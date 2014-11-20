namespace WindowsOPC
{
    partial class FormCalibration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalibration));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelSensitiveZ = new System.Windows.Forms.Label();
            this.labelSensitiveXY = new System.Windows.Forms.Label();
            this.labelPaceZ = new System.Windows.Forms.Label();
            this.labelMaxPace = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarSensitiveZ = new System.Windows.Forms.TrackBar();
            this.trackBarSensitiveXY = new System.Windows.Forms.TrackBar();
            this.trackBarPaceZ = new System.Windows.Forms.TrackBar();
            this.trackBarMaxPace = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cwTrackBarDub2ZnMaxNum = new UserControlLib.CWTrackBarDub2();
            this.labelZZeroOffset = new System.Windows.Forms.Label();
            this.labelZnMaxNumRight = new System.Windows.Forms.Label();
            this.labelZnMaxNumLeft = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cwTrackBar2ZZeroOffset = new UserControlLib.CWTrackBar2();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelYnMaxNumRight = new System.Windows.Forms.Label();
            this.cwTrackBarDub2YnMaxNum = new UserControlLib.CWTrackBarDub2();
            this.labelYnMaxNumLeft = new System.Windows.Forms.Label();
            this.labelYZeroOffset = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cwTrackBar2YZeroOffset = new UserControlLib.CWTrackBar2();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelXnMaxNumRight = new System.Windows.Forms.Label();
            this.labelXnMaxNumLeft = new System.Windows.Forms.Label();
            this.cwTrackBarDub2XnMaxNum = new UserControlLib.CWTrackBarDub2();
            this.labelXZeroOffset = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cwTrackBar2XZeroOffset = new UserControlLib.CWTrackBar2();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelsys_dead_area_xLeft = new System.Windows.Forms.Label();
            this.labelsys_dead_area_xRight = new System.Windows.Forms.Label();
            this.labelsys_dead_area_yLeft = new System.Windows.Forms.Label();
            this.labelsys_dead_area_yRight = new System.Windows.Forms.Label();
            this.labelsys_dead_area_zLeft = new System.Windows.Forms.Label();
            this.labelsys_dead_area_zRight = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSensitiveZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSensitiveXY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPaceZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMaxPace)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelSensitiveZ);
            this.groupBox1.Controls.Add(this.labelSensitiveXY);
            this.groupBox1.Controls.Add(this.labelPaceZ);
            this.groupBox1.Controls.Add(this.labelMaxPace);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.trackBarSensitiveZ);
            this.groupBox1.Controls.Add(this.trackBarSensitiveXY);
            this.groupBox1.Controls.Add(this.trackBarPaceZ);
            this.groupBox1.Controls.Add(this.trackBarMaxPace);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 237);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "最大最下值设置";
            // 
            // labelSensitiveZ
            // 
            this.labelSensitiveZ.AutoSize = true;
            this.labelSensitiveZ.Location = new System.Drawing.Point(6, 205);
            this.labelSensitiveZ.Name = "labelSensitiveZ";
            this.labelSensitiveZ.Size = new System.Drawing.Size(11, 12);
            this.labelSensitiveZ.TabIndex = 4;
            this.labelSensitiveZ.Text = "0";
            // 
            // labelSensitiveXY
            // 
            this.labelSensitiveXY.AutoSize = true;
            this.labelSensitiveXY.Location = new System.Drawing.Point(6, 152);
            this.labelSensitiveXY.Name = "labelSensitiveXY";
            this.labelSensitiveXY.Size = new System.Drawing.Size(11, 12);
            this.labelSensitiveXY.TabIndex = 4;
            this.labelSensitiveXY.Text = "0";
            // 
            // labelPaceZ
            // 
            this.labelPaceZ.AutoSize = true;
            this.labelPaceZ.Location = new System.Drawing.Point(6, 103);
            this.labelPaceZ.Name = "labelPaceZ";
            this.labelPaceZ.Size = new System.Drawing.Size(11, 12);
            this.labelPaceZ.TabIndex = 4;
            this.labelPaceZ.Text = "0";
            // 
            // labelMaxPace
            // 
            this.labelMaxPace.AutoSize = true;
            this.labelMaxPace.Location = new System.Drawing.Point(6, 50);
            this.labelMaxPace.Name = "labelMaxPace";
            this.labelMaxPace.Size = new System.Drawing.Size(11, 12);
            this.labelMaxPace.TabIndex = 3;
            this.labelMaxPace.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "灵敏度Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "最大速度Z";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "灵敏度XY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "最大速度XY";
            // 
            // trackBarSensitiveZ
            // 
            this.trackBarSensitiveZ.Location = new System.Drawing.Point(79, 177);
            this.trackBarSensitiveZ.Name = "trackBarSensitiveZ";
            this.trackBarSensitiveZ.Size = new System.Drawing.Size(262, 45);
            this.trackBarSensitiveZ.TabIndex = 1;
            this.trackBarSensitiveZ.ValueChanged += new System.EventHandler(this.trackBarSensitiveZ_ValueChanged);
            // 
            // trackBarSensitiveXY
            // 
            this.trackBarSensitiveXY.Location = new System.Drawing.Point(79, 124);
            this.trackBarSensitiveXY.Name = "trackBarSensitiveXY";
            this.trackBarSensitiveXY.Size = new System.Drawing.Size(262, 45);
            this.trackBarSensitiveXY.TabIndex = 1;
            this.trackBarSensitiveXY.ValueChanged += new System.EventHandler(this.trackBarSensitiveXY_ValueChanged);
            // 
            // trackBarPaceZ
            // 
            this.trackBarPaceZ.Location = new System.Drawing.Point(79, 71);
            this.trackBarPaceZ.Name = "trackBarPaceZ";
            this.trackBarPaceZ.Size = new System.Drawing.Size(262, 45);
            this.trackBarPaceZ.TabIndex = 1;
            this.trackBarPaceZ.ValueChanged += new System.EventHandler(this.trackBarPaceZ_ValueChanged);
            // 
            // trackBarMaxPace
            // 
            this.trackBarMaxPace.Location = new System.Drawing.Point(79, 18);
            this.trackBarMaxPace.Name = "trackBarMaxPace";
            this.trackBarMaxPace.Size = new System.Drawing.Size(262, 45);
            this.trackBarMaxPace.TabIndex = 1;
            this.trackBarMaxPace.ValueChanged += new System.EventHandler(this.trackBarMaxPace_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.trackBar2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.trackBar1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(9, 249);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 161);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "其他设置";
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(78, 63);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(262, 45);
            this.trackBar2.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "加速度Z";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(78, 12);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(262, 45);
            this.trackBar1.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "加速度XY";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(26, 136);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(72, 16);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.Text = "使能摇杆";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(26, 114);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 16);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "取反上下摇杆方向";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(270, 565);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(368, 554);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(360, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "校正";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.labelsys_dead_area_zRight);
            this.groupBox5.Controls.Add(this.cwTrackBarDub2ZnMaxNum);
            this.groupBox5.Controls.Add(this.labelZZeroOffset);
            this.groupBox5.Controls.Add(this.labelsys_dead_area_zLeft);
            this.groupBox5.Controls.Add(this.labelZnMaxNumRight);
            this.groupBox5.Controls.Add(this.labelZnMaxNumLeft);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.cwTrackBar2ZZeroOffset);
            this.groupBox5.Location = new System.Drawing.Point(6, 352);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(347, 174);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Z";
            // 
            // cwTrackBarDub2ZnMaxNum
            // 
            this.cwTrackBarDub2ZnMaxNum.CW_ValueProcessLeft = 0;
            this.cwTrackBarDub2ZnMaxNum.CW_ValueProcessRight = 0;
            this.cwTrackBarDub2ZnMaxNum.Location = new System.Drawing.Point(13, 29);
            this.cwTrackBarDub2ZnMaxNum.MaxnumLeft = 100;
            this.cwTrackBarDub2ZnMaxNum.MaxnumRight = 100;
            this.cwTrackBarDub2ZnMaxNum.Name = "cwTrackBarDub2ZnMaxNum";
            this.cwTrackBarDub2ZnMaxNum.Size = new System.Drawing.Size(322, 70);
            this.cwTrackBarDub2ZnMaxNum.TabIndex = 6;
            this.cwTrackBarDub2ZnMaxNum.CW_ValueChangedLeftUp += new UserControlLib.CWTrackBarDub2.CW_ValueChangedLeftUpEventHandler(this.cwTrackBarDub2ZnMaxNum_CW_ValueChangedLeftUp);
            this.cwTrackBarDub2ZnMaxNum.CW_ValueChangedRightUp += new UserControlLib.CWTrackBarDub2.CW_ValueChangedRightUpEventHandler(this.cwTrackBarDub2ZnMaxNum_CW_ValueChangedRightUp);
            this.cwTrackBarDub2ZnMaxNum.CW_ValueChangedLeftDown += new UserControlLib.CWTrackBarDub2.CW_ValueChangedLeftDownEventHandler(this.cwTrackBarDub2ZnMaxNum_CW_ValueChangedLeftDown);
            this.cwTrackBarDub2ZnMaxNum.CW_ValueChangedRightDown += new UserControlLib.CWTrackBarDub2.CW_ValueChangedRightDownEventHandler(this.cwTrackBarDub2ZnMaxNum_CW_ValueChangedRightDown);
            // 
            // labelZZeroOffset
            // 
            this.labelZZeroOffset.AutoSize = true;
            this.labelZZeroOffset.Location = new System.Drawing.Point(169, 122);
            this.labelZZeroOffset.Name = "labelZZeroOffset";
            this.labelZZeroOffset.Size = new System.Drawing.Size(11, 12);
            this.labelZZeroOffset.TabIndex = 8;
            this.labelZZeroOffset.Text = "0";
            // 
            // labelZnMaxNumRight
            // 
            this.labelZnMaxNumRight.AutoSize = true;
            this.labelZnMaxNumRight.Location = new System.Drawing.Point(232, 14);
            this.labelZnMaxNumRight.Name = "labelZnMaxNumRight";
            this.labelZnMaxNumRight.Size = new System.Drawing.Size(11, 12);
            this.labelZnMaxNumRight.TabIndex = 9;
            this.labelZnMaxNumRight.Text = "0";
            // 
            // labelZnMaxNumLeft
            // 
            this.labelZnMaxNumLeft.AutoSize = true;
            this.labelZnMaxNumLeft.Location = new System.Drawing.Point(112, 14);
            this.labelZnMaxNumLeft.Name = "labelZnMaxNumLeft";
            this.labelZnMaxNumLeft.Size = new System.Drawing.Size(11, 12);
            this.labelZnMaxNumLeft.TabIndex = 9;
            this.labelZnMaxNumLeft.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "Z漂移";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 6;
            this.label12.Text = "正负最大值";
            // 
            // cwTrackBar2ZZeroOffset
            // 
            this.cwTrackBar2ZZeroOffset.CWMaxinum = 10000;
            this.cwTrackBar2ZZeroOffset.CWValue = 0;
            this.cwTrackBar2ZZeroOffset.Location = new System.Drawing.Point(13, 137);
            this.cwTrackBar2ZZeroOffset.Name = "cwTrackBar2ZZeroOffset";
            this.cwTrackBar2ZZeroOffset.Size = new System.Drawing.Size(322, 45);
            this.cwTrackBar2ZZeroOffset.TabIndex = 2;
            this.cwTrackBar2ZZeroOffset.CW_ValueChanged += new UserControlLib.CWTrackBar2.CW_ValueChangedEventHandler(this.cwTrackBar2ZZeroOffset_CW_ValueChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelsys_dead_area_yRight);
            this.groupBox4.Controls.Add(this.labelYnMaxNumRight);
            this.groupBox4.Controls.Add(this.labelsys_dead_area_yLeft);
            this.groupBox4.Controls.Add(this.cwTrackBarDub2YnMaxNum);
            this.groupBox4.Controls.Add(this.labelYnMaxNumLeft);
            this.groupBox4.Controls.Add(this.labelYZeroOffset);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.cwTrackBar2YZeroOffset);
            this.groupBox4.Location = new System.Drawing.Point(6, 175);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(347, 175);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Y";
            // 
            // labelYnMaxNumRight
            // 
            this.labelYnMaxNumRight.AutoSize = true;
            this.labelYnMaxNumRight.Location = new System.Drawing.Point(232, 14);
            this.labelYnMaxNumRight.Name = "labelYnMaxNumRight";
            this.labelYnMaxNumRight.Size = new System.Drawing.Size(11, 12);
            this.labelYnMaxNumRight.TabIndex = 9;
            this.labelYnMaxNumRight.Text = "0";
            // 
            // cwTrackBarDub2YnMaxNum
            // 
            this.cwTrackBarDub2YnMaxNum.CW_ValueProcessLeft = 0;
            this.cwTrackBarDub2YnMaxNum.CW_ValueProcessRight = 0;
            this.cwTrackBarDub2YnMaxNum.Location = new System.Drawing.Point(13, 30);
            this.cwTrackBarDub2YnMaxNum.MaxnumLeft = 100;
            this.cwTrackBarDub2YnMaxNum.MaxnumRight = 100;
            this.cwTrackBarDub2YnMaxNum.Name = "cwTrackBarDub2YnMaxNum";
            this.cwTrackBarDub2YnMaxNum.Size = new System.Drawing.Size(322, 70);
            this.cwTrackBarDub2YnMaxNum.TabIndex = 6;
            this.cwTrackBarDub2YnMaxNum.CW_ValueChangedLeftUp += new UserControlLib.CWTrackBarDub2.CW_ValueChangedLeftUpEventHandler(this.cwTrackBarDub2YnMaxNum_CW_ValueChangedLeftUp);
            this.cwTrackBarDub2YnMaxNum.CW_ValueChangedRightUp += new UserControlLib.CWTrackBarDub2.CW_ValueChangedRightUpEventHandler(this.cwTrackBarDub2YnMaxNum_CW_ValueChangedRightUp);
            this.cwTrackBarDub2YnMaxNum.CW_ValueChangedLeftDown += new UserControlLib.CWTrackBarDub2.CW_ValueChangedLeftDownEventHandler(this.cwTrackBarDub2YnMaxNum_CW_ValueChangedLeftDown);
            this.cwTrackBarDub2YnMaxNum.CW_ValueChangedRightDown += new UserControlLib.CWTrackBarDub2.CW_ValueChangedRightDownEventHandler(this.cwTrackBarDub2YnMaxNum_CW_ValueChangedRightDown);
            // 
            // labelYnMaxNumLeft
            // 
            this.labelYnMaxNumLeft.AutoSize = true;
            this.labelYnMaxNumLeft.Location = new System.Drawing.Point(112, 14);
            this.labelYnMaxNumLeft.Name = "labelYnMaxNumLeft";
            this.labelYnMaxNumLeft.Size = new System.Drawing.Size(11, 12);
            this.labelYnMaxNumLeft.TabIndex = 9;
            this.labelYnMaxNumLeft.Text = "0";
            // 
            // labelYZeroOffset
            // 
            this.labelYZeroOffset.AutoSize = true;
            this.labelYZeroOffset.Location = new System.Drawing.Point(169, 124);
            this.labelYZeroOffset.Name = "labelYZeroOffset";
            this.labelYZeroOffset.Size = new System.Drawing.Size(11, 12);
            this.labelYZeroOffset.TabIndex = 8;
            this.labelYZeroOffset.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "Y漂移";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "正负最大值";
            // 
            // cwTrackBar2YZeroOffset
            // 
            this.cwTrackBar2YZeroOffset.CWMaxinum = 10000;
            this.cwTrackBar2YZeroOffset.CWValue = 0;
            this.cwTrackBar2YZeroOffset.Location = new System.Drawing.Point(13, 139);
            this.cwTrackBar2YZeroOffset.Name = "cwTrackBar2YZeroOffset";
            this.cwTrackBar2YZeroOffset.Size = new System.Drawing.Size(322, 45);
            this.cwTrackBar2YZeroOffset.TabIndex = 2;
            this.cwTrackBar2YZeroOffset.CW_ValueChanged += new UserControlLib.CWTrackBar2.CW_ValueChangedEventHandler(this.cwTrackBar2YZeroOffset_CW_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelsys_dead_area_xRight);
            this.groupBox3.Controls.Add(this.labelsys_dead_area_xLeft);
            this.groupBox3.Controls.Add(this.labelXnMaxNumRight);
            this.groupBox3.Controls.Add(this.labelXnMaxNumLeft);
            this.groupBox3.Controls.Add(this.cwTrackBarDub2XnMaxNum);
            this.groupBox3.Controls.Add(this.labelXZeroOffset);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cwTrackBar2XZeroOffset);
            this.groupBox3.Location = new System.Drawing.Point(6, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(347, 170);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "X";
            // 
            // labelXnMaxNumRight
            // 
            this.labelXnMaxNumRight.AutoSize = true;
            this.labelXnMaxNumRight.Location = new System.Drawing.Point(232, 14);
            this.labelXnMaxNumRight.Name = "labelXnMaxNumRight";
            this.labelXnMaxNumRight.Size = new System.Drawing.Size(11, 12);
            this.labelXnMaxNumRight.TabIndex = 9;
            this.labelXnMaxNumRight.Text = "0";
            // 
            // labelXnMaxNumLeft
            // 
            this.labelXnMaxNumLeft.AutoSize = true;
            this.labelXnMaxNumLeft.Location = new System.Drawing.Point(112, 14);
            this.labelXnMaxNumLeft.Name = "labelXnMaxNumLeft";
            this.labelXnMaxNumLeft.Size = new System.Drawing.Size(11, 12);
            this.labelXnMaxNumLeft.TabIndex = 9;
            this.labelXnMaxNumLeft.Text = "0";
            // 
            // cwTrackBarDub2XnMaxNum
            // 
            this.cwTrackBarDub2XnMaxNum.CW_ValueProcessLeft = 0;
            this.cwTrackBarDub2XnMaxNum.CW_ValueProcessRight = 0;
            this.cwTrackBarDub2XnMaxNum.Location = new System.Drawing.Point(13, 29);
            this.cwTrackBarDub2XnMaxNum.MaxnumLeft = 100;
            this.cwTrackBarDub2XnMaxNum.MaxnumRight = 100;
            this.cwTrackBarDub2XnMaxNum.Name = "cwTrackBarDub2XnMaxNum";
            this.cwTrackBarDub2XnMaxNum.Size = new System.Drawing.Size(322, 70);
            this.cwTrackBarDub2XnMaxNum.TabIndex = 6;
            this.cwTrackBarDub2XnMaxNum.CW_ValueChangedLeftUp += new UserControlLib.CWTrackBarDub2.CW_ValueChangedLeftUpEventHandler(this.cwTrackBarDub2XnMaxNum_CW_ValueChangedLeftUp);
            this.cwTrackBarDub2XnMaxNum.CW_ValueChangedRightUp += new UserControlLib.CWTrackBarDub2.CW_ValueChangedRightUpEventHandler(this.cwTrackBarDub2XnMaxNum_CW_ValueChangedRightUp);
            this.cwTrackBarDub2XnMaxNum.CW_ValueChangedLeftDown += new UserControlLib.CWTrackBarDub2.CW_ValueChangedLeftDownEventHandler(this.cwTrackBarDub2XnMaxNum_CW_ValueChangedLeftDown);
            this.cwTrackBarDub2XnMaxNum.CW_ValueChangedRightDown += new UserControlLib.CWTrackBarDub2.CW_ValueChangedRightDownEventHandler(this.cwTrackBarDub2XnMaxNum_CW_ValueChangedRightDown);
            // 
            // labelXZeroOffset
            // 
            this.labelXZeroOffset.AutoSize = true;
            this.labelXZeroOffset.Location = new System.Drawing.Point(169, 121);
            this.labelXZeroOffset.Name = "labelXZeroOffset";
            this.labelXZeroOffset.Size = new System.Drawing.Size(11, 12);
            this.labelXZeroOffset.TabIndex = 8;
            this.labelXZeroOffset.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 7;
            this.label11.Text = "X漂移";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "正负最大值";
            // 
            // cwTrackBar2XZeroOffset
            // 
            this.cwTrackBar2XZeroOffset.CWMaxinum = 10000;
            this.cwTrackBar2XZeroOffset.CWValue = 0;
            this.cwTrackBar2XZeroOffset.Location = new System.Drawing.Point(13, 136);
            this.cwTrackBar2XZeroOffset.Name = "cwTrackBar2XZeroOffset";
            this.cwTrackBar2XZeroOffset.Size = new System.Drawing.Size(322, 45);
            this.cwTrackBar2XZeroOffset.TabIndex = 2;
            this.cwTrackBar2XZeroOffset.CW_ValueChanged += new UserControlLib.CWTrackBar2.CW_ValueChangedEventHandler(this.cwTrackBar2XZeroOffset_CW_ValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(360, 545);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "限制";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelsys_dead_area_xLeft
            // 
            this.labelsys_dead_area_xLeft.AutoSize = true;
            this.labelsys_dead_area_xLeft.Location = new System.Drawing.Point(112, 102);
            this.labelsys_dead_area_xLeft.Name = "labelsys_dead_area_xLeft";
            this.labelsys_dead_area_xLeft.Size = new System.Drawing.Size(11, 12);
            this.labelsys_dead_area_xLeft.TabIndex = 10;
            this.labelsys_dead_area_xLeft.Text = "0";
            // 
            // labelsys_dead_area_xRight
            // 
            this.labelsys_dead_area_xRight.AutoSize = true;
            this.labelsys_dead_area_xRight.Location = new System.Drawing.Point(232, 102);
            this.labelsys_dead_area_xRight.Name = "labelsys_dead_area_xRight";
            this.labelsys_dead_area_xRight.Size = new System.Drawing.Size(11, 12);
            this.labelsys_dead_area_xRight.TabIndex = 10;
            this.labelsys_dead_area_xRight.Text = "0";
            // 
            // labelsys_dead_area_yLeft
            // 
            this.labelsys_dead_area_yLeft.AutoSize = true;
            this.labelsys_dead_area_yLeft.Location = new System.Drawing.Point(112, 103);
            this.labelsys_dead_area_yLeft.Name = "labelsys_dead_area_yLeft";
            this.labelsys_dead_area_yLeft.Size = new System.Drawing.Size(11, 12);
            this.labelsys_dead_area_yLeft.TabIndex = 10;
            this.labelsys_dead_area_yLeft.Text = "0";
            // 
            // labelsys_dead_area_yRight
            // 
            this.labelsys_dead_area_yRight.AutoSize = true;
            this.labelsys_dead_area_yRight.Location = new System.Drawing.Point(232, 103);
            this.labelsys_dead_area_yRight.Name = "labelsys_dead_area_yRight";
            this.labelsys_dead_area_yRight.Size = new System.Drawing.Size(11, 12);
            this.labelsys_dead_area_yRight.TabIndex = 10;
            this.labelsys_dead_area_yRight.Text = "0";
            // 
            // labelsys_dead_area_zLeft
            // 
            this.labelsys_dead_area_zLeft.AutoSize = true;
            this.labelsys_dead_area_zLeft.Location = new System.Drawing.Point(112, 102);
            this.labelsys_dead_area_zLeft.Name = "labelsys_dead_area_zLeft";
            this.labelsys_dead_area_zLeft.Size = new System.Drawing.Size(11, 12);
            this.labelsys_dead_area_zLeft.TabIndex = 10;
            this.labelsys_dead_area_zLeft.Text = "0";
            // 
            // labelsys_dead_area_zRight
            // 
            this.labelsys_dead_area_zRight.AutoSize = true;
            this.labelsys_dead_area_zRight.Location = new System.Drawing.Point(232, 102);
            this.labelsys_dead_area_zRight.Name = "labelsys_dead_area_zRight";
            this.labelsys_dead_area_zRight.Size = new System.Drawing.Size(11, 12);
            this.labelsys_dead_area_zRight.TabIndex = 10;
            this.labelsys_dead_area_zRight.Text = "0";
            // 
            // FormCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 600);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(378, 636);
            this.MinimumSize = new System.Drawing.Size(378, 636);
            this.Name = "FormCalibration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "电位器校准";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSensitiveZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSensitiveXY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPaceZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMaxPace)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarSensitiveZ;
        private System.Windows.Forms.TrackBar trackBarSensitiveXY;
        private System.Windows.Forms.TrackBar trackBarPaceZ;
        private System.Windows.Forms.TrackBar trackBarMaxPace;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private UserControlLib.CWTrackBar2 cwTrackBar2XZeroOffset;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private UserControlLib.CWTrackBar2 cwTrackBar2ZZeroOffset;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private UserControlLib.CWTrackBar2 cwTrackBar2YZeroOffset;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelXZeroOffset;
        private System.Windows.Forms.Label labelZZeroOffset;
        private System.Windows.Forms.Label labelYZeroOffset;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelZnMaxNumRight;
        private System.Windows.Forms.Label labelZnMaxNumLeft;
        private System.Windows.Forms.Label labelYnMaxNumRight;
        private System.Windows.Forms.Label labelYnMaxNumLeft;
        private System.Windows.Forms.Label labelXnMaxNumRight;
        private System.Windows.Forms.Label labelXnMaxNumLeft;
        private System.Windows.Forms.Label labelSensitiveZ;
        private System.Windows.Forms.Label labelSensitiveXY;
        private System.Windows.Forms.Label labelPaceZ;
        private System.Windows.Forms.Label labelMaxPace;
        private UserControlLib.CWTrackBarDub2 cwTrackBarDub2XnMaxNum;
        private UserControlLib.CWTrackBarDub2 cwTrackBarDub2ZnMaxNum;
        private UserControlLib.CWTrackBarDub2 cwTrackBarDub2YnMaxNum;
        private System.Windows.Forms.Label labelsys_dead_area_xLeft;
        private System.Windows.Forms.Label labelsys_dead_area_yRight;
        private System.Windows.Forms.Label labelsys_dead_area_yLeft;
        private System.Windows.Forms.Label labelsys_dead_area_xRight;
        private System.Windows.Forms.Label labelsys_dead_area_zRight;
        private System.Windows.Forms.Label labelsys_dead_area_zLeft;

    }
}