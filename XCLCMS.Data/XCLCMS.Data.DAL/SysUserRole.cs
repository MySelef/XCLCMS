using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using XCLCMS.Data.DBUtility;//Please add references
namespace XCLCMS.Data.DAL
{
    /// <summary>
    /// 数据访问类:SysUserRole
    /// </summary>
    public partial class SysUserRole
    {
        public SysUserRole()
        { }
        #region  Method

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.SysUserRole model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@FK_UserInfoID", SqlDbType.BigInt,8),
					new SqlParameter("@FK_SysRoleID", SqlDbType.BigInt,8),
					new SqlParameter("@RecordState", SqlDbType.Char,1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreaterID", SqlDbType.BigInt,8),
					new SqlParameter("@CreaterName", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdaterID", SqlDbType.BigInt,8),
					new SqlParameter("@UpdaterName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.FK_UserInfoID;
            parameters[1].Value = model.FK_SysRoleID;
            parameters[2].Value = model.RecordState;
            parameters[3].Value = model.CreateTime;
            parameters[4].Value = model.CreaterID;
            parameters[5].Value = model.CreaterName;
            parameters[6].Value = model.UpdateTime;
            parameters[7].Value = model.UpdaterID;
            parameters[8].Value = model.UpdaterName;

            DbHelperSQL.RunProcedure("SysUserRole_ADD", parameters, out rowsAffected);
            return rowsAffected > 0;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(XCLCMS.Data.Model.SysUserRole model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@FK_UserInfoID", SqlDbType.BigInt,8),
					new SqlParameter("@FK_SysRoleID", SqlDbType.BigInt,8),
					new SqlParameter("@RecordState", SqlDbType.Char,1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreaterID", SqlDbType.BigInt,8),
					new SqlParameter("@CreaterName", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdaterID", SqlDbType.BigInt,8),
					new SqlParameter("@UpdaterName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.FK_UserInfoID;
            parameters[1].Value = model.FK_SysRoleID;
            parameters[2].Value = model.RecordState;
            parameters[3].Value = model.CreateTime;
            parameters[4].Value = model.CreaterID;
            parameters[5].Value = model.CreaterName;
            parameters[6].Value = model.UpdateTime;
            parameters[7].Value = model.UpdaterID;
            parameters[8].Value = model.UpdaterName;

            DbHelperSQL.RunProcedure("SysUserRole_Update", parameters, out rowsAffected);
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
        public XCLCMS.Data.Model.SysUserRole GetModel(long FK_UserInfoID, long FK_SysRoleID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@FK_UserInfoID", SqlDbType.BigInt,8),
					new SqlParameter("@FK_SysRoleID", SqlDbType.BigInt,8)			};
            parameters[0].Value = FK_UserInfoID;
            parameters[1].Value = FK_SysRoleID;

            XCLCMS.Data.Model.SysUserRole model = new XCLCMS.Data.Model.SysUserRole();
            DataSet ds = DbHelperSQL.RunProcedure("SysUserRole_GetModel", parameters, "ds");
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
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

