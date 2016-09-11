namespace XCLCMS.Data.Model.Custom
{
    public class Tags_IsExistCondition
    {
        public string TagName { get; set; }

        public long FK_MerchantID { get; set; }

        public long FK_MerchantAppID { get; set; }
    }
}