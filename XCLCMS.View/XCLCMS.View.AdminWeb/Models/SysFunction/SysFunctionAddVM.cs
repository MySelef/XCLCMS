using System.Collections.Generic;

namespace XCLCMS.View.AdminWeb.Models.SysFunction
{
    /// <summary>
    /// 功能添加或修改页 viewmodel
    /// </summary>
    public class SysFunctionAddVM
    {
        /// <summary>
        /// 表单action
        /// </summary>
        public string FormAction { get; set; }

        public long SysFunctionID { get; set; }

        public long ParentID { get; set; }

        public XCLCMS.Data.Model.SysFunction SysFunction { get; set; }

        /// <summary>
        /// 当前节点路径
        /// </summary>
        public List<XCLCMS.Data.Model.Custom.SysFunctionSimple> PathList { get; set; }
    }
}