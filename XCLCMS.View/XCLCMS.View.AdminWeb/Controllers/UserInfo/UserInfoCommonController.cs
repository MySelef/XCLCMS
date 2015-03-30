using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.UserInfo
{
    /// <summary>
    /// 用户公共controller
    /// </summary>
    public class UserInfoCommonController : BaseController
    {
        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        public ActionResult IsExistUserName()
        {
            string userName = XCLNetTools.StringHander.FormHelper.GetString("UserName").Trim();
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            bool isExist = new XCLCMS.Data.BLL.UserInfo().IsExistUserName(userName);
            if (isExist)
            {
                msgModel.IsSuccess = false;
                msgModel.Message = "该用户名已存在！";
            }
            else
            {
                msgModel.IsSuccess = true;
                msgModel.Message = "该用户名可以使用！";
            }
            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }
    }
}
