using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace XCLCMS.Data.DAL
{
    /// <summary>
    /// 数据访问类:SysLog
    /// </summary>
    public partial class SysLog : XCLCMS.Data.DAL.Common.BaseDAL
    {
        public SysLog()
        { }

        #region Method

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.SysLog> GetModelList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SysLogID,LogLevel,LogType,RefferUrl,Url,Code,Title,Contents,ClientIP,Remark,CreateTime ");
            strSql.Append(" FROM SysLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            var ds = db.ExecuteDataSet(dbCommand);
            return XCLNetTools.Generic.ListHelper.DataSetToList<XCLCMS.Data.Model.SysLog>(ds) as List<XCLCMS.Data.Model.SysLog>;
        }

        #endregion Method

        #region MethodEx

        /// <summary>
        /// 分页数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.SysLog> GetPageList(XCLNetTools.Entity.PagerInfo pageInfo, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            DataTable dt = XCLCMS.Data.DAL.Common.Common.GetPageList("SysLog", pageInfo, strWhere, fieldName, fieldKey, fieldOrder);
            return XCLNetTools.Generic.ListHelper.DataTableToList<XCLCMS.Data.Model.SysLog>(dt) as List<XCLCMS.Data.Model.SysLog>;
        }

        /// <summary>
        /// 删除指定时间范围内的记录
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        public void ClearListByDateTime(DateTime? startTime, DateTime? endTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" DELETE FROM dbo.SysLog WHERE 1=1 ");
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());

            if (null != startTime)
            {
                dbCommand.CommandText += " and CreateTime>=@StartTime ";
                db.AddInParameter(dbCommand, "StartTime", DbType.DateTime, (DateTime)startTime);
            }

            if (null != endTime)
            {
                dbCommand.CommandText += " and CreateTime<=@EndTime ";
                db.AddInParameter(dbCommand, "EndTime", DbType.DateTime, (DateTime)endTime);
            }

            db.ExecuteNonQuery(dbCommand);
        }

        #endregion MethodEx
    }
}