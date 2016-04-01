using System.Collections.Generic;
using System.Data;

namespace XCLCMS.Data.BLL
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    public partial class UserInfo
    {
        private readonly XCLCMS.Data.DAL.UserInfo dal = new XCLCMS.Data.DAL.UserInfo();

        public UserInfo()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.UserInfo GetModel(long UserInfoID)
        {
            return dal.GetModel(UserInfoID);
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
        public List<XCLCMS.Data.Model.UserInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.UserInfo> DataTableToList(DataTable dt)
        {
            List<XCLCMS.Data.Model.UserInfo> modelList = new List<XCLCMS.Data.Model.UserInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                XCLCMS.Data.Model.UserInfo model;
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
        /// 分页列表
        /// </summary>
        public List<XCLCMS.Data.Model.UserInfo> GetPageList(XCLNetTools.Entity.PagerInfo pageInfo, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            return dal.GetPageList(pageInfo, strWhere, fieldName, fieldKey, fieldOrder);
        }

        /// <summary>
        /// 判断指定用户名是否存在
        /// </summary>
        public bool IsExistUserName(string userName)
        {
            return dal.IsExistUserName(userName);
        }

        /// <summary>
        /// 根据用户名和密码获取用户实体
        /// </summary>
        public XCLCMS.Data.Model.UserInfo GetModel(string userName, string pwd)
        {
            return dal.GetModel(userName, pwd);
        }

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.UserInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(XCLCMS.Data.Model.UserInfo model)
        {
            return dal.Update(model);
        }

        #endregion ExtensionMethod
    }
}