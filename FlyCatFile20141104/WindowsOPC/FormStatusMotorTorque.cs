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
    public partial class FormStatusMotorTorque : Form
    {

        OPCOperate.VariableClass vc = OPCOperate.VariableClass.VariableClass_();

        public FormStatusMotorTorque()
        {
            InitializeComponent();
            dlgSetValue1 = new DLGSetValue(SetValue1);
            dlgSetValue2 = new DLGSetValue(SetValue2);
            dlgSetValue3 = new DLGSetValue(SetValue3);
            dlgSetValue4 = new DLGSetValue(SetValue4);

            vc.StateUpdate += new OPCOperate.VariableClass.StateUpdateEventHandler(vc_StateUpdate);
        }

        void vc_StateUpdate(object sender, OPCOperate.MyOPC.FlyCat_SysState data)
        {
            try
            {
                double v1 = data.SysState_Moment.AMoment * ratio;
                SetValue1(v1);
                labeld1.Text = v1.ToString();

                double v2 = data.SysState_Moment.BMoment * ratio;
                SetValue2(v2);
                labeld2.Text = v2.ToString();

                double v3 = data.SysState_Moment.CMoment * ratio;
                SetValue3(v3);
                labeld3.Text = v3.ToString();

                double v4 = data.SysState_Moment.DMoment * ratio;
                SetValue4(v4);
                labeld4.Text = v4.ToString();

            }
            catch
            {


            }
        }

        delegate void DLGSetValue(double value);
        DLGSetValue dlgSetValue1, dlgSetValue2, dlgSetValue3, dlgSetValue4;
        void SetValue1(double va)
        {
            if (progressBar1no5_torque.InvokeRequired)
            {
                progressBar1no5_torque.Invoke(dlgSetValue1, new object[] { va });
            }
            else
            {
                if (va > -1 && va <= progressBar1no5_torque.Maximum)
                {
                    progressBar1no5_torque.Value = (int)va;
                }
            }
        }

        void SetValue2(double va)
        {
            if (progressBar2no6_torque.InvokeRequired)
            {
                progressBar2no6_torque.Invoke(dlgSetValue2, new object[] { va });
            }
            else
            {
                if (va > -1 && va <= progressBar2no6_torque.Maximum)
                {
                    progressBar2no6_torque.Value = (int)va;
                }
            }
        }

        void SetValue3(double va)
        {
            if (progressBar3no7_torque.InvokeRequired)
            {
                progressBar3no7_torque.Invoke(dlgSetValue3, new object[] { va });
            }
            else
            {
                if (va > -1 && va <= progressBar3no7_torque.Maximum)
                {
                    progressBar3no7_torque.Value = (int)va;
                }
            }
        }

        void SetValue4(double va)
        {
            if (progressBar4no8_torque.InvokeRequired)
            {
                progressBar4no8_torque.Invoke(dlgSetValue4, new object[] { va });
            }
            else
            {
                if (va > -1 && va <= progressBar4no8_torque.Maximum)
                {
                    progressBar4no8_torque.Value = (int)va;
                }
            }
        }

        private void FormStatusMotorTorque_FormClosing(object sender, FormClosingEventArgs e)
        {
            vc.StateUpdate -= new VariableClass.StateUpdateEventHandler(vc_StateUpdate);
        }

        /// <summary>
        /// 放大倍数
        /// </summary>
        int ratio = 1;

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            ratio = trackBar1.Value;
            if (ratio > 1)
            {

            }
            else
            {
                ratio = 1;
            }
        }
    }
}
