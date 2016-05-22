using System;
using System.Collections.Generic;

namespace XCLCMS.Data.WebAPIEntity.ResponseEntity
{
    [Serializable]
    public class PageListResponseEntity<TResult>
    {
        public List<TResult> ResultList { get; set; }

        public XCLNetTools.Entity.PagerInfo PagerInfo { get; set; }
    }
}