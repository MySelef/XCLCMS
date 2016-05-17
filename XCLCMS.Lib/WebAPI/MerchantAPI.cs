using System.Collections.Generic;
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
        /// 查询商户信息实体
        /// </summary>
        public static APIResponseEntity<XCLCMS.Data.Model.Merchant> MerchantDetail(APIRequestEntity<long> request)
        {
            return Library.Request<long, XCLCMS.Data.Model.Merchant>(request, "Merchant/MerchantDetail");
        }

        /// <summary>
        /// 查询商户信息分页列表
        /// </summary>
        public static APIResponseEntity<XCLCMS.Data.WebAPIEntity.ResponseEntity.Merchant.MerchantPageListResponseEntity> MerchantPageList(APIRequestEntity<MerchantPageListConditionEntity> request)
        {
            return Library.Request<MerchantPageListConditionEntity, XCLCMS.Data.WebAPIEntity.ResponseEntity.Merchant.MerchantPageListResponseEntity>(request, "Merchant/MerchantPageList");
        }

        /// <summary>
        /// 新增商户信息
        /// </summary>
        public static APIResponseEntity<bool> MerchantAdd(APIRequestEntity<XCLCMS.Data.Model.Merchant> request)
        {
            return Library.Request<XCLCMS.Data.Model.Merchant, bool>(request, "Merchant/MerchantAdd", false);
        }

        /// <summary>
        /// 修改商户信息
        /// </summary>
        public static APIResponseEntity<bool> MerchantUpdate(APIRequestEntity<XCLCMS.Data.Model.Merchant> request)
        {
            return Library.Request<XCLCMS.Data.Model.Merchant, bool>(request, "Merchant/MerchantUpdate", false);
        }

        /// <summary>
        /// 删除商户信息
        /// </summary>
        public static APIResponseEntity<bool> MerchantDelete(APIRequestEntity<List<long>> request)
        {
            return Library.Request<List<long>, bool>(request, "Merchant/MerchantDelete", false);
        }

        /// <summary>
        /// 判断商户名是否存在
        /// </summary>
        public static APIResponseEntity<bool> IsExistMerchantName(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.Merchant.IsExistMerchantNameEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.Merchant.IsExistMerchantNameEntity, bool>(request, "Merchant/IsExistMerchantName");
        }
    }
}