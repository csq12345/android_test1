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
    public partial class FormMotorActivation : Form
    {
        OPCOperate.AsyMotorControlOperate amco = new OPCOperate.AsyMotorControlOperate();
        public FormMotorActivation()
        {
            InitializeComponent();

            checkBox1.Checked = amco.ManualState;
            timer1.Start();
            button1.Enabled = checkBox1.Checked;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (radioButtonUp.Checked)
                {
                    amco.PointPlayUp = true;//收绳
                }

                if (radioButtonDown.Checked)
                {
                    amco.PointPlayDn = true;//放绳
                }
            }
            catch (Exception ex)
            {
 
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (radioButtonUp.Checked)
                {
                    amco.PointPlayUp = false;//收绳
                }

                if (radioButtonDown.Checked)
                {
                    amco.PointPlayDn = false;//放绳
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                amco.ManualState = checkBox1.Checked;

                if (checkBox1.Checked)
                {
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double db;
                if (checkBox2.Checked)
                {
                    Double.TryParse(textBox1.Text, out db);
                    amco.ConfigManualMaxPace = db;
                }
            }
            catch (Exception ex)
            {
 
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox2.Checked)
                {
                    button2.Enabled = true;
                }
                else
                {
                    button2.Enabled = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!checkBox2.Checked)
                {
                    textBox1.Text = amco.ConfigManualMaxPace.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonAll.Checked)
                {
                    amco.Motor1SelectState = true;
                    amco.Motor2SelectState = true;
                    amco.Motor3SelectState = true;
                    amco.Motor4SelectState = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void radioButtonMotor1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonMotor1.Checked)
                {
                    amco.Motor1SelectState = true;
                    amco.Motor2SelectState = false;
                    amco.Motor3SelectState = false;
                    amco.Motor4SelectState = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void radioButtonMotor2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonMotor2.Checked)
                {
                    amco.Motor1SelectState = false;
                    amco.Motor2SelectState = true;
                    amco.Motor3SelectState = false;
                    amco.Motor4SelectState = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void radioButtonMotor3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonMotor3.Checked)
                {
                    amco.Motor1SelectState = false;
                    amco.Motor2SelectState = false;
                    amco.Motor3SelectState = true;
                    amco.Motor4SelectState = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void radioButtonMotor4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonMotor4.Checked)
                {
                    amco.Motor1SelectState = false;
                    amco.Motor2SelectState = false;
                    amco.Motor3SelectState = false;
                    amco.Motor4SelectState = true;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
