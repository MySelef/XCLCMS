using System.Collections.Generic;
using XCLCMS.Data.Model.Custom;

namespace XCLCMS.Data.BLL
{
    /// <summary>
    /// 标签表
    /// </summary>
    public partial class Tags
    {
        private readonly XCLCMS.Data.DAL.Tags dal = new XCLCMS.Data.DAL.Tags();

        public Tags()
        { }

        #region BasicMethod

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.Tags model)
        {
            return dal.Add(model);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(XCLCMS.Data.Model.Tags model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.Tags GetModel(long TagsID)
        {
            return dal.GetModel(TagsID);
        }

        #endregion BasicMethod

        #region Extends

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.Tags GetModel(Tags_IsExistCondition condition)
        {
            return dal.GetModel(condition);
        }

        /// <summary>
        /// 批量添加tags，并返回添加成功的tagid列表
        /// </summary>
        public XCLNetTools.Entity.MethodResult<Tags_AddMethodResult> Add(List<XCLCMS.Data.Model.Tags> lst)
        {
            return dal.Add(lst);
        }

        #endregion Extends
    }
}