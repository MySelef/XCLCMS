using System.Collections.Generic;

namespace XCLCMS.Data.BLL
{
    public class FriendLinks
    {
        private readonly XCLCMS.Data.DAL.FriendLinks dal = new XCLCMS.Data.DAL.FriendLinks();

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.FriendLinks model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(XCLCMS.Data.Model.FriendLinks model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.FriendLinks GetModel(long ArticleID)
        {
            return dal.GetModel(ArticleID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.FriendLinks> GetModelList(string strWhere)
        {
            return dal.GetModelList(strWhere);
        }

        #endregion BasicMethod
    }
}