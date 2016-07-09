using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.Model.Custom
{
    /// <summary>
    /// 文章的相关文章 model
    /// </summary>
    [Serializable]
    public class ArticleRelationDetailModel
    {
        /// <summary>
        /// 上一篇
        /// </summary>
        public XCLCMS.Data.Model.Article PreArticle { get; set; }

        /// <summary>
        /// 下一篇
        /// </summary>
        public XCLCMS.Data.Model.Article NextArticle { get; set; }

        /// <summary>
        /// 同类其它文章
        /// </summary>
        public List<XCLCMS.Data.Model.Article> SameTypeArticleList { get; set; }
    }
}
