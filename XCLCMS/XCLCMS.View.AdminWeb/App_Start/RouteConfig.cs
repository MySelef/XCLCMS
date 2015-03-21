using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace XCLCMS.View.AdminWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //简化登录首页界面的url
            routes.MapRoute(
                name: "LoginShortURL",
                url: "go",
                defaults: new { controller = "Login", action = "Logon" }
            );

            //默认，请放在最下面，避免优先匹配
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}