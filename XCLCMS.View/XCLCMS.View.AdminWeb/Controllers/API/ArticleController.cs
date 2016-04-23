using System.Web.Http;

namespace XCLCMS.View.AdminWeb.Controllers.API
{
    public class ArticleController : ApiController
    {
        private XCLCMS.Data.BLL.Article articleBLL = new Data.BLL.Article();

        /// <summary>
        /// 根据ID查询文章实体
        /// </summary>
        public XCLCMS.Data.Model.Article GetArticle(long id)
        {
            return articleBLL.GetModel(id);
        }
    }
}