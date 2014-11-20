using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SeePoint;
using OPCOperate;

namespace WindowsOPC
{
    public partial class FormReplay : Form
    {
        SeePoint.REC rec = new SeePoint.REC(200);
        AsyMotorControlOperate amco = new AsyMotorControlOperate();
        AsyMotorDisplayPoint amdp = new AsyMotorDisplayPoint();
        AsyMotorInitValue amiv = new AsyMotorInitValue();
        public FormReplay()
        {
            InitializeComponent();

            ShowProcess += new ShowProcessEventHandler(FormReplay_ShowProcess);
            dlgshowProgressBar = new DLGShowProgressBar(ShowProgress);

            //刷新回放状态
            timer2.Start();
        }

        void FormReplay_ShowProcess(int value)
        {
            dlgshowProgressBar(value);
        }
        RECSpace[] recSpaces = null;

        /// <summary>
        /// 回放计数
        /// </summary>
        int replayCount = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;

                recSpaces = rec.Load(filename);
                if (rec != null)
                {
                    button2.Enabled = true;
                }
            }
        }
        bool isRun = false;

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (!isRun)
                {
                    if (recSpaces != null)
                    {
                        int t = 0;
                        Int32.TryParse(textBox1.Text, out t);
                        timer1.Interval = t;
                        replayCount = 0;
                        progressBar1.Maximum = recSpaces.Length;
                        timer1.Start();
                        button2.Text = "停止";
                        button3.Enabled = true;
                        isRun = true;
                    }
                }
                else
                {
                    button2.Text = "回放";
                    isRun = false;
                    timer1.Stop();
                    button3.Enabled = false;
                    isContinu = true;
                    button3.Text = "暂停";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                if (isContinu)
                {
                    if (replayCount < recSpaces.Length)
                    {
                        RECSpace rec = recSpaces[replayCount];
                        amco.ReplayDnPaceX = rec.DollypointItem.X;

                        amco.ReplayDnPaceY = rec.DollypointItem.Y;

                        amco.ReplayDnPaceZ = rec.DollypointItem.Z;

                        ShowProcessEvent(replayCount);
                        replayCount++;
                    }
                    else
                    {
                        timer1.Stop();
                        button3.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                timer1.Stop();
                MessageBox.Show(ex.Message);
            }

        }


        public event ShowProcessEventHandler ShowProcess;
        public delegate void ShowProcessEventHandler(int value);

        void ShowProcessEvent(int value)
        {
            if (ShowProcess != null)
            {
                ShowProcess.BeginInvoke(value, new AsyncCallback(ShowProcessBar), ShowProcess);
            }
        }
        void ShowProcessBar(IAsyncResult ias)
        {
            ShowProcessEventHandler sp = (ShowProcessEventHandler)ias.AsyncState;




        }
        delegate void DLGShowProgressBar(int value);

        DLGShowProgressBar dlgshowProgressBar;

        void ShowProgress(int value)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(dlgshowProgressBar, new object[] { value });

            }
            else
            {
                progressBar1.Value = value;
            }
        }
        /// <summary>
        /// 是否继续下一条
        /// </summary>
        bool isContinu = true;
        private void button3_Click(object sender, EventArgs e)
        {
            if (isContinu)
            {
                isContinu = false;
                button3.Text = "继续";
            }
            else
            {
                isContinu = true;
                button3.Text = "暂停";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //OPCOperate.AsyMotorControlOperate asycontrol = new OPCOperate.AsyMotorControlOperate();

            amco.ReplayState = true;//选择回放状态
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //OPCOperate.AsyMotorControlOperate asycontrol = new OPCOperate.AsyMotorControlOperate();
            //asycontrol.BackPlayInitPoint = true;//参考点回零
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //OPCOperate.AsyMotorControlOperate asycontrol = new OPCOperate.AsyMotorControlOperate();
            bool bl = Convert.ToBoolean(label3.Text);
            if (bl)
            {
                amco.BackPlayInitPoint = false;//关闭回参考点
            }
            else
            {
                amco.BackPlayInitPoint = true;//关闭回参考点
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //OPCOperate.AsyMotorControlOperate asycontrol = new OPCOperate.AsyMotorControlOperate();
            amco.ReplayStart = true;//回放开始
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //OPCOperate.AsyMotorControlOperate asycontrol = new OPCOperate.AsyMotorControlOperate();
            userControlRGY1.SetStatu(amco.ReplayState);//回放功能状态
            userControlRGY2.SetStatu(amco.BackPlayInitPointComplete);//回初始点完成状态
            userControlRGY3.SetStatu(amco.BackPlayInitPoint);//回初始点状态
            userControlRGY4.SetStatu(amco.ReplayStart);//回放开始状态

            label1.Text = Convert.ToString(amco.ReplayState);
            label2.Text = Convert.ToString(amco.BackPlayInitPointComplete);
            label3.Text = Convert.ToString(amco.BackPlayInitPoint);
            label4.Text = Convert.ToString(amco.ReplayStart);

            //周期读云台初始坐标和当前坐标
            labelytInitX.Text = String.Format("{0:N3}",amiv.PInitX);
            labelytInitY.Text = String.Format("{0:N3}", amiv.PInitY);
            labelytInitZ.Text = String.Format("{0:N3}", amiv.PInitZ);

            labelytCurX.Text = String.Format("{0:N3}", amdp.PXPoint);
            labelytCurY.Text = String.Format("{0:N3}", amdp.PYPoint);
            labelytCurZ.Text = String.Format("{0:N3}", amdp.PZPoint);

            if (!checkBox_xiugai.Checked)
            {
                textBoxhlconfigX.Text = amco.ReplayOriginX.ToString();
                textBoxhlconfigY.Text = amco.ReplayOriginY.ToString();
                textBoxhlconfigZ.Text = amco.ReplayOriginZ.ToString();
                textBoxhlconfigV.Text = amco.ReplayOriginPace.ToString();
            }
        }

        delegate void ContolUpdate(Control l, object o);
        ContolUpdate labeldisplay;

        void LUpdate(Control l, object o)
        {
            if (!l.IsHandleCreated)
            {
                return;
            }

            if (l.InvokeRequired)
            {
                if (l.IsHandleCreated)
                {
                    l.Invoke(labeldisplay, new object[] { l, o });
                }
            }
            else
            {
                if (o.GetType() == typeof(string))
                {
                    l.Text = o.ToString();
                }
                else if (o.GetType() == typeof(bool))
                {
                    l.Enabled = Convert.ToBoolean(o);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //首先选择回放功能，再设置云台回参考点，查看回参考点是否完成，然后点击关闭回参考点，最后操作回放开始。

            button4.Enabled = false;
            labeldisplay = new ContolUpdate(LUpdate);

            System.Threading.Thread updowndata = new System.Threading.Thread(new System.Threading.ThreadStart(updowndatathread));
            updowndata.Start();

        }

        public void updowndatathread()
        {
            try
            {
                string RecDataX;
                string RecDataY;
                string RecDataZ;
                //创建流
                System.IO.FileStream fsr = new System.IO.FileStream("D:\\录制文件_XYZ.txt", System.IO.FileMode.Open);
                System.IO.StreamReader sr = new System.IO.StreamReader(fsr);

                //读出
                string str = string.Empty;

                str = sr.ReadLine();
                RecDataX = str;
                str = sr.ReadLine();
                RecDataY = str;
                str = sr.ReadLine();
                RecDataZ = str;

                //清空缓冲区、关闭流
                sr.Close();
                fsr.Close();

                //写入下位机
                //清零当前组数
                amco.ReadRecDataGroupCount = 0;
                //清除加载完成标志
                amco.RecUpdateCompleted = false;

                int count = 0;
                while (true)
                {
                    System.Threading.Thread.Sleep(5);
                    count++;
                    if (amco.ReadRecDataGroupCount == 0 || count > 100)
                    {
                        break;
                    }
                }

                if (count > 100)
                {
                    LUpdate(button4, true);
                    //线程挂起
                    return;
                }

                int groupcount = amco.RecDataGroupNum;
                int groupnum = amco.ReadRecDataGroupCount;

                //groupcount = 33;
                //groupnum = 0;
                for (int i = 0; i < groupcount; i++)
                {
                    //写入一组数据到临时变量区
                    int num;

                    str = string.Empty;
                    for (int j = 0; j < 101; j++)
                    {
                        num = RecDataX.IndexOf(',');
                        if (num <= 0)
                        {
                            str += RecDataX;
                            RecDataX = string.Empty;
                            break;
                        }
                        if (j < 100)
                        {
                            str += RecDataX.Substring(0, num + 1);
                        }
                        else
                        {
                            str += RecDataX.Substring(0, num);
                        }
                        RecDataX = RecDataX.Substring(num + 1);
                    }
                    amco.ArrRecXData = str;

                    str = string.Empty;
                    for (int j = 0; j < 101; j++)
                    {
                        num = RecDataY.IndexOf(',');
                        if (num <= 0)
                        {
                            str += RecDataY;
                            RecDataY = string.Empty;
                            break;
                        }
                        if (j < 100)
                        {
                            str += RecDataY.Substring(0, num + 1);
                        }
                        else
                        {
                            str += RecDataY.Substring(0, num);
                        }
                        RecDataY = RecDataY.Substring(num + 1);
                    }
                    amco.ArrRecYData = str;

                    str = string.Empty;
                    for (int j = 0; j < 101; j++)
                    {
                        num = RecDataZ.IndexOf(',');
                        if (num <= 0)
                        {
                            str += RecDataZ;
                            RecDataZ = string.Empty;
                            break;
                        }
                        if (j < 100)
                        {
                            str += RecDataZ.Substring(0, num + 1);
                        }
                        else
                        {
                            str += RecDataZ.Substring(0, num);
                        }
                        RecDataZ = RecDataZ.Substring(num + 1);
                    }
                    amco.ArrRecZData = str;

                    System.Threading.Thread.Sleep(200);

                    //开始
                    amco.WriteRecPointStart = true;

                    count = 0;
                    while ((groupnum == amco.ReadRecDataGroupCount) && count < 100)
                    {
                        System.Threading.Thread.Sleep(10);
                        count++;
                    }
                    groupnum = amco.ReadRecDataGroupCount;

                    count = 0;
                    while (amco.WriteRecPointStart && count < 100)
                    {
                        System.Threading.Thread.Sleep(10);
                        count++;
                    }
                    groupcount = amco.RecDataGroupNum;

                    //groupnum++;
                }

                //线程挂起
                System.Threading.Thread.Sleep(1000);
                LUpdate(button4, true);

            }
            catch (Exception ex)
            {
                LUpdate(button4, true);
                MessageBox.Show("写入数据:" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            amco.ReplayState = false;
            amco.BackPlayInitPoint = false;
            amco.ReplayStart = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (checkBox_xiugai.Checked)
            {
                double x = 0;
                double.TryParse(textBoxhlconfigX.Text, out x);
                amco.ReplayOriginX = x;

                double y = 0;
                double.TryParse(textBoxhlconfigY.Text, out y);
                amco.ReplayOriginY = y;

                double z = 0;
                double.TryParse(textBoxhlconfigZ.Text, out z);
                amco.ReplayOriginZ = z;

                double v = 0;
                double.TryParse(textBoxhlconfigV.Text, out v);
                amco.ReplayOriginPace = v;

                checkBox_xiugai.Checked = false;
                button10.Enabled = false;
            }

        }

        private void checkBox_xiugai_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_xiugai.Checked)
            {
                button10.Enabled = true;
            }
            else
            {
                button10.Enabled = false;
            }
        }

    }
}
