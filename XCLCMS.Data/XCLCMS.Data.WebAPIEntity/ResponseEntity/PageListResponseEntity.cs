using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity.ResponseEntity
{
    [Serializable]
    [DataContract]
    public class PageListResponseEntity<TResult>
    {
        [DataMember]
        public List<TResult> ResultList { get; set; }

        [DataMember]
        public XCLNetTools.Entity.PagerInfo PagerInfo { get; set; }
    }
}