using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Lib.Permission
{
    /// <summary>
    /// 权限帮助类
    /// </summary>
    public class PerHelper
    {
        #region 角色相关
        /// <summary>
        /// 获取角色列表
        /// </summary>
        public static List<XCLCMS.Data.Model.View.v_SysDic_Roles> GetRoleList()
        {
            return new XCLCMS.Data.BLL.View.v_SysDic_Roles().GetModelList("");
        }

        /// <summary>
        /// 获取功能列表
        /// </summary>
        public static List<XCLCMS.Data.Model.View.v_SysFunction> GetFunctionList()
        {
            return new XCLCMS.Data.BLL.View.v_SysFunction().GetModelList("");
        }

        /// <summary>
        /// 获取指定用户的角色
        /// </summary>
        public static List<XCLCMS.Data.Model.View.v_SysDic_Roles> GetRoleByUserID(long userId)
        {
            return new XCLCMS.Data.BLL.View.v_SysDic_Roles().GetListByUserID(userId);
        }

        #endregion

        #region 权限功能相关
        /// <summary>
        /// 判断指定用户是否至少拥有权限组中的某个权限
        /// </summary>
        public static bool HasAnyPermission(long userId, List<XCLCMS.Lib.Permission.Function.FunctionEnum> functionList)
        {
            bool flag = false;
            if (null != functionList && functionList.Count > 0)
            {
                List<long> funList = functionList.Select(k => (long)k).ToList();
                flag = new XCLCMS.Data.BLL.SysFunction().CheckUserHasAnyFunction(userId, funList);
            }
            return flag;
        }

        /// <summary>
        /// 判断指定用户是否拥有某个权限
        /// </summary>
        public static bool HasPermission(long userId, XCLCMS.Lib.Permission.Function.FunctionEnum funEm)
        {
            return PerHelper.HasAnyPermission(userId, new List<Function.FunctionEnum>() { 
                funEm
            });
        }
        #endregion
    }
}
