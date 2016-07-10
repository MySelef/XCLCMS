using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace XCLCMS.Data.DAL.View
{
    /// <summary>
    /// 数据访问类:v_SysRole
    /// </summary>
    public partial class v_SysRole : XCLCMS.Data.DAL.Common.BaseDAL
    {
        public v_SysRole()
        { }

        #region Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.View.v_SysRole GetModel(long SysRoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from v_SysRole  WITH(NOLOCK)  ");
            strSql.Append(" where SysRoleID=@SysRoleID ");
            XCLCMS.Data.Model.View.v_SysRole model = new XCLCMS.Data.Model.View.v_SysRole();
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "SysRoleID", DbType.Int64, SysRoleID);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            var lst = XCLNetTools.Generic.ListHelper.DataSetToList<XCLCMS.Data.Model.View.v_SysRole>(ds);
            return null != lst && lst.Count > 0 ? lst[0] : null;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysRole> GetModelList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM v_SysRole WITH(NOLOCK)   ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = base.CreateDatabase();
            var ds = db.ExecuteDataSet(CommandType.Text, strSql.ToString());
            return XCLNetTools.Generic.ListHelper.DataSetToList<XCLCMS.Data.Model.View.v_SysRole>(ds) as List<XCLCMS.Data.Model.View.v_SysRole>;
        }

        #endregion Method

        #region MethodEx

        /// <summary>
        /// 根据parentID返回列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysRole> GetList(long parentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from v_SysRole  WITH(NOLOCK)  where ParentID=@ParentID order by Weight asc");
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ParentID", DbType.Int64, parentID);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return XCLNetTools.Generic.ListHelper.DataSetToList<XCLCMS.Data.Model.View.v_SysRole>(ds) as List<XCLCMS.Data.Model.View.v_SysRole>;
        }

        /// <summary>
        /// 根据code查询model
        /// </summary>
        public XCLCMS.Data.Model.View.v_SysRole GetModelByCode(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT
                                        top 1
                                        a.*
                                        FROM dbo.v_SysRole AS a WITH(NOLOCK)  
                                        where a.RecordState='N' and a.Code=@Code
                                        ");

            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Code", DbType.AnsiString, code);
            DataSet ds = db.ExecuteDataSet(dbCommand);

            var lst = XCLNetTools.Generic.ListHelper.DataTableToList<XCLCMS.Data.Model.View.v_SysRole>(ds.Tables[0]);
            return null != lst && lst.Count > 0 ? lst[0] : null;
        }

        #endregion MethodEx
    }
}