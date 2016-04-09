namespace XCLCMS.Data.BLL.Strategy.Article
{
    /// <summary>
    /// 文章上下文
    /// </summary>
    public class ArticleContext : BaseContext
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public XCLCMS.Data.Model.Article Article { get; set; }
    }
}