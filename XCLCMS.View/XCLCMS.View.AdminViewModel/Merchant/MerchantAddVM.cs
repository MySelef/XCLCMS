using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.View.AdminViewModel.Merchant
{
    public class MerchantAddVM
    {
        /// <summary>
        /// 表单action
        /// </summary>
        public string FormAction { get; set; }

        /// <summary>
        /// 商户model
        /// </summary>
        public XCLCMS.Data.Model.Merchant Merchant { get; set; }
    }
}
