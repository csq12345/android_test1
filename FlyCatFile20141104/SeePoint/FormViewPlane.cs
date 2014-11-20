using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mod;

namespace SeePoint
{
     partial class FormViewPlane : FormView
    {

        Graphics mygra;
        Bitmap mybm;
        Point[] myps;

        Pen mypen;

        List<District> Districts = new List<District>();

        //#region MyRegion
        // internal Pointz pointzSta1;
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

        ///// <summary>
        ///// 原点
        ///// </summary>
        //internal Point basePoint;
        //#endregion
        public FormViewPlane()
        {
            InitializeComponent();
            BasePointChanged += new BasePointChangedEventHandler(FormViewPlane_BasePointChanged);
            dlgShowPoint = new DLGShowPoint(ShowPoint);

            base.pictureBox1.MouseClick += new MouseEventHandler(pictureBox1_MouseClick);
        }



        void FormViewPlane_BasePointChanged(Point basepoint)
        {
            ShowPoint();
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



        private void FormViewPlane_Load(object sender, EventArgs e)
        {
            Initial();
            oldWidth = this.Size.Width;
            oldHeight = this.Size.Height;

        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

            base.OnPaintBackground(e);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="p">系统坐标点</param>
        /// <param name="rotate">旋转角</param>
        /// <returns>绘制坐标点</returns>
        Point ConvertPointToDraw(Point2d p, double rotate, double ratio)
        {
            double c = Math.Sqrt(Math.Pow(p.X  - basePoint.X, 2) + Math.Pow(p.Y  - basePoint.Y, 2));

            double x= Math.Sin(-rotate) * c * p.Ratio / ratio;
            double y = Math.Cos(-rotate) * c * p.Ratio / ratio;
            return new Point((int)x, (int)y);
        }


        /// <summary>
        /// 将图形旋转指定角度并绘制图形
        /// </summary>
        public bool RotateTras(Point p1, Point p2, Point p3, Point p4, Point p0, double rotate,
            Point wp1, Point wp2, Point wp3, Point wp4)
        {

            try
            {


                if (initialed)
                {
                    mygra.ResetTransform();
                    mygra.TranslateTransform(basePoint.X, basePoint.Y);
                    mygra.Clear(ColorLib.colorPlaneBack);



                    mypen.Color = ColorLib.colorBasePoint;
                    mygra.DrawArc(mypen, new Rectangle(new Point(-3, -3), new Size(6, 6)), 0, 360);//原点
  
                    mygra.RotateTransform((float)rotate);
 
                   foreach (District dis in Districts)
                    {
                        Point2d[] ps = dis.GetPoints();

                        if (dis.EndEdit)
                        {

                            //绘制区域
                           
                                Point[] ps1 = new Point[ps.Length];
                                for (int i = 0; i < ps.Length; i++)
                                {
                                    ps1[i] = ConvertPointToDraw(ps[i], rotate,ratioSta);
                                }
                            if (ps.Length > 2)
                            {
                                mygra.DrawPolygon(mypen, ps1);
                            }
                        }
                        else
                        {
                            //绘制顶点
                            foreach (Point2d p in ps)
                            {
                                //Point pd = ConvertPointToDraw(p, rotate, ratioSta);

                                Point pd = new Point(p.X,p.Y);
                                mygra.DrawArc(mypen,
                                            new Rectangle(
                                            pd,
                                            new Size(6, 6)),
                                            0,
                                            360);
                            }
                        }
                    }

                    bool cp1 = CheckPointVisable(myps[0]);
                    bool cp2 = CheckPointVisable(myps[1]);
                    bool cp3 = CheckPointVisable(myps[2]);
                    bool cp4 = CheckPointVisable(myps[3]);
                    this.Text = maxratiosta.ToString();

                    if (cp1 & cp2 & cp3 & cp4)
                    {
                        Console.WriteLine("绘制");
                        mypen.Color = ColorLib.colorPillar;
                        mygra.DrawPolygon(mypen, new Point[] { p1, p2, p3, p4 });//四周

                        mypen.Color = ColorLib.warning;
                        mygra.DrawPolygon(mypen, new Point[] { wp1, wp2, wp3, wp4 });//警戒线

                        mypen.Color = ColorLib.colorPN;
                        mygra.DrawLine(mypen, p0, p1);
                        mygra.DrawLine(mypen, p0, p2);
                        mygra.DrawLine(mypen, p0, p3);
                        mygra.DrawLine(mypen, p0, p4);//连线

                        //if (!CheckPointVisable(myps[0]))
                        //    {
                        //        this.Size = new Size(this.Size.Width + 10, this.Size.Height + 10);
                        //        //ShowPoint();
                        //    }

                        mypen.Color = ColorLib.colorP1;
                        mygra.DrawArc(mypen, new Rectangle(new Point(p1.X - 3, p1.Y - 3), new Size(6, 6)), 0, 360);//A
                        mypen.Color = ColorLib.colorP2;
                        mygra.DrawArc(mypen, new Rectangle(new Point(p2.X - 3, p2.Y - 3), new Size(6, 6)), 0, 360);//B
                        mypen.Color = ColorLib.colorP3;
                        mygra.DrawArc(mypen, new Rectangle(new Point(p3.X - 3, p3.Y - 3), new Size(6, 6)), 0, 360);//C
                        mypen.Color = ColorLib.colorP4;
                        mygra.DrawArc(mypen, new Rectangle(new Point(p4.X - 3, p4.Y - 3), new Size(6, 6)), 0, 360);//D

                        mypen.Color = ColorLib.colorP0;
                        mygra.DrawArc(mypen, new Rectangle(new Point(p0.X - 3, p0.Y - 3), new Size(6, 6)), 0, 360);//P

                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        mybm.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        pictureBox1.BackgroundImage = Image.FromStream(ms);
                        //ctureBox1.Refresh();
                        evenSizeChanged = true;

                        //bool rb= SetRatio(ratioSta - 5);
                        //return rb;
                    }
                    else
                    {
                        Console.WriteLine("调整" + ratioSta);

                        evenSizeChanged = false;
                        //bool rb = SetRatio(ratioSta + 5);

                        //return rb;

                        this.Size = new Size(this.Size.Width + 10, this.Size.Height + 10);
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
                MessageBox.Show(ex.Message);
                this.Close();
                return false;
            }
        }



        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="p0"></param>
        /// <param name="ratio"></param>
        /// <param name="wp1"></param>
        /// <param name="wp2"></param>
        /// <param name="wp3"></param>
        /// <param name="wp4"></param>
        public void DiplayPoint(Pointz p1, Pointz p2, Pointz p3, Pointz p4, Pointz p0, double ratio,
            int wp1, int wp2, int wp3, int wp4)
        {
            DiplayPoint(p1, p2, p3, p4, p0, ratio,
             wp1, wp2, wp3, wp4, false);
        }

        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="p0"></param>
        /// <param name="ratio"></param>
        /// <param name="wp1"></param>
        /// <param name="wp2"></param>
        /// <param name="wp3"></param>
        /// <param name="wp4"></param>
        /// <param name="autoThumb">p点</param>
        public void DiplayPoint(Pointz p1, Pointz p2, Pointz p3, Pointz p4, Pointz p0, double ratio,
            int wp1, int wp2, int wp3, int wp4, bool autoThumb)
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

                pointzw1 = wp1;
                pointzw2 = wp2;
                pointzw3 = wp3;
                pointzw4 = wp4;

                double r = GetMaxRatic(ratio);

                //ratioSta = GetRatio(); 
                setvalue = true;
                SetRatio(r);


                //ShowPoint();
            }

        }



        double maxangle = 0;
        delegate bool DLGShowPoint();
        DLGShowPoint dlgShowPoint;
        /// <summary>
        /// 绘制并显示图形
        /// </summary>
        bool ShowPoint()
        {
            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke(dlgShowPoint, null);
                return true;
            }
            else
            {
                if (setvalue)
                {

                    //Pointz maxradiusPointz = GetMaxRadius(out maxRadius);
                    //double tanValue = Math.Abs(maxradiusPointz.Y) / Math.Abs(maxradiusPointz.X);
                    //double myangle = Math.Atan(tanValue) / (Math.PI / 180);



                    double angle = GetRotateAngle();
                    //maxangle = myangle - angle;
                    //double cosvalue = Math.Cos((myangle - angle) * Math.PI / 180);
                    //;
                    //double sinvalue = Math.Sin((myangle - angle) * Math.PI / 180);
                    //w2 = (maxRadius / ratioSta) * cosvalue * 2;
                    //h2 = (maxRadius / ratioSta) * sinvalue * 2;
                    //double minplane = GetShowPlaneMinRadius();

                    //double maxRadius = GetMaxRadius();

                    //ratioSta = maxRadius / minplane;
                    //ratioSta = 500;
                    //int ooo = 0;

                    maxratiosta = GetMaxRatic(ratioSta);

                    myps = CreateDrawPlanePoint(mygra, mypen, pointzSta1, pointzSta2, pointzSta3, pointzSta4,
                        pointzSta0, ratioSta, pointzw1, pointzw2, pointzw3, pointzw4);



                    return RotateTras(myps[0], myps[1], myps[2], myps[3],
                         myps[4], -angle, myps[5], myps[6], myps[7], myps[8]);

                }
                else
                {
                    return false;
                }
            }
        }

        double GetMaxRatic(double rat)
        {
            Pointz maxradiusPointz = GetMaxRadius(out maxRadius);
            if (maxradiusPointz != null)
            {
                double tanValue = Math.Abs(maxradiusPointz.Y) / Math.Abs(maxradiusPointz.X);
                double myangle = Math.Atan(tanValue) / (Math.PI / 180);



                double angle = GetRotateAngle();
                maxangle = myangle - angle;
                double cosvalue = Math.Cos((myangle - angle) * Math.PI / 180);

                double sinvalue = Math.Sin((myangle - angle) * Math.PI / 180);
                return GetMaxRatic(rat, cosvalue, sinvalue);
            }
            else
            {
                return 0;
            }
        }

        double maxratiosta = 0;
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
            double minsize = Math.Min(pictureBox1.Width, pictureBox1.Height);
            if (maxnum < minsize)
            {
                //可以继续放大
                return GetMaxRatic(re, cos, sin);
            }
            return re + 15;
        }

        /// <summary>
        /// 设置缩放比例
        /// </summary>
        /// <param name="ratio"></param>
        public bool SetRatio(double ratio)
        {
            if (ratio == 0)
                return false;

            ratioSta = ratio;

            return ShowPoint();
        }

        /// <summary>
        /// 旋转角度
        /// </summary>
        /// <param name="rotate"></param>
        public void SetRotateAngle(double rotate)
        {
            evenSizeChanged = false;
            OffsetRotate = rotate;
            ratioSta = GetMaxRatic(ratioSta);

            ShowPoint();
        }

        /// <summary>
        /// 是否执行窗体大小变化事件
        /// </summary>
        bool evenSizeChanged = true;
        int oldWidth = 0;
        int oldHeight = 0;
        private void FormViewPlane_SizeChanged(object sender, EventArgs e)
        {
            if (evenSizeChanged)
            {
                Console.WriteLine("大小");
                ReInitialGraphice();
                //ratioSta = GetRatio();
                ratioSta = GetMaxRatic(ratioSta);

                ShowPoint();
            }
        }

        /// <summary>
        /// 计算能适应屏幕的缩放比例
        /// </summary>
        /// <returns></returns>
        double GetRatio()
        {
            double maxRadius = GetMaxRadius();
            double minplane = GetShowPlaneMinRadius();

            return maxRadius / minplane;
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

        }

        District newDistrict;

        private void 新建区域ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {


                if (新建区域ToolStripMenuItem.Checked)
                {
                    editDistrict = true;
                    newDistrict = new District();//创建一个新区域
                    Districts.Add(newDistrict);//将区域添加到集合中
                    
                }
                else
                {
                    editDistrict = false;
                    if (newDistrict != null)
                    {
                        newDistrict.EndEdit = true;
                    }
                    newDistrict = null;
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

                if (editDistrict && newDistrict != null)
                {
                    Point2d p = new Point2d(DownX, DownY);
                    p.BaseX = basePoint.X;
                    p.BaseY = basePoint.Y;
                    p.Ratio = ratioSta;

                  Point2d p2 =  ConvertPointToPoint2d(DownX, DownY); 

                    newDistrict.Add(p2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        Point2d ConvertPointToPoint2d(int x, int y)
        {
            Point2d p2d;
            double c = Math.Sqrt(Math.Pow(x - basePoint.X, 2) + Math.Pow(y - basePoint.Y, 2));//求点与坐标原点的距离
            double rotate = GetRotateAngle();
            double nx = Math.Tan(rotate) * c;
            double ny = Math.Sin(rotate) * c;

            p2d = new Point2d((int)nx,(int)ny);
            return p2d;
        }
    }
}
