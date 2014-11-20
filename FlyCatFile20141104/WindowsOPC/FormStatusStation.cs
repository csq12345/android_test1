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
    public partial class FormStatusStation : Form
    {
        /// <summary>
        /// fdfdsd 
        /// </summary>
        OPCOperate.VariableClass vc = VariableClass.VariableClass_();

        public FormStatusStation()
        {
            InitializeComponent();
            Initial();

          
        }

       


        /// <summary>
        /// 初始化界面
        /// </summary>
        void Initial()
        {
            //DataGridViewRow[] dgvr = new DataGridViewRow[]{
            //    CreateNewRow("通讯状态","CommuniCation"),
            //    CreateNewRow("紧急按钮","EmergenceButton"),
            //    CreateNewRow("电缆监控","CableFeedMonitor"),
            //    CreateNewRow("安全手刹","SafetyClutch"),
            //    CreateNewRow("钥匙开关","KeySwitches"),
            //    CreateNewRow("重启安全回路","SafetyCirceitRestarted"),
            //    CreateNewRow("制动","Brakes"),
            //    CreateNewRow("移动NC","Motion_NC"),
            //    CreateNewRow("重置电阻","RegenResistor"),
            //    CreateNewRow("激活","Activated"),
            //};


            //dataGridView1.Rows.AddRange(dgvr);
        }

        /// <summary>
        ///// 获取新列表行
        ///// </summary>
        ///// <returns></returns>
        //DataGridViewRow CreateNewRow(string name, string tag)
        //{
        //    //DataGridViewRow dgvr = new DataGridViewRow();
        //    //dgvr.CreateCells(dataGridView1);
        //    //dgvr.Cells[0].Value = name;
        //    //dgvr.Tag = tag;
        //    //for (int i = 1; i < dgvr.Cells.Count; i++)
        //    //{
        //    //    dgvr.Cells[i].Value = Properties.Resources.yellow;
        //    //}
        //    //return dgvr;
        //}

        /// <summary>
        /// 设置界面上一行的值
        /// </summary>
        void SetRowValue(string name)
        {
            //DataGridViewRow dgvr = FindRowByName(name);
            //if (dgvr != null)
            //{

            //}
        }

        private void FormStatusStation_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        ///// <summary>
        ///// 查找指定名称的行
        ///// </summary>
        ///// <param name="name"></param>
        //DataGridViewRow FindRowByName(string name)
        //{
        //    DataGridViewRow redgvr = null;
        //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //    {
        //        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == name)
        //        {
        //            redgvr = dataGridView1.Rows[i];
        //        }
        //    }
        //    return redgvr;
        //}
    }
}
