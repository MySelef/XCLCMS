using System.Web.Http;
using System.Web.Mvc;

namespace XCLCMS.WebAPI.Areas.HelpPage
{
    public class HelpPageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "HelpPage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "HelpPage_Default",
                url: "Help/{action}/{apiId}",
                defaults: new { controller = "Help", action = "Index", apiId = UrlParameter.Optional },
                namespaces: new[] { "XCLCMS.WebAPI.Areas.HelpPage.Controllers" }
            );

            HelpPageConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}