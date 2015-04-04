using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.BLL.Strategy.SysDic
{
    /// <summary>
    /// 字典库上下文
    /// </summary>
    public class SysDicContext:BaseContext
    {
        /// <summary>
        /// 字典库信息
        /// </summary>
        public XCLCMS.Data.Model.SysDic SysDic { get; set; }

        /// <summary>
        /// 角色所对应的功能id列表
        /// </summary>
        public List<long> FunctionIdList { get; set; }
    }
}
