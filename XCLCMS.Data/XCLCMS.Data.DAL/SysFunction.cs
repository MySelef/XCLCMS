using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using XCLCMS.Data.DBUtility;//Please add references
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
            SqlParameter[] parameters = {
					new SqlParameter("@SysFunctionID", SqlDbType.BigInt,8),
					new SqlParameter("@ParentID", SqlDbType.BigInt,8),
					new SqlParameter("@FunctionName", SqlDbType.VarChar,100),
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@RecordState", SqlDbType.Char,1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreaterID", SqlDbType.BigInt,8),
					new SqlParameter("@CreaterName", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdaterID", SqlDbType.BigInt,8),
					new SqlParameter("@UpdaterName", SqlDbType.NVarChar,50),
                                        
                    new SqlParameter("@ResultCode", SqlDbType.Int,4),
                    new SqlParameter("@ResultMessage", SqlDbType.NVarChar,1000)
                                        };
            parameters[0].Value = model.SysFunctionID;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.FunctionName;
            parameters[3].Value = model.Code;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.RecordState;
            parameters[6].Value = model.CreateTime;
            parameters[7].Value = model.CreaterID;
            parameters[8].Value = model.CreaterName;
            parameters[9].Value = model.UpdateTime;
            parameters[10].Value = model.UpdaterID;
            parameters[11].Value = model.UpdaterName;

            parameters[12].Direction = ParameterDirection.Output;
            parameters[13].Direction = ParameterDirection.Output;

            DbHelperSQL.RunProcedure("sp_SysFunction_ADD", parameters, "ds");

            var result = XCLCMS.Data.DAL.CommonDAL.CommonDALHelper.GetProcedureResult(parameters);
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
        public bool Update(XCLCMS.Data.Model.SysFunction model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@SysFunctionID", SqlDbType.BigInt,8),
					new SqlParameter("@ParentID", SqlDbType.BigInt,8),
					new SqlParameter("@FunctionName", SqlDbType.VarChar,100),
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@RecordState", SqlDbType.Char,1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreaterID", SqlDbType.BigInt,8),
					new SqlParameter("@CreaterName", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdaterID", SqlDbType.BigInt,8),
					new SqlParameter("@UpdaterName", SqlDbType.NVarChar,50),
                                        
                    new SqlParameter("@ResultCode", SqlDbType.Int,4),
                    new SqlParameter("@ResultMessage", SqlDbType.NVarChar,1000)
                                        };
            parameters[0].Value = model.SysFunctionID;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.FunctionName;
            parameters[3].Value = model.Code;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.RecordState;
            parameters[6].Value = model.CreateTime;
            parameters[7].Value = model.CreaterID;
            parameters[8].Value = model.CreaterName;
            parameters[9].Value = model.UpdateTime;
            parameters[10].Value = model.UpdaterID;
            parameters[11].Value = model.UpdaterName;

            parameters[12].Direction = ParameterDirection.Output;
            parameters[13].Direction = ParameterDirection.Output;

            DbHelperSQL.RunProcedure("sp_SysFunction_Update", parameters, "ds");

            var result = XCLCMS.Data.DAL.CommonDAL.CommonDALHelper.GetProcedureResult(parameters);
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
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = long.Parse(row["ParentID"].ToString());
                }
                if (row["FunctionName"] != null)
                {
                    model.FunctionName = row["FunctionName"].ToString();
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
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
            strSql.Append("select SysFunctionID,ParentID,FunctionName,Code,Remark,RecordState,CreateTime,CreaterID,CreaterName,UpdateTime,UpdaterID,UpdaterName ");
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
        /// 判断功能标识是否存在
        /// </summary>
        public bool IsExistCode(string code)
        {
            string strSql = " select top 1 1 from SysFunction where Code=@Code";
            SqlParameter[] parameters = { 
                                        new SqlParameter("@Code", SqlDbType.VarChar, 50)
                                        };
            parameters[0].Value = code;
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

            DbHelperSQL.RunProcedure("sp_CheckUserHasAnyFunction", parameters, "ds");

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

        /// <summary>
        /// 获取指定SysFunctionID所属的层级list
        /// </summary>
        public DataTable GetLayerListBySysFunctionID(long sysFunctionID)
        {
            string str = string.Format("select * from fun_SysFunction_GetLayerListByID({0})", sysFunctionID);
            DataSet ds = DbHelperSQL.Query(str);
            DataTable dt = null;
            if (null != ds && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 删除指定SysFunctionID下面的子节点
        /// </summary>
        public bool DelChild(XCLCMS.Data.Model.SysFunction model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@SysFunctionID", SqlDbType.BigInt,8),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdaterID", SqlDbType.BigInt,8),
					new SqlParameter("@UpdaterName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.SysFunctionID;
            parameters[1].Value = model.UpdateTime;
            parameters[2].Value = model.UpdaterID;
            parameters[3].Value = model.UpdaterName;
            string strSql = string.Format("update SysFunction set RecordState='{0}',UpdateTime=@UpdateTime,UpdaterID=@UpdaterID,UpdaterName=@UpdaterName where ParentID=@SysFunctionID and RecordState='{1}' and ParentID>0",
                                    XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.D.ToString(), XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString());
            return DbHelperSQL.ExecuteSql(strSql, parameters) > 0;
        }

        /// <summary>
        /// 根据SysFunctionID查询其子项
        /// </summary>
        public DataTable GetChildListByID(long sysFunctionID)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter param = null;
            List<SqlParameter> ps = new List<SqlParameter>();

            strSql.Append(@"SELECT
                                        a.*
                                        FROM dbo.SysFunction AS a
                                        where ParentID=@ParentID and RecordState='N'
                                        ");
            param = new SqlParameter("@ParentID", SqlDbType.BigInt, 8);
            param.Value = sysFunctionID;
            ps.Add(param);

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), ps.ToArray());
            return null != ds && ds.Tables.Count > 0 ? ds.Tables[0] : null;
        }
        #endregion  MethodEx
    }
}

