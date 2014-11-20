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
    public partial class FormDollyStartPosition : Form
    {
        public FormDollyStartPosition()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDollyStartPositionCalculate frm = new FormDollyStartPositionCalculate();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}
