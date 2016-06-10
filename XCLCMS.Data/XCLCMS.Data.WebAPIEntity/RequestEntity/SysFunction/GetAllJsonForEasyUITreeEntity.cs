using System;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.SysFunction
{
    [Serializable]
    [DataContract]
    public class GetAllJsonForEasyUITreeEntity
    {
        [DataMember]
        public long MerchantID { get; set; }
    }
}