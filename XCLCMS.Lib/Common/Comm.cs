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

        #endregion 其它
    }
}