using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CWTrack
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            
        }
        int maxValue = 10;
        /// <summary>
        /// 最大值
        /// </summary>
        public int MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }
        int minValue = 0;
        /// <summary>
        /// 最小值
        /// </summary>
        public int MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }

        bool towWay = false;
        /// <summary>
        /// 是否是双向刻度
        /// </summary>
        public bool TowWay
        {
            get { return towWay; }
            set { 
                towWay = value;
                UserControl1_SizeChanged(null, null);
            }
        }


        List<TrackItem> trackItems = new List<TrackItem>();
        /// <summary>
        /// 滑块集合
        /// </summary>
        internal List<TrackItem> TrackItems
        {
            get { return trackItems; }
            set { trackItems = value; }
        }
        /// <summary>
        /// 背景色绘制对象
        /// </summary>
        Graphics gBack;
        /// <summary>
        /// 背景图
        /// </summary>
        Bitmap bmBack;
        /// <summary>
        /// 前景绘制对象
        /// </summary>
        Graphics gFront;
        /// <summary>
        /// 前景图
        /// </summary>
        Bitmap bmFront;
        /// <summary>
        /// 绘制前景画笔
        /// </summary>
        Pen penFront;

        Color colFront;
        /// <summary>
        /// 初始对象
        /// </summary>
        void Initial()
        {
            pictureBoxShow.Location = new Point(pictureBoxTrack1.Width / 2, pictureBoxTrack1.Height);
            pictureBoxShow.Width = panel1.Width - pictureBoxTrack1.Width - 1;


            bmBack = new Bitmap(maxValue, 1);//背景色绘制彩色
            gBack = Graphics.FromImage(bmBack);
            bmFront = new Bitmap(pictureBoxShow.Width, pictureBoxShow.Height);//刻度
            gFront = Graphics.FromImage(bmFront);
            colFront = Color.Red;
            penFront = new Pen(new SolidBrush(colFront),2);

            //pictureBoxShow.BackgroundImage = bmBack;

            TrackItemCreate();//创建一个滑块
        }

        /// <summary>
        /// 创建一个滑块并添加在最后位置
        /// </summary>
        void TrackItemCreate()
        {
            TrackItem ti1 = new TrackItem();
            ti1.PicBox = pictureBoxTrack1;
            trackItems.Add(ti1);
        }

        /// <summary>
        /// 移除最后一个滑块 至少保留一个
        /// </summary>
        bool TrackItemRemoveLast()
        {
            if (trackItems.Count - 1 > 1)
            {
                trackItems.RemoveAt(trackItems.Count - 1);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 移除指定位置滑块
        /// </summary>
        /// <param name="index"></param>
        bool TrackItemRemoveAt(int index)
        {
            if (index > -1 && trackItems.Count > 0)
            {
                trackItems.RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 绘制背景
        /// </summary>
        void DrawBack()
        {

        }

        /// <summary>
        /// 绘制前景
        /// </summary>
        void DrawFront(int maxvalue, bool towway)
        {
            //获得当前可显示范围的宽的像素
            int widthpix = pictureBoxShow.Width;
            
            int onevaluewidth = 0;//一个值的像素宽度
            if (towway)
            {
                onevaluewidth = widthpix / (maxvalue  * 2);
            }
            else
            {
                onevaluewidth = widthpix / maxvalue;
            }

            //刻度水平的起始和终结点
            Point pStart =new Point(0, pictureBoxShow.Height * 2 / 3);
            Point pEnd = new Point(pictureBoxShow.Width, pictureBoxShow.Height * 2 / 3);
            //绘制刻度水平
            gFront.DrawLine(penFront, pStart, pEnd);

            int countpix = -1;
            while (countpix < widthpix)
            {
                Point pScaleUp = new Point(countpix,5);//刻度上点
                Point pScaleDown = new Point(countpix, pictureBoxShow.Height * 2 / 3);//刻度下点


                gFront.DrawLine(penFront, pScaleUp, pScaleDown);
                countpix += onevaluewidth;
            }

            pictureBoxShow.Image = bmFront;
        }

        /// <summary>
        /// 获取图片对应的滑块
        /// </summary>
        /// <param name="picbox"></param>
        /// <returns></returns>
        TrackItem GetTrackByPicBox(PictureBox picbox)
        {
            return trackItems.Find(delegate(TrackItem ti)
             {
                 if (ti.PicBox == picbox)
                 {
                     return true;
                 }
                 else
                 {
                     return false;
                 }
             }
                 );
        }

        /// <summary>
        /// 记录鼠标是否在图片上按下
        /// </summary>
        bool mouseDown = false;
        int mouseDX = 0;
        int mouseDY = 0;
        private void pictureBoxTrack1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            PictureBox pc = (PictureBox)sender;
            mouseDX = e.X;
            mouseDY = e.Y;
            //Point p= PointToClient(new Point(e.X, e.Y));
            //mouseDX = e.X;
            //mouseDY = e.Y;
            TrackItem ti = GetTrackByPicBox(pc);
            //textBox1.Text = mouseDX + " " + mouseDY;
        }

        private void pictureBoxTrack1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                PictureBox pc = (PictureBox)sender;
                int nx = pc.Location.X + e.X - mouseDX;
                if (nx >= 0 && nx < panel1.Width - pc.Width)
                {
                    pc.Location = new Point(nx, 0);
                }
                //pc.Location = e.Y - mouseDY;
                //textBox2.Text = pc.Location.X + " " + pc.Location.Y;
                //textBox2.Text = e.X + " " +e.Y;
            }
        }

        private void pictureBoxTrack1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            Initial();
            DrawFront(maxValue, TowWay);
        }

        private void UserControl1_SizeChanged(object sender, EventArgs e)
        {
            if (TowWay)
            {
                int mod = pictureBoxShow.Width % (maxValue*2);
                if (mod > 0)
                {
                    this.Size = new Size(this.Size.Width - 1, this.Size.Height);
                }
            }
            else
            {
                int mod = pictureBoxShow.Width % maxValue;
                if (mod > 0)
                {
                    this.Size = new Size(this.Size.Width - 1, this.Size.Height);
                }
            }
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
                //int mod= pictureBoxShow.Width % maxValue;
                //if (mod > 0)
                //{
                //    this.Size = new Size(this.Size.Width-1,this.Size.Height);
                //}
                pictureBoxShow.Width = panel1.Width - pictureBoxTrack1.Width - 1;
        }
    }
}
