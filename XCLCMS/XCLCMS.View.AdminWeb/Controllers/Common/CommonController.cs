using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace XCLCMS.View.AdminWeb.Controllers.Common
{
    public class CommonController : BaseController
    {
        /// <summary>
        /// 自动生成随机数
        /// </summary>
        /// <returns></returns>
        public JsonResult CreateAutoCode()
        {
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            msgModel.Message = XCLNetTools.StringHander.RandomHelper.GenerateStringId();
            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 清理缓存
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function=XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_ClearCache)]
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
        [XCLCMS.Lib.Filters.FunctionFilter(Function=XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_ClearRubbishData)]
        public JsonResult ClearRubbishData()
        {
            XCLCMS.Data.BLL.Common.Common.ClearRubbishData();
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            msgModel.IsSuccess = true;
            msgModel.Message = "垃圾数据清理成功！";
            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 图片显示
        /// </summary>
        public ActionResult ShowImg()
        {
            XCLCMS.View.AdminViewModel.Common.ShowImgVM viewModel = new AdminViewModel.Common.ShowImgVM();
            viewModel.ImgSrc=XCLNetTools.StringHander.FormHelper.GetString("ImgSrc");
            return View("~/Views/Common/ShowImg.cshtml", viewModel);
        }
    }
}
