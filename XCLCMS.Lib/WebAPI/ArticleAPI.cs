using System.Collections.Generic;
using XCLCMS.Data.WebAPIEntity;
using XCLCMS.Data.WebAPIEntity.RequestEntity;

namespace XCLCMS.Lib.WebAPI
{
    /// <summary>
    /// 文章API
    /// </summary>
    public static class ArticleAPI
    {
        /// <summary>
        /// 查询文章信息实体
        /// </summary>
        public static APIResponseEntity<XCLCMS.Data.Model.View.v_Article> Detail(APIRequestEntity<long> request)
        {
            return Library.Request<long, XCLCMS.Data.Model.View.v_Article>(request, "Article/Detail");
        }

        /// <summary>
        /// 查询指定文章关联的其它文章信息
        /// </summary>
        public static APIResponseEntity<XCLCMS.Data.Model.Custom.ArticleRelationDetailModel> RelationDetail(APIRequestEntity<long> request)
        {
            return Library.Request<long, XCLCMS.Data.Model.Custom.ArticleRelationDetailModel>(request, "Article/RelationDetail");
        }

        /// <summary>
        /// 查询文章信息分页列表
        /// </summary>
        public static APIResponseEntity<XCLCMS.Data.WebAPIEntity.ResponseEntity.PageListResponseEntity<XCLCMS.Data.Model.View.v_Article>> PageList(APIRequestEntity<PageListConditionEntity> request)
        {
            return Library.Request<PageListConditionEntity, XCLCMS.Data.WebAPIEntity.ResponseEntity.PageListResponseEntity<XCLCMS.Data.Model.View.v_Article>>(request, "Article/PageList");
        }

        /// <summary>
        /// 查询文章信息分页列表(简单分页)
        /// </summary>
        public static APIResponseEntity<XCLCMS.Data.WebAPIEntity.ResponseEntity.PageListResponseEntity<XCLCMS.Data.Model.View.v_Article>> SimplePageList(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.Article.SimplePageListEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.Article.SimplePageListEntity, XCLCMS.Data.WebAPIEntity.ResponseEntity.PageListResponseEntity<XCLCMS.Data.Model.View.v_Article>>(request, "Article/SimplePageList");
        }

        /// <summary>
        /// 检查文章code是否已存在
        /// </summary>
        public static APIResponseEntity<bool> IsExistCode(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.Article.IsExistCodeEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.Article.IsExistCodeEntity, bool>(request, "Article/IsExistCode");
        }

        /// <summary>
        /// 新增文章信息
        /// </summary>
        public static APIResponseEntity<bool> Add(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.Article.AddOrUpdateEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.Article.AddOrUpdateEntity, bool>(request, "Article/Add", false);
        }

        /// <summary>
        /// 修改文章信息
        /// </summary>
        public static APIResponseEntity<bool> Update(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.Article.AddOrUpdateEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.Article.AddOrUpdateEntity, bool>(request, "Article/Update", false);
        }

        /// <summary>
        /// 删除文章信息
        /// </summary>
        public static APIResponseEntity<bool> Delete(APIRequestEntity<List<long>> request)
        {
            return Library.Request<List<long>, bool>(request, "Article/Delete", false);
        }
    }
}