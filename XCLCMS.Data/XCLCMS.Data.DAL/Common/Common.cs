using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;
using System.Data.Common;

namespace XCLCMS.Data.DAL.Common
{
    /// <summary>
    /// DAL层公共方法
    /// </summary>
    public class Common
    {
        /// <summary>
        /// 分页(可按非主键排序)
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="pageSize">每页最多显示的条数</param>
        /// <param name="pageIndex">当前为第几页 1为第1页</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="strWhere"> 查询条件 (注意: 不要加 where)</param>
        /// <param name="fieldName">列名，若为空，则取所有列</param>
        ///<param name="fieldKey">主键名</param>
        ///<param name="fieldOrder">排序字段，可加DESC/ASC</param>
        /// <returns>DataTable</returns>
        public static DataTable GetPageList(string tableName, int pageSize, int pageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            Database db = new XCLCMS.Data.DAL.Common.BaseDAL().CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Pager");
            db.AddOutParameter(dbCommand, "RecordCount", DbType.Int32, 4);
            db.AddOutParameter(dbCommand, "PageCount", DbType.Int32, 4);

            db.AddInParameter(dbCommand, "PageSize", DbType.Int32, pageSize);
            db.AddInParameter(dbCommand, "PageCurrent", DbType.Int32, pageIndex);
            db.AddInParameter(dbCommand, "tbname", DbType.String, tableName);
            db.AddInParameter(dbCommand, "FieldShow", DbType.String, fieldName);
            db.AddInParameter(dbCommand, "Where", DbType.String, strWhere);
            db.AddInParameter(dbCommand, "FieldOrder", DbType.String, fieldOrder);
            db.AddInParameter(dbCommand, "FieldKey", DbType.String, fieldKey);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            int.TryParse(Convert.ToString(dbCommand.Parameters["@RecordCount"].Value), out recordCount);
            return null != ds && ds.Tables.Count > 0 ? ds.Tables[0] : null;
        }

        /// <summary>
        /// 垃圾数据清理
        /// </summary>
        public static void ClearRubbishData()
        {
            Database db = new XCLCMS.Data.DAL.Common.BaseDAL().CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_ClearRubbishData");
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// 从存储过程参数中获取存储过程的执行结果
        /// </summary>
        /// <param name="parameters">存储过程参数</param>
        public static XCLCMS.Data.DAL.Entity.ProcedureResultModel GetProcedureResult(DbParameterCollection parameters)
        {
            XCLCMS.Data.DAL.Entity.ProcedureResultModel model = new Entity.ProcedureResultModel();
            model.IsSuccess = true;

            if (null != parameters && parameters.Count > 0)
            {
                if (parameters.Contains("@ResultCode"))
                {
                    model.ResultCode = Int32.Parse(Convert.ToString(parameters["@ResultCode"].Value));
                    model.IsSuccess = (model.ResultCode == 1);
                }
                if (parameters.Contains("@ResultMessage"))
                {
                    model.ResultMessage = Convert.ToString(parameters["@ResultMessage"].Value);
                }
            }

            return model;
        }
    }
}