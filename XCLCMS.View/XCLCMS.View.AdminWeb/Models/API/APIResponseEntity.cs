using System;

namespace XCLCMS.View.AdminWeb.Models.API
{
    /// <summary>
    /// web api response实体
    /// </summary>
    [Serializable]
    public class APIResponseEntity<T> where T : new()
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// 消息提示
        /// </summary>
        public string Message { get; set; }
    }
}