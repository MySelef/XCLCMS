using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XCLCMS.Lib.Filters
{
    /// <summary>
    /// 权限拦截
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class PermissionFilter : AuthorizeAttribute
    {
        /// <summary>
        /// 是否必须验证登录
        /// </summary>
        public bool IsMustLogin { get; set; }

        private XCLCMS.Data.Model.UserInfo UserInfo { get; set; }

        /// <summary>
        /// 登录权限验证
        /// </summary>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!this.IsMustLogin)
            {
                return true;
            }

            var req = httpContext.Request.RequestContext;
            string controllerName = Convert.ToString(req.RouteData.Values["controller"]);
            string actionName = Convert.ToString(req.RouteData.Values["action"]);

            bool flag = false;
            this.UserInfo = XCLCMS.Lib.Login.LoginHelper.GetUserInfoFromLoginInfo();
            if (null != this.UserInfo)
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 处理无权限的请求
        /// </summary>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            var response = filterContext.HttpContext.Response;
            response.Clear();
            response.Redirect(XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Admin_LoginURL);
            response.End();
        }

        /// <summary>
        /// 功能权限验证
        /// </summary>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (null == this.UserInfo)
            {
                return;
            }

            bool isPass = false;
            object[] attrs = filterContext.ActionDescriptor.GetCustomAttributes(typeof(XCLCMS.Lib.Filters.FunctionFilter), true);
            if (null != attrs && attrs.Length > 0)
            {
                var funList=attrs.Select(k => ((XCLCMS.Lib.Filters.FunctionFilter)(k)).Function).ToList();
                isPass = XCLCMS.Lib.Permission.PerHelper.HasAnyPermission(this.UserInfo.UserInfoID, funList);
                if (!isPass)
                {
                    throw new HttpException(403, "抱歉，您没有权限执行该操作，若有疑问，请联系管理员！");
                }
            }
        }
    }
}
