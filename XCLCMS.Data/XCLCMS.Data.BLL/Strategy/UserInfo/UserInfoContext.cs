using System.Collections.Generic;

namespace XCLCMS.Data.BLL.Strategy.UserInfo
{
    /// <summary>
    /// 用户上下文
    /// </summary>
    public class UserInfoContext : BaseContext
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public XCLCMS.Data.Model.UserInfo UserInfo { get; set; }

        /// <summary>
        /// 用户的角色id
        /// </summary>
        public List<long> UserRoleIDs { get; set; }
    }
}