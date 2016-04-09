using System.Collections.Generic;

namespace XCLCMS.Data.BLL
{
    /// <summary>
    /// 用户角色关系表
    /// </summary>
    public partial class SysUserRole
    {
        private readonly XCLCMS.Data.DAL.SysUserRole dal = new XCLCMS.Data.DAL.SysUserRole();

        public SysUserRole()
        { }

        #region BasicMethod

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.SysUserRole> GetModelList(string strWhere)
        {
            return dal.GetModelList(strWhere);
        }

        #endregion BasicMethod

        #region ExtensionMethod

        /// <summary>
        /// 增加数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.SysUserRole model, List<long> roleIdList = null)
        {
            return dal.Add(model, roleIdList);
        }

        #endregion ExtensionMethod
    }
}