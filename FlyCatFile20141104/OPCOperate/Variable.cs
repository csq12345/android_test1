using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPCOperate
{

    public class Variable
    {

        public event VarChangedEventHandler VarChanged;
        public delegate void VarChangedEventHandler(object obj);

        public void VarChangedEvent(object obj)
        {
            if (VarChanged != null)
            {
                VarChanged(obj);
            }
        }
    }
}
