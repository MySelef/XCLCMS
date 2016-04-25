using XCLCMS.Data.WebAPIEntity;

namespace XCLCMS.Lib.WebAPI
{
    /// <summary>
    /// 文章API
    /// </summary>
    public class ArticleAPI
    {
        /// <summary>
        /// 是否存在Code
        /// </summary>
        public static APIResponseEntity<bool> IsExistCode(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.Article.IsExistCodeEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.Article.IsExistCodeEntity, bool>(request, "Article/IsExistCode");
        }
    }
}