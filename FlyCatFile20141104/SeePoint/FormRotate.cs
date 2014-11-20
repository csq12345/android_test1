using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SeePoint
{
    public partial class FormRotate : Form
    {
        OPCOperate.AsyMotorControlOperate amco = new OPCOperate.AsyMotorControlOperate();
        public FormRotate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //旋转
            double rotate = 0;
            Double.TryParse(textBoxsys_xyxuanzhuanjiaodu.Text, out rotate);
            MessageBox.Show(rotate.ToString());
            amco.ControlCircAngle = rotate;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxsys_xyxuanzhuanjiaodu.Text = "0";
            button1_Click(null,null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
