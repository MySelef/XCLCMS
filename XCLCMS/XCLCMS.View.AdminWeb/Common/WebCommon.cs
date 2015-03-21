using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.ComponentModel;

namespace XCLCMS.View.AdminWeb.Common
{
    public class WebCommon
    {
        #region 静态资源相关
        private static XCLNetTools.PublicClass.StaticResourceConfig _staticResourceConfig = null;
        /// <summary>
        /// 静态资源
        /// </summary>
        public static XCLNetTools.PublicClass.StaticResourceConfig StaticResourceConfig
        {
            get 
            {
                var newStaticResourceConfig = _staticResourceConfig.DeepClone();
                if (null != newStaticResourceConfig.StaticResourceList && newStaticResourceConfig.StaticResourceList.Count > 0)
                {
                    newStaticResourceConfig.StaticResourceList.ForEach(k =>
                    {
                        k.Version = XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Admin_ResourceVersion;
                        k.Src = string.Format("{0}/{1}", XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Admin_ResourceRootURL.Trim().TrimEnd('/'), k.Src.Trim().TrimStart('/'));
                    });
                }
                return newStaticResourceConfig;
            }
            set
            {
                _staticResourceConfig = value;
            }
        }
        #endregion

        #region 菜单导航
        /// <summary>
        /// 菜单导航id所在的url参数名
        /// </summary>
        public static readonly string MenuIDsParamName = "sysMID";
        /// <summary>
        /// 菜单导航id所在的url参数值
        /// </summary>
        public static string MenuIDsParamValue
        {
            get
            {
                return XCLNetTools.StringHander.FormHelper.GetString(MenuIDsParamName);
            }
        }
        /// <summary>
        /// url附加的信息
        /// </summary>
        public static string UrlAdditiveParams
        {
            get
            {
                return string.Format("{0}={1}", MenuIDsParamName, MenuIDsParamValue);
            }
        }
        /// <summary>
        /// form表单附加的hidden参数信息
        /// </summary>
        public static string FormAdditiveParams
        {
            get
            {
                StringBuilder str = new StringBuilder();
                str.AppendFormat(@"<input type=""hidden"" name=""{0}"" value=""{1}""/>", MenuIDsParamName, MenuIDsParamValue);
                return str.ToString();
            }
        }
        #endregion

        #region 路径相关
        /// <summary>
        /// 网站根路径
        /// </summary>
        public static string RootURL
        {
            get
            {
                return XCLNetTools.StringHander.Common.RootUri;
            }
        }

        /// <summary>
        /// 上一步的URL
        /// </summary>
        public static string RefferUrl
        {
            get
            {
                string url = null == HttpContext.Current.Request.UrlReferrer ? string.Empty : HttpContext.Current.Request.UrlReferrer.AbsoluteUri;
                if (string.IsNullOrEmpty(url))
                {
                    url = XCLCMS.View.AdminWeb.Common.WebCommon.RootURL;
                }
                return url;
            }
        }
        #endregion
    }
}