using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPCOperate
{
    /// <summary>
    /// 变量参数类的集合。获取和设置部分变量
    /// </summary>
    public class VariableClass
    {
       static VariableClass mystaticVariableClass;

        public static VariableClass VariableClass_()
        {
            if (mystaticVariableClass == null)
            {
                mystaticVariableClass = new VariableClass();
            }
            return mystaticVariableClass;
        }

    

        //状态周期更新定时器
        System.Timers.Timer timer1;
        //实时坐标周期更新定时器
        System.Timers.Timer timer2;

        /// <summary>
        /// 状态更新事件
        /// </summary>
        /// <param name="obj"></param>
        public delegate void StateUpdateEventHandler(object sender, OPCOperate.MyOPC.FlyCat_SysState data);
        public event StateUpdateEventHandler StateUpdate;

        private void StateUpdateEvent(object sender, OPCOperate.MyOPC.FlyCat_SysState data)
        {
            if (StateUpdate != null)
            {
                StateUpdate(sender, data);
            }
        }

        /// <summary>
        /// 实时坐标更新事件
        /// </summary>
        /// <param name="obj"></param>
        public delegate void PointXYZUpdateEventHandler(object sender, OPCOperate.MyOPC.FlyCat_PointXYZ data);
        public event PointXYZUpdateEventHandler PointXYZUpdate;

        private void PointXYZUpdateEvent(object sender, OPCOperate.MyOPC.FlyCat_PointXYZ data)
        {
            if (PointXYZUpdate != null)
            {
                PointXYZUpdate(sender, data);
                //PointXYZUpdate.BeginInvoke(sender, data, new AsyncCallback(CallBack), PointXYZUpdate);
            }
        }

        void CallBack(IAsyncResult ias)
        {
            PointXYZUpdateEventHandler t = (PointXYZUpdateEventHandler)ias.AsyncState;
            t.EndInvoke(ias);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        VariableClass()
        {
            //状态周期更新定时器，缺省周期为500ms
            timer1 = new System.Timers.Timer(500);
            timer1.Elapsed+=new System.Timers.ElapsedEventHandler(timer1_Elapsed);
            timer1.Enabled = true;
            timer1.AutoReset = true;

            //实时坐标周期更新定时器，缺省周期为300ms
            timer2 = new System.Timers.Timer(200);
            timer2.Elapsed += new System.Timers.ElapsedEventHandler(timer2_Elapsed);
            timer2.Enabled = true;
            timer2.AutoReset = true;
        }

        /// <summary>
        /// 状态周期更新的时间,单位ms
        /// </summary>
        public double SysStateInterval
        {
            get { return timer1.Interval; }
            set { timer1.Interval = value; }
        }

        /// <summary>
        /// 实时坐标周期更新的时间,单位ms
        /// </summary>
        public double PointXYZInterval
        {
            get { return timer2.Interval; }
            set { timer2.Interval = value; }
        }

        /// <summary>
        /// timer1事件处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            StateUpdateEvent(sender,MyOPCObject.SysStateClass);
        }

        /// <summary>
        /// timer2事件处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer2_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            PointXYZUpdateEvent(sender, MyOPCObject.PointXYZClass);
        }

    }

    #region 状态变量(只读同步读)

    /// <summary>
    /// 站点错误状态(同步方式)
    /// </summary>
    public class AsyMotorNodeError
    {

        bool a = false;
        /// <summary>
        /// A站点错误
        /// </summary>
        public bool A
        {
            get
            {
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.statu_no5_error), out a);
                return a;
            }
           
        }

        string astr = "";
        public string Astr
        {
            get
            {
                MyOPCObject.ReadData(VariableEnum.statu_no5_error);
                return astr;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.statu_no6_error), out b);
                return b;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.statu_no7_error), out c);
                return c;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.statu_no8_error), out d);
                return d;
            }
           
        }

    }

    /// <summary>
    /// 站点通讯错误状态(同步方式)
    /// </summary>
    public class AsyMotorCommError
    {

        bool a = false;
        /// <summary>
        /// A站点通讯错误
        /// </summary>
        public bool A
        {
            get
            {
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.statu_no5_tongxun), out a);
                return a;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.statu_no6_tongxun), out b);
                return b;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.statu_no7_tongxun), out c);
                return c;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.statu_no8_tongxun), out d);
                return d;
            }
            
        }

    }

    /// <summary>
    /// 站点使能状态(同步方式)
    /// </summary>
    public class AsyMotorEnabled
    {
        bool a = false;
        /// <summary>
        /// A站点使能
        /// </summary>
        public bool A
        {
            get
            {
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.statu_no5_enable_ok), out a);
                return a;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.statu_no6_enable_ok), out b);
                return b;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.statu_no7_enable_ok), out c);
                return c;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.statu_no8_enable_ok), out d);
                return d;
            }
            
        }
    }

    #endregion

    #region DI状态显示(只读同步读)
    /// <summary>
    /// DI状态显示(同步方式)
    /// </summary>
    public class AsyMotorDIState
    {
        bool btControl = false;
        /// <summary>
        /// DI-控制系统使能按钮
        /// </summary>
        public bool DI_SysControlEn
        {
            get
            {
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_enable), out btControl);
                return btControl;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_5haojog), out btAPointPlay);
                return btAPointPlay;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_6haojog), out btBPointPlay);
                return btBPointPlay;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_7haojog), out btCPointPlay);
                return btCPointPlay;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_8haojog), out btDPointPlay);
                return btDPointPlay;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_ack), out btFaultReset);
                return btFaultReset;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_auto_man), out btSwitch);
                return btSwitch;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_auto_start), out btStart);
                return btStart;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_homeing01), out btSysZero1);
                return btSysZero1;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_homeing02), out btSysZero2);
                return btSysZero2;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_jiudijizhong), out btLocalControl);
                return btLocalControl;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_5haoshoudong), out btAManual);
                return btAManual;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_6haoshoudong), out btBManual);
                return btBManual;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_7haoshoudong), out btCManual);
                return btCManual;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_8haoshoudong), out btDManual);
                return btDManual;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_5jiting), out btAEmerStop);
                return btAEmerStop;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_6jiting), out btBEmerStop);
                return btBEmerStop;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_7jiting), out btCEmerStop);
                return btCEmerStop;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_8jiting), out btDEmerStop);
                return btDEmerStop;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_5zhidongjiance), out btAStopCheck);
                return btAStopCheck;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_6zhidongjiance), out btBStopCheck);
                return btBStopCheck;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_7zhidongjiance), out btCStopCheck);
                return btCStopCheck;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_8zhidongjiance), out btDStopCheck);
                return btDStopCheck;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_5shoushengjiance), out btAPullCheck);
                return btAPullCheck;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_6shoushengjiance), out btBPullCheck);
                return btBPullCheck;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_7shoushengjiance), out btCPullCheck);
                return btCPullCheck;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_8shoushengjiance), out btDPullCheck);
                return btDPullCheck;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.di_jinjitingche), out btEmerStop);
                return btEmerStop;
            }
        }

    }

    #endregion

    #region DO状态显示(只读同步读)
    /// <summary>
    /// DO状态显示(同步方式)
    /// </summary>
    public class AsyMotorDOState
    {
        bool btAControl = false;
        /// <summary>
        /// DO-A站电机抱闸控制状态
        /// </summary>
        public bool DO_ALockControl
        {
            get
            {
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.do_5haobaozha), out btAControl);
                return btAControl;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.do_6haobaozha), out btBControl);
                return btBControl;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.do_7haobaozha), out btCControl);
                return btCControl;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.do_8haobaozha), out btDControl);
                return btDControl;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.do_5haojiechuqi), out btAKMControl);
                return btAKMControl;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.do_6haojiechuqi), out btBKMControl);
                return btBKMControl;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.do_7haojiechuqi), out btCKMControl);
                return btCKMControl;
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
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.do_8haojiechuqi), out btDKMControl);
                return btDKMControl;
            }
        }
    }
    #endregion

    #region 力矩显示(只读)

    /// <summary>
    /// 力矩显示类(同步方式)
    /// </summary>
    public class AsyMotorMoment
    {
        Double dAMoment = 0.0;
        /// <summary>
        ///获取A站力矩
        /// </summary>
        public Double AMoment
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.no5_torque), out dAMoment);
                return dAMoment;
            }
        }

        Double dBMoment = 0.0;
        /// <summary>
        ///获取B站力矩
        /// </summary>
        public Double BMoment
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.no6_torque), out dBMoment);
                return dBMoment;
            }
        }

        Double dCMoment = 0.0;
        /// <summary>
        ///获取C站力矩
        /// </summary>
        public Double CMoment
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.no7_torque), out dCMoment);
                return dCMoment;
            }
        }

        Double dDMoment = 0.0;
        /// <summary>
        ///获取D站力矩
        /// </summary>
        public Double DMoment
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.no8_torque), out dDMoment);
                return dDMoment;
            }
        }
    }

    #endregion

    #region 实时坐标显示(只读同步读)

    /// <summary>
    /// 显示的实时坐标值(同步方式)
    /// </summary>
    public class AsyMotorDisplayPoint
    {
        Double txPXPoint = 0;
        /// <summary>
        /// P点X轴坐标
        /// </summary>
        public Double PXPoint
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.xp), out txPXPoint);
                return txPXPoint;
            }
            
        }

        Double txPYPoint = 0;
        /// <summary>
        /// P点Y轴坐标
        /// </summary>
        public Double PYPoint
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.yp), out txPYPoint);
                return txPYPoint;
            }
            
        }

        Double txPZPoint = 0;
        /// <summary>
        /// P点Z轴坐标
        /// </summary>
        public Double PZPoint
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.zp), out txPZPoint);
                return txPZPoint;
            }
            
        }

        Double txAXPoint = 0;
        /// <summary>
        /// A点X轴坐标
        /// </summary>
        public Double AXPoint
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.xa), out txAXPoint);
                return txAXPoint;
            }
            
        }

        Double txAYPoint = 0;
        /// <summary>
        /// A点Y轴坐标
        /// </summary>
        public Double AYPoint
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.ya), out txAYPoint);
                return txAYPoint;
            }
            
        }

        Double txAZPoint = 0;
        /// <summary>
        /// A点Z轴坐标
        /// </summary>
        public Double AZPoint
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.za), out txAZPoint);
                return txAZPoint;
            }
           
        }

        Double txBXPoint = 0;
        /// <summary>
        /// B点X轴坐标
        /// </summary>
        public Double BXPoint
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.xb), out txBXPoint);
                return txBXPoint;
            }
            
        }

        Double txBYPoint = 0;
        /// <summary>
        /// B点Y轴坐标
        /// </summary>
        public Double BYPoint
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.yb), out txBYPoint);
                return txAYPoint;
            }
            
        }

        Double txBZPoint = 0;
        /// <summary>
        /// B点Z轴坐标
        /// </summary>
        public Double BZPoint
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.zb), out txBZPoint);
                return txBZPoint;
            }
            
        }

        Double txCXPoint = 0;
        /// <summary>
        /// C点X轴坐标
        /// </summary>
        public Double CXPoint
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.xc), out txCXPoint);
                return txCXPoint;
            }
            
        }

        Double txCYPoint = 0;
        /// <summary>
        /// C点Y轴坐标
        /// </summary>
        public Double CYPoint
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.yc), out txCYPoint);
                return txCYPoint;
            }
            
        }

        Double txCZPoint = 0;
        /// <summary>
        /// C点Z轴坐标
        /// </summary>
        public Double CZPoint
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.zc), out txCZPoint);
                return txCZPoint;
            }
            
        }

        Double txDXPoint = 0;
        /// <summary>
        /// D点X轴坐标
        /// </summary>
        public Double DXPoint
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.xd), out txDXPoint);
                return txDXPoint;
            }
            
        }

        Double txDYPoint = 0;
        /// <summary>
        /// D点Y轴坐标
        /// </summary>
        public Double DYPoint
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.yd), out txDYPoint);
                return txDYPoint;
            }
            
        }

        Double txDZPoint = 0;
        /// <summary>
        /// D点Z轴坐标
        /// </summary>
        public Double DZPoint
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.zd), out txDZPoint);
                return txDZPoint;
            }
            
        }

    }

    #endregion

    #region 控制功能(读写同步读写)

    /// <summary>
    /// 控制功能(同步方式)
    /// </summary>
    public class AsyMotorControlOperate
    {
        bool txRockerReverse = false;
        /// <summary>
        /// 获取或设置取反上下摇杆方向
        /// </summary>
        public bool RockerReverse
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.pc_qufanzfangxian), out txRockerReverse);
                return txRockerReverse;
            }
            set
            {
                //txRockerReverse = value;
                Int32 temp = Convert.ToInt32(value);
                MyOPCObject.WriteData(VariableEnum.pc_qufanzfangxian, temp.ToString());
            }
        }

        bool txPointPlayDn = false;
        /// <summary>
        /// 获取或设置上位机点动放绳按钮
        /// </summary>
        public bool PointPlayDn
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.pc_jog_fangshen), out txPointPlayDn);
                return txPointPlayDn;
            }
            set
            {
                //txPointPlayDn = value;
                Int32 temp = Convert.ToInt32(value);
                MyOPCObject.WriteData(VariableEnum.pc_jog_fangshen, temp.ToString());
            }
        }

        bool txPointPlayUp = false;
        /// <summary>
        /// 获取或设置上位机点动收绳按钮
        /// </summary>
        public bool PointPlayUp
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.pc_jog_shoushen), out txPointPlayUp);
                return txPointPlayUp;
            }
            set
            {
                //txPointPlayUp = value;
                Int32 temp = Convert.ToInt32(value);
                MyOPCObject.WriteData(VariableEnum.pc_jog_shoushen, temp.ToString());
            }
        }

        bool txManualState = false;
        /// <summary>
        /// 获取或设置上位机进入手动调整状态
        /// </summary>
        public bool ManualState
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.pc_man_tiaozhen), out txManualState);
                return txManualState;
            }
            set
            {
                //txManualState = value;
                Int32 temp = Convert.ToInt32(value);
                MyOPCObject.WriteData(VariableEnum.pc_man_tiaozhen, temp.ToString());
            }
        }

        bool txMotor1SelectState = false;
        /// <summary>
        /// 获取或设置上位机对电机1的选择状态
        /// </summary>
        public bool Motor1SelectState
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.pc_5haojog), out txMotor1SelectState);
                return txMotor1SelectState;
            }
            set
            {
                txMotor1SelectState = value;
                MyOPCObject.WriteData(VariableEnum.pc_5haojog, txMotor1SelectState.ToString());
            }
        }

        bool txMotor2SelectState = false;
        /// <summary>
        /// 获取或设置上位机对电机2的选择状态
        /// </summary>
        public bool Motor2SelectState
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.pc_6haojog), out txMotor2SelectState);
                return txMotor2SelectState;
            }
            set
            {
                txMotor2SelectState = value;
                MyOPCObject.WriteData(VariableEnum.pc_6haojog, txMotor2SelectState.ToString());
            }
        }

        bool txMotor3SelectState = false;
        /// <summary>
        /// 获取或设置上位机对电机3的选择状态
        /// </summary>
        public bool Motor3SelectState
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.pc_7haojog), out txMotor3SelectState);
                return txMotor3SelectState;
            }
            set
            {
                txMotor3SelectState = value;
                MyOPCObject.WriteData(VariableEnum.pc_7haojog, txMotor3SelectState.ToString());
            }
        }

        bool txMotor4SelectState = false;
        /// <summary>
        /// 获取或设置上位机对电机4的选择状态
        /// </summary>
        public bool Motor4SelectState
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.pc_8haojog), out txMotor4SelectState);
                return txMotor4SelectState;
            }
            set
            {
                txMotor4SelectState = value;
                MyOPCObject.WriteData(VariableEnum.pc_8haojog, txMotor4SelectState.ToString());
            }
        }

        bool txRockerEnabled = false;
        /// <summary>
        /// 获取或设置上位机禁用启用摇杆
        /// </summary>
        public bool RockerEnabled
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.pc_yaogan_enable), out txRockerEnabled);
                return txRockerEnabled;
            }
            set
            {
                //txRockerEnabled = value;
                Int32 temp = Convert.ToInt32(value);
                MyOPCObject.WriteData(VariableEnum.pc_yaogan_enable, temp.ToString());
            }
        }

        bool txBackPlayInitPoint = false;
        /// <summary>
        /// 获取或设置返回回放路径初始点
        /// </summary>
        public bool BackPlayInitPoint
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.sys_backtochushidian), out txBackPlayInitPoint);
                return txBackPlayInitPoint;
            }
            set
            {
                //txBackPlayInitPoint = value;
                Int32 temp = Convert.ToInt32(value);
                MyOPCObject.WriteData(VariableEnum.sys_backtochushidian, temp.ToString());
            }
        }

        bool txBackPlayInitPointComplete = false;
        /// <summary>
        /// 获取或设置返回回放路径初始点完成
        /// </summary>
        public bool BackPlayInitPointComplete
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.sys_backwancheng), out txBackPlayInitPointComplete);
                return txBackPlayInitPointComplete;
            }
            set
            {
                //txBackPlayInitPointComplete = value;
                Int32 temp = Convert.ToInt32(value);
                MyOPCObject.WriteData(VariableEnum.sys_backwancheng, temp.ToString());
            }
        }

        bool txFaultReset = false;
        /// <summary>
        /// 获取或设置上位机故障复位按钮
        /// </summary>
        public bool FaultReset
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.hmi_ack), out txFaultReset);
                return txFaultReset;
            }
            set
            {
                //txFaultReset = value;
                Int32 temp = Convert.ToInt32(value);
                MyOPCObject.WriteData(VariableEnum.hmi_ack, temp.ToString());
            }
        }

        bool txReplayState = false;
        /// <summary>
        /// 获取或设置是否处于回放状态
        /// </summary>
        public bool ReplayState
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.sys_replay), out txReplayState);
                return txReplayState;
            }
            set
            {
                //txReplayState = value;
                Int32 temp = Convert.ToInt32(value);
                MyOPCObject.WriteData(VariableEnum.sys_replay, temp.ToString());
            }
        }

        Double txReplayOriginPace = 0.0;
        /// <summary>
        /// 获取或设置回回放零点时的速度基准
        /// </summary>
        public Double ReplayOriginPace
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.vh), out txReplayOriginPace);
                return txReplayOriginPace;
            }
            set
            {
                txReplayOriginPace = value;
                MyOPCObject.WriteData(VariableEnum.vh, txReplayOriginPace.ToString());
            }
        }

        Double txReplayOriginX = 0.0;
        /// <summary>
        /// 获取或设置回回放原点的X坐标
        /// </summary>
        public Double ReplayOriginX
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.xh), out txReplayOriginX);
                return txReplayOriginX;
            }
            set
            {
                txReplayOriginX = value;
                MyOPCObject.WriteData(VariableEnum.xh, txReplayOriginX.ToString());
            }
        }

        Double txReplayOriginY = 0.0;
        /// <summary>
        /// 获取或设置回回放原点的Y坐标
        /// </summary>
        public Double ReplayOriginY
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.yh), out txReplayOriginY);
                return txReplayOriginY;
            }
            set
            {
                txReplayOriginY = value;
                MyOPCObject.WriteData(VariableEnum.yh, txReplayOriginY.ToString());
            }
        }

        Double txReplayOriginZ = 0.0;
        /// <summary>
        /// 获取或设置回回放原点的Z坐标
        /// </summary>
        public Double ReplayOriginZ
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.zh), out txReplayOriginZ);
                return txReplayOriginZ;
            }
            set
            {
                txReplayOriginZ = value;
                MyOPCObject.WriteData(VariableEnum.zh, txReplayOriginZ.ToString());
            }
        }

        Double txReplayDnPaceX = 0.0;
        /// <summary>
        /// 获取或设置回放时上位机给的运动信号 X方向
        /// </summary>
        public Double ReplayDnPaceX
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_hf_vx), out txReplayDnPaceX);
                return txReplayDnPaceX;
            }
            set
            {
                txReplayDnPaceX = value;
                MyOPCObject.WriteData(VariableEnum.pc_hf_vx, txReplayDnPaceX.ToString());
            }
        }

        Double txReplayDnPaceY = 0.0;
        /// <summary>
        /// 获取或设置回放时上位机给的运动信号 Y方向
        /// </summary>
        public Double ReplayDnPaceY
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_hf_vy), out txReplayDnPaceY);
                return txReplayDnPaceY;
            }
            set
            {
                txReplayDnPaceY = value;
                MyOPCObject.WriteData(VariableEnum.pc_hf_vy, txReplayDnPaceY.ToString());
            }
        }

        Double txReplayDnPaceZ = 0.0;
        /// <summary>
        /// 获取或设置回放时上位机给的运动信号 Z方向
        /// </summary>
        public Double ReplayDnPaceZ
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_hf_vz), out txReplayDnPaceZ);
                return txReplayDnPaceZ;
            }
            set
            {
                txReplayDnPaceZ = value;
                MyOPCObject.WriteData(VariableEnum.pc_hf_vz, txReplayDnPaceZ.ToString());
            }
        }

        Double txRecX = 0.0;
        /// <summary>
        /// 获取或设置录制信号 X方向
        /// </summary>
        public Double RecX
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_jl_vx), out txRecX);
                return txRecX;
            }
            set
            {
                txRecX = value;
                MyOPCObject.WriteData(VariableEnum.pc_jl_vx, txRecX.ToString());
            }
        }

        Double txRecY = 0.0;
        /// <summary>
        /// 获取或设置录制信号 Y方向
        /// </summary>
        public Double RecY
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_jl_vy), out txRecY);
                return txRecY;
            }
            set
            {
                txRecY = value;
                MyOPCObject.WriteData(VariableEnum.pc_jl_vy, txRecY.ToString());
            }
        }

        Double txRecZ = 0.0;
        /// <summary>
        /// 获取或设置录制信号 Z方向
        /// </summary>
        public Double RecZ
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_jl_vz), out txRecZ);
                return txRecZ;
            }
            set
            {
                txRecZ = value;
                MyOPCObject.WriteData(VariableEnum.pc_jl_vz, txRecZ.ToString());
            }
        }

        Double txControlCircAngle = 0.0;
        /// <summary>
        /// 获取或设置坐标旋转角度
        /// </summary>
        public Double ControlCircAngle
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.sys_xyxuanzhuanjiaodu), out txControlCircAngle);
                return txControlCircAngle;
            }
            set
            {
                txControlCircAngle = value;
                MyOPCObject.WriteData(VariableEnum.sys_xyxuanzhuanjiaodu, txControlCircAngle.ToString());
            }
        }

        Double txControlPaceAdd = 0.0;
        /// <summary>
        /// 获取或设置速度斜坡控制增量
        /// </summary>
        public Double ControlPaceAdd
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.sys_xiepozhengliang), out txControlPaceAdd);
                return txControlPaceAdd;
            }
            set
            {
                txControlPaceAdd = value;
                MyOPCObject.WriteData(VariableEnum.sys_xiepozhengliang, txControlPaceAdd.ToString());
            }
        }

        Double txConfigPMaxPace = 0.0;
        /// <summary>
        /// 获取或设置P点X、Y轴移动最快速度
        /// </summary>
        public Double ConfigPMaxPace
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_pintai_vmax), out txConfigPMaxPace);
                return txConfigPMaxPace;
            }
            set
            {
                txConfigPMaxPace = value;
                MyOPCObject.WriteData(VariableEnum.pc_pintai_vmax, txConfigPMaxPace.ToString());
            }
        }

        Double txConfigManualMaxPace = 0.0;
        /// <summary>
        /// 获取或设置上位机手动速度给定
        /// </summary>
        public Double ConfigManualMaxPace
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_shoudongsudugeiding), out txConfigManualMaxPace);
                return txConfigManualMaxPace;
            }
            set
            {
                txConfigManualMaxPace = value;
                MyOPCObject.WriteData(VariableEnum.pc_shoudongsudugeiding, txConfigManualMaxPace.ToString());
            }
        }

        Double txConfigRockerSensitive = 0.0;
        /// <summary>
        /// 获取或设置X、Y轴摇杆灵敏度，范围：0-10
        /// </summary>
        public Double ConfigRockerSensitive
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_yaoganlingmingdu), out txConfigRockerSensitive);
                return txConfigRockerSensitive;
            }
            set
            {
                txConfigRockerSensitive = value;
                MyOPCObject.WriteData(VariableEnum.pc_yaoganlingmingdu, txConfigRockerSensitive.ToString());
            }
        }

        Double txConfigPaceCoefficient = 0.0;
        /// <summary>
        /// 获取或设置计算垂直于各边速度时的系数
        /// </summary>
        public Double ConfigPaceCoefficient
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.sys_shouxianxishu), out txConfigPaceCoefficient);
                return txConfigPaceCoefficient;
            }
            set
            {
                txConfigPaceCoefficient = value;
                MyOPCObject.WriteData(VariableEnum.sys_shouxianxishu, txConfigPaceCoefficient.ToString());
            }
        }

        Double txConfigAHeight = 0.0;
        /// <summary>
        ///获取或设置A站高度
        /// </summary>
        public Double ConfigAHeight
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.long_a_gaodu), out txConfigAHeight);
                return txConfigAHeight;
            }
            set
            {
                txConfigAHeight = value;
                MyOPCObject.WriteData(VariableEnum.long_a_gaodu, txConfigAHeight.ToString());
            }
        }

        Double txConfigBHeight = 0.0;
        /// <summary>
        ///获取或设置B站高度
        /// </summary>
        public Double ConfigBHeight
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.long_b_gaodu), out txConfigBHeight);
                return txConfigBHeight;
            }
            set
            {
                txConfigBHeight = value;
                MyOPCObject.WriteData(VariableEnum.long_b_gaodu, txConfigBHeight.ToString());
            }
        }

        Double txConfigCHeight = 0.0;
        /// <summary>
        ///获取或设置C站高度
        /// </summary>
        public Double ConfigCHeight
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.long_c_gaodu), out txConfigCHeight);
                return txConfigCHeight;
            }
            set
            {
                txConfigCHeight = value;
                MyOPCObject.WriteData(VariableEnum.long_c_gaodu, txConfigCHeight.ToString());
            }
        }

        Double txConfigDHeight = 0.0;
        /// <summary>
        ///获取或设置D站高度
        /// </summary>
        public Double ConfigDHeight
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.long_d_gaodu), out txConfigDHeight);
                return txConfigDHeight;
            }
            set
            {
                txConfigDHeight = value;
                MyOPCObject.WriteData(VariableEnum.long_d_gaodu, txConfigDHeight.ToString());
            }
        }

        Double txConfigAllHeight = 0.0;
        /// <summary>
        ///获取或设置全站仪高度设定
        /// </summary>
        public Double ConfigAllHeight
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.long_quanzhanyigaodu), out txConfigAllHeight);
                return txConfigAllHeight;
            }
            set
            {
                txConfigAllHeight = value;
                MyOPCObject.WriteData(VariableEnum.long_quanzhanyigaodu, txConfigAllHeight.ToString());
            }
        }

        Double txConfigABWidth = 0.0;
        /// <summary>
        ///获取或设置AB站水平宽度
        /// </summary>
        public Double ConfigABWidth
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.long_ab_kuandu), out txConfigABWidth);
                return txConfigABWidth;
            }
            set
            {
                txConfigABWidth = value;
                MyOPCObject.WriteData(VariableEnum.long_ab_kuandu, txConfigABWidth.ToString());
            }
        }

        Double txConfigBCWidth = 0.0;
        /// <summary>
        ///获取或设置BC站水平宽度
        /// </summary>
        public Double ConfigBCWidth
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.long_bc_kuandu), out txConfigBCWidth);
                return txConfigBCWidth;
            }
            set
            {
                txConfigBCWidth = value;
                MyOPCObject.WriteData(VariableEnum.long_bc_kuandu, txConfigBCWidth.ToString());
            }
        }

        Double txConfigCDWidth = 0.0;
        /// <summary>
        ///获取或设置CD站水平宽度
        /// </summary>
        public Double ConfigCDWidth
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.long_cd_kuandu), out txConfigCDWidth);
                return txConfigCDWidth;
            }
            set
            {
                txConfigCDWidth = value;
                MyOPCObject.WriteData(VariableEnum.long_cd_kuandu, txConfigCDWidth.ToString());
            }
        }

        Double txConfigDAWidth = 0.0;
        /// <summary>
        ///获取或设置DA站水平宽度
        /// </summary>
        public Double ConfigDAWidth
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.long_da_kuandu), out txConfigDAWidth);
                return txConfigDAWidth;
            }
            set
            {
                txConfigDAWidth = value;
                MyOPCObject.WriteData(VariableEnum.long_da_kuandu, txConfigDAWidth.ToString());
            }
        }

        Double txConfigTwoMotorSelect = 0.0;
        /// <summary>
        ///获取或设置上位机区别测量的是AP、BP、CP或DP		BYTE	二次测量电机选择 0A 1B 2C 3D
        /// </summary>
        public Double ConfigTwoMotorSelect
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_qubieabcd), out txConfigTwoMotorSelect);
                return txConfigTwoMotorSelect;
            }
            set
            {
                txConfigTwoMotorSelect = value;
                MyOPCObject.WriteData(VariableEnum.pc_qubieabcd, txConfigTwoMotorSelect.ToString());
            }
        }

        Double txConfigRockerSensitiveZ = 0.0;
        /// <summary>
        /// 获取或设置Z轴摇杆灵敏度，范围：0-10
        /// </summary>
        public Double ConfigRockerSensitiveZ
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_yaoganlingmingdu_z), out txConfigRockerSensitiveZ);
                return txConfigRockerSensitiveZ;
            }
            set
            {
                txConfigRockerSensitiveZ = value;
                MyOPCObject.WriteData(VariableEnum.pc_yaoganlingmingdu_z, txConfigRockerSensitiveZ.ToString());
            }
        }

        Double txControlPaceAddZ = 0.0;
        /// <summary>
        /// 获取或设置Z轴速度斜坡控制增量
        /// </summary>
        public Double ControlPaceAddZ
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.sys_xiepozhengliang_z), out txControlPaceAddZ);
                return txControlPaceAddZ;
            }
            set
            {
                txControlPaceAddZ = value;
                MyOPCObject.WriteData(VariableEnum.sys_xiepozhengliang_z, txControlPaceAddZ.ToString());
            }
        }

        Double txConfigPMaxPaceZ = 0.0;
        /// <summary>
        /// 获取或设置P点Z轴移动最快速度
        /// </summary>
        public Double ConfigPMaxPaceZ
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_pintai_vmax_z), out txConfigPMaxPaceZ);
                return txConfigPMaxPaceZ;
            }
            set
            {
                txConfigPMaxPaceZ = value;
                MyOPCObject.WriteData(VariableEnum.pc_pintai_vmax_z, txConfigPMaxPaceZ.ToString());
            }
        }

        Int32 txCommTestCount = 0;
        /// <summary>
        /// 获取或设置通信测试计算值,范围是0~100
        /// </summary>
        public Int32 CommTestCount
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.pc_tongxunceshi), out txCommTestCount);
                return txCommTestCount;
            }
            set
            {
                txCommTestCount = value;
                MyOPCObject.WriteData(VariableEnum.pc_tongxunceshi, txCommTestCount.ToString());
            }
        }

        Double txConfigRockerXpMaxNum = 0.0;
        /// <summary>
        /// 获取或设置摇杆X正向最大值,数值为百分数范围20~100
        /// </summary>
        public Double ConfigRockerXpMaxNum
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_yaoganmax_xzheng), out txConfigRockerXpMaxNum);
                return txConfigRockerXpMaxNum;
            }
            set
            {
                txConfigRockerXpMaxNum = value;
                MyOPCObject.WriteData(VariableEnum.pc_yaoganmax_xzheng, txConfigRockerXpMaxNum.ToString());
            }
        }

        Double txConfigRockerXnMaxNum = 0.0;
        /// <summary>
        /// 获取或设置摇杆X负向最大值,数值为百分数范围-20~-100
        /// </summary>
        public Double ConfigRockerXnMaxNum
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_yaoganmax_xfu), out txConfigRockerXnMaxNum);
                return txConfigRockerXnMaxNum;
            }
            set
            {
                txConfigRockerXnMaxNum = value;
                MyOPCObject.WriteData(VariableEnum.pc_yaoganmax_xfu, txConfigRockerXnMaxNum.ToString());
            }
        }

        Double txConfigRockerYpMaxNum = 0.0;
        /// <summary>
        /// 获取或设置摇杆Y正向最大值,数值为百分数范围20~100
        /// </summary>
        public Double ConfigRockerYpMaxNum
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_yaoganmax_yzheng), out txConfigRockerYpMaxNum);
                return txConfigRockerYpMaxNum;
            }
            set
            {
                txConfigRockerYpMaxNum = value;
                MyOPCObject.WriteData(VariableEnum.pc_yaoganmax_yzheng, txConfigRockerYpMaxNum.ToString());
            }
        }

        Double txConfigRockerYnMaxNum = 0.0;
        /// <summary>
        /// 获取或设置摇杆Y负向最大值,数值为百分数范围-20~-100
        /// </summary>
        public Double ConfigRockerYnMaxNum
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_yaoganmax_yfu), out txConfigRockerYnMaxNum);
                return txConfigRockerYnMaxNum;
            }
            set
            {
                txConfigRockerYnMaxNum = value;
                MyOPCObject.WriteData(VariableEnum.pc_yaoganmax_yfu, txConfigRockerYnMaxNum.ToString());
            }
        }

        Double txConfigRockerZpMaxNum = 0.0;
        /// <summary>
        /// 获取或设置摇杆Z正向最大值,数值为百分数范围20~100
        /// </summary>
        public Double ConfigRockerZpMaxNum
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_yaoganmax_zzheng), out txConfigRockerZpMaxNum);
                return txConfigRockerZpMaxNum;
            }
            set
            {
                txConfigRockerZpMaxNum = value;
                MyOPCObject.WriteData(VariableEnum.pc_yaoganmax_zzheng, txConfigRockerZpMaxNum.ToString());
            }
        }

        Double txConfigRockerZnMaxNum = 0.0;
        /// <summary>
        /// 获取或设置摇杆Z负向最大值,数值为百分数范围-20~-100
        /// </summary>
        public Double ConfigRockerZnMaxNum
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_yaoganmax_zfu), out txConfigRockerZnMaxNum);
                return txConfigRockerZnMaxNum;
            }
            set
            {
                txConfigRockerZnMaxNum = value;
                MyOPCObject.WriteData(VariableEnum.pc_yaoganmax_zfu, txConfigRockerZnMaxNum.ToString());
            }
        }

        Double txConfigRockerXNum = 0.0;
        /// <summary>
        /// 获取或设置摇杆X值,数值为百分数范围-100~100
        /// </summary>
        public Double ConfigRockerXNum
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_qianhouyangan_1), out txConfigRockerXNum);
                return txConfigRockerXNum;
            }
            set
            {
                txConfigRockerXNum = value;
                MyOPCObject.WriteData(VariableEnum.pc_qianhouyangan_1, txConfigRockerXNum.ToString());
            }
        }

        Double txConfigRockerYNum = 0.0;
        /// <summary>
        /// 获取或设置摇杆Y值,数值为百分数范围-100~100
        /// </summary>
        public Double ConfigRockerYNum
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_zuoyouyaogan_1), out txConfigRockerYNum);
                return txConfigRockerYNum;
            }
            set
            {
                txConfigRockerYNum = value;
                MyOPCObject.WriteData(VariableEnum.pc_zuoyouyaogan_1, txConfigRockerYNum.ToString());
            }
        }

        Double txConfigRockerZNum = 0.0;
        /// <summary>
        /// 获取或设置摇杆Z值,数值为百分数范围-100~100
        /// </summary>
        public Double ConfigRockerZNum
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_shangxiayaogan_1), out txConfigRockerZNum);
                return txConfigRockerZNum;
            }
            set
            {
                txConfigRockerZNum = value;
                MyOPCObject.WriteData(VariableEnum.pc_shangxiayaogan_1, txConfigRockerZNum.ToString());
            }
        }

        Double txConfigRockerXPaceArea = 0.0;
        /// <summary>
        /// 获取或设置摇杆X的速度死区大小,数值为百分数范围0~100
        /// </summary>
        public Double ConfigRockerXPaceArea
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.sys_dead_area_x), out txConfigRockerXPaceArea);
                return txConfigRockerXPaceArea;
            }
            set
            {
                txConfigRockerXPaceArea = value;
                MyOPCObject.WriteData(VariableEnum.sys_dead_area_x, txConfigRockerXPaceArea.ToString());
            }
        }

        Double txConfigRockerYPaceArea = 0.0;
        /// <summary>
        /// 获取或设置摇杆Y的速度死区大小,数值为百分数范围0~100
        /// </summary>
        public Double ConfigRockerYPaceArea
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.sys_dead_area_y), out txConfigRockerYPaceArea);
                return txConfigRockerYPaceArea;
            }
            set
            {
                txConfigRockerYPaceArea = value;
                MyOPCObject.WriteData(VariableEnum.sys_dead_area_y, txConfigRockerYPaceArea.ToString());
            }
        }

        Double txConfigRockerZPaceArea = 0.0;
        /// <summary>
        /// 获取或设置摇杆Z的速度死区大小,数值为百分数范围0~100
        /// </summary>
        public Double ConfigRockerZPaceArea
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.sys_dead_area_z), out txConfigRockerZPaceArea);
                return txConfigRockerZPaceArea;
            }
            set
            {
                txConfigRockerZPaceArea = value;
                MyOPCObject.WriteData(VariableEnum.sys_dead_area_z, txConfigRockerZPaceArea.ToString());
            }
        }

        Int32 txConfigRockerXZeroOffset = 0;
        /// <summary>
        /// 获取或设置摇杆X的零漂值,数值为百分数范围-10000~10000
        /// </summary>
        public Int32 ConfigRockerXZeroOffset
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.pc_yaogan_piaoyi_x), out txConfigRockerXZeroOffset);
                return txConfigRockerXZeroOffset;
            }
            set
            {
                txConfigRockerXZeroOffset = value;
                MyOPCObject.WriteData(VariableEnum.pc_yaogan_piaoyi_x, txConfigRockerXZeroOffset.ToString());
            }
        }

        Int32 txConfigRockerYZeroOffset = 0;
        /// <summary>
        /// 获取或设置摇杆Y的零漂值,数值为百分数范围-10000~10000
        /// </summary>
        public Int32 ConfigRockerYZeroOffset
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.pc_yaogan_piaoyi_y), out txConfigRockerYZeroOffset);
                return txConfigRockerYZeroOffset;
            }
            set
            {
                txConfigRockerYZeroOffset = value;
                MyOPCObject.WriteData(VariableEnum.pc_yaogan_piaoyi_y, txConfigRockerYZeroOffset.ToString());
            }
        }

        Int32 txConfigRockerZZeroOffset = 0;
        /// <summary>
        /// 获取或设置摇杆Z的零漂值,数值为百分数范围-10000~10000
        /// </summary>
        public Int32 ConfigRockerZZeroOffset
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.pc_yaogan_piaoyi_z), out txConfigRockerZZeroOffset);
                return txConfigRockerZZeroOffset;
            }
            set
            {
                txConfigRockerZZeroOffset = value;
                MyOPCObject.WriteData(VariableEnum.pc_yaogan_piaoyi_z, txConfigRockerZZeroOffset.ToString());
            }
        }

        Int32 txRecTimeCount = 0;
        /// <summary>
        /// 获取或设置录制时间ms
        /// </summary>
        public Int32 RecTime
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.pc_luzhi_time), out txRecTimeCount);
                return txRecTimeCount;
            }
            set
            {
                txRecTimeCount = value;
                MyOPCObject.WriteData(VariableEnum.pc_luzhi_time, txRecTimeCount.ToString());
            }
        }

        bool txRecStart = false;
        /// <summary>
        /// 获取或设置录制开始状态
        /// </summary>
        public bool RecStart
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.pc_luzhi_start), out txRecStart);
                return txRecStart;
            }
            set
            {
                //txRecStart = value;
                Int32 temp = Convert.ToInt32(value);
                MyOPCObject.WriteData(VariableEnum.pc_luzhi_start, temp.ToString());
            }
        }

        bool txReplayStart = false;
        /// <summary>
        /// 获取或设置回放开始状态
        /// </summary>
        public bool ReplayStart
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.pc_huifang_start), out txReplayStart);
                return txReplayStart;
            }
            set
            {
                //txReplayStart = value;
                Int32 temp = Convert.ToInt32(value);
                MyOPCObject.WriteData(VariableEnum.pc_huifang_start, temp.ToString());
            }
        }

        Int32 txRecPointCount = 0;
        /// <summary>
        /// 获取或设置录制点数
        /// </summary>
        public Int32 RecPointCount
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.pc_luzhi_lengh), out txRecPointCount);
                return txRecPointCount;
            }
            set
            {
                txRecPointCount = value;
                MyOPCObject.WriteData(VariableEnum.pc_luzhi_lengh, txRecPointCount.ToString());
            }
        }

        Int32 txRecPointCountP = 0;
        /// <summary>
        /// 获取或设置录制点数指针
        /// </summary>
        public Int32 RecPointCountP
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.zhizhen_vx), out txRecPointCountP);
                return txRecPointCountP;
            }
            set
            {
                txRecPointCountP = value;
                MyOPCObject.WriteData(VariableEnum.zhizhen_vx, txRecPointCountP.ToString());
            }
        }

        bool txReadRecPointStart = false;
        /// <summary>
        /// 获取或设置读取录制数据开始状态
        /// </summary>
        public bool ReadRecPointStart
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.pc_duqu_shuju), out txReadRecPointStart);
                return txReadRecPointStart;
            }
            set
            {
                txReadRecPointStart = value;
                MyOPCObject.WriteData(VariableEnum.pc_duqu_shuju, txReadRecPointStart.ToString());
            }
        }

        Int32 txRecDataGroupNum = 0;
        /// <summary>
        /// 获取或设置录制数据的组数
        /// </summary>
        public Int32 RecDataGroupNum
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.pc_shujuzushu), out txRecDataGroupNum);
                return txRecDataGroupNum;
            }
            set
            {
                txRecDataGroupNum = value;
                MyOPCObject.WriteData(VariableEnum.pc_shujuzushu, txRecDataGroupNum.ToString());
            }
        }

        bool txWriteRecPointStart = false;
        /// <summary>
        /// 获取或设置写入录制数据开始状态
        /// </summary>
        public bool WriteRecPointStart
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.pc_xiachua_shuju), out txWriteRecPointStart);
                return txWriteRecPointStart;
            }
            set
            {
                txWriteRecPointStart = value;
                MyOPCObject.WriteData(VariableEnum.pc_xiachua_shuju, txWriteRecPointStart.ToString());
            }
        }

        string txArrRecXData = string.Empty;
        /// <summary>
        /// 获取或设置录制X轴数据数组字符串,数据直接用','分开
        /// </summary>
        public string ArrRecXData
        {
            get
            {
                txArrRecXData = MyOPCObject.ReadData(VariableEnum.temp_vx);
                int index = txArrRecXData.IndexOfAny(new char[1]{')'});
                if (index < txArrRecXData.Length)
                {
                    txArrRecXData = txArrRecXData.Substring(index+1);
                }
                return txArrRecXData;
            }
            set
            {
                txArrRecXData = value;
                MyOPCObject.WriteData(VariableEnum.temp_vx, txArrRecXData);
            }
        }

        string txArrRecYData = string.Empty;
        /// <summary>
        /// 获取或设置录制Y轴数据数组字符串,数据直接用','分开
        /// </summary>
        public string ArrRecYData
        {
            get
            {
                txArrRecYData = MyOPCObject.ReadData(VariableEnum.temp_vy);
                int index = txArrRecYData.IndexOfAny(new char[1] { ')' });
                if (index < txArrRecYData.Length)
                {
                    txArrRecYData = txArrRecYData.Substring(index+1);
                }
                return txArrRecYData;
            }
            set
            {
                txArrRecYData = value;
                MyOPCObject.WriteData(VariableEnum.temp_vy, txArrRecYData);
            }
        }

        string txArrRecZData = string.Empty;
        /// <summary>
        /// 获取或设置录制Z轴数据数组字符串,数据直接用','分开
        /// </summary>
        public string ArrRecZData
        {
            get
            {
                txArrRecZData = MyOPCObject.ReadData(VariableEnum.temp_vz);
                int index = txArrRecZData.IndexOfAny(new char[1] { ')' });
                if (index < txArrRecZData.Length)
                {
                    txArrRecZData = txArrRecZData.Substring(index+1);
                }
                return txArrRecZData;
            }
            set
            {
                txArrRecZData = value;
                MyOPCObject.WriteData(VariableEnum.temp_vz, txArrRecZData);
            }
        }

        Int32 txReadRecDataGroupCount = 0;
        /// <summary>
        /// 获取或设置读取录制数据的组计数
        /// </summary>
        public Int32 ReadRecDataGroupCount
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.temp_zushu), out txReadRecDataGroupCount);
                return txReadRecDataGroupCount;
            }
            set
            {
                txReadRecDataGroupCount = value;
                MyOPCObject.WriteData(VariableEnum.temp_zushu, txReadRecDataGroupCount.ToString());
            }
        }

        bool txRecUpdateCompleted = false;
        /// <summary>
        /// 获取或设置上传录制数据完成状态
        /// </summary>
        public bool RecUpdateCompleted
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.temp_readok), out txRecUpdateCompleted);
                return txRecUpdateCompleted;
            }
            set
            {
                txRecUpdateCompleted = value;
                MyOPCObject.WriteData(VariableEnum.temp_readok, txRecUpdateCompleted.ToString());
            }
        }

        bool txTm31CommState1 = false;
        /// <summary>
        /// 1号TM31通讯断开
        /// </summary>
        public bool Tm31CommState1
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.sys_tm3101_jiance), out txTm31CommState1);
                return txTm31CommState1;
            }
            //set
            //{
            //    txTm31CommState1 = value;
            //    MyOPCObject.WriteData(VariableEnum.sys_tm3101_jiance, txTm31CommState1.ToString());
            //}
        }

        bool txTm31CommState2 = false;
        /// <summary>
        /// 2号TM31通讯断开
        /// </summary>
        public bool Tm31CommState2
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.sys_tm3102_jiance), out txTm31CommState2);
                return txTm31CommState2;
            }
            //set
            //{
            //    txTm31CommState2 = value;
            //    MyOPCObject.WriteData(VariableEnum.sys_tm3102_jiance, txTm31CommState2.ToString());
            //}
        }

        Int32 txTm31Alarm1 = 0;
        /// <summary>
        /// 1号TM31报警号
        /// </summary>
        public Int32 Tm31Alarm1
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.no2_tm31_alm_1), out txTm31Alarm1);
                return txTm31Alarm1;
            }
            //set
            //{
            //    txTm31Alarm1 = value;
            //    MyOPCObject.WriteData(VariableEnum.no2_tm31_alm_1, txTm31Alarm1.ToString());
            //}
        }

        Int32 txTm31Alarm2 = 0;
        /// <summary>
        /// 2号TM31报警号
        /// </summary>
        public Int32 Tm31Alarm2
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.no2_tm31_alm_2), out txTm31Alarm2);
                return txTm31Alarm2;
            }
            //set
            //{
            //    txTm31Alarm2 = value;
            //    MyOPCObject.WriteData(VariableEnum.no2_tm31_alm_2, txTm31Alarm2.ToString());
            //}
        }

        Int32 txMainServoAlarm1 = 0;
        /// <summary>
        /// 1号主伺服报警号
        /// </summary>
        public Int32 MainServoAlarm1
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.no5_alm), out txMainServoAlarm1);
                return txMainServoAlarm1;
            }
            //set
            //{
            //    txMainServoAlarm1 = value;
            //    MyOPCObject.WriteData(VariableEnum.no5_alm, txMainServoAlarm1.ToString());
            //}
        }

        Int32 txMainServoAlarm2 = 0;
        /// <summary>
        /// 2号主伺服报警号
        /// </summary>
        public Int32 MainServoAlarm2
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.no6_alm), out txMainServoAlarm2);
                return txMainServoAlarm2;
            }
            //set
            //{
            //    txMainServoAlarm2 = value;
            //    MyOPCObject.WriteData(VariableEnum.no6_alm, txMainServoAlarm2.ToString());
            //}
        }

        Int32 txMainServoAlarm3 = 0;
        /// <summary>
        /// 3号主伺服报警号
        /// </summary>
        public Int32 MainServoAlarm3
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.no7_alm), out txMainServoAlarm3);
                return txMainServoAlarm3;
            }
            //set
            //{
            //    txMainServoAlarm3 = value;
            //    MyOPCObject.WriteData(VariableEnum.no7_alm, txMainServoAlarm3.ToString());
            //}
        }

        Int32 txMainServoAlarm4 = 0;
        /// <summary>
        /// 4号主伺服报警号
        /// </summary>
        public Int32 MainServoAlarm4
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.no8_alm), out txMainServoAlarm4);
                return txMainServoAlarm4;
            }
            //set
            //{
            //    txMainServoAlarm4 = value;
            //    MyOPCObject.WriteData(VariableEnum.no8_alm, txMainServoAlarm4.ToString());
            //}
        }

        Int32 txMainControlAlarm1 = 0;
        /// <summary>
        /// 1号主控制器报警号
        /// </summary>
        public Int32 MainControlAlarm1
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.no5_cu_alm), out txMainControlAlarm1);
                return txMainControlAlarm1;
            }
            //set
            //{
            //    txMainControlAlarm1 = value;
            //    MyOPCObject.WriteData(VariableEnum.no5_cu_alm, txMainControlAlarm1.ToString());
            //}
        }

        Int32 txMainControlAlarm2 = 0;
        /// <summary>
        /// 2号主控制器报警号
        /// </summary>
        public Int32 MainControlAlarm2
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.no6_cu_alm), out txMainControlAlarm2);
                return txMainControlAlarm2;
            }
            //set
            //{
            //    txMainControlAlarm2 = value;
            //    MyOPCObject.WriteData(VariableEnum.no6_cu_alm, txMainControlAlarm2.ToString());
            //}
        }

        Int32 txMainControlAlarm3 = 0;
        /// <summary>
        /// 3号主控制器报警号
        /// </summary>
        public Int32 MainControlAlarm3
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.no7_cu_alm), out txMainControlAlarm3);
                return txMainControlAlarm3;
            }
            //set
            //{
            //    txMainControlAlarm3 = value;
            //    MyOPCObject.WriteData(VariableEnum.no7_cu_alm, txMainControlAlarm3.ToString());
            //}
        }

        Int32 txMainControlAlarm4 = 0;
        /// <summary>
        /// 4号主控制器报警号
        /// </summary>
        public Int32 MainControlAlarm4
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.no8_cu_alm), out txMainControlAlarm4);
                return txMainControlAlarm4;
            }
            //set
            //{
            //    txMainControlAlarm4 = value;
            //    MyOPCObject.WriteData(VariableEnum.no8_cu_alm, txMainControlAlarm4.ToString());
            //}
        }

        Int32 txD435ControlAlarm = 0;
        /// <summary>
        /// D435集成控制器报警号
        /// </summary>
        public Int32 D435ControlAlarm
        {
            get
            {
                Int32.TryParse(MyOPCObject.ReadData(VariableEnum.no1_cu0_alm), out txD435ControlAlarm);
                return txD435ControlAlarm;
            }
            //set
            //{
            //    txD435ControlAlarm = value;
            //    MyOPCObject.WriteData(VariableEnum.no1_cu0_alm, txD435ControlAlarm.ToString());
            //}
        }

        bool txAxisDiscrepancyState = false;
        /// <summary>
        /// 轴误差状态是否正常
        /// </summary>
        public bool AxisDiscrepancyState
        {
            get
            {
                bool.TryParse(MyOPCObject.ReadData(VariableEnum.bz_keyiyunxing), out txAxisDiscrepancyState);
                return txAxisDiscrepancyState;
            }
            //set
            //{
            //    txAxisDiscrepancyState = value;
            //    MyOPCObject.WriteData(VariableEnum.bz_keyiyunxing, txAxisDiscrepancyState.ToString());
            //}
        }
    }

    #endregion

    #region 初始状态(读写同步读写)
    /// <summary>
    /// 初始参数设置(同步方式)
    /// </summary>
    public class AsyMotorInitValue
    {
        Double txZHConfine = 0;
        /// <summary>
        /// 最高点夹角Z坐标限制
        /// </summary>
        public Double ConfineHJJZ
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.sys_jiajiaojiaodu), out txZHConfine);
                return txZHConfine;
            }
            set
            {
                txZHConfine = value;
                MyOPCObject.WriteData(VariableEnum.sys_jiajiaojiaodu, txZHConfine.ToString());
            }
        }

        Double txZLConfine = 0;
        /// <summary>
        /// 最低点Z坐标限制
        /// </summary>
        public Double ConfineZ
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.sys_zmin), out txZLConfine);
                return txZLConfine;
            }
            set
            {
                txZLConfine = value;
                MyOPCObject.WriteData(VariableEnum.sys_zmin, txZLConfine.ToString());
            }
        }

        Double txPADSpace = 0;
        /// <summary>
        /// P点距AD边水平投影设定距离
        /// </summary>
        public Double PSpaceAD
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_p_da), out txPADSpace);
                return txPADSpace;
            }
            set
            {
                txPADSpace = value;
                MyOPCObject.WriteData(VariableEnum.pc_p_da, txPADSpace.ToString());
            }
        }

        Double txPBCSpace = 0;
        /// <summary>
        /// P点距BC边水平投影设定距离
        /// </summary>
        public Double PSpaceBC
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_p_bc), out txPBCSpace);
                return txPBCSpace;
            }
            set
            {
                txPBCSpace = value;
                MyOPCObject.WriteData(VariableEnum.pc_p_bc, txPBCSpace.ToString());
            }
        }

        Double txPABSpace = 0;
        /// <summary>
        /// P点距AB边水平投影设定距离
        /// </summary>
        public Double PSpaceAB
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_p_ab), out txPABSpace);
                return txPABSpace;
            }
            set
            {
                txPABSpace = value;
                MyOPCObject.WriteData(VariableEnum.pc_p_ab, txPABSpace.ToString());
            }
        }

        Double txPCDSpace = 0;
        /// <summary>
        /// P点距CD边水平投影设定距离
        /// </summary>
        public Double PSpaceCD
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.pc_p_cd), out txPCDSpace);
                return txPCDSpace;
            }
            set
            {
                txPCDSpace = value;
                MyOPCObject.WriteData(VariableEnum.pc_p_cd, txPCDSpace.ToString());
            }
        }

        Double txASpace = 0;
        /// <summary>
        /// A点测量距离
        /// </summary>
        public Double ASpace
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.longa), out txASpace);
                return txASpace;
            }
            set
            {
                txASpace = value;
                MyOPCObject.WriteData(VariableEnum.longa, txASpace.ToString());
            }
        }

        Double txBSpace = 0;
        /// <summary>
        /// B点测量距离
        /// </summary>
        public Double BSpace
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.longb), out txBSpace);
                return txBSpace;
            }
            set
            {
                txBSpace = value;
                MyOPCObject.WriteData(VariableEnum.longb, txBSpace.ToString());
            }
        }

        Double txCSpace = 0;
        /// <summary>
        /// C点测量距离
        /// </summary>
        public Double CSpace
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.longc), out txCSpace);
                return txCSpace;
            }
            set
            {
                txCSpace = value;
                MyOPCObject.WriteData(VariableEnum.longc, txCSpace.ToString());
            }
        }

        Double txDSpace = 0;
        /// <summary>
        /// D点测量距离
        /// </summary>
        public Double DSpace
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.longd), out txDSpace);
                return txDSpace;
            }
            set
            {
                txDSpace = value;
                MyOPCObject.WriteData(VariableEnum.longd, txDSpace.ToString());
            }
        }

        Double txPSpace = 0;
        /// <summary>
        /// P点测量距离
        /// </summary>
        public Double PSpace
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.longp), out txPSpace);
                return txPSpace;
            }
            set
            {
                txPSpace = value;
                MyOPCObject.WriteData(VariableEnum.longp, txPSpace.ToString());
            }
        }

        Double txPLevel = 0;
        /// <summary>
        /// P点水平角
        /// </summary>
        public Double PLevel
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.sppj), out txPLevel);
                return txPLevel;
            }
            set
            {
                txPLevel = value;
                MyOPCObject.WriteData(VariableEnum.sppj, txPLevel.ToString());
            }
        }

        Double txALevel = 0;
        /// <summary>
        /// A点水平角
        /// </summary>
        public Double ALevel
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.spaj), out txALevel);
                return txALevel;
            }
            set
            {
                txALevel = value;
                MyOPCObject.WriteData(VariableEnum.spaj, txALevel.ToString());
            }
        }

        Double txBLevel = 0;
        /// <summary>
        /// B点水平角
        /// </summary>
        public Double BLevel
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.spbj), out txBLevel);
                return txBLevel;
            }
            set
            {
                txBLevel = value;
                MyOPCObject.WriteData(VariableEnum.spbj, txBLevel.ToString());
            }
        }

        Double txCLevel = 0;
        /// <summary>
        /// C点水平角
        /// </summary>
        public Double CLevel
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.spcj), out txCLevel);
                return txCLevel;
            }
            set
            {
                txCLevel = value;
                MyOPCObject.WriteData(VariableEnum.spcj, txCLevel.ToString());
            }
        }

        Double txDLevel = 0;
        /// <summary>
        /// D点水平角
        /// </summary>
        public Double DLevel
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.spdj), out txDLevel);
                return txDLevel;
            }
            set
            {
                txDLevel = value;
                MyOPCObject.WriteData(VariableEnum.spdj, txDLevel.ToString());
            }
        }

        Double txPUp = 0;
        /// <summary>
        /// P点仰角
        /// </summary>
        public Double PUp
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.yangpj), out txPUp);
                return txPUp;
            }
            set
            {
                txPUp = value;
                MyOPCObject.WriteData(VariableEnum.yangpj, txPUp.ToString());
            }
        }

        Double txAUp = 0;
        /// <summary>
        /// A点仰角
        /// </summary>
        public Double AUp
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.yangaj), out txAUp);
                return txAUp;
            }
            set
            {
                txAUp = value;
                MyOPCObject.WriteData(VariableEnum.yangaj, txAUp.ToString());
            }
        }

        Double txBUp = 0;
        /// <summary>
        /// B点仰角
        /// </summary>
        public Double BUp
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.yangbj), out txBUp);
                return txBUp;
            }
            set
            {
                txBUp = value;
                MyOPCObject.WriteData(VariableEnum.yangbj, txBUp.ToString());
            }
        }

        Double txCUp = 0;
        /// <summary>
        /// C点仰角
        /// </summary>
        public Double CUp
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.yangcj), out txCUp);
                return txCUp;
            }
            set
            {
                txCUp = value;
                MyOPCObject.WriteData(VariableEnum.yangcj, txCUp.ToString());
            }
        }

        Double txDUp = 0;
        /// <summary>
        /// D点仰角
        /// </summary>
        public Double DUp
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.yangdj), out txDUp);
                return txDUp;
            }
            set
            {
                txDUp = value;
                MyOPCObject.WriteData(VariableEnum.yangdj, txDUp.ToString());
            }
        }

        double pInitX = 0;
        /// <summary>
        /// 云台的初始坐标X轴
        /// </summary>
        public double PInitX
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.xp0), out pInitX);
                return pInitX;
            }
            set
            {
                pInitX = value;
                MyOPCObject.WriteData(VariableEnum.xp0, pInitX.ToString());
            }
        }

        double pInitY = 0;
        /// <summary>
        /// 云台的初始坐标Y轴
        /// </summary>
        public double PInitY
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.yp0), out pInitY);
                return pInitY;
            }
            set
            {
                pInitY = value;
                MyOPCObject.WriteData(VariableEnum.yp0, pInitY.ToString());
            }
        }

        double pInitZ = 0;
        /// <summary>
        /// 云台的初始坐标Z轴
        /// </summary>
        public double PInitZ
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.zp0), out pInitZ);
                return pInitZ;
            }
            set
            {
                pInitZ = value;
                MyOPCObject.WriteData(VariableEnum.zp0, pInitZ.ToString());
            }
        }

    }

    /// <summary>
    /// 二次测量值设置(同步方式)
    /// </summary>
    public class AsyMotorTwoInitValue
    {
        bool twoResetSwitch = false;
        /// <summary>
        /// 第二次测量上位机回零开关
        /// </summary>
        public bool TwoResetSwitch
        {
            get
            {
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.pc_homing), out twoResetSwitch);
                return twoResetSwitch;
            }
            set
            {
                twoResetSwitch = value;
                //Int32 temp = Convert.ToInt32(value);
                MyOPCObject.WriteData(VariableEnum.pc_homing, twoResetSwitch.ToString());
            }
        }

        bool twoResetSwitchOK = false;
        /// <summary>
        /// 第二次测量回零完成状态
        /// </summary>
        public bool ResetSwitchOK
        {
            get
            {
                Boolean.TryParse(MyOPCObject.ReadData(VariableEnum.pc_homing_jiaodui), out twoResetSwitchOK);
                return twoResetSwitchOK;
            }
            set
            {
                twoResetSwitchOK = value;
                //Int32 temp = Convert.ToInt32(value);
                MyOPCObject.WriteData(VariableEnum.pc_homing_jiaodui, twoResetSwitchOK.ToString());
            }
        }

        double twoPXValue = 0.0;
        /// <summary>
        /// 第二次测量P点在原坐标系中的X坐标，为平台坐标赋值
        /// </summary>
        public double TwoPxValue
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.xp1), out twoPXValue);
                return twoPXValue;
            }
            set
            {
                twoPXValue = value;
                MyOPCObject.WriteData(VariableEnum.xp1, twoPXValue.ToString());
            }
        }

        double twoAUp = 0.0;
        /// <summary>
        /// 第二次测量A点仰角
        /// </summary>
        public double TwoAUp
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.yangaj2), out twoAUp);
                return twoAUp;
            }
            set
            {
                twoAUp = value;
                MyOPCObject.WriteData(VariableEnum.yangaj2, twoAUp.ToString());
            }
        }

        double twoBUp = 0.0;
        /// <summary>
        /// 第二次测量B点仰角
        /// </summary>
        public double TwoBUp
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.yangbj2), out twoBUp);
                return twoBUp;
            }
            set
            {
                twoBUp = value;
                MyOPCObject.WriteData(VariableEnum.yangbj2, twoBUp.ToString());
            }
        }

        double twoCUp = 0.0;
        /// <summary>
        /// 第二次测量C点仰角
        /// </summary>
        public double TwoCUp
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.yangcj2), out twoCUp);
                return twoCUp;
            }
            set
            {
                twoCUp = value;
                MyOPCObject.WriteData(VariableEnum.yangcj2, twoCUp.ToString());
            }
        }

        double twoDUp = 0.0;
        /// <summary>
        /// 第二次测量D点仰角
        /// </summary>
        public double TwoDUp
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.yangdj2), out twoDUp);
                return twoDUp;
            }
            set
            {
                twoDUp = value;
                MyOPCObject.WriteData(VariableEnum.yangdj2, twoDUp.ToString());
            }
        }

        double twoPUp = 0.0;
        /// <summary>
        /// 第二次测量P点仰角
        /// </summary>
        public double TwoPUp
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.yangpj2), out twoPUp);
                return twoPUp;
            }
            set
            {
                twoPUp = value;
                MyOPCObject.WriteData(VariableEnum.yangpj2, twoPUp.ToString());
            }
        }

        double twoASpace = 0;
        /// <summary>
        /// 第二次测量A点距离
        /// </summary>
        public double TwoASpace
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.longa2), out twoASpace);
                return twoASpace;
            }
            set
            {
                twoASpace = value;
                MyOPCObject.WriteData(VariableEnum.longa2, twoASpace.ToString());
            }
        }

        double twoBSpace = 0;
        /// <summary>
        /// 第二次测量B点距离
        /// </summary>
        public double TwoBSpace
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.longb2), out twoBSpace);
                return twoBSpace;
            }
            set
            {
                twoBSpace = value;
                MyOPCObject.WriteData(VariableEnum.longb2, twoBSpace.ToString());
            }
        }

        double twoCSpace = 0;
        /// <summary>
        /// 第二次测量C点距离
        /// </summary>
        public double TwoCSpace
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.longc2), out twoCSpace);
                return twoCSpace;
            }
            set
            {
                twoCSpace = value;
                MyOPCObject.WriteData(VariableEnum.longc2, twoCSpace.ToString());
            }
        }

        double twoDSpace = 0;
        /// <summary>
        /// 第二次测量C点距离
        /// </summary>
        public double TwoDSpace
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.longd2), out twoDSpace);
                return twoDSpace;
            }
            set
            {
                twoDSpace = value;
                MyOPCObject.WriteData(VariableEnum.longd2, twoDSpace.ToString());
            }
        }

        double twoPSpace = 0;
        /// <summary>
        /// 第二次测量P点距离
        /// </summary>
        public double TwoPSpace
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.longp2), out twoPSpace);
                return twoPSpace;
            }
            set
            {
                twoPSpace = value;
                MyOPCObject.WriteData(VariableEnum.longp2, twoPSpace.ToString());
            }
        }

        double twoPLevel = 0;
        /// <summary>
        /// 第二次测量P点水平角
        /// </summary>
        public double TwoPLevel
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.sppj2), out twoPLevel);
                return twoPLevel;
            }
            set
            {
                twoPLevel = value;
                MyOPCObject.WriteData(VariableEnum.sppj2, twoPLevel.ToString());
            }
        }

        double twoALevel = 0;
        /// <summary>
        /// 第二次测量A点水平角
        /// </summary>
        public double TwoALevel
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.spaj2), out twoALevel);
                return twoALevel;
            }
            set
            {
                twoALevel = value;
                MyOPCObject.WriteData(VariableEnum.spaj2, twoALevel.ToString());
            }
        }

        double twoBLevel = 0;
        /// <summary>
        /// 第二次测量B点水平角
        /// </summary>
        public double TwoBLevel
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.spbj2), out twoBLevel);
                return twoBLevel;
            }
            set
            {
                twoBLevel = value;
                MyOPCObject.WriteData(VariableEnum.spbj2, twoBLevel.ToString());
            }
        }

        double twoCLevel = 0;
        /// <summary>
        /// 第二次测量C点水平角
        /// </summary>
        public double TwoCLevel
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.spcj2), out twoCLevel);
                return twoCLevel;
            }
            set
            {
                twoCLevel = value;
                MyOPCObject.WriteData(VariableEnum.spcj2, twoCLevel.ToString());
            }
        }

        double twoDLevel = 0;
        /// <summary>
        /// 第二次测量D点水平角
        /// </summary>
        public double TwoDLevel
        {
            get
            {
                Double.TryParse(MyOPCObject.ReadData(VariableEnum.spdj2), out twoDLevel);
                return twoDLevel;
            }
            set
            {
                twoDLevel = value;
                MyOPCObject.WriteData(VariableEnum.spdj2, twoDLevel.ToString());
            }
        }

        

    }

    #endregion
}
