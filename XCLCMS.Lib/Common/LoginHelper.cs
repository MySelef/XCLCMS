using System.Web;

namespace XCLCMS.Lib.Common
{
    /// <summary>
    /// 登录相关
    /// </summary>
    public class LoginHelper
    {
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
        /// 设置登录与退出的登录令牌信息（session/cookie...）
        /// </summary>
        public static void SetLogInfo(XCLNetTools.Enum.CommonEnum.LoginTypeEnum type, string userToken)
        {
            var context = HttpContext.Current;
            switch (type)
            {
                //退出
                case XCLNetTools.Enum.CommonEnum.LoginTypeEnum.OFF:
                    XCLNetTools.Http.CookieHelper.DelCookies(XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Common_UserLoginFlagName);
                    context.Session.Remove(XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Common_UserLoginFlagName);
                    break;
                //登录
                case XCLNetTools.Enum.CommonEnum.LoginTypeEnum.ON:
                    if (string.IsNullOrWhiteSpace(userToken))
                    {
                        throw new System.Exception("必须指定用户的登录令牌信息！");
                    }
                    XCLNetTools.Http.CookieHelper.SetCookies(XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Common_UserLoginFlagName, userToken, 30);
                    context.Session[XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Common_UserLoginFlagName] = userToken;
                    break;
            }
        }

        /// <summary>
        /// 根据session或cookie中的登录令牌来获取当前用户model
        /// </summary>
        public static XCLCMS.Data.Model.Custom.UserInfoDetailModel GetUserInfoFromLoginInfo()
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
            var request = XCLCMS.Lib.WebAPI.Library.CreateRequest<XCLCMS.Data.WebAPIEntity.RequestEntity.Open.LogonCheckEntity>(loginString);
            request.Body = new Data.WebAPIEntity.RequestEntity.Open.LogonCheckEntity();
            request.Body.UserToken = loginString;
            var response = XCLCMS.Lib.WebAPI.OpenAPI.LogonCheck(request);
            if (null != response && response.IsSuccess)
            {
                return response.Body;
            }
            return null;
        }

        /// <summary>
        /// 获取系统内置用户的登录令牌
        /// </summary>
        public static string GetInnerUserToken()
        {
            XCLCMS.Data.BLL.UserInfo bll = new Data.BLL.UserInfo();
            var model = bll.GetModel(XCLCMS.Data.CommonHelper.SystemDataConst.XInnerUserName);
            if (null == model)
            {
                throw new System.Exception("内置用户不存在！");
            }
            return string.Format("{0}^{1}", model.UserName, model.Pwd);
        }
    }
}