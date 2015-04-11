using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.BLL.Strategy.SysRole
{
    /// <summary>
    /// 角色上下文
    /// </summary>
    public class SysRoleContext : BaseContext
    {
        /// <summary>
        /// 角色信息
        /// </summary>
        public XCLCMS.Data.Model.SysRole SysRole { get; set; }

        /// <summary>
        /// 角色所对应的功能id列表
        /// </summary>
        public List<long> FunctionIdList { get; set; }
    }
}
