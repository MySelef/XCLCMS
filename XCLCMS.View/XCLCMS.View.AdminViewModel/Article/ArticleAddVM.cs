using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.View.AdminViewModel.Article
{
    /// <summary>
    /// 文章添加或修改页的viewmodel
    /// </summary>
    public class ArticleAddVM
    {
        /// <summary>
        /// 表单action
        /// </summary>
        public string FormAction { get; set; }

        public XCLCMS.Data.Model.Article Article { get; set; }
    }
}
