using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.Merchant
{
    /// <summary>
    /// 商户应用信息Controller
    /// </summary>
    public class MerchantAppController : BaseController
    {
        /// <summary>
        /// 商户应用信息列表
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantAppView)]
        public ActionResult Index()
        {
            XCLCMS.View.AdminWeb.Models.Merchant.MerchantAppListVM viewModel = new XCLCMS.View.AdminWeb.Models.Merchant.MerchantAppListVM();

            #region 初始化查询条件

            viewModel.Search = new XCLNetSearch.Search();
            viewModel.Search.TypeList = new List<XCLNetSearch.SearchFieldInfo>() {
                new XCLNetSearch.SearchFieldInfo("商户应用ID","MerchantAppID|number|text",""),
                new XCLNetSearch.SearchFieldInfo("商户应用名","MerchantAppName|string|text",""),
                new XCLNetSearch.SearchFieldInfo("所属商户ID","FK_MerchantID|number|text",""),
                new XCLNetSearch.SearchFieldInfo("所属商户名","MerchantName|string|text",""),
                new XCLNetSearch.SearchFieldInfo("备注","Remark|string|text",""),
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

            var request = XCLCMS.Lib.WebAPI.Library.CreateRequest<XCLCMS.Data.WebAPIEntity.RequestEntity.PageListConditionEntity>(base.UserToken);
            request.Body = new Data.WebAPIEntity.RequestEntity.PageListConditionEntity()
            {
                PagerInfoSimple = base.PageParamsInfo.ToPagerInfoSimple(),
                Where = strWhere
            };
            var response = XCLCMS.Lib.WebAPI.MerchantAppAPI.PageList(request).Body;
            viewModel.MerchantAppList = response.ResultList;
            viewModel.PagerModel = response.PagerInfo;

            return View("~/Views/Merchant/MerchantAppList.cshtml", viewModel);
        }

        /// <summary>
        /// 添加与编辑商户应用页面首页
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantAppAdd)]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantAppEdit)]
        public ActionResult Add()
        {
            long merchantAppId = XCLNetTools.StringHander.FormHelper.GetLong("merchantAppId");

            var merchantAppBLL = new Data.BLL.MerchantApp();
            var viewModel = new XCLCMS.View.AdminWeb.Models.Merchant.MerchantAppAddVM();
            viewModel.MerchantApp = new Data.Model.MerchantApp();

            switch (base.CurrentHandleType)
            {
                case XCLCMS.Lib.Common.Comm.HandleType.ADD:
                    viewModel.MerchantApp = new Data.Model.MerchantApp();
                    viewModel.FormAction = Url.Action("AddSubmit", "MerchantApp");
                    break;

                case XCLCMS.Lib.Common.Comm.HandleType.UPDATE:
                    var request = XCLCMS.Lib.WebAPI.Library.CreateRequest<long>(base.UserToken);
                    request.Body = merchantAppId;
                    var response = XCLCMS.Lib.WebAPI.MerchantAppAPI.Detail(request);

                    viewModel.MerchantApp = response.Body;
                    viewModel.FormAction = Url.Action("UpdateSubmit", "MerchantApp");
                    break;
            }

            return View("~/Views/Merchant/MerchantAppAdd.cshtml", viewModel);
        }

        /// <summary>
        /// 将表单值转为viewModel
        /// </summary>
        private XCLCMS.View.AdminWeb.Models.Merchant.MerchantAppAddVM GetViewModel(FormCollection fm)
        {
            var viewModel = new XCLCMS.View.AdminWeb.Models.Merchant.MerchantAppAddVM();
            viewModel.MerchantApp = new Data.Model.MerchantApp();
            viewModel.MerchantApp.FK_MerchantID = XCLNetTools.StringHander.FormHelper.GetLong("txtMerchantID");
            viewModel.MerchantApp.MerchantAppID = XCLNetTools.StringHander.FormHelper.GetLong("MerchantAppID");
            viewModel.MerchantApp.MerchantAppName = XCLNetTools.StringHander.FormHelper.GetString("txtMerchantAppName");
            viewModel.MerchantApp.Remark = XCLNetTools.StringHander.FormHelper.GetString("txtRemark");
            viewModel.MerchantApp.ResourceVersion = XCLNetTools.StringHander.FormHelper.GetString("txtResourceVersion");
            viewModel.MerchantApp.Email = XCLNetTools.StringHander.FormHelper.GetString("txtEmail");
            viewModel.MerchantApp.CopyRight = XCLNetTools.StringHander.FormHelper.GetString("txtCopyRight");
            viewModel.MerchantApp.MetaDescription = XCLNetTools.StringHander.FormHelper.GetString("txtMetaDescription");
            viewModel.MerchantApp.MetaKeyWords = XCLNetTools.StringHander.FormHelper.GetString("txtMetaKeyWords");
            viewModel.MerchantApp.MetaTitle = XCLNetTools.StringHander.FormHelper.GetString("txtMetaTitle");
            viewModel.MerchantApp.WebURL = XCLNetTools.StringHander.FormHelper.GetString("txtWebURL");
            return viewModel;
        }

        /// <summary>
        /// 添加商户应用信息
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantAppAdd)]
        public override ActionResult AddSubmit(FormCollection fm)
        {
            var viewModel = this.GetViewModel(fm);
            XCLCMS.Data.BLL.MerchantApp merchantAppBLL = new Data.BLL.MerchantApp();
            XCLCMS.Data.Model.MerchantApp model = new XCLCMS.Data.Model.MerchantApp();
            model.MerchantAppID = XCLCMS.Data.BLL.Common.Common.GenerateID(Data.CommonHelper.EnumType.IDTypeEnum.MEP);
            model.FK_MerchantID = viewModel.MerchantApp.FK_MerchantID;
            model.MerchantAppName = viewModel.MerchantApp.MerchantAppName;
            model.CreaterID = base.CurrentUserModel.UserInfoID;
            model.CreaterName = base.CurrentUserModel.UserName;
            model.CreateTime = DateTime.Now;
            model.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString();
            model.Remark = viewModel.MerchantApp.Remark;
            model.UpdaterID = model.CreaterID;
            model.UpdaterName = model.CreaterName;
            model.UpdateTime = model.CreateTime;
            model.ResourceVersion = viewModel.MerchantApp.ResourceVersion;
            model.Email = viewModel.MerchantApp.Email;
            model.CopyRight = viewModel.MerchantApp.CopyRight;
            model.MetaDescription = viewModel.MerchantApp.MetaDescription;
            model.MetaKeyWords = viewModel.MerchantApp.MetaKeyWords;
            model.MetaTitle = viewModel.MerchantApp.MetaTitle;
            model.WebURL = viewModel.MerchantApp.WebURL;

            var request = XCLCMS.Lib.WebAPI.Library.CreateRequest<XCLCMS.Data.Model.MerchantApp>(base.UserToken);
            request.Body = model;
            var response = XCLCMS.Lib.WebAPI.MerchantAppAPI.Add(request);

            return Json(response);
        }

        /// <summary>
        /// 更新商户应用信息
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantAppEdit)]
        public override ActionResult UpdateSubmit(FormCollection fm)
        {
            base.UpdateSubmit(fm);
            long merchantAppId = XCLNetTools.StringHander.FormHelper.GetLong("merchantAppId");
            var viewModel = this.GetViewModel(fm);
            var merchantAppBLL = new Data.BLL.MerchantApp();
            var model = merchantAppBLL.GetModel(merchantAppId);
            model.FK_MerchantID = viewModel.MerchantApp.FK_MerchantID;
            model.MerchantAppName = viewModel.MerchantApp.MerchantAppName;
            model.Remark = viewModel.MerchantApp.Remark;
            model.UpdaterID = model.CreaterID;
            model.UpdaterName = model.CreaterName;
            model.UpdateTime = model.CreateTime;
            model.ResourceVersion = viewModel.MerchantApp.ResourceVersion;
            model.Email = viewModel.MerchantApp.Email;
            model.CopyRight = viewModel.MerchantApp.CopyRight;
            model.MetaDescription = viewModel.MerchantApp.MetaDescription;
            model.MetaKeyWords = viewModel.MerchantApp.MetaKeyWords;
            model.MetaTitle = viewModel.MerchantApp.MetaTitle;
            model.WebURL = viewModel.MerchantApp.WebURL;

            var request = XCLCMS.Lib.WebAPI.Library.CreateRequest<XCLCMS.Data.Model.MerchantApp>(base.UserToken);
            request.Body = model;
            var response = XCLCMS.Lib.WebAPI.MerchantAppAPI.Update(request);

            return Json(response);
        }
    }
}