using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuOPCClass;

namespace OPCOperate
{
    /// <summary>
    /// 自定义OPC类
    /// </summary>
    public class MyOPC : IOPC
    {
        SuOPCClass.OpcRcwDaClass myOPCClient;

        FlyCat_PointXYZ fcpointxyz = new FlyCat_PointXYZ();

        FlyCat_SysState fcsysstate = new FlyCat_SysState();

        /// <summary>
        /// 周期更新数据，时间周期单位ms
        /// </summary>
        private const int  DataUpdateNum = 100;

        System.Timers.Timer DataUpdatetime;

        #region 系统状态变量
        /// <summary>
        /// 系统状态名称
        /// </summary>
        static string[] sysstate_name = 
        {
            VariableEnum.statu_no5_enable_ok,//	1	A站电机使能OK	PI377.2	BOOL	电机A、B、C、D激活状态
            VariableEnum.statu_no6_enable_ok,//	2	B站电机使能OK	PI397.2	BOOL	
            VariableEnum.statu_no7_enable_ok,//	3	C站电机使能OK	PI417.2	BOOL	
            VariableEnum.statu_no8_enable_ok,//	4	D站电机使能OK	PI437.2	BOOL	
            VariableEnum.statu_no5_error,//	5	A站错误		BOOL	
            VariableEnum.statu_no6_error,//	6	B站错误		BOOL	
            VariableEnum.statu_no7_error ,//	7	C站错误		BOOL	
            VariableEnum.statu_no8_error ,//	8	D站错误		BOOL	
            VariableEnum.statu_no5_tongxun,//	9	A站通讯故障		BOOL	
            VariableEnum.statu_no6_tongxun ,//	10	B站通讯故障		BOOL	
            VariableEnum.statu_no7_tongxun ,//	11	C站通讯故障		BOOL	
            VariableEnum.statu_no8_tongxun ,//	12	D站通讯故障		BOOL

            VariableEnum.do_5haobaozha ,//	13	A站电机抱闸控制	PQ298.1	BOOL	电机A、B、C、D报闸         打开关闭状态
            VariableEnum.do_6haobaozha ,//	14	B站电机抱闸控制	PQ318.1	BOOL	
            VariableEnum.do_7haobaozha ,//	15	C站电机抱闸控制	PQ338.1	BOOL	
            VariableEnum.do_8haobaozha ,//	16	D站电机抱闸控制	PQ358.1	BOOL	  
            VariableEnum.do_5haojiechuqi,//	17	A站接触器吸合		BOOL	
            VariableEnum.do_6haojiechuqi ,//	18	B站接触器吸合		BOOL	
            VariableEnum.do_7haojiechuqi,//	19	C站接触器吸合		BOOL	
            VariableEnum.do_8haojiechuqi ,//	20	D站接触器吸合		BOOL	

            VariableEnum.di_jinjitingche,//	21	紧急停止按钮（总）	PI257.0	BOOL	紧急停车状态（操作台）
            VariableEnum.di_enable ,//	22	控制系统使能（激活）按钮	PI257.1	BOOL	
            VariableEnum.di_5haojog,//	23	A站电机点动按钮	PI257.4	BOOL	A站操作盒
            VariableEnum.di_6haojog,//	24	B站电机点动按钮	PI257.5	BOOL	B站操作盒
            VariableEnum.di_7haojog ,//	25	C站电机点动按钮	PI257.6	BOOL	C站操作盒
            VariableEnum.di_8haojog,//	26	D站电机点动按钮	PI257.7	BOOL	D站操作盒
            VariableEnum.di_ack ,//	27	故障复位按钮	PI257.2	BOOL	操作台控制盒
            VariableEnum.di_auto_man,//	28	手动/自动转换按钮	PI257.3	BOOL	操作台控制盒
            VariableEnum.di_auto_start ,//	29	启动按钮	PI267.0	BOOL	操作台控制盒
            VariableEnum.di_homeing01 ,//	30	系统回零按钮1	PI267.1	BOOL	操作台控制盒
            VariableEnum.di_homeing02 ,//	31	系统回零按钮2	PI267.2	BOOL	操作台控制盒
            VariableEnum.di_jiudijizhong ,//	32	就地控制按钮	PI267.3	BOOL	操作台控制盒
            VariableEnum.di_8haoshoudong,//	33	操作台D站手动按钮	PI358.3	BOOL	操作台控制盒
            VariableEnum.di_7haoshoudong,//	34	操作台C站手动按钮	PI338.3	BOOL	操作台控制盒
            VariableEnum.di_6haoshoudong ,//	35	操作台B站手动按钮	PI318.3	BOOL	操作台控制盒
            VariableEnum.di_5haoshoudong ,//	36	操作台A站手动按钮	PI298.3	BOOL	操作台控制盒
            VariableEnum.di_5jiting,//	37	A站急停按钮	PI298.0	BOOL	A站操作盒
            VariableEnum.di_6jiting,//	38	B站急停按钮	PI318.0	BOOL	B站操作盒
            VariableEnum.di_7jiting,//	39	C站急停按钮	PI338.0	BOOL	C站操作盒
            VariableEnum.di_8jiting,//	40	D站急停按钮	PI358.0	BOOL	A站操作盒
            VariableEnum.di_5zhidongjiance,//	41	A站制动检测开关	PI299.0	BOOL	
            VariableEnum.di_6zhidongjiance,//	42	B站制动检测开关	PI319.0	BOOL	
            VariableEnum.di_7zhidongjiance ,//	43	C站制动检测开关	PI339.0	BOOL	
            VariableEnum.di_8zhidongjiance ,//	44	D站制动检测开关	PI359.0	BOOL	
            VariableEnum.di_5shoushengjiance, //	45	A站收绳检测开关	PI299.1	BOOL	
            VariableEnum.di_6shoushengjiance,//	46	B站收绳检测开关	PI319.1	BOOL	
            VariableEnum.di_7shoushengjiance,//	47	C站收绳检测开关	PI339.1	BOOL	
            VariableEnum.di_8shoushengjiance, //	48	D站收绳检测开关	PI359.1	BOOL

            VariableEnum.no5_torque,//49 A站扭矩   LREAL
            VariableEnum.no6_torque,//50 B站扭矩   LREAL
            VariableEnum.no7_torque,//51 C站扭矩   LREAL
            VariableEnum.no8_torque,//52 D站扭矩   LREAL
        };

        /// <summary>
        /// 系统状态，对应OpcItemsValue数据索引值
        /// </summary>
        private int[] SysDataIndex;

        static int _SysStateVarCount = sysstate_name.Length;
        /// <summary>
        /// 获取系统状态参数的数量
        /// </summary>
        public int SysStateVarCount
        {
            get { return _SysStateVarCount; }
        }

        /// <summary>
        /// 系统状态
        /// </summary>
        //FlyCat_SysState fcss = new FlyCat_SysState();
     
        Array _SysStateData = Array.CreateInstance(typeof(object), _SysStateVarCount, 2);

        /// <summary>
        /// 获取系统状态二维数组，包括变量名称和变量值。
        /// </summary>
        public Array SysStateData
        {
            get { return _SysStateData; }
        }

        /// <summary>
        /// 获取状态数据类
        /// </summary>
        public FlyCat_SysState SysStateClass
        {
            get {return fcsysstate; }
        }

        #endregion

        #region 实时坐标
        /// <summary>
        /// 实时坐标变量名称
        /// </summary>
        static string[] pointxyz_name = 
        {
            VariableEnum.xp,//	88	P点X轴坐标		LREAL	平台坐标
            VariableEnum.yp,//	89	P点Y轴坐标		LREAL	
            VariableEnum.zp,//	90	P点Z轴坐标		LREAL	
            VariableEnum.xa,//	91	A点X轴坐标		LREAL	A坐标
            VariableEnum.ya,//	92	A点Y轴坐标		LREAL	
            VariableEnum.za,//	93	A点Z轴坐标		LREAL	
            VariableEnum.xb,//	94	B点X轴坐标		LREAL	B坐标
            VariableEnum.yb,//	95	B点Y轴坐标		LREAL	
            VariableEnum.zb,//	96	B点Z轴坐标		LREAL	
            VariableEnum.xc,//	97	C点X轴坐标		LREAL	C坐标
            VariableEnum.yc,//	98	C点Y轴坐标		LREAL	
            VariableEnum.zc,//	99	C点Z轴坐标		LREAL	
            VariableEnum.xd,//	100	D点X轴坐标		LREAL	D坐标
            VariableEnum.yd,//	101	D点Y轴坐标		LREAL	
            VariableEnum.zd,//	102	D点Z轴坐标		LREAL	
            VariableEnum.pc_jl_vx,//录制X轴坐标
            VariableEnum.pc_jl_vy,//录制Y轴坐标
            VariableEnum.pc_jl_vz,//录制Z轴坐标
        };

        /// <summary>
        /// 实时坐标，对应OpcItemsValue数据索引值
        /// </summary>
        private int[] PointXYZDataIndex;

        static int _PointXYZVarCount = pointxyz_name.Length;
        /// <summary>
        /// 获取实时坐标参数的数量
        /// </summary>
        public int PointXYZVarCount
        {
            get { return _PointXYZVarCount; }
        }

        /// <summary>
        /// 实时坐标
        /// </summary>
        Array _PointXYZData = Array.CreateInstance(typeof(object), _PointXYZVarCount, 2);

        /// <summary>
        /// 获取实时坐标二维数组，包括变量名称和变量值。
        /// </summary>
        public Array PointXYZData
        {
            get { return _PointXYZData; }
        }

        /// <summary>
        /// 获取实时坐标数据类
        /// </summary>
        public FlyCat_PointXYZ PointXYZClass
        {
            get { return fcpointxyz; }
        }

        /// <summary>
        ///  获取数据项的数据类型
        /// </summary>
        public Type[] ItemType
        {
            get { return myOPCClient.OpcItemsType; }
        }

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public MyOPC()
        {
            myOPCClient = new OpcRcwDaClass();
            //myOPCClient.DataChanged += new OPCClientClass.DataChangedEventHandler(myOPCClient_DataChanged);

            DataUpdatetime = new System.Timers.Timer(DataUpdateNum);
            DataUpdatetime.Elapsed +=new System.Timers.ElapsedEventHandler(DataUpdatetime_Elapsed);
            DataUpdatetime.Start();

            //系统状态初始化
            for (int i = 0; i < _SysStateVarCount; i++)
            {
                _SysStateData.SetValue(sysstate_name[i], i, 0);
                _SysStateData.SetValue((object)(false), i, 1);//将状态初始化为false
            }

            SysDataIndex = new int[_SysStateVarCount];

            //实时坐标初始化
            for (int i = 0; i < _PointXYZVarCount; i++)
            {
                _PointXYZData.SetValue(pointxyz_name[i], i, 0);
                _PointXYZData.SetValue((object)(0.0), i, 1);//将实时坐标初始化为0
            }

            PointXYZDataIndex = new int[_PointXYZVarCount];
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~MyOPC()
        {
            //myOPCClient.DataChanged -= new OPCClientClass.DataChangedEventHandler(myOPCClient_DataChanged);
            DataUpdatetime.Elapsed -= new System.Timers.ElapsedEventHandler(DataUpdatetime_Elapsed);
            GC.Collect();
        }

        /// <summary>
        /// 获取数据项的数组索引
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public int GetItemIndex(string itemID)
        {
            return myOPCClient.GetItemIndex(itemID);
        }

        /// <summary>
        /// 获取数据的索引值
        /// </summary>
        /// <returns>是否正确</returns>
        private bool GetDataIndex()
        {
            if (myOPCClient.OpcConnected)
            {
                if (myOPCClient.OpcItemsLength > 0)
                {
                    bool ret = true;

                    //系统状态值索引
                    int i;
                    for (i = 0; i < _SysStateVarCount; i++)
                    {
                        string strtemp= sysstate_name[i];
                        int j;
                        for (j = 0; j < myOPCClient.OpcItemsLength; j++)
                        {
                            if (myOPCClient.OpcItemsName[j].Trim() == strtemp.Trim())
                            {
                                SysDataIndex[i] = j;
                                break;
                            }
                        }
                        if (j >= myOPCClient.OpcItemsLength)
                        {
                            ret = false;
                        }
                    }

                    //实时状态值索引
                    int m;
                    for (m = 0; m < _PointXYZVarCount; m++)
                    {
                        string strtemp = pointxyz_name[m];
                        int n;
                        for (n = 0; n < myOPCClient.OpcItemsLength; n++)
                        {
                            if (myOPCClient.OpcItemsName[n].Trim() == strtemp.Trim())
                            {
                                PointXYZDataIndex[m] = n;
                                break;
                            }
                        }
                        if (n >= myOPCClient.OpcItemsLength)
                        {
                            ret = false;
                        }
                    }

                    return ret;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///数据变化事件处理函数
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        //void myOPCClient_DataChanged(object Sender, OPCClientClass.DataChangedEventArgs e)
        //{
        //    int i = 0;
        //    try
        //    {
        //        //数据发生变化
        //        int len1 = e.ItemValue.Length;

        //        for (i=0; i < len1; i++)
        //        {
        //            bool bl = false;
        //            if (e.ItemID[i] == null)
        //            {
        //                continue;
        //            }
        //            string str1 = e.ItemID[i].Trim();

        //            //系统状态
        //            if (!bl)
        //            {
        //                int len2 = _SysStateVarCount;

        //                for (int j = 0; j < len2; j++)
        //                {
        //                    string str2 = Convert.ToString(_SysStateData.GetValue(j, 0)).Trim();//获取变量名称

        //                    if (str1 == str2)
        //                    {
        //                        object temp = e.ItemValue.GetValue(i);
        //                        _SysStateData.SetValue(temp, j, 1);//设置变量值
        //                        bl = true;

        //                        switch (j)
        //                        {
        //                            case 0:
        //                                fcsysstate.SysState_Enabled.A = Convert.ToBoolean(temp);
        //                                break;
        //                            case 1:
        //                                fcsysstate.SysState_Enabled.B = Convert.ToBoolean(temp);
        //                                break;
        //                            case 2:
        //                                fcsysstate.SysState_Enabled.C = Convert.ToBoolean(temp);
        //                                break;
        //                            case 3:
        //                                fcsysstate.SysState_Enabled.D = Convert.ToBoolean(temp);
        //                                break;
        //                            case 4:
        //                                fcsysstate.SysState_NodeError.A = Convert.ToBoolean(temp);
        //                                break;
        //                            case 5:
        //                                fcsysstate.SysState_NodeError.B = Convert.ToBoolean(temp);
        //                                break;
        //                            case 6:
        //                                fcsysstate.SysState_NodeError.C = Convert.ToBoolean(temp);
        //                                break;
        //                            case 7:
        //                                fcsysstate.SysState_NodeError.D = Convert.ToBoolean(temp);
        //                                break;
        //                            case 8:
        //                                fcsysstate.SysState_CommError.A = Convert.ToBoolean(temp);
        //                                break;
        //                            case 9:
        //                                fcsysstate.SysState_CommError.B = Convert.ToBoolean(temp);
        //                                break;
        //                            case 10:
        //                                fcsysstate.SysState_CommError.C = Convert.ToBoolean(temp);
        //                                break;
        //                            case 11:
        //                                fcsysstate.SysState_CommError.D = Convert.ToBoolean(temp);
        //                                break;
        //                            case 12:
        //                                fcsysstate.SysState_DOState.DO_ALockControl = Convert.ToBoolean(temp);
        //                                break;
        //                            case 13:
        //                                fcsysstate.SysState_DOState.DO_BLockControl = Convert.ToBoolean(temp);
        //                                break;
        //                            case 14:
        //                                fcsysstate.SysState_DOState.DO_CLockControl = Convert.ToBoolean(temp);
        //                                break;
        //                            case 15:
        //                                fcsysstate.SysState_DOState.DO_DLockControl = Convert.ToBoolean(temp);
        //                                break;
        //                            case 16:
        //                                fcsysstate.SysState_DOState.DO_AKMControl = Convert.ToBoolean(temp);
        //                                break;
        //                            case 17:
        //                                fcsysstate.SysState_DOState.DO_BKMControl = Convert.ToBoolean(temp);
        //                                break;
        //                            case 18:
        //                                fcsysstate.SysState_DOState.DO_CKMControl = Convert.ToBoolean(temp);
        //                                break;
        //                            case 19:
        //                                fcsysstate.SysState_DOState.DO_DKMControl = Convert.ToBoolean(temp);
        //                                break;
        //                            case 20:
        //                                fcsysstate.SysState_DIState.DI_EmerStop = Convert.ToBoolean(temp);//
        //                                break;
        //                            case 21:
        //                                fcsysstate.SysState_DIState.DI_SysControlEn = Convert.ToBoolean(temp);
        //                                break;
        //                            case 22:
        //                                fcsysstate.SysState_DIState.DI_APointPlay = Convert.ToBoolean(temp);
        //                                break;
        //                            case 23:
        //                                fcsysstate.SysState_DIState.DI_BPointPlay = Convert.ToBoolean(temp);
        //                                break;
        //                            case 24:
        //                                fcsysstate.SysState_DIState.DI_CPointPlay = Convert.ToBoolean(temp);
        //                                break;
        //                            case 25:
        //                                fcsysstate.SysState_DIState.DI_DPointPlay = Convert.ToBoolean(temp);
        //                                break;
        //                            case 26:
        //                                fcsysstate.SysState_DIState.DI_FaultReset = Convert.ToBoolean(temp);
        //                                break;
        //                            case 27:
        //                                fcsysstate.SysState_DIState.DI_Switch = Convert.ToBoolean(temp);
        //                                break;
        //                            case 28:
        //                                fcsysstate.SysState_DIState.DI_Start = Convert.ToBoolean(temp);
        //                                break;
        //                            case 29:
        //                                fcsysstate.SysState_DIState.DI_SysZero1 = Convert.ToBoolean(temp);
        //                                break;
        //                            case 30:
        //                                fcsysstate.SysState_DIState.DI_SysZero2 = Convert.ToBoolean(temp);
        //                                break;
        //                            case 31:
        //                                fcsysstate.SysState_DIState.DI_LocalControl = Convert.ToBoolean(temp);
        //                                break;
        //                            case 32:
        //                                fcsysstate.SysState_DIState.DI_DManual = Convert.ToBoolean(temp);
        //                                break;
        //                            case 33:
        //                                fcsysstate.SysState_DIState.DI_CManual = Convert.ToBoolean(temp);
        //                                break;
        //                            case 34:
        //                                fcsysstate.SysState_DIState.DI_BManual = Convert.ToBoolean(temp);
        //                                break;
        //                            case 35:
        //                                fcsysstate.SysState_DIState.DI_AManual = Convert.ToBoolean(temp);
        //                                break;
        //                            case 36:
        //                                fcsysstate.SysState_DIState.DI_AEmerStop = Convert.ToBoolean(temp);
        //                                break;
        //                            case 37:
        //                                fcsysstate.SysState_DIState.DI_BEmerStop = Convert.ToBoolean(temp);
        //                                break;
        //                            case 38:
        //                                fcsysstate.SysState_DIState.DI_CEmerStop = Convert.ToBoolean(temp);
        //                                break;
        //                            case 39:
        //                                fcsysstate.SysState_DIState.DI_DEmerStop = Convert.ToBoolean(temp);
        //                                break;
        //                            case 40:
        //                                fcsysstate.SysState_DIState.DI_AStopCheck = Convert.ToBoolean(temp);
        //                                break;
        //                            case 41:
        //                                fcsysstate.SysState_DIState.DI_BStopCheck = Convert.ToBoolean(temp);
        //                                break;
        //                            case 42:
        //                                fcsysstate.SysState_DIState.DI_CStopCheck = Convert.ToBoolean(temp);
        //                                break;
        //                            case 43:
        //                                fcsysstate.SysState_DIState.DI_DStopCheck = Convert.ToBoolean(temp);
        //                                break;
        //                            case 44:
        //                                fcsysstate.SysState_DIState.DI_APullCheck = Convert.ToBoolean(temp);
        //                                break;
        //                            case 45:
        //                                fcsysstate.SysState_DIState.DI_BPullCheck = Convert.ToBoolean(temp);
        //                                break;
        //                            case 46:
        //                                fcsysstate.SysState_DIState.DI_CPullCheck = Convert.ToBoolean(temp);
        //                                break;
        //                            case 47:
        //                                fcsysstate.SysState_DIState.DI_DPullCheck = Convert.ToBoolean(temp);
        //                                break;
        //                            case 48:
        //                                fcsysstate.SysState_Moment.AMoment = Convert.ToDouble(temp);
        //                                break;
        //                            case 49:
        //                                fcsysstate.SysState_Moment.BMoment = Convert.ToDouble(temp);
        //                                break;
        //                            case 50:
        //                                fcsysstate.SysState_Moment.CMoment = Convert.ToDouble(temp);
        //                                break;
        //                            case 51:
        //                                fcsysstate.SysState_Moment.DMoment = Convert.ToDouble(temp);
        //                                break;
        //                            default:
        //                                break;
        //                        }
        //                        break;
        //                    }
        //                }
        //            }

        //            //实时坐标
        //            if (!bl)
        //            {
        //                int len2 = _PointXYZVarCount;

        //                for (int j = 0; j < len2; j++)
        //                {
        //                    string str2 = Convert.ToString(_PointXYZData.GetValue(j, 0)).Trim();//获取变量名称

        //                    if (str1 == str2)
        //                    {
        //                        object temp = e.ItemValue.GetValue(i);
        //                        _PointXYZData.SetValue(temp, j, 1);//设置变量值
        //                        bl = true;

        //                        switch (j)
        //                        {
        //                            case 0:
        //                                fcpointxyz.PXCoor = Convert.ToDouble(temp);
        //                                break;
        //                            case 1:
        //                                fcpointxyz.PYCoor = Convert.ToDouble(temp);
        //                                break;
        //                            case 2:
        //                                fcpointxyz.PZCoor = Convert.ToDouble(temp);
        //                                break;
        //                            case 3:
        //                                fcpointxyz.AXCoor = Convert.ToDouble(temp);
        //                                break;
        //                            case 4:
        //                                fcpointxyz.AYCoor = Convert.ToDouble(temp);
        //                                break;
        //                            case 5:
        //                                fcpointxyz.AZCoor = Convert.ToDouble(temp);
        //                                break;
        //                            case 6:
        //                                fcpointxyz.BXCoor = Convert.ToDouble(temp);
        //                                break;
        //                            case 7:
        //                                fcpointxyz.BYCoor = Convert.ToDouble(temp);
        //                                break;
        //                            case 8:
        //                                fcpointxyz.BZCoor = Convert.ToDouble(temp);
        //                                break;
        //                            case 9:
        //                                fcpointxyz.CXCoor = Convert.ToDouble(temp);
        //                                break;
        //                            case 10:
        //                                fcpointxyz.CYCoor = Convert.ToDouble(temp);
        //                                break;
        //                            case 11:
        //                                fcpointxyz.CZCoor = Convert.ToDouble(temp);
        //                                break;
        //                            case 12:
        //                                fcpointxyz.DXCoor = Convert.ToDouble(temp);
        //                                break;
        //                            case 13:
        //                                fcpointxyz.DYCoor = Convert.ToDouble(temp);
        //                                break;
        //                            case 14:
        //                                fcpointxyz.DZCoor = Convert.ToDouble(temp);
        //                                break;
        //                            default:
        //                                break;
        //                        }
        //                        break;
        //                    }
        //                }
        //            }

        //        }
        //    }
        //    catch
        //    {
        //        throw new NotImplementedException();
        //    }
        //}


        /// <summary>
        /// 更新系统状态
        /// </summary>
        /// <param name="index"></param>
        /// <param name="temp"></param>
        private void SysDataUpdate(int index,string temp)
        {
            switch (index)
            {
                case 0:
                    fcsysstate.SysState_Enabled.A = Convert.ToBoolean(temp);
                    break;
                case 1:
                    fcsysstate.SysState_Enabled.B = Convert.ToBoolean(temp);
                    break;
                case 2:
                    fcsysstate.SysState_Enabled.C = Convert.ToBoolean(temp);
                    break;
                case 3:
                    fcsysstate.SysState_Enabled.D = Convert.ToBoolean(temp);
                    break;
                case 4:
                    fcsysstate.SysState_NodeError.A = Convert.ToBoolean(temp);
                    break;
                case 5:
                    fcsysstate.SysState_NodeError.B = Convert.ToBoolean(temp);
                    break;
                case 6:
                    fcsysstate.SysState_NodeError.C = Convert.ToBoolean(temp);
                    break;
                case 7:
                    fcsysstate.SysState_NodeError.D = Convert.ToBoolean(temp);
                    break;
                case 8:
                    fcsysstate.SysState_CommError.A = Convert.ToBoolean(temp);
                    break;
                case 9:
                    fcsysstate.SysState_CommError.B = Convert.ToBoolean(temp);
                    break;
                case 10:
                    fcsysstate.SysState_CommError.C = Convert.ToBoolean(temp);
                    break;
                case 11:
                    fcsysstate.SysState_CommError.D = Convert.ToBoolean(temp);
                    break;
                case 12:
                    fcsysstate.SysState_DOState.DO_ALockControl = Convert.ToBoolean(temp);
                    break;
                case 13:
                    fcsysstate.SysState_DOState.DO_BLockControl = Convert.ToBoolean(temp);
                    break;
                case 14:
                    fcsysstate.SysState_DOState.DO_CLockControl = Convert.ToBoolean(temp);
                    break;
                case 15:
                    fcsysstate.SysState_DOState.DO_DLockControl = Convert.ToBoolean(temp);
                    break;
                case 16:
                    fcsysstate.SysState_DOState.DO_AKMControl = Convert.ToBoolean(temp);
                    break;
                case 17:
                    fcsysstate.SysState_DOState.DO_BKMControl = Convert.ToBoolean(temp);
                    break;
                case 18:
                    fcsysstate.SysState_DOState.DO_CKMControl = Convert.ToBoolean(temp);
                    break;
                case 19:
                    fcsysstate.SysState_DOState.DO_DKMControl = Convert.ToBoolean(temp);
                    break;
                case 20:
                    fcsysstate.SysState_DIState.DI_EmerStop = Convert.ToBoolean(temp);//
                    break;
                case 21:
                    fcsysstate.SysState_DIState.DI_SysControlEn = Convert.ToBoolean(temp);
                    break;
                case 22:
                    fcsysstate.SysState_DIState.DI_APointPlay = Convert.ToBoolean(temp);
                    break;
                case 23:
                    fcsysstate.SysState_DIState.DI_BPointPlay = Convert.ToBoolean(temp);
                    break;
                case 24:
                    fcsysstate.SysState_DIState.DI_CPointPlay = Convert.ToBoolean(temp);
                    break;
                case 25:
                    fcsysstate.SysState_DIState.DI_DPointPlay = Convert.ToBoolean(temp);
                    break;
                case 26:
                    fcsysstate.SysState_DIState.DI_FaultReset = Convert.ToBoolean(temp);
                    break;
                case 27:
                    fcsysstate.SysState_DIState.DI_Switch = Convert.ToBoolean(temp);
                    break;
                case 28:
                    fcsysstate.SysState_DIState.DI_Start = Convert.ToBoolean(temp);
                    break;
                case 29:
                    fcsysstate.SysState_DIState.DI_SysZero1 = Convert.ToBoolean(temp);
                    break;
                case 30:
                    fcsysstate.SysState_DIState.DI_SysZero2 = Convert.ToBoolean(temp);
                    break;
                case 31:
                    fcsysstate.SysState_DIState.DI_LocalControl = Convert.ToBoolean(temp);
                    break;
                case 32:
                    fcsysstate.SysState_DIState.DI_DManual = Convert.ToBoolean(temp);
                    break;
                case 33:
                    fcsysstate.SysState_DIState.DI_CManual = Convert.ToBoolean(temp);
                    break;
                case 34:
                    fcsysstate.SysState_DIState.DI_BManual = Convert.ToBoolean(temp);
                    break;
                case 35:
                    fcsysstate.SysState_DIState.DI_AManual = Convert.ToBoolean(temp);
                    break;
                case 36:
                    fcsysstate.SysState_DIState.DI_AEmerStop = Convert.ToBoolean(temp);
                    break;
                case 37:
                    fcsysstate.SysState_DIState.DI_BEmerStop = Convert.ToBoolean(temp);
                    break;
                case 38:
                    fcsysstate.SysState_DIState.DI_CEmerStop = Convert.ToBoolean(temp);
                    break;
                case 39:
                    fcsysstate.SysState_DIState.DI_DEmerStop = Convert.ToBoolean(temp);
                    break;
                case 40:
                    fcsysstate.SysState_DIState.DI_AStopCheck = Convert.ToBoolean(temp);
                    break;
                case 41:
                    fcsysstate.SysState_DIState.DI_BStopCheck = Convert.ToBoolean(temp);
                    break;
                case 42:
                    fcsysstate.SysState_DIState.DI_CStopCheck = Convert.ToBoolean(temp);
                    break;
                case 43:
                    fcsysstate.SysState_DIState.DI_DStopCheck = Convert.ToBoolean(temp);
                    break;
                case 44:
                    fcsysstate.SysState_DIState.DI_APullCheck = Convert.ToBoolean(temp);
                    break;
                case 45:
                    fcsysstate.SysState_DIState.DI_BPullCheck = Convert.ToBoolean(temp);
                    break;
                case 46:
                    fcsysstate.SysState_DIState.DI_CPullCheck = Convert.ToBoolean(temp);
                    break;
                case 47:
                    fcsysstate.SysState_DIState.DI_DPullCheck = Convert.ToBoolean(temp);
                    break;
                case 48:
                    fcsysstate.SysState_Moment.AMoment = Convert.ToDouble(temp);
                    break;
                case 49:
                    fcsysstate.SysState_Moment.BMoment = Convert.ToDouble(temp);
                    break;
                case 50:
                    fcsysstate.SysState_Moment.CMoment = Convert.ToDouble(temp);
                    break;
                case 51:
                    fcsysstate.SysState_Moment.DMoment = Convert.ToDouble(temp);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 更新实时坐标
        /// </summary>
        /// <param name="index"></param>
        /// <param name="temp"></param>
        private void PointXYZDataUpdate(int index, string temp)
        {
            switch (index)
            {
                case 0:
                    fcpointxyz.PXCoor = Convert.ToDouble(temp);
                    break;
                case 1:
                    fcpointxyz.PYCoor = Convert.ToDouble(temp);
                    break;
                case 2:
                    fcpointxyz.PZCoor = Convert.ToDouble(temp);
                    break;
                case 3:
                    fcpointxyz.AXCoor = Convert.ToDouble(temp);
                    break;
                case 4:
                    fcpointxyz.AYCoor = Convert.ToDouble(temp);
                    break;
                case 5:
                    fcpointxyz.AZCoor = Convert.ToDouble(temp);
                    break;
                case 6:
                    fcpointxyz.BXCoor = Convert.ToDouble(temp);
                    break;
                case 7:
                    fcpointxyz.BYCoor = Convert.ToDouble(temp);
                    break;
                case 8:
                    fcpointxyz.BZCoor = Convert.ToDouble(temp);
                    break;
                case 9:
                    fcpointxyz.CXCoor = Convert.ToDouble(temp);
                    break;
                case 10:
                    fcpointxyz.CYCoor = Convert.ToDouble(temp);
                    break;
                case 11:
                    fcpointxyz.CZCoor = Convert.ToDouble(temp);
                    break;
                case 12:
                    fcpointxyz.DXCoor = Convert.ToDouble(temp);
                    break;
                case 13:
                    fcpointxyz.DYCoor = Convert.ToDouble(temp);
                    break;
                case 14:
                    fcpointxyz.DZCoor = Convert.ToDouble(temp);
                    break;
                case 15:
                    fcpointxyz.JLXCoor = Convert.ToDouble(temp);
                    break;
                case 16:
                    fcpointxyz.JLYCoor = Convert.ToDouble(temp);
                    break;
                case 17:
                    fcpointxyz.JLZCoor = Convert.ToDouble(temp);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 数据周期处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataUpdatetime_Elapsed(object sender, EventArgs e)
        {

            try
            {
    
                if (myOPCClient.OpcConnected)
                {
                    for (int i = 0; i < _SysStateVarCount; i++)
                    {
                        int index = SysDataIndex[i];
                        string strtemp = SuOPCClass.OpcRcwDaClass.ToString(myOPCClient.OpcItemsValue[index]);
                        _SysStateData.SetValue(strtemp, i, 1);
                        SysDataUpdate(i, strtemp);
                    }

                    for (int j = 0; j < _PointXYZVarCount; j++)
                    {
                        int index = PointXYZDataIndex[j];
                        string strtemp = SuOPCClass.OpcRcwDaClass.ToString(myOPCClient.OpcItemsValue[index]);
                        _PointXYZData.SetValue(strtemp, j, 1);
                        PointXYZDataUpdate(j, strtemp);
                    }
                }

                DataUpdatetime.Start();
           }
            catch (Exception ex)
            {
                
            }
        }

        /// <summary>
        /// 所有数据的集合
        /// </summary>
        internal Array Data
        {
            get
            {
                if (myOPCClient.OpcConnected)
                {
                    int count = myOPCClient.OpcItemsLength;

                    if (count > 0)
                    {
                        Array arr = Array.CreateInstance(typeof(string), new int[2] { count, 2 }, new int[2] { 0, 0 });
                        for (int i = 0; i < count; i++)
                        {
                            arr.SetValue(myOPCClient.OpcItemsName[i], i, 0);
                            arr.SetValue(SuOPCClass.OpcRcwDaClass.ToString(myOPCClient.OpcItemsValue[i]), i, 1);
                        }

                        return (arr);
                    }
                    else
                    {
                        return (null);
                    }
                }
                else
                {
                    return (null);
                }

            }
        }

        /// <summary>
        /// 获取opc是否连接
        /// </summary>
        internal bool Connection
        {
            get { return myOPCClient.OpcConnected; }
        }

        #region IOPC 成员

        /// <summary>
        /// 连接服务端
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool OPCConnection(string ip, string name)
        {
            try
            {
                bool bl;
                if (!myOPCClient.OpcConnected)
                {
                    myOPCClient.Connect(ip, name);
                    bl = myOPCClient.OpcConnected;

                    if (bl)
                    {
                        GetDataIndex();
                    }
                }
                else
                {
                    bl = true;
                }
                return bl;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// 连接服务端
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool OPCConnection(string ip, string name,string[] items)
        {
                bool bl;
                if (!myOPCClient.OpcConnected)
                {
                    myOPCClient.Connect(ip, name, items);
                    bl = myOPCClient.OpcConnected;

                    if (bl)
                    {
                        GetDataIndex();
                    }
                }
                else
                {
                    bl = true;
                }
                return bl;

        }
        /// <summary>
        /// 读取变量
        /// </summary>
        /// <param name="variable">读取的变量名称</param>
        /// <returns>变量的值,错误时返回null</returns>
        public string OPCReadData(string variable)
        {
            try
            {
                string str;
                if (myOPCClient.OpcConnected)
                {
                    //str = myOPCClient.OPCReadData(variable);
                    myOPCClient.OPCAsReadData(variable);
                    int i;
                    for (i = 0; i < myOPCClient.OpcItemsLength; i++)
                    {
                        if(myOPCClient.OpcItemsName[i].Trim() == variable.Trim())
                        {
                            break;
                        } 
                    }
                    if (i < myOPCClient.OpcItemsLength)
                    {
                        str = SuOPCClass.OpcRcwDaClass.ToString(myOPCClient.OpcItemsValue[i]);
                    }
                    else
                    {
                        str = null;
                    }
                }
                else
                {
                    str = null;
                }
                return str;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 读取多个变量
        /// </summary>
        /// <param name="variable">变量名称数组</param>
        /// <returns>数值数组</returns>
        public string[] OPCReadData(string[] variable)
        {
            try
            {
                string[] str;
                if (myOPCClient.OpcConnected)
                {
                    str = (string[])SuOPCClass.OpcRcwDaClass.ChangeType(myOPCClient.OPCReadData(variable),typeof(string[]));
                }
                else
                {
                    str = null;
                }
                return str;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 写入变量值
        /// </summary>
        /// <param name="variable">写入的变量名称</param>
        /// <param name="value">写入的变量的值</param>
        /// <returns>写入是否成功</returns>
        public bool OPCWriteData(string variable, string value)
        {
            try
            {
                bool bl;
                if (myOPCClient.OpcConnected)
                {
                    //bl = myOPCClient.OPCWriteData(variable, value);
                    //bl = myOPCClient.OPCAsWriteData(variable, value);//异步写
                    object o = SuOPCClass.OpcRcwDaClass.ChangeType(value,typeof(object));
                    bl = myOPCClient.OPCAsWriteData(variable, o);//异步写
                }
                else
                {
                    bl = false;
                }
                return bl;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 写入多个变量值
        /// </summary>
        /// <param name="variable">写入的数据名称数组</param>
        /// <param name="value">写入的数据数组</param>
        /// <returns>是否有错误</returns>
        public bool OPCWriteData(string[] variable, string[] value)
        {
            try
            {
                bool bl;
                if (myOPCClient.OpcConnected)
                {
                    bl = myOPCClient.OPCWriteData(variable, value);
                }
                else
                {
                    bl = false;
                }
                return bl;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        /// <summary>
        /// 实时坐标值类
        /// </summary>
        public class FlyCat_PointXYZ
        {
            #region 实时坐标P点的x,y,z轴坐标
            double _PXCoor = 0.0;
            /// <summary>
            /// 获取或设置实时坐标P点的X轴坐标值
            /// </summary>
            public double PXCoor
            {
                get { return _PXCoor; }
                set { _PXCoor = value;}
            }

            double _PYCoor = 0.0;
            /// <summary>
            /// 获取或设置实时坐标P点的Y轴坐标值
            /// </summary>
            public double PYCoor
            {
                get { return _PYCoor; }
                set { _PYCoor = value; }
            }

            double _PZCoor = 0.0;
            /// <summary>
            /// 获取或设置实时坐标P点的Z轴坐标值
            /// </summary>
            public double PZCoor
            {
                get { return _PZCoor; }
                set { _PZCoor = value; }
            }

            #endregion

            #region 实时坐标A点的x,y,z轴坐标
            double _AXCoor = 0.0;
            /// <summary>
            /// 获取或设置实时坐标A点的X轴坐标值
            /// </summary>
            public double AXCoor
            {
                get { return _AXCoor; }
                set { _AXCoor = value; }
            }

            double _AYCoor = 0.0;
            /// <summary>
            /// 获取或设置实时坐标A点的Y轴坐标值
            /// </summary>
            public double AYCoor
            {
                get { return _AYCoor; }
                set { _AYCoor = value; }
            }

            double _AZCoor = 0.0;
            /// <summary>
            /// 获取或设置实时坐标A点的Z轴坐标值
            /// </summary>
            public double AZCoor
            {
                get { return _AZCoor; }
                set { _AZCoor = value; }
            }

            #endregion

            #region 实时坐标B点的x,y,z轴坐标
            double _BXCoor = 0.0;
            /// <summary>
            /// 获取或设置实时坐标B点的X轴坐标值
            /// </summary>
            public double BXCoor
            {
                get { return _BXCoor; }
                set { _BXCoor = value; }
            }

            double _BYCoor = 0.0;
            /// <summary>
            /// 获取或设置实时坐标B点的Y轴坐标值
            /// </summary>
            public double BYCoor
            {
                get { return _BYCoor; }
                set { _BYCoor = value; }
            }

            double _BZCoor = 0.0;
            /// <summary>
            /// 获取或设置实时坐标B点的Z轴坐标值
            /// </summary>
            public double BZCoor
            {
                get { return _BZCoor; }
                set { _BZCoor = value; }
            }

            #endregion

            #region 实时坐标C点的x,y,z轴坐标
            double _CXCoor = 0.0;
            /// <summary>
            /// 获取或设置实时坐标C点的X轴坐标值
            /// </summary>
            public double CXCoor
            {
                get { return _CXCoor; }
                set { _CXCoor = value; }
            }

            double _CYCoor = 0.0;
            /// <summary>
            /// 获取或设置实时坐标C点的Y轴坐标值
            /// </summary>
            public double CYCoor
            {
                get { return _CYCoor; }
                set { _CYCoor = value; }
            }

            double _CZCoor = 0.0;
            /// <summary>
            /// 获取或设置实时坐标C点的Z轴坐标值
            /// </summary>
            public double CZCoor
            {
                get { return _CZCoor; }
                set { _CZCoor = value; }
            }

            #endregion

            #region 实时坐标D点的x,y,z轴坐标
            double _DXCoor = 0.0;
            /// <summary>
            /// 获取或设置实时坐标D点的X轴坐标值
            /// </summary>
            public double DXCoor
            {
                get { return _DXCoor; }
                set { _DXCoor = value; }
            }

            double _DYCoor = 0.0;
            /// <summary>
            /// 获取或设置实时坐标D点的Y轴坐标值
            /// </summary>
            public double DYCoor
            {
                get { return _DYCoor; }
                set { _DYCoor = value; }
            }

            double _DZCoor = 0.0;
            /// <summary>
            /// 获取或设置实时坐标D点的Z轴坐标值
            /// </summary>
            public double DZCoor
            {
                get { return _DZCoor; }
                set { _DZCoor = value; }
            }

            #endregion

            #region 录制实时坐标x,y,z轴坐标
            double _JLXCoor = 0.0;
            /// <summary>
            /// 获取或设置录制的X轴坐标值
            /// </summary>
            public double JLXCoor
            {
                get { return _JLXCoor; }
                set { _JLXCoor = value; }
            }

            double _JLYCoor = 0.0;
            /// <summary>
            /// 获取或设置录制的Y轴坐标值
            /// </summary>
            public double JLYCoor
            {
                get { return _JLYCoor; }
                set { _JLYCoor = value; }
            }

            double _JLZCoor = 0.0;
            /// <summary>
            /// 获取或设置录制的Z轴坐标值
            /// </summary>
            public double JLZCoor
            {
                get { return _JLZCoor; }
                set { _JLZCoor = value; }
            }

            #endregion

        }

        /// <summary>
        /// 系统状态类
        /// </summary>
        public class FlyCat_SysState
        {
            /// <summary>
            /// 站点错误
            /// </summary>
            public MotorNodeError SysState_NodeError = new MotorNodeError();

            /// <summary>
            /// 站点通讯错误状态
            /// </summary>
            public MotorCommError SysState_CommError = new MotorCommError();

            /// <summary>
            /// 站点使能状态
            /// </summary>
            public MotorEnabled SysState_Enabled = new MotorEnabled();

            /// <summary>
            /// DO状态显示类
            /// </summary>
            public MotorDOState SysState_DOState = new MotorDOState();

            /// <summary>
            /// DI状态显示类
            /// </summary>
            public MotorDIState SysState_DIState = new MotorDIState();

            /// <summary>
            /// 电机力矩显示类
            /// </summary>
            public MotorMoment SysState_Moment = new MotorMoment();
        }

        /// <summary>
        /// 站点错误类
        /// </summary>
        public class MotorNodeError
        {

            bool a = false;
            /// <summary>
            /// A站点错误
            /// </summary>
            public bool A
            {
                get 
                { 
                    return a; 
                }
                set 
                { 
                    a = value; 
                }

            }
            bool b = false;
            /// <summary>
            /// B站点错误
            /// </summary>
            public bool B
            {
                get
                {
                    return b;
                }
                set
                {
                    b = value;
                }

            }
            bool c = false;
            /// <summary>
            /// C站点错误
            /// </summary>
            public bool C
            {
                get
                {
                    return c;
                }
                set
                {
                    c = value;
                }

            }
            bool d = false;
            /// <summary>
            /// D站点错误
            /// </summary>
            public bool D
            {
                get
                {
                    return d;
                }
                set
                {
                    d = value;
                }

            }

        }

        /// <summary>
        /// 站点通讯错误状态
        /// </summary>
        public class MotorCommError
        {

            bool a = false;
            /// <summary>
            /// A站点通讯错误
            /// </summary>
            public bool A
            {
                get
                {
                    return a;
                }
                set
                {
                    a = value;
                }

            }
            bool b = false;
            /// <summary>
            /// B站点通讯错误
            /// </summary>
            public bool B
            {
                get
                {
                    return b;
                }
                set
                {
                    b = value;
                }

            }
            bool c = false;
            /// <summary>
            /// C站点通讯错误
            /// </summary>
            public bool C
            {
                get
                {
                    return c;
                }
                set
                {
                    c = value;
                }
            }
            bool d = false;
            /// <summary>
            /// D站点通讯错误
            /// </summary>
            public bool D
            {
                get
                {
                    return d;
                }
                set
                {
                    d = value;
                }

            }

        }

        /// <summary>
        /// 站点使能状态
        /// </summary>
        public class MotorEnabled
        {
            bool a = false;
            /// <summary>
            /// A站点使能
            /// </summary>
            public bool A
            {
                get
                {
                    return a;
                }
                set
                {
                    a = value;
                }
            }

            bool b = false;
            /// <summary>
            /// B站点使能
            /// </summary>
            public bool B
            {
                get
                {
                    return b;
                }
                set
                {
                    b = value;
                }
            }

            bool c = false;
            /// <summary>
            /// C站点使能
            /// </summary>
            public bool C
            {
                get
                {
                    return c;
                }
                set
                {
                    c = value;
                }
            }

            bool d = false;
            /// <summary>
            /// D站点使能
            /// </summary>
            public bool D
            {
                get
                {
                    return d;
                }
                set
                {
                    d = value;
                }
            }
        }

        // <summary>
        /// DO状态显示
        /// </summary>
        public class MotorDOState
        {
            bool btAControl = false;
            /// <summary>
            /// DO-A站电机抱闸控制状态
            /// </summary>
            public bool DO_ALockControl
            {
                get
                {
                    return btAControl;
                }
                set
                {
                    btAControl = value;
                }

            }

            bool btBControl = false;
            /// <summary>
            /// DO-B站电机抱闸控制状态
            /// </summary>
            public bool DO_BLockControl
            {
                get
                {
                    return btBControl;
                }
                set
                {
                    btBControl = value;
                }

            }

            bool btCControl = false;
            /// <summary>
            /// DO-C站电机抱闸控制状态
            /// </summary>
            public bool DO_CLockControl
            {
                get
                {
                    return btCControl;
                }
                set
                {
                    btCControl = value;
                }

            }

            bool btDControl = false;
            /// <summary>
            /// DO-D站电机抱闸控制状态
            /// </summary>
            public bool DO_DLockControl
            {
                get
                {
                    return btDControl;
                }
                set
                {
                    btDControl = value;
                }

            }

            bool btAKMControl = false;
            /// <summary>
            /// DO-A站接触器状态
            /// </summary>
            public bool DO_AKMControl
            {
                get
                {
                    return btAKMControl;
                }
                set
                {
                    btAKMControl = value;
                }

            }

            bool btBKMControl = false;
            /// <summary>
            /// DO-B站接触器状态
            /// </summary>
            public bool DO_BKMControl
            {
                get
                {
                    return btBKMControl;
                }
                set
                {
                    btBKMControl = value;
                }

            }

            bool btCKMControl = false;
            /// <summary>
            /// DO-C站接触器状态
            /// </summary>
            public bool DO_CKMControl
            {
                get
                {
                    return btCKMControl;
                }
                set
                {
                    btCKMControl = value;
                }

            }

            bool btDKMControl = false;
            /// <summary>
            /// DO-D站接触器状态
            /// </summary>
            public bool DO_DKMControl
            {
                get
                {
                    return btDKMControl;
                }
                set
                {
                    btDKMControl = value;
                }
            }
        }

        /// <summary>
        /// DI状态显示
        /// </summary>
        public class MotorDIState
        {
            bool btControl = false;
            /// <summary>
            /// DI-控制系统使能按钮
            /// </summary>
            public bool DI_SysControlEn
            {
                get
                {
                    return btControl;
                }
                set
                {
                    btControl = value;
                }
            }

            bool btAPointPlay = false;
            /// <summary>
            /// DI-A站点动按钮
            /// </summary>
            public bool DI_APointPlay
            {
                get
                {
                    return btAPointPlay;
                }
                set
                {
                    btAPointPlay = value;
                }
            }

            bool btBPointPlay = false;
            /// <summary>
            /// DI-B站点动按钮
            /// </summary>
            public bool DI_BPointPlay
            {
                get
                {
                    return btBPointPlay;
                }
                set
                {
                    btBPointPlay = value;
                }
            }

            bool btCPointPlay = false;
            /// <summary>
            /// DI-C站点动按钮
            /// </summary>
            public bool DI_CPointPlay
            {
                get
                {
                    return btCPointPlay;
                }
                set
                {
                    btCPointPlay = value;
                }
            }

            bool btDPointPlay = false;
            /// <summary>
            /// DI-D站点动按钮
            /// </summary>
            public bool DI_DPointPlay
            {
                get
                {
                    return btDPointPlay;
                }
                set
                {
                    btDPointPlay = value;
                }
            }

            bool btFaultReset = false;
            /// <summary>
            /// DI-故障复位按钮
            /// </summary>
            public bool DI_FaultReset
            {
                get
                {
                    return btFaultReset;
                }
                set
                {
                    btFaultReset = value;
                }
            }

            bool btSwitch = false;
            /// <summary>
            /// DI-手动自动转换按钮
            /// </summary>
            public bool DI_Switch
            {
                get
                {
                    return btSwitch;
                }
                set
                {
                    btSwitch = value;
                }
            }

            bool btStart = false;
            /// <summary>
            /// DI-起动按钮
            /// </summary>
            public bool DI_Start
            {
                get
                {
                    return btStart;
                }
                set
                {
                    btStart = value;
                }
            }

            bool btSysZero1 = false;
            /// <summary>
            /// DI-系统回零按钮1
            /// </summary>
            public bool DI_SysZero1
            {
                get
                {
                    return btSysZero1;
                }
                set
                {
                    btSysZero1 = value;
                }
            }

            bool btSysZero2 = false;
            /// <summary>
            /// DI-系统回零按钮2
            /// </summary>
            public bool DI_SysZero2
            {
                get
                {
                    return btSysZero2;
                }
                set
                {
                    btSysZero2 = value;
                }
            }

            bool btLocalControl = false;
            /// <summary>
            /// DI-本地控制按钮
            /// </summary>
            public bool DI_LocalControl
            {
                get
                {
                    return btLocalControl;
                }
                set
                {
                    btLocalControl = value;
                }
            }

            bool btAManual = false;
            /// <summary>
            /// DI-A站手动按钮
            /// </summary>
            public bool DI_AManual
            {
                get
                {
                    return btAManual;
                }
                set
                {
                    btAManual = value;
                }
            }

            bool btBManual = false;
            /// <summary>
            /// DI-B站手动按钮
            /// </summary>
            public bool DI_BManual
            {
                get
                {
                    return btBManual;
                }
                set
                {
                    btBManual = value;
                }
            }

            bool btCManual = false;
            /// <summary>
            /// DI-C站手动按钮
            /// </summary>
            public bool DI_CManual
            {
                get
                {
                    return btCManual;
                }
                set
                {
                    btCManual = value;
                }
            }

            bool btDManual = false;
            /// <summary>
            /// DI-D站手动按钮
            /// </summary>
            public bool DI_DManual
            {
                get
                {
                    return btDManual;
                }
                set
                {
                    btDManual = value;
                }
            }

            bool btAEmerStop = false;
            /// <summary>
            /// DI-A站紧急停车按钮
            /// </summary>
            public bool DI_AEmerStop
            {
                get
                {
                    return btAEmerStop;
                }
                set
                {
                    btAEmerStop = value;
                }
            }

            bool btBEmerStop = false;
            /// <summary>
            /// DI-B站紧急停车按钮
            /// </summary>
            public bool DI_BEmerStop
            {
                get
                {
                    return btBEmerStop;
                }
                set
                {
                    btBEmerStop = value;
                }
            }

            bool btCEmerStop = false;
            /// <summary>
            /// DI-C站紧急停车按钮
            /// </summary>
            public bool DI_CEmerStop
            {
                get
                {
                    return btCEmerStop;
                }
                set
                {
                    btCEmerStop = value;
                }
            }

            bool btDEmerStop = false;
            /// <summary>
            /// DI-D站紧急停车按钮
            /// </summary>
            public bool DI_DEmerStop
            {
                get
                {
                    return btDEmerStop;
                }
                set
                {
                    btDEmerStop = value;
                }
            }

            bool btAStopCheck = false;
            /// <summary>
            /// DI-A站制动检测按钮
            /// </summary>
            public bool DI_AStopCheck
            {
                get
                {
                    return btAStopCheck;
                }
                set
                {
                    btAStopCheck = value;
                }
            }

            bool btBStopCheck = false;
            /// <summary>
            /// DI-B站制动检测按钮
            /// </summary>
            public bool DI_BStopCheck
            {
                get
                {
                    return btBStopCheck;
                }
                set
                {
                    btBStopCheck = value;
                }
            }

            bool btCStopCheck = false;
            /// <summary>
            /// DI-C站制动检测按钮
            /// </summary>
            public bool DI_CStopCheck
            {
                get
                {
                    return btCStopCheck;
                }
                set
                {
                    btCStopCheck = value;
                }
            }

            bool btDStopCheck = false;
            /// <summary>
            /// DI-D站制动检测按钮
            /// </summary>
            public bool DI_DStopCheck
            {
                get
                {
                    return btDStopCheck;
                }
                set
                {
                    btDStopCheck = value;
                }
            }

            bool btAPullCheck = false;
            /// <summary>
            /// DI-A站收绳检测按钮
            /// </summary>
            public bool DI_APullCheck
            {
                get
                {
                    return btAPullCheck;
                }
                set
                {
                    btAPullCheck = value;
                }
            }

            bool btBPullCheck = false;
            /// <summary>
            /// DI-B站收绳检测按钮
            /// </summary>
            public bool DI_BPullCheck
            {
                get
                {
                    return btBPullCheck;
                }
                set
                {
                    btBPullCheck = value;
                }
            }

            bool btCPullCheck = false;
            /// <summary>
            /// DI-C站收绳检测按钮
            /// </summary>
            public bool DI_CPullCheck
            {
                get
                {
                    return btCPullCheck;
                }
                set
                {
                    btCPullCheck = value;
                }
            }

            bool btDPullCheck = false;
            /// <summary>
            /// DI-D站收绳检测按钮
            /// </summary>
            public bool DI_DPullCheck
            {
                get
                {
                    return btDPullCheck;
                }
                set
                {
                    btDPullCheck = value;
                }
            }

            bool btEmerStop = false;
            /// <summary>
            /// DI-全局紧急停车按钮
            /// </summary>
            public bool DI_EmerStop
            {
                get
                {
                    return btEmerStop;
                }
                set
                {
                    btEmerStop = value;
                }
            }

        }

        /// <summary>
        /// 力矩状态显示
        /// </summary>
        public class MotorMoment
        {
            double dAMoment = 0.0;
            /// <summary>
            /// A站力矩
            /// </summary>
            public double AMoment
            {
                get
                {
                    return dAMoment;
                }
                set
                {
                    dAMoment = value;
                }
            }

            double dBMoment = 0.0;
            /// <summary>
            /// B站力矩
            /// </summary>
            public double BMoment
            {
                get
                {
                    return dBMoment;
                }
                set
                {
                    dBMoment = value;
                }
            }

            double dCMoment = 0.0;
            /// <summary>
            /// C站力矩
            /// </summary>
            public double CMoment
            {
                get
                {
                    return dCMoment;
                }
                set
                {
                    dCMoment = value;
                }
            }

            double dDMoment = 0.0;
            /// <summary>
            /// D站力矩
            /// </summary>
            public double DMoment
            {
                get
                {
                    return dDMoment;
                }
                set
                {
                    dDMoment = value;
                }
            }

        }

    }
}
