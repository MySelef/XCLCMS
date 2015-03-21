using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.View.AdminViewModel.SysFunction
{
    /// <summary>
    /// 功能列表viewmodel
    /// </summary>
    public class SysFunctionListVM
    {
        public XCLNetSearch.Search Search { get; set; }

        public XCLCMS.View.AdminViewModel.UserControl.XCLPagerVM PagerModel { get; set; }

        public List<XCLCMS.Data.Model.View.v_SysFunction> SysFunctionList { get; set; }
    }
}
