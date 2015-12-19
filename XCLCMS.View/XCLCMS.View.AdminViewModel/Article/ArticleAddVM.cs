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

        /// <summary>
        /// 文章类型select的option
        /// </summary>
        public string ArticleTypeOptions { get; set; }

        /// <summary>
        /// 文章状态select的option
        /// </summary>
        public string ArticleStateOptions { get; set; }

        /// <summary>
        /// 文章类型类型select的option
        /// </summary>
        public string ArticleContentTypeOptions { get; set; }

        /// <summary>
        /// 文章链接打开方式select的option
        /// </summary>
        public string URLOpenTypeOptions { get; set; }

        /// <summary>
        /// 文章来源select的option
        /// </summary>
        public string FromInfoOptions { get; set; }

        /// <summary>
        /// 文章作者select的options
        /// </summary>
        public string AuthorNameOptions { get; set; }
    }
}