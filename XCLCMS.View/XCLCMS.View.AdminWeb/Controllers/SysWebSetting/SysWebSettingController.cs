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
            XCLCMS.View.AdminViewModel.SysWebSetting.SysWebSettingListVM viewModel = new AdminViewModel.SysWebSetting.SysWebSettingListVM();

            #region 初始化查询条件

            viewModel.Search = new XCLNetSearch.Search();
            viewModel.Search.TypeList = new List<XCLNetSearch.SearchFieldInfo>() {
                new XCLNetSearch.SearchFieldInfo("配置ID","SysWebSettingID|number|text",""),
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

            XCLCMS.Data.BLL.SysWebSetting bll = new Data.BLL.SysWebSetting();
            viewModel.SysWebSettingList = bll.GetPageList(base.PageParamsInfo, strWhere, "", "[SysWebSettingID]", "[KeyName] asc");
            viewModel.PagerModel = base.PageParamsInfo;
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

            XCLCMS.Data.BLL.SysWebSetting bll = new Data.BLL.SysWebSetting();
            XCLCMS.View.AdminViewModel.SysWebSetting.SysWebSettingAddVM viewModel = new AdminViewModel.SysWebSetting.SysWebSettingAddVM();

            switch (base.CurrentHandleType)
            {
                case XCLCMS.Lib.Common.Comm.HandleType.ADD:
                    viewModel.SysWebSetting = new Data.Model.SysWebSetting();
                    viewModel.FormAction = Url.Action("AddSubmit", "SysWebSetting");
                    break;

                case XCLCMS.Lib.Common.Comm.HandleType.UPDATE:
                    viewModel.SysWebSetting = bll.GetModel(sysWebSettingID);
                    viewModel.FormAction = Url.Action("UpdateSubmit", "SysWebSetting");
                    break;
            }

            return View("~/Views/SysWebSetting/SysWebSettingAdd.cshtml", viewModel);
        }

        /// <summary>
        /// 将表单值转为viewModel
        /// </summary>
        private XCLCMS.View.AdminViewModel.SysWebSetting.SysWebSettingAddVM GetViewModel(FormCollection fm)
        {
            XCLCMS.View.AdminViewModel.SysWebSetting.SysWebSettingAddVM viewModel = new AdminViewModel.SysWebSetting.SysWebSettingAddVM();
            viewModel.SysWebSetting = new Data.Model.SysWebSetting();
            viewModel.SysWebSetting.KeyName = (fm["txtKeyName"] ?? "").Trim();
            viewModel.SysWebSetting.KeyValue = (fm["txtKeyValue"] ?? "").Trim();
            viewModel.SysWebSetting.Remark = (fm["txtRemark"] ?? "").Trim();
            return viewModel;
        }

        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysWebSettingAdd)]
        public override ActionResult AddSubmit(FormCollection fm)
        {
            base.AddSubmit(fm);
            XCLCMS.View.AdminViewModel.SysWebSetting.SysWebSettingAddVM viewModel = this.GetViewModel(fm);

            XCLCMS.Data.BLL.SysWebSetting bll = new Data.BLL.SysWebSetting();
            XCLCMS.Data.Model.SysWebSetting model = null;
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
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
            model.SysWebSettingID = XCLCMS.Data.BLL.Common.Common.GenerateID(Data.CommonHelper.EnumType.IDTypeEnum.SET);
            if (bll.Add(model))
            {
                msgModel.Message = "添加成功！";
                msgModel.IsSuccess = true;
            }
            else
            {
                msgModel.Message = "添加失败！";
                msgModel.IsSuccess = false;
            }
            return Json(msgModel);
        }

        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysWebSettingEdit)]
        public override ActionResult UpdateSubmit(FormCollection fm)
        {
            base.UpdateSubmit(fm);
            long sysWebSettingID = XCLNetTools.StringHander.FormHelper.GetLong("SysWebSettingID");
            XCLCMS.View.AdminViewModel.SysWebSetting.SysWebSettingAddVM viewModel = this.GetViewModel(fm);
            XCLCMS.Data.BLL.SysWebSetting bll = new Data.BLL.SysWebSetting();
            XCLCMS.Data.Model.SysWebSetting model = null;
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            model = bll.GetModel(sysWebSettingID);
            model.KeyName = viewModel.SysWebSetting.KeyName;
            model.KeyValue = viewModel.SysWebSetting.KeyValue;
            model.UpdaterID = base.CurrentUserModel.UserInfoID;
            model.UpdaterName = base.CurrentUserModel.UserName;
            model.UpdateTime = DateTime.Now;
            model.Remark = viewModel.SysWebSetting.Remark;
            if (bll.Update(model))
            {
                msgModel.Message = "修改成功！";
                msgModel.IsSuccess = true;
            }
            else
            {
                msgModel.Message = "修改失败！";
                msgModel.IsSuccess = false;
            }
            return Json(msgModel);
        }

        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysWebSettingDel)]
        public override ActionResult DelSubmit(FormCollection fm)
        {
            base.DelSubmit(fm);
            XCLCMS.Data.BLL.SysWebSetting bll = new Data.BLL.SysWebSetting();
            XCLCMS.Data.Model.SysWebSetting model = null;
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            DateTime dtNow = DateTime.Now;
            long[] ids = XCLNetTools.Common.DataTypeConvert.GetLongArrayByStringArray(XCLNetTools.StringHander.FormHelper.GetString("SysWebSettingIDs").Split(','));
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i] <= 0) continue;
                model = bll.GetModel(ids[i]);
                if (null != model)
                {
                    model.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.D.ToString();
                    model.UpdaterID = base.CurrentUserModel.UserInfoID;
                    model.UpdaterName = base.CurrentUserModel.UserName;
                    model.UpdateTime = dtNow;
                    bll.Update(model);
                }
            }
            msgModel.IsSuccess = true;
            msgModel.IsRefresh = true;
            msgModel.Message = "删除成功！";
            return Json(msgModel);
        }
    }
}