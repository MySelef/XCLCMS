using System.Web.Mvc;

namespace XCLCMS.FileManager.Controllers
{
    public class FileInfoController : Controller
    {
        // GET: FileInfo
        public ActionResult List()
        {
            Models.FileInfo.ListVM viewModel = new Models.FileInfo.ListVM();
            viewModel.RootFolder = Common.WebCommon.RootUploadFolder;
            return View(viewModel);
        }

        public JsonResult GetFileList()
        {
            XCLNetTools.Message.MessageModel msg = new XCLNetTools.Message.MessageModel();

            msg.CustomObject = XCLNetTools.FileHandler.FileDirectory.GetFileList(Server.MapPath(Common.WebCommon.RootUploadFolder));
            msg.IsSuccess = true;

            return Json(msg, JsonRequestBehavior.AllowGet);
        }
    }
}