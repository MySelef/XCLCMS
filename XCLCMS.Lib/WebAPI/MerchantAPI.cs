using XCLCMS.Data.WebAPIEntity;
using XCLCMS.Data.WebAPIEntity.RequestEntity.Merchant;

namespace XCLCMS.Lib.WebAPI
{
    /// <summary>
    /// 商户信息API
    /// </summary>
    public class MerchantAPI
    {
        /// <summary>
        /// 查询商户信息分页列表
        /// </summary>
        public static APIResponseEntity<XCLCMS.Data.WebAPIEntity.ResponseEntity.Merchant.MerchantPageListResponseEntity> GetMerchantPageList(APIRequestEntity<MerchantPageListConditionEntity> request)
        {
            return Library.Request<MerchantPageListConditionEntity, XCLCMS.Data.WebAPIEntity.ResponseEntity.Merchant.MerchantPageListResponseEntity>(request, "Merchant/GetMerchantPageList");
        }
    }
}