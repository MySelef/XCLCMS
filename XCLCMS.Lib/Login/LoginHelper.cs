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

        #endregion 枚举

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
        /// 根据用户名和密码生成用户token
        /// </summary>
        public static string CreateUserToken(string userName, string pwd)
        {
            XCLCMS.Lib.Login.UserLoginInfoModel loginInfo = new XCLCMS.Lib.Login.UserLoginInfoModel();
            loginInfo.UserName = userName;
            loginInfo.Pwd = pwd;
            return XCLCMS.Lib.Encrypt.EncryptHelper.EncryptStringDES(loginInfo.ToString());
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
                    string loginStr = CreateUserToken(userInfo.UserName, userInfo.Pwd);
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
            return XCLCMS.Lib.Login.LoginHelper.GetUserInfoByUserToken(loginString);
        }

        /// <summary>
        /// 根据该model的字符串形式还原该model
        /// </summary>
        /// <param name="userToken">加密后的userToken信息</param>
        /// <returns>解密后的用户信息</returns>
        public static XCLCMS.Data.Model.UserInfo GetUserInfoByUserToken(string userToken)
        {
            if (string.IsNullOrEmpty(userToken))
            {
                return null;
            }
            //解密为：admin^21232F297A57A5A743894A0E4A801FC3
            userToken = XCLCMS.Lib.Encrypt.EncryptHelper.DecryptStringDES(userToken);
            string[] strSplit = userToken.Split('^');
            if (strSplit.Length != 2)
            {
                return null;
            }
            XCLCMS.Data.BLL.UserInfo bll = new Data.BLL.UserInfo();
            UserLoginInfoModel model = new UserLoginInfoModel();
            model.UserName = strSplit[0];
            model.Pwd = strSplit[1];
            return bll.GetModel(model.UserName, model.Pwd);
        }

        /// <summary>
        /// 获取内置用户的token
        /// </summary>
        public static string GetInnerUserToken()
        {
            XCLCMS.Data.BLL.UserInfo bll = new Data.BLL.UserInfo();
            var model = bll.GetModel(XCLCMS.Data.CommonHelper.SystemDataConst.XInnerUserName);
            if (null == model)
            {
                throw new System.Exception("内置用户不存在！");
            }
            return CreateUserToken(model.UserName, model.Pwd);
        }

        #endregion 登录相关信息设置
    }
}