using System;
using System.Web.Mvc;

namespace XCLCMS.Lib.Common
{
    /// <summary>
    /// 公共操作
    /// </summary>
    public class Comm
    {
        #region 缓存相关

        /// <summary>
        /// 站点配置信息缓存
        /// </summary>
        public const string SettingCacheName = "SettingCacheName";

        /// <summary>
        /// 缓存清理
        /// </summary>
        public static void ClearCache()
        {
            XCLNetTools.Cache.CacheClass.Clear(XCLCMS.Lib.Common.Comm.SettingCacheName);
        }

        #endregion 缓存相关

        #region 配置相关

        /// <summary>
        /// 获取当前系统所处环境
        /// </summary>
        public static XCLNetTools.Enum.CommonEnum.SysEnvironmentEnum GetCurrentEnvironment()
        {
            string val = XCLNetTools.XML.ConfigClass.GetConfigString("SysEnvironment");
            if (string.IsNullOrWhiteSpace(val))
            {
                throw new ArgumentNullException("SysEnvironment", "appSettings中缺少环境节点配置信息！");
            }
            return (XCLNetTools.Enum.CommonEnum.SysEnvironmentEnum)Enum.Parse(typeof(XCLNetTools.Enum.CommonEnum.SysEnvironmentEnum), val.Trim().ToUpper());
        }

        /// <summary>
        /// 获取当前应用ID
        /// </summary>
        public static long AppID
        {
            get
            {
                var id = XCLNetTools.Common.DataTypeConvert.ToLong(XCLNetTools.XML.ConfigClass.GetConfigString("AppID"));
                if (id <= 0)
                {
                    throw new ArgumentNullException("AppID", "请在配置文件中配置有效的AppID！");
                }
                return id;
            }
        }

        /// <summary>
        /// 获取当前应用AppKey
        /// </summary>
        public static string AppKey
        {
            get
            {
                var str = XCLNetTools.XML.ConfigClass.GetConfigString("AppKey");
                if (string.IsNullOrWhiteSpace(str))
                {
                    throw new ArgumentNullException("AppKey", "请在配置文件中配置有效的AppKey！");
                }
                return str;
            }
        }

        /// <summary>
        /// 获取当前应用WebAPIJsUrl
        /// </summary>
        public static string WebAPIJsUrl
        {
            get
            {
                var str = XCLNetTools.XML.ConfigClass.GetConfigString("WebAPIJsUrl");
                if (string.IsNullOrWhiteSpace(str))
                {
                    throw new ArgumentNullException("WebAPIJsUrl", "请在配置文件中配置有效的WebAPIJsUrl！");
                }
                return str;
            }
        }

        /// <summary>
        /// 获取当前应用WebAPIServiceURL
        /// </summary>
        public static string WebAPIServiceURL
        {
            get
            {
                var str = XCLNetTools.XML.ConfigClass.GetConfigString("WebAPIServiceURL");
                if (string.IsNullOrWhiteSpace(str))
                {
                    throw new ArgumentNullException("WebAPIServiceURL", "请在配置文件中配置有效的WebAPIServiceURL！");
                }
                return str;
            }
        }

        #endregion 配置相关

        #region 其它

        /// <summary>
        /// web api 用户token名
        /// </summary>
        public const string WebAPIUserTokenHeaderName = "XCLCMSWebAPIHeader";

        /// <summary>
        /// 重写json
        /// </summary>
        public static JsonResult XCLJsonResult(object data, JsonRequestBehavior jsonRequestBehavior = JsonRequestBehavior.DenyGet)
        {
            return new XCLNetTools.MVC.JsonResultFormat() { Data = data, JsonRequestBehavior = jsonRequestBehavior };
        }

        /// <summary>
        /// 获取当前应用程序的商户实体
        /// </summary>
        public static XCLCMS.Data.Model.Merchant GetCurrentApplicationMerchant()
        {
            return XCLCMS.Lib.Common.Comm.GetCurrentApplicationMerchantAppInfo().Merchant;
        }

        /// <summary>
        /// 获取当前应用程序的商户应用实体
        /// </summary>
        public static XCLCMS.Data.Model.MerchantApp GetCurrentApplicationMerchantApp()
        {
            return XCLCMS.Lib.Common.Comm.GetCurrentApplicationMerchantAppInfo().MerchantApp;
        }

        /// <summary>
        /// 获取当前应用程序的商户应用信息
        /// </summary>
        public static XCLCMS.Data.Model.Custom.MerchantAppInfoModel GetCurrentApplicationMerchantAppInfo()
        {
            XCLCMS.Data.Model.Custom.MerchantAppInfoModel model = null;
            var request = XCLCMS.Lib.WebAPI.Library.CreateRequest<object>();
            request.Body = XCLCMS.Lib.Common.Comm.AppKey;
            var response = XCLCMS.Lib.WebAPI.MerchantAppAPI.DetailByAppKey(request);
            if (null != response && null != response.Body && null != response.Body.Merchant && null != response.Body.MerchantApp)
            {
                model = response.Body;
            }
            else
            {
                throw new Exception("商户应用信息获取失败，请配置有效的AppKey！");
            }
            return model;
        }

        #endregion 其它
    }
}