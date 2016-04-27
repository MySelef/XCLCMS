using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.Merchant
{
    public class MerchantAppController : BaseController
    {
        public ActionResult List()
        {
            return View("~/Views/Merchant/MerchantAppList.cshtml");
        }

        public ActionResult Add()
        {
            return View("~/Views/Merchant/MerchantAppAdd.cshtml");
        }
    }
}