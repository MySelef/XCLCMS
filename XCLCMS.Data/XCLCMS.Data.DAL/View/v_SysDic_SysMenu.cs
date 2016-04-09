using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace XCLCMS.Data.DAL.View
{
    /// <summary>
    /// 数据访问类:v_SysDic_SysMenu
    /// </summary>
    public partial class v_SysDic_SysMenu : XCLCMS.Data.DAL.Common.BaseDAL
    {
        public v_SysDic_SysMenu()
        { }

        #region Method

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
            var lst = XCLNetTools.Generic.ListHelper.DataSetToList<XCLCMS.Data.Model.View.v_SysDic_SysMenu>(ds);
            return null != lst && lst.Count > 0 ? lst[0] : null;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysDic_SysMenu> GetModelList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM v_SysDic_SysMenu ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            var ds = db.ExecuteDataSet(dbCommand);
            return XCLNetTools.Generic.ListHelper.DataSetToList<XCLCMS.Data.Model.View.v_SysDic_SysMenu>(ds) as List<XCLCMS.Data.Model.View.v_SysDic_SysMenu>;
        }

        #endregion Method
    }
}