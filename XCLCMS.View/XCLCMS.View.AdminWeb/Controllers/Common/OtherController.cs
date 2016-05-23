using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.Common
{
    /// <summary>
    /// 其它开放的Controller
    /// </summary>
    public class OtherController : XCLCMS.Lib.Base.AdminBaseController
    {
        /// <summary>
        /// 跳转至文件管理页
        /// </summary>
        public ActionResult FileManagerFileList()
        {
            return Redirect(XCLCMS.Lib.SysWebSetting.Setting.SettingModel.FileManager_FileListURL);
        }

        /// <summary>
        /// 跳转至文件上传页
        /// </summary>
        /// <returns></returns>
        public ActionResult FileManagerUpload()
        {
            return Redirect(XCLCMS.Lib.SysWebSetting.Setting.SettingModel.FileManager_FileUploadURL);
        }
    }
}