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
    /// <summary>
    /// 绘图窗体的基类窗体
    /// </summary>
    public  partial class FormView : Form
    {
        /// <summary>
        /// 空间点1
        /// </summary>
        internal Pointz pointzSta1;
        /// <summary>
        /// 空间点2
        /// </summary>
        internal Pointz pointzSta2;
        /// <summary>
        /// 空间点3
        /// </summary>
        internal Pointz pointzSta3;
        /// <summary>
        /// 空间点4
        /// </summary>
        internal Pointz pointzSta4;
        /// <summary>
        /// 空间原点
        /// </summary>
        internal Pointz pointzSta0;

        internal int pointzw1;
        internal int pointzw2;
        internal int pointzw3;
        internal int pointzw4;

        /// <summary>
        /// 比例
        /// </summary>
        internal double ratioSta = 0;

        /// <summary>
        /// 是否初始化完成
        /// </summary>
        internal bool initialed = false;

        /// <summary>
        /// 赋值完成
        /// </summary>
        internal bool setvalue = false;

        /// <summary>
        /// 原点
        /// </summary>
        internal Point basePoint;

        public FormView()
        {
            InitializeComponent();
        }

        private double offsetRotate = 0;
        /// <summary>
        /// 旋转偏移。即实际操作需要的旋转角度
        /// </summary>
        internal double OffsetRotate
        {
            get { return offsetRotate; }
            set { offsetRotate = value; }
        }


        bool mouseDown = false;

        Point pointDown;
        int cx = 0;
        int cy = 0;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //mouseDown = true;
            //pointDown = new Point(e.X, e.Y);

            //cx = e.X - basePoint.X;
            //cy = e.Y - basePoint.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //mouseDown = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (mouseDown)
            //{        
            //    basePoint = new Point(e.X-cx,e.Y-cy);
            //    BasePointChangedEvent(basePoint);
            //}
        }


        public event BasePointChangedEventHandler BasePointChanged;
        public delegate void BasePointChangedEventHandler(Point basepoint);

        void BasePointChangedEvent(Point basepoint)
        {
            if (BasePointChanged != null)
            {
                BasePointChanged(basepoint);
            }
        }

        /// <summary>
        /// 获取最长的对角线长度
        /// </summary>
        /// <returns></returns>
        public double GetMaxDiagnal()
        {
            double re = 0;
            if (pointzSta1 != null
                && pointzSta2 != null
                && pointzSta3 != null
                && pointzSta4 != null)
            {
                double a1 = Math.Abs(pointzSta3.X - pointzSta1.X);
                double b1 = Math.Abs(pointzSta3.Y - pointzSta1.Y);

                re = Math.Sqrt(Math.Pow(a1, 2) + Math.Pow(b1, 2));

                double a2 = Math.Abs(pointzSta2.X - pointzSta4.X);
                double b2 = Math.Abs(pointzSta2.Y - pointzSta4.Y);

                double c2 = Math.Sqrt(Math.Pow(a2, 2) + Math.Pow(b2, 2));
                if (c2 > re)
                {
                    re = c2;
                }
            }

            return re;
        }

        /// <summary>
        /// 获取相对原点最大半径
        /// </summary>
        /// <returns></returns>
        public double GetMaxRadius()
        {
            double re = 0;
            if (pointzSta1 != null
                && pointzSta2 != null
                && pointzSta3 != null
                && pointzSta4 != null)
            {


                double c1 = Math.Sqrt(Math.Pow(pointzSta1.X, 2) + Math.Pow(pointzSta1.Y, 2));
                double c2 = Math.Sqrt(Math.Pow(pointzSta2.X, 2) + Math.Pow(pointzSta2.Y, 2));
                double c3 = Math.Sqrt(Math.Pow(pointzSta3.X, 2) + Math.Pow(pointzSta3.Y, 2));
                double c4 = Math.Sqrt(Math.Pow(pointzSta4.X, 2) + Math.Pow(pointzSta4.Y, 2));
                re = c1;
                if (c2 > re)
                {
                    re = c2;
                }
                if (c3 > re)
                {
                    re = c3;
                }
                if (c4 > re)
                {
                    re = c4;
                }

            }
            return re;
        }

        /// <summary>
        /// 获取相对原点最大半径
        /// </summary>
        /// <returns></returns>
        public Pointz GetMaxRadius(out double radius)
        {
            Pointz rep = null ;
            double re=0;
            if (pointzSta1 != null
                && pointzSta2 != null
                && pointzSta3 != null
                && pointzSta4 != null)
            {


                double c1 = Math.Sqrt(Math.Pow(pointzSta1.X, 2) + Math.Pow(pointzSta1.Y, 2));
                double c2 = Math.Sqrt(Math.Pow(pointzSta2.X, 2) + Math.Pow(pointzSta2.Y, 2));
                double c3 = Math.Sqrt(Math.Pow(pointzSta3.X, 2) + Math.Pow(pointzSta3.Y, 2));
                double c4 = Math.Sqrt(Math.Pow(pointzSta4.X, 2) + Math.Pow(pointzSta4.Y, 2));
                //rep = pointzSta1;
                if (c1 > re)
                {
                    re = c1;
                    rep = pointzSta1;
                }
                if (c2 > re)
                {
                    re = c2;
                    rep = pointzSta2;
                }
                if (c3 > re)
                {
                    re = c3;
                    rep = pointzSta3;
                }
                if (c4 > re)
                {
                    re = c4;
                    rep = pointzSta4;
                }

            }
            radius = re;
            return rep;
        }

        /// <summary>
        /// 检查点是否符合绘图要求
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal bool CheckPointz(Pointz p)
        {
            //1000毫米*100=100米
            int len = 1000 * 100;
            double minnum=-1000*3;
            double maxnum=1000*3;
            if (p.X == 0 && p.Y == 0 && p.Z == 0)
            {
                return false;
            }
            if ((p.X > maxnum || p.X < minnum)

                && (p.Y > maxnum || p.Y < minnum)
                && (p.Z > maxnum || p.Z < minnum))
            {
            }
                if (p.X > -len & p.X < len
                   & p.Y > -len & p.Y < len
                   & p.Z > -len & p.Z < len)
                {
                    return true;
                }
                else
                {
                    return false;
                }
           
        }

        /// <summary>
        /// 获取校正角
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public double GetRotateAngle()
        {

            double re = 0;
            if (pointzSta1 != null
                && pointzSta2 != null
                && pointzSta3 != null
                && pointzSta4 != null)
            {
                double tanValue = Math.Abs(pointzSta1.Y - pointzSta2.Y) / Math.Abs(pointzSta1.X - pointzSta2.X);
                re = Math.Atan(tanValue) / (Math.PI / 180) + offsetRotate;
                return re;
            }
            else
            {
                return double.NaN;
            }

        }

       
        /// <summary>
        /// 获取偏移角度
        /// </summary>
        /// <param name="pa"></param>
        /// <param name="pb"></param>
        /// <returns></returns>
        public double GetRotateAngle(Pointz pa,Pointz pb)
        {

            double re = 0;
            if (pa != null
                && pb != null
              )
            {
                double tanValue = Math.Abs(pa.Y - pb.Y) / Math.Abs(pa.X - pb.X);
                re = Math.Atan(tanValue) / (Math.PI / 180);
                return re;
            }
            else
            {
                return double.NaN;
            }

        }



        /// <summary>
        /// 获取显示界面最小半径
        /// </summary>
        /// <returns></returns>
        public double GetShowPlaneMinRadius()
        {
            double re = 0;
            if (pictureBox1.Width > pictureBox1.Height)
            {
                re = pictureBox1.Height / 2*1;
            }
            else
            {
                re = pictureBox1.Width / 2*1;
            }

            return re;
        }

        /// <summary>
        /// 获取相对坐标系最大X绝对值
        /// </summary>
        /// <returns></returns>
        public double GetShowPlaneMaxMathX(Pointz p1,Pointz p2,Pointz p3,Pointz p4)
        {
            double maxX = 0;
            if (p1 != null
              && p2 != null
              && p3 != null
              && p4 != null)
            {
                double absValue = 0;
                absValue = Math.Abs(p1.X);
                if (absValue > maxX)
                    maxX = absValue;
                absValue = Math.Abs(p2.X);
                if (absValue > maxX)
                    maxX = absValue;
                absValue = Math.Abs(p3.X);
                if (absValue > maxX)
                    maxX = absValue;
                absValue = Math.Abs(p4.X);
                if (absValue > maxX)
                    maxX = absValue;
            }
            return maxX;
        }

        /// <summary>
        ///  获取相对坐标系最大Y绝对值
        /// </summary>
        /// <returns></returns>
        public double GetShowPlaneMaxMathY(Pointz p1, Pointz p2, Pointz p3, Pointz p4)
        {
            double maxY = 0;
            if (p1 != null
              && p2 != null
              && p3 != null
              && p4 != null)
            {
                double absValue = 0;
                absValue = Math.Abs(p1.Y);
                if (absValue > maxY)
                    maxY = absValue;
                absValue = Math.Abs(p2.Y);
                if (absValue > maxY)
                    maxY = absValue;
                absValue = Math.Abs(p3.Y);
                if (absValue > maxY)
                    maxY = absValue;
                absValue = Math.Abs(p4.Y);
                if (absValue > maxY)
                    maxY = absValue;
            }
            return maxY;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
