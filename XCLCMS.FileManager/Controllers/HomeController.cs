using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XCLCMS.FileManager.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetFileList()
        {
            XCLNetTools.Message.MessageModel msg = new XCLNetTools.Message.MessageModel();

            string[] files=XCLNetTools.FileHandler.ComFile.GetFolderFiles("~/");


            string[] directories= System.IO.Directory.EnumerateDirectories(Server.MapPath("~/")).ToArray();


            msg.CustomObject = files.Concat(directories);

            return Json(msg, JsonRequestBehavior.AllowGet);
        }
    }
}