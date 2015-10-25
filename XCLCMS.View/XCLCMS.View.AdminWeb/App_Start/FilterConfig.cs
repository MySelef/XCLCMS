using System.Web;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new XCLCMS.Lib.Filters.ExceptionFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
}