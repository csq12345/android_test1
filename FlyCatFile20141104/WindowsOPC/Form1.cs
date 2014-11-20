using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SeePoint;

namespace WindowsOPC
{
    public partial class Form1 : Form
    {


        FormMain mymainform;
        public Form1(FormMain mainfrm)
        {
            InitializeComponent();
            mymainform = mainfrm;
        }

        double ra = 500;

        private void button1_Click(object sender, EventArgs e)
        {

            //Pointz p1 = new Pointz(-50000, 50000, 50000);
            //Pointz p2 = new Pointz(95000, 60000, 50000);
            //Pointz p3 = new Pointz(90000, 75000, -50000);
            //Pointz p4 = new Pointz(-10000, 100000, -150000);
            //Pointz p0 = new Pointz(0, 50000, 0);

            //Pointz p1 = new Pointz(50000, 0, 50000);
            //Pointz p2 = new Pointz(95000, 50000, 60000);
            //Pointz p3 = new Pointz(-90000, 75000, 750000);
            //Pointz p4 = new Pointz(10000, -90000, 100000);
            //Pointz p0 = new Pointz(0, 0, 0);


            Pointz p1 = new Pointz(50000, 0, 50000);
            Pointz p2 = new Pointz(0, 50000, 60000);
            Pointz p3 = new Pointz(-50000, 0, 70000);
            Pointz p4 = new Pointz(0, -50000, 80000);
            Pointz p0 = new Pointz(25000, -25000, 25000);


            Pointz wp1 = new Pointz(50000, 0, 50000);
            Pointz wp2 = new Pointz(0, 50000, 60000);
            Pointz wp3 = new Pointz(-50000, 0, 70000);
            Pointz wp4 = new Pointz(0, -50000, 80000);

            // = (double)((10 - trackBar1.Value) * 0.1);
            //ra = 1010;
            //if (mymainform.frm_Font != null && mymainform.frm_Font.IsDisposed == false)
            //{

            //    mymainform.frm_Font.DiplayPoint(p1, p2, p3, p4, p0, ra);
            //}
            if (mymainform.frmPlane != null && mymainform.frmPlane.IsDisposed == false)
            {
                mymainform.frmPlane.Draw(p1, p2, p3, p4, p0, ra);
            }
            //if (mymainform.frm_Side != null && mymainform.frm_Side.IsDisposed == false)
            //{
            //    mymainform.frm_Side.DiplayPoint(p1, p2, p3, p4, p0, ra);
            //}
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            //double ra =(double)((10- trackBar1.Value)*0.1);
            //if (mymainform.frm_Font != null && mymainform.frm_Font.IsDisposed == false)
            //{
            //    mymainform.frm_Font.SetRatio(ra);
            //}
            if (mymainform.frmPlane != null && mymainform.frmPlane.IsDisposed == false)
            {
                //mymainform.frmPlane.SetRatio(ra);
            }
            //if (mymainform.frm_Side != null && mymainform.frm_Side.IsDisposed == false)
            //{
            //    mymainform.frm_Side.SetRatio(ra);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ax = 0, ay = 0, az = 0;
            int.TryParse(textBoxax.Text.Trim(), out ax);
            int.TryParse(textBoxay.Text.Trim(), out ay);
            int.TryParse(textBoxaz.Text.Trim(), out az);
            Pointz p1 = new Pointz(ax, ay, az);

            int bx = 0, by = 0, bz = 0;
            int.TryParse(textBoxbx.Text.Trim(), out bx);
            int.TryParse(textBoxby.Text.Trim(), out by);
            int.TryParse(textBoxbz.Text.Trim(), out bz);
            Pointz p2 = new Pointz(bx, by, bz);

            int cx = 0, cy = 0, cz = 0;
            int.TryParse(textBoxcx.Text.Trim(), out cx);
            int.TryParse(textBoxcy.Text.Trim(), out cy);
            int.TryParse(textBoxcz.Text.Trim(), out cz);
            Pointz p3 = new Pointz(cx, cy, cz);

            int dx = 0, dy = 0, dz = 0;
            int.TryParse(textBoxdx.Text.Trim(), out dx);
            int.TryParse(textBoxdy.Text.Trim(), out dy);
            int.TryParse(textBoxdz.Text.Trim(), out dz);
            Pointz p4 = new Pointz(dx, dy, dz);

            int px = 0, py = 0, pz = 0;
            int.TryParse(textBoxpx.Text.Trim(), out px);
            int.TryParse(textBoxpy.Text.Trim(), out py);
            int.TryParse(textBoxpz.Text.Trim(), out pz);
            Pointz p0 = new Pointz(px, py, pz);



            //if (mymainform.frm_Font != null && mymainform.frm_Font.IsDisposed == false)
            //{
            //    mymainform.frm_Font.DiplayPoint(p1, p2, p3, p4, p0, ra);
            //}
            if (mymainform.frmPlane != null && mymainform.frmPlane.IsDisposed == false)
            {

                //mymainform.frmPlane.DiplayPoint(p1, p2, p3, p4, p0, ra, 100, 100, 100, 100);
                mymainform.frmPlane.Draw(p1, p2, p3, p4, p0, ra);
            }
            //if (mymainform.frm_Side != null && mymainform.frm_Side.IsDisposed == false)
            //{
            //    mymainform.frm_Side.DiplayPoint(p1, p2, p3, p4, p0, ra);
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ra -= 10;

            //mymainform.frm_Side.SetRatio(ra);
            //mymainform.frmPlane.SetRatio(ra);
            //mymainform.frm_Font.SetRatio(ra);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ra += 10;
            //mymainform.frm_Side.SetRatio(ra);
            //mymainform.frmPlane.SetRatio(ra);
            //mymainform.frm_Font.SetRatio(ra);
        }
        OPCOperate.AsyMotorControlOperate amco = new OPCOperate.AsyMotorControlOperate();
        private void button3_Click_1(object sender, EventArgs e)
        {
            button3.Text = amco.ControlCircAngle.ToString();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            amco.ControlCircAngle = (double)45;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double rotate = Convert.ToDouble(textBox1.Text);
            if (mymainform.frmPlane != null && !mymainform.frmPlane.IsDisposed)
            {
                mymainform.frmPlane.NewRotateAngle = rotate;
                mymainform.frmPlane.ReDraw();
            }
            //if (mymainform.frm_Side != null)
            //    mymainform.frm_Side.SetRotateAngle(rotate);
            if (mymainform.frm_font1 != null && !mymainform.frm_font1.IsDisposed)
            {
                mymainform.frm_font1.NewRotateAngle = rotate;
                mymainform.frm_font1.ReDraw();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double ratio = Convert.ToDouble(textBox2.Text);
            //if (mymainform.frmPlane != null)
                //mymainform.frmPlane.SetRatio(ratio);

                //if (mymainform.frm_Side != null)
                //    mymainform.frm_Side.SetRatio(ratio);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                //Pointz p1 = new Pointz(50, 0, 200);
                //Pointz p2 = new Pointz(0, 50, 200);
                //Pointz p3 = new Pointz(-50, 0, 200);
                //Pointz p4 = new Pointz(0, -50, 200);
                //Pointz p0 = new Pointz(0, -0, 200);

                Pointz p1 = new Pointz(17594, 0, 3981);
                Pointz p2 = new Pointz(4240, 10678, 4357);
                Pointz p3 = new Pointz(-8077, -5877, 4495);
                Pointz p4 = new Pointz(3769, -18676, 4297);
                Pointz p0 = new Pointz(-5037, -5150, 0);

                //Pointz wp1 = new Pointz(50000, 0, 50000);
                //Pointz wp2 = new Pointz(0, 50000, 60000);
                //Pointz wp3 = new Pointz(-50000, 0, 70000);
                //Pointz wp4 = new Pointz(0, -50000, 80000);


                //Pointz p1 = new Pointz(10000, 0, 2000);
                //Pointz p2 = new Pointz(0, 10000, 3000);
                //Pointz p3 = new Pointz(-10000, 0, 3500);
                //Pointz p4 = new Pointz(0, -10000, 4000);
                //Pointz p0 = new Pointz(0, 0, 1000);       

                double ratic = 10;

                if (mymainform.frmPlane != null && mymainform.frmPlane.IsDisposed == false)
                {
                    //Point pa = new Point((int)p1.X, (int)p1.Y);
                    //Point pb = new Point((int)p2.X, (int)p2.Y);
                    //Point pc = new Point((int)p3.X, (int)p3.Y);
                    //Point pd = new Point((int)p4.X, (int)p4.Y);
                    //Point p = new Point((int)p0.X, (int)p0.Y);


                    mymainform.frmPlane.Draw(p1, p2, p3, p4, p0, ratic);
                }

                if (mymainform.frm_font1 != null && mymainform.frm_font1.IsDisposed == false)
                {
                    mymainform.frm_font1.Draw(p1, p2, p3, p4, p0, ratic);
                }

                if (mymainform.frm_side1 != null && mymainform.frm_side1.IsDisposed == false)
                {
                    mymainform.frm_side1.Draw(p1, p2, p3, p4, p0, ratic);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
