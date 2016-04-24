using XCLCMS.View.AdminWeb.Models.API;

namespace XCLCMS.View.AdminWeb.Controllers.API
{
    public class ArticleController : BaseAPIController
    {
        private XCLCMS.Data.BLL.Article articleBLL = new Data.BLL.Article();

        /// <summary>
        /// 根据ID查询文章实体
        /// </summary>
        public APIResponseEntity<XCLCMS.Data.Model.Article> GetArticle(long id)
        {
            APIResponseEntity<XCLCMS.Data.Model.Article> response = new APIResponseEntity<Data.Model.Article>();
            var model = articleBLL.GetModel(id);
            response.IsSuccess = null != model;
            response.Result = model;
            return response;
        }
    }
}