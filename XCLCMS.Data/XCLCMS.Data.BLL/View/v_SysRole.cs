using System.Collections.Generic;
using System.Data;

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
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysRole> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysRole> DataTableToList(DataTable dt)
        {
            List<XCLCMS.Data.Model.View.v_SysRole> modelList = new List<XCLCMS.Data.Model.View.v_SysRole>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                XCLCMS.Data.Model.View.v_SysRole model;
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

        #endregion BasicMethod

        #region ExtensionMethod

        /// <summary>
        /// 根据parentID返回列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysRole> GetList(long parentID)
        {
            List<XCLCMS.Data.Model.View.v_SysRole> lst = null;
            DataTable dt = dal.GetList(parentID);
            if (null != dt && dt.Rows.Count > 0)
            {
                lst = DataTableToList(dt);
            }
            return lst;
        }

        #endregion ExtensionMethod
    }
}