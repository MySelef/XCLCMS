using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.BLL.View
{
    /// <summary>
    /// v_SysDic_Roles
    /// </summary>
    public partial class v_SysDic_Roles
    {
        private readonly XCLCMS.Data.DAL.View.v_SysDic_Roles dal = new XCLCMS.Data.DAL.View.v_SysDic_Roles();
        public v_SysDic_Roles()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.View.v_SysDic_Roles GetModel(long SysDicID)
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
        public List<XCLCMS.Data.Model.View.v_SysDic_Roles> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysDic_Roles> DataTableToList(DataTable dt)
        {
            List<XCLCMS.Data.Model.View.v_SysDic_Roles> modelList = new List<XCLCMS.Data.Model.View.v_SysDic_Roles>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                XCLCMS.Data.Model.View.v_SysDic_Roles model;
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
         /// <summary>
        /// 获取指定userid的角色
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysDic_Roles> GetListByUserID(long userId)
        {
            List<XCLCMS.Data.Model.View.v_SysDic_Roles> lst = null;
            DataTable dt = dal.GetListByUserID(userId);
            if (null != dt && dt.Rows.Count > 0)
            {
                lst = DataTableToList(dt);
            }
            return lst;
        }
        #endregion  ExtensionMethod
    }
}

