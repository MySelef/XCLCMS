using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.View.AdminViewModel.Merchant
{
    public class MerchantListVM
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
        /// 商户信息列表
        /// </summary>
        public List<XCLCMS.Data.Model.Merchant> MerchantList { get; set; }
    }
}
