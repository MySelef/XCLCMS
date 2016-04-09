using System.Collections.Generic;

namespace XCLCMS.Data.BLL.View
{
    /// <summary>
    /// v_SysRole
    /// </summary>
    public partial class v_SysRole
    {
        private readonly XCLCMS.Data.DAL.View.v_SysRole dal = new XCLCMS.Data.DAL.View.v_SysRole();

        public v_SysRole()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.View.v_SysRole GetModel(long SysRoleID)
        {
            return dal.GetModel(SysRoleID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysRole> GetModelList(string strWhere)
        {
            return dal.GetModelList(strWhere);
        }

        #endregion BasicMethod

        #region ExtensionMethod

        /// <summary>
        /// 根据parentID返回列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysRole> GetList(long parentID)
        {
            return dal.GetList(parentID);
        }

        #endregion ExtensionMethod
    }
}