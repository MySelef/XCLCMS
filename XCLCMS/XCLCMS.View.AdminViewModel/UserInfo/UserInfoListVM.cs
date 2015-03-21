using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.View.AdminViewModel.UserInfo
{
    public class UserInfoListVM
    {
        public XCLNetSearch.Search Search { get; set; }

        public XCLCMS.View.AdminViewModel.UserControl.XCLPagerVM PagerModel { get; set; }

        public List<XCLCMS.Data.Model.UserInfo> UserInfoList { get; set; }

    }
}
