namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timerJoystickRead = new System.Windows.Forms.Timer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LXAxis = new System.Windows.Forms.Label();
            this.LYAxis = new System.Windows.Forms.Label();
            this.LZRotation = new System.Windows.Forms.Label();
            this.LThrottle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CBJoystick = new System.Windows.Forms.ComboBox();
            this.EDeadZ = new System.Windows.Forms.TextBox();
            this.EDeadY = new System.Windows.Forms.TextBox();
            this.EDeadX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BEnablePPM = new System.Windows.Forms.Button();
            this.BDetectPPMAmplitude = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.EAmplitude = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.aboutAudioPPMJoystickInterfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.enablePPMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerJoystickRead
            // 
            this.timerJoystickRead.Tick += new System.EventHandler(this.timerJoystickRead_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X Axis:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y Axis:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Throttle:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Z Rotation:";
            // 
            // LXAxis
            // 
            this.LXAxis.AutoSize = true;
            this.LXAxis.Location = new System.Drawing.Point(95, 70);
            this.LXAxis.Name = "LXAxis";
            this.LXAxis.Size = new System.Drawing.Size(13, 13);
            this.LXAxis.TabIndex = 4;
            this.LXAxis.Text = "0";
            // 
            // LYAxis
            // 
            this.LYAxis.AutoSize = true;
            this.LYAxis.Location = new System.Drawing.Point(95, 95);
            this.LYAxis.Name = "LYAxis";
            this.LYAxis.Size = new System.Drawing.Size(13, 13);
            this.LYAxis.TabIndex = 5;
            this.LYAxis.Text = "0";
            // 
            // LZRotation
            // 
            this.LZRotation.AutoSize = true;
            this.LZRotation.Location = new System.Drawing.Point(95, 122);
            this.LZRotation.Name = "LZRotation";
            this.LZRotation.Size = new System.Drawing.Size(13, 13);
            this.LZRotation.TabIndex = 6;
            this.LZRotation.Text = "0";
            // 
            // LThrottle
            // 
            this.LThrottle.AutoSize = true;
            this.LThrottle.Location = new System.Drawing.Point(95, 148);
            this.LThrottle.Name = "LThrottle";
            this.LThrottle.Size = new System.Drawing.Size(13, 13);
            this.LThrottle.TabIndex = 7;
            this.LThrottle.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CBJoystick);
            this.groupBox1.Controls.Add(this.EDeadZ);
            this.groupBox1.Controls.Add(this.EDeadY);
            this.groupBox1.Controls.Add(this.EDeadX);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LThrottle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.LZRotation);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LYAxis);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.LXAxis);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 173);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Joystick Settings";
            // 
            // CBJoystick
            // 
            this.CBJoystick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBJoystick.FormattingEnabled = true;
            this.CBJoystick.Location = new System.Drawing.Point(19, 19);
            this.CBJoystick.Name = "CBJoystick";
            this.CBJoystick.Size = new System.Drawing.Size(361, 21);
            this.CBJoystick.TabIndex = 16;
            this.CBJoystick.SelectionChangeCommitted += new System.EventHandler(this.CBJoystick_SelectionChangeCommitted);
            // 
            // EDeadZ
            // 
            this.EDeadZ.Location = new System.Drawing.Point(313, 122);
            this.EDeadZ.Name = "EDeadZ";
            this.EDeadZ.Size = new System.Drawing.Size(67, 20);
            this.EDeadZ.TabIndex = 13;
            this.EDeadZ.Text = "5";
            // 
            // EDeadY
            // 
            this.EDeadY.Location = new System.Drawing.Point(313, 95);
            this.EDeadY.Name = "EDeadY";
            this.EDeadY.Size = new System.Drawing.Size(67, 20);
            this.EDeadY.TabIndex = 12;
            this.EDeadY.Text = "5";
            // 
            // EDeadX
            // 
            this.EDeadX.Location = new System.Drawing.Point(313, 67);
            this.EDeadX.Name = "EDeadX";
            this.EDeadX.Size = new System.Drawing.Size(67, 20);
            this.EDeadX.TabIndex = 11;
            this.EDeadX.Text = "5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(175, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Z Rotation dead zone:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Y Axis dead zone:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "X Axis dead zone:";
            // 
            // BEnablePPM
            // 
            this.BEnablePPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEnablePPM.Location = new System.Drawing.Point(308, 263);
            this.BEnablePPM.Name = "BEnablePPM";
            this.BEnablePPM.Size = new System.Drawing.Size(99, 22);
            this.BEnablePPM.TabIndex = 9;
            this.BEnablePPM.Text = "Enable PPM";
            this.BEnablePPM.UseVisualStyleBackColor = true;
            this.BEnablePPM.Click += new System.EventHandler(this.BEnablePPM_Click);
            // 
            // BDetectPPMAmplitude
            // 
            this.BDetectPPMAmplitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BDetectPPMAmplitude.Location = new System.Drawing.Point(19, 29);
            this.BDetectPPMAmplitude.Name = "BDetectPPMAmplitude";
            this.BDetectPPMAmplitude.Size = new System.Drawing.Size(130, 22);
            this.BDetectPPMAmplitude.TabIndex = 10;
            this.BDetectPPMAmplitude.Text = "Detect PPM Amplitude";
            this.BDetectPPMAmplitude.UseVisualStyleBackColor = true;
            this.BDetectPPMAmplitude.Click += new System.EventHandler(this.BDetectPPMAmplitude_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(175, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Amplitude:";
            // 
            // EAmplitude
            // 
            this.EAmplitude.Location = new System.Drawing.Point(313, 29);
            this.EAmplitude.Name = "EAmplitude";
            this.EAmplitude.Size = new System.Drawing.Size(67, 20);
            this.EAmplitude.TabIndex = 14;
            this.EAmplitude.Text = "32760";
            this.EAmplitude.TextChanged += new System.EventHandler(this.EAmplitude_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BDetectPPMAmplitude);
            this.groupBox2.Controls.Add(this.EAmplitude);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 66);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PPM Settings";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipTitle = "Audio PPM Information";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Audio PPM Joystick Interface";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutAudioPPMJoystickInterfaceToolStripMenuItem,
            this.toolStripMenuItem2,
            this.enablePPMToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(264, 104);
            // 
            // aboutAudioPPMJoystickInterfaceToolStripMenuItem
            // 
            this.aboutAudioPPMJoystickInterfaceToolStripMenuItem.Name = "aboutAudioPPMJoystickInterfaceToolStripMenuItem";
            this.aboutAudioPPMJoystickInterfaceToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.aboutAudioPPMJoystickInterfaceToolStripMenuItem.Text = "About Audio PPM Joystick Interface";
            this.aboutAudioPPMJoystickInterfaceToolStripMenuItem.Click += new System.EventHandler(this.aboutAudioPPMJoystickInterfaceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(260, 6);
            // 
            // enablePPMToolStripMenuItem
            // 
            this.enablePPMToolStripMenuItem.Name = "enablePPMToolStripMenuItem";
            this.enablePPMToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.enablePPMToolStripMenuItem.Text = "Enable PPM";
            this.enablePPMToolStripMenuItem.Click += new System.EventHandler(this.enablePPMToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(260, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 297);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BEnablePPM);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(435, 335);
            this.MinimumSize = new System.Drawing.Size(435, 335);
            this.Name = "Form1";
            this.Text = "Audio PPM Joystick Interface";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerJoystickRead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LXAxis;
        private System.Windows.Forms.Label LYAxis;
        private System.Windows.Forms.Label LZRotation;
        private System.Windows.Forms.Label LThrottle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox EDeadZ;
        private System.Windows.Forms.TextBox EDeadY;
        private System.Windows.Forms.TextBox EDeadX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BEnablePPM;
        private System.Windows.Forms.Button BDetectPPMAmplitude;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox EAmplitude;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CBJoystick;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enablePPMToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutAudioPPMJoystickInterfaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}

