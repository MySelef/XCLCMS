namespace XCLCMS.Lib.Base
{
    /// <summary>
    /// 基类接口
    /// </summary>
    public interface IBaseController
    {
        /// <summary>
        /// 当前所登录的用户model
        /// </summary>
        XCLCMS.Data.Model.UserInfo CurrentUserModel { get; }
    }
}