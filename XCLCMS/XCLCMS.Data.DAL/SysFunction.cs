using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using XCLCMS.CodeTool.DBUtility;//Please add references
namespace XCLCMS.Data.DAL
{
    /// <summary>
    /// 数据访问类:SysFunction
    /// </summary>
    public partial class SysFunction
    {
        public SysFunction()
        { }
        #region  Method


        /// <summary>
        ///  增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.SysFunction model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@SysFunctionID", SqlDbType.BigInt,8),
					new SqlParameter("@FunctionName", SqlDbType.VarChar,100),
					new SqlParameter("@FK_TypeID", SqlDbType.BigInt,8),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@RecordState", SqlDbType.Char,1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreaterID", SqlDbType.BigInt,8),
					new SqlParameter("@CreaterName", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdaterID", SqlDbType.BigInt,8),
					new SqlParameter("@UpdaterName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.SysFunctionID;
            parameters[1].Value = model.FunctionName;
            parameters[2].Value = model.FK_TypeID;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.RecordState;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.CreaterID;
            parameters[7].Value = model.CreaterName;
            parameters[8].Value = model.UpdateTime;
            parameters[9].Value = model.UpdaterID;
            parameters[10].Value = model.UpdaterName;

            DbHelperSQL.RunProcedure("SysFunction_ADD", parameters, out rowsAffected);
            return rowsAffected > 0;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(XCLCMS.Data.Model.SysFunction model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@SysFunctionID", SqlDbType.BigInt,8),
					new SqlParameter("@FunctionName", SqlDbType.VarChar,100),
					new SqlParameter("@FK_TypeID", SqlDbType.BigInt,8),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@RecordState", SqlDbType.Char,1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreaterID", SqlDbType.BigInt,8),
					new SqlParameter("@CreaterName", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdaterID", SqlDbType.BigInt,8),
					new SqlParameter("@UpdaterName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.SysFunctionID;
            parameters[1].Value = model.FunctionName;
            parameters[2].Value = model.FK_TypeID;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.RecordState;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.CreaterID;
            parameters[7].Value = model.CreaterName;
            parameters[8].Value = model.UpdateTime;
            parameters[9].Value = model.UpdaterID;
            parameters[10].Value = model.UpdaterName;

            DbHelperSQL.RunProcedure("SysFunction_Update", parameters, out rowsAffected);
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
        public XCLCMS.Data.Model.SysFunction GetModel(long SysFunctionID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@SysFunctionID", SqlDbType.BigInt,8)			};
            parameters[0].Value = SysFunctionID;

            XCLCMS.Data.Model.SysFunction model = new XCLCMS.Data.Model.SysFunction();
            DataSet ds = DbHelperSQL.Query("select * from SysFunction where SysFunctionID=@SysFunctionID", parameters);
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
        public XCLCMS.Data.Model.SysFunction DataRowToModel(DataRow row)
        {
            XCLCMS.Data.Model.SysFunction model = new XCLCMS.Data.Model.SysFunction();
            if (row != null)
            {
                if (row["SysFunctionID"] != null && row["SysFunctionID"].ToString() != "")
                {
                    model.SysFunctionID = long.Parse(row["SysFunctionID"].ToString());
                }
                if (row["FunctionName"] != null)
                {
                    model.FunctionName = row["FunctionName"].ToString();
                }
                if (row["FK_TypeID"] != null && row["FK_TypeID"].ToString() != "")
                {
                    model.FK_TypeID = long.Parse(row["FK_TypeID"].ToString());
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
            strSql.Append("select SysFunctionID,FunctionName,FK_TypeID,Remark,RecordState,CreateTime,CreaterID,CreaterName,UpdateTime,UpdaterID,UpdaterName ");
            strSql.Append(" FROM SysFunction ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
        #region  MethodEx
        /// <summary>
        /// 判断功能名称是否存在
        /// </summary>
        public bool IsExistFunctionName(string functionName)
        {
            string strSql = " select top 1 1 from SysFunction where FunctionName=@FunctionName";
            SqlParameter[] parameters = { 
                                        new SqlParameter("@FunctionName", SqlDbType.VarChar, 100)
                                        };
            parameters[0].Value = functionName;
            return DbHelperSQL.Exists(strSql, parameters);
        }

        /// <summary>
        /// 验证某个用户是否拥有指定功能列表中的某个功能权限
        /// </summary>
        public bool CheckUserHasAnyFunction(long userId, List<long> functionList)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@IsPass", SqlDbType.TinyInt),
                                        new SqlParameter("@UserInfoID",SqlDbType.BigInt),
                                        new SqlParameter("@FunctionListXML",SqlDbType.Xml)
                                        };
            parameters[0].Direction=ParameterDirection.Output;
            parameters[1].Value=userId;
            parameters[2].Value=XCLNetTools.XML.SerializeHelper.Serializer<List<long>>(functionList);

            DbHelperSQL.RunProcedure("proc_CheckUserHasAnyFunction", parameters, "ds");

            return XCLNetTools.StringHander.Common.GetInt(parameters[0].Value) == 1;
        }

        /// <summary>
        /// 获取指定角色的所有功能
        /// </summary>
        /// <param name="sysRoleID">角色ID</param>
        public DataTable GetListByRoleID(long sysRoleID)
        {
            string strSql = @"WITH Info1 AS (
	                                    SELECT DISTINCT a.FK_SysFunctionID FROM dbo.SysRoleFunction AS a WHERE RecordState='N' AND FK_SysRoleID=@SysRoleID
                                    )
                                    SELECT
                                    a.*
                                    FROM dbo.SysFunction AS a
                                    INNER JOIN Info1 AS b ON a.SysFunctionID=b.FK_SysFunctionID AND a.RecordState='N'
                                    ";
            SqlParameter[] parameters = { 
                                        new SqlParameter("@SysRoleID", SqlDbType.BigInt)
                                        };
            parameters[0].Value = sysRoleID;
            DataSet ds = DbHelperSQL.Query(strSql, parameters);
            return null != ds && ds.Tables.Count > 0 ? ds.Tables[0] : null;
        }
        #endregion  MethodEx
    }
}

