using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace XCLCMS.View.AdminWeb
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //静态资源配置信息
            XCLCMS.View.AdminWeb.Common.WebCommon.StaticResourceConfig = XCLNetTools.StringHander.Common.GetStaticResourceConfig(Server.MapPath("~/Config/StaticResourceConfig.config"));
            //XCLNetLogger配置信息
            XCLNetLogger.Config.LogConfig.SetConfig(Server.MapPath("~/Config/XCLNetLogger.config"));
        }
    }
}