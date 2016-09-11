using System.Collections.Generic;

namespace XCLCMS.Data.BLL
{
    public class ObjectTag
    {
        private readonly XCLCMS.Data.DAL.ObjectTag dal = new XCLCMS.Data.DAL.ObjectTag();

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.ObjectTag model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        public bool Delete(XCLCMS.Data.CommonHelper.EnumType.ObjectTypeEnum objectType, long objectID)
        {
            return dal.Delete(objectType, objectID);
        }

        /// <summary>
        /// 批量添加（先删再加）
        /// </summary>
        public bool Add(XCLCMS.Data.CommonHelper.EnumType.ObjectTypeEnum objectType, long objectID, List<long> tagIDList, XCLCMS.Data.Model.Custom.ContextModel context = null)
        {
            return dal.Add(objectType, objectID, tagIDList, context);
        }
    }
}