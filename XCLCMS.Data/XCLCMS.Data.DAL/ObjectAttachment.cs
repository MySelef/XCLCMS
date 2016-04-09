using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace XCLCMS.Data.DAL
{
    /// <summary>
    /// 数据访问类:ObjectAttachment
    /// </summary>
    public partial class ObjectAttachment : XCLCMS.Data.DAL.Common.BaseDAL
    {
        public ObjectAttachment()
        { }

        #region Method

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.ObjectAttachment model)
        {
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_ObjectAttachment_ADD");
            db.AddInParameter(dbCommand, "ObjectType", DbType.AnsiString, model.ObjectType);
            db.AddInParameter(dbCommand, "FK_ObjectID", DbType.Int64, model.FK_ObjectID);
            db.AddInParameter(dbCommand, "FK_AttachmentID", DbType.Int64, model.FK_AttachmentID);
            db.AddInParameter(dbCommand, "RecordState", DbType.AnsiString, model.RecordState);
            db.AddInParameter(dbCommand, "CreateTime", DbType.DateTime, model.CreateTime);
            db.AddInParameter(dbCommand, "CreaterID", DbType.Int64, model.CreaterID);
            db.AddInParameter(dbCommand, "CreaterName", DbType.String, model.CreaterName);
            db.AddInParameter(dbCommand, "UpdateTime", DbType.DateTime, model.UpdateTime);
            db.AddInParameter(dbCommand, "UpdaterID", DbType.Int64, model.UpdaterID);
            db.AddInParameter(dbCommand, "UpdaterName", DbType.String, model.UpdaterName);

            db.AddOutParameter(dbCommand, "ResultCode", DbType.Int32, 4);
            db.AddOutParameter(dbCommand, "ResultMessage", DbType.String, 1000);
            db.ExecuteNonQuery(dbCommand);

            var result = XCLCMS.Data.DAL.Common.Common.GetProcedureResult(dbCommand.Parameters);
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
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.ObjectAttachment> GetModelList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ObjectType,FK_ObjectID,FK_AttachmentID,RecordState,CreateTime,CreaterID,CreaterName,UpdateTime,UpdaterID,UpdaterName ");
            strSql.Append(" FROM ObjectAttachment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = base.CreateDatabase();
            var ds = db.ExecuteDataSet(CommandType.Text, strSql.ToString());
            return XCLNetTools.Generic.ListHelper.DataSetToList<XCLCMS.Data.Model.ObjectAttachment>(ds) as List<XCLCMS.Data.Model.ObjectAttachment>;
        }

        #endregion Method
    }
}