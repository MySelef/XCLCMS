using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.SysDic
{
    [Serializable]
    [DataContract]
    public class GetEasyUITreeByConditionEntity
    {
        [DataMember]
        public long MerchantID { get; set; }
    }
}
