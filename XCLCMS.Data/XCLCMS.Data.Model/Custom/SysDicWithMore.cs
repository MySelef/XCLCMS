using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.Model.Custom
{
    /// <summary>
    /// 字典库扩展model
    /// </summary>
    public class SysDicWithMore
    {
        /// <summary>
        /// 字典model
        /// </summary>
        public XCLCMS.Data.Model.SysDic SysDic { get; set; }

        /// <summary>
        /// 角色功能list
        /// </summary>
        public List<long> RoleFunctionList { get; set; }

        /// <summary>
        /// 状态位
        /// </summary>
        public int WithMoreState { get; set; }
    }
}
