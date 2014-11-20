using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsOPC
{
    public partial class FormOPCTest : Form
    {
        OPCOperate.VariableClass myVariable = OPCOperate.VariableClass.VariableClass_();

        OPCOperate.AsyMotorInitValue myInitvalue = new OPCOperate.AsyMotorInitValue();

        delegate void LabelUpdate(Label l,string text);
        LabelUpdate labeldisplay;
       
        public FormOPCTest()
        {
            InitializeComponent();
            timer1.Interval = 500;
            timer1.Start();

            timer2.Interval = 1000;
            timer2.Start();

            labeldisplay = new LabelUpdate(LUpdate);

            myVariable.StateUpdate+=new OPCOperate.VariableClass.StateUpdateEventHandler(myVariable_StateUpdate);
            myVariable.PointXYZUpdate+=new OPCOperate.VariableClass.PointXYZUpdateEventHandler(myVariable_PointXYZUpdate);

            
        }

        void LUpdate(Label l,string text)
        {
            if (!l.IsHandleCreated)
            {
                return;
            }

            if (l.InvokeRequired)
            {
                if (l.IsHandleCreated)
                {
                    l.Invoke(labeldisplay, new object[] { l, text });
                }
            }
            else
            {
                l.Text = text;
            }
        }

        private void myVariable_StateUpdate(object sender, OPCOperate.MyOPC.FlyCat_SysState data)
        {
            try
            {
                LUpdate(labelAerr, data.SysState_NodeError.A.ToString());
                LUpdate(labelAerr, data.SysState_NodeError.A.ToString());
                LUpdate(labelBerr, data.SysState_NodeError.B.ToString());
                LUpdate(labelCerr, data.SysState_NodeError.C.ToString());
                LUpdate(labelDerr, data.SysState_NodeError.D.ToString());

                LUpdate(labelAComm, data.SysState_CommError.A.ToString());
                LUpdate(labelBComm, data.SysState_CommError.B.ToString());
                LUpdate(labelCComm, data.SysState_CommError.C.ToString());
                LUpdate(labelDComm, data.SysState_CommError.D.ToString());

                LUpdate(labelAEn, data.SysState_Enabled.A.ToString());
                LUpdate(labelBEn, data.SysState_Enabled.B.ToString());
                LUpdate(labelCEn, data.SysState_Enabled.C.ToString());
                LUpdate(labelDEn,data.SysState_Enabled.D.ToString());

                LUpdate(labelDOAbz, data.SysState_DOState.DO_ALockControl.ToString());
                LUpdate(labelDOBbz, data.SysState_DOState.DO_BLockControl.ToString());
                LUpdate(labelDOCbz, data.SysState_DOState.DO_CLockControl.ToString());
                LUpdate(labelDODbz, data.SysState_DOState.DO_DLockControl.ToString());

                LUpdate(labelDOAkm, data.SysState_DOState.DO_AKMControl.ToString());
                LUpdate(labelDOBkm, data.SysState_DOState.DO_BKMControl.ToString());
                LUpdate(labelDOCkm, data.SysState_DOState.DO_CKMControl.ToString());
                LUpdate(labelDODkm, data.SysState_DOState.DO_DKMControl.ToString());

                //label7.Text = data.SysState_DIState.DI_EmerStop.ToString();
            }
            catch (Exception ex)
            {
                //myVariable.StateUpdate -= new OPCOperate.VariableClass.StateUpdateEventHandler(myVariable_StateUpdate);
                MessageBox.Show("状态更新：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void myVariable_PointXYZUpdate(object sender, OPCOperate.MyOPC.FlyCat_PointXYZ data)
        {
            try
            {
                LUpdate(labelPX, data.PXCoor.ToString());
                LUpdate(labelPX,data.PXCoor.ToString());
                LUpdate(labelPY,data.PYCoor.ToString());
                LUpdate(labelPZ,data.PZCoor.ToString());

                LUpdate(labelAX,data.AXCoor.ToString());
                LUpdate(labelAY,data.AYCoor.ToString());
                LUpdate(labelAZ,data.AZCoor.ToString());

                LUpdate(labelBX,data.BXCoor.ToString());
                LUpdate(labelBY,data.BYCoor.ToString());
                LUpdate(labelBZ,data.BZCoor.ToString());

                LUpdate(labelCX,data.CXCoor.ToString());
                LUpdate(labelCY,data.CYCoor.ToString());
                LUpdate(labelCZ,data.CZCoor.ToString());

                LUpdate(labelDX,data.DXCoor.ToString());
                LUpdate(labelDY,data.DYCoor.ToString());
                LUpdate(labelDZ,data.DZCoor.ToString());
            }
            catch (Exception ex)
            {
                //myVariable.PointXYZUpdate -= new OPCOperate.VariableClass.PointXYZUpdateEventHandler(myVariable_PointXYZUpdate);
                MessageBox.Show("实时坐标更新：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (OPCOperate.MyOPCObject.IsConnected())
                {
                    Array arr = OPCOperate.MyOPCObject.Data;

                    int j, RowCount, len;
                    RowCount = dataGridView1.RowCount;

                    len = arr.Length / arr.Rank;
                    for (int i = 0; i < len; i++)
                    {
                        for (j = 0; j < RowCount; j++)
                        {
                            if ((string)arr.GetValue(i, 0) == dataGridView1.Rows[j].Cells["Column1"].Value.ToString())
                            {
                                dataGridView1.Rows[j].Cells["Column2"].Value = arr.GetValue(i, 1);
                                break;
                            }
                        }

                        if (j >= RowCount)
                        {
                            dataGridView1.Rows.Add(new object[2] { arr.GetValue(i, 0), arr.GetValue(i, 1) });
                        }

                    }

                    label2.Text = dataGridView1.Rows.Count.ToString();
                }

                timer1.Start();
            }
            catch (Exception ex)
            {
                timer1.Stop();
                MessageBox.Show("定时器1：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                OPCOperate.AsyMotorNodeError err = new OPCOperate.AsyMotorNodeError();
                //labelAerr.Text = err.A.ToString();
                //labelBerr.Text = err.B.ToString();
                //labelCerr.Text = err.C.ToString();
                //labelDerr.Text = err.D.ToString();

                timer2.Start();
            }
            catch (Exception ex)
            {
                timer1.Stop();
                MessageBox.Show("定时器：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((e.ColumnIndex == 1) && (e.RowIndex != -1))
                {
                    string str1 = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                    string str2 = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Column2"].Value);
                    FormOPCTestw f = new FormOPCTestw(str1, str2);
                    if (f.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据列表：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormOPCTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            myVariable.PointXYZUpdate -= new OPCOperate.VariableClass.PointXYZUpdateEventHandler(myVariable_PointXYZUpdate);
            myVariable.StateUpdate -= new OPCOperate.VariableClass.StateUpdateEventHandler(myVariable_StateUpdate);
            myVariable = null;
        }
    }
}
