using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPCOperate;

namespace WindowsOPC
{
    public partial class FormStatusControl1 : Form
    {

        AsyMotorControlOperate amco = new AsyMotorControlOperate();

        public FormStatusControl1()
        {
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (amco.Tm31CommState1)
                {
                    userControlRGYTm31CommState1.SetStatu(true);
                }
                else
                {
                    userControlRGYTm31CommState1.SetStatu(false);
                }
                
                if (amco.Tm31CommState2)
                {
                    userControlRGYTm31CommState2.SetStatu(true);
                }
                else
                {
                    userControlRGYTm31CommState2.SetStatu(false);
                }

                if (amco.AxisDiscrepancyState)
                {
                    userControlRGYAxisState.SetStatu(true);
                }
                else
                {
                    userControlRGYAxisState.SetStatu(false);
                }

                labelTm31Alarm11.Text = amco.Tm31Alarm1.ToString();
                labelTm31Alarm2.Text = amco.Tm31Alarm2.ToString();

                labelMainServoAlarm1.Text = amco.MainServoAlarm1.ToString();
                labelMainServoAlarm2.Text = amco.MainServoAlarm2.ToString();
                labelMainServoAlarm3.Text = amco.MainServoAlarm3.ToString();
                labelMainServoAlarm4.Text = amco.MainServoAlarm4.ToString();

                labelMainControlAlarm1.Text = amco.MainControlAlarm1.ToString();
                labelMainControlAlarm2.Text = amco.MainControlAlarm2.ToString();
                labelMainControlAlarm3.Text = amco.MainControlAlarm3.ToString();
                labelMainControlAlarm4.Text = amco.MainControlAlarm4.ToString();


                labelD435ControlAlarm.Text = amco.D435ControlAlarm.ToString();
            }
            catch
            {
                
            }
        }


    }
}
