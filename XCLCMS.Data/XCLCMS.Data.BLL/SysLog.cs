using System;
using System.Collections.Generic;
using System.Data;

namespace XCLCMS.Data.BLL
{
    /// <summary>
    /// 系统日志记录
    /// </summary>
    public partial class SysLog
    {
        private readonly XCLCMS.Data.DAL.SysLog dal = new XCLCMS.Data.DAL.SysLog();

        public SysLog()
        { }

        #region BasicMethod

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
        public List<XCLCMS.Data.Model.SysLog> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return XCLNetTools.Generic.ListHelper.DataTableToList<XCLCMS.Data.Model.SysLog>(ds.Tables[0]) as List<XCLCMS.Data.Model.SysLog>;
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
        public List<XCLCMS.Data.Model.SysLog> GetPageList(XCLNetTools.Entity.PagerInfo pageInfo, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            return dal.GetPageList(pageInfo, strWhere, fieldName, fieldKey, fieldOrder);
        }

        /// <summary>
        /// 删除指定时间范围内的记录
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        public void ClearListByDateTime(DateTime? startTime, DateTime? endTime)
        {
            dal.ClearListByDateTime(startTime, endTime);
        }

        #endregion ExtensionMethod
    }
}