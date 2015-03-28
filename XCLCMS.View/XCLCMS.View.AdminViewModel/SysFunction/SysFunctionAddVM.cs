using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.View.AdminViewModel.SysFunction
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

        public XCLCMS.Data.Model.SysFunction SysFunction { get; set; }
    }
}
