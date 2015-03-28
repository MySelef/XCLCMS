using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Lib.Filters
{
    /// <summary>
    /// 功能Filter
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class FunctionFilter : Attribute
    {
        /// <summary>
        /// 当前功能标识组
        /// </summary>
        public XCLCMS.Lib.Permission.Function.FunctionEnum Function { get; set; }
    }
}
