using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Collections.Generic;

namespace XCLCMS.Data.DAL
{
    /// <summary>
    /// 数据访问类:Article
    /// </summary>
    public partial class Article : XCLCMS.Data.Common.BaseDAL
    {
        public Article()
        { }
        #region  Method

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.Article model)
        {
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Article_ADD");
            db.AddInParameter(dbCommand, "ArticleID", DbType.Int64, model.ArticleID);
            db.AddInParameter(dbCommand, "Code", DbType.AnsiString, model.Code);
            db.AddInParameter(dbCommand, "Title", DbType.String, model.Title);
            db.AddInParameter(dbCommand, "SubTitle", DbType.String, model.SubTitle);
            db.AddInParameter(dbCommand, "AuthorName", DbType.String, model.AuthorName);
            db.AddInParameter(dbCommand, "FromInfo", DbType.String, model.FromInfo);
            db.AddInParameter(dbCommand, "ArticleContentType", DbType.AnsiString, model.ArticleContentType);
            db.AddInParameter(dbCommand, "Contents", DbType.String, model.Contents);
            db.AddInParameter(dbCommand, "Summary", DbType.String, model.Summary);
            db.AddInParameter(dbCommand, "MainImage1", DbType.AnsiString, model.MainImage1);
            db.AddInParameter(dbCommand, "MainImage2", DbType.AnsiString, model.MainImage2);
            db.AddInParameter(dbCommand, "MainImage3", DbType.AnsiString, model.MainImage3);
            db.AddInParameter(dbCommand, "ViewCount", DbType.Int32, model.ViewCount);
            db.AddInParameter(dbCommand, "IsCanComment", DbType.AnsiString, model.IsCanComment);
            db.AddInParameter(dbCommand, "CommentCount", DbType.Int32, model.CommentCount);
            db.AddInParameter(dbCommand, "GoodCount", DbType.Int32, model.GoodCount);
            db.AddInParameter(dbCommand, "MiddleCount", DbType.Int32, model.MiddleCount);
            db.AddInParameter(dbCommand, "BadCount", DbType.Int32, model.BadCount);
            db.AddInParameter(dbCommand, "HotCount", DbType.Int32, model.HotCount);
            db.AddInParameter(dbCommand, "URLOpenType", DbType.AnsiString, model.URLOpenType);
            db.AddInParameter(dbCommand, "ArticleState", DbType.AnsiString, model.ArticleState);
            db.AddInParameter(dbCommand, "VerifyState", DbType.AnsiString, model.VerifyState);
            db.AddInParameter(dbCommand, "IsRecommend", DbType.AnsiString, model.IsRecommend);
            db.AddInParameter(dbCommand, "IsEssence", DbType.AnsiString, model.IsEssence);
            db.AddInParameter(dbCommand, "IsTop", DbType.AnsiString, model.IsTop);
            db.AddInParameter(dbCommand, "TopBeginTime", DbType.DateTime, model.TopBeginTime);
            db.AddInParameter(dbCommand, "TopEndTime", DbType.DateTime, model.TopEndTime);
            db.AddInParameter(dbCommand, "KeyWords", DbType.String, model.KeyWords);
            db.AddInParameter(dbCommand, "Tags", DbType.String, model.Tags);
            db.AddInParameter(dbCommand, "Comments", DbType.String, model.Comments);
            db.AddInParameter(dbCommand, "LinkUrl", DbType.AnsiString, model.LinkUrl);
            db.AddInParameter(dbCommand, "PublishTime", DbType.DateTime, model.PublishTime);
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
        public bool Update(XCLCMS.Data.Model.Article model)
        {
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Article_Update");
            db.AddInParameter(dbCommand, "ArticleID", DbType.Int64, model.ArticleID);
            db.AddInParameter(dbCommand, "Code", DbType.AnsiString, model.Code);
            db.AddInParameter(dbCommand, "Title", DbType.String, model.Title);
            db.AddInParameter(dbCommand, "SubTitle", DbType.String, model.SubTitle);
            db.AddInParameter(dbCommand, "AuthorName", DbType.String, model.AuthorName);
            db.AddInParameter(dbCommand, "FromInfo", DbType.String, model.FromInfo);
            db.AddInParameter(dbCommand, "ArticleContentType", DbType.AnsiString, model.ArticleContentType);
            db.AddInParameter(dbCommand, "Contents", DbType.String, model.Contents);
            db.AddInParameter(dbCommand, "Summary", DbType.String, model.Summary);
            db.AddInParameter(dbCommand, "MainImage1", DbType.AnsiString, model.MainImage1);
            db.AddInParameter(dbCommand, "MainImage2", DbType.AnsiString, model.MainImage2);
            db.AddInParameter(dbCommand, "MainImage3", DbType.AnsiString, model.MainImage3);
            db.AddInParameter(dbCommand, "ViewCount", DbType.Int32, model.ViewCount);
            db.AddInParameter(dbCommand, "IsCanComment", DbType.AnsiString, model.IsCanComment);
            db.AddInParameter(dbCommand, "CommentCount", DbType.Int32, model.CommentCount);
            db.AddInParameter(dbCommand, "GoodCount", DbType.Int32, model.GoodCount);
            db.AddInParameter(dbCommand, "MiddleCount", DbType.Int32, model.MiddleCount);
            db.AddInParameter(dbCommand, "BadCount", DbType.Int32, model.BadCount);
            db.AddInParameter(dbCommand, "HotCount", DbType.Int32, model.HotCount);
            db.AddInParameter(dbCommand, "URLOpenType", DbType.AnsiString, model.URLOpenType);
            db.AddInParameter(dbCommand, "ArticleState", DbType.AnsiString, model.ArticleState);
            db.AddInParameter(dbCommand, "VerifyState", DbType.AnsiString, model.VerifyState);
            db.AddInParameter(dbCommand, "IsRecommend", DbType.AnsiString, model.IsRecommend);
            db.AddInParameter(dbCommand, "IsEssence", DbType.AnsiString, model.IsEssence);
            db.AddInParameter(dbCommand, "IsTop", DbType.AnsiString, model.IsTop);
            db.AddInParameter(dbCommand, "TopBeginTime", DbType.DateTime, model.TopBeginTime);
            db.AddInParameter(dbCommand, "TopEndTime", DbType.DateTime, model.TopEndTime);
            db.AddInParameter(dbCommand, "KeyWords", DbType.String, model.KeyWords);
            db.AddInParameter(dbCommand, "Tags", DbType.String, model.Tags);
            db.AddInParameter(dbCommand, "Comments", DbType.String, model.Comments);
            db.AddInParameter(dbCommand, "LinkUrl", DbType.AnsiString, model.LinkUrl);
            db.AddInParameter(dbCommand, "PublishTime", DbType.DateTime, model.PublishTime);
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
        public XCLCMS.Data.Model.Article GetModel(long ArticleID)
        {
            XCLCMS.Data.Model.Article model = new XCLCMS.Data.Model.Article();
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("select * from Article where ArticleID=@ArticleID");
            db.AddInParameter(dbCommand, "ArticleID", DbType.Int64, ArticleID);
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
        public XCLCMS.Data.Model.Article DataRowToModel(DataRow row)
        {
            XCLCMS.Data.Model.Article model = new XCLCMS.Data.Model.Article();
            if (row != null)
            {
                if (row["ArticleID"] != null && row["ArticleID"].ToString() != "")
                {
                    model.ArticleID = long.Parse(row["ArticleID"].ToString());
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["SubTitle"] != null)
                {
                    model.SubTitle = row["SubTitle"].ToString();
                }
                if (row["AuthorName"] != null)
                {
                    model.AuthorName = row["AuthorName"].ToString();
                }
                if (row["FromInfo"] != null)
                {
                    model.FromInfo = row["FromInfo"].ToString();
                }
                if (row["ArticleContentType"] != null)
                {
                    model.ArticleContentType = row["ArticleContentType"].ToString();
                }
                if (row["Contents"] != null)
                {
                    model.Contents = row["Contents"].ToString();
                }
                if (row["Summary"] != null)
                {
                    model.Summary = row["Summary"].ToString();
                }
                if (row["MainImage1"] != null)
                {
                    model.MainImage1 = row["MainImage1"].ToString();
                }
                if (row["MainImage2"] != null)
                {
                    model.MainImage2 = row["MainImage2"].ToString();
                }
                if (row["MainImage3"] != null)
                {
                    model.MainImage3 = row["MainImage3"].ToString();
                }
                if (row["ViewCount"] != null && row["ViewCount"].ToString() != "")
                {
                    model.ViewCount = int.Parse(row["ViewCount"].ToString());
                }
                if (row["IsCanComment"] != null)
                {
                    model.IsCanComment = row["IsCanComment"].ToString();
                }
                if (row["CommentCount"] != null && row["CommentCount"].ToString() != "")
                {
                    model.CommentCount = int.Parse(row["CommentCount"].ToString());
                }
                if (row["GoodCount"] != null && row["GoodCount"].ToString() != "")
                {
                    model.GoodCount = int.Parse(row["GoodCount"].ToString());
                }
                if (row["MiddleCount"] != null && row["MiddleCount"].ToString() != "")
                {
                    model.MiddleCount = int.Parse(row["MiddleCount"].ToString());
                }
                if (row["BadCount"] != null && row["BadCount"].ToString() != "")
                {
                    model.BadCount = int.Parse(row["BadCount"].ToString());
                }
                if (row["HotCount"] != null && row["HotCount"].ToString() != "")
                {
                    model.HotCount = int.Parse(row["HotCount"].ToString());
                }
                if (row["URLOpenType"] != null)
                {
                    model.URLOpenType = row["URLOpenType"].ToString();
                }
                if (row["ArticleState"] != null)
                {
                    model.ArticleState = row["ArticleState"].ToString();
                }
                if (row["VerifyState"] != null)
                {
                    model.VerifyState = row["VerifyState"].ToString();
                }
                if (row["IsRecommend"] != null)
                {
                    model.IsRecommend = row["IsRecommend"].ToString();
                }
                if (row["IsEssence"] != null)
                {
                    model.IsEssence = row["IsEssence"].ToString();
                }
                if (row["IsTop"] != null)
                {
                    model.IsTop = row["IsTop"].ToString();
                }
                if (row["TopBeginTime"] != null && row["TopBeginTime"].ToString() != "")
                {
                    model.TopBeginTime = DateTime.Parse(row["TopBeginTime"].ToString());
                }
                if (row["TopEndTime"] != null && row["TopEndTime"].ToString() != "")
                {
                    model.TopEndTime = DateTime.Parse(row["TopEndTime"].ToString());
                }
                if (row["KeyWords"] != null)
                {
                    model.KeyWords = row["KeyWords"].ToString();
                }
                if (row["Tags"] != null)
                {
                    model.Tags = row["Tags"].ToString();
                }
                if (row["Comments"] != null)
                {
                    model.Comments = row["Comments"].ToString();
                }
                if (row["LinkUrl"] != null)
                {
                    model.LinkUrl = row["LinkUrl"].ToString();
                }
                if (row["PublishTime"] != null && row["PublishTime"].ToString() != "")
                {
                    model.PublishTime = DateTime.Parse(row["PublishTime"].ToString());
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
            strSql.Append("select ArticleID,Code,Title,SubTitle,AuthorName,FromInfo,ArticleType,Contents,Summary,MainImage,ViewCount,IsCanComment,CommentCount,GoodCount,MiddleCount,BadCount,HotCount,URLOpenType,ArticleState,RecordState,CreateTime,CreaterID,CreaterName,UpdateTime,UpdaterID,UpdaterName ");
            strSql.Append(" FROM Article ");
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
        /// <summary>
        /// 分页数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.Article> GetPageList(int pageSize, int pageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            DataTable dt = XCLCMS.Data.DAL.Common.Common.GetPageList("Article", pageSize, pageIndex, ref recordCount, strWhere, fieldName, fieldKey, fieldOrder);
            return XCLNetTools.Generic.ListHelper<XCLCMS.Data.Model.Article>.DataTableToList(dt) as List<XCLCMS.Data.Model.Article>;
        }
        #endregion  MethodEx
    }
}

