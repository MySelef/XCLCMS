using System;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity
{
    /// <summary>
    /// web api response实体
    /// </summary>
    [Serializable]
    [DataContract]
    public class APIResponseEntity<T> where T : new()
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        [DataMember]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        [DataMember]
        public T Result { get; set; }

        /// <summary>
        /// 消息提示
        /// </summary>
        [DataMember]
        public string Message { get; set; }
    }
}