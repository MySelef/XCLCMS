using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.View.AdminViewModel.SysWebSetting
{
    /// <summary>
    /// 配置 列表
    /// </summary>
    public class SysWebSettingListVM
    {
        public XCLNetSearch.Search Search { get; set; }

        public XCLNetTools.Entity.PagerInfo PagerModel { get; set; }

        public List<XCLCMS.Data.Model.SysWebSetting> SysWebSettingList { get; set; }
    }
}
