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
        /// 系统所属环境枚举
        /// </summary>
        public enum SysEnvironmentEnum
        {
            /// <summary>
            /// 开发环境
            /// </summary>
            DEV,

            /// <summary>
            /// 测试环境
            /// </summary>
            FAT,

            /// <summary>
            /// UAT环境
            /// </summary>
            UAT,

            /// <summary>
            /// 生产环境
            /// </summary>
            PRD
        }

        /// <summary>
        /// 获取当前系统所处环境
        /// </summary>
        public static SysEnvironmentEnum GetCurrentEnvironment()
        {
            string val = XCLNetTools.XML.ConfigClass.GetConfigString("SysEnvironment");
            if (string.IsNullOrWhiteSpace(val))
            {
                throw new Exception("当前系统没有配置环境节点信息！");
            }
            return (SysEnvironmentEnum)Enum.Parse(typeof(SysEnvironmentEnum), val.Trim().ToUpper());
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
        /// 获取当前应用实体
        /// </summary>
        public static XCLCMS.Data.Model.MerchantApp CurrentApplicationMerchantApp
        {
            get
            {
                var appId = XCLNetTools.Common.DataTypeConvert.ToLong(XCLNetTools.XML.ConfigClass.GetConfigString("AppID"));
                var model = new XCLCMS.Data.BLL.MerchantApp().GetModel(appId);
                if (null == model)
                {
                    throw new Exception("此应用未配置AppID信息！");
                }
                return model;
            }
        }

        #endregion 其它
    }
}