using System.Linq;
using System.Web.Http;

namespace XCLCMS.WebAPI.Controllers
{
    /// <summary>
    /// web api基类
    /// </summary>
    [XCLCMS.WebAPI.Filters.APIPermissionFilter(IsMustLogin = true)]
    [XCLCMS.WebAPI.Filters.APIExceptionFilter()]
    public class BaseAPIController : ApiController
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
                    string token = null;
                    var tokenHeaders = base.ActionContext.Request.Headers.GetValues(XCLCMS.Lib.Common.Comm.WebAPIUserTokenHeaderName);
                    if (null != tokenHeaders && tokenHeaders.Count() > 0)
                    {
                        token = tokenHeaders.First();
                    }
                    this._currentUserModel = XCLCMS.WebAPI.Library.Common.GetUserInfoByUserToken(token);
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
                    UserInfoID = this.CurrentUserModel.UserInfoID,
                    UserName = this.CurrentUserModel.UserName
                };
            }
        }

        /// <summary>
        /// 当前用户是否只能访问自己的商户数据
        /// </summary>
        public bool IsOnlyCurrentMerchant
        {
            get
            {
                return Lib.Permission.PerHelper.IsOnlyCurrentMerchant(this.CurrentUserModel.UserInfoID);
            }
        }

        #endregion 其它
    }
}