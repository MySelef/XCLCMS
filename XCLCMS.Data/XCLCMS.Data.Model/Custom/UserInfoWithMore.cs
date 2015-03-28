using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.Model.Custom
{
    /// <summary>
    /// 包含其它信息的用户model
    /// </summary>
    public class UserInfoWithMore
    {
        /// <summary>
        /// 用户model
        /// </summary>
        public XCLCMS.Data.Model.UserInfo UserInfo { get; set; }

        /// <summary>
        /// 当前用户的角色id
        /// </summary>
        public List<long> UserRoleIDs { get; set; }

        /// <summary>
        /// 状态位
        /// </summary>
        public int WithMoreState { get; set; }
    }
}
