using System.Linq;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.Common
{
    /// <summary>
    /// 公共controller
    /// </summary>
    public class CommonController : BaseController
    {
        /// <summary>
        /// 清理缓存
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_ClearCache)]
        public JsonResult ClearCache()
        {
            XCLCMS.Lib.Common.Comm.ClearCache();
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            msgModel.IsSuccess = true;
            msgModel.IsRefresh = true;
            msgModel.Message = "缓存清理成功！";
            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 垃圾数据清理
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_ClearRubbishData)]
        public JsonResult ClearRubbishData()
        {
            XCLCMS.Data.BLL.Common.Common.ClearRubbishData();
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            msgModel.IsSuccess = true;
            msgModel.Message = "垃圾数据清理成功！";
            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据文件id查询文件详情
        /// </summary>
        /// <returns></returns>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.FileManager_LogicFileView)]
        public JsonResult GetFileInfo()
        {
            var ids = (XCLNetTools.StringHander.FormHelper.GetString("FileID") ?? "").Split(',').ToList().ConvertAll(k => XCLNetTools.Common.DataTypeConvert.ToLong(k));
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            msgModel.CustomObject = new XCLCMS.Data.BLL.Attachment().GetList(ids);
            msgModel.IsSuccess = true;
            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }
    }
}