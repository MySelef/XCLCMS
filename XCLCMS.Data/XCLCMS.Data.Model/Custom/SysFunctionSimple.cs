using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.Model.Custom
{
    /// <summary>
    /// 功能模块简版实体
    /// </summary>
    public class SysFunctionSimple
    {
        /// <summary>
        /// 功能ID
        /// </summary>
        public long SysFunctionID
        {
            get;
            set;
        }
        /// <summary>
        /// 父ID
        /// </summary>
        public long ParentID
        {
            get;
            set;
        }
        /// <summary>
        /// 功能名
        /// </summary>
        public string FunctionName
        {
            get;
            set;
        }
    }
}
