using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsOPC
{
    public partial class FormCalibration : Form
    {
        OPCOperate.AsyMotorControlOperate amco = new OPCOperate.AsyMotorControlOperate();
        public FormCalibration()
        {
            InitializeComponent();
            //amco.ConfigRockerXZeroOffset
            timer1.Start();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            amco.RockerReverse = checkBox1.Checked;//反向摇杆

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            amco.RockerEnabled = checkBox3.Checked;//禁用摇杆
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }



        private void trackBarSensitiveXY_ValueChanged(object sender, EventArgs e)
        {
            amco.ConfigRockerSensitive = trackBarSensitiveXY.Value;//xy灵敏度
            labelSensitiveXY.Text = trackBarSensitiveXY.Value.ToString();
        }

        private void trackBarSensitiveZ_ValueChanged(object sender, EventArgs e)
        {
            amco.ConfigRockerSensitiveZ = trackBarSensitiveZ.Value;//z灵敏度
            labelSensitiveZ.Text = trackBarSensitiveZ.Value.ToString();
        }

        private void trackBarMaxPace_ValueChanged(object sender, EventArgs e)
        {
            amco.ConfigPMaxPace = trackBarMaxPace.Value * 1000;//xy最大速度
            labelMaxPace.Text = trackBarMaxPace.Value.ToString();
        }

        private void trackBarPaceZ_ValueChanged(object sender, EventArgs e)
        {
            amco.ConfigPMaxPaceZ = trackBarPaceZ.Value * 1000;//z最大速度
            labelPaceZ.Text = trackBarPaceZ.Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cwTrackBar2XZeroOffset.CWValue = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //button4.Text = cwTrackBar2XZeroOffset.CWValue.ToString();
        }


        private void cwTrackBar2XZeroOffset_CW_ValueChanged(int value)
        {
            labelXZeroOffset.Text = value.ToString();
            amco.ConfigRockerXZeroOffset = value;//X轴摇杆 零点漂移修正（-10000，+10000）
        }


        private void cwTrackBar2YZeroOffset_CW_ValueChanged(int value)
        {
            labelYZeroOffset.Text = value.ToString();
            amco.ConfigRockerYZeroOffset = value;//Y轴摇杆 零点漂移修正（-10000，+10000）
        }

        private void cwTrackBar2ZZeroOffset_CW_ValueChanged(int value)
        {
            labelZZeroOffset.Text = value.ToString();
            amco.ConfigRockerZZeroOffset = value;//Z轴摇杆 零点漂移修正（-10000，+10000）
        }

        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //x摇杆值范围
            double xnum = amco.ConfigRockerXNum;
            if (xnum < 0)
            {
                if (-xnum > cwTrackBarDub2XnMaxNum.MaxnumLeft)
                {
                    cwTrackBarDub2XnMaxNum.CW_ValueProcessLeft = cwTrackBarDub2XnMaxNum.MaxnumLeft;
                    labelXnMaxNumLeft.Text = cwTrackBarDub2XnMaxNum.MaxnumRight.ToString();
                }
                else
                {
                    cwTrackBarDub2XnMaxNum.CW_ValueProcessLeft = (int)-xnum;
                    labelXnMaxNumLeft.Text = ((int)-xnum).ToString();
                    //cwTrackBarDubXnMaxNum.CW_ValueProcessLeft = 0;
                }
            }
            else
            {
                if (xnum > cwTrackBarDub2XnMaxNum.MaxnumRight)
                {
                    cwTrackBarDub2XnMaxNum.CW_ValueProcessRight = cwTrackBarDub2XnMaxNum.MaxnumRight;
                    labelXnMaxNumRight.Text = cwTrackBarDub2XnMaxNum.MaxnumRight.ToString();
                }
                else
                {
                    cwTrackBarDub2XnMaxNum.CW_ValueProcessRight = (int)xnum;
                    labelXnMaxNumRight.Text = ((int)xnum).ToString();
                    //cwTrackBarDubXnMaxNum.CW_ValueProcessRight = 0;
                }
            }

            //y摇杆值范围
            double ynum = amco.ConfigRockerYNum;
            if (ynum < 0)
            {
                if (-ynum > cwTrackBarDub2YnMaxNum.MaxnumLeft)
                {
                    cwTrackBarDub2YnMaxNum.CW_ValueProcessLeft = cwTrackBarDub2YnMaxNum.MaxnumLeft;
                    labelYnMaxNumLeft.Text = cwTrackBarDub2YnMaxNum.MaxnumRight.ToString();
                }
                else
                {
                    cwTrackBarDub2YnMaxNum.CW_ValueProcessLeft = (int)-ynum;
                    labelYnMaxNumLeft.Text = ((int)-ynum).ToString();
                    //cwTrackBarDubYnMaxNum.CW_ValueProcessLeft = 0;
                }
            }
            else
            {
                if (ynum > cwTrackBarDub2YnMaxNum.MaxnumRight)
                {
                    cwTrackBarDub2YnMaxNum.CW_ValueProcessRight = cwTrackBarDub2YnMaxNum.MaxnumRight;
                    labelYnMaxNumRight.Text = cwTrackBarDub2YnMaxNum.MaxnumRight.ToString();
                }
                else
                {
                    cwTrackBarDub2YnMaxNum.CW_ValueProcessRight = (int)ynum;
                    labelYnMaxNumRight.Text = ((int)ynum).ToString();
                    //cwTrackBarDubYnMaxNum.CW_ValueProcessRight = 0;
                }
            }

            //z摇杆值范围
            double znum = amco.ConfigRockerZNum;
            if (znum < 0)
            {
                if (-znum > cwTrackBarDub2ZnMaxNum.MaxnumLeft)
                {
                    cwTrackBarDub2ZnMaxNum.CW_ValueProcessLeft = cwTrackBarDub2ZnMaxNum.MaxnumLeft;
                    labelZnMaxNumLeft.Text = cwTrackBarDub2ZnMaxNum.MaxnumLeft.ToString();
                }
                else
                {
                    cwTrackBarDub2ZnMaxNum.CW_ValueProcessLeft = (int)-znum;
                    labelZnMaxNumLeft.Text = ((int)-znum).ToString();
                    //cwTrackBarDubZnMaxNum.CW_ValueProcessLeft = 0;
                }
            }
            else
            {
                if (znum > cwTrackBarDub2ZnMaxNum.MaxnumRight)
                {
                    cwTrackBarDub2ZnMaxNum.CW_ValueProcessRight = cwTrackBarDub2ZnMaxNum.MaxnumRight;
                    labelZnMaxNumRight.Text = cwTrackBarDub2ZnMaxNum.MaxnumRight.ToString();
                }
                else
                {
                    cwTrackBarDub2ZnMaxNum.CW_ValueProcessRight = (int)znum;
                    labelZnMaxNumRight.Text = ((int)znum).ToString();
                    //cwTrackBarDubZnMaxNum.CW_ValueProcessRight = 0;
                }
            }
            //count++;
            //labelcount.Text = count.ToString();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 1)
                {
                    Read();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        void Read()
        {
            //最大XY速度
            if (amco.ConfigPMaxPace >= 0
                && amco.ConfigPMaxPace <= trackBarMaxPace.Maximum)
                trackBarMaxPace.Value = (int)(amco.ConfigPMaxPace / 1000);
            else if (amco.ConfigPMaxPace > trackBarMaxPace.Maximum)
                trackBarMaxPace.Value = trackBarMaxPace.Maximum;
            else if (amco.ConfigPMaxPace < 0)
                trackBarMaxPace.Value = 0;
            //最大Z速度
            if (amco.ConfigPMaxPaceZ >= 0
                && amco.ConfigPMaxPaceZ <= trackBarPaceZ.Maximum)
                trackBarPaceZ.Value = (int)(amco.ConfigPMaxPaceZ / 1000);
            else if (amco.ConfigPMaxPaceZ > trackBarPaceZ.Maximum)
                trackBarPaceZ.Value = trackBarPaceZ.Maximum;
            else if (amco.ConfigPMaxPaceZ < 0)
                trackBarPaceZ.Value = 0;

            //灵敏度
            
            if (amco.ConfigRockerSensitive >= 0
                && amco.ConfigRockerSensitive <= trackBarSensitiveXY.Maximum)
                trackBarSensitiveXY.Value = (int)amco.ConfigRockerSensitive;
            else if (amco.ConfigRockerSensitive > trackBarSensitiveXY.Maximum)
                trackBarSensitiveXY.Value = trackBarSensitiveXY.Maximum;
            else if (amco.ConfigRockerSensitive < 0)
                trackBarSensitiveXY.Value = 0;

           
            if (amco.ConfigRockerSensitiveZ >= 0
                && amco.ConfigRockerSensitiveZ <= trackBarSensitiveZ.Maximum)
                trackBarSensitiveZ.Value = (int)amco.ConfigRockerSensitiveZ;
            else if (amco.ConfigRockerSensitiveZ > trackBarSensitiveZ.Maximum)
                trackBarSensitiveZ.Value = trackBarSensitiveZ.Maximum;
            else if (amco.ConfigRockerSensitiveZ < 0)
                trackBarSensitiveZ.Value = 0;

            
            checkBox1.Checked = amco.RockerReverse;
            checkBox3.Checked = amco.RockerEnabled;
        }


        private void cwTrackBarDub2XnMaxNum_CW_ValueChangedLeftUp(int value)
        {
            amco.ConfigRockerXnMaxNum = -value;//x负向最大值
        }

        private void cwTrackBarDub2XnMaxNum_CW_ValueChangedRightUp(int value)
        {
            amco.ConfigRockerXpMaxNum = value;//x正向最大值
        }


        private void cwTrackBarDub2YnMaxNum_CW_ValueChangedLeftUp(int value)
        {
            amco.ConfigRockerYnMaxNum = -value;//y负向最大值
        }

        private void cwTrackBarDub2YnMaxNum_CW_ValueChangedRightUp(int value)
        {
            amco.ConfigRockerYpMaxNum = value;//y正向最大值
        }

        private void cwTrackBarDub2ZnMaxNum_CW_ValueChangedLeftUp(int value)
        {
            amco.ConfigRockerZnMaxNum = -value;//y负向最大值
        }

        private void cwTrackBarDub2ZnMaxNum_CW_ValueChangedRightUp(int value)
        {
            amco.ConfigRockerZpMaxNum = value;//y正向最大值
        }

        private void cwTrackBarDub2XnMaxNum_CW_ValueChangedLeftDown(int value)
        {
            amco.ConfigRockerXPaceArea = -value;//x负向死区
            labelsys_dead_area_xLeft.Text = (value).ToString();
        }

        private void cwTrackBarDub2XnMaxNum_CW_ValueChangedRightDown(int value)
        {
            amco.ConfigRockerXPaceArea = value;//x正向死区
            labelsys_dead_area_xRight.Text = value.ToString();
        }

        private void cwTrackBarDub2YnMaxNum_CW_ValueChangedLeftDown(int value)
        {
            amco.ConfigRockerYPaceArea = -value;//y负向死区
            labelsys_dead_area_yLeft.Text = value.ToString();
        }

        private void cwTrackBarDub2YnMaxNum_CW_ValueChangedRightDown(int value)
        {
            amco.ConfigRockerYPaceArea = value;//y正向死区
            labelsys_dead_area_yLeft.Text = value.ToString();
        }

        private void cwTrackBarDub2ZnMaxNum_CW_ValueChangedLeftDown(int value)
        {
            amco.ConfigRockerZPaceArea = -value;//z负向死区
            labelsys_dead_area_zLeft.Text = value.ToString();
        }

        private void cwTrackBarDub2ZnMaxNum_CW_ValueChangedRightDown(int value)
        {
            amco.ConfigRockerZPaceArea = value;//z正向死区
            labelsys_dead_area_zLeft.Text = value.ToString();
        }
    }
}
