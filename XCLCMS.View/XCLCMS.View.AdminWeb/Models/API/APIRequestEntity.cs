using System;

namespace XCLCMS.View.AdminWeb.Models.API
{
    /// <summary>
    /// web api request实体
    /// </summary>
    [Serializable]
    public class APIRequestEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PWD { get; set; }

        /// <summary>
        /// 来源ip
        /// </summary>
        public string ClientIP { get; set; }

        /// <summary>
        /// 来源url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 请求ID
        /// </summary>
        public string RequestID { get; } = Guid.NewGuid().ToString("N");
    }
}