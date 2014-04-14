using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using SlimDX;
using SlimDX.DirectInput;
using SlimDX.DirectSound;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private static List<Joystick> joysticks = new List<Joystick>();
        private static int cj = 0;
        private static JoystickState state = new JoystickState();
        private AudioPPM.SoundPlay sndplay;
        private bool playing = false;

        void CreateDevice()
        {
            DirectInput dinput = new DirectInput();
            int joy = 0;

            foreach (DeviceInstance device in dinput.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                try
                {
                    joysticks.Add(new Joystick(dinput, device.InstanceGuid));
                    CBJoystick.Items.Add(joysticks[joy].Information.ProductName);
                    joy++;
                }
                catch (DirectInputException)
                {
                }
            }

            if (joysticks.Count == 0)
            {
                MessageBox.Show("There are no joysticks attached to the system! Plug a joystick in and restart the program if you want to use a joystick.");
                return;
            }
            else
            {
                CBJoystick.SelectedIndex = cj;
                joysticks[cj].SetCooperativeLevel(this, SlimDX.DirectInput.CooperativeLevel.Exclusive | SlimDX.DirectInput.CooperativeLevel.Background);
            }


            foreach (DeviceObjectInstance deviceObject in joysticks[cj].GetObjects())
            {
                if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                    joysticks[cj].GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(0, 1000);
            }
            joysticks[cj].Acquire();
            timerJoystickRead.Interval = 1000 / 50;
            timerJoystickRead.Start();
        }

        void ReadImmediateData()
        {
            if (joysticks[cj].Acquire().IsFailure)
                return;

            if (joysticks[cj].Poll().IsFailure)
                return;

            state = joysticks[cj].GetCurrentState();
            if (Result.Last.IsFailure)
                return;

            //All we need for now, X, Y, Z-rotation and throttle.
            LXAxis.Text = state.X.ToString(CultureInfo.CurrentCulture);
            LYAxis.Text = state.Y.ToString(CultureInfo.CurrentCulture);
            LZRotation.Text = state.RotationZ.ToString(CultureInfo.CurrentCulture);
            int[] slider = state.GetSliders();
            LThrottle.Text = slider[0].ToString(CultureInfo.CurrentCulture);
            //tell PPM stuff what to do
            if (playing)
            {
                lock (sndplay.channels_lock)
                {
                    int Xval, Yval, Zval = 0;
                    sndplay.PPMchannels[1] = 100-(slider[0]/10);

                    Int32.TryParse(EDeadX.Text, out Xval);
                    Int32.TryParse(EDeadY.Text, out Yval);
                    Int32.TryParse(EDeadZ.Text, out Zval);

                    if ((state.X > 500+Xval) || (state.X < 500-Xval))
                        sndplay.PPMchannels[2] = 100-(state.X/10);
                    if ((state.Y > 500+Yval) || (state.Y < 500-Yval))
                        sndplay.PPMchannels[3] = 100-(state.Y/10);
                    if ((state.RotationZ > 500+Zval) || (state.RotationZ < 500-Zval))
                        sndplay.PPMchannels[4] = 100-(state.RotationZ/10);
                }
            }
        }

        void ReleaseDevice(Joystick j)
        {
            timerJoystickRead.Stop();
            if (j != null)
            {
                try
                {
                    j.Unacquire();
                    j.Dispose();
                }
                catch { }
            }
            j = null;
        }

        public Form1()
        {
            InitializeComponent();
            sndplay = new AudioPPM.SoundPlay();
            CreateDevice();
            Show();
        }

        private void timerJoystickRead_Tick(object sender, EventArgs e)
        {
            ReadImmediateData();
        }

        private void Terminate()
        {
            sndplay.StopPPM();
            foreach (Joystick j in joysticks)
                ReleaseDevice(j);
            notifyIcon1.Visible = false;
            Application.Exit();
        }

        private void EnableDisable()
        {
            if (!playing)
            {
                BEnablePPM.Text = "Disable PPM";
                contextMenuStrip1.Items[2].Text = "Disable PPM";
                sndplay.PlayPPM(this.Handle);
                playing = true;
            }
            else
            {
                BEnablePPM.Text = "Enable PPM";
                contextMenuStrip1.Items[2].Text = "Enable PPM";
                sndplay.StopPPM();
                playing = false;
            }
        }

        private void BEnablePPM_Click(object sender, EventArgs e)
        {
            EnableDisable();
        }

        private void BDetectPPMAmplitude_Click(object sender, EventArgs e)
        {
            AudioPPM.SoundCapture sndcap = new AudioPPM.SoundCapture();
            EAmplitude.Text = sndcap.GetAmplitude().ToString();
        }

        private void CBJoystick_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                joysticks[cj].Unacquire();
            }
            catch { }

            try
            {
                cj = CBJoystick.SelectedIndex;
                joysticks[cj].SetCooperativeLevel(this, SlimDX.DirectInput.CooperativeLevel.Exclusive | SlimDX.DirectInput.CooperativeLevel.Background);
            }
            catch (DirectInputException)
            {
                cj = -1;
                CBJoystick.SelectedIndex = cj;
                // MessageBox.Show("The selected joystick could not be selected. It might be already used by another application in exclusive mode.");
            }

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (!this.Visible)
                Show();
            else
                Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Terminate();
        }

        private void enablePPMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableDisable();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Terminate();
            Application.Exit();//have to exit again, noob .NET
        }

        private void EAmplitude_TextChanged(object sender, EventArgs e)
        {
            short val = 32760; //Default amplitude
            if (Int16.TryParse(EAmplitude.Text, out val))
                sndplay.Amplitude = val;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                
                this.WindowState = FormWindowState.Normal;
                Hide();
                notifyIcon1.BalloonTipText = "Audio PPM Joystick Interface is here!";
                notifyIcon1.ShowBalloonTip(10000);
            }
        }

        private void aboutAudioPPMJoystickInterfaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AudioPPM.AboutForm();
        }
    }
}
