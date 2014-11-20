using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mod
{
   public class Point2d
    {



        int x = 0;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        int y = 0;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        double ratio = 0;

        public double Ratio
        {
            get { return ratio; }
            set { ratio = value; }
        }


        int baseX = 0;

        public int BaseX
        {
            get { return baseX; }
            set { baseX = value; }
        }

        int baseY = 0;

        public int BaseY
        {
            get { return baseY; }
            set { baseY = value; }
        }

        public Point2d(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
