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
    public partial class FormPlaceCoordinates : Form
    {
        public FormPlaceCoordinates()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //实例一个类型对象
            OPCOperate.VariableInitialClass vic = new OPCOperate.VariableInitialClass();
            //向类型对象中定义的变量赋值
            vic.PlaceCoordinates_.X1 = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormPlaceCoordinatesCalculate frm = new FormPlaceCoordinatesCalculate();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
