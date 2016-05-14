using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.Merchant
{
    [Serializable]
    [DataContract]
    public class MerchantPageListConditionEntity
    {
        [DataMember]
        public XCLNetTools.Entity.PagerInfo PageInfo { get; set; }

        [DataMember]
        public string Where { get; set; }
    }
}
