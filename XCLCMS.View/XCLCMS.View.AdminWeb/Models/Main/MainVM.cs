using System.Collections.Generic;

namespace XCLCMS.View.AdminWeb.Models.Main
{
    /// <summary>
    /// 主模板视图model
    /// </summary>
    public class MainVM
    {
        /// <summary>
        /// 主菜单
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysDic> MenuList { get; set; }
    }
}