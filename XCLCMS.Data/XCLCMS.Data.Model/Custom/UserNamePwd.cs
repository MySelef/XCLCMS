using System;

namespace XCLCMS.Data.Model.Custom
{
    /// <summary>
    /// 用户名和密码 实体
    /// </summary>
    [Serializable]
    public class UserNamePwd
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码（密文）
        /// </summary>
        public string Pwd { get; set; }
    }
}