using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Controllers;

namespace XCLCMS.WebAPI.Filters
{
    /// <summary>
    /// web api 权限验证
    /// </summary>
    public class APIPermissionFilter : System.Web.Http.AuthorizeAttribute
    {
        /// <summary>
        /// 是否必须验证登录
        /// </summary>
        public bool IsMustLogin { get; set; }

        /// <summary>
        /// 判断最终是否有权限访问
        /// </summary>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (!this.IsMustLogin)
            {
                return true;
            }

            var attrs = actionContext.ActionDescriptor.GetCustomAttributes<XCLCMS.Lib.Filters.FunctionFilter>();
            if (null == attrs || attrs.Count == 0)
            {
                return true;
            }

            string token = null;
            IEnumerable<string> tokenHeaders = null;
            if (actionContext.Request.Headers.TryGetValues(XCLCMS.Lib.Common.Comm.WebAPIUserTokenHeaderName, out tokenHeaders))
            {
                if (null != tokenHeaders && tokenHeaders.Count() > 0)
                {
                    token = tokenHeaders.First();
                }
            }
            var userInfo = XCLCMS.WebAPI.Library.Common.GetUserInfoByUserToken(token);

            if (null == userInfo)
            {
                return false;
            }

            var funList = attrs.Select(k => k.Function).ToList();
            return XCLCMS.Lib.Permission.PerHelper.HasAnyPermission(userInfo.UserInfoID, funList);
        }
    }
}