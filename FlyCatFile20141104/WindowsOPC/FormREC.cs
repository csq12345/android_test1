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
    public partial class FormREC : Form
    {
        /// <summary>
        /// 录制时长 单位ms
        /// </summary>
        double timelenght = 0;
        /// <summary>
        /// 时间片间隔 单位ms
        /// </summary>
        double timespan = 200;

        REC rec;

        OPCOperate.VariableClass myVariable = OPCOperate.VariableClass.VariableClass_();
        OPCOperate.AsyMotorControlOperate asycontrol = new OPCOperate.AsyMotorControlOperate();
        /// <summary>
        /// 是否录制
        /// </summary>
        bool run = false;
        public FormREC(int span)
        {
            InitializeComponent();
            timespan = span;
            rec = new REC(span);
            myVariable.PointXYZUpdate += new OPCOperate.VariableClass.PointXYZUpdateEventHandler(myVariable_PointXYZUpdate);
            dlgShowTime = new DLGShowTime(ShowTime);

            timer2.Start();

            string path = AppDomain.CurrentDomain.BaseDirectory + "Data";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.SelectedPath = path;

            comboBoxLJ.Items.Clear();
            comboBoxLJ.Items.Add(folderBrowserDialog1.SelectedPath);
            if (comboBoxLJ.Items.Count > 0)
            {
                comboBoxLJ.SelectedIndex = 0;
            }
        }


        public void myVariable_PointXYZUpdate(object sender, OPCOperate.MyOPC.FlyCat_PointXYZ data)
        {
            //接收坐标变更事件
            if (run)
            {
                if (rec != null)
                {
                    rec.AddSpace(data.JLXCoor, data.JLYCoor, data.JLZCoor);
                    timelenght += timespan;
                    dlgShowTime(timelenght);
                }
            }
        }

        /// <summary>
        /// 由主窗体注册的事件调用该方法
        /// </summary>
        /// <param name="data"></param>
        public void myVariable_PointXYZUpdate(OPCOperate.MyOPC.FlyCat_PointXYZ data)
        {
            //接收坐标变更事件
            if (run)
            {
                if (rec != null)
                {
                    rec.AddSpace(data.PXCoor, data.PYCoor, data.PZCoor);
                    timelenght += timespan;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timelenght = 0;
            run = true;
            button1.Enabled = false;
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            run = false;
            button1.Enabled = true;
            button3.Enabled = true;
        }


        delegate void DLGShowTime(double t);
        DLGShowTime dlgShowTime;
        /// <summary>
        /// 显示时间
        /// </summary>
        /// <param name="t"></param>
        void ShowTime(double t)
        {
            if (label2.InvokeRequired)
            {
                label2.Invoke(dlgShowTime, new object[] { t });
            }
            else
            {
                label2.Text = t.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (DialogResult.OK == saveFileDialog1.ShowDialog())
                {
                    string filename = saveFileDialog1.FileName;
                    rec.Save(filename);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = rec.GetSpaceCount().ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //设置是否启用
            if (checkBox1.Checked)
            {
                //设置录制时间
                asycontrol.RecTime = Convert.ToInt32(textBox1.Text);

                checkBox1.Checked = false;
                button5.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //启动录制按钮
            //OPCOperate.AsyMotorControlOperate asycontrol = new OPCOperate.AsyMotorControlOperate();
            asycontrol.RecStart = true;
            button6.Enabled = false;
            timer1.Start();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                button5.Enabled = false;
            }
            else
            {
                button5.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(10);
            if (!asycontrol.RecStart)
            {
                button6.Enabled = true;
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                label7.Text = Convert.ToString(asycontrol.RecPointCount);//录制长度，下位根据设置时间计算得出
                userControlRGY1.SetStatu(asycontrol.ReadRecPointStart);//设置录制开始状态
                label8.Text = Convert.ToString(asycontrol.ReadRecPointStart);//读取录制开始状态
                label9.Text = Convert.ToString(asycontrol.ReadRecDataGroupCount);//读取录制的当前组数
                label10.Text = Convert.ToString(asycontrol.RecDataGroupNum);//录制的总组数

                if (!checkBox1.Checked)
                {
                    //设置录制时间
                    textBox1.Text = asycontrol.RecTime.ToString();
                }
            }
            catch
            {


            }

        }

        string strx = string.Empty;
        string stry = string.Empty;
        string strz = string.Empty;
        private void button7_Click(object sender, EventArgs e)
        {
            strx = asycontrol.ArrRecXData;
            stry = asycontrol.ArrRecYData;
            strz = asycontrol.ArrRecZData;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //加载一组数据到临时变量区
            asycontrol.ReadRecPointStart = true;
        }

        string SaveLzpath;
        private void button9_Click(object sender, EventArgs e)
        {
            if (comboBoxLJ.Text.Trim() == "")
            {
                MessageBox.Show("请选择数据的保存路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            button9.Enabled = false;

            labeldisplay = new ContolUpdate(LUpdate);

            ControlReadText = new ContolRead(ReadText);

            //保存路径
            if (comboBoxLJ.Text.Trim() != "")
            {
                SaveLzpath = comboBoxLJ.Text.Trim() + "\\";
            }
            else
            {
                SaveLzpath = "D:\\";
            }

            if (textBoxFileName.Text.Trim() != "")
            {
                SaveLzpath = SaveLzpath + textBoxFileName.Text.Trim();
            }
            else
            {
                SaveLzpath = SaveLzpath + "录制文件_XYZ";
            }

            System.Threading.Thread downloaddata = new System.Threading.Thread(new System.Threading.ThreadStart(loaddatathread));
            downloaddata.Start();
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

        delegate string ContolRead(Control l);
        ContolRead ControlReadText;

        string ReadText(Control l)
        {
            if (!l.IsHandleCreated)
            {
                return "";
            }

            if (l.InvokeRequired)
            {
                if (l.IsHandleCreated)
                {
                    return l.Invoke(labeldisplay, l).ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return l.Text;
                
            }
        }

        StringBuilder RecDataX;
        StringBuilder RecDataY;
        StringBuilder RecDataZ;
        public void loaddatathread()
        {
            try
            {
                //清零当前组数
                asycontrol.ReadRecDataGroupCount = 0;
                //清除加载完成标志
                asycontrol.RecUpdateCompleted = false;

                //label8.Text = Convert.ToString(asycontrol.ReadRecPointStart);//读取录制开始状态
                //label9.Text = Convert.ToString(asycontrol.ReadRecDataGroupCount);//读取录制的当前组数
                //label10.Text = Convert.ToString(asycontrol.RecDataGroupNum);//录制的总组数

                LUpdate(label8, Convert.ToString(asycontrol.ReadRecPointStart));
                LUpdate(label9, Convert.ToString(asycontrol.ReadRecDataGroupCount));
                LUpdate(label10, Convert.ToString(asycontrol.RecDataGroupNum));

                int count = 0;
                while (true)
                {
                    System.Threading.Thread.Sleep(5);
                    count++;
                    if (asycontrol.ReadRecDataGroupCount == 0 || count > 100)
                    {
                        break;
                    }
                }

                if (count > 100)
                {
                    LUpdate(button9, true);
                    //线程挂起
                    return;
                }

                int groupcount = asycontrol.RecDataGroupNum;
                int groupnum = asycontrol.ReadRecDataGroupCount;

                RecDataX = new StringBuilder();
                RecDataY = new StringBuilder();
                RecDataZ = new StringBuilder();

                for (int i = 0; i < groupcount; i++)
                {
                    //加载一组数据到临时变量区
                    asycontrol.ReadRecPointStart = true;
                    count = 0;
                    while ((groupnum == asycontrol.ReadRecDataGroupCount) && count < 100)
                    {
                        System.Threading.Thread.Sleep(10);
                        count++;
                    }
                    groupnum = asycontrol.ReadRecDataGroupCount;

                    count = 0;
                    while (asycontrol.ReadRecPointStart && count < 100)
                    {
                        System.Threading.Thread.Sleep(10);
                        count++;
                    }

                    System.Threading.Thread.Sleep(200);

                    RecDataX.Append(asycontrol.ArrRecXData.Trim());
                    RecDataY.Append(asycontrol.ArrRecYData.Trim());
                    RecDataZ.Append(asycontrol.ArrRecZData.Trim());

                    if (i < groupcount - 1)
                    {
                        RecDataX.Append(",");
                        RecDataY.Append(",");
                        RecDataZ.Append(",");
                    }
                    groupcount = asycontrol.RecDataGroupNum;

                    LUpdate(label11, i.ToString());
                }

                //保存
                SaveLzpath = SaveLzpath + "(" + DateTime.Now.ToString("yyyy_MM_dd HH_mm_ss") + ")";
                string strclass = ".txt";

                //创建流
                StringBuilder str1 = new StringBuilder(); ;
                str1.Append(RecDataX);
                str1.Append("\r\n");
                str1.Append(RecDataY);
                str1.Append("\r\n");
                str1.Append(RecDataZ);
                str1.Append("\r\n");

                System.IO.FileStream fs = new System.IO.FileStream(SaveLzpath + strclass, System.IO.FileMode.Create);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);

                //写入
                sw.Write(str1);

                //清空缓冲区、关闭流
                sw.Flush();
                sw.Close();
                fs.Close();


                //线程挂起
                System.Threading.Thread.Sleep(1000);
                LUpdate(button9, true);
                //GC.Collect();

            }
            catch (Exception ex)
            {
                LUpdate(button9, true);
                MessageBox.Show("读取数据:" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonLJ_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    comboBoxLJ.Items.Clear();
                    comboBoxLJ.Items.Add(folderBrowserDialog1.SelectedPath);
                    if (comboBoxLJ.Items.Count > 0)
                    {
                        comboBoxLJ.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        } 

    }
}
