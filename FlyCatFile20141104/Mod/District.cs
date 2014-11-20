using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Mod
{
    public class District
    {
        /// <summary>
        /// 一个区域包含的点
        /// </summary>
        List<Point2d> districtPoint = new List<Point2d>();
        bool endEdit = false;
        /// <summary>
        /// 是否完成编辑
        /// </summary>
        public bool EndEdit
        {
            get { return endEdit; }
            set { endEdit = value; }
        }

        public void Add(Point2d p)
        {
            districtPoint.Add(p);
        }

        public Point2d GetPoint(int index)
        {
            return districtPoint[index];
        }

        public Point2d[] GetPoints()
        {
            return districtPoint.ToArray();
        }

        public bool Remove(Point2d p)
        {
            return districtPoint.Remove(p);
        }

        public void RemoveAt(int index)
        {
            districtPoint.RemoveAt(index);
        }

        public int Count
        {
            get{
                return districtPoint.Count;
            }
        }
    }
}
