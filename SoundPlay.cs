using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX;
using SlimDX.XAudio2;
using SlimDX.Multimedia;
using SlimDX.DirectSound;
using System.IO;
using WaveLibrary;
using System.Windows.Forms;

namespace AudioPPM
{
    public class SoundPlay: IDisposable
    {
        private XAudio2 device;
        private MasteringVoice masteringVoice;
        private AudioBuffer buffer;
        private SourceVoice srcVoice;
        private WaveFormat wf;
        private MemoryStream ms;

        private double microsec;
        private List<short> frame;
        private int PPMSamples;

        public Dictionary<int, double> PPMchannels;
        public short channels;
        public short Amplitude;
        public int Rate;

        public Object channels_lock = new Object();

        public byte[] GenPPM()
        {
            frame.Clear();
            //PPM "Stop/Start"
            try
            {
                frame.AddRange(Enumerable.Repeat((short)-Amplitude, (int)(4 * microsec * channels)));
            }
            catch { }

            //channels
            lock (channels_lock)
            {
                foreach (int i in PPMchannels.Keys)
                {
                    try
                    {
                        //PPM base
                        frame.AddRange(Enumerable.Repeat(Amplitude, (int)(7 * microsec * channels)));
                        //PPM Signal
                        frame.AddRange(Enumerable.Repeat(Amplitude, (int)((PPMchannels[i] * 0.75 / 100) * 10 * microsec * channels)));
                        //PPM Signal end
                        frame.AddRange(Enumerable.Repeat((short)-Amplitude, (int)(4 * microsec * channels)));
                    }
                    catch { }
                }
            }

            //Complete the PPM signal with leading blank
            frame.InsertRange(0, new short[(PPMSamples - frame.Count)]);

            var data = new List<byte>();
            try
            {
                foreach (short dp in frame)
                    data.AddRange(System.BitConverter.GetBytes(dp));
            } catch {
            }
            return data.ToArray();
        }

        public void PlayPPM(IntPtr win)
        {
            Rate = 192000; //44100 on cheapo, 96000 on AC97, 192000 on HD Audio
            channels = 2;
            PPMSamples = (int)(0.0220 * Rate*channels); // 22 or 22.5ms in samples, rounded up
            microsec = Rate/10000.0; // 192 = 1ms, 19.2 = 0.1ms or 1mis @ 192khz
            PPMchannels = new Dictionary<int, double>();
            frame = new List<short>();
            Amplitude = 32760;

            /*WaveFile wFile;
            wFile = new WaveFile(channels, 16, Rate);
            */

            //Set channels to neutral except throttle, to zero.
            PPMchannels.Add(1, 0.0); //Throttle
            PPMchannels.Add(2, 50.0); //Ailerons
            PPMchannels.Add(3, 50.0); //Stab
            PPMchannels.Add(4, 50.0); //Rudder
            PPMchannels.Add(5, 50.0);
            PPMchannels.Add(6, 50.0);
            PPMchannels.Add(7, 50.0);
            PPMchannels.Add(8, 50.0);

            byte [] data = GenPPM();

            /*wFile.SetData(data, data.Length);
            wFile.WriteFile(@"C:\Users\kang\Desktop\test.wav");
            */
            ms = new MemoryStream();
            ms.SetLength(0);
            ms.Write(data, 0, data.Length);
            ms.Position = 0;

            wf = new WaveFormat();
            wf.FormatTag = WaveFormatTag.Pcm;
            wf.BitsPerSample = (short)16;
            wf.Channels = channels;
            wf.SamplesPerSecond = Rate;
            wf.BlockAlignment = (short)(wf.Channels * wf.BitsPerSample/8);
            wf.AverageBytesPerSecond = wf.SamplesPerSecond * wf.BlockAlignment;

            device = new XAudio2();
            device.StartEngine();
            masteringVoice = new MasteringVoice(device);
            srcVoice = new SourceVoice(device, wf);
            buffer = new AudioBuffer();
            buffer.AudioData = ms;
            buffer.AudioBytes = (int)data.Length;
            buffer.Flags = SlimDX.XAudio2.BufferFlags.None;

            srcVoice.BufferStart += new EventHandler<ContextEventArgs>(srcVoice_BufferStart);
            srcVoice.FrequencyRatio = 1;
            srcVoice.SubmitSourceBuffer(buffer);
            srcVoice.Start();
        }

        
        public void srcVoice_BufferStart(object sender, ContextEventArgs e)
        {
            byte[] data = GenPPM();

            ms.SetLength(0);
            ms.Write(data, 0, data.Length);
            ms.Position = 0;

            try
            {
                srcVoice.SubmitSourceBuffer(buffer);
                srcVoice.Start();
            }
            catch
            {
                buffer.Flags = SlimDX.XAudio2.BufferFlags.EndOfStream;
                srcVoice.Stop();
            }
            
        }

        public void StopPPM()
        {
            try
            {
                buffer.Flags = SlimDX.XAudio2.BufferFlags.EndOfStream;
            }
            catch { }
            try
            {
                srcVoice.Stop();
            }
            catch { }
        }

        public void Dispose()
        {
            buffer.Dispose();
            srcVoice.Dispose();
            masteringVoice.Dispose();
            device.Dispose();
        }
    }
}
