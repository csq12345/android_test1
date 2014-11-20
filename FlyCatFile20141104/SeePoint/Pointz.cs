using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeePoint
{
    /// <summary>
    /// 三维点
    /// </summary>
    public class Pointz
    {
        double x = 0;
        /// <summary>
        /// X坐标
        /// </summary>
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        double y = 0;
        /// <summary>
        /// Y坐标
        /// </summary>
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        double z = 0;
        /// <summary>
        /// Z坐标
        /// </summary>
        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        public Pointz()
        {

        }

        public Pointz(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

      
    }

    /// <summary>
    /// 双精度大小
    /// </summary>
    public struct SizeD
    {
        public SizeD(double width,double height)
        {
            this.width = width;
            this.height = height;
        }

        double width ;

        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        double height;

        public double Height
        {
            get { return height; }
            set { height = value; }
        }
    }

}
