using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.Common
{
    /// <summary>
    /// 开放的Controller
    /// </summary>
    public class OtherController : Controller
    {
        /// <summary>
        /// 跳转到错误页
        /// </summary>
        public ActionResult Error()
        {
            var msgModel = System.Web.HttpContext.Current.Session["XCLErrorSessionName"] as XCLNetTools.Message.MessageModel;
            if (null == msgModel)
            {
                msgModel = new XCLNetTools.Message.MessageModel()
                {
                    Message = "未知错误！"
                };
            }
            if (string.IsNullOrEmpty(msgModel.MessageMore))
            {
                msgModel.MessageMore = "无";
            }
            if (string.IsNullOrEmpty(msgModel.FromUrl))
            {
                msgModel.FromUrl = string.Format("{0}", XCLCMS.View.AdminWeb.Common.WebCommon.RootURL);
            }
            return View("~/Views/Common/Error.cshtml", msgModel);
        }
    }
}
