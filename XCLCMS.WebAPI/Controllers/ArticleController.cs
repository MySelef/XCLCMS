using System;
using XCLCMS.Data.WebAPIEntity;

namespace XCLCMS.WebAPI.Controllers
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
            response.Body = model;
            return response;
        }

        /// <summary>
        /// 检查文章code是否已存在
        /// </summary>
        public APIResponseEntity<bool> IsExistCode(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.Article.IsExistCodeEntity> request)
        {
            #region 初始化

            request.Body.Code = (request.Body.Code ?? "").Trim();
            APIResponseEntity<bool> response = new APIResponseEntity<bool>()
            {
                IsSuccess = true,
                Message = "该唯一标识可以使用！",
                Body = true
            };
            XCLCMS.Data.Model.Article model = null;

            #endregion 初始化

            #region 数据校验

            if (string.IsNullOrEmpty(request.Body.Code))
            {
                response.Message = "请指定Code参数！";
                response.IsSuccess = false;
                response.Body = false;
                return response;
            }

            #endregion 数据校验

            #region 构建response

            if (request.Body.ArticleID > 0)
            {
                model = articleBLL.GetModel(request.Body.ArticleID);
                if (null != model && string.Equals(request.Body.Code, model.Code, StringComparison.OrdinalIgnoreCase))
                {
                    return response;
                }
            }

            if (articleBLL.IsExistCode(request.Body.Code))
            {
                response.IsSuccess = false;
                response.Body = false;
                response.Message = "该唯一标识已被占用！";
                return response;
            }
            return response;

            #endregion 构建response
        }
    }
}