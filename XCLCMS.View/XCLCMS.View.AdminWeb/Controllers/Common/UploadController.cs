using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XCLNetTools.Generic;

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
            HttpPostedFileBase file= Request.Files["FileInfo"];
            DateTime dtNow = DateTime.Now;
            string newFileName =string.Format("{0:yyyyMMddHHmmss}_{1}.{2}",dtNow,XCLNetTools.StringHander.RandomHelper.GetRandomValue(0,Int32.MaxValue), XCLNetTools.FileHandler.ComFile.GetExtName(file.FileName));
            string directoryPath = string.Format("{0}/{1}/{2}/", XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Admin_UploaderFilePath.TrimEnd('/'),dtNow.Year,dtNow.Month);
            string path = string.Format("{0}/{1}", directoryPath.TrimEnd('/'), newFileName);
            XCLNetTools.FileHandler.FileDirectory.MakeDirectory(Server.MapPath(directoryPath));
            file.SaveAs(Server.MapPath(path));

            string fileSetting = fm["FileSetting"] ?? "";
            XCLCMS.View.Model.Uploader.FileSetting settingModel = null;
            List<XCLCMS.View.Model.Uploader.FileSetting> settingList = null;
            if (!string.IsNullOrEmpty(fileSetting))
            {
                settingList = XCLNetTools.Serialize.JSON.DeSerialize<List<XCLCMS.View.Model.Uploader.FileSetting>>(fileSetting);
                if (settingList.IsNotNullOrEmpty())
                {
                    settingModel = settingList[0];
                }
            }

            System.Threading.Thread.Sleep(2000);

            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            return Json(msgModel);
        }
    }
}
