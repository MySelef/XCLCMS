using System;
using System.Collections.Generic;
using System.Drawing;
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
            #region 基本信息
            HttpPostedFileBase file= Request.Files["FileInfo"];
            DateTime dtNow = DateTime.Now;
            Image img = null;
            string name=string.Format("{0:yyyyMMddHHmmss}_{1}",dtNow,XCLNetTools.StringHander.RandomHelper.GetRandomValue(0,Int32.MaxValue));
            string ext=XCLNetTools.FileHandler.ComFile.GetExtName(file.FileName);
            string newFileName =string.Format("{0}.{1}",name, ext);
            //附件主目录
            string directoryPath = string.Format("{0}/{1}/{2}/", XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Admin_UploaderFilePath.TrimEnd('/'),dtNow.Year,dtNow.Month);
            //附件临时目录
            string directoryTempPath = string.Format("{0}/{1}/{2}/", XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Admin_UploaderTempPath.TrimEnd('/'), dtNow.Year, dtNow.Month);
            //原图保存后的物理地址
            string savedServerPath = string.Empty;
            #endregion

            #region 生成缩略图
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
            if (null != settingModel)
            {
                if (settingModel.ImgCropHeight == 0 && settingModel.ImgCropWidth == 0)
                {
                    //如果不裁剪，则直接保存原图
                    XCLNetTools.FileHandler.FileDirectory.MakeDirectory(Server.MapPath(directoryPath));
                    savedServerPath = Server.MapPath(string.Format("{0}/{1}", directoryPath.TrimEnd('/'), newFileName));
                }
                else
                {
                    //如果裁剪了，则原图保存到临时文件夹中
                    XCLNetTools.FileHandler.FileDirectory.MakeDirectory(Server.MapPath(directoryTempPath));
                    savedServerPath = Server.MapPath(string.Format("{0}/{1}", directoryTempPath.TrimEnd('/'), newFileName));
                }
                file.SaveAs(savedServerPath);

                img = XCLNetTools.FileHandler.ImgLib.Crop(savedServerPath, settingModel.ImgCropWidth, settingModel.ImgCropHeight, settingModel.ImgX1, settingModel.ImgY1);
                img.Save(Server.MapPath(string.Format("{0}/{1}_{2}_{3}.{4}", directoryPath.TrimEnd('/'), name, settingModel.ImgCropWidth, settingModel.ImgCropHeight, ext)));
            }
            #endregion

            System.Threading.Thread.Sleep(2000);

            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            return Json(msgModel);
        }
    }
}
