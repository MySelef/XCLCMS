using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace XCLCMS.Data.DAL.View
{
    public class v_Article : XCLCMS.Data.DAL.Common.BaseDAL
    {
        public v_Article()
        { }

        #region Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.View.v_Article GetModel(long ArticleID)
        {
            XCLCMS.Data.Model.View.v_Article model = new XCLCMS.Data.Model.View.v_Article();
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("select * from v_Article where ArticleID=@ArticleID");
            db.AddInParameter(dbCommand, "ArticleID", DbType.Int64, ArticleID);
            DataSet ds = db.ExecuteDataSet(dbCommand);

            var lst = XCLNetTools.Generic.ListHelper.DataTableToList<XCLCMS.Data.Model.View.v_Article>(ds.Tables[0]);
            return null != lst && lst.Count > 0 ? lst[0] : null;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_Article> GetModelList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UpdaterName,UpdaterID,UpdateTime,CreaterName,CreaterID,CreateTime,RecordState,PublishTime,LinkUrl,Comments,Tags,KeyWords,TopEndTime,TopBeginTime,IsTop,IsEssence,IsRecommend,VerifyState,ArticleState,URLOpenType,HotCount,BadCount,MiddleCount,GoodCount,CommentCount,IsCanComment,ViewCount,MainImage3,MainImage2,MainImage1,Summary,Contents,ArticleContentType,FromInfo,AuthorName,SubTitle,Title,Code,ArticleID,ArticleTypeIDs,ArticleTypeNames ");
            strSql.Append(" FROM v_Article ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = base.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            var ds = db.ExecuteDataSet(dbCommand);
            return XCLNetTools.Generic.ListHelper.DataSetToList<XCLCMS.Data.Model.View.v_Article>(ds) as List<XCLCMS.Data.Model.View.v_Article>;
        }

        #endregion Method

        #region Extend Method

        /// <summary>
        /// 分页数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_Article> GetPageList(XCLNetTools.Entity.PagerInfo pageInfo, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            DataTable dt = XCLCMS.Data.DAL.Common.Common.GetPageList("v_Article", pageInfo, strWhere, fieldName, fieldKey, fieldOrder);
            return XCLNetTools.Generic.ListHelper.DataTableToList<XCLCMS.Data.Model.View.v_Article>(dt) as List<XCLCMS.Data.Model.View.v_Article>;
        }

        #endregion Extend Method
    }
}