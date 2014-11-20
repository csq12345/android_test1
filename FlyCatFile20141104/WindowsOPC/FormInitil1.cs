using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPCOperate;
using System.IO;

namespace WindowsOPC
{
    public partial class FormInitil1 : Form
    {
        OPCOperate.AsyMotorControlOperate amco = new OPCOperate.AsyMotorControlOperate();

        OPCOperate.AsyMotorInitValue amiv = new OPCOperate.AsyMotorInitValue();

        OPCOperate.AsyMotorTwoInitValue amtiv = new OPCOperate.AsyMotorTwoInitValue();

        public FormInitil1()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 重置测量2
        /// </summary>
        void ResetRadioCheck2()
        {

            radioButton4_4.Checked = false;
            radioButton4_3.Checked = false;
            radioButton4_2.Checked = false;
        }
        private void radioButton3_1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3_1.Checked)
            {
                groupBoxValue3.Text = "滑轮1";

                textBoxValueHorizontal3.Text = amtiv.TwoALevel.ToString();
                textBoxValueVertical3.Text = amtiv.TwoAUp.ToString();
                textBoxValueLenght3.Text = amtiv.TwoASpace.ToString();
            }
        }

        private void radioButton3_2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton4_2.Enabled = !radioButton3_2.Checked;
            ResetRadioCheck2();
            if (radioButton3_2.Checked)
            {
                groupBoxValue3.Text = "滑轮2";

                textBoxValueHorizontal3.Text = amtiv.TwoBLevel.ToString();
                textBoxValueVertical3.Text = amtiv.TwoBUp.ToString();
                textBoxValueLenght3.Text = amtiv.TwoBSpace.ToString();
            }
        }

        private void radioButton3_3_CheckedChanged(object sender, EventArgs e)
        {
            radioButton4_2.Enabled = radioButton4_3.Enabled = !radioButton3_3.Checked;
            ResetRadioCheck2();
            if (radioButton3_3.Checked)
            {
                groupBoxValue3.Text = "滑轮3";

                textBoxValueHorizontal3.Text = amtiv.TwoCLevel.ToString();
                textBoxValueVertical3.Text = amtiv.TwoCUp.ToString();
                textBoxValueLenght3.Text = amtiv.TwoCSpace.ToString();
            }
        }

        private void buttonSubmit1_Click(object sender, EventArgs e)
        {
            //全站仪

            //高度
            double ah = 0;
            Double.TryParse(textBoxlong_a_gaodu.Text, out ah);
            amco.ConfigAHeight = ah;

            double bh = 0;
            Double.TryParse(textBoxlong_b_gaodu.Text, out bh);
            amco.ConfigBHeight = bh;

            double ch = 0;
            Double.TryParse(textBoxlong_c_gaodu.Text, out ch);
            amco.ConfigCHeight = ch;

            double dh = 0;
            Double.TryParse(textBoxlong_d_gaodu.Text, out dh);
            amco.ConfigDHeight = dh;


            //水平宽度
            double abw = 0;
            Double.TryParse(textBoxlong_ab_kuandu.Text, out abw);
            amco.ConfigABWidth = abw;

            double bcw = 0;
            Double.TryParse(textBoxlong_bc_kuandu.Text, out bcw);
            amco.ConfigBCWidth = bcw;

            double cdw = 0;
            Double.TryParse(textBoxlong_cd_kuandu.Text, out cdw);
            amco.ConfigCDWidth = cdw;

            double daw = 0;
            Double.TryParse(textBoxlong_da_kuandu.Text, out daw);
            amco.ConfigDAWidth = daw;


            //全站仪高度
            double hh = 0;
            Double.TryParse(textBoxlong_quanzhanyigaodu.Text, out hh);
            amco.ConfigAllHeight = hh;

        }

        private void buttonSubmit3_Click(object sender, EventArgs e)
        {
            //投影
            double ab = 0;
            Double.TryParse(textBoxpc_p_ab.Text, out ab);
            amiv.PSpaceAB = ab;

            double bc = 0;
            Double.TryParse(textBoxpc_p_bc.Text, out bc);
            amiv.PSpaceBC = bc;

            double cd = 0;
            Double.TryParse(textBoxpc_p_cd.Text, out cd);
            amiv.PSpaceCD = cd;

            double da = 0;
            Double.TryParse(textBoxpc_p_da.Text, out da);
            amiv.PSpaceAD = da;

            double minz = 0;
            Double.TryParse(textBoxsys_zmin.Text, out minz);
            amiv.ConfineZ = minz;

        }


        void SetInitilStep(int step)
        {
            if (FormMain.initilStep < step)
            {
                FormMain.initilStep = step;
            }
        }

        bool GetInitilStep(int step)
        {
            if (step <= FormMain.initilStep)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void buttonSubmit2_Click(object sender, EventArgs e)
        {
            SetInitilStep(1);

            //测量

            //水平角
            double ahor = 0;
            Double.TryParse(textBoxspaj.Text, out ahor);
            amiv.ALevel = ahor;
            double bhor = 0;
            Double.TryParse(textBoxspbj.Text, out bhor);
            amiv.BLevel = bhor;
            double chor = 0;
            Double.TryParse(textBoxspcj.Text, out chor);
            amiv.CLevel = chor;
            double dhor = 0;
            Double.TryParse(textBoxspdj.Text, out dhor);
            amiv.DLevel = dhor;

            double phor = 0;
            Double.TryParse(textBoxsppj.Text, out phor);
            amiv.PLevel = phor;

            //垂直角
            double aver = 0;
            Double.TryParse(textBoxyangaj.Text, out aver);
            amiv.AUp = aver;
            double bver = 0;
            Double.TryParse(textBoxyangbj.Text, out bver);
            amiv.BUp = bver;
            double cver = 0;
            Double.TryParse(textBoxyangcj.Text, out cver);
            amiv.CUp = cver;
            double dver = 0;
            Double.TryParse(textBoxyangdj.Text, out dver);
            amiv.DUp = dver;

            double pver = 0;
            Double.TryParse(textBoxyangpj.Text, out pver);
            amiv.PUp = pver;


            //距离
            double al = 0;
            Double.TryParse(textBoxlonga.Text, out al);
            amiv.ASpace = al;
            double bl = 0;
            Double.TryParse(textBoxlongb.Text, out bl);
            amiv.BSpace = bl;
            double cl = 0;
            Double.TryParse(textBoxlongc.Text, out cl);
            amiv.CSpace = cl;
            double dl = 0;
            Double.TryParse(textBoxlongd.Text, out dl);
            amiv.DSpace = dl;

            double pl = 0;
            Double.TryParse(textBoxlongp.Text, out pl);
            amiv.PSpace = pl;

        }

        private void buttonSubmit4_Click(object sender, EventArgs e)
        {
            //二次测量
            if ((radioButton3_1.Checked || radioButton3_2.Checked || radioButton3_3.Checked) &&
                (radioButton4_2.Checked || radioButton4_3.Checked || radioButton4_4.Checked))
            {
                //第一站点
                if (radioButton3_1.Checked)
                {
                    double ahor = 0;
                    Double.TryParse(textBoxValueHorizontal3.Text, out ahor);
                    amtiv.TwoALevel = ahor;

                    double aver = 0;
                    Double.TryParse(textBoxValueVertical3.Text, out aver);
                    amtiv.TwoAUp = aver;

                    double al = 0;
                    Double.TryParse(textBoxValueLenght3.Text, out al);
                    amtiv.TwoASpace = al;
                }
                if (radioButton3_2.Checked)
                {
                    double bhor = 0;
                    Double.TryParse(textBoxValueHorizontal3.Text, out bhor);
                    amtiv.TwoBLevel = bhor;

                    double bver = 0;
                    Double.TryParse(textBoxValueVertical3.Text, out bver);
                    amtiv.TwoBUp = bver;

                    double bl = 0;
                    Double.TryParse(textBoxValueLenght3.Text, out bl);
                    amtiv.TwoBSpace = bl;
                }
                if (radioButton3_3.Checked)
                {
                    double chor = 0;
                    Double.TryParse(textBoxValueHorizontal3.Text, out chor);
                    amtiv.TwoCLevel = chor;

                    double cver = 0;
                    Double.TryParse(textBoxValueVertical3.Text, out cver);
                    amtiv.TwoCUp = cver;

                    double cl = 0;
                    Double.TryParse(textBoxValueLenght3.Text, out cl);
                    amtiv.TwoCSpace = cl;
                }

                //第二站点
                if (radioButton4_2.Checked)
                {
                    double bhor = 0;
                    Double.TryParse(textBoxValueHorizontal4.Text, out bhor);
                    amtiv.TwoBLevel = bhor;

                    double bver = 0;
                    Double.TryParse(textBoxValueVertical4.Text, out bver);
                    amtiv.TwoBUp = bver;

                    double bl = 0;
                    Double.TryParse(textBoxValueLenght4.Text, out bl);
                    amtiv.TwoBSpace = bl;
                }
                if (radioButton4_3.Checked)
                {
                    double chor = 0;
                    Double.TryParse(textBoxValueHorizontal4.Text, out chor);
                    amtiv.TwoCLevel = chor;

                    double cver = 0;
                    Double.TryParse(textBoxValueVertical4.Text, out cver);
                    amtiv.TwoCUp = cver;

                    double cl = 0;
                    Double.TryParse(textBoxValueLenght4.Text, out cl);
                    amtiv.TwoCSpace = cl;
                }
                if (radioButton4_4.Checked)
                {
                    double dhor = 0;
                    Double.TryParse(textBoxValueHorizontal4.Text, out dhor);
                    amtiv.TwoDLevel = dhor;

                    double dver = 0;
                    Double.TryParse(textBoxValueVertical4.Text, out dver);
                    amtiv.TwoDUp = dver;

                    double dl = 0;
                    Double.TryParse(textBoxValueLenght4.Text, out dl);
                    amtiv.TwoDSpace = dl;
                }

                //云台
                double sppj = 0;
                Double.TryParse(textBoxsppj.Text, out sppj);
                amiv.PLevel = sppj;
                double yangpj = 0;
                Double.TryParse(textBoxyangpj.Text, out yangpj);
                amiv.PUp = yangpj;
                double ongp = 0;
                Double.TryParse(textBoxlongp.Text, out ongp);
                amiv.PSpace = ongp;


                //云台二次测量
                double phor = 0;
                Double.TryParse(textBoxValueHorizontalp1.Text, out phor);
                amtiv.TwoPLevel = phor;
                double pver = 0;
                Double.TryParse(textBoxValueVerticalp1.Text, out pver);
                amtiv.TwoPUp = pver;
                double pl = 0;
                Double.TryParse(textBoxValueLenghtp1.Text, out pl);
                amtiv.TwoPSpace = pl;



                //p点在原坐标位置
                double px = 0;
                Double.TryParse(textBoxxp1.Text, out px);
                amtiv.TwoPxValue = px;


            }
        }

        private void radioButton4_2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4_2.Checked)
            {
                groupBoxValue4.Text = "滑轮2";

                textBoxValueHorizontal4.Text = amtiv.TwoBLevel.ToString();
                textBoxValueVertical4.Text = amtiv.TwoBUp.ToString();
                textBoxValueLenght4.Text = amtiv.TwoBSpace.ToString();

                if (radioButton3_1.Checked)
                {
                    amco.ConfigTwoMotorSelect = 0;//选择1和2
                }

            }
        }

        private void radioButton4_3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4_3.Checked)
            {
                groupBoxValue4.Text = "滑轮3";

                textBoxValueHorizontal4.Text = amtiv.TwoCLevel.ToString();
                textBoxValueVertical4.Text = amtiv.TwoCUp.ToString();
                textBoxValueLenght4.Text = amtiv.TwoCSpace.ToString();

                if (radioButton3_1.Checked)
                {
                    //amco.ConfigTwoMotorSelect = 0;//选择1和2 暂未定义
                }
                if (radioButton3_2.Checked)
                {
                    amco.ConfigTwoMotorSelect = 1;//选择2和3
                }

            }
        }

        private void radioButton4_4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4_4.Checked)
            {
                groupBoxValue4.Text = "滑轮4";

                textBoxValueHorizontal4.Text = amtiv.TwoDLevel.ToString();
                textBoxValueVertical4.Text = amtiv.TwoDUp.ToString();
                textBoxValueLenght4.Text = amtiv.TwoDSpace.ToString();

                if (radioButton3_1.Checked)
                {
                    amco.ConfigTwoMotorSelect = 3;//选择1和4
                }
                if (radioButton3_2.Checked)
                {
                    //amco.ConfigTwoMotorSelect = 1;//选择2和4 暂未定义
                }
                if (radioButton3_3.Checked)
                {
                    amco.ConfigTwoMotorSelect = 2;//选择3和4
                }
            }
        }

        private void checkBoxpc_homing_CheckedChanged(object sender, EventArgs e)
        {
            //amtiv.TwoResetSwitch = checkBoxpc_homing.Checked;//上位机回零开关


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //水平角
            //textBox1_1.Text = amiv.ALevel.ToString();
            //textBox1_2.Text = amiv.AUp.ToString();
            //textBox1_3.Text = amiv.ASpace.ToString();
        }

        private void FormInitil1_Load(object sender, EventArgs e)
        {
            Read1();
        }

        /// <summary>
        /// 初始测量
        /// </summary>
        void Read1()
        {
            //测量

            //水平角
            textBoxspaj.Text = amiv.ALevel.ToString();
            textBoxspbj.Text = amiv.BLevel.ToString();
            textBoxspcj.Text = amiv.CLevel.ToString();
            textBoxspdj.Text = amiv.DLevel.ToString();

            textBoxsppj.Text = amiv.PLevel.ToString();

            //垂直角
            textBoxyangaj.Text = amiv.AUp.ToString();
            textBoxyangbj.Text = amiv.BUp.ToString();

            textBoxyangcj.Text = amiv.CUp.ToString();
            textBoxyangdj.Text = amiv.DUp.ToString();
            textBoxyangpj.Text = amiv.PUp.ToString();


            //距离
            textBoxlonga.Text = amiv.ASpace.ToString();
            textBoxlongb.Text = amiv.BSpace.ToString();
            textBoxlongc.Text = amiv.CSpace.ToString();
            textBoxlongd.Text = amiv.DSpace.ToString();

            textBoxlongp.Text = amiv.PSpace.ToString();

            //全站仪高度
            textBoxlong_quanzhanyigaodu.Text = amco.ConfigAllHeight.ToString();
        }

        /// <summary>
        /// 边界设置
        /// 
        /// </summary>
        void Read2()
        {

            //高度
            textBoxlong_a_gaodu.Text = amco.ConfigAHeight.ToString();
            textBoxlong_b_gaodu.Text = amco.ConfigBHeight.ToString();
            textBoxlong_c_gaodu.Text = amco.ConfigCHeight.ToString();
            textBoxlong_d_gaodu.Text = amco.ConfigDHeight.ToString();

            //宽度
            textBoxlong_ab_kuandu.Text = amco.ConfigABWidth.ToString();
            textBoxlong_bc_kuandu.Text = amco.ConfigBCWidth.ToString();
            textBoxlong_cd_kuandu.Text = amco.ConfigCDWidth.ToString();
            textBoxlong_da_kuandu.Text = amco.ConfigDAWidth.ToString();



            textBoxpc_p_ab.Text = amiv.PSpaceAB.ToString();
            textBoxpc_p_bc.Text = amiv.PSpaceBC.ToString();
            textBoxpc_p_cd.Text = amiv.PSpaceCD.ToString();
            textBoxpc_p_da.Text = amiv.PSpaceAD.ToString();

            textBoxsys_jiajiaojiaodu.Text = amiv.ConfineHJJZ.ToString();
            textBoxsys_zmin.Text = amiv.ConfineZ.ToString();
        }

        /// <summary>
        /// 投影
        /// </summary>
        void Read3()
        {

            textBoxsys_zmin.Text = amiv.ConfineZ.ToString();
            textBoxpc_p_ab.Text = amiv.PSpaceAB.ToString();
            textBoxpc_p_bc.Text = amiv.PSpaceBC.ToString();
            textBoxpc_p_cd.Text = amiv.PSpaceCD.ToString();
            textBoxpc_p_da.Text = amiv.PSpaceAD.ToString();

        }

        /// <summary>
        /// 二次测量
        /// </summary>
        void Read4()
        {
            if (radioButton3_1.Checked)
            {
                textBoxValueHorizontal3.Text = amtiv.TwoALevel.ToString();
                textBoxValueVertical3.Text = amtiv.TwoAUp.ToString();
                textBoxValueLenght3.Text = amtiv.TwoASpace.ToString();
            }

            if (radioButton3_2.Checked)
            {
                textBoxValueHorizontal3.Text = amtiv.TwoBLevel.ToString();
                textBoxValueVertical3.Text = amtiv.TwoBUp.ToString();
                textBoxValueLenght3.Text = amtiv.TwoBSpace.ToString();
            }

            if (radioButton3_3.Checked)
            {
                textBoxValueHorizontal3.Text = amtiv.TwoCLevel.ToString();
                textBoxValueVertical3.Text = amtiv.TwoCUp.ToString();
                textBoxValueLenght3.Text = amtiv.TwoCSpace.ToString();

            }

            //第二站点
            if (radioButton4_2.Checked)
            {
                textBoxValueHorizontal4.Text = amtiv.TwoBLevel.ToString();
                textBoxValueVertical4.Text = amtiv.TwoBUp.ToString();
                textBoxValueLenght4.Text = amtiv.TwoBSpace.ToString();
            }
            if (radioButton4_3.Checked)
            {
                textBoxValueHorizontal4.Text = amtiv.TwoDLevel.ToString();
                textBoxValueVertical4.Text = amtiv.TwoCUp.ToString();
                textBoxValueLenght4.Text = amtiv.TwoCSpace.ToString();

            }
            if (radioButton4_4.Checked)
            {
                textBoxValueHorizontal4.Text = amtiv.TwoDLevel.ToString();
                textBoxValueVertical4.Text = amtiv.TwoDUp.ToString();
                textBoxValueLenght4.Text = amtiv.TwoDSpace.ToString();
            }

            //云台
            textBoxsppj.Text = amiv.PLevel.ToString();
            textBoxyangpj.Text = amiv.PUp.ToString();
            textBoxlongp.Text = amiv.PSpace.ToString();
            //云台二次测量
            textBoxValueHorizontalp1.Text = amtiv.TwoPLevel.ToString();
            textBoxValueVerticalp1.Text = amtiv.TwoPUp.ToString();
            textBoxValueLenghtp1.Text = amtiv.TwoPSpace.ToString();
            //p点在原坐标位置
            textBoxxp1.Text = amtiv.TwoPxValue.ToString();

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPage.Text)
            {
                case "初始测量":
                    {
                        if (GetInitilStep(0))
                        {
                            panelOne.Enabled = true;
                            //SetPanelControlsEnable(panelOne, false);
                            Read1();
                        }
                        else
                        {
                            panelOne.Enabled = false;
                            //SetPanelControlsEnable(panelOne, true);
                        }

                        timer1.Stop();
                    }
                    break;
                case "边界设置":
                    {
                        if (GetInitilStep(1))
                        {
                            panelTow.Enabled = true;
                            //SetPanelControlsEnable(panelTow, false);
                            Read2();
                        }
                        else
                        {
                            panelTow.Enabled = false;
                            //SetPanelControlsEnable(panelTow, true);
                        }

                        timer1.Stop();
                    }
                    break;
                case "二次测量":
                    {
                        if (GetInitilStep(2))
                        {
                            panelThree.Enabled = true;
                            //SetPanelControlsEnable(panelThree, false);
                            Read4();
                        }
                        else
                        {
                            panelThree.Enabled = false;
                            //SetPanelControlsEnable(panelThree, true);
                        }

                        timer1.Start();
                    }
                    break;
                case "":
                    {

                    }
                    break;
                default:
                    timer1.Stop();
                    break;
            }

        }

        void SetPanelControlsEnable(Panel p, bool b)
        {
            for (int i = 0; i < p.Controls.Count; i++)
            {
                p.Controls[i].Enabled = b;

            }
        }

        private void button24_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button24_MouseDown(object sender, MouseEventArgs e)
        {
            amco.PointPlayDn = true;//开始放绳
        }

        private void button24_MouseUp(object sender, MouseEventArgs e)
        {
            amco.PointPlayDn = false;//停止放绳
        }

        private void button23_MouseDown(object sender, MouseEventArgs e)
        {
            //开始收绳
            amco.PointPlayUp = true;
        }

        private void button23_MouseUp(object sender, MouseEventArgs e)
        {
            //停止收绳
            amco.PointPlayUp = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            SetInitilStep(2);

            /*选中各边距离相等时*/
            double pc_all = 0;
            Double.TryParse(textBoxAll.Text, out pc_all);

            double pc_p_ab = 0;
            Double.TryParse(textBoxpc_p_ab.Text, out pc_p_ab);
            double pc_p_bc = 0;
            Double.TryParse(textBoxpc_p_bc.Text, out pc_p_bc);
            double pc_p_cd = 0;
            Double.TryParse(textBoxpc_p_cd.Text, out pc_p_cd);
            double pc_p_da = 0;
            Double.TryParse(textBoxpc_p_da.Text, out pc_p_da);

            double sys_jiajiaojiaodu = 0;//最高夹角
            Double.TryParse(textBoxsys_jiajiaojiaodu.Text, out sys_jiajiaojiaodu);
            double sys_zmin = 0;//最低高度
            Double.TryParse(textBoxsys_zmin.Text, out sys_zmin);

            amiv.ConfineHJJZ = sys_jiajiaojiaodu;
            amiv.ConfineZ = sys_zmin;

            if (checkBoxpc_p_ab.Checked)
                amiv.PSpaceAB = pc_p_ab;
            if (checkBoxpc_p_bc.Checked)
                amiv.PSpaceBC = pc_p_bc;
            if (checkBoxpc_p_cd.Checked)
                amiv.PSpaceCD = pc_p_cd;
            if (checkBoxpc_p_da.Checked)
                amiv.PSpaceAD = pc_p_da;

            /*选中各边距离相等时*/
            if (checkBoxAll.Checked)
            {
                amiv.PSpaceAB = pc_all;
                amiv.PSpaceBC = pc_all;
                amiv.PSpaceCD = pc_all;
                amiv.PSpaceAD = pc_all;
            }


        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            panelCheck.Enabled = !checkBoxAll.Checked;

        }

        private void button22_Click(object sender, EventArgs e)
        {
            button20_Click(null, null);

            tabControl1.SelectedIndex = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonSubmit2_Click(null, null);

            tabControl1.SelectedIndex = 1;
        }

        private void textBoxAll_TextChanged(object sender, EventArgs e)
        {
            //所有边界使用相同去
            textBoxpc_p_ab.Text = textBoxAll.Text;
            textBoxpc_p_bc.Text = textBoxAll.Text;
            textBoxpc_p_cd.Text = textBoxAll.Text;
            textBoxpc_p_da.Text = textBoxAll.Text;

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(labelStar.Text))
                {
                    amtiv.TwoResetSwitch = false;//二次回零关闭
                }
                else
                {
                    amtiv.TwoResetSwitch = true;//二次回零开始
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            try
            {
                labelStar.Text = amtiv.TwoResetSwitch.ToString();//回零启动状态
                labelOK.Text = amtiv.ResetSwitchOK.ToString();//回零完成状态
            }
            catch
            {
                throw;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            try
            {
                Save1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void Save1()
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string savepath = saveFileDialog1.FileName;


                ConfigData cd = new ConfigData();

                #region MyRegion1

                //水平角
                cd.amiv_ALevel = amiv.ALevel.ToString();
                cd.amiv_BLevel = amiv.BLevel.ToString();
                cd.amiv_CLevel = amiv.CLevel.ToString();
                cd.amiv_DLevel = amiv.DLevel.ToString();

                cd.amiv_PLevel = amiv.PLevel.ToString();

                //垂直角
                cd.amiv_AUp = amiv.AUp.ToString();
                cd.amiv_BUp = amiv.BUp.ToString();

                cd.amiv_CUp = amiv.CUp.ToString();
                cd.amiv_DUp = amiv.DUp.ToString();

                cd.amiv_PUp = amiv.PUp.ToString();

                //距离
                cd.amiv_ASpace = amiv.ASpace.ToString();
                cd.amiv_BSpace = amiv.BSpace.ToString();
                cd.amiv_CSpace = amiv.CSpace.ToString();
                cd.amiv_DSpace = amiv.DSpace.ToString();

                cd.amiv_PSpace = amiv.PSpace.ToString();

                //全站仪高度
                cd.amco_ConfigAllHeight = amco.ConfigAllHeight.ToString();
                #endregion

                #region MyRegion2
                /*选中各边距离不相等时*/
                cd.amiv_ConfineHJJZ = amiv.ConfineHJJZ.ToString();
                cd.amiv_ConfineZ = amiv.ConfineZ.ToString();

                cd.checkBoxpc_p_ab = checkBoxpc_p_ab.Checked;
                cd.amiv_PSpaceAB = amiv.PSpaceAB.ToString();
                cd.checkBoxpc_p_bc = checkBoxpc_p_bc.Checked;
                cd.amiv_PSpaceBC = amiv.PSpaceBC.ToString();
                cd.checkBoxpc_p_cd = checkBoxpc_p_cd.Checked;
                cd.amiv_PSpaceCD = amiv.PSpaceCD.ToString();
                cd.checkBoxpc_p_da = checkBoxpc_p_da.Checked;
                cd.amiv_PSpaceAD = amiv.PSpaceAD.ToString();

                /*选中各边距离相等时*/
                cd.checkBoxAll = checkBoxAll.Checked;

                cd.pc_all = textBoxAll.Text;
                #endregion

                string str = LitJson.JsonMapper.ToJson(cd);

                File.WriteAllText(savepath, str, Encoding.GetEncoding("gbk"));

            }
        }
        void Save2()
        {

        }
        void Save3()
        {

        }

        void Load1(string str)
        {
            ConfigData cd = LitJson.JsonMapper.ToObject<ConfigData>(str);

            #region MyRegion1
            //水平角
            textBoxspaj.Text = cd.amiv_ALevel;
            //double ahor = 0;
            //Double.TryParse(textBoxspaj.Text, out ahor);
            //amiv.ALevel = ahor;

            textBoxspbj.Text = cd.amiv_BLevel;
            //double bhor = 0;
            //Double.TryParse(textBoxspbj.Text, out bhor);
            //amiv.BLevel = bhor;

            textBoxspcj.Text = cd.amiv_CLevel;
            //double chor = 0;
            //Double.TryParse(textBoxspcj.Text, out chor);
            //amiv.CLevel = chor;

            textBoxspdj.Text = cd.amiv_DLevel;
            //double dhor = 0;
            //Double.TryParse(textBoxspdj.Text, out dhor);
            //amiv.DLevel = dhor;

            textBoxsppj.Text = cd.amiv_PLevel;
            //double phor = 0;
            //Double.TryParse(textBoxsppj.Text, out phor);
            //amiv.PLevel = phor;

            //垂直角
            textBoxyangaj.Text = cd.amiv_AUp;
            //double aver = 0;
            //Double.TryParse(textBoxyangaj.Text, out aver);
            //amiv.AUp = aver;

            textBoxyangbj.Text = cd.amiv_BUp;
            //double bver = 0;
            //Double.TryParse(textBoxyangbj.Text, out bver);
            //amiv.BUp = bver;

            textBoxyangcj.Text = cd.amiv_CUp;
            //double cver = 0;
            //Double.TryParse(textBoxyangcj.Text, out cver);
            //amiv.CUp = cver;

            textBoxyangdj.Text = cd.amiv_DUp;
            //double dver = 0;
            //Double.TryParse(textBoxyangdj.Text, out dver);
            //amiv.DUp = dver;

            textBoxyangpj.Text = cd.amiv_PUp;
            //double pver = 0;
            //Double.TryParse(textBoxyangpj.Text, out pver);
            //amiv.PUp = pver;


            //距离
            textBoxlonga.Text = cd.amiv_ASpace;
            //double al = 0;
            //Double.TryParse(textBoxlonga.Text, out al);
            //amiv.ASpace = al;

            textBoxlongb.Text = cd.amiv_BSpace;
            //double bl = 0;
            //Double.TryParse(textBoxlongb.Text, out bl);
            //amiv.BSpace = bl;

            textBoxlongc.Text = cd.amiv_CSpace;
            //double cl = 0;
            //Double.TryParse(textBoxlongc.Text, out cl);
            //amiv.CSpace = cl;

            textBoxlongd.Text = cd.amiv_DSpace;
            //double dl = 0;
            //Double.TryParse(textBoxlongd.Text, out dl);
            //amiv.DSpace = dl;

            textBoxlongp.Text = cd.amiv_PSpace;
            //double pl = 0;
            //Double.TryParse(textBoxlongp.Text, out pl);
            //amiv.PSpace = pl; 
            #endregion


            #region MyRegion2
            /*选中各边距离相等时*/
            textBoxAll.Text = cd.pc_all;
            double pc_all = 0;
            Double.TryParse(textBoxAll.Text, out pc_all);

            textBoxpc_p_ab.Text = cd.amiv_PSpaceAB;
            //double pc_p_ab = 0;
            //Double.TryParse(textBoxpc_p_ab.Text, out pc_p_ab);

            textBoxpc_p_bc.Text = cd.amiv_PSpaceBC;
            //double pc_p_bc = 0;
            //Double.TryParse(textBoxpc_p_bc.Text, out pc_p_bc);

            textBoxpc_p_cd.Text = cd.amiv_PSpaceCD;
            //double pc_p_cd = 0;
            //Double.TryParse(textBoxpc_p_cd.Text, out pc_p_cd);

            textBoxpc_p_da.Text = cd.amiv_PSpaceAD;
            //double pc_p_da = 0;
            //Double.TryParse(textBoxpc_p_da.Text, out pc_p_da);

            textBoxsys_jiajiaojiaodu.Text = cd.amiv_ConfineHJJZ;
            //double sys_jiajiaojiaodu = 0;//最高夹角
            //Double.TryParse(textBoxsys_jiajiaojiaodu.Text, out sys_jiajiaojiaodu);

            textBoxsys_zmin.Text = cd.amiv_ConfineZ;
            //double sys_zmin = 0;//最低高度
            //Double.TryParse(textBoxsys_zmin.Text, out sys_zmin);

            //amiv.ConfineHJJZ = sys_jiajiaojiaodu;
            //amiv.ConfineZ = sys_zmin;

            checkBoxpc_p_ab.Checked = cd.checkBoxpc_p_ab;
            //if (checkBoxpc_p_ab.Checked)
            //    amiv.PSpaceAB = pc_p_ab;
            checkBoxpc_p_bc.Checked = cd.checkBoxpc_p_bc;
            //if (checkBoxpc_p_bc.Checked)
            //    amiv.PSpaceBC = pc_p_bc;
            checkBoxpc_p_cd.Checked = cd.checkBoxpc_p_cd;
            //if (checkBoxpc_p_cd.Checked)
            //    amiv.PSpaceCD = pc_p_cd;
            checkBoxpc_p_da.Checked = cd.checkBoxpc_p_da;
            //if (checkBoxpc_p_da.Checked)
            //    amiv.PSpaceAD = pc_p_da;
            checkBoxAll.Checked = cd.checkBoxAll;
            /*选中各边距离相等时*/
            //if (checkBoxAll.Checked)
            //{
            //    amiv.PSpaceAB = pc_all;
            //    amiv.PSpaceBC = pc_all;
            //    amiv.PSpaceCD = pc_all;
            //    amiv.PSpaceAD = pc_all;
            //} 
            #endregion
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                string str = File.ReadAllText(filename);
                Load1(str);
            }
        }

        private void buttonAllj_Click(object sender, EventArgs e)
        {
            double temp = 0;
            Double.TryParse(textBoxAll.Text, out temp);
            temp -= 100;
            textBoxAll.Text = temp.ToString();
        }

        private void buttonAllz_Click(object sender, EventArgs e)
        {
            double temp = 0;
            Double.TryParse(textBoxAll.Text, out temp);
            temp += 100;
            textBoxAll.Text = temp.ToString();
        }

        private void buttonpc_p_abj_Click(object sender, EventArgs e)
        {
            double temp = 0;
            Double.TryParse(textBoxpc_p_ab.Text, out temp);
            temp -= 100;
            textBoxpc_p_ab.Text = temp.ToString();
        }

        private void buttonpc_p_abz_Click(object sender, EventArgs e)
        {
            double temp = 0;
            Double.TryParse(textBoxpc_p_ab.Text, out temp);
            temp += 100;
            textBoxpc_p_ab.Text = temp.ToString();
        }

        private void buttonpc_p_bcj_Click(object sender, EventArgs e)
        {
            double temp = 0;
            Double.TryParse(textBoxpc_p_bc.Text, out temp);
            temp -= 100;
            textBoxpc_p_bc.Text = temp.ToString();
        }

        private void buttonpc_p_bcz_Click(object sender, EventArgs e)
        {
            double temp = 0;
            Double.TryParse(textBoxpc_p_bc.Text, out temp);
            temp += 100;
            textBoxpc_p_bc.Text = temp.ToString();
        }

        private void buttonpc_p_cdj_Click(object sender, EventArgs e)
        {
            double temp = 0;
            Double.TryParse(textBoxpc_p_cd.Text, out temp);
            temp -= 100;
            textBoxpc_p_cd.Text = temp.ToString();
        }

        private void buttonpc_p_cdz_Click(object sender, EventArgs e)
        {
            double temp = 0;
            Double.TryParse(textBoxpc_p_cd.Text, out temp);
            temp += 100;
            textBoxpc_p_cd.Text = temp.ToString();
        }

        private void buttonpc_p_daj_Click(object sender, EventArgs e)
        {
            double temp = 0;
            Double.TryParse(textBoxpc_p_da.Text, out temp);
            temp -= 100;
            textBoxpc_p_da.Text = temp.ToString();
        }

        private void buttonpc_p_daz_Click(object sender, EventArgs e)
        {
            double temp = 0;
            Double.TryParse(textBoxpc_p_da.Text, out temp);
            temp += 100;
            textBoxpc_p_da.Text = temp.ToString();
        }

        private void buttonsys_jiajiaojiaoduj_Click(object sender, EventArgs e)
        {
            double temp = 0;
            Double.TryParse(textBoxsys_jiajiaojiaodu.Text, out temp);
            temp -= 100;
            textBoxsys_jiajiaojiaodu.Text = temp.ToString();
        }

        private void buttonsys_jiajiaojiaoduz_Click(object sender, EventArgs e)
        {
            double temp = 0;
            Double.TryParse(textBoxsys_jiajiaojiaodu.Text, out temp);
            temp += 100;
            textBoxsys_jiajiaojiaodu.Text = temp.ToString();
        }

        private void buttonsys_zminj_Click(object sender, EventArgs e)
        {
            double temp = 0;
            Double.TryParse(textBoxsys_zmin.Text, out temp);
            temp -= 100;
            textBoxsys_zmin.Text = temp.ToString();
        }

        private void buttonsys_zminz_Click(object sender, EventArgs e)
        {
            double temp = 0;
            Double.TryParse(textBoxsys_zmin.Text, out temp);
            temp += 100;
            textBoxsys_zmin.Text = temp.ToString();
        }
    }
}
