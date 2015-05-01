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
    /// 数据访问类:UserInfo
    /// </summary>
    public partial class UserInfo : XCLCMS.Data.DAL.Common.BaseDAL
    {
        public UserInfo()
        { }
        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.UserInfo GetModel(long UserInfoID)
        {
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("select * from UserInfo where UserInfoID=@UserInfoID");
            db.AddInParameter(dbCommand, "UserInfoID", DbType.Int64, UserInfoID);
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
        public XCLCMS.Data.Model.UserInfo DataRowToModel(DataRow row)
        {
            XCLCMS.Data.Model.UserInfo model = new XCLCMS.Data.Model.UserInfo();
            if (row != null)
            {
                if (row["UserInfoID"] != null && row["UserInfoID"].ToString() != "")
                {
                    model.UserInfoID = long.Parse(row["UserInfoID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["FK_MerchantID"] != null && row["FK_MerchantID"].ToString() != "")
                {
                    model.FK_MerchantID = long.Parse(row["FK_MerchantID"].ToString());
                }
                if (row["RealName"] != null)
                {
                    model.RealName = row["RealName"].ToString();
                }
                if (row["NickName"] != null)
                {
                    model.NickName = row["NickName"].ToString();
                }
                if (row["Pwd"] != null)
                {
                    model.Pwd = row["Pwd"].ToString();
                }
                if (row["Age"] != null && row["Age"].ToString() != "")
                {
                    model.Age = int.Parse(row["Age"].ToString());
                }
                if (row["SexType"] != null)
                {
                    model.SexType = row["SexType"].ToString();
                }
                if (row["Birthday"] != null && row["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(row["Birthday"].ToString());
                }
                if (row["Tel"] != null)
                {
                    model.Tel = row["Tel"].ToString();
                }
                if (row["QQ"] != null)
                {
                    model.QQ = row["QQ"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["OtherContact"] != null)
                {
                    model.OtherContact = row["OtherContact"].ToString();
                }
                if (row["AccessType"] != null)
                {
                    model.AccessType = row["AccessType"].ToString();
                }
                if (row["AccessToken"] != null)
                {
                    model.AccessToken = row["AccessToken"].ToString();
                }
                if (row["UserState"] != null)
                {
                    model.UserState = row["UserState"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["RoleName"] != null)
                {
                    model.RoleName = row["RoleName"].ToString();
                }
                if (row["RoleMaxWeight"] != null && row["RoleMaxWeight"].ToString() != "")
                {
                    model.RoleMaxWeight = int.Parse(row["RoleMaxWeight"].ToString());
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
            strSql.Append("select * FROM UserInfo ");
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
        public List<XCLCMS.Data.Model.UserInfo>  GetPageList(int pageSize, int pageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            DataTable dt= XCLCMS.Data.DAL.Common.Common.GetPageList("UserInfo", pageSize, pageIndex, ref recordCount, strWhere, fieldName, fieldKey, fieldOrder);
            return XCLNetTools.Generic.ListHelper.DataTableToList < XCLCMS.Data.Model.UserInfo>(dt) as List<XCLCMS.Data.Model.UserInfo>;
        }

        /// <summary>
        /// 判断指定用户名是否存在
        /// </summary>
        public bool IsExistUserName(string userName)
        {
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("select top 1 1 from UserInfo where UserName=@UserName");
            db.AddInParameter(dbCommand, "UserName", DbType.AnsiString, userName);
            return db.ExecuteScalar(dbCommand) != null;
        }

        /// <summary>
        /// 根据用户名和密码获取用户实体
        /// </summary>
        public XCLCMS.Data.Model.UserInfo GetModel(string userName, string pwd)
        {
            XCLCMS.Data.Model.UserInfo model = null;
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("select top 1 * from UserInfo where UserName=@UserName and Pwd=@Pwd");
            db.AddInParameter(dbCommand, "UserName", DbType.AnsiString, userName);
            db.AddInParameter(dbCommand, "Pwd", DbType.AnsiString, pwd);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            if (null != ds && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count>0)
            {
                model = this.DataRowToModel(ds.Tables[0].Rows[0]);
            }
            return model;
        }

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.UserInfo model)
        {
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_UserInfo_ADD");
            db.AddInParameter(dbCommand, "UserInfoID", DbType.Int64, model.UserInfoID);
            db.AddInParameter(dbCommand, "UserName", DbType.AnsiString, model.UserName);
            db.AddInParameter(dbCommand, "FK_MerchantID", DbType.Int64, model.FK_MerchantID);
            db.AddInParameter(dbCommand, "RealName", DbType.String, model.RealName);
            db.AddInParameter(dbCommand, "NickName", DbType.String, model.NickName);
            db.AddInParameter(dbCommand, "Pwd", DbType.AnsiString, model.Pwd);
            db.AddInParameter(dbCommand, "Age", DbType.Int32, model.Age);
            db.AddInParameter(dbCommand, "SexType", DbType.AnsiString, model.SexType);
            db.AddInParameter(dbCommand, "Birthday", DbType.DateTime, model.Birthday);
            db.AddInParameter(dbCommand, "Tel", DbType.AnsiString, model.Tel);
            db.AddInParameter(dbCommand, "QQ", DbType.AnsiString, model.QQ);
            db.AddInParameter(dbCommand, "Email", DbType.AnsiString, model.Email);
            db.AddInParameter(dbCommand, "OtherContact", DbType.String, model.OtherContact);
            db.AddInParameter(dbCommand, "AccessType", DbType.AnsiString, model.AccessType);
            db.AddInParameter(dbCommand, "AccessToken", DbType.AnsiString, model.AccessToken);
            db.AddInParameter(dbCommand, "UserState", DbType.AnsiString, model.UserState);
            db.AddInParameter(dbCommand, "Remark", DbType.String, model.Remark);
            db.AddInParameter(dbCommand, "RoleName", DbType.String, model.RoleName);
            db.AddInParameter(dbCommand, "RoleMaxWeight", DbType.Int32, model.RoleMaxWeight);
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
        public bool Update(XCLCMS.Data.Model.UserInfo model)
        {
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_UserInfo_Update");
            db.AddInParameter(dbCommand, "UserInfoID", DbType.Int64, model.UserInfoID);
            db.AddInParameter(dbCommand, "UserName", DbType.AnsiString, model.UserName);
            db.AddInParameter(dbCommand, "FK_MerchantID", DbType.Int64, model.FK_MerchantID);
            db.AddInParameter(dbCommand, "RealName", DbType.String, model.RealName);
            db.AddInParameter(dbCommand, "NickName", DbType.String, model.NickName);
            db.AddInParameter(dbCommand, "Pwd", DbType.AnsiString, model.Pwd);
            db.AddInParameter(dbCommand, "Age", DbType.Int32, model.Age);
            db.AddInParameter(dbCommand, "SexType", DbType.AnsiString, model.SexType);
            db.AddInParameter(dbCommand, "Birthday", DbType.DateTime, model.Birthday);
            db.AddInParameter(dbCommand, "Tel", DbType.AnsiString, model.Tel);
            db.AddInParameter(dbCommand, "QQ", DbType.AnsiString, model.QQ);
            db.AddInParameter(dbCommand, "Email", DbType.AnsiString, model.Email);
            db.AddInParameter(dbCommand, "OtherContact", DbType.String, model.OtherContact);
            db.AddInParameter(dbCommand, "AccessType", DbType.AnsiString, model.AccessType);
            db.AddInParameter(dbCommand, "AccessToken", DbType.AnsiString, model.AccessToken);
            db.AddInParameter(dbCommand, "UserState", DbType.AnsiString, model.UserState);
            db.AddInParameter(dbCommand, "Remark", DbType.String, model.Remark);
            db.AddInParameter(dbCommand, "RoleName", DbType.String, model.RoleName);
            db.AddInParameter(dbCommand, "RoleMaxWeight", DbType.Int32, model.RoleMaxWeight);
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
        #endregion  MethodEx
    }
}

