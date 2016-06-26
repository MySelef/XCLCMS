using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.Article
{
    [Serializable]
    [DataContract]
    public class SimplePageListEntity
    {
        [DataMember]
        public XCLNetTools.Entity.PagerInfo PageInfo { get; set; }
        [DataMember]
        public XCLCMS.Data.Model.Custom.ArticleSearchCondition Condition { get; set; }
    }
}
