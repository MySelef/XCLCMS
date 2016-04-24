using System.Web.Http;

namespace XCLCMS.Lib.Base.API
{
    /// <summary>
    /// web api 抽象基类
    /// </summary>
    public class AbstractBaseAPIController : ApiController
    {
        #region 当前登录用户相关

        private XCLCMS.Data.Model.UserInfo _currentUserModel = null;
        private XCLCMS.Data.Model.Custom.ContextModel _contextModel = null;

        /// <summary>
        /// 当前登录的用户实体
        /// </summary>
        public XCLCMS.Data.Model.UserInfo CurrentUserModel
        {
            get
            {
                if (this._currentUserModel == null)
                {
                    this._currentUserModel = XCLCMS.Lib.Login.LoginHelper.GetUserInfoFromLoginInfo();
                }
                return this._currentUserModel;
            }
        }

        /// <summary>
        /// 当前已登录用户的ID
        /// </summary>
        public long UserID
        {
            get
            {
                return null != this.CurrentUserModel ? this.CurrentUserModel.UserInfoID : 0;
            }
        }

        #endregion 当前登录用户相关

        #region 其它

        /// <summary>
        /// db上下文
        /// </summary>
        public XCLCMS.Data.Model.Custom.ContextModel ContextModel
        {
            get
            {
                if (null != this._contextModel)
                {
                    return this._contextModel;
                }
                return new Data.Model.Custom.ContextModel()
                {
                    UserInfo = this.CurrentUserModel
                };
            }
        }

        #endregion 其它
    }
}