using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using XCLCMS.Data.DBUtility;
namespace XCLCMS.Data.DAL
{
    /// <summary>
    /// 数据访问类:SysWebSetting
    /// </summary>
    public partial class SysWebSetting
    {
        public SysWebSetting()
        { }
        #region  Method


        /// <summary>
        ///  增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.SysWebSetting model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@SysWebSettingID", SqlDbType.BigInt,8),
					new SqlParameter("@KeyName", SqlDbType.VarChar,100),
					new SqlParameter("@KeyValue", SqlDbType.VarChar,2000),
					new SqlParameter("@Remark", SqlDbType.VarChar,1000),
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
            parameters[0].Value = model.SysWebSettingID;
            parameters[1].Value = model.KeyName;
            parameters[2].Value = model.KeyValue;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.RecordState;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.CreaterID;
            parameters[7].Value = model.CreaterName;
            parameters[8].Value = model.UpdateTime;
            parameters[9].Value = model.UpdaterID;
            parameters[10].Value = model.UpdaterName;

            parameters[11].Direction = ParameterDirection.Output;
            parameters[12].Direction = ParameterDirection.Output;

            DbHelperSQL.RunProcedure("sp_SysWebSetting_ADD", parameters, "ds");

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
        public bool Update(XCLCMS.Data.Model.SysWebSetting model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@SysWebSettingID", SqlDbType.BigInt,8),
					new SqlParameter("@KeyName", SqlDbType.VarChar,100),
					new SqlParameter("@KeyValue", SqlDbType.VarChar,2000),
					new SqlParameter("@Remark", SqlDbType.VarChar,1000),
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
            parameters[0].Value = model.SysWebSettingID;
            parameters[1].Value = model.KeyName;
            parameters[2].Value = model.KeyValue;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.RecordState;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.CreaterID;
            parameters[7].Value = model.CreaterName;
            parameters[8].Value = model.UpdateTime;
            parameters[9].Value = model.UpdaterID;
            parameters[10].Value = model.UpdaterName;

            parameters[11].Direction = ParameterDirection.Output;
            parameters[12].Direction = ParameterDirection.Output;

            DbHelperSQL.RunProcedure("sp_SysWebSetting_Update", parameters, "ds");

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
        public XCLCMS.Data.Model.SysWebSetting GetModel(long SysWebSettingID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@SysWebSettingID", SqlDbType.BigInt,8)			};
            parameters[0].Value = SysWebSettingID;

            XCLCMS.Data.Model.SysWebSetting model = new XCLCMS.Data.Model.SysWebSetting();
            DataSet ds = DbHelperSQL.Query("select * from SysWebSetting where SysWebSettingID=@SysWebSettingID", parameters);
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
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
        #region  MethodEx
        /// <summary>
        /// 分页数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.SysWebSetting> GetPageList(int pageSize, int pageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            DataTable dt = XCLCMS.Data.DAL.CommonDAL.CommonDALHelper.GetPageList("SysWebSetting", pageSize, pageIndex, ref recordCount, strWhere, fieldName, fieldKey, fieldOrder);
            return XCLNetTools.Generic.ListHelper<XCLCMS.Data.Model.SysWebSetting>.DataTableToList(dt) as List<XCLCMS.Data.Model.SysWebSetting>;
        }
        /// <summary>
        /// 判断指定配置名是否存在
        /// </summary>
        public bool IsExistKeyName(string keyName)
        {
            string strSql = " select top 1 1 from SysWebSetting where KeyName=@KeyName";
            SqlParameter[] parameters = { 
                                        new SqlParameter("@KeyName", SqlDbType.VarChar, 100)
                                        };
            parameters[0].Value = keyName;
            return DbHelperSQL.Exists(strSql, parameters);
        }
        #endregion  MethodEx
    }
}

