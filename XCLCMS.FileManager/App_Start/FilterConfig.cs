using System.Web.Mvc;

namespace XCLCMS.FileManager
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