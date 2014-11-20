namespace WindowsOPC
{
    partial class FormReplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReplay));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.userControlRGY4 = new UserControlLib.UserControlRGY();
            this.userControlRGY3 = new UserControlLib.UserControlRGY();
            this.userControlRGY2 = new UserControlLib.UserControlRGY();
            this.userControlRGY1 = new UserControlLib.UserControlRGY();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelytCurZ = new System.Windows.Forms.Label();
            this.labelytCurY = new System.Windows.Forms.Label();
            this.labelytCurX = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelytInitZ = new System.Windows.Forms.Label();
            this.labelytInitY = new System.Windows.Forms.Label();
            this.labelytInitX = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_xiugai = new System.Windows.Forms.CheckBox();
            this.textBoxhlconfigV = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.textBoxhlconfigZ = new System.Windows.Forms.TextBox();
            this.textBoxhlconfigY = new System.Windows.Forms.TextBox();
            this.textBoxhlconfigX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "打开";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(155, 265);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "回放";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(14, 294);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(416, 15);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Visible = false;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(234, 265);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "暂停";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(95, 267);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(54, 21);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "200";
            this.textBox1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.userControlRGY4);
            this.groupBox1.Controls.Add(this.userControlRGY3);
            this.groupBox1.Controls.Add(this.userControlRGY2);
            this.groupBox1.Controls.Add(this.userControlRGY1);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 249);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "回放";
            // 
            // userControlRGY4
            // 
            this.userControlRGY4.Location = new System.Drawing.Point(265, 201);
            this.userControlRGY4.Name = "userControlRGY4";
            this.userControlRGY4.Size = new System.Drawing.Size(16, 16);
            this.userControlRGY4.TabIndex = 21;
            // 
            // userControlRGY3
            // 
            this.userControlRGY3.Location = new System.Drawing.Point(185, 201);
            this.userControlRGY3.Name = "userControlRGY3";
            this.userControlRGY3.Size = new System.Drawing.Size(16, 16);
            this.userControlRGY3.TabIndex = 20;
            // 
            // userControlRGY2
            // 
            this.userControlRGY2.Location = new System.Drawing.Point(105, 201);
            this.userControlRGY2.Name = "userControlRGY2";
            this.userControlRGY2.Size = new System.Drawing.Size(16, 16);
            this.userControlRGY2.TabIndex = 19;
            // 
            // userControlRGY1
            // 
            this.userControlRGY1.Location = new System.Drawing.Point(25, 201);
            this.userControlRGY1.Name = "userControlRGY1";
            this.userControlRGY1.Size = new System.Drawing.Size(16, 16);
            this.userControlRGY1.TabIndex = 18;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelytCurZ);
            this.groupBox4.Controls.Add(this.labelytCurY);
            this.groupBox4.Controls.Add(this.labelytCurX);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Location = new System.Drawing.Point(313, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(95, 164);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "云台当前坐标";
            // 
            // labelytCurZ
            // 
            this.labelytCurZ.AutoSize = true;
            this.labelytCurZ.ForeColor = System.Drawing.Color.Red;
            this.labelytCurZ.Location = new System.Drawing.Point(29, 74);
            this.labelytCurZ.Name = "labelytCurZ";
            this.labelytCurZ.Size = new System.Drawing.Size(11, 12);
            this.labelytCurZ.TabIndex = 16;
            this.labelytCurZ.Text = "0";
            // 
            // labelytCurY
            // 
            this.labelytCurY.AutoSize = true;
            this.labelytCurY.ForeColor = System.Drawing.Color.Red;
            this.labelytCurY.Location = new System.Drawing.Point(29, 46);
            this.labelytCurY.Name = "labelytCurY";
            this.labelytCurY.Size = new System.Drawing.Size(11, 12);
            this.labelytCurY.TabIndex = 15;
            this.labelytCurY.Text = "0";
            // 
            // labelytCurX
            // 
            this.labelytCurX.AutoSize = true;
            this.labelytCurX.ForeColor = System.Drawing.Color.Red;
            this.labelytCurX.Location = new System.Drawing.Point(29, 18);
            this.labelytCurX.Name = "labelytCurX";
            this.labelytCurX.Size = new System.Drawing.Size(11, 12);
            this.labelytCurX.TabIndex = 14;
            this.labelytCurX.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 74);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 13;
            this.label17.Text = "Z:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 46);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 12;
            this.label18.Text = "Y:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 18);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 12);
            this.label19.TabIndex = 11;
            this.label19.Text = "X:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelytInitZ);
            this.groupBox3.Controls.Add(this.labelytInitY);
            this.groupBox3.Controls.Add(this.labelytInitX);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(212, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(95, 164);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "云台初始坐标";
            // 
            // labelytInitZ
            // 
            this.labelytInitZ.AutoSize = true;
            this.labelytInitZ.ForeColor = System.Drawing.Color.Red;
            this.labelytInitZ.Location = new System.Drawing.Point(29, 74);
            this.labelytInitZ.Name = "labelytInitZ";
            this.labelytInitZ.Size = new System.Drawing.Size(11, 12);
            this.labelytInitZ.TabIndex = 16;
            this.labelytInitZ.Text = "0";
            // 
            // labelytInitY
            // 
            this.labelytInitY.AutoSize = true;
            this.labelytInitY.ForeColor = System.Drawing.Color.Red;
            this.labelytInitY.Location = new System.Drawing.Point(29, 46);
            this.labelytInitY.Name = "labelytInitY";
            this.labelytInitY.Size = new System.Drawing.Size(11, 12);
            this.labelytInitY.TabIndex = 15;
            this.labelytInitY.Text = "0";
            // 
            // labelytInitX
            // 
            this.labelytInitX.AutoSize = true;
            this.labelytInitX.ForeColor = System.Drawing.Color.Red;
            this.labelytInitX.Location = new System.Drawing.Point(29, 18);
            this.labelytInitX.Name = "labelytInitX";
            this.labelytInitX.Size = new System.Drawing.Size(11, 12);
            this.labelytInitX.TabIndex = 14;
            this.labelytInitX.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "Z:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "Y:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "X:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_xiugai);
            this.groupBox2.Controls.Add(this.textBoxhlconfigV);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.button10);
            this.groupBox2.Controls.Add(this.textBoxhlconfigZ);
            this.groupBox2.Controls.Add(this.textBoxhlconfigY);
            this.groupBox2.Controls.Add(this.textBoxhlconfigX);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(6, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 164);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "回零坐标设置";
            // 
            // checkBox_xiugai
            // 
            this.checkBox_xiugai.AutoSize = true;
            this.checkBox_xiugai.Location = new System.Drawing.Point(10, 127);
            this.checkBox_xiugai.Name = "checkBox_xiugai";
            this.checkBox_xiugai.Size = new System.Drawing.Size(72, 16);
            this.checkBox_xiugai.TabIndex = 4;
            this.checkBox_xiugai.Text = "是否修改";
            this.checkBox_xiugai.UseVisualStyleBackColor = true;
            this.checkBox_xiugai.CheckedChanged += new System.EventHandler(this.checkBox_xiugai_CheckedChanged);
            // 
            // textBoxhlconfigV
            // 
            this.textBoxhlconfigV.Location = new System.Drawing.Point(94, 96);
            this.textBoxhlconfigV.Name = "textBoxhlconfigV";
            this.textBoxhlconfigV.Size = new System.Drawing.Size(100, 21);
            this.textBoxhlconfigV.TabIndex = 3;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 99);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 12);
            this.label20.TabIndex = 17;
            this.label20.Text = "回零点速度:";
            // 
            // button10
            // 
            this.button10.Enabled = false;
            this.button10.Location = new System.Drawing.Point(94, 123);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 5;
            this.button10.Text = "修改";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // textBoxhlconfigZ
            // 
            this.textBoxhlconfigZ.Location = new System.Drawing.Point(94, 72);
            this.textBoxhlconfigZ.Name = "textBoxhlconfigZ";
            this.textBoxhlconfigZ.Size = new System.Drawing.Size(100, 21);
            this.textBoxhlconfigZ.TabIndex = 2;
            // 
            // textBoxhlconfigY
            // 
            this.textBoxhlconfigY.Location = new System.Drawing.Point(94, 48);
            this.textBoxhlconfigY.Name = "textBoxhlconfigY";
            this.textBoxhlconfigY.Size = new System.Drawing.Size(100, 21);
            this.textBoxhlconfigY.TabIndex = 1;
            // 
            // textBoxhlconfigX
            // 
            this.textBoxhlconfigX.Location = new System.Drawing.Point(94, 24);
            this.textBoxhlconfigX.Name = "textBoxhlconfigX";
            this.textBoxhlconfigX.Size = new System.Drawing.Size(100, 21);
            this.textBoxhlconfigX.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "回零坐标X:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "回零坐标Z:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "回零坐标Y:";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(344, 197);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 4;
            this.button9.Text = "清除";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(287, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(207, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(127, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(47, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "0";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(258, 220);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 3;
            this.button8.Text = "回放开始";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(177, 220);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 2;
            this.button7.Text = "回参考点";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(96, 220);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 1;
            this.button6.Text = "回零完成";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(15, 220);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "回放功能";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(344, 220);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "开始写入";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // FormReplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 276);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "回放";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxhlconfigZ;
        private System.Windows.Forms.TextBox textBoxhlconfigY;
        private System.Windows.Forms.TextBox textBoxhlconfigX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelytCurZ;
        private System.Windows.Forms.Label labelytCurY;
        private System.Windows.Forms.Label labelytCurX;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelytInitZ;
        private System.Windows.Forms.Label labelytInitY;
        private System.Windows.Forms.Label labelytInitX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxhlconfigV;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.CheckBox checkBox_xiugai;
        private UserControlLib.UserControlRGY userControlRGY1;
        private UserControlLib.UserControlRGY userControlRGY4;
        private UserControlLib.UserControlRGY userControlRGY3;
        private UserControlLib.UserControlRGY userControlRGY2;
    }
}