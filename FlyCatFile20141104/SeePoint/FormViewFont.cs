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
    public partial class FormViewFontOrSide : FormView
    {


        Graphics mygra;
        Bitmap mybm;
        Point[] myps;
        Point[] myGroundps;
        Pen mypen;
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

        public FormViewFontOrSide(string title)
        {
            InitializeComponent();
            BasePointChanged += new BasePointChangedEventHandler(FormViewFont_BasePointChanged);
            dlgShowPoint = new DLGShowPoint(ShowPoint);
            this.Text = title;

        }

        void FormViewFont_BasePointChanged(Point basepoint)
        {
            ShowPoint();
        }
        
        double addangle = 0;
        /// <summary>
        /// 设置补充角度
        /// </summary>
        public double Addangle
        {
            get { return addangle; }
            set { addangle = value; }
        }

        void Initial()
        {
            initialed = false;
            mybm = new Bitmap(pictureBox1.Width, pictureBox1.Height);//画板
            mypen = new Pen(new SolidBrush(ColorLib.colorPen), 2);//画笔
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
        private void FormViewFont_Load(object sender, EventArgs e)
        {
            Initial();
            //Pointz p1 = new Pointz(-100, 100, 100);
            //Pointz p2 = new Pointz(190, 120, 100);
            //Pointz p3 = new Pointz(180, 150, -300);
            //Pointz p4 = new Pointz(-210, 200, -300);



            //graWidth = pictureBox1.Width / 2;
            //graHeight = pictureBox1.Height / 2;
            //myps = ConvertToPlanePoint(p1, p2, p3, p4);
            //myps = CreateDrawPlanePoint(mygra, mypen, p1, p2, p3, p4, 0.7);
            //myGroundps = GetPlanePointGroundPoint(myps, 10);
        }


        Point[] CreateDrawPlanePoint(Graphics gra, Pen pen, Pointz p1, Pointz p2, Pointz p3, Pointz p4, Pointz p0, double ratio, double rotateAngle)
        {
            if (gra != null)
            {

                Point pt1 = new Point();
                pt1.X = -(int)(p1.X / ratio);
                pt1.Y = -(int)(p1.Z / ratio);
                double c1 = Math.Sqrt(Math.Pow(p1.X, 2) + Math.Pow(p1.Y, 2));
                double tanValue1 = p1.Y / p1.X;
                double angle1 = Math.Atan(tanValue1) / (Math.PI / 180);
                double x1 = c1 * Math.Cos((angle1 + rotateAngle) * Math.PI / 180) / ratio;
                pt1.X = -(int)x1;

                Point pt2 = new Point();
                pt2.X = -(int)(p2.X / ratio);
                pt2.Y = -(int)(p2.Z / ratio);
                double c2 = Math.Sqrt(Math.Pow(p2.X, 2) + Math.Pow(p2.Y, 2));
                double tanValue2 = p2.Y / p2.X;
                double angle2 = Math.Atan(tanValue2) / (Math.PI / 180);
                if (p2.X < 0)
                {
                    angle2 = angle2 + 180;
                }
                double x2 = c2 * Math.Cos((angle2 + rotateAngle) * Math.PI / 180) / ratio;
                pt2.X = -(int)x2;

                Point pt3 = new Point();
                pt3.X = -(int)(p3.X / ratio);
                pt3.Y = -(int)(p3.Z / ratio);
                double c3 = Math.Sqrt(Math.Pow(p3.X, 2) + Math.Pow(p3.Y, 2));
                double tanValue3 = (p3.Y) / (p3.X);
                double angle3 = Math.Atan(tanValue3) / (Math.PI / 180);
                if (p3.X < 0)
                {
                    angle3 = angle3 + 180;
                }
                double x3 = c3 * Math.Cos((angle3 + rotateAngle) * Math.PI / 180) / ratio;
                pt3.X = -(int)x3;

                Point pt4 = new Point();
                pt4.X = -(int)(p4.X / ratio);
                pt4.Y = -(int)(p4.Z / ratio);
                double c4 = Math.Sqrt(Math.Pow(p4.X, 2) + Math.Pow(p4.Y, 2));
                double tanValue4 = (p4.Y) / (p4.X);
                double angle4 = Math.Atan(tanValue4) / (Math.PI / 180);
                double x4 = c4 * Math.Cos((angle4 + rotateAngle) * Math.PI / 180) / ratio;
                pt4.X = -(int)x4;

                Point pt0 = new Point();
                pt0.X = -(int)(p0.X / ratio);
                pt0.Y = -(int)(p0.Z / ratio);
                double c0 = Math.Sqrt(Math.Pow(p0.X, 2) + Math.Pow(p0.Y, 2));
                double tanValue0 = (p0.Y) / (p0.X);
                double angle0 = Math.Atan(tanValue0) / (Math.PI / 180);
                //if (pt0.X < 0)
                //{
                //    angle0 = angle0 + 180;
                //}
                double x0 = c0 * Math.Cos((angle0 + rotateAngle) * Math.PI / 180) / ratio;
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
            pg2.Y = -groundHeight;
            Point pg3 = new Point();
            pg3.X = p3.X;
            pg3.Y = -groundHeight;
            Point pg4 = new Point();
            pg4.X = p4.X;
            pg4.Y = -groundHeight;

            return new Point[] { pg1, pg2, pg3, pg4 };
        }

        Pointz GetZero(Pointz p1, Pointz p2)
        {
            double xc = Math.Abs(p2.X - p1.X);
            double yc = Math.Abs(p2.Z - p1.Z);
            double x2 = Math.Pow(xc, 2);
            double y2 = Math.Pow(yc, 2);
            double z1 = Math.Sqrt(x2 + y2);

            return new Pointz();
        }


        /// <summary>
        /// 将图形旋转指定角度
        /// </summary>
        public bool RotateTras(Point p1, Point p2, Point p3, Point p4, Point p0, Point pg1, Point pg2, Point pg3, Point pg4)
        {

            try
            {


                if (initialed)
                {
                    mygra.ResetTransform();
                    mygra.TranslateTransform(basePoint.X, basePoint.Y * 2);
                    mygra.Clear(ColorLib.colorPlaneBack);

                    mypen.Color = ColorLib.colorBasePoint;
                    mygra.DrawArc(mypen, new Rectangle(new Point(-4, -4), new Size(8, 8)), 0, 360);//原点

                    bool cp1 = CheckPointVisable(myps[0]);
                    bool cp2 = CheckPointVisable(myps[1]);
                    bool cp3 = CheckPointVisable(myps[2]);
                    bool cp4 = CheckPointVisable(myps[3]);
                    if (cp1 & cp2 & cp3 & cp4)
                    {
                        Console.WriteLine("绘制");
                        //mygra.RotateTransform(rotate);
                        //mypen.Color = ColorLib.colorSky;
                        //mygra.DrawPolygon(mypen, new Point[] { p1, p2, p3, p4 });

                        mypen.Color = ColorLib.colorGround;
                        mygra.DrawPolygon(mypen, new Point[] { pg1, pg2, pg3, pg4 });


                        mypen.Color = ColorLib.colorPN;
                        mygra.DrawLine(mypen, p0, p1);
                        mygra.DrawLine(mypen, p0, p2);
                        mygra.DrawLine(mypen, p0, p3);
                        mygra.DrawLine(mypen, p0, p4);//连线

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

                        evenSizeChanged = true;
                    }
                    else
                    {
                        Console.WriteLine("调整" + ratioSta);
                        evenSizeChanged = false;


                        int newWidth = this.Size.Width;

                        int newHeight = this.Size.Height;
                        double mdy = Math.Max(Math.Abs(myps[0].Y), Math.Abs(myps[1].Y));
                        mdy = Math.Max(Math.Abs(mdy), Math.Abs(myps[2].Y));
                        mdy = Math.Max(Math.Abs(mdy), Math.Abs(myps[3].Y));

                        //如果最高点大于屏幕高
                        if (mdy > pictureBox1.Height)
                        {
                            newHeight = this.Size.Height + 10;
                            //this.Size = new Size(this.Size.Width, this.Size.Height + 10);
                        }

                        double mdx = Math.Max(Math.Abs(myps[0].X), Math.Abs(myps[1].X));
                        mdx = Math.Max(Math.Abs(mdx), Math.Abs(myps[2].X));
                        mdx = Math.Max(Math.Abs(mdx), Math.Abs(myps[3].X));

                        //如果最高点大于屏幕高
                        if (mdx > pictureBox1.Width)
                        {
                            newWidth = this.Size.Width + 10;
                            //this.Size = new Size(this.Size.Width + 10, this.Size.Height);
                        }
                        this.Size = new Size(newWidth, newHeight);
                        ReInitialGraphice();
                        ShowPoint();
                        return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("绘图错误！"+ex.Message);
                this.Close();
                return false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Pointz p1 = new Pointz(100, 50, 0);
            //Pointz p2 = new Pointz(200, 50, 20);
            //GetZero(p1, p2);
        }

        /// <summary>
        /// 检查点是否在绘制范围内
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        bool CheckPointVisable(Point p)
        {
            if (mygra != null)
            {
                return mygra.IsVisible(p);
            }
            return true;
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
                //将点值折算成两位数范围内 以保证第一次显示时是显示全部点

                pointzSta1 = p1;
                pointzSta2 = p2;
                pointzSta3 = p3;
                pointzSta4 = p4;
                pointzSta0 = p0;
                double r = GetMaxRatic(ratio);
                setvalue = true;
                SetRatio(r);

                //SetRatio(ratio);



                //ShowPoint();
            }
        }


        Pointz ConvertPointz(Pointz pz)
        {



            return null;
        }

        double maxratiosta = 0;
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

                    //double minplane = GetShowPlaneMinRadius();
                    //double maxRadius = GetMaxRadius();
                    //ratioSta = maxRadius / minplane;

                    maxratiosta = GetMaxRatic(ratioSta);

                    myps = CreateDrawPlanePoint(mygra, mypen, pointzSta1, pointzSta2, pointzSta3, pointzSta4,
                        pointzSta0, ratioSta, angle + addangle);
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


        /// <summary>
        /// 是否执行窗体大小变化事件
        /// </summary>
        bool evenSizeChanged = true;
        private void FormViewFont_SizeChanged(object sender, EventArgs e)
        {
            if (evenSizeChanged)
            {
                //Console.WriteLine("大小");
                ReInitialGraphice();
                ratioSta = GetMaxRatic(ratioSta);
                ShowPoint();
            }
        }

        double maxangle = 0;
        /// <summary>
        /// 获取最大比例
        /// </summary>
        /// <param name="rat"></param>
        /// <returns></returns>
        double GetMaxRatic(double rat)
        {
            Pointz maxradiusPointz = GetMaxRadius(out maxRadius);
            double redouble = 0;
            if (maxradiusPointz != null)
            {
                double tanValue = Math.Abs(maxradiusPointz.Y) / Math.Abs(maxradiusPointz.X);
                double myangle = Math.Atan(tanValue) / (Math.PI / 180);



                double angle = GetRotateAngle();
                maxangle = myangle - angle;
                double cosvalue = Math.Cos((myangle - angle) * Math.PI / 180);

                double sinvalue = Math.Sin((myangle - angle) * Math.PI / 180);
                redouble = GetMaxRatic(rat, cosvalue, sinvalue);


            }

            //if (redouble < 130)
            //{
            //    redouble = 130;
            //}
            return redouble;
        }


        /// <summary>
        /// 最大比例
        /// </summary>
        double maxRadius = 0;
        double GetMaxRatic(double rat, double cos, double sin)
        {
            double re = rat - 2;//最大比例
            double w2 = 0;
            double h2 = 0;
            w2 = (maxRadius / re) * cos * 2;
            h2 = (maxRadius / re) * sin * 2;

            w2 = Math.Abs(w2);
            h2 = Math.Abs(h2);
            double maxnum = Math.Max(w2, h2);
            double minsize = pictureBox1.Width;
            if (maxnum < minsize)
            {
                //可以继续放大
                return GetMaxRatic(re, cos, sin);
            }
            return re + 15;
        }

    }
}
