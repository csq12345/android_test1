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
    public partial class FormViewSide : FormView
    { 
        Pen mypen;
        Graphics mygra;
        Bitmap mybm;
        Point[] myps;
        Point[] myGroundps;


        public FormViewSide()
        {
            InitializeComponent();
            BasePointChanged += new BasePointChangedEventHandler(FormViewSide_BasePointChanged);
            dlgShowPoint = new DLGShowPoint(ShowPoint);
        }

        void FormViewSide_BasePointChanged(Point basepoint)
        {
            ShowPoint();
        }

        
        //#region MyRegion
        //internal Pointz pointzSta1;
        //internal Pointz pointzSta2;
        //internal Pointz pointzSta3;
        //internal Pointz pointzSta4;
        //internal Pointz pointzSta0;

        ///// <summary>
        ///// 比例
        ///// </summary>
        //internal double ratioSta = 0;

        ///// <summary>
        ///// 是否初始化完成
        ///// </summary>
        //internal bool initialed = false;

        ///// <summary>
        ///// 赋值完成
        ///// </summary>
        //internal bool setvalue = false;

        ///// <summary>
        ///// 原点
        ///// </summary>
        //internal Point basePoint;
        //#endregion



        void Initial()
        {
            initialed = false;
            mybm = new Bitmap(pictureBox1.Width, pictureBox1.Height);//画板
            mypen = new Pen(new SolidBrush(ColorLib.colorPen),2);//画笔
            mygra = Graphics.FromImage(mybm);

            basePoint.X = pictureBox1.Width / 2;
            basePoint.Y = pictureBox1.Height / 2;
            initialed = true;
            //mygra.TranslateTransform(basePoint.X, basePoint.Y);
        }

        void ReInitialGraphice()
        {
            initialed = false;
            mybm = new Bitmap(pictureBox1.Width, pictureBox1.Height);//画板
            mygra = Graphics.FromImage(mybm);
            basePoint.X = pictureBox1.Width / 2;
            basePoint.Y = pictureBox1.Height / 2;
            initialed = true;
        }
        Point[] CreateDrawPlanePoint(Graphics gra, Pen pen, Pointz p1, Pointz p2, Pointz p3, Pointz p4, Pointz p0, double ratio ,double rotateAngle)
        {
            if (gra != null)
            {
                Point pt1 = new Point();
                pt1.X = -(int)(p1.Y / ratio);
                pt1.Y = -(int)(p1.Z / ratio);
                double c1 = Math.Sqrt(Math.Pow(p1.X, 2) + Math.Pow(p1.Y, 2));
                double tanValue1 = p1.Y / p1.X;
                double angle1 = Math.Atan(tanValue1) / (Math.PI / 180);
                double x1 = c1 * Math.Cos((angle1 - rotateAngle) * Math.PI / 180) / ratio;
                pt1.X = -(int)x1;

                Point pt2 = new Point();
                pt2.X = -(int)(p2.Y / ratio);
                pt2.Y = -(int)(p2.Z / ratio);
                double c2 = Math.Sqrt(Math.Pow(p2.X, 2) + Math.Pow(p2.Y, 2));
                double tanValue2 = p2.Y / p2.X;
                double angle2 = Math.Atan(tanValue2) / (Math.PI / 180);
                double x2 = c2 * Math.Cos((angle2 - rotateAngle) * Math.PI / 180) / ratio;
                pt2.X = -(int)x2;

                Point pt3 = new Point();
                pt3.X = -(int)(p3.Y / ratio);
                pt3.Y = -(int)(p3.Z / ratio);
                double c3 = Math.Sqrt(Math.Pow(p3.X, 2) + Math.Pow(p3.Y, 2));
                double tanValue3 = (p3.Y) / (p3.X);
                double angle3 = Math.Atan(tanValue3) / (Math.PI / 180);
                if (p3.X < 0 && tanValue3 == 0)
                {
                    angle3 = angle3 + 180;
                }
                double x3 = c3 * Math.Cos((angle3 - rotateAngle) * Math.PI / 180) / ratio;
                pt3.X = -(int)x3;


                Point pt4 = new Point();
                pt4.X = -(int)(p4.Y / ratio);
                pt4.Y = -(int)(p4.Z / ratio);
                double c4 = Math.Sqrt(Math.Pow(p4.X, 2) + Math.Pow(p4.Y, 2));
                double tanValue4 = (p4.Y) / (p4.X);
                double angle4 = Math.Atan(tanValue4) / (Math.PI / 180);
                double x4 = c4 * Math.Cos((angle4 - rotateAngle) * Math.PI / 180) / ratio;
                pt4.X = -(int)x4;

                Point pt0 = new Point();
                pt0.X = -(int)(p0.Y / ratio);
                pt0.Y = -(int)(p0.Z / ratio);
                double c0 = Math.Sqrt(Math.Pow(p0.X, 2) + Math.Pow(p0.Y, 2));
                double tanValue0 = (p0.Y) / (p0.X);
                double angle0 = Math.Atan(tanValue0) / (Math.PI / 180);
                // if (pt0.X < 0)
                //{
                //    angle0 = angle0 + 180;
                //}
                double x0 = c0 * Math.Cos((angle0 - rotateAngle) * Math.PI / 180) / ratio;
                pt0.X = -(int)x0;
                if (Double.IsNaN(x0))
                {
                    pt0.X = 0;
                }
                else
                {
                    if (p0.X < 0)
                    {
                        pt0.X = (int)x0;
                    }
                    else
                    {
                        pt0.X = -(int)x0;
                    }
                }
                return new Point[] { pt1, pt2, pt3, pt4, pt0 };
            }
            return null;
        }


        /// <summary>
        /// 获取平面点对应地面的垂直投影点
        /// </summary>
        /// <param name="ps"></param>
        /// <returns></returns>
        Point[] GetPlanePointGroundPoint(Point p1, Point p2, Point p3, Point p4, int groundHeight)
        {
            Point pg1 = new Point();
            pg1.X = p1.X;
            pg1.Y = -groundHeight;
            Point pg2 = new Point();
            pg2.X = p2.X;
            pg2.Y =- groundHeight;
            Point pg3 = new Point();
            pg3.X = p3.X;
            pg3.Y = -groundHeight;
            Point pg4 = new Point();
            pg4.X = p4.X;
            pg4.Y =- groundHeight;

            return new Point[] { pg1, pg2, pg3, pg4 };
        }


        /// <summary>
        /// 将图形旋转指定角度
        /// </summary>
        public void RotateTras(Point p1, Point p2, Point p3, Point p4, Point p0, Point pg1, Point pg2, Point pg3, Point pg4)
        {
            if (initialed)
            {
                mygra.ResetTransform();
                mygra.TranslateTransform(basePoint.X, basePoint.Y*2);
                mygra.Clear(ColorLib.colorPlaneBack);

                mypen.Color = ColorLib.colorBasePoint;
                mygra.DrawArc(mypen, new Rectangle(new Point(-4, -4), new Size(8, 8)), 0, 360);//原点


                //mygra.RotateTransform(rotate);
                //mypen.Color = ColorLib.colorSky;
                //mygra.DrawPolygon(mypen, new Point[] { p1, p2, p3, p4 });

                mypen.Color = ColorLib.colorPN;
                mygra.DrawLine(mypen, p0, p1);
                mygra.DrawLine(mypen, p0, p2);
                mygra.DrawLine(mypen, p0, p3);
                mygra.DrawLine(mypen, p0, p4);//连线

                mypen.Color = ColorLib.colorGround;
                mygra.DrawPolygon(mypen, new Point[] { pg1, pg2, pg3, pg4 });

                mypen.Color = ColorLib.colorP1;
                mygra.DrawArc(mypen, new Rectangle(new Point(p1.X - 3, p1.Y - 3), new Size(6, 6)), 0, 360);
              
                mypen.Color = ColorLib.colorP2;
                mygra.DrawArc(mypen, new Rectangle(new Point(p2.X - 3, p2.Y - 3), new Size(6, 6)), 0, 360);
               
                mypen.Color = ColorLib.colorP3;
                mygra.DrawArc(mypen, new Rectangle(new Point(p3.X - 3, p3.Y - 3), new Size(6, 6)), 0, 360);
                
                mypen.Color = ColorLib.colorP4;
                mygra.DrawArc(mypen, new Rectangle(new Point(p4.X - 3, p4.Y - 3), new Size(6, 6)), 0, 360);

                mypen.Color = ColorLib.colorPillar;
                mygra.DrawLine(mypen, p1, pg1);
                mygra.DrawLine(mypen, p2, pg2);
                mygra.DrawLine(mypen, p3, pg3); 
                mygra.DrawLine(mypen, p4, pg4);

                mypen.Color = ColorLib.colorP0;
                mygra.DrawArc(mypen, new Rectangle(new Point(p0.X - 3, p0.Y - 3), new Size(6, 6)), 0, 360);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                mybm.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                pictureBox1.Image = Image.FromStream(ms);
                //ctureBox1.Refresh();
            }
        }

        private void FormViewSide_Load(object sender, EventArgs e)
        {
            Initial();
            //Pointz p1 = new Pointz(-100, 100, 100);
            //Pointz p2 = new Pointz(190, 120, 100);
            //Pointz p3 = new Pointz(180, 150, -300);
            //Pointz p4 = new Pointz(-210, 200, -300);


            //myps = CreateDrawPlanePoint(mygra, mypen, p1, p2, p3, p4, 0.7);
            //myGroundps = GetPlanePointGroundPoint(myps[0], myps[1], myps[2], myps[3], 10);
        }

        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="p0">p点</param>
        public void DiplayPoint(Pointz p1, Pointz p2, Pointz p3, Pointz p4, Pointz p0, double ratio)
        {
            if (CheckPointz(p1)
                  && CheckPointz(p2)
                  && CheckPointz(p3)
                  && CheckPointz(p4))
            {
                pointzSta1 = p1;
                pointzSta2 = p2;
                pointzSta3 = p3;
                pointzSta4 = p4;
                pointzSta0 = p0;
                SetRatio(ratio);
                setvalue = true;
                ShowPoint();
            }
        }

         delegate void DLGShowPoint();
        DLGShowPoint dlgShowPoint;

        void ShowPoint()
        {
            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke(dlgShowPoint, null);
            }
            else
            {
                if (setvalue)
                {

                    double angle = GetRotateAngle();

                    double minplane = GetShowPlaneMinRadius();
                    double maxRadius = GetMaxRadius();
                    ratioSta = maxRadius / minplane;

                    myps = CreateDrawPlanePoint(mygra, mypen, pointzSta1, pointzSta2, pointzSta3, pointzSta4,
                        pointzSta0, ratioSta, angle);
                    myGroundps = GetPlanePointGroundPoint(myps[0], myps[1], myps[2], myps[3], 10);
                    RotateTras(myps[0], myps[1], myps[2], myps[3]
                        , myps[4]
                        , myGroundps[0], myGroundps[1], myGroundps[2], myGroundps[3]);
                }
            }
        }
        /// <summary>
        /// 设置缩放比例
        /// </summary>
        /// <param name="ratio"></param>
        public void SetRatio(double ratio)
        {
            if (ratio == 0)
                return;
            ratioSta = ratio;
            ShowPoint();
        }
        /// <summary>
        /// 旋转角度
        /// </summary>
        /// <param name="rotate"></param>
        public void SetRotateAngle(double rotate)
        {
            OffsetRotate = rotate;
            ShowPoint();
        }
        private void FormViewSide_SizeChanged(object sender, EventArgs e)
        {
            ReInitialGraphice();
            ShowPoint();
        }
    }
}
