using System;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.Open
{
    /// <summary>
    /// 登录检测
    /// 方式一：提供用户名和密码
    /// 方式二：只需提供已有令牌
    /// </summary>
    [Serializable]
    [DataContract]
    public class LogonCheckEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// 密码（明文）
        /// </summary>
        [DataMember]
        public string Pwd { get; set; }

        /// <summary>
        /// 已有令牌
        /// </summary>
        [DataMember]
        public string UserToken { get; set; }
    }
}