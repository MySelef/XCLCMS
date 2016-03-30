using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;
using System.Data.Common;
using System.Text;

namespace XCLCMS.Data.DAL
{
    /// <summary>
    /// 数据访问类:Attachment
    /// </summary>
    public partial class Attachment : XCLCMS.Data.DAL.Common.BaseDAL
    {
        public Attachment()
        { }

        #region Method

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.Attachment model)
        {
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Attachment_ADD");
            db.AddInParameter(dbCommand, "AttachmentID", DbType.Int64, model.AttachmentID);
            db.AddInParameter(dbCommand, "ParentID", DbType.Int64, model.ParentID);
            db.AddInParameter(dbCommand, "Title", DbType.String, model.Title);
            db.AddInParameter(dbCommand, "ViewType", DbType.AnsiString, model.ViewType);
            db.AddInParameter(dbCommand, "FormatType", DbType.AnsiString, model.FormatType);
            db.AddInParameter(dbCommand, "Ext", DbType.AnsiString, model.Ext);
            db.AddInParameter(dbCommand, "URL", DbType.AnsiString, model.URL);
            db.AddInParameter(dbCommand, "Description", DbType.String, model.Description);
            db.AddInParameter(dbCommand, "DownLoadCount", DbType.Int32, model.DownLoadCount);
            db.AddInParameter(dbCommand, "ViewCount", DbType.Int32, model.ViewCount);
            db.AddInParameter(dbCommand, "FileSize", DbType.Decimal, model.FileSize);
            db.AddInParameter(dbCommand, "ImgWidth", DbType.Int32, model.ImgWidth);
            db.AddInParameter(dbCommand, "ImgHeight", DbType.Int32, model.ImgHeight);
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
        ///  更新一条数据
        /// </summary>
        public bool Update(XCLCMS.Data.Model.Attachment model)
        {
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Attachment_Update");
            db.AddInParameter(dbCommand, "AttachmentID", DbType.Int64, model.AttachmentID);
            db.AddInParameter(dbCommand, "ParentID", DbType.Int64, model.ParentID);
            db.AddInParameter(dbCommand, "Title", DbType.String, model.Title);
            db.AddInParameter(dbCommand, "ViewType", DbType.AnsiString, model.ViewType);
            db.AddInParameter(dbCommand, "FormatType", DbType.AnsiString, model.FormatType);
            db.AddInParameter(dbCommand, "Ext", DbType.AnsiString, model.Ext);
            db.AddInParameter(dbCommand, "URL", DbType.AnsiString, model.URL);
            db.AddInParameter(dbCommand, "Description", DbType.String, model.Description);
            db.AddInParameter(dbCommand, "DownLoadCount", DbType.Int32, model.DownLoadCount);
            db.AddInParameter(dbCommand, "ViewCount", DbType.Int32, model.ViewCount);
            db.AddInParameter(dbCommand, "FileSize", DbType.Decimal, model.FileSize);
            db.AddInParameter(dbCommand, "ImgWidth", DbType.Int32, model.ImgWidth);
            db.AddInParameter(dbCommand, "ImgHeight", DbType.Int32, model.ImgHeight);
            db.AddInParameter(dbCommand, "RecordState", DbType.AnsiString, model.RecordState);
            db.AddInParameter(dbCommand, "CreateTime", DbType.DateTime, model.CreateTime);
            db.AddInParameter(dbCommand, "CreaterID", DbType.Int64, model.CreaterID);
            db.AddInParameter(dbCommand, "CreaterName", DbType.String, model.CreaterName);
            db.AddInParameter(dbCommand, "UpdateTime", DbType.DateTime, model.UpdateTime);
            db.AddInParameter(dbCommand, "UpdaterID", DbType.Int64, model.UpdaterID);
            db.AddInParameter(dbCommand, "UpdaterName", DbType.String, model.UpdaterName);
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
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.Attachment GetModel(long AttachmentID)
        {
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Attachment_GetModel");
            db.AddInParameter(dbCommand, "AttachmentID", DbType.Int64, AttachmentID);
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
        public XCLCMS.Data.Model.Attachment DataRowToModel(DataRow row)
        {
            XCLCMS.Data.Model.Attachment model = new XCLCMS.Data.Model.Attachment();
            if (row != null)
            {
                if (row["AttachmentID"] != null && row["AttachmentID"].ToString() != "")
                {
                    model.AttachmentID = long.Parse(row["AttachmentID"].ToString());
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = long.Parse(row["ParentID"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["ViewType"] != null)
                {
                    model.ViewType = row["ViewType"].ToString();
                }
                if (row["FormatType"] != null)
                {
                    model.FormatType = row["FormatType"].ToString();
                }
                if (row["Ext"] != null)
                {
                    model.Ext = row["Ext"].ToString();
                }
                if (row["URL"] != null)
                {
                    model.URL = row["URL"].ToString();
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["DownLoadCount"] != null && row["DownLoadCount"].ToString() != "")
                {
                    model.DownLoadCount = int.Parse(row["DownLoadCount"].ToString());
                }
                if (row["ViewCount"] != null && row["ViewCount"].ToString() != "")
                {
                    model.ViewCount = int.Parse(row["ViewCount"].ToString());
                }
                if (row["FileSize"] != null && row["FileSize"].ToString() != "")
                {
                    model.FileSize = decimal.Parse(row["FileSize"].ToString());
                }
                if (row["ImgWidth"] != null && row["ImgWidth"].ToString() != "")
                {
                    model.ImgWidth = int.Parse(row["ImgWidth"].ToString());
                }
                if (row["ImgHeight"] != null && row["ImgHeight"].ToString() != "")
                {
                    model.ImgHeight = int.Parse(row["ImgHeight"].ToString());
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
            strSql.Append("select AttachmentID,ParentID,Title,ViewType,FormatType,Ext,URL,Description,DownLoadCount,ViewCount,FileSize,ImgWidth,ImgHeight,RecordState,CreateTime,CreaterID,CreaterName,UpdateTime,UpdaterID,UpdaterName ");
            strSql.Append(" FROM Attachment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = base.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        #endregion Method
    }
}