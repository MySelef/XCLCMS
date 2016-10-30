using System;
using System.Web.Mvc;

namespace XCLCMS.Lib.Common
{
    /// <summary>
    /// 公共操作
    /// </summary>
    public class Comm
    {
        #region 页面操作

        /// <summary>
        /// 页面操作类型
        /// </summary>
        public enum HandleType
        {
            /// <summary>
            /// 添加
            /// </summary>
            ADD,

            /// <summary>
            /// 删除
            /// </summary>
            DEL,

            /// <summary>
            /// 更新
            /// </summary>
            UPDATE,

            /// <summary>
            /// 导入
            /// </summary>
            INPUT,

            /// <summary>
            /// 导出
            /// </summary>
            OUTPUT,

            /// <summary>
            /// 其它
            /// </summary>
            OTHER
        }

        #endregion 页面操作

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

        #region 环境相关

        /// <summary>
        /// 获取当前系统所处环境
        /// </summary>
        public static XCLNetTools.Enum.CommonEnum.SysEnvironmentEnum GetCurrentEnvironment()
        {
            string val = XCLNetTools.XML.ConfigClass.GetConfigString("SysEnvironment");
            if (string.IsNullOrWhiteSpace(val))
            {
                throw new Exception("当前系统没有配置环境节点信息！");
            }
            return (XCLNetTools.Enum.CommonEnum.SysEnvironmentEnum)Enum.Parse(typeof(XCLNetTools.Enum.CommonEnum.SysEnvironmentEnum), val.Trim().ToUpper());
        }

        #endregion 环境相关

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
            XCLCMS.Data.Model.Merchant model = null;
            var appModel = XCLCMS.Lib.Common.Comm.GetCurrentApplicationMerchantApp();
            if (null != appModel)
            {
                var request = XCLCMS.Lib.WebAPI.Library.CreateRequest<long>(XCLCMS.Lib.Common.LoginHelper.GetInnerUserToken());
                request.Body = appModel.FK_MerchantID;
                var response = XCLCMS.Lib.WebAPI.MerchantAPI.Detail(request);
                if (null != response)
                {
                    model = response.Body;
                }
            }
            return model;
        }

        /// <summary>
        /// 获取当前应用程序的商户应用实体
        /// </summary>
        public static XCLCMS.Data.Model.MerchantApp GetCurrentApplicationMerchantApp()
        {
            var appId = XCLNetTools.Common.DataTypeConvert.ToLong(XCLNetTools.XML.ConfigClass.GetConfigString("AppID"));
            if (appId <= 0)
            {
                throw new Exception("请给当前应用程序配置AppID信息！");
            }
            XCLCMS.Data.Model.MerchantApp model = null;

            var request = XCLCMS.Lib.WebAPI.Library.CreateRequest<long>(XCLCMS.Lib.Common.LoginHelper.GetInnerUserToken());
            request.Body = appId;
            var response = XCLCMS.Lib.WebAPI.MerchantAppAPI.Detail(request);
            if (null != response)
            {
                model = response.Body;
            }
            if (null == model)
            {
                throw new Exception(string.Format("当前应用程序AppID（{0}）无效！", appId));
            }
            return model;
        }

        #endregion 其它
    }
}