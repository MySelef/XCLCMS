using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.Login
{
    /// <summary>
    /// 登录controller
    /// </summary>
    public class LoginController : Controller
    {
        /// <summary>
        /// 验证码所在session名
        /// </summary>
        private static readonly string ValidCodeSessionName = "ValidCodeSession";
        /// <summary>
        /// 登录
        /// </summary>
        public ActionResult Logon()
        {
            if (XCLCMS.Lib.Login.LoginHelper.IsLogOn)
            {
                return RedirectToAction("Index", "Default");
            }
            return View("~/Views/Login/Logon.cshtml");
        }

        /// <summary>
        /// 退出
        /// </summary>
        public ActionResult LogOut()
        {
            XCLCMS.Lib.Login.LoginHelper.SetLogInfo(Lib.Login.LoginHelper.LoginType.OFF, null);
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            msgModel.IsSuccess = true;
            msgModel.Message = "退出成功！";
            return Json(msgModel,JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        public void GenerateValidCode()
        {
            string code = XCLNetTools.FileHandler.VerificationCode.GenerateCheckCode();
            Session[ValidCodeSessionName] = code;
            XCLNetTools.FileHandler.VerificationCode.CreateCheckCodeImage(code);
        }

        [HttpPost]
        public ActionResult LogonSubmit(FormCollection form)
        {
            string userName = (form["txtUserName"] ?? "").Trim();
            string pwd = form["txtPwd"] ?? "";
            string code = (form["txtValidCode"] ?? "").Trim();

            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            if (!string.Equals(Convert.ToString(Session[ValidCodeSessionName]), code, StringComparison.OrdinalIgnoreCase))
            {
                msgModel.Message = "验证码输入不正确！";
                return Json(msgModel);
            }

            XCLCMS.Data.BLL.UserInfo userBLL = new Data.BLL.UserInfo();
            XCLCMS.Data.Model.UserInfo userModel = userBLL.GetModel(userName,XCLCMS.Lib.Encrypt.EncryptHelper.EncryptStringMD5(pwd));
            if (null == userModel)
            {
                msgModel.Message = string.Format("用户名或密码不正确！",userName);
            }
            else if (!string.Equals(userModel.UserState, XCLCMS.Data.CommonHelper.EnumType.UserStateEnum.N.ToString()))
            {
                msgModel.Message = string.Format("用户名{0}已被禁用！", userName);
            }
            else
            {
                XCLCMS.Lib.Login.LoginHelper.SetLogInfo(XCLCMS.Lib.Login.LoginHelper.LoginType.ON, userModel);
                msgModel.IsSuccess = true;
            }

            //写入日志
            XCLNetLogger.Log.WriteLog(new XCLNetLogger.Model.LogModel() { 
                LogType=XCLCMS.Data.CommonHelper.EnumType.LogTypeEnum.LOGIN.ToString(),
                LogLevel=XCLNetLogger.Config.LogConfig.LogLevel.INFO,
                Title = string.Format("用户{0}，尝试登录系统{1}", userName, msgModel.IsSuccess ? "成功" : "失败")
            });

            return Json(msgModel);
        }

    }
}
