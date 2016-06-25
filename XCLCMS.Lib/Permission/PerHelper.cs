using System;
using System.Collections.Generic;
using System.Linq;

namespace XCLCMS.Lib.Permission
{
    /// <summary>
    /// 权限帮助类
    /// </summary>
    public class PerHelper
    {
        /// <summary>
        /// 普通商户角色必须包含的权限功能ID列表
        /// </summary>
        public static List<long> NormalMerchantFixedFunctionIDList = new List<long>() {
            (long)XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_DataFilter_OnlyCurrentMerchant
        };

        #region 角色相关

        /// <summary>
        /// 获取角色列表
        /// </summary>
        public static List<XCLCMS.Data.Model.SysRole> GetRoleList()
        {
            return new XCLCMS.Data.BLL.SysRole().GetModelList("");
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
        public static List<XCLCMS.Data.Model.SysRole> GetRoleByUserID(long userId)
        {
            return new XCLCMS.Data.BLL.SysRole().GetListByUserID(userId);
        }

        /// <summary>
        /// 获取普通商户的所有功能数据源列表
        /// </summary>
        public static List<XCLCMS.Data.Model.View.v_SysFunction> GetNormalMerchantFunctionTreeList()
        {
            var bll = new XCLCMS.Data.BLL.SysFunction();
            var roleBLL = new XCLCMS.Data.BLL.View.v_SysRole();
            var roleModel = roleBLL.GetModelByCode(XCLCMS.Data.CommonHelper.SysRoleConst.SysRoleCodeEnum.MerchantMainRole.ToString());
            if (null == roleModel)
            {
                throw new Exception("请指定普通商户所有功能主角色！");
            }
            var allFuns = GetFunctionList();
            var funLst = bll.GetListByRoleID(roleModel.SysRoleID.Value);
            var resultId = new List<long>();

            if (null != funLst && funLst.Count > 0)
            {
                funLst.ForEach(k =>
                {
                    var lst = bll.GetLayerListBySysFunctionId(k.SysFunctionID);
                    if (null != lst && lst.Count > 0)
                    {
                        resultId.AddRange(lst.Select(m => m.SysFunctionID));
                    }
                });
            }
            resultId = resultId.Distinct().ToList();
            return allFuns.Where(k => resultId.Contains(k.SysFunctionID.Value)).ToList() ?? new List<Data.Model.View.v_SysFunction>();
        }

        /// <summary>
        /// 获取普通商户的所有功能id List
        /// </summary>
        public static List<long> GetNormalMerchantFunctionIDList()
        {
            List<long> result = null;
            var lst = GetNormalMerchantFunctionTreeList();
            if (null != lst && lst.Count > 0)
            {
                result = lst.Where(k => k.IsLeaf == 1).Select(k => (long)k.SysFunctionID).ToList();
            }
            return result ?? new List<long>();
        }

        #endregion 角色相关

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

        #endregion 权限功能相关

        #region 其它

        /// <summary>
        /// 判断指定用户是否只能访问自己商户的数据
        /// </summary>
        public static bool IsOnlyCurrentMerchant(long userId)
        {
            return HasPermission(userId, Function.FunctionEnum.SysFun_DataFilter_OnlyCurrentMerchant);
        }

        #endregion 其它
    }
}