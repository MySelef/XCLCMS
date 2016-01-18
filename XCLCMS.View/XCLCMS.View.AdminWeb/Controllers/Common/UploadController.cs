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
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            List<string> savedImgPathList = new List<string>();

            #region 基本信息

            HttpPostedFileBase file = Request.Files["FileInfo"];
            DateTime dtNow = DateTime.Now;
            string name = string.Format("{0:yyyyMMdd}_{1}", dtNow, System.Guid.NewGuid().ToString("N"));
            string ext = XCLNetTools.FileHandler.ComFile.GetExtName(file.FileName);
            string newFileName = string.Format("{0}.{1}", name, ext);
            //附件主目录
            string directoryPath = string.Format("{0}/{1}/{2}/", XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Admin_UploaderFilePath.TrimEnd('/'), dtNow.Year, dtNow.Month);
            //附件临时目录
            string directoryTempPath = string.Format("{0}/{1}/{2}/", XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Admin_UploaderTempPath.TrimEnd('/'), dtNow.Year, dtNow.Month);
            //原图保存后的物理地址
            string savedServerPath = string.Empty;
            //原图是否需要裁剪
            bool isNeedCrop = false;

            //生成目录
            XCLNetTools.FileHandler.FileDirectory.MakeDirectory(Server.MapPath(directoryPath));
            XCLNetTools.FileHandler.FileDirectory.MakeDirectory(Server.MapPath(directoryTempPath));

            #endregion 基本信息

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

            if (null == settingModel)
            {
                msgModel.IsSuccess = false;
                msgModel.Message = "参数设置无效！";
                return Json(msgModel);
            }

            if (null != settingModel.ThumbImgSettings && settingModel.ThumbImgSettings.Count > 0)
            {
                settingModel.ThumbImgSettings = settingModel.ThumbImgSettings.Where(k => k.Width > 0 && k.Height > 0).Distinct().ToList();
            }

            #region 裁剪主图

            isNeedCrop = settingModel.ImgCropHeight > 0 && settingModel.ImgCropWidth > 0;

            if (isNeedCrop)
            {
                //如果需要裁剪，则原图先保存到临时文件夹中
                savedServerPath = Server.MapPath(string.Format("{0}/{1}", directoryTempPath.TrimEnd('/'), newFileName));
                file.SaveAs(savedServerPath);

                using (var img = XCLNetTools.FileHandler.ImgLib.Crop(savedServerPath, settingModel.ImgCropWidth, settingModel.ImgCropHeight, settingModel.ImgX1, settingModel.ImgY1))
                {
                    if (null != img)
                    {
                        savedServerPath = Server.MapPath(string.Format("{0}/{1}_{2}_{3}.{4}", directoryPath.TrimEnd('/'), name, settingModel.ImgCropWidth, settingModel.ImgCropHeight, ext));
                        img.Save(savedServerPath);
                        savedImgPathList.Add(savedServerPath);
                    }
                }
            }
            else
            {
                //如果不裁剪，则直接保存原图
                savedServerPath = Server.MapPath(string.Format("{0}/{1}", directoryPath.TrimEnd('/'), newFileName));
                file.SaveAs(savedServerPath);

                savedImgPathList.Add(savedServerPath);
            }

            #endregion 裁剪主图

            #region 根据主图的参数设置再生成缩略图

            if (null != settingModel.ThumbImgSettings && settingModel.ThumbImgSettings.Count > 0)
            {
                foreach (var thumb in settingModel.ThumbImgSettings)
                {
                    using (var img = XCLNetTools.FileHandler.ImgLib.Crop(savedServerPath, thumb.Width, thumb.Height, 0, 0))
                    {
                        if (null != img)
                        {
                            string thumbPath = Server.MapPath(string.Format("{0}/{1}_{2}_{3}.{4}", directoryPath.TrimEnd('/'), name, thumb.Width, thumb.Height, ext));
                            img.Save(thumbPath);
                            savedImgPathList.Add(thumbPath);
                        }
                    }
                }
            }

            #endregion 根据主图的参数设置再生成缩略图

            #endregion 生成缩略图

            msgModel.CustomObject = savedImgPathList;
            msgModel.IsSuccess = true;

            return Json(msgModel);
        }
    }
}