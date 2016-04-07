using System.Collections.Generic;

namespace XCLCMS.View.AdminWeb.Models.SysLog
{
    public class SysLogListVM
    {
        public XCLNetSearch.Search Search { get; set; }

        public XCLNetTools.Entity.PagerInfo PagerModel { get; set; }

        public List<XCLCMS.Data.Model.SysLog> SysLogList { get; set; }

        public List<XCLNetTools.Entity.Enum.EnumFieldModel> ClearLogDateTypeList { get; set; }
    }
}