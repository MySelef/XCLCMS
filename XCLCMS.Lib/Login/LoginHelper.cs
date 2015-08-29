using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace XCLCMS.Lib.Login
{
    /// <summary>
    /// 登录相关
    /// </summary>
    public class LoginHelper
    {
        #region 枚举
        /// <summary>
        /// 登录类型
        /// </summary>
        public enum LoginType
        {
            /// <summary>
            /// 登录
            /// </summary>
            ON,
            /// <summary>
            /// 退出
            /// </summary>
            OFF
        }
        #endregion

        #region 登录相关信息设置
        /// <summary>
        /// 是否已登录
        /// </summary>
        public static bool IsLogOn
        {
            get
            {
                return null != LoginHelper.GetUserInfoFromLoginInfo();
            }
        }

        /// <summary>
        /// 设置登录与退出的相关信息（session/cookie...）
        /// </summary>
        public static void SetLogInfo(LoginType type, XCLCMS.Data.Model.UserInfo userInfo)
        {
            var context = HttpContext.Current;
            switch (type)
            {
                //退出
                case LoginType.OFF:
                    XCLNetTools.Http.CookieHelper.DelCookies(XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Common_UserLoginFlagName);
                    context.Session.Remove(XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Common_UserLoginFlagName);
                    break;
                //登录
                case LoginType.ON:
                    XCLCMS.Lib.Login.UserLoginInfoModel loginInfo = new XCLCMS.Lib.Login.UserLoginInfoModel();
                    loginInfo.UserName = userInfo.UserName;
                    loginInfo.Pwd = userInfo.Pwd;
                    string loginStr = XCLCMS.Lib.Encrypt.EncryptHelper.EncryptStringDES(loginInfo.ToString());
                    XCLNetTools.Http.CookieHelper.SetCookies(XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Common_UserLoginFlagName, loginStr, 30);
                    context.Session[XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Common_UserLoginFlagName] = loginStr;
                    break;
            }
        }

        /// <summary>
        /// 从登录信息所保存的session或cookie获取当前用户model
        /// </summary>
        /// <returns></returns>
        public static XCLCMS.Data.Model.UserInfo GetUserInfoFromLoginInfo()
        {
            string loginString = HttpContext.Current.Session[XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Common_UserLoginFlagName] as string;
            if (string.IsNullOrEmpty(loginString))
            {
                loginString = XCLNetTools.Http.CookieHelper.GetCookies(XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Common_UserLoginFlagName);
            }
            if (string.IsNullOrEmpty(loginString))
            {
                return null;
            }
            loginString = XCLCMS.Lib.Encrypt.EncryptHelper.DecryptStringDES(loginString);
            var loginModel=XCLCMS.Lib.Login.LoginHelper.GetUserLoginInfo(loginString);
            XCLCMS.Data.BLL.UserInfo bll = new Data.BLL.UserInfo();
            return bll.GetModel(loginModel.UserName, loginModel.Pwd);
        }

        /// <summary>
        /// 根据该model的字符串形式还原该model
        /// </summary>
        /// <param name="str">如：admin^21232F297A57A5A743894A0E4A801FC3</param>
        /// <returns></returns>
        private static UserLoginInfoModel GetUserLoginInfo(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            string[] strSplit = str.Split('^');
            if (strSplit.Length != 2)
            {
                return null;
            }

            UserLoginInfoModel model = new UserLoginInfoModel();
            model.UserName = strSplit[0];
            model.Pwd = strSplit[1];
            return model;
        }
        #endregion
    }
}
