using System.Collections.Generic;

namespace XCLCMS.Data.BLL.View
{
    /// <summary>
    /// v_SysDic_SysMenu
    /// </summary>
    public partial class v_SysDic_SysMenu
    {
        private readonly XCLCMS.Data.DAL.View.v_SysDic_SysMenu dal = new XCLCMS.Data.DAL.View.v_SysDic_SysMenu();

        public v_SysDic_SysMenu()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.View.v_SysDic_SysMenu GetModel(long SysDicID)
        {
            return dal.GetModel(SysDicID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysDic_SysMenu> GetModelList(string strWhere)
        {
            return dal.GetModelList(strWhere);
        }

        #endregion BasicMethod
    }
}