using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.Home
{
    /// <summary>
    /// 默认controller
    /// </summary>
    public class DefaultController : BaseController
    {
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
