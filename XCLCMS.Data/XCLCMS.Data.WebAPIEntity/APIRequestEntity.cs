using System;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity
{
    /// <summary>
    /// web api request实体
    /// </summary>
    [Serializable]
    [DataContract]
    public class APIRequestEntity<T> where T : new()
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [DataMember]
        public string PWD { get; set; }

        /// <summary>
        /// 来源ip
        /// </summary>
        [DataMember]
        public string ClientIP { get; set; }

        /// <summary>
        /// 来源url
        /// </summary>
        [DataMember]
        public string Url { get; set; }

        /// <summary>
        /// 请求ID
        /// </summary>
        [DataMember]
        public string RequestID { get; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// request的数据
        /// </summary>
        [DataMember]
        public T Data { get; set; }
    }
}