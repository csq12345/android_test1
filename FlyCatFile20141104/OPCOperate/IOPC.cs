using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPCOperate
{
    interface IOPC
    {
        /// <summary>
        /// 连接opc服务端
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        bool OPCConnection(string ip, string name);

        /// <summary>
        /// 读取指定的变量名的值
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        string OPCReadData(string variable);

        /// <summary>
        /// 写入指定变量名的值
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool OPCWriteData(string variable, string value);
    }
}
