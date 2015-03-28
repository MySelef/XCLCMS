using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using XCLCMS.Data.DBUtility;
namespace XCLCMS.Data.DAL
{
    /// <summary>
    /// 数据访问类:SysLog
    /// </summary>
    public partial class SysLog
    {
        public SysLog()
        { }
        #region  Method

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public long Add(XCLCMS.Data.Model.SysLog model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@SysLogID", SqlDbType.BigInt,8),
					new SqlParameter("@LogLevel", SqlDbType.VarChar,50),
					new SqlParameter("@LogType", SqlDbType.VarChar,50),
					new SqlParameter("@RefferUrl", SqlDbType.VarChar,1000),
					new SqlParameter("@Url", SqlDbType.VarChar,1000),
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@Title", SqlDbType.VarChar,500),
					new SqlParameter("@Contents", SqlDbType.VarChar,4000),
					new SqlParameter("@ClientIP", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,2000),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.LogLevel;
            parameters[2].Value = model.LogType;
            parameters[3].Value = model.RefferUrl;
            parameters[4].Value = model.Url;
            parameters[5].Value = model.Code;
            parameters[6].Value = model.Title;
            parameters[7].Value = model.Contents;
            parameters[8].Value = model.ClientIP;
            parameters[9].Value = model.Remark;
            parameters[10].Value = model.CreateTime;

            DbHelperSQL.RunProcedure("SysLog_ADD", parameters, out rowsAffected);
            return (long)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(XCLCMS.Data.Model.SysLog model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@SysLogID", SqlDbType.BigInt,8),
					new SqlParameter("@LogLevel", SqlDbType.VarChar,50),
					new SqlParameter("@LogType", SqlDbType.VarChar,50),
					new SqlParameter("@RefferUrl", SqlDbType.VarChar,1000),
					new SqlParameter("@Url", SqlDbType.VarChar,1000),
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@Title", SqlDbType.VarChar,500),
					new SqlParameter("@Contents", SqlDbType.VarChar,4000),
					new SqlParameter("@ClientIP", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,2000),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.SysLogID;
            parameters[1].Value = model.LogLevel;
            parameters[2].Value = model.LogType;
            parameters[3].Value = model.RefferUrl;
            parameters[4].Value = model.Url;
            parameters[5].Value = model.Code;
            parameters[6].Value = model.Title;
            parameters[7].Value = model.Contents;
            parameters[8].Value = model.ClientIP;
            parameters[9].Value = model.Remark;
            parameters[10].Value = model.CreateTime;

            DbHelperSQL.RunProcedure("SysLog_Update", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.SysLog GetModel(long SysLogID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@SysLogID", SqlDbType.BigInt)
			};
            parameters[0].Value = SysLogID;

            XCLCMS.Data.Model.SysLog model = new XCLCMS.Data.Model.SysLog();
            DataSet ds = DbHelperSQL.RunProcedure("SysLog_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


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
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
        #region  MethodEx
        /// <summary>
        /// 分页数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.SysLog> GetPageList(int pageSize, int pageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            DataTable dt = XCLCMS.Data.DAL.CommonDAL.CommonDALHelper.GetPageList("SysLog", pageSize, pageIndex, ref recordCount, strWhere, fieldName, fieldKey, fieldOrder);
            return XCLNetTools.Generic.ListHelper<XCLCMS.Data.Model.SysLog>.DataTableToList(dt) as List<XCLCMS.Data.Model.SysLog>;
        }

        /// <summary>
        /// 删除指定时间范围内的记录
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        public void ClearListByDateTime(DateTime? startTime,DateTime? endTime)
        {
            List<SqlParameter> psList = new List<SqlParameter>();
            SqlParameter sp = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" DELETE FROM dbo.SysLog WHERE 1=1 ");
            if (null != startTime)
            {
                strSql.Append(" and CreateTime>=@StartTime ");
                sp = new SqlParameter("@StartTime", SqlDbType.DateTime);
                sp.Value = (DateTime)startTime;
                psList.Add(sp);
            }
            if (null != endTime)
            {
                strSql.Append(" and CreateTime<=@EndTime ");
                sp = new SqlParameter("@EndTime", SqlDbType.DateTime);
                sp.Value = (DateTime)endTime;
                psList.Add(sp);
            }
            DbHelperSQL.ExecuteSql(strSql.ToString(), psList.ToArray());

        }
        #endregion  MethodEx
    }
}

