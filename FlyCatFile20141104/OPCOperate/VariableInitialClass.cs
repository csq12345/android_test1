using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPCOperate
{
    //因为这里的所有变量都是初始的时候必须设置的 所以变量只提供set操作 如果有需要get操作的话 另说

    /// <summary>
    /// 初始变量的集合的类
    /// </summary>
    public class VariableInitialClass
    {
        
        #region 空间坐标


        PlaceCoordinates placeCoordinates_ = new PlaceCoordinates();
        /// <summary>
        /// 设置空间坐标
        /// </summary>
        public PlaceCoordinates PlaceCoordinates_
        {
            get { return placeCoordinates_; }
            set { placeCoordinates_ = value; }
        }

        #endregion
    }

    


    /// <summary>
    /// 设置空间坐标
    /// </summary>
    public class PlaceCoordinates :Variable
    {
        #region 滑轮1
        float x1 = 0;

        public float X1
        {
            //get { return x1; }
            set { x1 = value;
            //MyOPCObject.WriteData(VariableEnum.xa, value.ToString());
            base.VarChangedEvent(this);
            }
        }
        float y1 = 0;

        public float Y1
        {
            //get { return y1; }
            set { y1 = value;
            base.VarChangedEvent(this);
            }
        }
        float z1 = 0;

        public float Z1
        {
            //get { return z1; }
            set { z1 = value;
            base.VarChangedEvent(this);
            }
        }
        #endregion

        #region 滑轮2
        float x2 = 0;

        public float X2
        {
            //get { return x2; }
            set { x2 = value;
            base.VarChangedEvent(this);
            }
        }
        float y2 = 0;

        public float Y2
        {
            //get { return y2; }
            set { y2 = value;
            base.VarChangedEvent(this);
            }
        }
        float z2 = 0;

        public float Z2
        {
            //get { return z2; }
            set { z2 = value;

            base.VarChangedEvent(this);
            }
        }
        #endregion

        #region 滑轮3
        float x3 = 0;

        public float X3
        {
            //get { return x3; }
            set { x3 = value; 
                base.VarChangedEvent(this); 
            }
        }

        float y3 = 0;

        public float Y3
        {
            //get { return y3; }
            set { y3 = value;
            base.VarChangedEvent(this);
            }
        }

        float z3 = 0;

        public float Z3
        {
            //get { return z3; }
            set { z3 = value;
            base.VarChangedEvent(this);
            }
        }

        #endregion

        #region 滑轮4
        float x4 = 0;

        public float X4
        {
            //get { return x4; }
            set { x4 = value;
            base.VarChangedEvent(this);
            }
        }

        float y4 = 0;

        public float Y4
        {
            //get { return y4; }
            set { y4 = value;
            base.VarChangedEvent(this);
            }
        }

        float z4 = 0;

        public float Z4
        {
            //get { return z4; }
            set { z4 = value;
            base.VarChangedEvent(this);
            }
        }

        #endregion
    }
}
