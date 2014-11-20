using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mod
{
    /// <summary>
    /// 空间的四个滑轮点
    /// </summary>
    public class PlacePoint
    {
        Pulley pulley1;
        /// <summary>
        /// 滑轮1
        /// </summary>
        public Pulley Pulley1
        {
            get { return pulley1; }
            set { pulley1 = value; }
        }
        Pulley pulley2;
        /// <summary>
        /// 滑轮2
        /// </summary>
        public Pulley Pulley2
        {
            get { return pulley2; }
            set { pulley2 = value; }
        }
        Pulley pulley3;
        /// <summary>
        /// 滑轮3
        /// </summary>
        public Pulley Pulley3
        {
            get { return pulley3; }
            set { pulley3 = value; }
        }
        Pulley pulley4;
        /// <summary>
        /// 滑轮4
        /// </summary>
        public Pulley Pulley4
        {
            get { return pulley4; }
            set { pulley4 = value; }
        }

        DollyPoint dollyPoint1;

        /// <summary>
        /// 云台
        /// </summary>
        public DollyPoint DollyPoint1
        {
            get { return dollyPoint1; }
            set { dollyPoint1 = value; }
        }

    }

    /// <summary>
    /// 滑轮
    /// </summary>
   public class Pulley
    {
        double x = 0;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        double y = 0;

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        double z = 0;

        public double Z
        {
            get { return z; }
            set { z = value; }
        }
    }
}
