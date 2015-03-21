using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.Model.Custom
{
    public class SysDicSimple
    {
        public long SysDicID
        {
            get;
            set;
        }
        public long ParentID
        {
            get;
            set;
        }
        public string DicName
        {
            get;
            set;
        }
    }
}
