﻿using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

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

        private XCLCMS.Data.BLL.UserInfo userInfoBLL = new Data.BLL.UserInfo();
        private XCLCMS.Data.Model.UserInfo _currentUserModel = null;
        private XCLCMS.Data.Model.Custom.ContextModel _contextModel = null;

        /// <summary>
        /// 当前登录的用户实体
        /// </summary>
        public XCLCMS.Data.Model.UserInfo CurrentUserModel
        {
            get
            {
                if (null != this._currentUserModel)
                {
                    return this._currentUserModel;
                }

                //从请求头中获取用户登录信息
                var bodyModel = XCLCMS.WebAPI.Library.Common.GetInfoFromActionContext(base.ActionContext);
                if (null == bodyModel)
                {
                    return this._currentUserModel;
                }

                if (string.IsNullOrWhiteSpace(bodyModel.UserToken))
                {
                    //如果当前是匿名用户，则使用内置用户作为当前接口的登录用户
                    this._currentUserModel = this.userInfoBLL.GetModel(XCLCMS.Data.CommonHelper.SystemDataConst.XInnerUserName);
                }
                else
                {
                    //从token中获取用户信息
                    this._currentUserModel = XCLCMS.WebAPI.Library.Common.GetUserInfoByUserToken(bodyModel.UserToken);
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

        public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            return base.ExecuteAsync(controllerContext, cancellationToken);
        }
    }
}