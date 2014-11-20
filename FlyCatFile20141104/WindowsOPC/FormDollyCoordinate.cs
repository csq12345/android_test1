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
    public partial class FormDollyCoordinate : Form
    {
        //OPCOperate.VariableClass vc = OPCOperate.VariableClass.VariableClass_();

        public FormDollyCoordinate()
        {
            InitializeComponent();
            //vc.PointXYZUpdate += new OPCOperate.VariableClass.PointXYZUpdateEventHandler(vc_PointXYZUpdate);
            dlgSetValues = new DLGSetValues(SetValues);
        }

        void vc_PointXYZUpdate(object sender, OPCOperate.MyOPC.FlyCat_PointXYZ data)
        {
            //SetValues(data.PXCoor,data.PYCoor,data.PZCoor);
        }

        delegate void DLGSetValues(double vx, double vy, double vz);
        DLGSetValues dlgSetValues;

        /// <summary>
        /// 设置界面的值
        /// </summary>
        /// <param name="vx"></param>
        /// <param name="vy"></param>
        /// <param name="vz"></param>
        void SetValues(double vx, double vy, double vz)
        {
            if (textBoxX.InvokeRequired)
            {
                textBoxX.Invoke(dlgSetValues,new double[]{vx,vy,vz});
            }
            else
            {

                textBoxX.Text = vx.ToString();

                textBoxY.Text = vy.ToString();
                textBoxZ.Text = vz.ToString();
            }
        }

        private void FormDollyCoordinate_FormClosing(object sender, FormClosingEventArgs e)
        {
            //vc.PointXYZUpdate -= new OPCOperate.VariableClass.PointXYZUpdateEventHandler(vc_PointXYZUpdate);
        }
    }
}
