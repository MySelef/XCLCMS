using System.Collections.Generic;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.Atricle
{
    /// <summary>
    /// 文章controller
    /// </summary>
    public class ArticleController : BaseController
    {
        public ActionResult Index()
        {
            XCLCMS.View.AdminViewModel.Article.ArticleListVM viewModel = new AdminViewModel.Article.ArticleListVM();

            #region 初始化查询条件

            viewModel.Search = new XCLNetSearch.Search();
            viewModel.Search.TypeList = new List<XCLNetSearch.SearchFieldInfo>() {
                new XCLNetSearch.SearchFieldInfo("文章ID","ArticleID|number|text",""),
                new XCLNetSearch.SearchFieldInfo("标题","Title|string|text",""),
                new XCLNetSearch.SearchFieldInfo("作者","AuthorName|string|text",""),
                new XCLNetSearch.SearchFieldInfo("来源","FromInfo|string|text",""),
                new XCLNetSearch.SearchFieldInfo("文章类型","ArticleContentType|string|text",""),
                new XCLNetSearch.SearchFieldInfo("浏览数","ViewCount|number|text",""),
                new XCLNetSearch.SearchFieldInfo("评论数","CommentCount|number|text",""),
                new XCLNetSearch.SearchFieldInfo("热度","HotCount|number|text",""),
                new XCLNetSearch.SearchFieldInfo("文章状态","ArticleState|string|text",""),
                new XCLNetSearch.SearchFieldInfo("记录状态","RecordState|string|text",""),
                new XCLNetSearch.SearchFieldInfo("创建时间","CreateTime|dateTime|text",""),
                new XCLNetSearch.SearchFieldInfo("创建者名","CreaterName|string|text",""),
                new XCLNetSearch.SearchFieldInfo("更新时间","UpdateTime|dateTime|text",""),
                new XCLNetSearch.SearchFieldInfo("更新人名","UpdaterName|string|text","")
            };
            string strWhere = string.Format("RecordState='{0}'", XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString());
            string strSearch = viewModel.Search.StrSQL;
            if (!string.IsNullOrEmpty(strSearch))
            {
                strWhere = string.Format("{0} and ({1})", strWhere, strSearch);
            }

            #endregion 初始化查询条件

            XCLCMS.Data.BLL.Article bll = new Data.BLL.Article();
            viewModel.ArticleList = bll.GetPageList(base.PageParamsInfo, strWhere, "", "[ArticleID]", "[ArticleID] desc");
            viewModel.PagerModel = base.PageParamsInfo;
            return View("~/Views/Article/ArticleList.cshtml", viewModel);
        }

        /// <summary>
        /// 添加或编辑首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            long articleID = XCLNetTools.StringHander.FormHelper.GetLong("ArticleID");

            XCLCMS.Data.BLL.Article bll = new Data.BLL.Article();
            XCLCMS.View.AdminViewModel.Article.ArticleAddVM viewModel = new AdminViewModel.Article.ArticleAddVM();

            var articleTypeDic = bll.GetArticleTypeDic();

            switch (base.CurrentHandleType)
            {
                case XCLCMS.Lib.Common.Comm.HandleType.ADD:
                    viewModel.Article = new Data.Model.Article();
                    viewModel.ArticleTypeOptions = XCLNetTools.Control.HtmlControl.Lib.GetOptions(articleTypeDic, new XCLNetTools.Entity.SetOptionEntity()
                    {
                        IsNeedPleaseSelect = true
                    });
                    viewModel.ArticleStateOptions = XCLNetTools.Control.HtmlControl.Lib.GetOptions(typeof(XCLCMS.Data.CommonHelper.EnumType.ArticleStateEnum), new XCLNetTools.Entity.SetOptionEntity()
                    {
                        IsNeedPleaseSelect = true
                    });
                    viewModel.ArticleContentTypeOptions = XCLNetTools.Control.HtmlControl.Lib.GetOptions(typeof(XCLCMS.Data.CommonHelper.EnumType.ArticleContentTypeEnum), new XCLNetTools.Entity.SetOptionEntity()
                    {
                        IsNeedPleaseSelect = false
                    });
                    viewModel.URLOpenTypeOptions = XCLNetTools.Control.HtmlControl.Lib.GetOptions(typeof(XCLCMS.Data.CommonHelper.EnumType.URLOpenTypeEnum), new XCLNetTools.Entity.SetOptionEntity()
                    {
                        IsNeedPleaseSelect = true
                    });
                    viewModel.FromInfoOptions = XCLNetTools.Control.HtmlControl.Lib.GetOptions(typeof(XCLCMS.Data.CommonHelper.EnumType.ArticleFromInfoEnum), new XCLNetTools.Entity.SetOptionEntity()
                    {
                        IsNeedPleaseSelect = false
                    });
                    viewModel.AuthorNameOptions = XCLNetTools.Control.HtmlControl.Lib.GetOptions(typeof(XCLCMS.Data.CommonHelper.EnumType.ArticleAuthorNameEnum), new XCLNetTools.Entity.SetOptionEntity()
                    {
                        IsNeedPleaseSelect = false
                    });
                    viewModel.Article.IsCanComment = XCLCMS.Data.CommonHelper.EnumType.YesNoEnum.Y.ToString();
                    viewModel.FormAction = Url.Action("AddSubmit", "Article");
                    break;

                case XCLCMS.Lib.Common.Comm.HandleType.UPDATE:
                    viewModel.Article = bll.GetModel(articleID);
                    viewModel.FormAction = Url.Action("UpdateSubmit", "Article");
                    break;
            }

            return View("~/Views/Article/ArticleAdd.cshtml", viewModel);
        }

        public override ActionResult AddSubmit(FormCollection fm)
        {
            XCLNetTools.Message.MessageModel msg = new XCLNetTools.Message.MessageModel();

            return Json(msg);
        }

        public override ActionResult DelSubmit(FormCollection fm)
        {
            XCLNetTools.Message.MessageModel msg = new XCLNetTools.Message.MessageModel();

            return Json(msg);
        }

        public override ActionResult UpdateSubmit(FormCollection fm)
        {
            XCLNetTools.Message.MessageModel msg = new XCLNetTools.Message.MessageModel();

            return Json(msg);
        }
    }
}