using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.View.AdminViewModel.Article
{
    /// <summary>
    /// 文章列表页
    /// </summary>
    public class ArticleListVM
    {
        public XCLNetSearch.Search Search { get; set; }

        public XCLCMS.View.AdminViewModel.UserControl.XCLPagerVM PagerModel { get; set; }

        public List<XCLCMS.Data.Model.Article> ArticleList { get; set; }
    }
}
