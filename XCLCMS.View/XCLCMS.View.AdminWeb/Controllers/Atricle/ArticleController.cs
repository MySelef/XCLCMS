using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.Atricle
{
    /// <summary>
    /// 文章controller
    /// </summary>
    public class ArticleController : BaseController
    {
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_ArticleView)]
        public ActionResult Index()
        {
            XCLCMS.View.AdminWeb.Models.Article.ArticleListVM viewModel = new XCLCMS.View.AdminWeb.Models.Article.ArticleListVM();

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

            XCLCMS.Data.BLL.View.v_Article bll = new Data.BLL.View.v_Article();
            viewModel.ArticleList = bll.GetPageList(base.PageParamsInfo, strWhere, "", "[ArticleID]", "[ArticleID] desc");
            viewModel.PagerModel = base.PageParamsInfo;
            return View("~/Views/Article/ArticleList.cshtml", viewModel);
        }

        /// <summary>
        /// 添加或编辑首页
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_ArticleAdd)]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_ArticleEdit)]
        public ActionResult Add()
        {
            long articleID = XCLNetTools.StringHander.FormHelper.GetLong("ArticleID");

            var objectAttachmentBLL = new XCLCMS.Data.BLL.ObjectAttachment();
            XCLCMS.Data.BLL.Article articleBLL = new Data.BLL.Article();
            XCLCMS.Data.BLL.View.v_Article bll = new Data.BLL.View.v_Article();
            XCLCMS.View.AdminWeb.Models.Article.ArticleAddVM viewModel = new XCLCMS.View.AdminWeb.Models.Article.ArticleAddVM();
            

            switch (base.CurrentHandleType)
            {
                case XCLCMS.Lib.Common.Comm.HandleType.ADD:
                    viewModel.Article = new Data.Model.View.v_Article();
                    viewModel.Article.IsCanComment = XCLCMS.Data.CommonHelper.EnumType.YesNoEnum.Y.ToString();
                    viewModel.FormAction = Url.Action("AddSubmit", "Article");
                    break;

                case XCLCMS.Lib.Common.Comm.HandleType.UPDATE:
                    viewModel.Article = bll.GetModel(articleID);
                    var attLst = objectAttachmentBLL.GetModelList(XCLCMS.Data.CommonHelper.EnumType.ObjectTypeEnum.ART, viewModel.Article.ArticleID);
                    if (null != attLst && attLst.Count > 0)
                    {
                        viewModel.AttachmentIDList = attLst.Select(k => k.FK_AttachmentID).ToList();
                    }
                    viewModel.FormAction = Url.Action("UpdateSubmit", "Article");
                    break;
            }
            
            viewModel.ArticleStateOptions = XCLNetTools.Control.HtmlControl.Lib.GetOptions(typeof(XCLCMS.Data.CommonHelper.EnumType.ArticleStateEnum), new XCLNetTools.Entity.SetOptionEntity()
            {
                IsNeedPleaseSelect = false,
                DefaultValue = viewModel.Article.ArticleState
            });
            viewModel.ArticleContentTypeOptions = XCLNetTools.Control.HtmlControl.Lib.GetOptions(typeof(XCLCMS.Data.CommonHelper.EnumType.ArticleContentTypeEnum), new XCLNetTools.Entity.SetOptionEntity()
            {
                IsNeedPleaseSelect = false,
                DefaultValue = viewModel.Article.ArticleContentType
            });
            viewModel.URLOpenTypeOptions = XCLNetTools.Control.HtmlControl.Lib.GetOptions(typeof(XCLCMS.Data.CommonHelper.EnumType.URLOpenTypeEnum), new XCLNetTools.Entity.SetOptionEntity()
            {
                IsNeedPleaseSelect = true,
                DefaultValue = viewModel.Article.URLOpenType
            });
            viewModel.FromInfoOptions = XCLNetTools.Control.HtmlControl.Lib.GetOptions(typeof(XCLCMS.Data.CommonHelper.EnumType.ArticleFromInfoEnum), new XCLNetTools.Entity.SetOptionEntity()
            {
                IsNeedPleaseSelect = false,
                DefaultValue = viewModel.Article.FromInfo
            });
            viewModel.AuthorNameOptions = XCLNetTools.Control.HtmlControl.Lib.GetOptions(typeof(XCLCMS.Data.CommonHelper.EnumType.ArticleAuthorNameEnum), new XCLNetTools.Entity.SetOptionEntity()
            {
                IsNeedPleaseSelect = false,
                DefaultValue = viewModel.Article.AuthorName
            });
            viewModel.VerifyStateOptions = XCLNetTools.Control.HtmlControl.Lib.GetOptions(typeof(XCLCMS.Data.CommonHelper.EnumType.VerifyStateEnum), new XCLNetTools.Entity.SetOptionEntity()
            {
                IsNeedPleaseSelect = false,
                DefaultValue = viewModel.Article.VerifyState
            });

            return View("~/Views/Article/ArticleAdd.cshtml", viewModel);
        }

        /// <summary>
        /// 查看页
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_ArticleView)]
        public ActionResult Show()
        {
            return View("~/Views/Article/ArticleShow.cshtml");
        }

        /// <summary>
        /// 将表单值转为viewModel
        /// </summary>
        private XCLCMS.View.AdminWeb.Models.Article.ArticleAddVM GetViewModel(FormCollection fm)
        {
            var viewModel = new XCLCMS.View.AdminWeb.Models.Article.ArticleAddVM();

            var mainImageIDList = XCLNetTools.StringHander.FormHelper.GetLongList("mainImage");

            viewModel.AttachmentIDList = XCLNetTools.StringHander.FormHelper.GetLongList("txtAttachments");
            viewModel.ArticleTypeIDList = XCLNetTools.StringHander.FormHelper.GetLongList("selArticleType");

            viewModel.Article = new Data.Model.View.v_Article();
            viewModel.Article.ArticleID = XCLNetTools.StringHander.FormHelper.GetLong("ArticleID");
            viewModel.Article.ArticleContentType = XCLNetTools.StringHander.FormHelper.GetString("selArticleContentType");
            viewModel.Article.ArticleState = XCLNetTools.StringHander.FormHelper.GetString("selArticleState");
            viewModel.Article.AuthorName = XCLNetTools.StringHander.FormHelper.GetString("selAuthorName");
            viewModel.Article.BadCount = XCLNetTools.StringHander.FormHelper.GetInt("txtBadCount");
            viewModel.Article.Code = XCLNetTools.StringHander.FormHelper.GetString("txtCode").Trim();
            viewModel.Article.Comments = XCLNetTools.StringHander.FormHelper.GetString("txtComments");
            viewModel.Article.Contents = XCLNetTools.StringHander.FormHelper.GetString("txtContents");
            viewModel.Article.FromInfo = XCLNetTools.StringHander.FormHelper.GetString("selFromInfo");
            viewModel.Article.GoodCount = XCLNetTools.StringHander.FormHelper.GetInt("txtGoodCount");
            viewModel.Article.HotCount = XCLNetTools.StringHander.FormHelper.GetInt("txtHotCount");
            viewModel.Article.IsCanComment = XCLNetTools.StringHander.FormHelper.GetString("ckIsCanComment");
            viewModel.Article.IsEssence = XCLNetTools.StringHander.FormHelper.GetString("ckIsEssence");
            viewModel.Article.IsRecommend = XCLNetTools.StringHander.FormHelper.GetString("ckIsRecommend");
            viewModel.Article.IsTop = XCLNetTools.StringHander.FormHelper.GetString("ckIsTop");
            viewModel.Article.KeyWords = XCLNetTools.StringHander.FormHelper.GetString("txtKeyWords");
            viewModel.Article.LinkUrl = XCLNetTools.StringHander.FormHelper.GetString("txtLinkUrl");

            if (null != mainImageIDList && mainImageIDList.Count > 0)
            {
                viewModel.Article.MainImage1 = mainImageIDList.Count >= 1 ? mainImageIDList[0] : 0;
                viewModel.Article.MainImage2 = mainImageIDList.Count >= 2 ? mainImageIDList[1] : 0;
                viewModel.Article.MainImage3 = mainImageIDList.Count >= 3 ? mainImageIDList[2] : 0;
            }
            else
            {
                viewModel.Article.MainImage1 = 0;
                viewModel.Article.MainImage2 = 0;
                viewModel.Article.MainImage3 = 0;
            }

            viewModel.Article.MiddleCount = XCLNetTools.StringHander.FormHelper.GetInt("txtMiddleCount");
            viewModel.Article.PublishTime = XCLNetTools.StringHander.FormHelper.GetDateTimeNull("txtPublishTime");
            viewModel.Article.SubTitle = XCLNetTools.StringHander.FormHelper.GetString("txtSubTitle");
            viewModel.Article.Summary = XCLNetTools.StringHander.FormHelper.GetString("txtSummary");
            viewModel.Article.Tags = XCLNetTools.StringHander.FormHelper.GetString("txtTags");
            viewModel.Article.Title = XCLNetTools.StringHander.FormHelper.GetString("txtTitle");
            viewModel.Article.TopBeginTime = XCLNetTools.StringHander.FormHelper.GetDateTimeNull("txtBeginTop");
            viewModel.Article.TopEndTime = XCLNetTools.StringHander.FormHelper.GetDateTimeNull("txtEndTop");
            viewModel.Article.URLOpenType = XCLNetTools.StringHander.FormHelper.GetString("selURLOpenType");
            viewModel.Article.VerifyState = XCLNetTools.StringHander.FormHelper.GetString("selVerifyState");
            viewModel.Article.ViewCount = XCLNetTools.StringHander.FormHelper.GetInt("txtViewCount");

            return viewModel;
        }

        /// <summary>
        /// 添加文章信息
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_ArticleAdd)]
        public override ActionResult AddSubmit(FormCollection fm)
        {
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();

            var viewModel = this.GetViewModel(fm);
            var model = new XCLCMS.Data.Model.Article();
            model.ArticleContentType = viewModel.Article.ArticleContentType;
            model.ArticleID = XCLCMS.Data.BLL.Common.Common.GenerateID(Data.CommonHelper.EnumType.IDTypeEnum.ART);
            model.ArticleState = viewModel.Article.ArticleState;
            model.AuthorName = viewModel.Article.AuthorName;
            model.BadCount = viewModel.Article.BadCount;
            if (string.IsNullOrWhiteSpace(viewModel.Article.Code))
            {
                model.Code = model.ArticleID.ToString();
            }
            else
            {
                model.Code = viewModel.Article.Code;
            }

            model.CommentCount = viewModel.Article.CommentCount;
            model.Comments = viewModel.Article.Comments;
            model.Contents = viewModel.Article.Contents;
            model.CreaterID = base.UserID;
            model.CreaterName = base.CurrentUserModel.UserName;
            model.CreateTime = DateTime.Now;
            model.FromInfo = viewModel.Article.FromInfo;
            model.GoodCount = viewModel.Article.GoodCount;
            model.HotCount = viewModel.Article.HotCount;
            model.IsCanComment = viewModel.Article.IsCanComment;
            model.IsEssence = viewModel.Article.IsEssence;
            model.IsRecommend = viewModel.Article.IsRecommend;
            model.IsTop = viewModel.Article.IsTop;
            model.KeyWords = viewModel.Article.KeyWords;
            model.LinkUrl = viewModel.Article.LinkUrl;
            model.MainImage1 = viewModel.Article.MainImage1;
            model.MainImage2 = viewModel.Article.MainImage2;
            model.MainImage3 = viewModel.Article.MainImage3;
            model.MiddleCount = viewModel.Article.MiddleCount;
            model.PublishTime = viewModel.Article.PublishTime;
            model.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString();
            model.SubTitle = viewModel.Article.SubTitle;
            model.Summary = viewModel.Article.Summary;
            model.Tags = viewModel.Article.Tags;
            model.Title = viewModel.Article.Title;
            model.TopBeginTime = viewModel.Article.TopBeginTime;
            model.TopEndTime = viewModel.Article.TopEndTime;
            model.UpdaterID = base.UserID;
            model.UpdaterName = base.CurrentUserModel.UserName;
            model.UpdateTime = DateTime.Now;
            model.URLOpenType = viewModel.Article.URLOpenType;
            model.VerifyState = viewModel.Article.VerifyState;
            model.ViewCount = viewModel.Article.ViewCount;

            var articleContext = new Data.BLL.Strategy.Article.ArticleContext();
            articleContext.CurrentUserInfo = base.CurrentUserModel;
            articleContext.Article = model;
            articleContext.HandleType = Data.BLL.Strategy.StrategyLib.HandleType.ADD;
            articleContext.ArticleTypeIDList = viewModel.ArticleTypeIDList;
            articleContext.ArticleAttachmentIDList = viewModel.AttachmentIDList;

            XCLCMS.Data.BLL.Strategy.ExecuteStrategy strategy = new Data.BLL.Strategy.ExecuteStrategy(new List<Data.BLL.Strategy.BaseStrategy>() {
                new XCLCMS.Data.BLL.Strategy.Article.Article(),
                new XCLCMS.Data.BLL.Strategy.Article.ObjectAttachment(),
                new XCLCMS.Data.BLL.Strategy.Article.ArticleType()
            });
            strategy.Execute(articleContext);

            if (strategy.Result != Data.BLL.Strategy.StrategyLib.ResultEnum.FAIL)
            {
                msgModel.Message = "添加成功！";
                msgModel.IsSuccess = true;
            }
            else
            {
                msgModel.Message = strategy.ResultMessage;
                msgModel.IsSuccess = false;
                XCLNetLogger.Log.WriteLog(XCLNetLogger.Config.LogConfig.LogLevel.ERROR, "添加文章信息失败", strategy.ResultMessage);
            }

            return Json(msgModel);
        }

        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_ArticleDel)]
        public override ActionResult DelSubmit(FormCollection fm)
        {
            XCLNetTools.Message.MessageModel msg = new XCLNetTools.Message.MessageModel();

            return Json(msg);
        }

        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_ArticleEdit)]
        public override ActionResult UpdateSubmit(FormCollection fm)
        {
            XCLNetTools.Message.MessageModel msg = new XCLNetTools.Message.MessageModel();

            return Json(msg);
        }
    }
}