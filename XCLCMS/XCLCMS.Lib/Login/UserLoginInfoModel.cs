using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XCLCMS.Lib.Login
{
    /// <summary>
    /// 用户登录时，存放在cookie中的登录信息
    /// </summary>
    public class UserLoginInfoModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码 （已加密）
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// tostring
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0}^{1}",UserName,Pwd);
        }
    }
}