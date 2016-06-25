using System;
using System.Web.Http;
using XCLCMS.Data.WebAPIEntity;

namespace XCLCMS.WebAPI.Controllers
{
    public class ArticleController : BaseAPIController
    {
        private XCLCMS.Data.BLL.Article articleBLL = new Data.BLL.Article();
        private XCLCMS.Data.BLL.View.v_Article vArticleBLL = new XCLCMS.Data.BLL.View.v_Article();

        /// <summary>
        /// 查询文章信息实体
        /// </summary>
        [HttpGet]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantView)]
        public APIResponseEntity<XCLCMS.Data.Model.View.v_Article> Detail([FromUri] string json)
        {
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<APIRequestEntity<long>>(System.Web.HttpUtility.UrlDecode(json));
            var response = new APIResponseEntity<XCLCMS.Data.Model.View.v_Article>();
            response.Body = vArticleBLL.GetModel(request.Body);
            response.IsSuccess = true;

            //限制商户
            if (base.IsOnlyCurrentMerchant && null != response.Body && response.Body.FK_MerchantID != base.CurrentUserModel.FK_MerchantID)
            {
                response.Body = null;
                response.IsSuccess = false;
            }

            return response;
        }






    }
}