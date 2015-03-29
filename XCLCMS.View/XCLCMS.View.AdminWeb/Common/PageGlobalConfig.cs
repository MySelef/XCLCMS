using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XCLCMS.View.AdminWeb.Common
{
    /// <summary>
    /// 页面全局配置（序列化为json）
    /// </summary>
    [Serializable]
    public class PageGlobalConfig
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 当前用户是否已登录
        /// </summary>
        public bool IsLogOn { get; set; }

        /// <summary>
        /// 站点根路径
        /// </summary>
        public string RootURL { get; set; }

        /// <summary>
        /// 静态资源根路径
        /// </summary>
        public string ResourceURL { get; set; }

        /// <summary>
        /// 静态资源版本号
        /// </summary>
        public string ResourceVersion { get; set; }

        /// <summary>
        /// json提示key
        /// </summary>
        public string XCLJsonMessageName { get; set; }

        /// <summary>
        /// 枚举json
        /// </summary>
        public string EnumConfig { get; set; }

        /// <summary>
        /// 当前父菜单id
        /// </summary>
        public long CurrentParentMenuID { get; set; }

        /// <summary>
        /// 当前菜单id
        /// </summary>
        public long CurrentMenuID { get; set; }
    }
}