using System.Collections.Generic;
using System.Data;

namespace XCLCMS.Data.BLL
{
    /// <summary>
    /// 网站配置表
    /// </summary>
    public partial class SysWebSetting
    {
        private readonly XCLCMS.Data.DAL.SysWebSetting dal = new XCLCMS.Data.DAL.SysWebSetting();

        public SysWebSetting()
        { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.SysWebSetting model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(XCLCMS.Data.Model.SysWebSetting model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.SysWebSetting GetModel(long SysWebSettingID)
        {
            return dal.GetModel(SysWebSettingID);
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
        public List<XCLCMS.Data.Model.SysWebSetting> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.SysWebSetting> DataTableToList(DataTable dt)
        {
            List<XCLCMS.Data.Model.SysWebSetting> modelList = new List<XCLCMS.Data.Model.SysWebSetting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                XCLCMS.Data.Model.SysWebSetting model;
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

        #region ExtensionMethod

        /// <summary>
        /// 分页数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.SysWebSetting> GetPageList(XCLNetTools.Entity.PagerInfo pageInfo, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            return dal.GetPageList(pageInfo, strWhere, fieldName, fieldKey, fieldOrder);
        }

        /// <summary>
        /// 判断指定配置名是否存在
        /// </summary>
        public bool IsExistKeyName(string keyName)
        {
            return dal.IsExistKeyName(keyName);
        }

        #endregion ExtensionMethod
    }
}