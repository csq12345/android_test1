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
    public partial class FormOPCTestw : Form
    {
        string str_name;
        string str_val;
        public FormOPCTestw()
        {
            InitializeComponent();
        }

        public FormOPCTestw(string name,string val)
        {
            InitializeComponent();
            str_name = name;
            str_val = val;
            this.Text += str_name;
            if (str_val != null)
            {
                textBox1.Text = str_val;
            }
            else
            {
                textBox1.Text = "";
            }

            //数据类型
            int index = OPCOperate.MyOPCObject.GetItemIndex(str_name);
            label1.Text = OPCOperate.MyOPCObject.ItemType[index].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool bl = OPCOperate.MyOPCObject.WriteData(str_name, textBox1.Text);
                if (bl)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
