using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.WebAPIEntity.ResponseEntity.Merchant
{
    [Serializable]
    public class MerchantPageListResponseEntity
    {
        public List<XCLCMS.Data.Model.View.v_Merchant> MerchantList { get; set; }

        public XCLNetTools.Entity.PagerInfo PagerInfo { get; set; }
    }
}
