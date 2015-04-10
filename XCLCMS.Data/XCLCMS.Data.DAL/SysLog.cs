using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;

namespace XCLCMS.Data.DAL
{
    /// <summary>
    /// 数据访问类:SysLog
    /// </summary>
    public partial class SysLog : XCLCMS.Data.Common.BaseDAL
    {
        public SysLog()
        { }
        #region  Method


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.SysLog DataRowToModel(DataRow row)
        {
            XCLCMS.Data.Model.SysLog model = new XCLCMS.Data.Model.SysLog();
            if (row != null)
            {
                if (row["SysLogID"] != null && row["SysLogID"].ToString() != "")
                {
                    model.SysLogID = long.Parse(row["SysLogID"].ToString());
                }
                if (row["LogLevel"] != null)
                {
                    model.LogLevel = row["LogLevel"].ToString();
                }
                if (row["LogType"] != null)
                {
                    model.LogType = row["LogType"].ToString();
                }
                if (row["RefferUrl"] != null)
                {
                    model.RefferUrl = row["RefferUrl"].ToString();
                }
                if (row["Url"] != null)
                {
                    model.Url = row["Url"].ToString();
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Contents"] != null)
                {
                    model.Contents = row["Contents"].ToString();
                }
                if (row["ClientIP"] != null)
                {
                    model.ClientIP = row["ClientIP"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
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
            return db.ExecuteDataSet(dbCommand);
        }

        #endregion  Method
        #region  MethodEx
        /// <summary>
        /// 分页数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.SysLog> GetPageList(int pageSize, int pageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            DataTable dt = XCLCMS.Data.DAL.Common.Common.GetPageList("SysLog", pageSize, pageIndex, ref recordCount, strWhere, fieldName, fieldKey, fieldOrder);
            return XCLNetTools.Generic.ListHelper<XCLCMS.Data.Model.SysLog>.DataTableToList(dt) as List<XCLCMS.Data.Model.SysLog>;
        }

        /// <summary>
        /// 删除指定时间范围内的记录
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        public void ClearListByDateTime(DateTime? startTime,DateTime? endTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" DELETE FROM dbo.SysLog WHERE 1=1 ");
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());

            if (null != startTime)
            {
                dbCommand.CommandText+=" and CreateTime>=@StartTime ";
                db.AddInParameter(dbCommand, "StartTime", DbType.DateTime, (DateTime)startTime);
            }

            if (null != endTime)
            {
                dbCommand.CommandText += " and CreateTime<=@EndTime ";
                db.AddInParameter(dbCommand, "EndTime", DbType.DateTime, (DateTime)endTime);
            }

            db.ExecuteNonQuery(dbCommand);

        }
        #endregion  MethodEx
    }
}

