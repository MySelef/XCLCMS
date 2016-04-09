using System.Collections.Generic;
using System.Data;

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
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.SysUserRole> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return XCLNetTools.Generic.ListHelper.DataTableToList<XCLCMS.Data.Model.SysUserRole>(ds.Tables[0]) as List<XCLCMS.Data.Model.SysUserRole>;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
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