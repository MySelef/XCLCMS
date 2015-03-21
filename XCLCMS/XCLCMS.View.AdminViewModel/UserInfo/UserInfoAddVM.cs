using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public XCLCMS.Data.Model.Custom.UserInfoWithMore UserInfoWithMore { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysDic_Roles> AllRoleList { get; set; }
    }
}
