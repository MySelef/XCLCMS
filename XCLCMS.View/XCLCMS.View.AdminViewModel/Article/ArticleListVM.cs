using System.Collections.Generic;

namespace XCLCMS.View.AdminViewModel.Article
{
    /// <summary>
    /// 文章列表页
    /// </summary>
    public class ArticleListVM
    {
        public XCLNetSearch.Search Search { get; set; }

        public XCLNetTools.Entity.PagerInfo PagerModel { get; set; }

        public List<XCLCMS.Data.Model.Article> ArticleList { get; set; }
    }
}