using System.Collections.Generic;
using System.Data;

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
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysDic_SysMenu> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysDic_SysMenu> DataTableToList(DataTable dt)
        {
            List<XCLCMS.Data.Model.View.v_SysDic_SysMenu> modelList = new List<XCLCMS.Data.Model.View.v_SysDic_SysMenu>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                XCLCMS.Data.Model.View.v_SysDic_SysMenu model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        #endregion BasicMethod
    }
}