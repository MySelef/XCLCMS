using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using XCLCMS.Data.DBUtility;//Please add references
namespace XCLCMS.Data.DAL
{
    /// <summary>
    /// 数据访问类:SysDic
    /// </summary>
    public partial class SysDic
    {
        public SysDic()
        { }
        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.SysDic GetModel(long SysDicID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@SysDicID", SqlDbType.BigInt,8)			};
            parameters[0].Value = SysDicID;

            XCLCMS.Data.Model.SysDic model = new XCLCMS.Data.Model.SysDic();
            DataSet ds = DbHelperSQL.Query("select * from SysDic where SysDicID=@SysDicID", parameters);
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
        public XCLCMS.Data.Model.SysDic DataRowToModel(DataRow row)
        {
            XCLCMS.Data.Model.SysDic model = new XCLCMS.Data.Model.SysDic();
            if (row != null)
            {
                if (row["SysDicID"] != null && row["SysDicID"].ToString() != "")
                {
                    model.SysDicID = long.Parse(row["SysDicID"].ToString());
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["DicType"] != null)
                {
                    model.DicType = row["DicType"].ToString();
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = long.Parse(row["ParentID"].ToString());
                }
                if (row["DicName"] != null)
                {
                    model.DicName = row["DicName"].ToString();
                }
                if (row["DicValue"] != null)
                {
                    model.DicValue = row["DicValue"].ToString();
                }
                if (row["Sort"] != null && row["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(row["Sort"].ToString());
                }
                if (row["Weight"] != null && row["Weight"].ToString() != "")
                {
                    model.Weight = int.Parse(row["Weight"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["FK_FunctionID"] != null && row["FK_FunctionID"].ToString() != "")
                {
                    model.FK_FunctionID = long.Parse(row["FK_FunctionID"].ToString());
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
            strSql.Append("select SysDicID,Code,DicType,ParentID,DicName,DicValue,Sort,Weight,Remark,FK_FunctionID,RecordState,CreateTime,CreaterID,CreaterName,UpdateTime,UpdaterID,UpdaterName ");
            strSql.Append(" FROM SysDic ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
        #region  MethodEx

        /// <summary>
        /// 获取指定sysDicID所属的层级list
        /// </summary>
        public DataTable GetLayerListBySysDicID(long sysDicID)
        {
            string str = string.Format("select * from fun_SysDic_GetLayerListByID({0})", sysDicID);
            DataSet ds = DbHelperSQL.Query(str);
            DataTable dt = null;
            if (null != ds && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 判断指定唯一标识是否存在
        /// </summary>
        public bool IsExistCode(string code)
        {
            string strSql = " select top 1 1 from SysDic where Code=@Code";
            SqlParameter[] parameters = { 
                                        new SqlParameter("@Code", SqlDbType.VarChar, 50)
                                        };
            parameters[0].Value = code;
            return DbHelperSQL.Exists(strSql, parameters);
        }

        /// <summary>
        /// 删除指定sysDicID下面的子节点
        /// </summary>
        public bool DelChild(XCLCMS.Data.Model.SysDic model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@SysDicID", SqlDbType.BigInt,8),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdaterID", SqlDbType.BigInt,8),
					new SqlParameter("@UpdaterName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.SysDicID;
            parameters[1].Value = model.UpdateTime;
            parameters[2].Value = model.UpdaterID;
            parameters[3].Value = model.UpdaterName;
            string strSql = string.Format("update SysDic set RecordState='{0}',UpdateTime=@UpdateTime,UpdaterID=@UpdaterID,UpdaterName=@UpdaterName where ParentID=@SysDicID and RecordState='{1}' and DicType<>'{2}'", 
                                    XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.D.ToString(), XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString(),XCLCMS.Data.CommonHelper.EnumType.DicTypeEnum.S.ToString());
            return DbHelperSQL.ExecuteSql(strSql,parameters)>0;
        }

        /// <summary>
        /// 根据code查询其子项
        /// （条件：Code、RecordState）
        /// </summary>
        public DataTable GetChildListByCode(XCLCMS.Data.Model.SysDic model)
        {
            StringBuilder strSql =new StringBuilder();
            SqlParameter param = null;
            List<SqlParameter> ps = new List<SqlParameter>();

            strSql.Append(@"SELECT
                                        b.*
                                        FROM dbo.SysDic AS a
                                        INNER JOIN dbo.SysDic AS b ON a.Code=@Code AND a.SysDicID=b.ParentID
                                        where 1=1 
                                        ");
            param = new SqlParameter("@Code", SqlDbType.VarChar, 50);
            param.Value = model.Code;
            ps.Add(param);

            if (!string.IsNullOrEmpty(model.RecordState))
            {
                strSql.Append(" and b.RecordState=@RecordState");
                param = new SqlParameter("@RecordState", SqlDbType.Char, 1);
                param.Value = model.RecordState;
                ps.Add(param);
            }
            
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), ps.ToArray());
            return null != ds && ds.Tables.Count > 0 ? ds.Tables[0] : null;
        }

        /// <summary>
        /// 根据SysDicID查询其子项
        /// （条件：SysDicID、RecordState）
        /// </summary>
        public DataTable GetChildListByID(XCLCMS.Data.Model.SysDic model)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter param = null;
            List<SqlParameter> ps = new List<SqlParameter>();

            strSql.Append(@"SELECT
                                        a.*
                                        FROM dbo.SysDic AS a
                                        where ParentID=@ParentID
                                        ");
            param = new SqlParameter("@ParentID", SqlDbType.BigInt, 8);
            param.Value = model.SysDicID;
            ps.Add(param);

            if (!string.IsNullOrEmpty(model.RecordState))
            {
                strSql.Append(" and RecordState=@RecordState");
                param = new SqlParameter("@RecordState", SqlDbType.Char, 1);
                param.Value = model.RecordState;
                ps.Add(param);
            }

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), ps.ToArray());
            return null != ds && ds.Tables.Count > 0 ? ds.Tables[0] : null;
        }

         /// <summary>
        ///  增加一条数据(带其它信息)
        /// </summary>
        public bool Add(XCLCMS.Data.Model.Custom.SysDicWithMore model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@SysDicID", SqlDbType.BigInt,8),
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@DicType", SqlDbType.Char,1),
					new SqlParameter("@ParentID", SqlDbType.BigInt,8),
					new SqlParameter("@DicName", SqlDbType.VarChar,200),
					new SqlParameter("@DicValue", SqlDbType.VarChar,1000),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Weight", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,1000),
                    new SqlParameter("@FK_FunctionID", SqlDbType.BigInt,8),
					new SqlParameter("@RecordState", SqlDbType.Char,1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreaterID", SqlDbType.BigInt,8),
					new SqlParameter("@CreaterName", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdaterID", SqlDbType.BigInt,8),
					new SqlParameter("@UpdaterName", SqlDbType.NVarChar,50),

                    new SqlParameter("@RoleFunctionXML",SqlDbType.Xml),//角色的功能
                    new SqlParameter("@WithMoreState",SqlDbType.Int)//存储过程功能分组状态位
                                        
                                        };
            parameters[0].Value = model.SysDic.SysDicID;
            parameters[1].Value = model.SysDic.Code;
            parameters[2].Value = model.SysDic.DicType;
            parameters[3].Value = model.SysDic.ParentID;
            parameters[4].Value = model.SysDic.DicName;
            parameters[5].Value = model.SysDic.DicValue;
            parameters[6].Value = model.SysDic.Sort;
            parameters[7].Value = model.SysDic.Weight;
            parameters[8].Value = model.SysDic.Remark;
            parameters[9].Value = model.SysDic.FK_FunctionID;
            parameters[10].Value = model.SysDic.RecordState;
            parameters[11].Value = model.SysDic.CreateTime;
            parameters[12].Value = model.SysDic.CreaterID;
            parameters[13].Value = model.SysDic.CreaterName;
            parameters[14].Value = model.SysDic.UpdateTime;
            parameters[15].Value = model.SysDic.UpdaterID;
            parameters[16].Value = model.SysDic.UpdaterName;

            //角色的功能处理
            string functionXML = string.Empty;
            if (null != model.RoleFunctionList && model.RoleFunctionList.Count > 0)
            {
                functionXML = XCLNetTools.XML.SerializeHelper.Serializer<List<long>>(model.RoleFunctionList);
            }
            parameters[17].Value = functionXML;
            parameters[18].Value = model.WithMoreState;

            DbHelperSQL.RunProcedure("SysDic_ADD", parameters, out rowsAffected);
            return rowsAffected > 0;
        }

        /// <summary>
        ///  更新一条数据(带其它信息)
        /// </summary>
        public bool Update(XCLCMS.Data.Model.Custom.SysDicWithMore model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@SysDicID", SqlDbType.BigInt,8),
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@DicType", SqlDbType.Char,1),
					new SqlParameter("@ParentID", SqlDbType.BigInt,8),
					new SqlParameter("@DicName", SqlDbType.VarChar,200),
					new SqlParameter("@DicValue", SqlDbType.VarChar,1000),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Weight", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,1000),
                    new SqlParameter("@FK_FunctionID", SqlDbType.BigInt,8),
					new SqlParameter("@RecordState", SqlDbType.Char,1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreaterID", SqlDbType.BigInt,8),
					new SqlParameter("@CreaterName", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdaterID", SqlDbType.BigInt,8),
					new SqlParameter("@UpdaterName", SqlDbType.NVarChar,50),

                    new SqlParameter("@RoleFunctionXML",SqlDbType.Xml),//角色的功能
                    new SqlParameter("@WithMoreState",SqlDbType.Int)//存储过程功能分组状态位                                        
                                        };
            parameters[0].Value = model.SysDic.SysDicID;
            parameters[1].Value = model.SysDic.Code;
            parameters[2].Value = model.SysDic.DicType;
            parameters[3].Value = model.SysDic.ParentID;
            parameters[4].Value = model.SysDic.DicName;
            parameters[5].Value = model.SysDic.DicValue;
            parameters[6].Value = model.SysDic.Sort;
            parameters[7].Value = model.SysDic.Weight;
            parameters[8].Value = model.SysDic.Remark;
            parameters[9].Value = model.SysDic.FK_FunctionID;
            parameters[10].Value = model.SysDic.RecordState;
            parameters[11].Value = model.SysDic.CreateTime;
            parameters[12].Value = model.SysDic.CreaterID;
            parameters[13].Value = model.SysDic.CreaterName;
            parameters[14].Value = model.SysDic.UpdateTime;
            parameters[15].Value = model.SysDic.UpdaterID;
            parameters[16].Value = model.SysDic.UpdaterName;

            //角色的功能处理
            string functionXML = string.Empty;
            if (null != model.RoleFunctionList && model.RoleFunctionList.Count > 0)
            {
                functionXML = XCLNetTools.XML.SerializeHelper.Serializer<List<long>>(model.RoleFunctionList);
            }
            parameters[17].Value = functionXML;
            parameters[18].Value = model.WithMoreState;

            DbHelperSQL.RunProcedure("SysDic_Update", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  MethodEx
    }
}

