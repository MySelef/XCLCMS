using System.Collections.Generic;

namespace XCLCMS.View.AdminViewModel.UserInfo
{
    /// <summary>
    /// 添加与修改用户信息model
    /// </summary>
    public class UserInfoAddVM
    {
        /// <summary>
        /// 表单action
        /// </summary>
        public string FormAction { get; set; }

        /// <summary>
        /// 用户model
        /// </summary>
        public XCLCMS.Data.Model.UserInfo UserInfo { get; set; }

        /// <summary>
        /// 角色id list
        /// </summary>
        public List<long> UserRoleIDs { get; set; }
    }
}