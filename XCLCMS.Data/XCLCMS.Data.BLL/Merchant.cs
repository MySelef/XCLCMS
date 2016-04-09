using System.Collections.Generic;
using System.Data;

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

        #region BasicMethod

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
            return XCLNetTools.Generic.ListHelper.DataTableToList<XCLCMS.Data.Model.Merchant>(ds.Tables[0]) as List<XCLCMS.Data.Model.Merchant>;
        }

        #endregion BasicMethod

        #region ExtensionMethod

        /// <summary>
        /// 分页列表
        /// </summary>
        public List<XCLCMS.Data.Model.Merchant> GetPageList(XCLNetTools.Entity.PagerInfo pageInfo, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            return dal.GetPageList(pageInfo, strWhere, fieldName, fieldKey, fieldOrder);
        }

        /// <summary>
        /// 获取商户类型
        /// </summary>
        public Dictionary<string, string> GetMerchantTypeDic()
        {
            return new XCLCMS.Data.BLL.SysDic().GetDictionaryByCode(XCLCMS.Data.CommonHelper.SysDicConst.SysDicCodeEnum.MerchantType.ToString());
        }

        #endregion ExtensionMethod
    }
}