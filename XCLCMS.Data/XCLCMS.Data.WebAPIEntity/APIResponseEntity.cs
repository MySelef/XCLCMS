using System;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity
{
    /// <summary>
    /// web api response实体
    /// </summary>
    [Serializable]
    [DataContract]
    public class APIResponseEntity<TBody>
    {
        private bool _isSuccess = true;
        private TBody _body = default(TBody);

        /// <summary>
        /// 是否成功（如果TBody与IsSuccess属性均为bool，则Body与IsSuccess一致）
        /// </summary>
        [DataMember]
        public bool IsSuccess
        {
            get { return this._isSuccess; }
            set
            {
                this._isSuccess = value;
                if (this._body is bool)
                {
                    this._body = (TBody)(object)value;
                }
            }
        }

        /// <summary>
        /// 返回结果（如果TBody与IsSuccess属性均为bool，则Body与IsSuccess一致）
        /// </summary>
        [DataMember]
        public TBody Body
        {
            get
            {
                return this._body;
            }
            set
            {
                this._body = value;
                if (this._body is bool)
                {
                    this._isSuccess = (bool)(object)value;
                }
            }
        }

        /// <summary>
        /// 消息提示
        /// </summary>
        [DataMember]
        public string Message { get; set; }
    }
}