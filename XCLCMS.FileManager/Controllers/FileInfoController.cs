using System.Web.Mvc;
using System.Collections.Generic;
using System.Text;

namespace XCLCMS.FileManager.Controllers
{
    public class FileInfoController : Controller
    {
        // GET: FileInfo
        public ActionResult List()
        {
            Models.FileInfo.ListVM viewModel = this.GetFormViewModel();
            viewModel.CurrentDirectory = XCLNetTools.StringHander.FormHelper.GetString("dir");
            if (string.IsNullOrEmpty(viewModel.CurrentDirectory))
            {
                viewModel.CurrentDirectory = Common.WebCommon.RootUploadFolder;
            }
            viewModel.CurrentDirectory = viewModel.CurrentDirectory.TrimEnd('/') + '/';


            viewModel.DirectoryNavigation = new List<XCLNetTools.Entity.TextValue>();
            var navArray=viewModel.CurrentDirectory.TrimStart(Common.WebCommon.RootUploadFolder.ToCharArray()).Trim('/').Split('/');
            StringBuilder link = new StringBuilder();
            for (int i = 0; i < navArray.Length; i++)
            {
                var s = navArray[i];
                link.Append(s+"/");
                viewModel.DirectoryNavigation.Add(new XCLNetTools.Entity.TextValue() {
                    Text=s,
                    Value= string.Format("{0}{1}", Common.WebCommon.RootUploadFolder,link.ToString())
                });
            }

            return View(viewModel);
        }

        private Models.FileInfo.ListVM GetFormViewModel()
        {
            Models.FileInfo.ListVM viewModel = new Models.FileInfo.ListVM();
            viewModel.CurrentDirectory= XCLNetTools.StringHander.FormHelper.GetString("dir");
            return viewModel;
        }

        public JsonResult GetFileList()
        {
            var viewModel = this.GetFormViewModel();

            XCLNetTools.Message.MessageModel msg = new XCLNetTools.Message.MessageModel();

            msg.CustomObject = XCLNetTools.FileHandler.FileDirectory.GetFileList(viewModel.CurrentDirectory, Common.WebCommon.RootUploadFolder);
            msg.IsSuccess = true;

            return new XCLNetTools.MVC.JsonResultFormat()
            {
                Data = msg,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}