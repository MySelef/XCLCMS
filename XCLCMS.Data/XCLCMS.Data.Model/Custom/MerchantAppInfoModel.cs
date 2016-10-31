using System;

namespace XCLCMS.Data.Model.Custom
{
    /// <summary>
    /// 商户应用信息实体
    /// </summary>
    [Serializable]
    public class MerchantAppInfoModel
    {
        /// <summary>
        /// 商户应用信息
        /// </summary>
        public XCLCMS.Data.Model.MerchantApp MerchantApp { get; set; }

        /// <summary>
        /// 所在商户的基本信息
        /// </summary>
        public XCLCMS.Data.Model.Merchant Merchant { get; set; }
    }
}