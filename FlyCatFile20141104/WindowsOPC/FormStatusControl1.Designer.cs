namespace WindowsOPC
{
    partial class FormStatusControl1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStatusControl1));
            this.label16 = new System.Windows.Forms.Label();
            this.userControlRGYTm31CommState2 = new UserControlLib.UserControlRGY();
            this.userControlRGYTm31CommState1 = new UserControlLib.UserControlRGY();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.labelTm31Alarm11 = new System.Windows.Forms.Label();
            this.labelTm31Alarm2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelMainServoAlarm1 = new System.Windows.Forms.Label();
            this.labelMainServoAlarm2 = new System.Windows.Forms.Label();
            this.labelMainServoAlarm3 = new System.Windows.Forms.Label();
            this.labelMainServoAlarm4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelMainControlAlarm1 = new System.Windows.Forms.Label();
            this.labelMainControlAlarm2 = new System.Windows.Forms.Label();
            this.labelMainControlAlarm3 = new System.Windows.Forms.Label();
            this.labelMainControlAlarm4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelD435ControlAlarm = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.userControlRGYAxisState = new UserControlLib.UserControlRGY();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 59);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 37;
            this.label16.Text = "TM31报警号";
            // 
            // userControlRGYTm31CommState2
            // 
            this.userControlRGYTm31CommState2.Location = new System.Drawing.Point(140, 36);
            this.userControlRGYTm31CommState2.Name = "userControlRGYTm31CommState2";
            this.userControlRGYTm31CommState2.Size = new System.Drawing.Size(16, 16);
            this.userControlRGYTm31CommState2.TabIndex = 36;
            // 
            // userControlRGYTm31CommState1
            // 
            this.userControlRGYTm31CommState1.Location = new System.Drawing.Point(90, 36);
            this.userControlRGYTm31CommState1.Name = "userControlRGYTm31CommState1";
            this.userControlRGYTm31CommState1.Size = new System.Drawing.Size(16, 16);
            this.userControlRGYTm31CommState1.TabIndex = 34;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 37;
            this.label1.Text = "TM31通讯状态";
            // 
            // labelTm31Alarm11
            // 
            this.labelTm31Alarm11.AutoSize = true;
            this.labelTm31Alarm11.ForeColor = System.Drawing.Color.Red;
            this.labelTm31Alarm11.Location = new System.Drawing.Point(90, 59);
            this.labelTm31Alarm11.Name = "labelTm31Alarm11";
            this.labelTm31Alarm11.Size = new System.Drawing.Size(11, 12);
            this.labelTm31Alarm11.TabIndex = 38;
            this.labelTm31Alarm11.Text = "0";
            // 
            // labelTm31Alarm2
            // 
            this.labelTm31Alarm2.AutoSize = true;
            this.labelTm31Alarm2.ForeColor = System.Drawing.Color.Red;
            this.labelTm31Alarm2.Location = new System.Drawing.Point(138, 59);
            this.labelTm31Alarm2.Name = "labelTm31Alarm2";
            this.labelTm31Alarm2.Size = new System.Drawing.Size(11, 12);
            this.labelTm31Alarm2.TabIndex = 38;
            this.labelTm31Alarm2.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 39;
            this.label2.Text = "主伺服报警号";
            // 
            // labelMainServoAlarm1
            // 
            this.labelMainServoAlarm1.AutoSize = true;
            this.labelMainServoAlarm1.ForeColor = System.Drawing.Color.Red;
            this.labelMainServoAlarm1.Location = new System.Drawing.Point(100, 42);
            this.labelMainServoAlarm1.Name = "labelMainServoAlarm1";
            this.labelMainServoAlarm1.Size = new System.Drawing.Size(11, 12);
            this.labelMainServoAlarm1.TabIndex = 39;
            this.labelMainServoAlarm1.Text = "0";
            // 
            // labelMainServoAlarm2
            // 
            this.labelMainServoAlarm2.AutoSize = true;
            this.labelMainServoAlarm2.ForeColor = System.Drawing.Color.Red;
            this.labelMainServoAlarm2.Location = new System.Drawing.Point(141, 42);
            this.labelMainServoAlarm2.Name = "labelMainServoAlarm2";
            this.labelMainServoAlarm2.Size = new System.Drawing.Size(11, 12);
            this.labelMainServoAlarm2.TabIndex = 39;
            this.labelMainServoAlarm2.Text = "0";
            // 
            // labelMainServoAlarm3
            // 
            this.labelMainServoAlarm3.AutoSize = true;
            this.labelMainServoAlarm3.ForeColor = System.Drawing.Color.Red;
            this.labelMainServoAlarm3.Location = new System.Drawing.Point(182, 42);
            this.labelMainServoAlarm3.Name = "labelMainServoAlarm3";
            this.labelMainServoAlarm3.Size = new System.Drawing.Size(11, 12);
            this.labelMainServoAlarm3.TabIndex = 39;
            this.labelMainServoAlarm3.Text = "0";
            // 
            // labelMainServoAlarm4
            // 
            this.labelMainServoAlarm4.AutoSize = true;
            this.labelMainServoAlarm4.ForeColor = System.Drawing.Color.Red;
            this.labelMainServoAlarm4.Location = new System.Drawing.Point(223, 42);
            this.labelMainServoAlarm4.Name = "labelMainServoAlarm4";
            this.labelMainServoAlarm4.Size = new System.Drawing.Size(11, 12);
            this.labelMainServoAlarm4.TabIndex = 39;
            this.labelMainServoAlarm4.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 39;
            this.label7.Text = "主控制器报警号";
            // 
            // labelMainControlAlarm1
            // 
            this.labelMainControlAlarm1.AutoSize = true;
            this.labelMainControlAlarm1.ForeColor = System.Drawing.Color.Red;
            this.labelMainControlAlarm1.Location = new System.Drawing.Point(100, 66);
            this.labelMainControlAlarm1.Name = "labelMainControlAlarm1";
            this.labelMainControlAlarm1.Size = new System.Drawing.Size(11, 12);
            this.labelMainControlAlarm1.TabIndex = 39;
            this.labelMainControlAlarm1.Text = "0";
            // 
            // labelMainControlAlarm2
            // 
            this.labelMainControlAlarm2.AutoSize = true;
            this.labelMainControlAlarm2.ForeColor = System.Drawing.Color.Red;
            this.labelMainControlAlarm2.Location = new System.Drawing.Point(141, 66);
            this.labelMainControlAlarm2.Name = "labelMainControlAlarm2";
            this.labelMainControlAlarm2.Size = new System.Drawing.Size(11, 12);
            this.labelMainControlAlarm2.TabIndex = 39;
            this.labelMainControlAlarm2.Text = "0";
            // 
            // labelMainControlAlarm3
            // 
            this.labelMainControlAlarm3.AutoSize = true;
            this.labelMainControlAlarm3.ForeColor = System.Drawing.Color.Red;
            this.labelMainControlAlarm3.Location = new System.Drawing.Point(182, 66);
            this.labelMainControlAlarm3.Name = "labelMainControlAlarm3";
            this.labelMainControlAlarm3.Size = new System.Drawing.Size(11, 12);
            this.labelMainControlAlarm3.TabIndex = 39;
            this.labelMainControlAlarm3.Text = "0";
            // 
            // labelMainControlAlarm4
            // 
            this.labelMainControlAlarm4.AutoSize = true;
            this.labelMainControlAlarm4.ForeColor = System.Drawing.Color.Red;
            this.labelMainControlAlarm4.Location = new System.Drawing.Point(223, 66);
            this.labelMainControlAlarm4.Name = "labelMainControlAlarm4";
            this.labelMainControlAlarm4.Size = new System.Drawing.Size(11, 12);
            this.labelMainControlAlarm4.TabIndex = 39;
            this.labelMainControlAlarm4.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 40;
            this.label3.Text = " D435控制器报警号";
            // 
            // labelD435ControlAlarm
            // 
            this.labelD435ControlAlarm.AutoSize = true;
            this.labelD435ControlAlarm.ForeColor = System.Drawing.Color.Red;
            this.labelD435ControlAlarm.Location = new System.Drawing.Point(141, 91);
            this.labelD435ControlAlarm.Name = "labelD435ControlAlarm";
            this.labelD435ControlAlarm.Size = new System.Drawing.Size(11, 12);
            this.labelD435ControlAlarm.TabIndex = 40;
            this.labelD435ControlAlarm.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 41;
            this.label4.Text = "W1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 41;
            this.label5.Text = "W2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(182, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 41;
            this.label6.Text = "W3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(223, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 41;
            this.label8.Text = "W4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.userControlRGYTm31CommState1);
            this.groupBox1.Controls.Add(this.userControlRGYTm31CommState2);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.labelTm31Alarm11);
            this.groupBox1.Controls.Add(this.labelTm31Alarm2);
            this.groupBox1.Location = new System.Drawing.Point(9, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 83);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TM31报警状态";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(139, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 39;
            this.label10.Text = "2#";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(88, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 38;
            this.label9.Text = "1#";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelMainServoAlarm1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.labelMainServoAlarm2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.labelMainControlAlarm1);
            this.groupBox2.Controls.Add(this.labelD435ControlAlarm);
            this.groupBox2.Controls.Add(this.labelMainServoAlarm3);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labelMainControlAlarm2);
            this.groupBox2.Controls.Add(this.labelMainControlAlarm4);
            this.groupBox2.Controls.Add(this.labelMainControlAlarm3);
            this.groupBox2.Controls.Add(this.labelMainServoAlarm4);
            this.groupBox2.Location = new System.Drawing.Point(9, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 124);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "报警信息";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.userControlRGYAxisState);
            this.groupBox3.Location = new System.Drawing.Point(188, 142);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(88, 83);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "轴误差状态";
            // 
            // userControlRGYAxisState
            // 
            this.userControlRGYAxisState.Location = new System.Drawing.Point(65, 36);
            this.userControlRGYAxisState.Name = "userControlRGYAxisState";
            this.userControlRGYAxisState.Size = new System.Drawing.Size(16, 16);
            this.userControlRGYAxisState.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 40;
            this.label11.Text = "是否正常";
            // 
            // FormStatusControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 258);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(292, 292);
            this.MinimumSize = new System.Drawing.Size(292, 292);
            this.Name = "FormStatusControl1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "报警查看";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private UserControlLib.UserControlRGY userControlRGYTm31CommState2;
        private UserControlLib.UserControlRGY userControlRGYTm31CommState1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTm31Alarm11;
        private System.Windows.Forms.Label labelTm31Alarm2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelMainServoAlarm1;
        private System.Windows.Forms.Label labelMainServoAlarm2;
        private System.Windows.Forms.Label labelMainServoAlarm3;
        private System.Windows.Forms.Label labelMainServoAlarm4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelMainControlAlarm1;
        private System.Windows.Forms.Label labelMainControlAlarm2;
        private System.Windows.Forms.Label labelMainControlAlarm3;
        private System.Windows.Forms.Label labelMainControlAlarm4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelD435ControlAlarm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private UserControlLib.UserControlRGY userControlRGYAxisState;

    }
}