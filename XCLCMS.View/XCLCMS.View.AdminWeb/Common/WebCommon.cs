using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.ComponentModel;

namespace XCLCMS.View.AdminWeb.Common
{
    /// <summary>
    /// 站点公共信息
    /// </summary>
    public class WebCommon
    {
        #region 静态资源相关
        private static XCLNetTools.Entity.StaticResourceConfig _staticResourceConfig = null;
        /// <summary>
        /// 静态资源
        /// </summary>
        public static XCLNetTools.Entity.StaticResourceConfig StaticResourceConfig
        {
            get 
            {
                var newStaticResourceConfig = _staticResourceConfig.DeepClone();
                if (null != newStaticResourceConfig.StaticResourceList && newStaticResourceConfig.StaticResourceList.Count > 0)
                {
                    newStaticResourceConfig.StaticResourceList.ForEach(k =>
                    {
                        k.Version = XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Admin_ResourceVersion;
                        k.Src=k.Src.Replace("{ResourcesRootURL}", XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Admin_ResourceRootURL);
                        k.Attr=k.Attr.Replace("{ResourcesRootURL}", XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Admin_ResourceRootURL);
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