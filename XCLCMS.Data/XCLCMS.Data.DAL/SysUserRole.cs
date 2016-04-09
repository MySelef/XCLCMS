using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace XCLCMS.Data.DAL
{
    /// <summary>
    /// 数据访问类:SysUserRole
    /// </summary>
    public partial class SysUserRole : XCLCMS.Data.DAL.Common.BaseDAL
    {
        public SysUserRole()
        { }

        #region Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.SysUserRole DataRowToModel(DataRow row)
        {
            XCLCMS.Data.Model.SysUserRole model = new XCLCMS.Data.Model.SysUserRole();
            if (row != null)
            {
                if (row["FK_UserInfoID"] != null && row["FK_UserInfoID"].ToString() != "")
                {
                    model.FK_UserInfoID = long.Parse(row["FK_UserInfoID"].ToString());
                }
                if (row["FK_SysRoleID"] != null && row["FK_SysRoleID"].ToString() != "")
                {
                    model.FK_SysRoleID = long.Parse(row["FK_SysRoleID"].ToString());
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
            strSql.Append("select FK_UserInfoID,FK_SysRoleID,RecordState,CreateTime,CreaterID,CreaterName,UpdateTime,UpdaterID,UpdaterName ");
            strSql.Append(" FROM SysUserRole ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            return db.ExecuteDataSet(dbCommand);
        }

        #endregion Method

        #region MethodEx

        /// <summary>
        ///  增加一条数据
        ///  注：如果roleIdList为空，则添加model.FK_SysRoleID，否则，则添加roleIdList
        /// </summary>
        public bool Add(XCLCMS.Data.Model.SysUserRole model, List<long> roleIdList = null)
        {
            if (null == roleIdList || roleIdList.Count == 0)
            {
                if (model.FK_SysRoleID > 0)
                {
                    roleIdList = new List<long>() {
                        model.FK_SysRoleID
                    };
                }
            }

            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_SysUserRole_ADD");
            db.AddInParameter(dbCommand, "FK_UserInfoID", DbType.Int64, model.FK_UserInfoID);
            db.AddInParameter(dbCommand, "RecordState", DbType.AnsiString, model.RecordState);
            db.AddInParameter(dbCommand, "CreateTime", DbType.DateTime, model.CreateTime);
            db.AddInParameter(dbCommand, "CreaterID", DbType.Int64, model.CreaterID);
            db.AddInParameter(dbCommand, "CreaterName", DbType.String, model.CreaterName);
            db.AddInParameter(dbCommand, "UpdateTime", DbType.DateTime, model.UpdateTime);
            db.AddInParameter(dbCommand, "UpdaterID", DbType.Int64, model.UpdaterID);
            db.AddInParameter(dbCommand, "UpdaterName", DbType.String, model.UpdaterName);

            dbCommand.Parameters.Add(new SqlParameter("FK_SysRoleIDTable", SqlDbType.Structured)
            {
                Direction = ParameterDirection.Input,
                Value = XCLNetTools.DataSource.DataTableHelper.ToSingleColumnDataTable<long, long>(roleIdList)
            });

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

        #endregion MethodEx
    }
}