using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XCLCMS.View.AdminWeb.Models.FriendLinks
{
    public class FriendLinksListVM
    {
        /// <summary>
        /// 查询控件
        /// </summary>
        public XCLNetSearch.Search Search { get; set; }

        /// <summary>
        /// 分页控件
        /// </summary>
        public XCLNetTools.Entity.PagerInfo PagerModel { get; set; }

        /// <summary>
        /// 友情链接信息列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_FriendLinks> FriendLinksList { get; set; }
    }
}