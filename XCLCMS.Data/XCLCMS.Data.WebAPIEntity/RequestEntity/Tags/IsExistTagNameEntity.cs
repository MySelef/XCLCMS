using System;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.Tags
{
    [Serializable]
    [DataContract]
    public class IsExistTagNameEntity
    {
        [DataMember]
        public string TagName { get; set; }

        [DataMember]
        public long TagsID { get; set; }

        [DataMember]
        public long MerchantID { get; set; }

        [DataMember]
        public long MerchantAppID { get; set; }
    }
}