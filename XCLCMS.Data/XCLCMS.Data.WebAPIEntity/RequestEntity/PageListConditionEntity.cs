using System;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity
{
    [Serializable]
    [DataContract]
    public class PageListConditionEntity
    {
        [DataMember]
        public XCLNetTools.Entity.PagerInfoSimple PagerInfoSimple { get; set; }

        [DataMember]
        public string Where { get; set; }
    }
}