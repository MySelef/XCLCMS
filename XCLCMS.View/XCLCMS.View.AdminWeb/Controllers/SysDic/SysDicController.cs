using System;
using System.Web.Mvc;
using XCLNetTools.Generic;

namespace XCLCMS.View.AdminWeb.Controllers.SysDic
{
    /// <summary>
    /// 字典库controller
    /// </summary>
    public class SysDicController : BaseController
    {
        /// <summary>
        /// 列表页
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysDicView)]
        public ActionResult Index()
        {
            return View("~/Views/SysDic/SysDicList.cshtml");
        }

        /// <summary>
        /// 添加或修改的页面
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysDicAdd)]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysDicEdit)]
        public ActionResult Add()
        {
            long sysDicId = XCLNetTools.StringHander.FormHelper.GetLong("sysDicId");
            XCLCMS.Data.BLL.SysDic bll = new Data.BLL.SysDic();
            XCLCMS.Data.BLL.SysFunction functionBLL = new Data.BLL.SysFunction();
            XCLCMS.View.AdminWeb.Models.SysDic.SysDicAddVM viewModel = new XCLCMS.View.AdminWeb.Models.SysDic.SysDicAddVM();

            //判断当前字典是否属于【系统菜单】
            if (viewModel.SysDicCategory == XCLCMS.View.AdminWeb.Models.SysDic.SysDicCategoryEnum.None)
            {
                var menus = new XCLCMS.Data.BLL.View.v_SysDic_SysMenu().GetModelList("");
                if (menus.IsNotNullOrEmpty())
                {
                    if (menus.Exists(k => k.SysDicID == sysDicId || (k.ParentID == sysDicId && base.CurrentHandleType == Lib.Common.Comm.HandleType.ADD)))
                    {
                        viewModel.SysDicCategory = XCLCMS.View.AdminWeb.Models.SysDic.SysDicCategoryEnum.SysMenu;
                    }
                }
            }

            switch (base.CurrentHandleType)
            {
                case XCLCMS.Lib.Common.Comm.HandleType.ADD:
                    viewModel.SysDic = new Data.Model.SysDic();
                    viewModel.ParentID = sysDicId;
                    viewModel.SysDicID = -1;
                    viewModel.FormAction = Url.Action("AddSubmit", "SysDic");
                    break;

                case XCLCMS.Lib.Common.Comm.HandleType.UPDATE:

                    var request = XCLCMS.Lib.WebAPI.Library.CreateRequest<long>(base.UserToken);
                    request.Body = sysDicId;
                    var response = XCLCMS.Lib.WebAPI.SysDicAPI.Detail(request);

                    viewModel.SysDicID = response.Body.SysDicID;
                    viewModel.SysDic = response.Body;
                    viewModel.ParentID = viewModel.SysDic.ParentID;
                    viewModel.FormAction = Url.Action("UpdateSubmit", "SysDic");
                    break;
            }

            viewModel.PathList = bll.GetLayerListBySysDicID(sysDicId);

            return View("~/Views/SysDic/SysDicAdd.cshtml", viewModel);
        }

        /// <summary>
        /// 将表单值转为viewModel
        /// </summary>
        private XCLCMS.View.AdminWeb.Models.SysDic.SysDicAddVM GetViewModel(FormCollection fm)
        {
            XCLCMS.View.AdminWeb.Models.SysDic.SysDicAddVM viewModel = new XCLCMS.View.AdminWeb.Models.SysDic.SysDicAddVM();
            viewModel.SysDic = new Data.Model.SysDic();
            viewModel.SysDicID = XCLNetTools.Common.DataTypeConvert.ToLong(fm["SysDicID"]);
            viewModel.ParentID = XCLNetTools.Common.DataTypeConvert.ToLong(fm["ParentID"]);
            viewModel.SysDic.Code = (fm["txtCode"] ?? "").Trim();
            viewModel.SysDic.DicName = (fm["txtDicName"] ?? "").Trim();
            viewModel.SysDic.DicValue = (fm["txtDicValue"] ?? "").Trim();
            viewModel.SysDic.Sort = XCLNetTools.Common.DataTypeConvert.ToInt(fm["txtSort"] ?? "");
            viewModel.SysDic.Remark = (fm["txtRemark"] ?? "").Trim();
            viewModel.SysDic.FK_FunctionID = XCLNetTools.Common.DataTypeConvert.ToLongNull(fm["txtFunctionID"] ?? "");
            viewModel.SysDic.FK_MerchantAppID = XCLNetTools.Common.DataTypeConvert.ToLong(fm["txtMerchantAppID"]);
            return viewModel;
        }

        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysDicAdd)]
        public override ActionResult AddSubmit(FormCollection fm)
        {
            base.AddSubmit(fm);
            XCLCMS.View.AdminWeb.Models.SysDic.SysDicAddVM viewModel = this.GetViewModel(fm);

            XCLCMS.Data.Model.SysDic sysDicModel = new Data.Model.SysDic();

            sysDicModel.Code = viewModel.SysDic.Code;
            sysDicModel.CreaterID = base.CurrentUserModel.UserInfoID;
            sysDicModel.CreaterName = base.CurrentUserModel.UserName;
            sysDicModel.CreateTime = DateTime.Now;
            sysDicModel.UpdaterID = base.CurrentUserModel.UserInfoID;
            sysDicModel.UpdaterName = base.CurrentUserModel.UserName;
            sysDicModel.UpdateTime = DateTime.Now;
            sysDicModel.DicName = viewModel.SysDic.DicName;
            sysDicModel.DicValue = viewModel.SysDic.DicValue;
            sysDicModel.ParentID = viewModel.ParentID;
            sysDicModel.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString();
            sysDicModel.Sort = viewModel.SysDic.Sort;
            sysDicModel.Remark = viewModel.SysDic.Remark;
            sysDicModel.FK_FunctionID = viewModel.SysDic.FK_FunctionID;
            sysDicModel.SysDicID = XCLCMS.Data.BLL.Common.Common.GenerateID(Data.CommonHelper.EnumType.IDTypeEnum.DIC);
            sysDicModel.FK_MerchantAppID = viewModel.SysDic.FK_MerchantAppID;

            var request = XCLCMS.Lib.WebAPI.Library.CreateRequest<XCLCMS.Data.Model.SysDic>(base.UserToken);
            request.Body = sysDicModel;
            var response = XCLCMS.Lib.WebAPI.SysDicAPI.Add(request);

            return Json(response);
        }

        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysDicEdit)]
        public override ActionResult UpdateSubmit(FormCollection fm)
        {
            base.UpdateSubmit(fm);
            XCLCMS.View.AdminWeb.Models.SysDic.SysDicAddVM viewModel = this.GetViewModel(fm);

            XCLCMS.Data.BLL.SysDic sysDicBLL = new Data.BLL.SysDic();
            XCLCMS.Data.Model.SysDic sysDicModel = sysDicBLL.GetModel(viewModel.SysDicID);
            sysDicModel.Code = viewModel.SysDic.Code;
            sysDicModel.UpdaterID = base.CurrentUserModel.UserInfoID;
            sysDicModel.UpdaterName = base.CurrentUserModel.UserName;
            sysDicModel.UpdateTime = DateTime.Now;
            sysDicModel.DicName = viewModel.SysDic.DicName;
            sysDicModel.DicValue = viewModel.SysDic.DicValue;
            sysDicModel.Sort = viewModel.SysDic.Sort;
            sysDicModel.Remark = viewModel.SysDic.Remark;
            sysDicModel.FK_FunctionID = viewModel.SysDic.FK_FunctionID;
            sysDicModel.FK_MerchantAppID = viewModel.SysDic.FK_MerchantAppID;

            var request = XCLCMS.Lib.WebAPI.Library.CreateRequest<XCLCMS.Data.Model.SysDic>(base.UserToken);
            request.Body = sysDicModel;
            var response = XCLCMS.Lib.WebAPI.SysDicAPI.Update(request);

            return Json(response);
        }
    }
}