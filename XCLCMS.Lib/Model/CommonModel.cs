namespace XCLCMS.Lib.Model
{
    /// <summary>
    /// 全局公共model
    /// </summary>
    public class CommonModel
    {
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public XCLCMS.Data.Model.UserInfo CurrentUserModel { get; set; }

        /// <summary>
        /// 是否已登录
        /// </summary>
        public bool IsLogOn
        {
            get
            {
                return null != this.CurrentUserModel;
            }
        }
    }
}