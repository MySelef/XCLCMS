using System.Collections.Generic;

namespace XCLCMS.Data.BLL
{
    /// <summary>
    /// 所有附件关系表
    /// </summary>
    public partial class ObjectAttachment
    {
        private readonly XCLCMS.Data.DAL.ObjectAttachment dal = new XCLCMS.Data.DAL.ObjectAttachment();

        public ObjectAttachment()
        { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.ObjectAttachment model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.ObjectAttachment> GetModelList(string strWhere)
        {
            return dal.GetModelList(strWhere);
        }

        #endregion BasicMethod
    }
}