using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XCLCMS.CodeTool.DBUtility;
using System.Collections.Generic;//Please add references
namespace XCLCMS.Data.DAL
{
    /// <summary>
    /// 数据访问类:Article
    /// </summary>
    public partial class Article
    {
        public Article()
        { }
        #region  Method

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.Article model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ArticleID", SqlDbType.BigInt,8),
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@SubTitle", SqlDbType.NVarChar,200),
					new SqlParameter("@AuthorName", SqlDbType.NVarChar,50),
					new SqlParameter("@FromInfo", SqlDbType.NVarChar,500),
					new SqlParameter("@ArticleType", SqlDbType.Char,3),
					new SqlParameter("@Contents", SqlDbType.NVarChar,-1),
					new SqlParameter("@Summary", SqlDbType.NVarChar,500),
					new SqlParameter("@MainImage", SqlDbType.VarChar,500),
					new SqlParameter("@ViewCount", SqlDbType.Int,4),
					new SqlParameter("@IsCanComment", SqlDbType.Char,1),
					new SqlParameter("@CommentCount", SqlDbType.Int,4),
					new SqlParameter("@GoodCount", SqlDbType.Int,4),
					new SqlParameter("@MiddleCount", SqlDbType.Int,4),
					new SqlParameter("@BadCount", SqlDbType.Int,4),
					new SqlParameter("@HotCount", SqlDbType.Int,4),
					new SqlParameter("@URLOpenType", SqlDbType.Char,3),
					new SqlParameter("@ArticleState", SqlDbType.Char,3),
					new SqlParameter("@RecordState", SqlDbType.Char,1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreaterID", SqlDbType.BigInt,8),
					new SqlParameter("@CreaterName", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdaterID", SqlDbType.BigInt,8),
					new SqlParameter("@UpdaterName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ArticleID;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.SubTitle;
            parameters[4].Value = model.AuthorName;
            parameters[5].Value = model.FromInfo;
            parameters[6].Value = model.ArticleType;
            parameters[7].Value = model.Contents;
            parameters[8].Value = model.Summary;
            parameters[9].Value = model.MainImage;
            parameters[10].Value = model.ViewCount;
            parameters[11].Value = model.IsCanComment;
            parameters[12].Value = model.CommentCount;
            parameters[13].Value = model.GoodCount;
            parameters[14].Value = model.MiddleCount;
            parameters[15].Value = model.BadCount;
            parameters[16].Value = model.HotCount;
            parameters[17].Value = model.URLOpenType;
            parameters[18].Value = model.ArticleState;
            parameters[19].Value = model.RecordState;
            parameters[20].Value = model.CreateTime;
            parameters[21].Value = model.CreaterID;
            parameters[22].Value = model.CreaterName;
            parameters[23].Value = model.UpdateTime;
            parameters[24].Value = model.UpdaterID;
            parameters[25].Value = model.UpdaterName;

            DbHelperSQL.RunProcedure("Article_ADD", parameters, out rowsAffected);
            return rowsAffected > 0;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(XCLCMS.Data.Model.Article model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@ArticleID", SqlDbType.BigInt,8),
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@SubTitle", SqlDbType.NVarChar,200),
					new SqlParameter("@AuthorName", SqlDbType.NVarChar,50),
					new SqlParameter("@FromInfo", SqlDbType.NVarChar,500),
					new SqlParameter("@ArticleType", SqlDbType.Char,3),
					new SqlParameter("@Contents", SqlDbType.NVarChar,-1),
					new SqlParameter("@Summary", SqlDbType.NVarChar,500),
					new SqlParameter("@MainImage", SqlDbType.VarChar,500),
					new SqlParameter("@ViewCount", SqlDbType.Int,4),
					new SqlParameter("@IsCanComment", SqlDbType.Char,1),
					new SqlParameter("@CommentCount", SqlDbType.Int,4),
					new SqlParameter("@GoodCount", SqlDbType.Int,4),
					new SqlParameter("@MiddleCount", SqlDbType.Int,4),
					new SqlParameter("@BadCount", SqlDbType.Int,4),
					new SqlParameter("@HotCount", SqlDbType.Int,4),
					new SqlParameter("@URLOpenType", SqlDbType.Char,3),
					new SqlParameter("@ArticleState", SqlDbType.Char,3),
					new SqlParameter("@RecordState", SqlDbType.Char,1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreaterID", SqlDbType.BigInt,8),
					new SqlParameter("@CreaterName", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdaterID", SqlDbType.BigInt,8),
					new SqlParameter("@UpdaterName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ArticleID;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.SubTitle;
            parameters[4].Value = model.AuthorName;
            parameters[5].Value = model.FromInfo;
            parameters[6].Value = model.ArticleType;
            parameters[7].Value = model.Contents;
            parameters[8].Value = model.Summary;
            parameters[9].Value = model.MainImage;
            parameters[10].Value = model.ViewCount;
            parameters[11].Value = model.IsCanComment;
            parameters[12].Value = model.CommentCount;
            parameters[13].Value = model.GoodCount;
            parameters[14].Value = model.MiddleCount;
            parameters[15].Value = model.BadCount;
            parameters[16].Value = model.HotCount;
            parameters[17].Value = model.URLOpenType;
            parameters[18].Value = model.ArticleState;
            parameters[19].Value = model.RecordState;
            parameters[20].Value = model.CreateTime;
            parameters[21].Value = model.CreaterID;
            parameters[22].Value = model.CreaterName;
            parameters[23].Value = model.UpdateTime;
            parameters[24].Value = model.UpdaterID;
            parameters[25].Value = model.UpdaterName;

            DbHelperSQL.RunProcedure("Article_Update", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.Article GetModel(long ArticleID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ArticleID", SqlDbType.BigInt,8)			};
            parameters[0].Value = ArticleID;

            XCLCMS.Data.Model.Article model = new XCLCMS.Data.Model.Article();
            DataSet ds = DbHelperSQL.RunProcedure("Article_GetModel", parameters, "ds");
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
                if (row["ArticleType"] != null)
                {
                    model.ArticleType = row["ArticleType"].ToString();
                }
                if (row["Contents"] != null)
                {
                    model.Contents = row["Contents"].ToString();
                }
                if (row["Summary"] != null)
                {
                    model.Summary = row["Summary"].ToString();
                }
                if (row["MainImage"] != null)
                {
                    model.MainImage = row["MainImage"].ToString();
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
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
        #region  MethodEx
        /// <summary>
        /// 分页数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.Article> GetPageList(int pageSize, int pageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            DataTable dt = XCLCMS.Data.DAL.CommonDAL.CommonDALHelper.GetPageList("Article", pageSize, pageIndex, ref recordCount, strWhere, fieldName, fieldKey, fieldOrder);
            return XCLNetTools.Generic.ListHelper<XCLCMS.Data.Model.Article>.DataTableToList(dt) as List<XCLCMS.Data.Model.Article>;
        }
        #endregion  MethodEx
    }
}

