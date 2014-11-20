using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OPCOperate;

namespace WindowsOPC
{
    public partial class FormStatusControl : Form
    {

        OPCOperate.VariableClass vc = VariableClass.VariableClass_();

        public FormStatusControl()
        {
            InitializeComponent();
            vc.StateUpdate += new VariableClass.StateUpdateEventHandler(vc_StateUpdate);
        }




        void vc_StateUpdate(object sender, MyOPC.FlyCat_SysState data)
        {
            StateUpdate(sender,data);

            StateUpdate2(sender,data);

        }

        void StateUpdate2(object sender, MyOPC.FlyCat_SysState data)
        {

            //点动按钮
            userControlRGYdi_5haojog1.SetStatu(data.SysState_DIState.DI_APointPlay);
            userControlRGYdi_5haojog2.SetStatu(data.SysState_DIState.DI_BPointPlay);
            userControlRGYdi_5haojog3.SetStatu(data.SysState_DIState.DI_CPointPlay);
            userControlRGYdi_5haojog4.SetStatu(data.SysState_DIState.DI_DPointPlay);

            //手动按钮
            userControlRGYdi_8haoshoudong1.SetStatu(data.SysState_DIState.DI_AManual);
            userControlRGYdi_8haoshoudong2.SetStatu(data.SysState_DIState.DI_BManual);
            userControlRGYdi_8haoshoudong3.SetStatu(data.SysState_DIState.DI_CManual);
            userControlRGYdi_8haoshoudong4.SetStatu(data.SysState_DIState.DI_DManual);

            //急停按钮
            userControlRGYdi_5jiting1.SetStatu(data.SysState_DIState.DI_AEmerStop);
            userControlRGYdi_5jiting2.SetStatu(data.SysState_DIState.DI_BEmerStop);
            userControlRGYdi_5jiting3.SetStatu(data.SysState_DIState.DI_CEmerStop);
            userControlRGYdi_5jiting4.SetStatu(data.SysState_DIState.DI_DEmerStop);

            //制动检测
            userControlRGYdi_5zhidongjiance1.SetStatu(data.SysState_DIState.DI_AStopCheck);
            userControlRGYdi_5zhidongjiance2.SetStatu(data.SysState_DIState.DI_BStopCheck);
            userControlRGYdi_5zhidongjiance3.SetStatu(data.SysState_DIState.DI_CStopCheck);
            userControlRGYdi_5zhidongjiance4.SetStatu(data.SysState_DIState.DI_DStopCheck);

            //收绳检测
            userControlRGYdi_5shoushengjiance1.SetStatu(data.SysState_DIState.DI_APullCheck);
            userControlRGYdi_5shoushengjiance2.SetStatu(data.SysState_DIState.DI_BPullCheck);
            userControlRGYdi_5shoushengjiance3.SetStatu(data.SysState_DIState.DI_CPullCheck);
            userControlRGYdi_5shoushengjiance4.SetStatu(data.SysState_DIState.DI_DPullCheck);

            //紧急停止总
            userControlRGYdi_jinjitingch1.SetStatu(data.SysState_DIState.DI_EmerStop);

            //控制系统能使
            userControlRGYdi_enable1.SetStatu(data.SysState_DIState.DI_SysControlEn);

            //故障复位按钮
            userControlRGYdi_ack.SetStatu(data.SysState_DIState.DI_FaultReset);

            //手动自动装换
            userControlRGYdi_auto_man.SetStatu(data.SysState_DIState.DI_Switch);

            //启动按钮
            userControlRGYdi_auto_start.SetStatu(data.SysState_DIState.DI_Start);

            //就地控制
            userControlRGYdi_jiudijizhong.SetStatu(data.SysState_DIState.DI_LocalControl);

            //系统回零
            userControlRGYdi_homeing01.SetStatu(data.SysState_DIState.DI_SysZero1);
            userControlRGYdi_homeing02.SetStatu(data.SysState_DIState.DI_SysZero2);

        }

        private void FormStatusControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            vc.StateUpdate -= new VariableClass.StateUpdateEventHandler(vc_StateUpdate);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        void StateUpdate(object sender, MyOPC.FlyCat_SysState data)
        {
            //通讯状态
            userControlRGYstatu_no5_tongxun1.SetStatu(!data.SysState_CommError.A);
            userControlRGYstatu_no5_tongxun2.SetStatu(!data.SysState_CommError.B);
            userControlRGYstatu_no5_tongxun3.SetStatu(!data.SysState_CommError.C);
            userControlRGYstatu_no5_tongxun4.SetStatu(!data.SysState_CommError.D);
            //站点错误
            userControlRGYstatu_no5_error1.SetStatu(data.SysState_NodeError.A);
            userControlRGYstatu_no5_error2.SetStatu(data.SysState_NodeError.B);
            userControlRGYstatu_no5_error3.SetStatu(data.SysState_NodeError.C);
            userControlRGYstatu_no5_error4.SetStatu(data.SysState_NodeError.D);

            //站点可用
            userControlRGYstatu_no5_enable_ok1.SetStatu(data.SysState_Enabled.A);
            userControlRGYstatu_no5_enable_ok2.SetStatu(data.SysState_Enabled.B);
            userControlRGYstatu_no5_enable_ok3.SetStatu(data.SysState_Enabled.C);
            userControlRGYstatu_no5_enable_ok4.SetStatu(data.SysState_Enabled.D);

            //抱闸控制
            userControlRGYdo_5haobaozha1.SetStatu(data.SysState_DOState.DO_ALockControl);
            userControlRGYdo_5haobaozha2.SetStatu(data.SysState_DOState.DO_BLockControl);
            userControlRGYdo_5haobaozha3.SetStatu(data.SysState_DOState.DO_CLockControl);
            userControlRGYdo_5haobaozha4.SetStatu(data.SysState_DOState.DO_DLockControl);

            //接触器
            userControlRGYdo_5haojiechuqi1.SetStatu(data.SysState_DOState.DO_AKMControl);
            userControlRGYdo_5haojiechuqi2.SetStatu(data.SysState_DOState.DO_BKMControl);
            userControlRGYdo_5haojiechuqi3.SetStatu(data.SysState_DOState.DO_CKMControl);
            userControlRGYdo_5haojiechuqi4.SetStatu(data.SysState_DOState.DO_DKMControl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
