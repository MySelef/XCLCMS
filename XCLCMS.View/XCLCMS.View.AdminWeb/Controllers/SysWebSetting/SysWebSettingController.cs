using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.SysWebSetting
{
    /// <summary>
    /// 配置controller
    /// </summary>
    public class SysWebSettingController : BaseController
    {
        /// <summary>
        /// 配置列表
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysWebSettingView)]
        public ActionResult Index()
        {
            XCLCMS.View.AdminWeb.Models.SysWebSetting.SysWebSettingListVM viewModel = new XCLCMS.View.AdminWeb.Models.SysWebSetting.SysWebSettingListVM();

            #region 初始化查询条件

            viewModel.Search = new XCLNetSearch.Search();
            viewModel.Search.TypeList = new List<XCLNetSearch.SearchFieldInfo>() {
                new XCLNetSearch.SearchFieldInfo("配置ID","SysWebSettingID|number|text",""),
                new XCLNetSearch.SearchFieldInfo("所属商户ID","FK_MerchantID|number|text",""),
                new XCLNetSearch.SearchFieldInfo("所属应用ID","FK_MerchantAppID|number|text",""),
                new XCLNetSearch.SearchFieldInfo("所属商户名","MerchantName|string|text",""),
                new XCLNetSearch.SearchFieldInfo("所属应用名","MerchantAppName|string|text",""),
                new XCLNetSearch.SearchFieldInfo("名称","KeyName|string|text",""),
                new XCLNetSearch.SearchFieldInfo("值","KeyValue|string|text",""),
                new XCLNetSearch.SearchFieldInfo("说明","Remark|string|text",""),
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
            var response = XCLCMS.Lib.WebAPI.SysWebSettingAPI.PageList(request).Body;
            viewModel.SysWebSettingList = response.ResultList;
            viewModel.PagerModel = response.PagerInfo;

            return View("~/Views/SysWebSetting/SysWebSettingList.cshtml", viewModel);
        }

        /// <summary>
        /// 添加与编辑页面首页
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysWebSettingAdd)]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysWebSettingEdit)]
        public ActionResult Add()
        {
            long sysWebSettingID = XCLNetTools.StringHander.FormHelper.GetLong("SysWebSettingID");

            XCLCMS.View.AdminWeb.Models.SysWebSetting.SysWebSettingAddVM viewModel = new XCLCMS.View.AdminWeb.Models.SysWebSetting.SysWebSettingAddVM();

            switch (base.CurrentHandleType)
            {
                case XCLCMS.Lib.Common.Comm.HandleType.ADD:
                    viewModel.SysWebSetting = new Data.Model.SysWebSetting();
                    viewModel.FormAction = Url.Action("AddSubmit", "SysWebSetting");
                    break;

                case XCLCMS.Lib.Common.Comm.HandleType.UPDATE:
                    var request = XCLCMS.Lib.WebAPI.Library.CreateRequest<long>(base.UserToken);
                    request.Body = sysWebSettingID;
                    var response = XCLCMS.Lib.WebAPI.SysWebSettingAPI.Detail(request);

                    viewModel.SysWebSetting = response.Body;
                    viewModel.FormAction = Url.Action("UpdateSubmit", "SysWebSetting");
                    break;
            }

            return View("~/Views/SysWebSetting/SysWebSettingAdd.cshtml", viewModel);
        }

        /// <summary>
        /// 将表单值转为viewModel
        /// </summary>
        private XCLCMS.View.AdminWeb.Models.SysWebSetting.SysWebSettingAddVM GetViewModel(FormCollection fm)
        {
            XCLCMS.View.AdminWeb.Models.SysWebSetting.SysWebSettingAddVM viewModel = new XCLCMS.View.AdminWeb.Models.SysWebSetting.SysWebSettingAddVM();
            viewModel.SysWebSetting = new Data.Model.SysWebSetting();
            viewModel.SysWebSetting.KeyName = (fm["txtKeyName"] ?? "").Trim();
            viewModel.SysWebSetting.KeyValue = (fm["txtKeyValue"] ?? "").Trim();
            viewModel.SysWebSetting.Remark = (fm["txtRemark"] ?? "").Trim();
            viewModel.SysWebSetting.FK_MerchantAppID = XCLNetTools.StringHander.FormHelper.GetLong("txtMerchantAppID");
            return viewModel;
        }

        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysWebSettingAdd)]
        public override ActionResult AddSubmit(FormCollection fm)
        {
            base.AddSubmit(fm);
            XCLCMS.View.AdminWeb.Models.SysWebSetting.SysWebSettingAddVM viewModel = this.GetViewModel(fm);

            XCLCMS.Data.Model.SysWebSetting model = null;
            model = new Data.Model.SysWebSetting();
            model.CreaterID = base.CurrentUserModel.UserInfoID;
            model.CreaterName = base.CurrentUserModel.UserName;
            model.CreateTime = DateTime.Now;
            model.UpdaterID = base.CurrentUserModel.UserInfoID;
            model.UpdaterName = base.CurrentUserModel.UserName;
            model.UpdateTime = DateTime.Now;
            model.KeyName = viewModel.SysWebSetting.KeyName;
            model.KeyValue = viewModel.SysWebSetting.KeyValue;
            model.Remark = viewModel.SysWebSetting.Remark;
            model.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString();
            model.SysWebSettingID = XCLCMS.Lib.WebAPI.Library.CommonAPI_GenerateID(base.UserToken, new Data.WebAPIEntity.RequestEntity.Common.GenerateIDEntity()
            {
                IDType = Data.CommonHelper.EnumType.IDTypeEnum.SET.ToString()
            }); 
            model.FK_MerchantAppID = viewModel.SysWebSetting.FK_MerchantAppID;

            var request = XCLCMS.Lib.WebAPI.Library.CreateRequest<XCLCMS.Data.Model.SysWebSetting>(base.UserToken);
            request.Body = model;
            var response = XCLCMS.Lib.WebAPI.SysWebSettingAPI.Add(request);

            return Json(response);
        }

        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysWebSettingEdit)]
        public override ActionResult UpdateSubmit(FormCollection fm)
        {
            base.UpdateSubmit(fm);
            long sysWebSettingID = XCLNetTools.StringHander.FormHelper.GetLong("SysWebSettingID");
            XCLCMS.View.AdminWeb.Models.SysWebSetting.SysWebSettingAddVM viewModel = this.GetViewModel(fm);
            XCLCMS.Data.Model.SysWebSetting model = new Data.Model.SysWebSetting();
            model.SysWebSettingID = sysWebSettingID;
            model.KeyName = viewModel.SysWebSetting.KeyName;
            model.KeyValue = viewModel.SysWebSetting.KeyValue;
            model.UpdaterID = base.CurrentUserModel.UserInfoID;
            model.UpdaterName = base.CurrentUserModel.UserName;
            model.UpdateTime = DateTime.Now;
            model.Remark = viewModel.SysWebSetting.Remark;
            model.FK_MerchantAppID = viewModel.SysWebSetting.FK_MerchantAppID;

            var request = XCLCMS.Lib.WebAPI.Library.CreateRequest<XCLCMS.Data.Model.SysWebSetting>(base.UserToken);
            request.Body = model;
            var response = XCLCMS.Lib.WebAPI.SysWebSettingAPI.Update(request);

            return Json(response);
        }
    }
}