using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPCOperate;

namespace OPCOperate
{
    public class ConfigData
    {
        #region MyRegion1


        //水平角
        public string amiv_ALevel = "";
        public string amiv_BLevel = "";
        public string amiv_CLevel = "";
        public string amiv_DLevel = "";

        public string amiv_PLevel = "";

        //垂直角
        public string amiv_AUp = "";
        public string amiv_BUp = "";

        public string amiv_CUp = "";
        public string amiv_DUp = "";
        public string amiv_PUp = "";


        //距离
        public string amiv_ASpace = "";
        public string amiv_BSpace = "";
        public string amiv_CSpace = "";
        public string amiv_DSpace = "";

        public string amiv_PSpace = "";

        //全站仪高度
        public string amco_ConfigAllHeight = "";
        #endregion

        #region MyRegion2
        /*选中各边距离不相等时*/
        public string amiv_ConfineHJJZ = "";
        public string amiv_ConfineZ = "";

        public bool checkBoxpc_p_ab = false;
        public string amiv_PSpaceAB = "";
        public bool checkBoxpc_p_bc = false;
        public string amiv_PSpaceBC = "";
        public bool checkBoxpc_p_cd = false;
        public string amiv_PSpaceCD = "";
        public bool checkBoxpc_p_da = false;
        public string amiv_PSpaceAD = "";

        /*选中各边距离相等时*/
        public bool checkBoxAll = false;
        public string pc_all = "";
       
        #endregion


        #region MyRegion3

        #endregion

    }
}
