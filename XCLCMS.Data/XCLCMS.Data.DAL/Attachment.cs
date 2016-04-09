using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;

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
            db.AddInParameter(dbCommand, "OriginFileName", DbType.AnsiString, model.OriginFileName);
            db.AddInParameter(dbCommand, "FileName", DbType.AnsiString, model.FileName);
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
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Attachment_Update");
            db.AddInParameter(dbCommand, "AttachmentID", DbType.Int64, model.AttachmentID);
            db.AddInParameter(dbCommand, "ParentID", DbType.Int64, model.ParentID);
            db.AddInParameter(dbCommand, "OriginFileName", DbType.AnsiString, model.OriginFileName);
            db.AddInParameter(dbCommand, "FileName", DbType.AnsiString, model.FileName);
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
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.Attachment GetModel(long AttachmentID)
        {
            XCLCMS.Data.Model.Attachment model = new XCLCMS.Data.Model.Attachment();
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("select * from Attachment where AttachmentID=@AttachmentID");
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
                if (row["OriginFileName"] != null)
                {
                    model.OriginFileName = row["OriginFileName"].ToString();
                }
                if (row["FileName"] != null)
                {
                    model.FileName = row["FileName"].ToString();
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
            strSql.Append("select *  FROM Attachment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = base.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        #endregion Method

        #region MethodEx

        /// <summary>
        /// 分页数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.Attachment> GetPageList(XCLNetTools.Entity.PagerInfo pageInfo, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            DataTable dt = XCLCMS.Data.DAL.Common.Common.GetPageList("Attachment", pageInfo, strWhere, fieldName, fieldKey, fieldOrder);
            return XCLNetTools.Generic.ListHelper.DataTableToList<XCLCMS.Data.Model.Attachment>(dt) as List<XCLCMS.Data.Model.Attachment>;
        }

        /// <summary>
        /// 获取指定id的子记录信息
        /// </summary>
        public List<XCLCMS.Data.Model.Attachment> GetListByParentID(long parentId)
        {
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("select * from Attachment where ParentID=@ParentID");
            db.AddInParameter(dbCommand, "ParentID", DbType.Int64, parentId);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return XCLNetTools.Generic.ListHelper.DataTableToList<XCLCMS.Data.Model.Attachment>(ds.Tables[0]) as List<XCLCMS.Data.Model.Attachment>;
        }

        /// <summary>
        /// 获取与指定附件相关的附件列表（不包含该指定的附件id）
        /// </summary>
        public List<XCLCMS.Data.Model.Attachment> GetCorrelativeList(long attachmentID)
        {
            var model = this.GetModel(attachmentID);
            if (null == model)
            {
                return null;
            }
            XCLCMS.Data.Model.Attachment tempModel = null;
            List<XCLCMS.Data.Model.Attachment> temp = null;
            List<XCLCMS.Data.Model.Attachment> result = new List<Model.Attachment>();

            temp = this.GetListByParentID(model.AttachmentID);

            if (null != temp && temp.Count > 0)
            {
                result.AddRange(temp);
            }

            if (model.ParentID > 0)
            {
                temp = this.GetListByParentID(model.ParentID);
                if (null != temp && temp.Count > 0)
                {
                    result.AddRange(temp);
                }

                tempModel = this.GetModel(model.ParentID);
                if (null != tempModel)
                {
                    result.Add(tempModel);
                }
            }

            if (null != result && result.Count > 0)
            {
                result = result.Distinct().Where(k => k.AttachmentID != attachmentID).ToList();
            }

            return result;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        public bool Delete(List<long> idLst, XCLCMS.Data.Model.Custom.ContextModel context)
        {
            if (null == idLst || idLst.Count == 0)
            {
                return true;
            }
            DateTime dtNow = DateTime.Now;
            using (var scope = new TransactionScope())
            {
                foreach (var id in idLst)
                {
                    var model = this.GetModel(id);
                    if (null == model)
                    {
                        continue;
                    }
                    //删除当前记录
                    model.UpdaterID = context.UserInfo.UserInfoID;
                    model.UpdaterName = context.UserInfo.UserName;
                    model.UpdateTime = dtNow;
                    model.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.D.ToString();
                    if (!this.Update(model))
                    {
                        return false;
                    }
                    //更新子记录的parentid为0
                    var subLst = this.GetListByParentID(id);
                    if (null != subLst && subLst.Count > 0)
                    {
                        foreach (var subModel in subLst)
                        {
                            subModel.ParentID = 0;
                            subModel.UpdaterID = context.UserInfo.UserInfoID;
                            subModel.UpdaterName = context.UserInfo.UserName;
                            subModel.UpdateTime = dtNow;
                            if (!this.Update(subModel))
                            {
                                return false;
                            }
                        }
                    }
                }
                scope.Complete();
            }
            return true;
        }

        /// <summary>
        /// 根据文件id查询文件信息
        /// </summary>
        public List<XCLCMS.Data.Model.Attachment> GetList(List<long> ids)
        {
            if (null == ids || ids.Count == 0)
            {
                return null;
            }
            ids = ids.Distinct().ToList();

            string sql = @"
                select a.* from Attachment as a
                inner join @TVP_ID as b on a.AttachmentID=b.ID
            ";

            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            dbCommand.Parameters.Add(new SqlParameter("TVP_ID", SqlDbType.Structured)
            {
                TypeName= "TVP_IDTable",
                Direction = ParameterDirection.Input,
                Value = XCLNetTools.DataSource.DataTableHelper.ToSingleColumnDataTable<long,long>(ids)
            });
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return XCLNetTools.Generic.ListHelper.DataTableToList<XCLCMS.Data.Model.Attachment>(ds.Tables[0]) as List<XCLCMS.Data.Model.Attachment>;

        }

        #endregion MethodEx
    }
}