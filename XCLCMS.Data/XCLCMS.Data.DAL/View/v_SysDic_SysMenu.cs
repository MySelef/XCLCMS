using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;

namespace XCLCMS.Data.DAL.View
{
    /// <summary>
    /// 数据访问类:v_SysDic_SysMenu
    /// </summary>
    public partial class v_SysDic_SysMenu:BaseDAL
    {
        public v_SysDic_SysMenu()
        { }
        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.View.v_SysDic_SysMenu GetModel(long SysDicID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from v_SysDic_SysMenu ");
            strSql.Append(" where SysDicID=@SysDicID ");
            XCLCMS.Data.Model.View.v_SysDic_SysMenu model = new XCLCMS.Data.Model.View.v_SysDic_SysMenu();
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "SysDicID", DbType.Int64, SysDicID);
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
        public XCLCMS.Data.Model.View.v_SysDic_SysMenu DataRowToModel(DataRow row)
        {
            XCLCMS.Data.Model.View.v_SysDic_SysMenu model = new XCLCMS.Data.Model.View.v_SysDic_SysMenu();
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
            strSql.Append("select SysDicID,Code,DicType,ParentID,DicName,DicValue,Sort,Weight,Remark,FK_FunctionID,RecordState,CreateTime,CreaterID,CreaterName,UpdateTime,UpdaterID,UpdaterName,NodeLevel,IsLeaf ");
            strSql.Append(" FROM v_SysDic_SysMenu ");
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

        #endregion  MethodEx
    }
}

