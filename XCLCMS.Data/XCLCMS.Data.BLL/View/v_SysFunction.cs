using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace XCLCMS.Data.BLL.View
{
    /// <summary>
    /// v_SysFunction
    /// </summary>
    public partial class v_SysFunction
    {
        private readonly XCLCMS.Data.DAL.View.v_SysFunction dal = new XCLCMS.Data.DAL.View.v_SysFunction();
        public v_SysFunction()
        { }
        #region  BasicMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.View.v_SysFunction GetModel(long SysFunctionID)
        {

            return dal.GetModel(SysFunctionID);
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
        public List<XCLCMS.Data.Model.View.v_SysFunction> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysFunction> DataTableToList(DataTable dt)
        {
            List<XCLCMS.Data.Model.View.v_SysFunction> modelList = new List<XCLCMS.Data.Model.View.v_SysFunction>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                XCLCMS.Data.Model.View.v_SysFunction model;
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
        /// 根据parentID返回列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysFunction> GetList(long parentID)
        {
            List<XCLCMS.Data.Model.View.v_SysFunction> lst = null;
            DataTable dt = dal.GetList(parentID);
            if (null != dt && dt.Rows.Count > 0)
            {
                lst = DataTableToList(dt);
            }
            return lst;
        }
        #endregion  ExtensionMethod
    }
}

