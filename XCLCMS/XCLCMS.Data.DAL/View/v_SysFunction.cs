using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XCLCMS.CodeTool.DBUtility;
using System.Collections.Generic;//Please add references
namespace XCLCMS.Data.DAL.View
{
    /// <summary>
    /// 数据访问类:v_SysFunction
    /// </summary>
    public partial class v_SysFunction
    {
        public v_SysFunction()
        { }
        #region  Method

         /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.View.v_SysFunction GetModel(long SysFunctionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from v_SysFunction ");
            strSql.Append(" where SysFunctionID=@SysFunctionID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SysFunctionID", SqlDbType.BigInt,8)			};
            parameters[0].Value = SysFunctionID;

            XCLCMS.Data.Model.View.v_SysFunction model = new XCLCMS.Data.Model.View.v_SysFunction();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
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
        public XCLCMS.Data.Model.View.v_SysFunction DataRowToModel(DataRow row)
        {
            XCLCMS.Data.Model.View.v_SysFunction model = new XCLCMS.Data.Model.View.v_SysFunction();
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
                if (row["C_TypeName"] != null)
                {
                    model.C_TypeName = row["C_TypeName"].ToString();
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
            strSql.Append("select SysFunctionID,FunctionName,FK_TypeID,Remark,RecordState,CreateTime,CreaterID,CreaterName,UpdateTime,UpdaterID,UpdaterName,C_TypeName ");
            strSql.Append(" FROM v_SysFunction ");
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
        public List<XCLCMS.Data.Model.View.v_SysFunction> GetPageList(int pageSize, int pageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            DataTable dt = XCLCMS.Data.DAL.CommonDAL.CommonDALHelper.GetPageList("v_SysFunction", pageSize, pageIndex, ref recordCount, strWhere, fieldName, fieldKey, fieldOrder);
            return XCLNetTools.Generic.ListHelper<XCLCMS.Data.Model.View.v_SysFunction>.DataTableToList(dt) as List<XCLCMS.Data.Model.View.v_SysFunction>;
        }
        #endregion  MethodEx
    }
}

