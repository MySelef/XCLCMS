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
    /// 数据访问类:SysWebSetting
    /// </summary>
    public partial class SysWebSetting : XCLCMS.Data.DAL.Common.BaseDAL
    {
        public SysWebSetting()
        { }
        #region  Method


        /// <summary>
        ///  增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.SysWebSetting model)
        {
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_SysWebSetting_ADD");
            db.AddInParameter(dbCommand, "SysWebSettingID", DbType.Int64, model.SysWebSettingID);
            db.AddInParameter(dbCommand, "KeyName", DbType.AnsiString, model.KeyName);
            db.AddInParameter(dbCommand, "KeyValue", DbType.AnsiString, model.KeyValue);
            db.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
            db.AddInParameter(dbCommand, "RecordState", DbType.AnsiString, model.RecordState);
            db.AddInParameter(dbCommand, "CreateTime", DbType.DateTime, model.CreateTime);
            db.AddInParameter(dbCommand, "CreaterID", DbType.Int64, model.CreaterID);
            db.AddInParameter(dbCommand, "CreaterName", DbType.String, model.CreaterName);
            db.AddInParameter(dbCommand, "UpdateTime", DbType.DateTime, model.UpdateTime);
            db.AddInParameter(dbCommand, "UpdaterID", DbType.Int64, model.UpdaterID);
            db.AddInParameter(dbCommand, "UpdaterName", DbType.String, model.UpdaterName);

            db.AddOutParameter(dbCommand, "ResultCode", DbType.Int32, 4);
            db.AddOutParameter(dbCommand, "ResultMessage", DbType.String, 1000);
            db.ExecuteNonQuery(dbCommand);

            var result = XCLCMS.Data.DAL.Common.Common.GetProcedureResult(dbCommand.Parameters);
            if (result.IsSuccess)
            {
                return true;
            }
            else
            {
                throw new Exception(result.ResultMessage);
            }
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(XCLCMS.Data.Model.SysWebSetting model)
        {
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_SysWebSetting_Update");
            db.AddInParameter(dbCommand, "SysWebSettingID", DbType.Int64, model.SysWebSettingID);
            db.AddInParameter(dbCommand, "KeyName", DbType.AnsiString, model.KeyName);
            db.AddInParameter(dbCommand, "KeyValue", DbType.AnsiString, model.KeyValue);
            db.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
            db.AddInParameter(dbCommand, "RecordState", DbType.AnsiString, model.RecordState);
            db.AddInParameter(dbCommand, "CreateTime", DbType.DateTime, model.CreateTime);
            db.AddInParameter(dbCommand, "CreaterID", DbType.Int64, model.CreaterID);
            db.AddInParameter(dbCommand, "CreaterName", DbType.String, model.CreaterName);
            db.AddInParameter(dbCommand, "UpdateTime", DbType.DateTime, model.UpdateTime);
            db.AddInParameter(dbCommand, "UpdaterID", DbType.Int64, model.UpdaterID);
            db.AddInParameter(dbCommand, "UpdaterName", DbType.String, model.UpdaterName);

            db.AddOutParameter(dbCommand, "ResultCode", DbType.Int32, 4);
            db.AddOutParameter(dbCommand, "ResultMessage", DbType.String, 1000);
            db.ExecuteNonQuery(dbCommand);

            var result = XCLCMS.Data.DAL.Common.Common.GetProcedureResult(dbCommand.Parameters);
            if (result.IsSuccess)
            {
                return true;
            }
            else
            {
                throw new Exception(result.ResultMessage);
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.SysWebSetting GetModel(long SysWebSettingID)
        {
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("select * from SysWebSetting where SysWebSettingID=@SysWebSettingID");
            db.AddInParameter(dbCommand, "SysWebSettingID", DbType.Int64, SysWebSettingID);
            DataSet ds = db.ExecuteDataSet(dbCommand);
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
        public XCLCMS.Data.Model.SysWebSetting DataRowToModel(DataRow row)
        {
            XCLCMS.Data.Model.SysWebSetting model = new XCLCMS.Data.Model.SysWebSetting();
            if (row != null)
            {
                if (row["SysWebSettingID"] != null && row["SysWebSettingID"].ToString() != "")
                {
                    model.SysWebSettingID = long.Parse(row["SysWebSettingID"].ToString());
                }
                if (row["KeyName"] != null)
                {
                    model.KeyName = row["KeyName"].ToString();
                }
                if (row["KeyValue"] != null)
                {
                    model.KeyValue = row["KeyValue"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["RecordState"] != null)
                {
                    model.RecordState = row["RecordState"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["CreaterID"] != null && row["CreaterID"].ToString() != "")
                {
                    model.CreaterID = long.Parse(row["CreaterID"].ToString());
                }
                if (row["CreaterName"] != null)
                {
                    model.CreaterName = row["CreaterName"].ToString();
                }
                if (row["UpdateTime"] != null && row["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
                }
                if (row["UpdaterID"] != null && row["UpdaterID"].ToString() != "")
                {
                    model.UpdaterID = long.Parse(row["UpdaterID"].ToString());
                }
                if (row["UpdaterName"] != null)
                {
                    model.UpdaterName = row["UpdaterName"].ToString();
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
            strSql.Append("select SysWebSettingID,KeyName,KeyValue,Remark,RecordState,CreateTime,CreaterID,CreaterName,UpdateTime,UpdaterID,UpdaterName ");
            strSql.Append(" FROM SysWebSetting ");
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
        public List<XCLCMS.Data.Model.SysWebSetting> GetPageList(int pageSize, int pageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            DataTable dt = XCLCMS.Data.DAL.Common.Common.GetPageList("SysWebSetting", pageSize, pageIndex, ref recordCount, strWhere, fieldName, fieldKey, fieldOrder);
            return XCLNetTools.Generic.ListHelper.DataTableToList < XCLCMS.Data.Model.SysWebSetting>(dt) as List<XCLCMS.Data.Model.SysWebSetting>;
        }
        /// <summary>
        /// 判断指定配置名是否存在
        /// </summary>
        public bool IsExistKeyName(string keyName)
        {
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(" select top 1 1 from SysWebSetting where KeyName=@KeyName");
            db.AddInParameter(dbCommand, "KeyName", DbType.AnsiString, keyName);
            return db.ExecuteScalar(dbCommand) != null;
        }
        #endregion  MethodEx
    }
}

