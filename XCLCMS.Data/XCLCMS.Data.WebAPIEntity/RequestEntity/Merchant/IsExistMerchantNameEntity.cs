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
    public class IsExistMerchantNameEntity
    {
        [DataMember]
        public string MerchantName { get; set; }

        [DataMember]
        public long MerchantID { get; set; }
    }
}
