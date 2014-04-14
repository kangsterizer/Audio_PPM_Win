using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX;
using SlimDX.DirectSound;

namespace AudioPPM
{
    class SoundCapture
    {
        SlimDX.DirectSound.DirectSoundCapture captureDevice = new SlimDX.DirectSound.DirectSoundCapture();
        SlimDX.Multimedia.WaveFormat waveFormat = new SlimDX.Multimedia.WaveFormat();

        public int GetAmplitude()
        {
            waveFormat.FormatTag = SlimDX.Multimedia.WaveFormatTag.Pcm;

            waveFormat.BitsPerSample = 16;
            waveFormat.BlockAlignment = (short)((waveFormat.BitsPerSample / 8));
            waveFormat.Channels = 1;
            waveFormat.SamplesPerSecond = 44100;
            waveFormat.AverageBytesPerSecond = waveFormat.SamplesPerSecond * waveFormat.BlockAlignment * waveFormat.Channels;

            SlimDX.DirectSound.CaptureBufferDescription bufferDescription = new SlimDX.DirectSound.CaptureBufferDescription();
            bufferDescription.BufferBytes = 8192;
            bufferDescription.Format = waveFormat;
            bufferDescription.WaveMapped = false;

            SlimDX.DirectSound.CaptureBuffer buffer = new SlimDX.DirectSound.CaptureBuffer(captureDevice, bufferDescription);
            buffer.Start(true);

            short[] samples = new short[5000];
            int max = 0;
            for (int i = 0; i < 1000; i++)
            {
                buffer.Read<short>(samples, 0, true);
                max = samples.Max();
                if (max != 0)
                    break;

            }

            buffer.Stop();
            buffer.Dispose();
            captureDevice.Dispose();

            return max;
        }
    }
}
