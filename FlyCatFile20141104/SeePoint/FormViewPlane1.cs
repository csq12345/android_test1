using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mod;
using System.Drawing.Drawing2D;

namespace SeePoint
{
    public partial class FormViewPlane1 : FormView
    {

        Graphics mygra;
        Bitmap mybm;
        Point[] myps;

        Pen mypen;

        /// <summary>
        /// 自定义区域集合
        /// </summary>
        List<District> Districts = new List<District>();

        /// <summary>
        /// 最大半径
        /// </summary>
        double maxRadius = 0;

        private int downX = 0;
        /// <summary>
        /// 鼠标按下时相对pic坐标
        /// </summary>
        public int DownX
        {
            get { return downX; }
            set { downX = value; }
        }
        private int downY = 0;
        /// <summary>
        /// 鼠标按下时相对pic坐标
        /// </summary>
        public int DownY
        {
            get { return downY; }
            set { downY = value; }
        }

        /// <summary>
        /// 是否正在编辑区域
        /// </summary>
        bool editDistrict = false;

        /// <summary>
        /// 是否正在删除区域
        /// </summary>
        bool deleteDistrict = false;

        /// <summary>
        /// 绘制时显示的比例
        /// </summary>
        double showRatio = 0;


        ///// <summary>
        ///// 原点
        ///// </summary>
        //internal Point basePoint;
        //#endregion
        public FormViewPlane1()
        {
            InitializeComponent();
            BasePointChanged += new BasePointChangedEventHandler(FormViewPlane_BasePointChanged);

            base.pictureBox1.MouseClick += new MouseEventHandler(pictureBox1_MouseClick);
        }



        void FormViewPlane_BasePointChanged(Point basepoint)
        {

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
        }
        void ReInitialGraphice()
        {
            initialed = false;
            mybm.Dispose();
            mybm = new Bitmap(pictureBox1.Width, pictureBox1.Height);//画板
            mygra = Graphics.FromImage(mybm);
            basePoint.X = pictureBox1.Width / 2;
            basePoint.Y = pictureBox1.Height / 2;

            initialed = true;
        }

       

        /// <summary>
        /// 绘制四边平面
        /// </summary>
        /// <param name="gra">绘制对象</param>
        /// <param name="pen">画笔</param>
        /// <param name="basePoint">绘图原点</param>
        /// <param name="p1">1点</param>
        /// <param name="p2">2点</param>
        /// <param name="p3">3点</param>
        /// <param name="p4">4点</param>
        /// <param name="p0">云台p点</param>
        /// <param name="ratio">比例</param>
        Point[] CreateDrawPlanePoint(Graphics gra, Pen pen, Pointz p1, Pointz p2, Pointz p3, Pointz p4, Pointz p0, double ratio,
             int wp1, int wp2, int wp3, int wp4)
        {
            if (gra != null)
            {
                Point pt1 = new Point();
                pt1.X = -(int)(p1.X / ratio);
                pt1.Y = (int)(p1.Y / ratio);

                Point pt2 = new Point();
                pt2.X = -(int)(p2.X / ratio);
                pt2.Y = (int)(p2.Y / ratio);

                Point pt3 = new Point();
                pt3.X = -(int)(p3.X / ratio);
                pt3.Y = (int)(p3.Y / ratio);

                Point pt4 = new Point();
                pt4.X = -(int)(p4.X / ratio);
                pt4.Y = (int)(p4.Y / ratio);

                Point pt0 = new Point();
                pt0.X = -(int)(p0.X / ratio);
                pt0.Y = (int)(p0.Y / ratio);

                Point wpt1 = new Point();
                //wpt1.X = -(int)(wp1.X / ratio);
                //wpt1.Y = (int)(wp1.Y / ratio);

                Point wpt2 = new Point();
                //wpt2.X = -(int)(wp2.X / ratio);
                //wpt2.Y = (int)(wp2.Y / ratio);

                Point wpt3 = new Point();
                //wpt3.X = -(int)(wp3.X / ratio);
                //wpt3.Y = (int)(wp3.Y / ratio);

                Point wpt4 = new Point();
                //wpt4.X = -(int)(wp4.X / ratio);
                //wpt4.Y = (int)(wp4.Y / ratio);

                return new Point[] { pt1, pt2, pt3, pt4, pt0, wpt1, wpt2, wpt3, wpt4 };
            }
            return null;
        }

        /// <summary>
        /// 获取缩小指定比例的点
        /// </summary>
        /// <param name="gra">绘制对象</param>
        /// <param name="pen">画笔</param>
        /// <param name="basePoint">绘图原点</param>
        /// <param name="p1">1点</param>
        /// <param name="p2">2点</param>
        /// <param name="p3">3点</param>
        /// <param name="p4">4点</param>
        /// <param name="p0">云台p点</param>
        /// <param name="ratio">比例</param>
        Point DrawRaticPoint(Pointz p, double ratio)
        {

            Point pt1 = new Point();
            pt1.X = (int)(p.X / ratio);
            pt1.Y = (int)(p.Y / ratio);

            return pt1;

        }

        private void FormViewPlane_Load(object sender, EventArgs e)
        {
            Initial();
            //this.Text = pictureBox1.Width + " " + pictureBox1.Height;
            //this.Bounds = new Rectangle();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

            base.OnPaintBackground(e);
        }








        ////////////////////

        //
        //计算旋转后各点坐标
        //
        //找出4点的最大x最小x最大y最小y
        //计算绘制各点所需最小矩形面积
        //平移坐标原点 从左上角 到 绝对最小y 和绝对最大x
        //绘制点


        /// <summary>
        /// 坐标原点偏移
        /// </summary>
        Point offsetBasePoint;

        /// <summary>
        /// 当前自然旋转角度
        /// </summary>
        double newRotateAngle = 0;
        /// <summary>
        /// 当前自然旋转角度
        /// </summary>
        public double NewRotateAngle
        {
            get { return newRotateAngle; }
            set { newRotateAngle = value; }
        }

        /// <summary>
        /// 计算原点偏移后 指定点的新坐标点 实际绘图原点并未变化
        /// </summary>
        /// <param name="p"></param>
        /// <param name="offsetBasepoint"></param>
        /// <returns></returns>
        Point ConvertBasePoint(Point p, Point offsetBasepoint)
        {
            Point rp = new Point();
            rp.X = p.X + offsetBasepoint.X;
            rp.Y = p.Y + offsetBasepoint.Y;

            return rp;
        }

        /// <summary>
        /// 设置绘制原点的偏移
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void SetOffsetBasePoint(int x, int y)
        {
            if (mygra != null)
            {

                mygra.TranslateTransform(x, y);
                mygra.ScaleTransform(-1, 1);
            }
        }

        /// <summary>
        /// 设置偏移修正旋转角 返回实际旋转角 偏移+期望
        /// </summary>
        /// <param name="pA"></param>
        /// <param name="pB"></param>
        /// <param name="pC"></param>
        /// <param name="pD"></param>
        /// <returns></returns>
        double SetOffsetRotate(Point pA, Point pB)
        {
            Pointz pza = new Pointz(pA.X, pA.Y, 0);
            Pointz pzb = new Pointz(pB.X, pB.Y, 0);
            double myrotate = GetRotateAngle(pza, pzb) + newRotateAngle;

            if (mygra != null)
            {
                mygra.RotateTransform((float)myrotate);
            }

            return myrotate;
        }


        /// <summary>
        /// 设置偏移修正旋转角 返回实际旋转角 偏移+期望
        /// </summary>
        /// <param name="pA"></param>
        /// <param name="pB"></param>
        /// <param name="pC"></param>
        /// <param name="pD"></param>
        /// <returns></returns>
        double SetOffsetRotate(Pointz pA, Pointz pB)
        {

            double myrotate = GetRotateAngle(pA, pB) + newRotateAngle;

            if (mygra != null)
            {
                mygra.RotateTransform((float)myrotate);
            }

            return myrotate;
        }


        /// <summary>
        /// 原点变换后的坐标点 即实际绘制点
        /// </summary>
        Point psa;
        /// <summary>
        /// 原点变换后的坐标点 即实际绘制点
        /// </summary>
        Point psb;
        /// <summary>
        /// 原点变换后的坐标点 即实际绘制点
        /// </summary>
        Point psc;
        /// <summary>
        /// 原点变换后的坐标点 即实际绘制点
        /// </summary>
        Point psd;
        /// <summary>
        /// 原点变换后的坐标点 即实际绘制点
        /// </summary> 
        Point ps0;

        public void Draw(Pointz pA, Pointz pB, Pointz pC, Pointz pD, Pointz p0, double ratic)
        {

            pointzSta1 = pA;
            pointzSta2 = pB;
            pointzSta3 = pC;
            pointzSta4 = pD;
            pointzSta0 = p0;

            mygra.ResetTransform();


            //Point pa = new Point((int)pA.X, (int)pA.Y);
            //Point pb = new Point((int)pB.X, (int)pB.Y);
            //Point pc = new Point((int)pC.X, (int)pC.Y);
            //Point pd = new Point((int)pD.X, (int)pD.Y);
            //Point p_0 = new Point((int)p0.X, (int)p0.Y);

            offsetBasePoint = new Point(0, 0);

            SetOffsetBasePoint(basePoint.X, basePoint.Y);

            //double toRotate = SetOffsetRotate(pA, pB);
            double toRotate = -GetRotateAngle(pA, pB) - newRotateAngle;



            //计算可用的最大比例
            showRatio = ratic;
            Size recSize = new Size(pictureBox1.Width / 2, pictureBox1.Height / 2);
            double newRatic = GetMaxRatic(ratic, pA, pB, pC, pD, toRotate, recSize);
            showRatio = newRatic;

            //将实际点坐标缩小指定比例 适应窗口显示
            Point pa = DrawRaticPoint(pA, showRatio);
            Point pb = DrawRaticPoint(pB, showRatio);
            Point pc = DrawRaticPoint(pC, showRatio);
            Point pd = DrawRaticPoint(pD, showRatio);
            Point p_0 = DrawRaticPoint(p0, showRatio);

            Point opa = new Point();
            Point opb = new Point();
            Point opc = new Point();
            Point opd = new Point();
            Point op_0 = new Point();
            GetGetRotatePoints(pa, pb, pc, pd, p_0, toRotate, out opa, out opb, out opc, out opd, out op_0);

            psa = ConvertBasePoint(opa, offsetBasePoint);
            psb = ConvertBasePoint(opb, offsetBasePoint);
            psc = ConvertBasePoint(opc, offsetBasePoint);
            psd = ConvertBasePoint(opd, offsetBasePoint);
            ps0 = ConvertBasePoint(op_0, offsetBasePoint);


            Drawer(psa, psb, psc, psd, ps0);

            bool canDraw = GetCanDraw(psa, psb, psc, psd, recSize);
            if (!canDraw)
            {
                this.Width = this.Width + 5;
                this.Height = this.Height + 5;
                ReDraw();
            }
            else
            {

            }
        }

        /// <summary>
        /// 获取四个点是否可以绘制出来并显示
        /// </summary>
        /// <param name="pa"></param>
        /// <param name="pb"></param>
        /// <param name="pc"></param>
        /// <param name="pd"></param>
        /// <returns></returns>
        bool GetCanDraw(Point pa, Point pb, Point pc, Point pd)
        {
            bool cp1 = CheckPointVisable(pa);
            bool cp2 = CheckPointVisable(pb);
            bool cp3 = CheckPointVisable(pc);
            bool cp4 = CheckPointVisable(pd);

            return cp1 || cp2 || cp3 || cp4;

        }

        /// <summary>
        /// 获取指定的点是否可以绘制
        /// </summary>
        /// <param name="pa"></param>
        /// <param name="pb"></param>
        /// <param name="pc"></param>
        /// <param name="pd"></param>
        /// <param name="rectangleSize"></param>
        /// <returns></returns>
        bool GetCanDraw(Point pa, Point pb, Point pc, Point pd, Size rectangleSize)
        {
            bool cp1 = CheckPointVisable(pa, rectangleSize);
            bool cp2 = CheckPointVisable(pb, rectangleSize);
            bool cp3 = CheckPointVisable(pc, rectangleSize);
            bool cp4 = CheckPointVisable(pd, rectangleSize);

            return cp1 & cp2 & cp3 & cp4;
        }
        /// <summary>
        /// 判断指定的点是否在面积区域中可绘制的
        /// </summary>
        /// <param name="p"></param>
        /// <param name="rectangleSize"></param>
        /// <returns></returns>
        bool CheckPointVisable(Point p, Size rectangleSize)
        {
            if (Math.Abs(p.X) > rectangleSize.Width || Math.Abs(p.Y) > rectangleSize.Height)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 重绘当前点
        /// </summary>
        public void ReDraw()
        {
            Draw(pointzSta1, pointzSta2, pointzSta3, pointzSta4, pointzSta0, showRatio);
        }

        void Drawer(Point pA, Point pB, Point pC, Point pD, Point p0)
        {
            try
            {


                if (initialed)
                {
                    mygra.Clear(ColorLib.colorPlaneBack);

                    mypen.Color = ColorLib.colorP1;
                    mygra.DrawArc(mypen, new Rectangle(new Point(pA.X - 3, pA.Y - 3), new Size(6, 6)), 0, 360);//A

                    mypen.Color = ColorLib.colorP2;
                    mygra.DrawArc(mypen, new Rectangle(new Point(pB.X - 3, pB.Y - 3), new Size(6, 6)), 0, 360);//B

                    mypen.Color = ColorLib.colorP3;
                    mygra.DrawArc(mypen, new Rectangle(new Point(pC.X - 3, pC.Y - 3), new Size(6, 6)), 0, 360);//C

                    mypen.Color = ColorLib.colorP4;
                    mygra.DrawArc(mypen, new Rectangle(new Point(pD.X - 3, pD.Y - 3), new Size(6, 6)), 0, 360);//D

                    mypen.Color = ColorLib.colorBasePoint;
                    mygra.DrawArc(mypen, new Rectangle(new Point(p0.X - 3, p0.Y - 3), new Size(6, 6)), 0, 360);//P  


                    mypen.Color = ColorLib.colorGround;
                    mygra.DrawPolygon(mypen, new Point[] { pA, pB, pC, pD });


                    mypen.Color = ColorLib.colorPN;
                    mygra.DrawLine(mypen, p0, pA);
                    mygra.DrawLine(mypen, p0, pB);
                    mygra.DrawLine(mypen, p0, pC);
                    mygra.DrawLine(mypen, p0, pD);//连线


                    foreach (District item in Districts)
                    {
                        if (item.EndEdit)
                        {
                            Point2d[] p2ds = item.GetPoints();
                            if (p2ds.Length >= 3)
                            {

                                Point[] ps = new Point[p2ds.Length];

                                for (int i = 0; i < ps.Length; i++)
                                {
                                    ps[i].X = -(int)(p2ds[i].X / showRatio);
                                    ps[i].Y = (int)(p2ds[i].Y / showRatio);
                                }
                                GraphicsPath graPath = new GraphicsPath();
                                graPath.AddPolygon(ps);
                                if (graPath.IsVisible(p0))
                                {
                                    mypen.Color = ColorLib.warning;
                                }
                                else
                                {
                                    mypen.Color = ColorLib.colorBasePoint;
                                }
                                mygra.DrawPolygon(mypen, ps);
                            }
                        }
                        else
                        {
                            Point2d[] p2ds = item.GetPoints();
                            foreach (Point2d p2d in p2ds)
                            {
                                int drawp2dx = -(int)(p2d.X / showRatio);
                                int drawp2dy = (int)(p2d.Y / showRatio);

                                mypen.Color = ColorLib.colorBasePoint;


                                mygra.DrawArc(mypen, new Rectangle(new Point(drawp2dx - 3, drawp2dy - 3), new Size(6, 6)), 0, 360);//P  
                            }
                        }
                    }

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    mybm.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            catch
            {

            }
        }


        ///// <summary>
        ///// 设置旋转角度
        ///// </summary>
        ///// <param name="rotate"></param>
        //public void SetRotateAngle(double rotate)
        //{
        //    ReDraw();
        //}

        /// <summary>
        /// 获取相对绘制原点最大距离的点 输出最大距离
        /// </summary>
        /// <returns></returns>
        Point GetMaxRadius(out double len)
        {
            double re = 0;
            Point rp = new Point();
            if (psa != null
                && psb != null
                && psc != null
                && psd != null)
            {
                double c1 = Math.Sqrt(Math.Pow(psa.X, 2) + Math.Pow(psa.Y, 2));
                double c2 = Math.Sqrt(Math.Pow(psb.X, 2) + Math.Pow(psb.Y, 2));
                double c3 = Math.Sqrt(Math.Pow(psc.X, 2) + Math.Pow(psc.Y, 2));
                double c4 = Math.Sqrt(Math.Pow(psd.X, 2) + Math.Pow(psd.Y, 2));

                re = c1;
                rp = psa;
                if (c2 > re)
                {
                    re = c2;
                    rp = psb;
                }
                if (c3 > re)
                {
                    re = c3;
                    rp = psc;
                }
                if (c4 > re)
                {
                    re = c4;
                    rp = psd;
                }

            }
            len = re;

            return rp;
        }

        /// <summary>
        /// 获取绘制这些点所需要的最小矩形面积（绘制原点在图形中心）
        /// </summary>
        /// <param name="ps"></param>
        /// <returns></returns>
        Size GetMinDrawRectangleSize(Point pa, Point pb, Point pc, Point pd, double angle)
        {
            Point p = new Point(0, 0);

            //计算点沿原点旋转后的坐标
            Point rotateA = GetRotatePoint(p, pa, angle);
            Point rotateB = GetRotatePoint(p, pb, angle);
            Point rotateC = GetRotatePoint(p, pc, angle);
            Point rotateD = GetRotatePoint(p, pd, angle);

            //找出坐标中 x轴最大的点 和y轴最大的点

            int maxX = 0;
            int maxY = 0;

            if (rotateA.X > maxX)
                maxX = rotateA.X;
            if (rotateB.X > maxX)
                maxX = rotateB.X;
            if (rotateC.X > maxX)
                maxX = rotateC.X;
            if (rotateD.X > maxX)
                maxX = rotateD.X;

            if (rotateA.Y > maxY)
                maxY = rotateA.Y;
            if (rotateB.Y > maxY)
                maxY = rotateB.Y;
            if (rotateC.Y > maxY)
                maxY = rotateC.Y;
            if (rotateD.Y > maxY)
                maxY = rotateD.Y;

            Size re = new Size(maxX, maxY);

            return re;
        }

        Point GetMinDrawRectangleCenter(Point pa, Point pb, Point pc, Point pd, double angle)
        {
          Size si=  GetMinDrawRectangleSize(pa,pb,pc,pd,angle);

            

          Point p = new Point();
          return p;
        }

        double GetMaxX(Point pa, Point pb, Point pc, Point pd)
        {
            return 0;
        }

        double GetMinX(Point pa, Point pb, Point pc, Point pd)
        {
            return 0;
        }
        double GetMaxY(Point pa, Point pb, Point pc, Point pd)
        {
            return 0;
        }
        double GetMinY(Point pa, Point pb, Point pc, Point pd)
        {
            return 0;
        }

        /// <summary>
        /// 获取指定点沿着指定原点旋转指定角度的点
        /// </summary>
        /// <param name="ps"></param>
        /// <returns></returns>
        void GetGetRotatePoints(Point pa, Point pb, Point pc, Point pd, Point p0, double angle,
            out Point opa, out  Point opb, out  Point opc, out  Point opd, out Point op0)
        {
            Point p = new Point(0, 0);

            //计算点沿原点旋转后的坐标
            opa = GetRotatePoint(p, pa, angle);
            opb = GetRotatePoint(p, pb, angle);
            opc = GetRotatePoint(p, pc, angle);
            opd = GetRotatePoint(p, pd, angle);
            op0 = GetRotatePoint(p, p0, angle);

        }

        /// <summary>
        /// 获取指定点沿着指定原点旋转指定角度的点
        /// </summary>
        /// <param name="center"></param>
        /// <param name="p1"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        private Point GetRotatePoint(Point center, Point p1, double angle)
        {
            Point tmp = new Point();
            double angleHude = angle * Math.PI / 180;/*角度变成弧度*/
            double x1 = (p1.X - center.X) * Math.Cos(angleHude) + (p1.Y - center.Y) * Math.Sin(angleHude) + center.X;
            double y1 = -(p1.X - center.X) * Math.Sin(angleHude) + (p1.Y - center.Y) * Math.Cos(angleHude) + center.Y;
            tmp.X = (int)x1;
            tmp.Y = (int)y1;
            return tmp;
        }


        double maxangle = 0;

        /// <summary>
        /// 获取区域中最大可缩放的比例
        /// </summary>
        /// <param name="rat"></param>
        /// <returns></returns>
        double GetMaxRatic(double rat, int width, int height)
        {
            //Pointz maxradiusPointz = GetMaxRadius(out maxRadius);

            double maxlen = 0;
            Point maxradiusPointz = GetMaxRadius(out maxlen);

            if (maxradiusPointz != null)
            {
                double tanValue = Math.Abs(maxradiusPointz.Y) / Math.Abs(maxradiusPointz.X);
                double myangle = Math.Atan(tanValue) / (Math.PI / 180);//计算最大距离点和x轴夹角

                double angle = GetRotateAngle();
                maxangle = myangle - angle;
                double cosvalue = Math.Cos((myangle - angle) * Math.PI / 180);

                double sinvalue = Math.Sin((myangle - angle) * Math.PI / 180);
                return GetMaxRatic(rat, cosvalue, sinvalue, width, height);
            }
            else
            {
                return 0;
            }
        }

        double maxratiosta = 0;
        double GetMaxRatic(double rat, double cos, double sin, int width, int height)
        {
            double re = rat - 5;//最大比例
            double w2 = 0;
            double h2 = 0;
            w2 = (maxRadius / re) * cos * 2;
            h2 = (maxRadius / re) * sin * 2;

            w2 = Math.Abs(w2);
            h2 = Math.Abs(h2);
            double maxnum = Math.Max(w2, h2);
            double minsize = Math.Min(pictureBox1.Width, pictureBox1.Height);
            if (maxnum < minsize)
            {
                //可以继续放大
                return GetMaxRatic(re, cos, sin, width, height);
            }
            return re + 20;
        }


        /// <summary>
        /// 获取区域中最大可缩放的比例
        /// </summary>
        /// <param name="rat"></param>
        /// <returns></returns>
        double GetMaxRatic(double rat, Size size, int width, int height)
        {
            //Pointz maxradiusPointz = GetMaxRadius(out maxRadius);

            double maxlen = 0;
            Point maxradiusPointz = GetMaxRadius(out maxlen);

            if (maxradiusPointz != null)
            {
                double tanValue = Math.Abs(maxradiusPointz.Y) / Math.Abs(maxradiusPointz.X);
                double myangle = Math.Atan(tanValue) / (Math.PI / 180);//计算最大距离点和x轴夹角

                double angle = GetRotateAngle();
                maxangle = myangle - angle;
                double cosvalue = Math.Cos((myangle - angle) * Math.PI / 180);

                double sinvalue = Math.Sin((myangle - angle) * Math.PI / 180);
                return GetMaxRatic(rat, cosvalue, sinvalue, width, height);
            }
            else
            {
                return 0;
            }
        }


        double GetMaxRatic(double ratic, Pointz pA, Pointz pB, Pointz pC, Pointz pD, double rotateAngle, Size nowRectangleSize)
        {

            double re = ratic - 4;//最大比例
            double w2 = 0;
            double h2 = 0;

            //计算按当前比例显示所需的矩形大小
            Point pa = DrawRaticPoint(pA, re);
            Point pb = DrawRaticPoint(pB, re);
            Point pc = DrawRaticPoint(pC, re);
            Point pd = DrawRaticPoint(pD, re);
            Size si = GetMinDrawRectangleSize(pa, pb, pc, pd, rotateAngle);

            //比较当前矩形大小 是否包含需求大小
            if (nowRectangleSize.Width > si.Width && nowRectangleSize.Height > si.Height)
            {
                //尝试继续放大
                return GetMaxRatic(re, pA, pB, pC, pD, -rotateAngle, nowRectangleSize);
            }
            else
            {
                return re + 10;
            }


            //if (maxnum < minsize)
            //{
            //    //可以继续放大
            //    return GetMaxRatic(re, size, width, height);
            //}

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

        private void FormViewPlane_Resize(object sender, EventArgs e)
        {

        }


        private void 删除区域ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                deleteDistrict = 删除区域ToolStripMenuItem.Checked;
                
                //if (删除区域ToolStripMenuItem.Checked)
                //{

                //}
                //else
                //{

                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 当前自定义区域
        /// </summary>
        District nowDistrict;

        private void 新建区域ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                editDistrict = 新建区域ToolStripMenuItem.Checked;
                if (新建区域ToolStripMenuItem.Checked)
                {
                    删除区域ToolStripMenuItem.Checked = false;

                    nowDistrict = new District();
                    Districts.Add(nowDistrict);
                }
                else
                {

                    nowDistrict.EndEdit = true;
                    //if (nowDistrict != null && nowDistrict.Count > 2)
                    //{
                    //Districts.Add(nowDistrict);
                    //}
                    nowDistrict = null;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                DownX = e.X;
                DownY = e.Y;

                if (editDistrict && nowDistrict != null)
                {
                    //计算相对绘图原地的坐标点
                    int bpx = DownX - basePoint.X;
                    int bpy = DownY - basePoint.Y;

                    //乘上比例 得出实际大小坐标
                    int bpx2 = (int)(bpx * showRatio);
                    int bpy2 = (int)(bpy * showRatio);
                    Point2d p = new Point2d(bpx2, bpy2);
                    nowDistrict.Add(p);
                }
                else if(deleteDistrict)
                {
                    //计算相对绘图原地的坐标点
                    int bpx = DownX - basePoint.X;
                    int bpy = DownY - basePoint.Y;

                    //乘上比例 得出实际大小坐标
                    int bpx2 = (int)(bpx * showRatio);
                    int bpy2 = (int)(bpy * showRatio);

                    Point p0 = new Point(-bpx,bpy);

                    List<District> deletedis = new List<District>();

                    foreach (District item in Districts)
                    {
                        if (item.EndEdit)
                        {
                            Point2d[] p2ds = item.GetPoints();
                            if (p2ds.Length >= 3)
                            {

                                Point[] ps = new Point[p2ds.Length];

                                for (int i = 0; i < ps.Length; i++)
                                {
                                    ps[i].X = -(int)(p2ds[i].X / showRatio);
                                    ps[i].Y = (int)(p2ds[i].Y / showRatio);
                                }
                                GraphicsPath graPath = new GraphicsPath();
                                graPath.AddPolygon(ps);
                                if (graPath.IsVisible(p0))
                                {
                                    deletedis.Add(item);
                                }
                                else
                                {
                                  
                                }
                               
                            }
                        }
                    }


                    //删除要删除的区域
                    for (int i = 0; i < deletedis.Count; i++)
                    {
                        Districts.Remove(deletedis[i]);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormViewPlane1_SizeChanged(object sender, EventArgs e)
        {
            ReInitialGraphice();

            //showRatic = GetMaxRatic(showRatic);
        }
    }
}
