namespace XCLCMS.View.AdminWeb.Models.Merchant
{
    public class MerchantAppAddVM
    {
        /// <summary>
        /// 表单action
        /// </summary>
        public string FormAction { get; set; }

        /// <summary>
        /// 商户应用model
        /// </summary>
        public XCLCMS.Data.Model.MerchantApp MerchantApp { get; set; }
    }
}