using System.Collections.Generic;

namespace XCLCMS.Data.BLL.View
{
    public class v_Attachment
    {
        private readonly XCLCMS.Data.DAL.View.v_Attachment dal = new XCLCMS.Data.DAL.View.v_Attachment();

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.View.v_Attachment GetModel(long AttachmentID)
        {
            return dal.GetModel(AttachmentID);
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_Attachment> GetPageList(XCLNetTools.Entity.PagerInfo pageInfo, XCLNetTools.Entity.SqlPagerConditionEntity condition)
        {
            return dal.GetPageList(pageInfo, condition);
        }
    }
}