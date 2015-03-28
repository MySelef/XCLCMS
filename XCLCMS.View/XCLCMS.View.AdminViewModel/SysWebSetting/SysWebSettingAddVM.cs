using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.View.AdminViewModel.SysWebSetting
{
    /// <summary>
    /// 配置添加或修改页 viewmodel
    /// </summary>
    public class SysWebSettingAddVM
    {
        /// <summary>
        /// 表单action
        /// </summary>
        public string FormAction { get; set; }

        public XCLCMS.Data.Model.SysWebSetting SysWebSetting { get; set; }
    }
}
