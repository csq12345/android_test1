using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPCOperate;
using Mod;
using SeePoint;
using System.Diagnostics;

namespace WindowsOPC
{
    public partial class FormMain : Form
    {
        public FormViewPlane2 frmPlane;
        public FormViewFontOrSide1 frm_font1;
        public FormViewFontOrSide1 frm_side1;
        //public FormViewFontOrSide frm_Font;
        //public FormViewFontOrSide frm_Side;
        //public FormViewSide frmSide;

        public FormStatusMotorTorque frmTorque;
        public FormPlaceCoordinates frmCoordinates;
        public FormMotorActivation frmActivation;
        public FormInitil1 frmInitil1;
        public FormDollyStartPositionCalculate frmDSPCalculate;
        public FormDollyCoordinate frmDCoordinate;
        public FormProgramSetting frmPSetting;
        public FormStatusStation frmSStation;
        public FormStatusControl frmSControl;
        public FormOtherControl frmOControl;
        public SeePoint.FormRotate frmRotate;
        public FormCalibration frmCalibration;

        FormReplay frmReplay;
        FormREC frmREC;

        OPCOperate.VariableClass myVariable = OPCOperate.VariableClass.VariableClass_();
        OPCOperate.AsyMotorControlOperate amco = new OPCOperate.AsyMotorControlOperate();

        #region 当前站点和云台的坐标
        double xP = 0;
        double yP = 0;
        double zP = 0;

        double xA = 0;
        double yA = 0;
        double zA = 0;

        double xB = 0;
        double yB = 0;
        double zB = 0;

        double xC = 0;
        double yC = 0;
        double zC = 0;

        double xD = 0;
        double yD = 0;
        double zD = 0;

        #endregion

        /// <summary>
        /// 初始化设置完成步骤
        /// </summary>
        public static int initilStep = 0;


        /// <summary>
        /// 缩放比例
        /// </summary>
        public double ratio = 1000;

        public FormMain fm;

        public FormMain()
        {
            InitializeComponent();
            fm = this;

            myVariable.PointXYZUpdate += new VariableClass.PointXYZUpdateEventHandler(myVariable_PointXYZUpdate);
        }

        int count = 0;
        void myVariable_PointXYZUpdate(object sender, MyOPC.FlyCat_PointXYZ data)
        {
            if (asySendREC != null)
            {
                asySendREC.BeginInvoke(data, null, null);
            }
            //坐标变动
            xP = data.PXCoor;
            yP = data.PYCoor;
            zP = data.PZCoor;

            xA = data.AXCoor;
            yA = data.AYCoor;
            zA = data.AZCoor;

            xB = data.BXCoor;
            yB = data.BYCoor;
            zB = data.BZCoor;

            xC = data.CXCoor;
            yC = data.CYCoor;
            zC = data.CZCoor;

            xD = data.DXCoor;
            yD = data.DYCoor;
            zD = data.DZCoor;

        }

        public delegate void AsySendREC(MyOPC.FlyCat_PointXYZ data);
        public AsySendREC asySendREC;
        private void 禁用电机ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 系统状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 电机力矩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTorque == null || frmTorque.IsDisposed)
            {
                FormStatusMotorTorque f = new FormStatusMotorTorque();
                f.MdiParent = this;
                frmTorque = f;
                f.Show();
            }
            else
            {
                frmTorque.Activate();
            }
        }

        private void 空间坐标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmCoordinates == null || frmCoordinates.IsDisposed)
            {
                FormPlaceCoordinates f = new FormPlaceCoordinates();
                f.MdiParent = this;
                frmCoordinates = f;
                f.Show();
            }
            else
            {
                frmCoordinates.Activate();
            }
        }

        private void 正面ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                //if (frm_Font == null || frm_Font.IsDisposed)
                //{
                //    FormViewFontOrSide f = new FormViewFontOrSide("正面");
                //    f.MdiParent = this;
                //    frm_Font = f;
                //    f.Show();
                //}
                //else
                //{
                //    frm_Side.Activate();
                //}

                if (frm_font1 == null || frm_font1.IsDisposed)
                {
                    frm_font1 = new FormViewFontOrSide1("正面");
                    frm_font1.MdiParent = this;
                    frm_font1.Show();

                }
                else
                {
                    frm_font1.Activate();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void 侧面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (frm_Side == null || frm_Side.IsDisposed)
                //{
                //    FormViewFontOrSide f = new FormViewFontOrSide("侧面");
                //    f.MdiParent = this;
                //    f.Addangle = -90;
                //    frm_Side = f;
                //    f.Show();
                //}
                //else
                //{
                //    frm_Side.Activate();
                //}

                if (frm_side1 == null || frm_side1.IsDisposed)
                {
                    frm_side1 = new FormViewFontOrSide1("侧面");
                    frm_side1.MdiParent = this;
                    frm_side1.Show();
                    frm_side1.Addangle = -90;

                }
                else
                {
                    frm_side1.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void 平面ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (frmPlane == null || frmPlane.IsDisposed)
                {
                    frmPlane = new FormViewPlane2();
                    frmPlane.MdiParent = this;
                    frmPlane.Show();

                }
                else
                {
                    frmPlane.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void 电机激活ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 激活电机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmActivation == null || frmActivation.IsDisposed)
            {
                FormMotorActivation f = new FormMotorActivation();
                f.MdiParent = this;
                frmActivation = f;
                f.Show();
            }
            else
            {
                frmActivation.Activate();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 空间边界ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmInitil1 == null || frmInitil1.IsDisposed)
            {
                FormInitil1 f = new FormInitil1();
                f.MdiParent = this;
                frmInitil1 = f;
                f.Show();
            }
            else
            {
                frmInitil1.Activate();
            }
        }

        private void 摄像机起始点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDSPCalculate == null || frmDSPCalculate.IsDisposed)
            {
                FormDollyStartPositionCalculate f = new FormDollyStartPositionCalculate();
                f.MdiParent = this;
                frmDSPCalculate = f;
                f.ShowDialog();
            }
            else
            {
                frmDSPCalculate.Activate();
            }
        }

        private void 摄像机坐标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDCoordinate == null || frmDCoordinate.IsDisposed)
            {
                FormDollyCoordinate f = new FormDollyCoordinate();
                f.MdiParent = this;
                frmDCoordinate = f;
                f.Show();
            }
            else
            {
                frmDCoordinate.Activate();
            }

        }

        private void 程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmPSetting == null || frmPSetting.IsDisposed)
            {
                FormProgramSetting f = new FormProgramSetting();
                f.MdiParent = this;
                frmPSetting = f;
                f.Show();
            }
            else
            {
                frmPSetting.Activate();
            }
        }

        private void 连接服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!OPCOperate.MyOPCObject.IsConnected())
                {
                    OPCOperate.MyOPCObject.Connection();
                }

                if (OPCOperate.MyOPCObject.IsConnected())
                {
                    连接服务ToolStripMenuItem.Enabled = false;
                    toolStripButton1.Enabled = false;
                    toolStripStatusLabel1.ForeColor = Color.Green;
                    toolStripStatusLabel1.Text = "服务器已连接";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接服务：" + ex.Message + " " + ex.StackTrace, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOPCTest f = new FormOPCTest();
            f.MdiParent = this;
            f.Show();
        }

        private void 缩放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(this);
            f.MdiParent = this;
            f.Show();
        }

        private void 排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 电机状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSStation == null || frmSStation.IsDisposed)
            {
                FormStatusStation f = new FormStatusStation();
                f.MdiParent = this;
                frmSStation = f;
                f.Show();
            }
            else
            {
                frmSStation.Activate();
            }
        }

        private void 控制状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSControl == null || frmSControl.IsDisposed)
            {
                FormStatusControl f = new FormStatusControl();
                f.MdiParent = this;
                frmSControl = f;
                f.Show();
            }
            else
            {
                frmSControl.Activate();
            }
        }

        private void 控制器1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 可用安全回路ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // public static string hmi_ack = "D435.hmi_ack";//	67	上位机故障复位按钮		BOOL	上位机操作（画面上）
            amco.FaultReset = true;
        }

        private void 录制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmREC == null || frmREC.IsDisposed)
            {
                FormREC f = new FormREC(200);
                f.MdiParent = this;
                frmREC = f;
                this.asySendREC = new AsySendREC(f.myVariable_PointXYZUpdate);
                f.Show();
            }
            else
            {
                frmREC.Activate();
            }
        }

        private void timerDraw_Tick(object sender, EventArgs e)
        {
            //定时取保存下来的云台坐标值 时间间隔小于数据的刷新间隔
            Pointz pa = new Pointz((int)xA, (int)yA, (int)zA);
            Pointz pb = new Pointz((int)xB, (int)yB, (int)zB);
            Pointz pc = new Pointz((int)xC, (int)yC, (int)zC);
            Pointz pd = new Pointz((int)xD, (int)yD, (int)zD);
            Pointz pp = new Pointz((int)xP, (int)yP, (int)zP);

            DisplayPoint(pa, pb, pc, pd, pp);
        }

        /// <summary>
        /// 全站仪高度
        /// </summary>
        double hostHeight = 0;

        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="pa"></param>
        /// <param name="pb"></param>
        /// <param name="pc"></param>
        /// <param name="pd"></param>
        /// <param name="pp"></param>
        void DisplayPoint(Pointz pa, Pointz pb, Pointz pc, Pointz pd, Pointz pp)
        {
            try
            {
                if ((pa.X == 0 && pa.Y == 0 && pa.Z == 0)
                    || (pb.X == 0 && pb.Y == 0 && pb.Z == 0)
                    || (pc.X == 0 && pc.Y == 0 && pc.Z == 0)
                    || (pd.X == 0 && pd.Y == 0 && pd.Z == 0))
                {
                }
                else
                {
                    if (hostHeight == 0)
                    {
                        hostHeight = amco.ConfigAllHeight;
                    }


                    Pointz pA = new Pointz();
                    pA.X = pa.X;
                    pA.Y = pa.Y;
                    pA.Z = pa.Z+hostHeight;
                    Pointz pB = new Pointz();
                    pB.X = pb.X;
                    pB.Y = pb.Y;
                    pB.Z = pb.Z + hostHeight;
                    Pointz pC = new Pointz();
                    pC.X = pc.X;
                    pC.Y = pc.Y;
                    pC.Z = pc.Z + hostHeight;
                    Pointz pD = new Pointz();
                    pD.X = pd.X;
                    pD.Y = pd.Y;
                    pD.Z = pd.Z + hostHeight;
                    Pointz pP = new Pointz();
                    pP.X = pp.X;
                    pP.Y = pp.Y;
                    pP.Z = pp.Z + hostHeight;



                    if (frm_side1 != null && frm_side1.IsDisposed == false)
                    {
                        frm_side1.Draw(pA, pB, pC, pD, pP, ratio);
                    }
                    if (frmPlane != null && frmPlane.IsDisposed == false)
                    {
                        frmPlane.Draw(pA, pB, pC, pD, pP, ratio);
                    }
                    if (frm_font1 != null && frm_font1.IsDisposed==false)
                    {
                        frm_font1.Draw(pA, pB, pC, pD, pP, ratio);
                    }

                }
            }
            catch
            {
                this.Text = "123";
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            timerDraw.Start();//开始绘制图片
            控制状态ToolStripMenuItem_Click(sender, e);

            平面ToolStripMenuItem_Click(sender, e);
            正面ToolStripMenuItem_Click(sender, e);
            //缩放ToolStripMenuItem_Click(sender, e);
            侧面ToolStripMenuItem_Click(sender, e);

            frm_font1.Location = new Point(360, 0);
            frmPlane.Location = new Point(360, 200);
            frm_side1.Location = new Point(670, 200);
            frmSControl.Location = new Point(0, 0);
        }

        private void 其他控制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmOControl == null || frmOControl.IsDisposed)
            {
                FormOtherControl f = new FormOtherControl();
                f.MdiParent = this;
                frmOControl = f;
                f.Show();
            }
            else
            {
                frmOControl.Activate();
            }
        }

        private void 旋转ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (frmRotate == null || frmRotate.IsDisposed)
            {
                SeePoint.FormRotate f = new FormRotate();
                f.MdiParent = this;
                frmRotate = f;
                f.Show();
            }
            else
            {
                frmRotate.Activate();
            }
        }

        private void 电位器校准ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmCalibration == null || frmCalibration.IsDisposed)
            {
                FormCalibration f = new FormCalibration();
                f.MdiParent = this;
                frmCalibration = f;
                f.Show();
            }
            else
            {
                frmCalibration.Activate();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            连接服务ToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            控制状态ToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            空间边界ToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            正面ToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            侧面ToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            平面ToolStripMenuItem_Click(sender, e);
        }

        private void 回放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmReplay == null || frmReplay.IsDisposed)
            {
                FormReplay f = new FormReplay();
                f.MdiParent = this;
                frmReplay = f;
                f.Show();
            }
        }

        private void 电机控制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process p = new Process();
                string path = AppDomain.CurrentDomain.BaseDirectory + "Speed.exe";
                if (System.IO.File.Exists(path))
                {
                    p.StartInfo = new ProcessStartInfo(path);
                    p.Start();
                }
                else
                {
                    MessageBox.Show("未找到 " + path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        FormStatusControl1 f;
        private void 控制状态1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (f == null || f.IsDisposed)
                {
                    f = new FormStatusControl1();
                    f.MdiParent = this;
                    f.Show();
                }
                else
                {
                    f.Activate();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

    }
}
