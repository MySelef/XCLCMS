using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XCLCMS.Data.DBUtility;
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
                if (row["NodeLevel"] != null && row["NodeLevel"].ToString() != "")
                {
                    model.NodeLevel = int.Parse(row["NodeLevel"].ToString());
                }
                if (row["IsLeaf"] != null && row["IsLeaf"].ToString() != "")
                {
                    model.IsLeaf = int.Parse(row["IsLeaf"].ToString());
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
            strSql.Append("select SysFunctionID,ParentID,FunctionName,Code,Remark,RecordState,CreateTime,CreaterID,CreaterName,UpdateTime,UpdaterID,UpdaterName,NodeLevel,IsLeaf ");
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

        /// <summary>
        /// 根据parentID返回列表
        /// </summary>
        public DataTable GetList(long parentID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.BigInt,8)			};
            parameters[0].Value = parentID;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from v_SysFunction where ParentID=@ParentID");
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return null != ds && ds.Tables.Count > 0 ? ds.Tables[0] : null;
        }
        #endregion  MethodEx
    }
}

