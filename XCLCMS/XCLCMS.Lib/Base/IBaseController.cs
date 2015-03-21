using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace XCLCMS.Lib.Base
{
    /// <summary>
    /// 基类接口
    /// </summary>
    public interface IBaseController
    {
        /// <summary>
        /// 当前所登录的用户model
        /// </summary>
        XCLCMS.Data.Model.UserInfo CurrentUserModel { get;}
    }
}
