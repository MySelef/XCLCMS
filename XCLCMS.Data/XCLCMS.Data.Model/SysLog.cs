using System;

namespace XCLCMS.Data.Model
{
    /// <summary>
    /// 系统日志记录
    /// </summary>
    [Serializable]
    public partial class SysLog
    {
        public SysLog()
        { }

        #region Model

        private long _syslogid;
        private string _loglevel;
        private string _logtype;
        private string _refferurl;
        private string _url;
        private string _code;
        private string _title;
        private string _contents;
        private string _clientip;
        private string _remark;
        private DateTime _createtime;

        /// <summary>
        ///
        /// </summary>
        public long SysLogID
        {
            set { _syslogid = value; }
            get { return _syslogid; }
        }

        /// <summary>
        /// 日志级别
        /// </summary>
        public string LogLevel
        {
            set { _loglevel = value; }
            get { return _loglevel; }
        }

        /// <summary>
        /// 日志类别(LogTypeEnum)
        /// </summary>
        public string LogType
        {
            set { _logtype = value; }
            get { return _logtype; }
        }

        /// <summary>
        /// 来源URL
        /// </summary>
        public string RefferUrl
        {
            set { _refferurl = value; }
            get { return _refferurl; }
        }

        /// <summary>
        /// Url
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }

        /// <summary>
        /// 日志代码
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Contents
        {
            set { _contents = value; }
            get { return _contents; }
        }

        /// <summary>
        /// 客户端IP
        /// </summary>
        public string ClientIP
        {
            set { _clientip = value; }
            get { return _clientip; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }

        #endregion Model
    }
}