using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace XCLCMS.FileManager.Controllers
{
    public class FileInfoController : BaseController
    {
        /// <summary>
        /// 磁盘文件列表页
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.FileManager_DiskFileView)]
        public ActionResult List()
        {
            Models.FileInfo.ListVM viewModel = this.GetFormViewModel();
            viewModel.CurrentDirectory = HttpUtility.UrlDecode(XCLNetTools.StringHander.FormHelper.GetString("dir"));
            if (string.IsNullOrEmpty(viewModel.CurrentDirectory))
            {
                viewModel.CurrentDirectory = XCLCMS.Lib.SysWebSetting.Setting.SettingModel.FileManager_UploadPath;
            }
            viewModel.CurrentDirectory = viewModel.CurrentDirectory.TrimEnd('/') + '/';

            viewModel.DirectoryNavigation = new List<XCLNetTools.Entity.TextValue>();
            var navArray = viewModel.CurrentDirectory.TrimStart(XCLCMS.Lib.SysWebSetting.Setting.SettingModel.FileManager_UploadPath.ToCharArray()).Trim('/').Split('/');
            StringBuilder link = new StringBuilder();
            for (int i = 0; i < navArray.Length; i++)
            {
                var s = navArray[i];
                link.Append(s + "/");
                viewModel.DirectoryNavigation.Add(new XCLNetTools.Entity.TextValue()
                {
                    Text = s,
                    Value = string.Format("{0}{1}", XCLCMS.Lib.SysWebSetting.Setting.SettingModel.FileManager_UploadPath, link.ToString())
                });
            }

            return View(viewModel);
        }

        private Models.FileInfo.ListVM GetFormViewModel()
        {
            Models.FileInfo.ListVM viewModel = new Models.FileInfo.ListVM();
            viewModel.CurrentDirectory = HttpUtility.UrlDecode(XCLNetTools.StringHander.FormHelper.GetString("dir"));
            return viewModel;
        }

        /// <summary>
        /// 查询磁盘文件列表
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.FileManager_DiskFileView)]
        public JsonResult GetFileList()
        {
            var viewModel = this.GetFormViewModel();

            XCLNetTools.Message.MessageModel msg = new XCLNetTools.Message.MessageModel();

            msg.CustomObject = XCLNetTools.FileHandler.FileDirectory.GetFileList(viewModel.CurrentDirectory, XCLCMS.Lib.SysWebSetting.Setting.SettingModel.FileManager_UploadPath, XCLCMS.Lib.SysWebSetting.Setting.SettingModel.FileManager_UploadPath.Replace("~/", XCLNetTools.StringHander.Common.RootUri));
            msg.IsSuccess = true;

            return new XCLNetTools.MVC.JsonResultFormat()
            {
                Data = msg,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        /// <summary>
        /// 磁盘文件删除
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.FileManager_DiskFileDel)]
        public override ActionResult DelSubmit(FormCollection fm)
        {
            return base.DelSubmit(fm);
        }
    }
}