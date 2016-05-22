using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.MerchantApp
{
    [Serializable]
    [DataContract]
    public class IsExistMerchantAppNameEntity
    {
        [DataMember]
        public string MerchantAppName { get; set; }

        [DataMember]
        public long MerchantAppID { get; set; }
    }
}
