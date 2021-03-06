﻿using Microsoft.Practices.EnterpriseLibrary.Data;
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
        /// 分页
        /// </summary>
        public static DataTable GetPageList(XCLNetTools.Entity.PagerInfo pageInfo, XCLNetTools.Entity.SqlPagerConditionEntity condition)
        {
            condition.PageIndex = pageInfo.PageIndex;
            condition.PageSize = pageInfo.PageSize;

            var db = new XCLCMS.Data.DAL.Common.BaseDAL().CreateDatabase();
            string strSql = XCLNetTools.DataBase.SQLLibrary.CreatePagerQuerySqlString(condition);
            var dbCommand = db.GetSqlStringCommand(strSql);
            db.AddOutParameter(dbCommand, "TotalCount", DbType.Int32, 4);

            var ds = db.ExecuteDataSet(dbCommand);
            pageInfo.RecordCount = XCLNetTools.Common.DataTypeConvert.ToInt(dbCommand.Parameters["@TotalCount"].Value);
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
        public static XCLCMS.Data.Model.Custom.ProcedureResultModel GetProcedureResult(DbParameterCollection parameters)
        {
            XCLCMS.Data.Model.Custom.ProcedureResultModel model = new XCLCMS.Data.Model.Custom.ProcedureResultModel();
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