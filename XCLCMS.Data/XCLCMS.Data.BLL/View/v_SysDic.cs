using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.BLL.View
{
    public  class v_SysDic
    {
        private readonly XCLCMS.Data.DAL.View.v_SysDic dal = new XCLCMS.Data.DAL.View.v_SysDic();
        public v_SysDic()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.View.v_SysDic GetModel(long SysDicID)
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
        public List<XCLCMS.Data.Model.View.v_SysDic> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysDic> DataTableToList(DataTable dt)
        {
            List<XCLCMS.Data.Model.View.v_SysDic> modelList = new List<XCLCMS.Data.Model.View.v_SysDic>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                XCLCMS.Data.Model.View.v_SysDic model;
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
        public List<XCLCMS.Data.Model.View.v_SysDic> GetList(long parentID)
        {
            List<XCLCMS.Data.Model.View.v_SysDic> lst = null;
            DataTable dt = dal.GetList(parentID);
            if (null != dt && dt.Rows.Count > 0)
            {
                lst = DataTableToList(dt);
            }
            return lst;
        }

         /// <summary>
        /// 递归获取指定code下的所有列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysDic> GetAllUnderListByCode(string code)
        {
            List<XCLCMS.Data.Model.View.v_SysDic> lst = null;
            DataTable dt = dal.GetAllUnderListByCode(code);
            if (null != dt && dt.Rows.Count > 0)
            {
                lst = DataTableToList(dt);
            }
            return lst;
        }
        #endregion  ExtensionMethod
    }
}
