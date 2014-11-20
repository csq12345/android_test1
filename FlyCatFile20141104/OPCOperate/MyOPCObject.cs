using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPCOperate
{
    /// <summary>
    /// opc服务操作类，所有和opcserver交互都使用此静态类
    /// </summary>
    public static class MyOPCObject
    {
        private const string ip = "127.0.0.1";
        //private const string name = "Matrikon.OPC.Simulation.1";
        //private const string name = "ICONICS.SimulatorOPCDA.2";
        private const string name ="OPC.SimaticNET";
        static MyOPC myopc = new MyOPC();

        //所有名称的集合
        static string[] VariableNames = 
        {
            VariableEnum.statu_no5_enable_ok,//	1	A站电机使能OK	PI377.2	BOOL	电机A、B、C、D激活状态
            VariableEnum.statu_no6_enable_ok,//	2	B站电机使能OK	PI397.2	BOOL	
            VariableEnum.statu_no7_enable_ok,//	3	C站电机使能OK	PI417.2	BOOL	
            VariableEnum.statu_no8_enable_ok,//	4	D站电机使能OK	PI437.2	BOOL	
            VariableEnum.statu_no5_error,//	5	A站错误		BOOL	
            VariableEnum.statu_no6_error,//	6	B站错误		BOOL	
            VariableEnum.statu_no7_error,//	7	C站错误		BOOL	
            VariableEnum.statu_no8_error,//	8	D站错误		BOOL	
            VariableEnum.statu_no5_tongxun,//	9	A站通讯故障		BOOL	
            VariableEnum.statu_no6_tongxun,//	10	B站通讯故障		BOOL	
            VariableEnum.statu_no7_tongxun,//	11	C站通讯故障		BOOL	
            VariableEnum.statu_no8_tongxun,//	12	D站通讯故障		BOOL

            VariableEnum.do_5haobaozha,//	13	A站电机抱闸控制	PQ298.1	BOOL	电机A、B、C、D报闸         打开关闭状态
            VariableEnum.do_6haobaozha,//	14	B站电机抱闸控制	PQ318.1	BOOL	
            VariableEnum.do_7haobaozha,//	15	C站电机抱闸控制	PQ338.1	BOOL	
            VariableEnum.do_8haobaozha,//	16	D站电机抱闸控制	PQ358.1	BOOL	  
            VariableEnum.do_5haojiechuqi,//	17	A站接触器吸合		BOOL	
            VariableEnum.do_6haojiechuqi,//	18	B站接触器吸合		BOOL	
            VariableEnum.do_7haojiechuqi,//	19	C站接触器吸合		BOOL	
            VariableEnum.do_8haojiechuqi,//	20	D站接触器吸合		BOOL	

            VariableEnum.di_jinjitingche,//	21	紧急停止按钮（总）	PI257.0	BOOL	紧急停车状态（操作台）
            VariableEnum.di_enable,//	22	控制系统使能（激活）按钮	PI257.1	BOOL	
            VariableEnum.di_5haojog,//	23	A站电机点动按钮	PI257.4	BOOL	A站操作盒
            VariableEnum.di_6haojog,//	24	B站电机点动按钮	PI257.5	BOOL	B站操作盒
            VariableEnum.di_7haojog,//	25	C站电机点动按钮	PI257.6	BOOL	C站操作盒
            VariableEnum.di_8haojog,//	26	D站电机点动按钮	PI257.7	BOOL	D站操作盒
            VariableEnum.di_ack,//	27	故障复位按钮	PI257.2	BOOL	操作台控制盒
            VariableEnum.di_auto_man,//	28	手动/自动转换按钮	PI257.3	BOOL	操作台控制盒
            VariableEnum.di_auto_start,//	29	启动按钮	PI267.0	BOOL	操作台控制盒
            VariableEnum.di_homeing01,//	30	系统回零按钮1	PI267.1	BOOL	操作台控制盒
            VariableEnum.di_homeing02,//	31	系统回零按钮2	PI267.2	BOOL	操作台控制盒
            VariableEnum.di_jiudijizhong,//	32	就地控制按钮	PI267.3	BOOL	操作台控制盒
            VariableEnum.di_8haoshoudong,//	33	操作台D站手动按钮	PI358.3	BOOL	操作台控制盒
            VariableEnum.di_7haoshoudong,//	34	操作台C站手动按钮	PI338.3	BOOL	操作台控制盒
            VariableEnum.di_6haoshoudong,//	35	操作台B站手动按钮	PI318.3	BOOL	操作台控制盒
            VariableEnum.di_5haoshoudong,//	36	操作台A站手动按钮	PI298.3	BOOL	操作台控制盒
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

            VariableEnum.pc_qufanzfangxian,//"D435.pc_qufanzfangxiang";//	49	取反上下摇杆方向		BOOL	

            VariableEnum.pc_jog_fangshen,//"D435.pc_jog_fangshen";//	50	上位机点动放绳按钮		BOOL	上位机（画面上）
            VariableEnum.pc_jog_shoushen,//"D435.pc_jog_shoushen";//	51	上位机点动收绳		BOOL	上位机（画面上）
            VariableEnum.pc_man_tiaozhen,//"D435.pc_man_tiaozhen";//	52	上位机进入手动调整状态		BOOL	上位机操作（画面上）
            VariableEnum.pc_yaogan_enable,//"D435.pc_yaogan_enable";//	53	上位机禁用启用摇杆		BOOL	上位机操作（画面上）

            VariableEnum.pc_5haojog,// = "\\SYM:\\D435.pc_5haojog";//	选中“电机1”		BOOL	上位机操作（画面上）
            VariableEnum.pc_6haojog,// = "\\SYM:\\D435.pc_6haojog";//	选中“电机2”		BOOL	上位机操作（画面上）
            VariableEnum.pc_7haojog,// = "\\SYM:\\D435.pc_7haojog";//	选中“电机3”		BOOL	上位机操作（画面上）
            VariableEnum.pc_8haojog,// = "\\SYM:\\D435.pc_8haojog";//	选中“电机4”		BOOL	上位机操作（画面上）

            VariableEnum.sys_backtochushidian,//"D435.sys_backtochushidian";//	54	回回放路径初始点		BOOL	上位机操作（画面上）
            VariableEnum.sys_backwancheng,//"D435.sys_backwancheng";//	55	回回放路径初始点完成		BOOL	上位机操作（画面上）
            VariableEnum.sys_replay,//"D435.sys_replay";//	56	是否处于回放状态		BOOL	上位机操作（画面上）

            VariableEnum.vh,//"D435.vh";//	57	回回放零点时的速度基准		LREAL	
            VariableEnum.xh,//"D435.xh";//	58	回放起点X坐标		LREAL	
            VariableEnum.yh,//"D435.yh";//	59	回放起点Y坐标		LREAL	
            VariableEnum.zh,//"D435.zh";//	60	回放起点Z坐标		LREAL	
            VariableEnum.pc_hf_vx,//"D435.pc_hf_vx";//	61	回放时上位机给的运动信号 X方向		LREAL	
            VariableEnum.pc_hf_vy,//"D435.pc_hf_vy";//	62	回放时上位机给的运动信号 Y方向		LREAL	
            VariableEnum.pc_hf_vz,//"D435.pc_hf_vz";//	63	回放时上位机给的运动信号 Z方向		LREAL	
            VariableEnum.pc_jl_vx,//"D435.pc_jl_vx";//	64	给上位机的摇杆信号 X方向		LREAL	
            VariableEnum.pc_jl_vy,//"D435.pc_jl_vy";//	65	给上位机的摇杆信号 Y方向		LREAL	
            VariableEnum.pc_jl_vz,//"D435.pc_jl_vz";//	66	给上位机的摇杆信号 Z方向		LREAL	

            VariableEnum.hmi_ack,//"D435.hmi_ack";//	67	上位机故障复位按钮		BOOL	上位机操作（画面上）
            VariableEnum.sys_xyxuanzhuanjiaodu,//"D435.sys_xyxuanzhuanjiaodu";//	68	坐标旋转角度		LREAL	坐标旋转
            VariableEnum.sys_xiepozhengliang,//"D435.sys_xiepozhengliang";//	69	速度斜坡控制增量		LREAL	摇杆灵敏度
            VariableEnum.pc_pintai_vmax,//"D435.pc_pintai_vmax";//	70	P点移动最快速度		LREAL	
            VariableEnum.pc_shoudongsudugeiding,//"D435.pc_shoudongsudugeiding";//	71	上位机手动速度给定		LREAL	
            VariableEnum.pc_yaoganlingmingdu,//"D435.pc_yaoganlingmingdu";//	72	摇杆灵敏度，范围：0-10		LREAL	
            VariableEnum.sys_shouxianxishu,//"D435.sys_shouxianxishu";//	73	计算垂直于各边速度时的系数		LREAL	

            VariableEnum.long_a_gaodu,//"D435.long_a_gaodu";//	74	A站高度		LREAL	
            VariableEnum.long_ab_kuandu,//"D435.long_ab_kuandu";//	75	AB站水平宽度		LREAL	
            VariableEnum.long_b_gaodu,//"D435.long_b_gaodu";//	76	B站高度		LREAL	
            VariableEnum.long_bc_kuandu,//"D435.long_bc_kuandu";//	77	BC站水平宽度		LREAL	
            VariableEnum.long_c_gaodu,//"D435.long_c_gaodu";//	78	C站高度		LREAL	
            VariableEnum.long_cd_kuandu,//"D435.long_cd_kuandu";//	79	CD站水平宽度		LREAL	
            VariableEnum.long_d_gaodu,//"D435.long_d_gaodu";//	80	D站高度		LREAL	
            VariableEnum.long_da_kuandu,//"D435.long_da_kuandu";//	81	DA站水平宽度		LREAL	
            VariableEnum.long_quanzhanyigaodu,//"D435.long_quanzhanyigaodu";//	82	全站仪高度设定		LREAL	
            VariableEnum.pc_qubieabcd,//"D435.pc_qubieabcd";//	83	上位机区别测量的是AP、BP、CP或DP		BYTE	二次测量电机选择 0A 1B 2C 3D

            VariableEnum.pc_yaoganlingmingdu_z,//"D435.pc_yaoganlingmingdu_z";//	Z轴摇杆灵敏度，范围：0-10		LREAL
            VariableEnum.sys_xiepozhengliang_z,//"D435.sys_xiepozhengliang_z";//	Z轴速度斜坡控制增量		LREAL
            VariableEnum.pc_pintai_vmax_z,//"D435.pc_pintai_vmax_z";//	Z移动最快速度		LREAL
            VariableEnum.pc_tongxunceshi,//"D435.pc_tongxunceshi";//	累加0-100,测试通讯		INT
            VariableEnum.pc_yaoganmax_xzheng,//"D435.pc_yaoganmax_xzheng";//	摇杆最大值 X正向(20，100)		LREAL
            VariableEnum.pc_yaoganmax_xfu,//"D435.pc_yaoganmax_xfu";//	摇杆最大值 X负向(-20，-100)		LREAL
            VariableEnum.pc_yaoganmax_yzheng,//"D435.pc_yaoganmax_yzheng";//	摇杆最大值 Y正向(20，100)		LREAL
            VariableEnum.pc_yaoganmax_yfu,//"D435.pc_yaoganmax_yfu";//	摇杆最大值 Y负向(-20，-100)		LREAL
            VariableEnum.pc_yaoganmax_zzheng,//"D435.pc_yaoganmax_zzheng";//	摇杆最大值 Z正向(20，100)		LREAL
            VariableEnum.pc_yaoganmax_zfu,//"D435.pc_yaoganmax_zfu";//	摇杆最大值 Z负向(-20，-100)		LREAL
            VariableEnum.pc_qianhouyangan_1,//"D435.pc_qianhouyangan_1";//	X 摇杆值,范围(-100，+100)		LREAL
            VariableEnum.pc_zuoyouyaogan_1,//"D435.pc_zuoyouyaogan_1";//	Y 摇杆值,范围(-100，+100)		LREAL
            VariableEnum.pc_shangxiayaogan_1,//"D435.pc_shangxiayaogan_1";//	Z 摇杆值,范围(-100，+100)		LREAL
            VariableEnum.sys_dead_area_x,//"D435.sys_dead_area_x";//	X摇杆速度给定死区大小,上位机给定，范围（0，100）		LREAL
            VariableEnum.sys_dead_area_y,//"D435.sys_dead_area_y";//	Y摇杆速度给定死区大小,上位机给定，范围（0，100）		LREAL
            VariableEnum.sys_dead_area_z,//"SYM.D435.sys_dead_area_z";//	Z摇杆速度给定死区大小,上位机给定，范围（0，100）		LREAL
            VariableEnum.pc_yaogan_piaoyi_x,//"SYM.pc_yaogan_piaoyi_x";//	X轴摇杆 零点漂移修正（-10000，+10000）		INT
            VariableEnum.pc_yaogan_piaoyi_y,//"SYM.pc_yaogan_piaoyi_y";//	Y轴摇杆 零点漂移修正（-10000，+10000）		INT
            VariableEnum.pc_yaogan_piaoyi_z,//"SYM.pc_yaogan_piaoyi_z";//	Z轴摇杆 零点漂移修正（-10000，+10000）		INT
            VariableEnum.pc_luzhi_time,//录制时设定录制时间 INT
            VariableEnum.pc_luzhi_start,//录制开始按钮。到达录制时间，下位机自动停止录制，并且复位录制按钮。 BOOL
            VariableEnum.pc_huifang_start,//回放开始 BOOL
            VariableEnum.pc_luzhi_lengh,//根据设置的录制时间计算得出的点数 INT

            VariableEnum.zhizhen_vx,	//数据个数，指针		DINT	
            VariableEnum.pc_duqu_shuju,	//PC机读取数据开始		BOOL	
            VariableEnum.pc_shujuzushu,	//数据组数		DINT	
            VariableEnum.pc_xiachua_shuju,	//PC机下传数据开始		BOOL	
            VariableEnum.temp_vx,	//vx临时数组		Array	real
            VariableEnum.temp_vy,	//vy临时数组		Array	real
            VariableEnum.temp_vz,	//vz临时数组		Array	real
            VariableEnum.temp_zushu,	//数据读取组数		DINT	数组计数器
            VariableEnum.temp_readok,	//下位机发送完毕		BOOL	

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

            VariableEnum.sys_jiajiaojiaodu,//	103	最高夹角角度限制		LREAL	飞行允许最高点
            VariableEnum.sys_zmin,//	103	最低点Z坐标限制		LREAL	飞行允许最高点
            VariableEnum.pc_p_da,//	104	P点距AD边水平投影设定距离		LREAL	各边飞行边界
            VariableEnum.pc_p_bc ,//	105	P点距BC边水平投影设定距离		LREAL	
            VariableEnum.pc_p_ab, //	106	P点距AB边水平投影设定距离		LREAL	
            VariableEnum.pc_p_cd ,//	107	P点距CD边水平投影设定距离		LREAL	
            VariableEnum.longa, //	108	A点测量距离		LREAL	A、B、C、D、P 5点初始球坐标
            VariableEnum.longb, //	109	B点测量距离		LREAL	
            VariableEnum.longc ,//	110	C点测量距离		LREAL	
            VariableEnum.longd ,//	111	D点测量距离		LREAL	
            VariableEnum.longp, //	112	P点测量距离		LREAL	
            VariableEnum.sppj, //	113	P点水平角		LREAL	
            VariableEnum.spaj ,//	114	A点水平角		LREAL	
            VariableEnum.spbj, //	115	B点水平角		LREAL	
            VariableEnum.spcj, //	116	C点水平角		LREAL	
            VariableEnum.spdj ,//	117	D点水平角		LREAL	
            VariableEnum.yangpj, //	118	P点仰角		LREAL	
            VariableEnum.yangaj,//	119	A点仰角		LREAL	
            VariableEnum.yangdj ,//	120	D点仰角		LREAL	
            VariableEnum.yangbj ,//	121	B点仰角		LREAL	
            VariableEnum.yangcj ,//	122	C点仰角		LREAL	

            VariableEnum.xp1 ,//	123	第二次测量P点在原坐标系中的X坐标，为平台坐标赋值		LREAL	
            VariableEnum.pc_homing ,//	124	第二次测量上位机回零开关		BOOL	上位机选择回零（画面上）
            VariableEnum.yangcj2 ,//	125	第二次测量C点仰角		LREAL	A、B、C、D、P 5点          二次测量对应球坐标
            VariableEnum.yangbj2,//	126	第二次测量B点仰角		LREAL	
            VariableEnum.yangaj2 ,//	127	第二次测量A点仰角		LREAL	
            VariableEnum.yangdj2 ,//	128	第二次测量D点仰角		LREAL	
            VariableEnum.yangpj2 ,//	129	第二次测量P点仰角		LREAL	
            VariableEnum.longp2 ,//	130	第二次测量P点距离		LREAL	
            VariableEnum.longa2 ,//	131	第二次测量A点距离		LREAL	
            VariableEnum.longb2 ,//	132	第二次测量B点距离		LREAL	
            VariableEnum.longc2 ,//	133	第二次测量C点距离		LREAL	
            VariableEnum.longd2 ,//	134	第二次测量D点距离		LREAL	
            VariableEnum.sppj2 ,//	135	第二次测量P点水平角		LREAL	
            VariableEnum.spaj2 ,//	136	第二次测量A点水平角		LREAL	
            VariableEnum.spbj2,//	137	第二次测量B点水平角		LREAL	
            VariableEnum.spcj2,//	138	第二次测量C点水平角		LREAL	
            VariableEnum.spdj2,//	139	第二次测量D点水平角		LREAL	

            VariableEnum.xp0,//	云台的初始坐标X轴   LREAL
            VariableEnum.yp0,//	云台的初始坐标Y轴   LREAL	
            VariableEnum.zp0,//	云台的初始坐标Z轴   LREAL

            VariableEnum.sys_tm3101_jiance,//	1号TM31通讯断开	BOOL
            VariableEnum.sys_tm3102_jiance,//	2号TM31通讯断开	BOOL
            VariableEnum.no5_alm,//	1号主伺服报警号	INT
            VariableEnum.no5_cu_alm,//	1号主控制器报警号	INT
            VariableEnum.no6_alm,//	2号主伺服报警号	INT
            VariableEnum.no6_cu_alm,//	2号主控制器报警号	INT
            VariableEnum.no7_alm,//	3号主伺服报警号	INT
            VariableEnum.no7_cu_alm,//	3号主控制器报警号	INT
            VariableEnum.no8_alm,//	4号主伺服报警号	INT
            VariableEnum.no8_cu_alm,//	4号主控制器报警号	INT
            VariableEnum.no1_cu0_alm,//	D435集成控制器报警号	INT
            VariableEnum.no2_tm31_alm_1,//	1号TM31报警号	INT
            VariableEnum.no2_tm31_alm_2,//	2号TM31报警号	INT

            VariableEnum.bz_keyiyunxing ,//各轴误差正常 BOOL

            VariableEnum.pc_homing_jiaodui,//	二次回零是否完成 BOOL
        };

        /// <summary>
        /// 所有数据集合
        /// </summary>
        public static Array Data
        {
            get { return myopc.Data; }
        }

        /// <summary>
        /// 状态标志数据集合
        /// </summary>
        public static Array SysStateData
        {
            get { return myopc.SysStateData; }
        }

        /// <summary>
        /// 获取状态标志数据类
        /// </summary>
        public static OPCOperate.MyOPC.FlyCat_SysState SysStateClass
        {
            get { return myopc.SysStateClass; }
        }

        /// <summary>
        /// 实时坐标数据集合
        /// </summary>
        public static Array PointXYZData
        {
            get { return myopc.PointXYZData; }
        }

        /// <summary>
        /// 获取实时坐标数据类
        /// </summary>
        public static OPCOperate.MyOPC.FlyCat_PointXYZ PointXYZClass
        {
            get { return myopc.PointXYZClass; }
        }

        /// <summary>
        /// 获取数据项的数据类型
        /// </summary>
        public static Type[] ItemType
        {
            get {return myopc.ItemType; }
        }

        /// <summary>
        /// 获取数据项的数组索引
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public static int GetItemIndex(string itemID)
        {
            return myopc.GetItemIndex(itemID);
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        public static bool Connection()
        {
            return myopc.OPCConnection(ip, name, VariableNames);
            //return myopc.OPCConnection(ip, name);
        }

        /// <summary>
        /// 读数据
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public static string ReadData(string variable)
        {
            return myopc.OPCReadData(variable);
        }

        /// <summary>
        /// 读多个数据
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public static string[] ReadData(string[] variable)
        {
            return myopc.OPCReadData(variable);
        }

        /// <summary>
        /// 写数据
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool WriteData(string variable, string value)
        {
            return myopc.OPCWriteData(variable,value);
        }

        /// <summary>
        /// 写多个数据
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool WriteData(string[] variable, string[] value)
        {
            return myopc.OPCWriteData(variable, value);
        }

        /// <summary>
        /// 查看opc服务是否连接
        /// </summary>
        /// <returns></returns>
        public static bool IsConnected()
        {
            return myopc.Connection;
        }
    }
}
