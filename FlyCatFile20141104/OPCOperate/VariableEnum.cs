using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPCOperate
{
    /// <summary>
    /// 所有变量枚举
    /// </summary>
    //public class VariableEnum
    //{

    //    //控制器IP地址192.168.0.100	控制器IP地址192.168.0.100						
    //    //控制器控制四台电机A、B、C、D四个站，逆时针排布	控制器控制四台电机A、B、C、D四个站，逆时针排布						
    //    //吊装飞行物（摄像机）用P站表示	吊装飞行物（摄像机）用P站表示						
    //    //变量名称	变量名称	,//	序号	解释	控制器地址	数据类型	含义

    //    /**************************************************************************
    //     *状态显示，只读变量
    //    **************************************************************************/
    //    public static string statu_no5_enable_ok = "\\SYM:\\D435.statu_no5_enable_ok";//	1	A站电机使能OK	PI377.2	BOOL	电机A、B、C、D激活状态
    //    public static string statu_no6_enable_ok = "\\SYM:\\D435.statu_no6_enable_ok";//	2	B站电机使能OK	PI397.2	BOOL	
    //    public static string statu_no7_enable_ok = "\\SYM:\\D435.statu_no7_enable_ok";//	3	C站电机使能OK	PI417.2	BOOL	
    //    public static string statu_no8_enable_ok = "\\SYM:\\D435.statu_no8_enable_ok";//	4	D站电机使能OK	PI437.2	BOOL	
    //    public static string statu_no5_error = "\\SYM:\\D435.statu_no5_error";//	5	A站错误		BOOL	
    //    public static string statu_no6_error = "\\SYM:\\D435.statu_no6_error";//	6	B站错误		BOOL	
    //    public static string statu_no7_error = "\\SYM:\\D435.statu_no7_error";//	7	C站错误		BOOL	
    //    public static string statu_no8_error = "\\SYM:\\D435.statu_no8_error";//	8	D站错误		BOOL	
    //    public static string statu_no5_tongxun = "\\SYM:\\D435.sys_drive_jiance_1";//"\\SYM:\\D435.statu_no5_tongxun";//(2013.3.11改)9	A站通讯故障		BOOL	
    //    public static string statu_no6_tongxun = "\\SYM:\\D435.sys_drive_jiance_2";//"\\SYM:\\D435.statu_no6_tongxun";//(2013.3.11改)10	B站通讯故障		BOOL	
    //    public static string statu_no7_tongxun = "\\SYM:\\D435.sys_drive_jiance_3";//"\\SYM:\\D435.statu_no7_tongxun";//(2013.3.11改)11	C站通讯故障		BOOL	
    //    public static string statu_no8_tongxun = "\\SYM:\\D435.sys_drive_jiance_4";//"\\SYM:\\D435.statu_no8_tongxun";//(2013.3.11改)12	D站通讯故障		BOOL

    //    public static string do_5haobaozha = "\\SYM:\\D435.do_5haobaozha";//	13	A站电机抱闸控制	PQ298.1	BOOL	电机A、B、C、D报闸         打开关闭状态
    //    public static string do_6haobaozha = "\\SYM:\\D435.do_6haobaozha";//	14	B站电机抱闸控制	PQ318.1	BOOL	
    //    public static string do_7haobaozha = "\\SYM:\\D435.do_7haobaozha";//	15	C站电机抱闸控制	PQ338.1	BOOL	
    //    public static string do_8haobaozha = "\\SYM:\\D435.do_8haobaozha";//	16	D站电机抱闸控制	PQ358.1	BOOL	  
    //    public static string do_5haojiechuqi = "\\SYM:\\D435.do_5haojiechuqi";//	17	A站接触器吸合		BOOL	
    //    public static string do_6haojiechuqi = "\\SYM:\\D435.do_6haojiechuqi";//	18	B站接触器吸合		BOOL	
    //    public static string do_7haojiechuqi = "\\SYM:\\D435.do_7haojiechuqi";//	19	C站接触器吸合		BOOL	
    //    public static string do_8haojiechuqi = "\\SYM:\\D435.do_8haojiechuqi";//	20	D站接触器吸合		BOOL	

    //    public static string di_jinjitingche = "\\SYM:\\D435.di_jinjitingche";//	21	紧急停止按钮（总）	PI257.0	BOOL	紧急停车状态（操作台）
    //    public static string di_enable = "\\SYM:\\D435.di_enable";//	22	控制系统使能（激活）按钮	PI257.1	BOOL	
    //    public static string di_5haojog = "\\SYM:\\D435.di_5haojog";//	23	A站电机点动按钮	PI257.4	BOOL	A站操作盒
    //    public static string di_6haojog = "\\SYM:\\D435.di_6haojog";//	24	B站电机点动按钮	PI257.5	BOOL	B站操作盒
    //    public static string di_7haojog = "\\SYM:\\D435.di_7haojog";//	25	C站电机点动按钮	PI257.6	BOOL	C站操作盒
    //    public static string di_8haojog = "\\SYM:\\D435.di_8haojog";//	26	D站电机点动按钮	PI257.7	BOOL	D站操作盒
    //    public static string di_ack = "\\SYM:\\D435.di_ack";//	27	故障复位按钮	PI257.2	BOOL	操作台控制盒
    //    public static string di_auto_man = "\\SYM:\\D435.di_auto_man";//	28	手动/自动转换按钮	PI257.3	BOOL	操作台控制盒
    //    public static string di_auto_start = "\\SYM:\\D435.di_auto_start";//	29	启动按钮	PI267.0	BOOL	操作台控制盒
    //    public static string di_homeing01 = "\\SYM:\\D435.di_homeing01";//	30	系统回零按钮1	PI267.1	BOOL	操作台控制盒
    //    public static string di_homeing02 = "\\SYM:\\D435.di_homeing02";//	31	系统回零按钮2	PI267.2	BOOL	操作台控制盒
    //    public static string di_jiudijizhong = "\\SYM:\\D435.di_jiudijizhong";//	32	就地控制按钮	PI267.3	BOOL	操作台控制盒
    //    public static string di_8haoshoudong = "\\SYM:\\D435.di_8haoshoudong";//	33	操作台D站手动按钮	PI358.3	BOOL	操作台控制盒
    //    public static string di_7haoshoudong = "\\SYM:\\D435.di_7haoshoudong";//	34	操作台C站手动按钮	PI338.3	BOOL	操作台控制盒
    //    public static string di_6haoshoudong = "\\SYM:\\D435.di_6haoshoudong";//	35	操作台B站手动按钮	PI318.3	BOOL	操作台控制盒
    //    public static string di_5haoshoudong = "\\SYM:\\D435.di_5haoshoudong";//	36	操作台A站手动按钮	PI298.3	BOOL	操作台控制盒
    //    public static string di_5jiting = "\\SYM:\\D435.di_5jiting";//	37	A站急停按钮	PI298.0	BOOL	A站操作盒
    //    public static string di_6jiting = "\\SYM:\\D435.di_6jiting";//	38	B站急停按钮	PI318.0	BOOL	B站操作盒
    //    public static string di_7jiting = "\\SYM:\\D435.di_7jiting";//	39	C站急停按钮	PI338.0	BOOL	C站操作盒
    //    public static string di_8jiting = "\\SYM:\\D435.di_8jiting";//	40	D站急停按钮	PI358.0	BOOL	A站操作盒
    //    public static string di_5zhidongjiance = "\\SYM:\\D435.di_5zhidongjiance";//	41	A站制动检测开关	PI299.0	BOOL	
    //    public static string di_6zhidongjiance = "\\SYM:\\D435.di_6zhidongjiance";//	42	B站制动检测开关	PI319.0	BOOL	
    //    public static string di_7zhidongjiance = "\\SYM:\\D435.di_7zhidongjiance";//	43	C站制动检测开关	PI339.0	BOOL	
    //    public static string di_8zhidongjiance = "\\SYM:\\D435.di_8zhidongjiance";//	44	D站制动检测开关	PI359.0	BOOL	
    //    public static string di_5shoushengjiance = "\\SYM:\\D435.di_5shoushengjiance";//	45	A站收绳检测开关	PI299.1	BOOL	
    //    public static string di_6shoushengjiance = "\\SYM:\\D435.di_6shoushengjiance";//	46	B站收绳检测开关	PI319.1	BOOL	
    //    public static string di_7shoushengjiance = "\\SYM:\\D435.di_7shoushengjiance";//	47	C站收绳检测开关	PI339.1	BOOL	
    //    public static string di_8shoushengjiance = "\\SYM:\\D435.di_8shoushengjiance";//	48	D站收绳检测开关	PI359.1	BOOL

    //    public static string no5_torque = "\\SYM:\\D435.no5_torque";//84 A站扭矩   LREAL
    //    public static string no6_torque = "\\SYM:\\D435.no6_torque";//85 B站扭矩   LREAL
    //    public static string no7_torque = "\\SYM:\\D435.no7_torque";//86 C站扭矩   LREAL
    //    public static string no8_torque = "\\SYM:\\D435.no8_torque";//87 D站扭矩   LREAL

    //    /**************************************************************************
    //     *控制功能，读写变量
    //    **************************************************************************/
    //    public static string pc_qufanzfangxian = "\\SYM:\\D435.pc_qufanzfangxiang";//	49	取反上下摇杆方向		BOOL	

    //    public static string pc_jog_fangshen = "\\SYM:\\D435.pc_jog_fangshen";//	50	上位机点动放绳按钮		BOOL	上位机（画面上）
    //    public static string pc_jog_shoushen = "\\SYM:\\D435.pc_jog_shoushen";//	51	上位机点动收绳		BOOL	上位机（画面上）
    //    public static string pc_man_tiaozhen = "\\SYM:\\D435.pc_man_tiaozhen";//	52	上位机进入手动调整状态		BOOL	上位机操作（画面上）
    //    public static string pc_yaogan_enable = "\\SYM:\\D435.pc_yaogan_enable";//	53	上位机禁用启用摇杆		BOOL	上位机操作（画面上）

    //    public static string pc_5haojog = "\\SYM:\\D435.pc_5haojog";//	选中“电机1”		BOOL	上位机操作（画面上）
    //    public static string pc_6haojog = "\\SYM:\\D435.pc_6haojog";//	选中“电机2”		BOOL	上位机操作（画面上）
    //    public static string pc_7haojog = "\\SYM:\\D435.pc_7haojog";//	选中“电机3”		BOOL	上位机操作（画面上）
    //    public static string pc_8haojog = "\\SYM:\\D435.pc_8haojog";//	选中“电机4”		BOOL	上位机操作（画面上）

    //    public static string sys_backtochushidian = "\\SYM:\\D435.sys_backtochushidian";//	54	回回放路径初始点		BOOL	上位机操作（画面上）
    //    public static string sys_backwancheng = "\\SYM:\\D435.sys_backwancheng";//	55	回回放路径初始点完成		BOOL	上位机操作（画面上）
    //    public static string sys_replay = "\\SYM:\\D435.sys_replay";//	56	是否处于回放状态		BOOL	上位机操作（画面上）

    //    public static string vh = "\\SYM:\\D435.vh";//	57	回回放零点时的速度基准		LREAL	
    //    public static string xh = "\\SYM:\\D435.xh";//	58	回放起点X坐标		LREAL	
    //    public static string yh = "\\SYM:\\D435.yh";//	59	回放起点Y坐标		LREAL	
    //    public static string zh = "\\SYM:\\D435.zh";//	60	回放起点Z坐标		LREAL	
    //    public static string pc_hf_vx = "\\SYM:\\D435.pc_hf_vx";//	61	回放时上位机给的运动信号 X方向		LREAL	
    //    public static string pc_hf_vy = "\\SYM:\\D435.pc_hf_vy";//	62	回放时上位机给的运动信号 Y方向		LREAL	
    //    public static string pc_hf_vz = "\\SYM:\\D435.pc_hf_vz";//	63	回放时上位机给的运动信号 Z方向		LREAL	
    //    public static string pc_jl_vx = "\\SYM:\\D435.pc_jl_vx";//	64	录制信号 X方向		LREAL	
    //    public static string pc_jl_vy = "\\SYM:\\D435.pc_jl_vy";//	65	录制信号 Y方向		LREAL	
    //    public static string pc_jl_vz = "\\SYM:\\D435.pc_jl_vz";//	66	录制信号 Z方向		LREAL	

    //    public static string hmi_ack = "\\SYM:\\D435.hmi_ack";//	67	上位机故障复位按钮		BOOL	上位机操作（画面上）
    //    public static string sys_xyxuanzhuanjiaodu = "\\SYM:\\D435.sys_xyxuanzhuanjiaodu";//	68	坐标旋转角度		LREAL	坐标旋转
    //    public static string sys_xiepozhengliang = "\\SYM:\\D435.sys_xiepozhengliang";//	69	速度斜坡控制增量		LREAL	摇杆灵敏度
    //    public static string pc_pintai_vmax = "\\SYM:\\D435.pc_pintai_vmax";//	70	P点移动最快速度		LREAL	
    //    public static string pc_shoudongsudugeiding = "\\SYM:\\D435.pc_shoudongsudugeiding";//	71	上位机手动速度给定		LREAL	
    //    public static string pc_yaoganlingmingdu = "\\SYM:\\D435.pc_yaoganlingmingdu";//	72	摇杆灵敏度，范围：0-10		LREAL	
    //    public static string sys_shouxianxishu = "\\SYM:\\D435.sys_shouxianxishu";//	73	计算垂直于各边速度时的系数		LREAL	

    //    public static string long_a_gaodu = "\\SYM:\\D435.long_a_gaodu";//	74	A站高度		LREAL	
    //    public static string long_ab_kuandu = "\\SYM:\\D435.long_ab_kuandu";//	75	AB站水平宽度		LREAL	
    //    public static string long_b_gaodu = "\\SYM:\\D435.long_b_gaodu";//	76	B站高度		LREAL	
    //    public static string long_bc_kuandu = "\\SYM:\\D435.long_bc_kuandu";//	77	BC站水平宽度		LREAL	
    //    public static string long_c_gaodu = "\\SYM:\\D435.long_c_gaodu";//	78	C站高度		LREAL	
    //    public static string long_cd_kuandu = "\\SYM:\\D435.long_cd_kuandu";//	79	CD站水平宽度		LREAL	
    //    public static string long_d_gaodu = "\\SYM:\\D435.long_d_gaodu";//	80	D站高度		LREAL	
    //    public static string long_da_kuandu = "\\SYM:\\D435.long_da_kuandu";//	81	DA站水平宽度		LREAL	
    //    public static string long_quanzhanyigaodu = "\\SYM:\\D435.long_quanzhanyigaodu";//	82	全站仪高度设定		LREAL	
    //    public static string pc_qubieabcd = "\\SYM:\\D435.pc_qubieabcd";//	83	上位机区别测量的是AP、BP、CP或DP		BYTE	二次测量电机选择 0A 1B 2C 3D

    //    public static string pc_yaoganlingmingdu_z = "\\SYM:\\D435.pc_yaoganlingmingdu_z";//	Z轴摇杆灵敏度，范围：0-10		LREAL
    //    public static string sys_xiepozhengliang_z = "\\SYM:\\D435.sys_xiepozhengliang_z";//	Z轴速度斜坡控制增量		LREAL
    //    public static string pc_pintai_vmax_z = "\\SYM:\\D435.pc_pintai_vmax_z";//	Z移动最快速度		LREAL
    //    public static string pc_tongxunceshi = "\\SYM:\\D435.pc_tongxunceshi";//	累加0-100,测试通讯		INT
    //    public static string pc_yaoganmax_xzheng = "\\SYM:\\D435.pc_yaoganmax_xzheng";//	摇杆最大值 X正向(20，100)		LREAL
    //    public static string pc_yaoganmax_xfu = "\\SYM:\\D435.pc_yaoganmax_xfu";//	摇杆最大值 X负向(-20，-100)		LREAL
    //    public static string pc_yaoganmax_yzheng = "\\SYM:\\D435.pc_yaoganmax_yzheng";//	摇杆最大值 Y正向(20，100)		LREAL
    //    public static string pc_yaoganmax_yfu = "\\SYM:\\D435.pc_yaoganmax_yfu";//	摇杆最大值 Y负向(-20，-100)		LREAL
    //    public static string pc_yaoganmax_zzheng = "\\SYM:\\D435.pc_yaoganmax_zzheng";//	摇杆最大值 Z正向(20，100)		LREAL
    //    public static string pc_yaoganmax_zfu = "\\SYM:\\D435.pc_yaoganmax_zfu";//	摇杆最大值 Z负向(-20，-100)		LREAL
    //    public static string pc_qianhouyangan_1 = "\\SYM:\\D435.pc_qianhouyangan_1";//	X 摇杆值,范围(-100，+100)		LREAL
    //    public static string pc_zuoyouyaogan_1 = "\\SYM:\\D435.pc_zuoyouyaogan_1";//	Y 摇杆值,范围(-100，+100)		LREAL
    //    public static string pc_shangxiayaogan_1 = "\\SYM:\\D435.pc_shangxiayaogan_1";//	Z 摇杆值,范围(-100，+100)		LREAL
    //    public static string sys_dead_area_x = "\\SYM:\\D435.sys_dead_area_x";//	X摇杆速度给定死区大小,上位机给定，范围（0，100）		LREAL
    //    public static string sys_dead_area_y = "\\SYM:\\D435.sys_dead_area_y";//	Y摇杆速度给定死区大小,上位机给定，范围（0，100）		LREAL
    //    public static string sys_dead_area_z = "\\SYM:\\D435.sys_dead_area_z";//	Z摇杆速度给定死区大小,上位机给定，范围（0，100）		LREAL
    //    public static string pc_yaogan_piaoyi_x = "\\SYM:\\D435.pc_yaogan_piaoyi_x";//	X轴摇杆 零点漂移修正（-10000，+10000）		INT
    //    public static string pc_yaogan_piaoyi_y = "\\SYM:\\D435.pc_yaogan_piaoyi_y";//	Y轴摇杆 零点漂移修正（-10000，+10000）		INT
    //    public static string pc_yaogan_piaoyi_z = "\\SYM:\\D435.pc_yaogan_piaoyi_z";//	Z轴摇杆 零点漂移修正（-10000，+10000）		INT
    //    public static string pc_luzhi_time = "\\SYM:\\D435.pc_luzhi_time";//录制时设定录制时间 INT
    //    public static string pc_luzhi_start = "\\SYM:\\D435.pc_luzhi_start";//录制开始按钮。到达录制时间，下位机自动停止录制，并且复位录制按钮。 BOOL
    //    public static string pc_huifang_start = "\\SYM:\\D435.pc_huifang_start";//回放开始 BOOL
    //    public static string pc_luzhi_lengh = "\\SYM:\\D435.pc_luzhi_lengh";//根据设置的录制时间计算得出的点数 INT

    //    public static string zhizhen_vx = "\\SYM:\\D435.zhizhen_vx";	//数据个数，指针		DINT	
    //    public static string pc_duqu_shuju = "\\SYM:\\D435.pc_duqu_shuju";	//PC机读取数据开始		BOOL	
    //    public static string pc_shujuzushu = "\\SYM:\\D435.pc_shujuzushu";	//数据组数		DINT	
    //    public static string pc_xiachua_shuju = "\\SYM:\\D435.pc_xiachua_shuju";	//PC机下传数据开始		BOOL	
    //    public static string temp_vx = "\\SYM:\\D435.readwrite.temp_vx";	//vx临时数组		Array	real
    //    public static string temp_vy = "\\SYM:\\D435.readwrite.temp_vy";	//vy临时数组		Array	real
    //    public static string temp_vz = "\\SYM:\\D435.readwrite.temp_vz";	//vz临时数组		Array	real
    //    public static string temp_zushu = "\\SYM:\\D435.readwrite.temp_zushu";	//数据读取组数		DINT	数组计数器
    //    public static string temp_readok = "\\SYM:\\D435.readwrite.temp_readok";	//下位机发送完毕		BOOL	



    //    /**************************************************************************
    //     *实时坐标值，只读变量
    //    **************************************************************************/
    //    public static string xp = "\\SYM:\\D435.xp";//	88	P点X轴坐标		LREAL	平台坐标
    //    public static string yp = "\\SYM:\\D435.yp";//	89	P点Y轴坐标		LREAL	
    //    public static string zp = "\\SYM:\\D435.zp";//	90	P点Z轴坐标		LREAL	
    //    public static string xa = "\\SYM:\\D435.xa";//	91	A点X轴坐标		LREAL	A坐标
    //    public static string ya = "\\SYM:\\D435.ya";//	92	A点Y轴坐标		LREAL	
    //    public static string za = "\\SYM:\\D435.za";//	93	A点Z轴坐标		LREAL	
    //    public static string xb = "\\SYM:\\D435.xb";//	94	B点X轴坐标		LREAL	B坐标
    //    public static string yb = "\\SYM:\\D435.yb";//	95	B点Y轴坐标		LREAL	
    //    public static string zb = "\\SYM:\\D435.zb";//	96	B点Z轴坐标		LREAL	
    //    public static string xc = "\\SYM:\\D435.xc";//	97	C点X轴坐标		LREAL	C坐标
    //    public static string yc = "\\SYM:\\D435.yc";//	98	C点Y轴坐标		LREAL	
    //    public static string zc = "\\SYM:\\D435.zc";//	99	C点Z轴坐标		LREAL	
    //    public static string xd = "\\SYM:\\D435.xd";//	100	D点X轴坐标		LREAL	D坐标
    //    public static string yd = "\\SYM:\\D435.yd";//	101	D点Y轴坐标		LREAL	
    //    public static string zd = "\\SYM:\\D435.zd";//	102	D点Z轴坐标		LREAL	

    //    /**************************************************************************
    //     *初始设置，读写变量
    //    **************************************************************************/
    //    public static string sys_jiajiaojiaodu = "\\SYM:\\D435.sys_jiajiaojiaodu";//	103	最高夹角角度限制		LREAL	飞行允许最高点
    //    public static string sys_zmin = "\\SYM:\\D435.sys_zdixian";//	103	最低点Z坐标限制		LREAL	飞行允许最低点
    //    public static string pc_p_da = "\\SYM:\\D435.pc_p_da";//	104	P点距AD边水平投影设定距离		LREAL	各边飞行边界
    //    public static string pc_p_bc = "\\SYM:\\D435.pc_p_bc";//	105	P点距BC边水平投影设定距离		LREAL	
    //    public static string pc_p_ab = "\\SYM:\\D435.pc_p_ab";//	106	P点距AB边水平投影设定距离		LREAL	
    //    public static string pc_p_cd = "\\SYM:\\D435.pc_p_cd";//	107	P点距CD边水平投影设定距离		LREAL	
    //    public static string longa = "\\SYM:\\D435.longa";//	108	A点测量距离		LREAL	A、B、C、D、P 5点初始球坐标
    //    public static string longb = "\\SYM:\\D435.longb";//	109	B点测量距离		LREAL	
    //    public static string longc = "\\SYM:\\D435.longc";//	110	C点测量距离		LREAL	
    //    public static string longd = "\\SYM:\\D435.longd";//	111	D点测量距离		LREAL	
    //    public static string longp = "\\SYM:\\D435.longp";//	112	P点测量距离		LREAL	
    //    public static string sppj = "\\SYM:\\D435.sppj";//	113	P点水平角		LREAL	
    //    public static string spaj = "\\SYM:\\D435.spaj";//	114	A点水平角		LREAL	
    //    public static string spbj = "\\SYM:\\D435.spbj";//	115	B点水平角		LREAL	
    //    public static string spcj = "\\SYM:\\D435.spcj";//	116	C点水平角		LREAL	
    //    public static string spdj = "\\SYM:\\D435.spdj";//	117	D点水平角		LREAL	
    //    public static string yangpj = "\\SYM:\\D435.yangpj";//	118	P点仰角		LREAL	
    //    public static string yangaj = "\\SYM:\\D435.yangaj";//	119	A点仰角		LREAL	
    //    public static string yangdj = "\\SYM:\\D435.yangdj";//	120	D点仰角		LREAL	
    //    public static string yangbj = "\\SYM:\\D435.yangbj";//	121	B点仰角		LREAL	
    //    public static string yangcj = "\\SYM:\\D435.yangcj";//	122	C点仰角		LREAL	

    //    public static string xp0 = "\\SYM:\\D435.xp0";//	云台的初始坐标X轴   LREAL
    //    public static string yp0 = "\\SYM:\\D435.yp0";//	云台的初始坐标Y轴   LREAL	
    //    public static string zp0 = "\\SYM:\\D435.zp0";//	云台的初始坐标Z轴   LREAL

    //    public static string xp1 = "\\SYM:\\D435.xp1";//	123	第二次测量P点在原坐标系中的X坐标，为平台坐标赋值		LREAL	
    //    public static string pc_homing = "\\SYM:\\D435.pc_homing";//	124	第二次测量上位机回零开关		BOOL	上位机选择回零（画面上）
    //    public static string yangcj2 = "\\SYM:\\D435.yangcj2";//	125	第二次测量C点仰角		LREAL	A、B、C、D、P 5点          二次测量对应球坐标
    //    public static string yangbj2 = "\\SYM:\\D435.yangbj2";//	126	第二次测量B点仰角		LREAL	
    //    public static string yangaj2 = "\\SYM:\\D435.yangaj2";//	127	第二次测量A点仰角		LREAL	
    //    public static string yangdj2 = "\\SYM:\\D435.yangdj2";//	128	第二次测量D点仰角		LREAL	
    //    public static string yangpj2 = "\\SYM:\\D435.yangpj2";//	129	第二次测量P点仰角		LREAL	
    //    public static string longp2 = "\\SYM:\\D435.longp2";//	130	第二次测量P点距离		LREAL	
    //    public static string longa2 = "\\SYM:\\D435.longa2";//	131	第二次测量A点距离		LREAL	
    //    public static string longb2 = "\\SYM:\\D435.longb2";//	132	第二次测量B点距离		LREAL	
    //    public static string longc2 = "\\SYM:\\D435.longc2";//	133	第二次测量C点距离		LREAL	
    //    public static string longd2 = "\\SYM:\\D435.longd2";//	134	第二次测量D点距离		LREAL	
    //    public static string sppj2 = "\\SYM:\\D435.sppj2";//	135	第二次测量P点水平角		LREAL	
    //    public static string spaj2 = "\\SYM:\\D435.spaj2";//	136	第二次测量A点水平角		LREAL	
    //    public static string spbj2 = "\\SYM:\\D435.spbj2";//	137	第二次测量B点水平角		LREAL	
    //    public static string spcj2 = "\\SYM:\\D435.spcj2";//	138	第二次测量C点水平角		LREAL	
    //    public static string spdj2 = "\\SYM:\\D435.spdj2";//	139	第二次测量D点水平角		LREAL	

    //    public static string pc_homing_jiaodui = "\\SYM:\\D435.pc_homing_jiaodui";//	二次回零是否完成 BOOL	

    //    //报警信息查看（2013.3.10）
    //    public static string sys_tm3101_jiance = "\\SYM:\\D435.sys_tm3101_jiance";//	1号TM31通讯断开	BOOL
    //    public static string sys_tm3102_jiance = "\\SYM:\\D435.sys_tm3102_jiance";//	2号TM31通讯断开	BOOL
    //    public static string no5_alm = "\\SYM:\\D435.no5_alm";//	1号主伺服报警号	INT
    //    public static string no5_cu_alm = "\\SYM:\\D435.no5_cu_alm";//	1号主控制器报警号	INT
    //    public static string no6_alm = "\\SYM:\\D435.no6_alm";//	2号主伺服报警号	INT
    //    public static string no6_cu_alm = "\\SYM:\\D435.no6_cu_alm";//	2号主控制器报警号	INT
    //    public static string no7_alm = "\\SYM:\\D435.no7_alm";//	3号主伺服报警号	INT
    //    public static string no7_cu_alm = "\\SYM:\\D435.no7_cu_alm";//	3号主控制器报警号	INT
    //    public static string no8_alm = "\\SYM:\\D435.no8_alm";//	4号主伺服报警号	INT
    //    public static string no8_cu_alm = "\\SYM:\\D435.no8_cu_alm";//	4号主控制器报警号	INT
    //    public static string no1_cu0_alm = "\\SYM:\\D435.no1_cu0_alm";//	D435集成控制器报警号	INT
    //    public static string no2_tm31_alm_1 = "\\SYM:\\D435.no2_tm31_alm_1";//	1号TM31报警号	INT
    //    public static string no2_tm31_alm_2 = "\\SYM:\\D435.no2_tm31_alm_2";//	2号TM31报警号	INT

    //    public static string bz_keyiyunxing = "\\SYM:\\D435.bz_keyiyunxing";//各轴误差正常 BOOL

    //}

    //public class VariableEnum
    //{

    //    //控制器IP地址192.168.0.100	控制器IP地址192.168.0.100						
    //    //控制器控制四台电机A、B、C、D四个站，逆时针排布	控制器控制四台电机A、B、C、D四个站，逆时针排布						
    //    //吊装飞行物（摄像机）用P站表示	吊装飞行物（摄像机）用P站表示						
    //    //变量名称	变量名称	,//	序号	解释	控制器地址	数据类型	含义

    //    /**************************************************************************
    //     *状态显示，只读变量
    //    **************************************************************************/
    //    public static string statu_no5_enable_ok = "D435.statu_no5_enable_ok";//	1	A站电机使能OK	PI377.2	BOOL	电机A、B、C、D激活状态
    //    public static string statu_no6_enable_ok = "D435.statu_no6_enable_ok";//	2	B站电机使能OK	PI397.2	BOOL	
    //    public static string statu_no7_enable_ok = "D435.statu_no7_enable_ok";//	3	C站电机使能OK	PI417.2	BOOL	
    //    public static string statu_no8_enable_ok = "D435.statu_no8_enable_ok";//	4	D站电机使能OK	PI437.2	BOOL	
    //    public static string statu_no5_error = "D435.statu_no5_error";//	5	A站错误		BOOL	
    //    public static string statu_no6_error = "D435.statu_no6_error";//	6	B站错误		BOOL	
    //    public static string statu_no7_error = "D435.statu_no7_error";//	7	C站错误		BOOL	
    //    public static string statu_no8_error = "D435.statu_no8_error";//	8	D站错误		BOOL	
    //    public static string statu_no5_tongxun = "D435.statu_no5_tongxun";//	9	A站通讯故障		BOOL	
    //    public static string statu_no6_tongxun = "D435.statu_no6_tongxun";//	10	B站通讯故障		BOOL	
    //    public static string statu_no7_tongxun = "D435.statu_no7_tongxun";//	11	C站通讯故障		BOOL	
    //    public static string statu_no8_tongxun = "D435.statu_no8_tongxun";//	12	D站通讯故障		BOOL

    //    public static string do_5haobaozha = "D435.do_5haobaozha";//	13	A站电机抱闸控制	PQ298.1	BOOL	电机A、B、C、D报闸         打开关闭状态
    //    public static string do_6haobaozha = "D435.do_6haobaozha";//	14	B站电机抱闸控制	PQ318.1	BOOL	
    //    public static string do_7haobaozha = "D435.do_7haobaozha";//	15	C站电机抱闸控制	PQ338.1	BOOL	
    //    public static string do_8haobaozha = "D435.do_8haobaozha";//	16	D站电机抱闸控制	PQ358.1	BOOL	  
    //    public static string do_5haojiechuqi = "D435.do_5haojiechuqi";//	17	A站接触器吸合		BOOL	
    //    public static string do_6haojiechuqi = "D435.do_6haojiechuqi";//	18	B站接触器吸合		BOOL	
    //    public static string do_7haojiechuqi = "D435.do_7haojiechuqi";//	19	C站接触器吸合		BOOL	
    //    public static string do_8haojiechuqi = "D435.do_8haojiechuqi";//	20	D站接触器吸合		BOOL	

    //    public static string di_jinjitingche = "D435.di_jinjitingche";//	21	紧急停止按钮（总）	PI257.0	BOOL	紧急停车状态（操作台）
    //    public static string di_enable = "D435.di_enable";//	22	控制系统使能（激活）按钮	PI257.1	BOOL	
    //    public static string di_5haojog = "D435.di_5haojog";//	23	A站电机点动按钮	PI257.4	BOOL	A站操作盒
    //    public static string di_6haojog = "D435.di_6haojog";//	24	B站电机点动按钮	PI257.5	BOOL	B站操作盒
    //    public static string di_7haojog = "D435.di_7haojog";//	25	C站电机点动按钮	PI257.6	BOOL	C站操作盒
    //    public static string di_8haojog = "D435.di_8haojog";//	26	D站电机点动按钮	PI257.7	BOOL	D站操作盒
    //    public static string di_ack = "D435.di_ack";//	27	故障复位按钮	PI257.2	BOOL	操作台控制盒
    //    public static string di_auto_man = "D435.di_auto_man";//	28	手动/自动转换按钮	PI257.3	BOOL	操作台控制盒
    //    public static string di_auto_start = "D435.di_auto_start";//	29	启动按钮	PI267.0	BOOL	操作台控制盒
    //    public static string di_homeing01 = "D435.di_homeing01";//	30	系统回零按钮1	PI267.1	BOOL	操作台控制盒
    //    public static string di_homeing02 = "D435.di_homeing02";//	31	系统回零按钮2	PI267.2	BOOL	操作台控制盒
    //    public static string di_jiudijizhong = "D435.di_jiudijizhong";//	32	就地控制按钮	PI267.3	BOOL	操作台控制盒
    //    public static string di_8haoshoudong = "D435.di_8haoshoudong";//	33	操作台D站手动按钮	PI358.3	BOOL	操作台控制盒
    //    public static string di_7haoshoudong = "D435.di_7haoshoudong";//	34	操作台C站手动按钮	PI338.3	BOOL	操作台控制盒
    //    public static string di_6haoshoudong = "D435.di_6haoshoudong";//	35	操作台B站手动按钮	PI318.3	BOOL	操作台控制盒
    //    public static string di_5haoshoudong = "D435.di_5haoshoudong";//	36	操作台A站手动按钮	PI298.3	BOOL	操作台控制盒
    //    public static string di_5jiting = "D435.di_5jiting";//	37	A站急停按钮	PI298.0	BOOL	A站操作盒
    //    public static string di_6jiting = "D435.di_6jiting";//	38	B站急停按钮	PI318.0	BOOL	B站操作盒
    //    public static string di_7jiting = "D435.di_7jiting";//	39	C站急停按钮	PI338.0	BOOL	C站操作盒
    //    public static string di_8jiting = "D435.di_8jiting";//	40	D站急停按钮	PI358.0	BOOL	A站操作盒
    //    public static string di_5zhidongjiance = "D435.di_5zhidongjiance";//	41	A站制动检测开关	PI299.0	BOOL	
    //    public static string di_6zhidongjiance = "D435.di_6zhidongjiance";//	42	B站制动检测开关	PI319.0	BOOL	
    //    public static string di_7zhidongjiance = "D435.di_7zhidongjiance";//	43	C站制动检测开关	PI339.0	BOOL	
    //    public static string di_8zhidongjiance = "D435.di_8zhidongjiance";//	44	D站制动检测开关	PI359.0	BOOL	
    //    public static string di_5shoushengjiance = "D435.di_5shoushengjiance";//	45	A站收绳检测开关	PI299.1	BOOL	
    //    public static string di_6shoushengjiance = "D435.di_6shoushengjiance";//	46	B站收绳检测开关	PI319.1	BOOL	
    //    public static string di_7shoushengjiance = "D435.di_7shoushengjiance";//	47	C站收绳检测开关	PI339.1	BOOL	
    //    public static string di_8shoushengjiance = "D435.di_8shoushengjiance";//	48	D站收绳检测开关	PI359.1	BOOL

    //    public static string no5_torque = "D435.no5_torque";//84 A站扭矩   LREAL
    //    public static string no6_torque = "D435.no6_torque";//85 B站扭矩   LREAL
    //    public static string no7_torque = "D435.no7_torque";//86 C站扭矩   LREAL
    //    public static string no8_torque = "D435.no8_torque";//87 D站扭矩   LREAL

    //    /**************************************************************************
    //     *控制功能，读写变量
    //    **************************************************************************/
    //    public static string pc_qufanzfangxian = "D435.pc_qufanzfangxiang";//	49	取反上下摇杆方向		BOOL	

    //    public static string pc_jog_fangshen = "D435.pc_jog_fangshen";//	50	上位机点动放绳按钮		BOOL	上位机（画面上）
    //    public static string pc_jog_shoushen = "D435.pc_jog_shoushen";//	51	上位机点动收绳		BOOL	上位机（画面上）
    //    public static string pc_man_tiaozhen = "D435.pc_man_tiaozhen";//	52	上位机进入手动调整状态		BOOL	上位机操作（画面上）
    //    public static string pc_yaogan_enable = "D435.pc_yaogan_enable";//	53	上位机禁用启用摇杆		BOOL	上位机操作（画面上）

    //    public static string sys_backtochushidian = "D435.sys_backtochushidian";//	54	回回放路径初始点		BOOL	上位机操作（画面上）
    //    public static string sys_backwancheng = "D435.sys_backwancheng";//	55	回回放路径初始点完成		BOOL	上位机操作（画面上）
    //    public static string sys_replay = "D435.sys_replay";//	56	是否处于回放状态		BOOL	上位机操作（画面上）

    //    public static string vh = "D435.vh";//	57	回回放零点时的速度基准		LREAL	
    //    public static string xh = "D435.xh";//	58	回放起点X坐标		LREAL	
    //    public static string yh = "D435.yh";//	59	回放起点Y坐标		LREAL	
    //    public static string zh = "D435.zh";//	60	回放起点Z坐标		LREAL	
    //    public static string pc_hf_vx = "D435.pc_hf_vx";//	61	回放时上位机给的运动信号 X方向		LREAL	
    //    public static string pc_hf_vy = "D435.pc_hf_vy";//	62	回放时上位机给的运动信号 Y方向		LREAL	
    //    public static string pc_hf_vz = "D435.pc_hf_vz";//	63	回放时上位机给的运动信号 Z方向		LREAL	
    //    public static string pc_jl_vx = "D435.pc_jl_vx";//	64	给上位机的摇杆信号 X方向		LREAL	
    //    public static string pc_jl_vy = "D435.pc_jl_vy";//	65	给上位机的摇杆信号 Y方向		LREAL	
    //    public static string pc_jl_vz = "D435.pc_jl_vz";//	66	给上位机的摇杆信号 Z方向		LREAL	

    //    public static string hmi_ack = "D435.hmi_ack";//	67	上位机故障复位按钮		BOOL	上位机操作（画面上）
    //    public static string sys_xyxuanzhuanjiaodu = "D435.sys_xyxuanzhuanjiaodu";//	68	坐标旋转角度		LREAL	坐标旋转
    //    public static string sys_xiepozhengliang = "D435.sys_xiepozhengliang";//	69	速度斜坡控制增量		LREAL	摇杆灵敏度
    //    public static string pc_pintai_vmax = "D435.pc_pintai_vmax";//	70	P点移动最快速度		LREAL	
    //    public static string pc_shoudongsudugeiding = "D435.pc_shoudongsudugeiding";//	71	上位机手动速度给定		LREAL	
    //    public static string pc_yaoganlingmingdu = "D435.pc_yaoganlingmingdu";//	72	摇杆灵敏度，范围：0-10		LREAL	
    //    public static string sys_shouxianxishu = "D435.sys_shouxianxishu";//	73	计算垂直于各边速度时的系数		LREAL	

    //    public static string long_a_gaodu = "D435.long_a_gaodu";//	74	A站高度		LREAL	
    //    public static string long_ab_kuandu = "D435.long_ab_kuandu";//	75	AB站水平宽度		LREAL	
    //    public static string long_b_gaodu = "D435.long_b_gaodu";//	76	B站高度		LREAL	
    //    public static string long_bc_kuandu = "D435.long_bc_kuandu";//	77	BC站水平宽度		LREAL	
    //    public static string long_c_gaodu = "D435.long_c_gaodu";//	78	C站高度		LREAL	
    //    public static string long_cd_kuandu = "D435.long_cd_kuandu";//	79	CD站水平宽度		LREAL	
    //    public static string long_d_gaodu = "D435.long_d_gaodu";//	80	D站高度		LREAL	
    //    public static string long_da_kuandu = "D435.long_da_kuandu";//	81	DA站水平宽度		LREAL	
    //    public static string long_quanzhanyigaodu = "D435.long_quanzhanyigaodu";//	82	全站仪高度设定		LREAL	
    //    public static string pc_qubieabcd = "D435.pc_qubieabcd";//	83	上位机区别测量的是AP、BP、CP或DP		BYTE	二次测量电机选择 0A 1B 2C 3D

    //    public static string pc_yaoganlingmingdu_z = "D435.pc_yaoganlingmingdu_z";//	Z轴摇杆灵敏度，范围：0-10		LREAL
    //    public static string sys_xiepozhengliang_z = "D435.sys_xiepozhengliang_z";//	Z轴速度斜坡控制增量		LREAL
    //    public static string pc_pintai_vmax_z = "D435.pc_pintai_vmax_z";//	Z移动最快速度		LREAL

    //    public static string pc_tongxunceshi = "D435.pc_tongxunceshi";//	累加0-100,测试通讯		INT

    //    public static string pc_yaoganmax_xzheng = "D435.pc_yaoganmax_xzheng";//	摇杆最大值 X正向(20，100)		LREAL
    //    public static string pc_yaoganmax_xfu = "D435.pc_yaoganmax_xfu";//	摇杆最大值 X负向(-20，-100)		LREAL
    //    public static string pc_yaoganmax_yzheng = "D435.pc_yaoganmax_yzheng";//	摇杆最大值 Y正向(20，100)		LREAL
    //    public static string pc_yaoganmax_yfu = "D435.pc_yaoganmax_yfu";//	摇杆最大值 Y负向(-20，-100)		LREAL
    //    public static string pc_yaoganmax_zzheng = "D435.pc_yaoganmax_zzheng";//	摇杆最大值 Z正向(20，100)		LREAL
    //    public static string pc_yaoganmax_zfu = "D435.pc_yaoganmax_zfu";//	摇杆最大值 Z负向(-20，-100)		LREAL
    //    //显示摇杆值
    //    public static string pc_qianhouyangan_1 = "D435.pc_qianhouyangan_1";//	X 摇杆值,范围(-100，+100)		LREAL
    //    public static string pc_zuoyouyaogan_1 = "D435.pc_zuoyouyaogan_1";//	Y 摇杆值,范围(-100，+100)		LREAL
    //    public static string pc_shangxiayaogan_1 = "D435.pc_shangxiayaogan_1";//	Z 摇杆值,范围(-100，+100)		LREAL

    //    public static string sys_dead_area_x = "D435.sys_dead_area_x";//	X摇杆速度给定死区大小,上位机给定，范围（0，100）		LREAL
    //    public static string sys_dead_area_y = "D435.sys_dead_area_y";//	Y摇杆速度给定死区大小,上位机给定，范围（0，100）		LREAL
    //    public static string sys_dead_area_z = "SYM.D435.sys_dead_area_z";//	Z摇杆速度给定死区大小,上位机给定，范围（0，100）		LREAL

    //    public static string pc_yaogan_piaoyi_x = "SYM.pc_yaogan_piaoyi_x";//	X轴摇杆 零点漂移修正（-10000，+10000）		INT
    //    public static string pc_yaogan_piaoyi_y = "SYM.pc_yaogan_piaoyi_y";//	Y轴摇杆 零点漂移修正（-10000，+10000）		INT
    //    public static string pc_yaogan_piaoyi_z = "SYM.pc_yaogan_piaoyi_z";//	Z轴摇杆 零点漂移修正（-10000，+10000）		INT

    //    public static string pc_luzhi_time = "SYM.D435.pc_luzhi_time";//录制时设定录制时间 INT
    //    public static string pc_luzhi_start = "SYM.D435.pc_luzhi_start";//录制开始按钮。到达录制时间，下位机自动停止录制，并且复位录制按钮。 BOOL
    //    public static string pc_huifang_start = "SYM.D435.pc_huifang_start";//回放开始 BOOL
    //    public static string pc_luzhi_lengh = "SYM.D435.pc_luzhi_lengh";//根据设置的录制时间计算得出的点数 INT

    //    public static string zhizhen_vx = "D435.zhizhen_vx";	//数据个数，指针		DINT	
    //    public static string pc_duqu_shuju = "D435.pc_duqu_shuju";	//PC机读取数据开始		BOOL	
    //    public static string pc_shujuzushu = "D435.pc_shujuzushu";	//数据组数		DINT	
    //    public static string pc_xiachua_shuju = "D435.pc_xiachua_shuju";	//PC机下传数据开始		BOOL	
    //    public static string temp_vx = "D435.readwrite.temp_vx";	//vx临时数组		Array	real
    //    public static string temp_vy = "D435.readwrite.temp_vy";	//vy临时数组		Array	real
    //    public static string temp_vz = "D435.readwrite.temp_vz";	//vz临时数组		Array	real
    //    public static string temp_zushu = "D435.readwrite.temp_zushu";	//数据读取组数		DINT	数组计数器
    //    public static string temp_readok = "D435.readwrite.temp_readok";	//下位机发送完毕		BOOL	


    //    /**************************************************************************
    //     *实时坐标值，只读变量
    //    **************************************************************************/
    //    public static string xp = "D435.xp";//	88	P点X轴坐标		LREAL	平台坐标
    //    public static string yp = "D435.yp";//	89	P点Y轴坐标		LREAL	
    //    public static string zp = "D435.zp";//	90	P点Z轴坐标		LREAL	
    //    public static string xa = "D435.xa";//	91	A点X轴坐标		LREAL	A坐标
    //    public static string ya = "D435.ya";//	92	A点Y轴坐标		LREAL	
    //    public static string za = "D435.za";//	93	A点Z轴坐标		LREAL	
    //    public static string xb = "D435.xb";//	94	B点X轴坐标		LREAL	B坐标
    //    public static string yb = "D435.yb";//	95	B点Y轴坐标		LREAL	
    //    public static string zb = "D435.zb";//	96	B点Z轴坐标		LREAL	
    //    public static string xc = "D435.xc";//	97	C点X轴坐标		LREAL	C坐标
    //    public static string yc = "D435.yc";//	98	C点Y轴坐标		LREAL	
    //    public static string zc = "D435.zc";//	99	C点Z轴坐标		LREAL	
    //    public static string xd = "D435.xd";//	100	D点X轴坐标		LREAL	D坐标
    //    public static string yd = "D435.yd";//	101	D点Y轴坐标		LREAL	
    //    public static string zd = "D435.zd";//	102	D点Z轴坐标		LREAL	

    //    /**************************************************************************
    //     *初始设置，读写变量
    //    **************************************************************************/
    //    public static string sys_zmin = "D435.sys_zmin";//	103	最低点Z坐标限制		LREAL	飞行允许最高点
    //    public static string pc_p_da = "D435.pc_p_da";//	104	P点距AD边水平投影设定距离		LREAL	各边飞行边界
    //    public static string pc_p_bc = "D435.pc_p_bc";//	105	P点距BC边水平投影设定距离		LREAL	
    //    public static string pc_p_ab = "D435.pc_p_ab";//	106	P点距AB边水平投影设定距离		LREAL	
    //    public static string pc_p_cd = "D435.pc_p_cd";//	107	P点距CD边水平投影设定距离		LREAL	
    //    public static string longa = "D435.longa";//	108	A点测量距离		LREAL	A、B、C、D、P 5点初始球坐标
    //    public static string longb = "D435.longb";//	109	B点测量距离		LREAL	
    //    public static string longc = "D435.longc";//	110	C点测量距离		LREAL	
    //    public static string longd = "D435.longd";//	111	D点测量距离		LREAL	
    //    public static string longp = "D435.longp";//	112	P点测量距离		LREAL	
    //    public static string sppj = "D435.sppj";//	113	P点水平角		LREAL	
    //    public static string spaj = "D435.spaj";//	114	A点水平角		LREAL	
    //    public static string spbj = "D435.spbj";//	115	B点水平角		LREAL	
    //    public static string spcj = "D435.spcj";//	116	C点水平角		LREAL	
    //    public static string spdj = "D435.spdj";//	117	D点水平角		LREAL	
    //    public static string yangpj = "D435.yangpj";//	118	P点仰角		LREAL	
    //    public static string yangaj = "D435.yangaj";//	119	A点仰角		LREAL	
    //    public static string yangdj = "D435.yangdj";//	120	D点仰角		LREAL	
    //    public static string yangbj = "D435.yangbj";//	121	B点仰角		LREAL	
    //    public static string yangcj = "D435.yangcj";//	122	C点仰角		LREAL	

    //    public static string xp1 = "D435.xp1";//	123	第二次测量P点在原坐标系中的X坐标，为平台坐标赋值		LREAL	
    //    public static string pc_homing = "D435.pc_homing";//	124	第二次测量上位机回零开关		BOOL	上位机选择回零（画面上）
    //    public static string yangcj2 = "D435.yangcj2";//	125	第二次测量C点仰角		LREAL	A、B、C、D、P 5点          二次测量对应球坐标
    //    public static string yangbj2 = "D435.yangbj2";//	126	第二次测量B点仰角		LREAL	
    //    public static string yangaj2 = "D435.yangaj2";//	127	第二次测量A点仰角		LREAL	
    //    public static string yangdj2 = "D435.yangdj2";//	128	第二次测量D点仰角		LREAL	
    //    public static string yangpj2 = "D435.yangpj2";//	129	第二次测量P点仰角		LREAL	
    //    public static string longp2 = "D435.longp2";//	130	第二次测量P点距离		LREAL	
    //    public static string longa2 = "D435.longa2";//	131	第二次测量A点距离		LREAL	
    //    public static string longb2 = "D435.longb2";//	132	第二次测量B点距离		LREAL	
    //    public static string longc2 = "D435.longc2";//	133	第二次测量C点距离		LREAL	
    //    public static string longd2 = "D435.longd2";//	134	第二次测量D点距离		LREAL	
    //    public static string sppj2 = "D435.sppj2";//	135	第二次测量P点水平角		LREAL	
    //    public static string spaj2 = "D435.spaj2";//	136	第二次测量A点水平角		LREAL	
    //    public static string spbj2 = "D435.spbj2";//	137	第二次测量B点水平角		LREAL	
    //    public static string spcj2 = "D435.spcj2";//	138	第二次测量C点水平角		LREAL	
    //    public static string spdj2 = "D435.spdj2";//	139	第二次测量D点水平角		LREAL	
    //}


    /// <summary>
    /// 所有变量枚举 西门子变量
    /// </summary>
    public class VariableEnum
    {

        //控制器IP地址192.168.0.100	控制器IP地址192.168.0.100						
        //控制器控制四台电机A、B、C、D四个站，逆时针排布	控制器控制四台电机A、B、C、D四个站，逆时针排布						
        //吊装飞行物（摄像机）用P站表示	吊装飞行物（摄像机）用P站表示						
        //变量名称	变量名称	,//	序号	解释	控制器地址	数据类型	含义

        /**************************************************************************
         *状态显示，只读变量
        **************************************************************************/
        public static string statu_no5_enable_ok = "\\SYM:\\D435.statu_no5_enable_ok";//	1	A站电机使能OK	PI377.2	BOOL	电机A、B、C、D激活状态
        public static string statu_no6_enable_ok = "\\SYM:\\D435.statu_no6_enable_ok";//	2	B站电机使能OK	PI397.2	BOOL	
        public static string statu_no7_enable_ok = "\\SYM:\\D435.statu_no7_enable_ok";//	3	C站电机使能OK	PI417.2	BOOL	
        public static string statu_no8_enable_ok = "\\SYM:\\D435.statu_no8_enable_ok";//	4	D站电机使能OK	PI437.2	BOOL	
        public static string statu_no5_error = "\\SYM:\\D435.statu_no5_error";//	5	A站错误		BOOL	
        public static string statu_no6_error = "\\SYM:\\D435.statu_no6_error";//	6	B站错误		BOOL	
        public static string statu_no7_error = "\\SYM:\\D435.statu_no7_error";//	7	C站错误		BOOL	
        public static string statu_no8_error = "\\SYM:\\D435.statu_no8_error";//	8	D站错误		BOOL	
        public static string statu_no5_tongxun = "\\SYM:\\D435.sys_drive_jiance_1";//"\\SYM:\\D435.statu_no5_tongxun";//(2013.3.11改)9	A站通讯故障		BOOL	
        public static string statu_no6_tongxun = "\\SYM:\\D435.sys_drive_jiance_2";//"\\SYM:\\D435.statu_no6_tongxun";//(2013.3.11改)10	B站通讯故障		BOOL	
        public static string statu_no7_tongxun = "\\SYM:\\D435.sys_drive_jiance_3";//"\\SYM:\\D435.statu_no7_tongxun";//(2013.3.11改)11	C站通讯故障		BOOL	
        public static string statu_no8_tongxun = "\\SYM:\\D435.sys_drive_jiance_4";//"\\SYM:\\D435.statu_no8_tongxun";//(2013.3.11改)12	D站通讯故障		BOOL

        public static string do_5haobaozha = "\\SYM:\\D435.do_5haobaozha";//	13	A站电机抱闸控制	PQ298.1	BOOL	电机A、B、C、D报闸         打开关闭状态
        public static string do_6haobaozha = "\\SYM:\\D435.do_6haobaozha";//	14	B站电机抱闸控制	PQ318.1	BOOL	
        public static string do_7haobaozha = "\\SYM:\\D435.do_7haobaozha";//	15	C站电机抱闸控制	PQ338.1	BOOL	
        public static string do_8haobaozha = "\\SYM:\\D435.do_8haobaozha";//	16	D站电机抱闸控制	PQ358.1	BOOL	  
        public static string do_5haojiechuqi = "\\SYM:\\D435.do_5haojiechuqi";//	17	A站接触器吸合		BOOL	
        public static string do_6haojiechuqi = "\\SYM:\\D435.do_6haojiechuqi";//	18	B站接触器吸合		BOOL	
        public static string do_7haojiechuqi = "\\SYM:\\D435.do_7haojiechuqi";//	19	C站接触器吸合		BOOL	
        public static string do_8haojiechuqi = "\\SYM:\\D435.do_8haojiechuqi";//	20	D站接触器吸合		BOOL	

        public static string di_jinjitingche = "\\SYM:\\D435.di_jinjitingche";//	21	紧急停止按钮（总）	PI257.0	BOOL	紧急停车状态（操作台）
        public static string di_enable = "\\SYM:\\D435.di_enable";//	22	控制系统使能（激活）按钮	PI257.1	BOOL	
        public static string di_5haojog = "\\SYM:\\D435.di_5haojog";//	23	A站电机点动按钮	PI257.4	BOOL	A站操作盒
        public static string di_6haojog = "\\SYM:\\D435.di_6haojog";//	24	B站电机点动按钮	PI257.5	BOOL	B站操作盒
        public static string di_7haojog = "\\SYM:\\D435.di_7haojog";//	25	C站电机点动按钮	PI257.6	BOOL	C站操作盒
        public static string di_8haojog = "\\SYM:\\D435.di_8haojog";//	26	D站电机点动按钮	PI257.7	BOOL	D站操作盒
        public static string di_ack = "\\SYM:\\D435.di_ack";//	27	故障复位按钮	PI257.2	BOOL	操作台控制盒
        public static string di_auto_man = "\\SYM:\\D435.di_auto_man";//	28	手动/自动转换按钮	PI257.3	BOOL	操作台控制盒
        public static string di_auto_start = "\\SYM:\\D435.di_auto_start";//	29	启动按钮	PI267.0	BOOL	操作台控制盒
        public static string di_homeing01 = "\\SYM:\\D435.di_homeing01";//	30	系统回零按钮1	PI267.1	BOOL	操作台控制盒
        public static string di_homeing02 = "\\SYM:\\D435.di_homeing02";//	31	系统回零按钮2	PI267.2	BOOL	操作台控制盒
        public static string di_jiudijizhong = "\\SYM:\\D435.di_jiudijizhong";//	32	就地控制按钮	PI267.3	BOOL	操作台控制盒
        public static string di_8haoshoudong = "\\SYM:\\D435.di_8haoshoudong";//	33	操作台D站手动按钮	PI358.3	BOOL	操作台控制盒
        public static string di_7haoshoudong = "\\SYM:\\D435.di_7haoshoudong";//	34	操作台C站手动按钮	PI338.3	BOOL	操作台控制盒
        public static string di_6haoshoudong = "\\SYM:\\D435.di_6haoshoudong";//	35	操作台B站手动按钮	PI318.3	BOOL	操作台控制盒
        public static string di_5haoshoudong = "\\SYM:\\D435.di_5haoshoudong";//	36	操作台A站手动按钮	PI298.3	BOOL	操作台控制盒
        public static string di_5jiting = "\\SYM:\\D435.di_5jiting";//	37	A站急停按钮	PI298.0	BOOL	A站操作盒
        public static string di_6jiting = "\\SYM:\\D435.di_6jiting";//	38	B站急停按钮	PI318.0	BOOL	B站操作盒
        public static string di_7jiting = "\\SYM:\\D435.di_7jiting";//	39	C站急停按钮	PI338.0	BOOL	C站操作盒
        public static string di_8jiting = "\\SYM:\\D435.di_8jiting";//	40	D站急停按钮	PI358.0	BOOL	A站操作盒
        public static string di_5zhidongjiance = "\\SYM:\\D435.di_5zhidongjiance";//	41	A站制动检测开关	PI299.0	BOOL	
        public static string di_6zhidongjiance = "\\SYM:\\D435.di_6zhidongjiance";//	42	B站制动检测开关	PI319.0	BOOL	
        public static string di_7zhidongjiance = "\\SYM:\\D435.di_7zhidongjiance";//	43	C站制动检测开关	PI339.0	BOOL	
        public static string di_8zhidongjiance = "\\SYM:\\D435.di_8zhidongjiance";//	44	D站制动检测开关	PI359.0	BOOL	
        public static string di_5shoushengjiance = "\\SYM:\\D435.di_5shoushengjiance";//	45	A站收绳检测开关	PI299.1	BOOL	
        public static string di_6shoushengjiance = "\\SYM:\\D435.di_6shoushengjiance";//	46	B站收绳检测开关	PI319.1	BOOL	
        public static string di_7shoushengjiance = "\\SYM:\\D435.di_7shoushengjiance";//	47	C站收绳检测开关	PI339.1	BOOL	
        public static string di_8shoushengjiance = "\\SYM:\\D435.di_8shoushengjiance";//	48	D站收绳检测开关	PI359.1	BOOL

        public static string no5_torque = "\\SYM:\\D435.no5_torque";//84 A站扭矩   LREAL
        public static string no6_torque = "\\SYM:\\D435.no6_torque";//85 B站扭矩   LREAL
        public static string no7_torque = "\\SYM:\\D435.no7_torque";//86 C站扭矩   LREAL
        public static string no8_torque = "\\SYM:\\D435.no8_torque";//87 D站扭矩   LREAL

        /**************************************************************************
         *控制功能，读写变量
        **************************************************************************/
        public static string pc_qufanzfangxian = "\\SYM:\\D435.pc_qufanzfangxiang";//	49	取反上下摇杆方向		BOOL	

        public static string pc_jog_fangshen = "\\SYM:\\D435.pc_jog_fangshen";//	50	上位机点动放绳按钮		BOOL	上位机（画面上）
        public static string pc_jog_shoushen = "\\SYM:\\D435.pc_jog_shoushen";//	51	上位机点动收绳		BOOL	上位机（画面上）
        public static string pc_man_tiaozhen = "\\SYM:\\HMIbutton_ActivateHandleMode";//	52	上位机进入手动调整状态		BOOL	上位机操作（画面上）
        public static string pc_yaogan_enable = "\\SYM:\\D435.pc_yaogan_enable";//	53	上位机禁用启用摇杆		BOOL	上位机操作（画面上）

        public static string pc_5haojog = "\\SYM:\\D435.pc_5haojog";//	选中“电机1”		BOOL	上位机操作（画面上）
        public static string pc_6haojog = "\\SYM:\\D435.pc_6haojog";//	选中“电机2”		BOOL	上位机操作（画面上）
        public static string pc_7haojog = "\\SYM:\\D435.pc_7haojog";//	选中“电机3”		BOOL	上位机操作（画面上）
        public static string pc_8haojog = "\\SYM:\\D435.pc_8haojog";//	选中“电机4”		BOOL	上位机操作（画面上）

        public static string sys_backtochushidian = "\\SYM:\\D435.sys_backtochushidian";//	54	回回放路径初始点		BOOL	上位机操作（画面上）
        public static string sys_backwancheng = "\\SYM:\\D435.sys_backwancheng";//	55	回回放路径初始点完成		BOOL	上位机操作（画面上）
        public static string sys_replay = "\\SYM:\\D435.sys_replay";//	56	是否处于回放状态		BOOL	上位机操作（画面上）

        public static string vh = "\\SYM:\\D435.vh";//	57	回回放零点时的速度基准		LREAL	
        public static string xh = "\\SYM:\\D435.xh";//	58	回放起点X坐标		LREAL	
        public static string yh = "\\SYM:\\D435.yh";//	59	回放起点Y坐标		LREAL	
        public static string zh = "\\SYM:\\D435.zh";//	60	回放起点Z坐标		LREAL	
        public static string pc_hf_vx = "\\SYM:\\D435.pc_hf_vx";//	61	回放时上位机给的运动信号 X方向		LREAL	
        public static string pc_hf_vy = "\\SYM:\\D435.pc_hf_vy";//	62	回放时上位机给的运动信号 Y方向		LREAL	
        public static string pc_hf_vz = "\\SYM:\\D435.pc_hf_vz";//	63	回放时上位机给的运动信号 Z方向		LREAL	
        public static string pc_jl_vx = "\\SYM:\\D435.pc_jl_vx";//	64	录制信号 X方向		LREAL	
        public static string pc_jl_vy = "\\SYM:\\D435.pc_jl_vy";//	65	录制信号 Y方向		LREAL	
        public static string pc_jl_vz = "\\SYM:\\D435.pc_jl_vz";//	66	录制信号 Z方向		LREAL	

        public static string hmi_ack = "\\SYM:\\HMIbutton_ActivateInitializeMode";//	67	上位机故障复位按钮		BOOL	上位机操作（画面上）
        public static string sys_xyxuanzhuanjiaodu = "\\SYM:\\D435.sys_xyxuanzhuanjiaodu";//	68	坐标旋转角度		LREAL	坐标旋转
        public static string sys_xiepozhengliang = "\\SYM:\\D435.sys_xiepozhengliang";//	69	速度斜坡控制增量		LREAL	摇杆灵敏度
        public static string pc_pintai_vmax = "\\SYM:\\D435.pc_pintai_vmax";//	70	P点移动最快速度		LREAL	
        public static string pc_shoudongsudugeiding = "\\SYM:\\HMI_WinderJoggingSpdSetpt";//	71	上位机手动速度给定		LREAL	
        public static string pc_yaoganlingmingdu = "\\SYM:\\D435.pc_yaoganlingmingdu";//	72	摇杆灵敏度，范围：0-10		LREAL	
        public static string sys_shouxianxishu = "\\SYM:\\D435.sys_shouxianxishu";//	73	计算垂直于各边速度时的系数		LREAL	

        public static string long_a_gaodu = "\\SYM:\\D435.long_a_gaodu";//	74	A站高度		LREAL	
        public static string long_ab_kuandu = "\\SYM:\\D435.long_ab_kuandu";//	75	AB站水平宽度		LREAL	
        public static string long_b_gaodu = "\\SYM:\\D435.long_b_gaodu";//	76	B站高度		LREAL	
        public static string long_bc_kuandu = "\\SYM:\\D435.long_bc_kuandu";//	77	BC站水平宽度		LREAL	
        public static string long_c_gaodu = "\\SYM:\\D435.long_c_gaodu";//	78	C站高度		LREAL	
        public static string long_cd_kuandu = "\\SYM:\\D435.long_cd_kuandu";//	79	CD站水平宽度		LREAL	
        public static string long_d_gaodu = "\\SYM:\\D435.long_d_gaodu";//	80	D站高度		LREAL	
        public static string long_da_kuandu = "\\SYM:\\D435.long_da_kuandu";//	81	DA站水平宽度		LREAL	
        public static string long_quanzhanyigaodu = "\\SYM:\\D435.long_quanzhanyigaodu";//	82	全站仪高度设定		LREAL	
        public static string pc_qubieabcd = "\\SYM:\\D435.pc_qubieabcd";//	83	上位机区别测量的是AP、BP、CP或DP		BYTE	二次测量电机选择 0A 1B 2C 3D

        public static string pc_yaoganlingmingdu_z = "\\SYM:\\D435.pc_yaoganlingmingdu_z";//	Z轴摇杆灵敏度，范围：0-10		LREAL
        public static string sys_xiepozhengliang_z = "\\SYM:\\D435.sys_xiepozhengliang_z";//	Z轴速度斜坡控制增量		LREAL
        public static string pc_pintai_vmax_z = "\\SYM:\\D435.pc_pintai_vmax_z";//	Z移动最快速度		LREAL
        public static string pc_tongxunceshi = "\\SYM:\\D435.pc_tongxunceshi";//	累加0-100,测试通讯		INT
        public static string pc_yaoganmax_xzheng = "\\SYM:\\D435.pc_yaoganmax_xzheng";//	摇杆最大值 X正向(20，100)		LREAL
        public static string pc_yaoganmax_xfu = "\\SYM:\\D435.pc_yaoganmax_xfu";//	摇杆最大值 X负向(-20，-100)		LREAL
        public static string pc_yaoganmax_yzheng = "\\SYM:\\D435.pc_yaoganmax_yzheng";//	摇杆最大值 Y正向(20，100)		LREAL
        public static string pc_yaoganmax_yfu = "\\SYM:\\D435.pc_yaoganmax_yfu";//	摇杆最大值 Y负向(-20，-100)		LREAL
        public static string pc_yaoganmax_zzheng = "\\SYM:\\D435.pc_yaoganmax_zzheng";//	摇杆最大值 Z正向(20，100)		LREAL
        public static string pc_yaoganmax_zfu = "\\SYM:\\D435.pc_yaoganmax_zfu";//	摇杆最大值 Z负向(-20，-100)		LREAL
        public static string pc_qianhouyangan_1 = "\\SYM:\\D435.pc_qianhouyangan_1";//	X 摇杆值,范围(-100，+100)		LREAL
        public static string pc_zuoyouyaogan_1 = "\\SYM:\\D435.pc_zuoyouyaogan_1";//	Y 摇杆值,范围(-100，+100)		LREAL
        public static string pc_shangxiayaogan_1 = "\\SYM:\\D435.pc_shangxiayaogan_1";//	Z 摇杆值,范围(-100，+100)		LREAL
        public static string sys_dead_area_x = "\\SYM:\\D435.sys_dead_area_x";//	X摇杆速度给定死区大小,上位机给定，范围（0，100）		LREAL
        public static string sys_dead_area_y = "\\SYM:\\D435.sys_dead_area_y";//	Y摇杆速度给定死区大小,上位机给定，范围（0，100）		LREAL
        public static string sys_dead_area_z = "\\SYM:\\D435.sys_dead_area_z";//	Z摇杆速度给定死区大小,上位机给定，范围（0，100）		LREAL
        public static string pc_yaogan_piaoyi_x = "\\SYM:\\D435.pc_yaogan_piaoyi_x";//	X轴摇杆 零点漂移修正（-10000，+10000）		INT
        public static string pc_yaogan_piaoyi_y = "\\SYM:\\D435.pc_yaogan_piaoyi_y";//	Y轴摇杆 零点漂移修正（-10000，+10000）		INT
        public static string pc_yaogan_piaoyi_z = "\\SYM:\\D435.pc_yaogan_piaoyi_z";//	Z轴摇杆 零点漂移修正（-10000，+10000）		INT
        public static string pc_luzhi_time = "\\SYM:\\D435.pc_luzhi_time";//录制时设定录制时间 INT
        public static string pc_luzhi_start = "\\SYM:\\D435.pc_luzhi_start";//录制开始按钮。到达录制时间，下位机自动停止录制，并且复位录制按钮。 BOOL
        public static string pc_huifang_start = "\\SYM:\\D435.pc_huifang_start";//回放开始 BOOL
        public static string pc_luzhi_lengh = "\\SYM:\\D435.pc_luzhi_lengh";//根据设置的录制时间计算得出的点数 INT

        public static string zhizhen_vx = "\\SYM:\\D435.zhizhen_vx";	//数据个数，指针		DINT	
        public static string pc_duqu_shuju = "\\SYM:\\D435.pc_duqu_shuju";	//PC机读取数据开始		BOOL	
        public static string pc_shujuzushu = "\\SYM:\\D435.pc_shujuzushu";	//数据组数		DINT	
        public static string pc_xiachua_shuju = "\\SYM:\\D435.pc_xiachua_shuju";	//PC机下传数据开始		BOOL	
        public static string temp_vx = "\\SYM:\\D435.readwrite.temp_vx";	//vx临时数组		Array	real
        public static string temp_vy = "\\SYM:\\D435.readwrite.temp_vy";	//vy临时数组		Array	real
        public static string temp_vz = "\\SYM:\\D435.readwrite.temp_vz";	//vz临时数组		Array	real
        public static string temp_zushu = "\\SYM:\\D435.readwrite.temp_zushu";	//数据读取组数		DINT	数组计数器
        public static string temp_readok = "\\SYM:\\D435.readwrite.temp_readok";	//下位机发送完毕		BOOL	



        /**************************************************************************
         *实时坐标值，只读变量
        **************************************************************************/
        public static string xp = "\\SYM:\\D435.xp";//	88	P点X轴坐标		LREAL	平台坐标
        public static string yp = "\\SYM:\\D435.yp";//	89	P点Y轴坐标		LREAL	
        public static string zp = "\\SYM:\\D435.zp";//	90	P点Z轴坐标		LREAL	
        public static string xa = "\\SYM:\\lr_WheelA_X";//	91	A点X轴坐标		LREAL	A坐标
        public static string ya = "\\SYM:\\lr_WheelA_Y";//	92	A点Y轴坐标		LREAL	
        public static string za = "\\SYM:\\lr_WheelA_Z";//	93	A点Z轴坐标		LREAL	
        public static string xb = "\\SYM:\\lr_WheelB_X";//	94	B点X轴坐标		LREAL	B坐标
        public static string yb = "\\SYM:\\lr_WheelB_Y";//	95	B点Y轴坐标		LREAL	
        public static string zb = "\\SYM:\\lr_WheelB_Z";//	96	B点Z轴坐标		LREAL	
        public static string xc = "\\SYM:\\lr_WheelC_X";//	97	C点X轴坐标		LREAL	C坐标
        public static string yc = "\\SYM:\\lr_WheelC_Y";//	98	C点Y轴坐标		LREAL	
        public static string zc = "\\SYM:\\lr_WheelC_Z";//	99	C点Z轴坐标		LREAL	
        public static string xd = "\\SYM:\\lr_WheelD_X";//	100	D点X轴坐标		LREAL	D坐标
        public static string yd = "\\SYM:\\lr_WheelD_Y";//	101	D点Y轴坐标		LREAL	
        public static string zd = "\\SYM:\\lr_WheelD_Z";//	102	D点Z轴坐标		LREAL	

        /**************************************************************************
         *初始设置，读写变量
        **************************************************************************/
        public static string sys_jiajiaojiaodu = "\\SYM:\\D435.sys_jiajiaojiaodu";//	103	最高夹角角度限制		LREAL	飞行允许最高点
        public static string sys_zmin = "\\SYM:\\D435.sys_zdixian";//	103	最低点Z坐标限制		LREAL	飞行允许最低点
        public static string pc_p_da = "\\SYM:\\HMI_DALimitation";//	104	P点距AD边水平投影设定距离		LREAL	各边飞行边界
        public static string pc_p_bc = "\\SYM:\\HMI_BCLimitation";//	105	P点距BC边水平投影设定距离		LREAL	
        public static string pc_p_ab = "\\SYM:\\HMI_ABLimitation";//	106	P点距AB边水平投影设定距离		LREAL	
        public static string pc_p_cd = "\\SYM:\\HMI_CDLimitation";//	107	P点距CD边水平投影设定距离		LREAL	
        public static string longa = "\\SYM:\\HMI_Length_A_O";//	108	A点测量距离		LREAL	A、B、C、D、P 5点初始球坐标
        public static string longb = "\\SYM:\\HMI_Length_B_O";//	109	B点测量距离		LREAL	
        public static string longc = "\\SYM:\\HMI_Length_C_O";//	110	C点测量距离		LREAL	
        public static string longd = "\\SYM:\\HMI_Length_D_O";//	111	D点测量距离		LREAL	
        public static string longp = "\\SYM:\\HMI_Length_ODragon";//	112	P点测量距离		LREAL	
        public static string sppj = "\\SYM:\\D435.sppj";//	113	P点水平角		LREAL	
        public static string spaj = "\\SYM:\\D435.spaj";//	114	A点水平角		LREAL	
        public static string spbj = "\\SYM:\\D435.spbj";//	115	B点水平角		LREAL	
        public static string spcj = "\\SYM:\\D435.spcj";//	116	C点水平角		LREAL	
        public static string spdj = "\\SYM:\\D435.spdj";//	117	D点水平角		LREAL	
        public static string yangpj = "\\SYM:\\HMI_Angle_ODragonm";//	118	P点仰角		LREAL	
        public static string yangaj = "\\SYM:\\HMI_Angle_A";//	119	A点仰角		LREAL	
        public static string yangdj = "\\SYM:\\HMI_Angle_D";//	120	D点仰角		LREAL	
        public static string yangbj = "\\SYM:\\HMI_Angle_B";//	121	B点仰角		LREAL	
        public static string yangcj = "\\SYM:\\HMI_Angle_C";//	122	C点仰角		LREAL	

        public static string xp0 = "\\SYM:\\D435.xp0";//	云台的初始坐标X轴   LREAL
        public static string yp0 = "\\SYM:\\D435.yp0";//	云台的初始坐标Y轴   LREAL	
        public static string zp0 = "\\SYM:\\D435.zp0";//	云台的初始坐标Z轴   LREAL

        public static string xp1 = "\\SYM:\\D435.xp1";//	123	第二次测量P点在原坐标系中的X坐标，为平台坐标赋值		LREAL	
        public static string pc_homing = "\\SYM:\\D435.pc_homing";//	124	第二次测量上位机回零开关		BOOL	上位机选择回零（画面上）
        public static string yangcj2 = "\\SYM:\\D435.yangcj2";//	125	第二次测量C点仰角		LREAL	A、B、C、D、P 5点          二次测量对应球坐标
        public static string yangbj2 = "\\SYM:\\D435.yangbj2";//	126	第二次测量B点仰角		LREAL	
        public static string yangaj2 = "\\SYM:\\D435.yangaj2";//	127	第二次测量A点仰角		LREAL	
        public static string yangdj2 = "\\SYM:\\D435.yangdj2";//	128	第二次测量D点仰角		LREAL	
        public static string yangpj2 = "\\SYM:\\D435.yangpj2";//	129	第二次测量P点仰角		LREAL	
        public static string longp2 = "\\SYM:\\D435.longp2";//	130	第二次测量P点距离		LREAL	
        public static string longa2 = "\\SYM:\\D435.longa2";//	131	第二次测量A点距离		LREAL	
        public static string longb2 = "\\SYM:\\D435.longb2";//	132	第二次测量B点距离		LREAL	
        public static string longc2 = "\\SYM:\\D435.longc2";//	133	第二次测量C点距离		LREAL	
        public static string longd2 = "\\SYM:\\D435.longd2";//	134	第二次测量D点距离		LREAL	
        public static string sppj2 = "\\SYM:\\D435.sppj2";//	135	第二次测量P点水平角		LREAL	
        public static string spaj2 = "\\SYM:\\D435.spaj2";//	136	第二次测量A点水平角		LREAL	
        public static string spbj2 = "\\SYM:\\D435.spbj2";//	137	第二次测量B点水平角		LREAL	
        public static string spcj2 = "\\SYM:\\D435.spcj2";//	138	第二次测量C点水平角		LREAL	
        public static string spdj2 = "\\SYM:\\D435.spdj2";//	139	第二次测量D点水平角		LREAL	

        public static string pc_homing_jiaodui = "\\SYM:\\D435.pc_homing_jiaodui";//	二次回零是否完成 BOOL	

        //报警信息查看（2013.3.10）
        public static string sys_tm3101_jiance = "\\SYM:\\D435.sys_tm3101_jiance";//	1号TM31通讯断开	BOOL
        public static string sys_tm3102_jiance = "\\SYM:\\D435.sys_tm3102_jiance";//	2号TM31通讯断开	BOOL
        public static string no5_alm = "\\SYM:\\D435.no5_alm";//	1号主伺服报警号	INT
        public static string no5_cu_alm = "\\SYM:\\D435.no5_cu_alm";//	1号主控制器报警号	INT
        public static string no6_alm = "\\SYM:\\D435.no6_alm";//	2号主伺服报警号	INT
        public static string no6_cu_alm = "\\SYM:\\D435.no6_cu_alm";//	2号主控制器报警号	INT
        public static string no7_alm = "\\SYM:\\D435.no7_alm";//	3号主伺服报警号	INT
        public static string no7_cu_alm = "\\SYM:\\D435.no7_cu_alm";//	3号主控制器报警号	INT
        public static string no8_alm = "\\SYM:\\D435.no8_alm";//	4号主伺服报警号	INT
        public static string no8_cu_alm = "\\SYM:\\D435.no8_cu_alm";//	4号主控制器报警号	INT
        public static string no1_cu0_alm = "\\SYM:\\D435.no1_cu0_alm";//	D435集成控制器报警号	INT
        public static string no2_tm31_alm_1 = "\\SYM:\\D435.no2_tm31_alm_1";//	1号TM31报警号	INT
        public static string no2_tm31_alm_2 = "\\SYM:\\D435.no2_tm31_alm_2";//	2号TM31报警号	INT

        public static string bz_keyiyunxing = "\\SYM:\\D435.bz_keyiyunxing";//各轴误差正常 BOOL

    }
}
