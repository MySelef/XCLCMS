using System;
using System.Data;
using System.Collections.Generic;
using XCLCMS.Data.Model;
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
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.SysUserRole model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(XCLCMS.Data.Model.SysUserRole model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.SysUserRole GetModel(long FK_UserInfoID, long FK_SysRoleID)
        {

            return dal.GetModel(FK_UserInfoID, FK_SysRoleID);
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
        public List<XCLCMS.Data.Model.SysUserRole> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.SysUserRole> DataTableToList(DataTable dt)
        {
            List<XCLCMS.Data.Model.SysUserRole> modelList = new List<XCLCMS.Data.Model.SysUserRole>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                XCLCMS.Data.Model.SysUserRole model;
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

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

