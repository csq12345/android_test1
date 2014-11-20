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
    public partial class FormOtherControl : Form
    {

        OPCOperate.AsyMotorControlOperate amco = new OPCOperate.AsyMotorControlOperate();

        public FormOtherControl()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormOtherControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            amco.PointPlayDn = true;//开始放绳
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            amco.PointPlayDn = false;//停止放绳
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            //开始收绳
            amco.PointPlayUp = true;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            //停止收绳
            amco.PointPlayUp = false;
        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            amco.ManualState = checkBox2.Checked;//手动状态
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            //各边速度系数
            double dob = 0;
            Double.TryParse(textBoxsys_shouxianxishu.Text, out dob);
            amco.ConfigPaceCoefficient = dob;

            //最大速度
            double maxsp = 0;
            Double.TryParse(textBoxpc_pintai_vmax.Text, out maxsp);
            amco.ConfigPMaxPace = maxsp;

             //斜坡增量
            double xpzl = 0;
            Double.TryParse(textBoxsys_xiepozhengliang.Text, out xpzl);
            amco.ControlPaceAdd = xpzl;

            //Z斜坡增量
            double Zxpzl = 0;
            Double.TryParse(textBoxZxiepozengliang.Text, out Zxpzl);
            amco.ControlPaceAddZ = Zxpzl;
            
          
            
               //手动给定速度
            double speed = 0;
            Double.TryParse(textBoxpc_shoudongsudugeiding.Text, out speed);
            amco.ConfigManualMaxPace = speed;
            
        }
    }
}
