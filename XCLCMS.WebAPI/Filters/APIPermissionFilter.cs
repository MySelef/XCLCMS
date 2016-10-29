using System.Linq;
using System.Web.Http;
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
        /// 当前用户
        /// </summary>
        private XCLCMS.Data.Model.UserInfo UserInfo { get; set; }

        /// <summary>
        /// 权限验证
        /// </summary>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //验证登录信息
            if (!this.IsMustLogin)
            {
                return;
            }

            string token = null;
            var tokenHeaders = actionContext.Request.Headers.GetValues(XCLCMS.Lib.Common.Comm.WebAPIUserTokenHeaderName);
            if (null != tokenHeaders && tokenHeaders.Count() > 0)
            {
                token = tokenHeaders.First();
            }

            this.UserInfo = XCLCMS.WebAPI.Library.Common.GetUserInfoByUserToken(token);

            if (null == this.UserInfo)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.Forbidden);
            }
            base.OnAuthorization(actionContext);
        }

        /// <summary>
        /// 判断最终是否有权限访问
        /// </summary>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (null == this.UserInfo)
            {
                return false;
            }

            //验证功能权限
            var attrs = actionContext.ActionDescriptor.GetCustomAttributes<XCLCMS.Lib.Filters.FunctionFilter>();
            if (null != attrs && attrs.Count > 0)
            {
                var funList = attrs.Select(k => k.Function).ToList();
                if (!XCLCMS.Lib.Permission.PerHelper.HasAnyPermission(this.UserInfo.UserInfoID, funList))
                {
                    return false;
                }
            }
            return true;
        }
    }
}