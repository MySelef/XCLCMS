using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.View.AdminViewModel.SysLog
{
    public class SysLogListVM
    {
        public XCLNetSearch.Search Search { get; set; }

        public XCLCMS.View.AdminViewModel.UserControl.XCLPagerVM PagerModel { get; set; }

        public List<XCLCMS.Data.Model.SysLog> SysLogList { get; set; }

        public List<XCLNetTools.Enum.EnumFieldModel> ClearLogDateTypeList { get; set; }
    }
}
