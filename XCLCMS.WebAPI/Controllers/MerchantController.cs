using System.Web.Http;
using XCLCMS.Data.WebAPIEntity;
using XCLCMS.Data.WebAPIEntity.RequestEntity.Merchant;

namespace XCLCMS.WebAPI.Controllers
{
    public class MerchantController : BaseAPIController
    {
        private XCLCMS.Data.BLL.View.v_Merchant vMerchantBLL = new Data.BLL.View.v_Merchant();

        /// <summary>
        /// 查询商户信息分页列表
        /// </summary>
        [HttpGet]
        public APIResponseEntity<XCLCMS.Data.WebAPIEntity.ResponseEntity.Merchant.MerchantPageListResponseEntity> GetMerchantPageList(string json)
        {
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<APIRequestEntity<MerchantPageListConditionEntity>>(System.Web.HttpUtility.UrlDecode(json));
            var response = new APIResponseEntity<XCLCMS.Data.WebAPIEntity.ResponseEntity.Merchant.MerchantPageListResponseEntity>();
            response.Result = new Data.WebAPIEntity.ResponseEntity.Merchant.MerchantPageListResponseEntity();
            response.Result.MerchantList = vMerchantBLL.GetPageList(request.Data.PageInfo, request.Data.Where, "", "[MerchantID]", "[MerchantID] desc");
            response.Result.PagerInfo = request.Data.PageInfo;
            response.IsSuccess = true;
            return response;
        }
    }
}