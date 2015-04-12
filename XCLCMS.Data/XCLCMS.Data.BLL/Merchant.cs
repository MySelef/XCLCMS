using System;
using System.Data;
using System.Collections.Generic;
using XCLCMS.Data.Model;

namespace XCLCMS.Data.BLL
{
    /// <summary>
    /// 商户表
    /// </summary>
    public partial class Merchant
    {
        private readonly XCLCMS.Data.DAL.Merchant dal = new XCLCMS.Data.DAL.Merchant();
        public Merchant()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.Merchant model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(XCLCMS.Data.Model.Merchant model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.Merchant GetModel(long MerchantID)
        {
            return dal.GetModel(MerchantID);
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
        public List<XCLCMS.Data.Model.Merchant> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.Merchant> DataTableToList(DataTable dt)
        {
            List<XCLCMS.Data.Model.Merchant> modelList = new List<XCLCMS.Data.Model.Merchant>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                XCLCMS.Data.Model.Merchant model;
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

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 分页列表
        /// </summary>
        public List<XCLCMS.Data.Model.Merchant> GetPageList(int pageSize, int pageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            return dal.GetPageList(pageSize, pageIndex, ref recordCount, strWhere, fieldName, fieldKey, fieldOrder);
        }
        #endregion  ExtensionMethod
    }
}

