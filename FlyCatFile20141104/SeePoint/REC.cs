using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mod;
using System.IO;

namespace SeePoint
{
    /// <summary>
    /// 录制
    /// </summary>
    public class REC
    {
        /// <summary>
        /// 时间片间隔
        /// </summary>
        int timespan = 0;
        /// <summary>
        /// 录制
        /// </summary>
        /// <param name="span">时间片间隔</param>
        public REC(int span)
        {
            timespan = span;
        }


        //List<RECSpace> ltp = new List<RECSpace>();
        Queue<RECSpace> queRecspace = new Queue<RECSpace>();
        /// <summary>
        /// 增加时间片
        /// </summary>
        /// <param name="space"></param>
        public void AddSpace(RECSpace space)
        {
            space.Index = queRecspace.Count;
            //ltp.Add(space);
            queRecspace.Enqueue(space);
        }

        /// <summary>
        /// 增加时间片
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void AddSpace(double x,double y,double z)
        {
            RECSpace recspace = new RECSpace();
            recspace.DollypointItem.X = x;
            recspace.DollypointItem.Y = y;
            recspace.DollypointItem.Z = z;
            AddSpace(recspace);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="filepath"></param>
        public void Save(string filepath)
        {
            string jsstr = LitJson.JsonMapper.ToJson(queRecspace.ToArray());
            File.WriteAllText(filepath, jsstr, Encoding.GetEncoding("gbk"));
            

        }
        /// <summary>
        /// 获取当前记录数量
        /// </summary>
        /// <returns></returns>
        public int GetSpaceCount()
        {
            return queRecspace.Count;
        }


        public RECSpace[] Load(string filename)
        {
            TextReader tr=new StreamReader(filename);
            RECSpace[]re = LitJson.JsonMapper.ToObject<RECSpace[]>(tr);

            return re;
        }
    }

    /// <summary>
    /// 时间片
    /// </summary>
    public class RECSpace
    {
        double index = 0;

        /// <summary>
        /// 顺序
        /// </summary>
        internal double Index
        {
            get { return index; }
            set { index = value; }
        }

        DollyPoint dollypointitem = new DollyPoint();

        public DollyPoint DollypointItem
        {
            get { return dollypointitem; }
            set { dollypointitem = value; }
        }
    }
}
