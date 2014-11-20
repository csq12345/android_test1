using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CWTrack
{
    class TrackItem
    {
        int value = 0;
        /// <summary>
        /// 当前滑块值
        /// </summary>
        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        object picBox = null;
        /// <summary>
        /// 滑块对应的图片
        /// </summary>
        public object PicBox
        {
            get { return picBox; }
            set { picBox = value; }
        }

    }
}
