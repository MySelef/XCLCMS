using System.Collections.Generic;

namespace XCLCMS.View.AdminWeb.Models.SysRole
{
    /// <summary>
    /// 添加或修改角色的viewmodel
    /// </summary>
    public class SysRoleAddVM
    {
        /// <summary>
        /// 表单action
        /// </summary>
        public string FormAction { get; set; }

        public long SysRoleID { get; set; }

        public long ParentID { get; set; }

        /// <summary>
        /// 当前节点路径
        /// </summary>
        public List<XCLCMS.Data.Model.Custom.SysRoleSimple> PathList { get; set; }

        /// <summary>
        /// 当前节点的Model
        /// </summary>
        public XCLCMS.Data.Model.SysRole SysRole { get; set; }

        /// <summary>
        /// 角色的功能ID
        /// </summary>
        public List<long> RoleFunctionIDList { get; set; }
    }
}