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
    public partial class FormViewPlane2 : FormView
    {

        Graphics mygra;
        Bitmap mybm;

        Pen mypen;

        int picToFormWidth = 0;

        int picToFormHeight = 0;

        /// <summary>
        /// 自定义区域集合
        /// </summary>
        List<District> Districts = new List<District>();

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
        double showRatio = 1;


        

        ///// <summary>
        ///// 原点
        ///// </summary>
        public FormViewPlane2()
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
            initialed = true;
        }
        void ReInitialGraphice()
        {
            initialed = false;
            mybm.Dispose();
            mybm = new Bitmap(pictureBox1.Width, pictureBox1.Height);//画板
            mygra = Graphics.FromImage(mybm);
            initialed = true;
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
        public new void Show()
        {
            base.Show();
            Initial();

            picToFormWidth = this.Width - pictureBox1.Width;
            picToFormHeight = this.Height - pictureBox1.Height;
        }

        private void FormViewPlane_Load(object sender, EventArgs e)
        {
            //Initial();
            //this.Text = pictureBox1.Width + " " + pictureBox1.Height;
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
            set
            {
                newRotateAngle = value;
                isratio = true;
            }
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
        /// 将自然坐标系的点转换到绘制坐标系
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        Point ConvertToDrawCoord(Point p)
        {
            Point rp = new Point();
            rp.X = p.X;
            rp.Y = -p.Y;

            return rp;
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

        //double maxratic = 1;
        /// <summary>
        /// 表示当前正在旋转
        /// </summary>
        bool isratio = false;
        public void Draw(Pointz pA, Pointz pB, Pointz pC, Pointz pD, Pointz p0, double ratic)
        {

            pointzSta1 = pA;
            pointzSta2 = pB;
            pointzSta3 = pC;
            pointzSta4 = pD;
            pointzSta0 = p0;

            mygra.ResetTransform();


            //获得实际旋转角 =偏转角+期望旋转角
            //newRotateAngle = 15;
            double toRotate = 180 + GetRotateAngle(pA, pB) + newRotateAngle;

            //将实际点坐标变成平面坐标
            Point pa = ConvertToDrawCoord(new Point((int)pA.X, (int)pA.Y));
            Point pb = ConvertToDrawCoord(new Point((int)pB.X, (int)pB.Y));
            Point pc = ConvertToDrawCoord(new Point((int)pC.X, (int)pC.Y));
            Point pd = ConvertToDrawCoord(new Point((int)pD.X, (int)pD.Y));
            Point p_0 = ConvertToDrawCoord(new Point((int)p0.X, (int)p0.Y));

            //输出旋转后的点坐标
            Point opa = new Point();
            Point opb = new Point();
            Point opc = new Point();
            Point opd = new Point();
            Point op_0 = new Point();
            //将点沿坐标原点旋转指定的角度
            GetGetRotatePoints(pa, pb, pc, pd, p_0, toRotate, out opa, out opb, out opc, out opd, out op_0);

            //计算将要绘制的图片所使用最小矩形大小
            Point bp;
            Size recsize = GetMinDrawRectangleSize(opa, opb, opc, opd, out bp);



            //平移各点
            offsetBasePoint = bp;
            psa = ConvertBasePoint(opa, offsetBasePoint);
            psb = ConvertBasePoint(opb, offsetBasePoint);
            psc = ConvertBasePoint(opc, offsetBasePoint);
            psd = ConvertBasePoint(opd, offsetBasePoint);
            ps0 = ConvertBasePoint(op_0, offsetBasePoint);

            int newpicWidth = 0;
            int newpicHeight = 0;
            double newmaxratic = GetMaxRatic(recsize, showRatio, out newpicWidth, out newpicHeight);
            showRatio = newmaxratic;
            if (newpicWidth != 0 && newpicHeight != 0)
            {
                this.Size = new Size(newpicWidth + picToFormWidth + 10, newpicHeight + picToFormHeight + 10);

                //ReDraw();
                return;
            }
            else if (newpicWidth != 0 && newpicHeight == 0)
            {
                this.Size = new Size(newpicWidth + picToFormWidth + 10, this.Height);

                //ReDraw();
                return;

            }
            else if (newpicWidth == 0 && newpicHeight != 0)
            {
                this.Size = new Size(newpicHeight + picToFormHeight + 10, this.Width);

                //ReDraw();
                return;
            }
            psa.X = (int)((double)psa.X / showRatio);
            psb.X = (int)((double)psb.X / showRatio);
            psc.X = (int)((double)psc.X / showRatio);
            psd.X = (int)((double)psd.X / showRatio);
            ps0.X = (int)((double)ps0.X / showRatio);
            psa.Y = (int)((double)psa.Y / showRatio);
            psb.Y = (int)((double)psb.Y / showRatio);
            psc.Y = (int)((double)psc.Y / showRatio);
            psd.Y = (int)((double)psd.Y / showRatio);
            ps0.Y = (int)((double)ps0.Y / showRatio);

            Drawer(psa, psb, psc, psd, ps0);
        }

        /// <summary>
        /// 获取当前图片框容纳绘制所需最小矩形，矩形需要缩放的最大比例
        /// </summary>
        /// <param name="minDrawRectangleSize"></param>
        /// <returns></returns>
        double GetDrawMaxRatio(Size minDrawRectangleSize)
        {
            //判断当前宽高大小 已最小值为参考进行缩放
            return 0;
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

                    //绘制原点
                    //mypen.Color = ColorLib.colorSky;
                    //mygra.DrawArc(mypen, new Rectangle(new Point(0, 0), new Size(6, 6)), 0, 360);

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


                    mypen.Color = ColorLib.warning;
                    mygra.DrawPolygon(mypen, new Point[] { pA, pB, pC, pD });


                    mypen.Color = ColorLib.colorPN;
                    mygra.DrawLine(mypen, p0, pA);
                    mygra.DrawLine(mypen, p0, pB);
                    mygra.DrawLine(mypen, p0, pC);
                    mygra.DrawLine(mypen, p0, pD);//连线


                    //绘制区域
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
                                    ps[i].X = (int)(p2ds[i].X / showRatio);
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
                                int drawp2dx = (int)(p2d.X / showRatio);
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


        /// <summary>
        /// 获取绘制这些点所需要的最小矩形面积（绘制原点在图形中心） 并输出偏移坐标原点
        /// </summary>
        /// <param name="ps"></param>
        /// <returns></returns>
        Size GetMinDrawRectangleSize(Point pa, Point pb, Point pc, Point pd, out Point offsetPoint)
        {
            //找出坐标中 x轴最大的点 和y轴最大的点

            int maxX = 0;
            int maxY = 0;
            if (pa.X > maxX)
                maxX = pa.X;
            if (pb.X > maxX)
                maxX = pb.X;
            if (pc.X > maxX)
                maxX = pc.X;
            if (pd.X > maxX)
                maxX = pd.X;

            if (pa.Y > maxY)
                maxY = pa.Y;
            if (pb.Y > maxY)
                maxY = pb.Y;
            if (pc.Y > maxY)
                maxY = pc.Y;
            if (pd.Y > maxY)
                maxY = pd.Y;

            int minX = 0;
            int minY = 0;
            if (pa.X < minX)
                minX = pa.X;
            if (pb.X < minX)
                minX = pb.X;
            if (pc.X < minX)
                minX = pc.X;
            if (pd.X < minX)
                minX = pd.X;

            if (pa.Y < minY)
                minY = pa.Y;
            if (pb.Y < minY)
                minY = pb.Y;
            if (pc.Y < minY)
                minY = pc.Y;
            if (pd.Y < minY)
                minY = pd.Y;

            Size re = new Size(Math.Abs(maxX) + Math.Abs(minX) + 10, Math.Abs(maxY) + Math.Abs(minY) + 10);

            offsetPoint = new Point(Math.Abs(minX) + 5, Math.Abs(minY) + 5);
            return re;
        }


        /// <summary>
        /// 获取最大可缩放比例
        /// </summary>
        /// <param name="recSize"></param>
        /// <returns></returns>
        double GetMaxRatic(Size recSize, double oldRatic, out int newWidth, out int newHeight)
        {
            double returnRatic = 0;
            int recWidth = 0;
            int recHeight = 0;
            if (oldRatic != 1)
            {
                recWidth = (int)((double)recSize.Width / oldRatic);
                recHeight = (int)((double)recSize.Height / oldRatic);
            }
            else
            {
                recWidth = recSize.Width;
                recHeight = recSize.Height;
            }
            int picWidth = pictureBox1.Width;
            int picHeight = pictureBox1.Height;
            newWidth = 0;
            newHeight = 0;
            if (recWidth > picWidth)
            {
                if (recHeight > picHeight)
                {
                    //完全大于可见范围

                    //先按宽缩小比例 如果按此比例缩小高 高能在可见范围高内 则按宽缩小比例
                    //如果按宽缩小比例不能使高在可见范文 则按高缩小比例

                    if (oldRatic == 1)
                    {
                        double raticWidth = (double)recWidth / (double)picWidth;
                        double smallHeight = (double)recHeight / (double)raticWidth;
                        if (smallHeight < picHeight)
                        {
                            returnRatic = raticWidth;
                        }
                        else
                        {
                            double raticHeight = (double)recHeight / (double)picHeight;
                            returnRatic = raticHeight;
                        }
                    }
                    else
                    {
                        if (isratio)
                        {
                            newWidth = recWidth;
                            newHeight = recHeight;
                            returnRatic = oldRatic;

                            isratio = false;
                        }
                    }
                }
                else
                {
                    //比可见范围宽但低于可见范围

                    //按宽缩小比例
                    double raticWidth = (double)recSize.Width / (double)picWidth;
                    if (isratio)
                    {
                        newWidth = recWidth;
                        newHeight = 0;
                        isratio = false;
                    }
                    else
                    {
                        returnRatic = raticWidth;
                    }

                }
            }
            else
            {
                if (recHeight > picHeight)
                {
                    //比可见范围窄但高于可见范围

                    //按高缩小比例
                    double raticHeight = (double)recSize.Height / (double)picHeight;

                    if (isratio)
                    {
                        newWidth = 0;
                        newHeight = recHeight;
                        returnRatic = oldRatic;
                        isratio = false;
                    }
                    else
                    {
                        returnRatic = raticHeight;
                    }



                }
                else
                {
                    //完全小于可见范围

                    //先按宽放大比例 如果高按宽放大的比例放大后也在可见范围内 则按宽放大比例
                    //如果按宽放大后 高不在可见范围 则按高放大比例
                    double raticWidth = (double)recSize.Width / (double)picWidth;
                    double bigHeight = (double)recSize.Height / (double)raticWidth;
                    if ((int)bigHeight > picHeight)
                    {
                        double raticHeight = (double)recSize.Height / (double)picHeight;

                        if (isratio)
                        {
                            returnRatic = oldRatic;

                            newWidth = recWidth;

                            newHeight = recHeight;
                            isratio = false;
                        }
                        else
                        {
                            returnRatic = raticHeight;
                        }
                    }
                    else
                    {

                        if (isratio)
                        {
                            returnRatic = oldRatic;
                            if (recWidth + 10 < picWidth)
                            {
                                newWidth = recWidth;
                            }
                            if (recHeight + 10 < picHeight)
                            {
                                newHeight = recHeight;
                            }
                            isratio = false;
                        }
                        else
                        {
                            returnRatic = raticWidth;
                        }
                    }


                }


            }

            return returnRatic;
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




        private void FormViewPlane_Resize(object sender, EventArgs e)
        {

        }


        private void 删除区域ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                deleteDistrict = 删除区域ToolStripMenuItem.Checked;
                if (删除区域ToolStripMenuItem.Checked)
                {

                }
                else
                {

                }
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
                else if (deleteDistrict)
                {
                    //计算相对绘图原地的坐标点
                    int bpx = DownX - basePoint.X;
                    int bpy = DownY - basePoint.Y;

                    //乘上比例 得出实际大小坐标
                    int bpx2 = (int)(bpx * showRatio);
                    int bpy2 = (int)(bpy * showRatio);

                    Point p0 = new Point(-bpx, bpy);

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
            this.Text = pictureBox1.Width + "," + pictureBox1.Height;
            //showRatic = GetMaxRatic(showRatic);
        }
    }
}
