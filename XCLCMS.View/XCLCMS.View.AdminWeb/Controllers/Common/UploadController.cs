using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.Common
{
    /// <summary>
    /// 文件上传controller
    /// </summary>
    public class UploadController : BaseController
    {
        /// <summary>
        /// 上传
        /// </summary>
        public ActionResult Index()
        {
            return View("~/Views/Common/Upload.cshtml");
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        [HttpPost]
        public JsonResult UploadSubmit(FormCollection fm)
        {
            var fileInfo = fm["FileInfo"];



            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();

            return Json(msgModel);
        }
    }
}
