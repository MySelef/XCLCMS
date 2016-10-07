using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.Ads
{
    [Serializable]
    [DataContract]
    public class IsExistCodeEntity
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public long AdsID { get; set; }
    }
}
