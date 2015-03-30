using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.SysFunction
{
    /// <summary>
    /// 功能controller
    /// </summary>
    public class SysFunctionController : BaseController
    {
        [XCLCMS.Lib.Filters.FunctionFilter(Function=XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysFunctionView)]
        public ActionResult Index()
        {
            XCLCMS.View.AdminViewModel.SysFunction.SysFunctionListVM viewModel = new AdminViewModel.SysFunction.SysFunctionListVM();

            #region 初始化查询条件
            viewModel.Search = new XCLNetSearch.Search();
            viewModel.Search.TypeList = new List<XCLNetSearch.SearchFieldInfo>() { 
                new XCLNetSearch.SearchFieldInfo("功能ID","SysFunctionID|number|text",""),
                new XCLNetSearch.SearchFieldInfo("所属模块","FK_TypeID|number|select",XCLCMS.Lib.Common.Tool.GetSysDicOptionsByCode(XCLCMS.Data.CommonHelper.SysDicConst.SysFunModules)),
                new XCLNetSearch.SearchFieldInfo("功能名称","FunctionName|string|text",""),
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
            #endregion

            XCLCMS.Data.BLL.View.v_SysFunction bll = new XCLCMS.Data.BLL.View.v_SysFunction();
            viewModel.SysFunctionList = bll.GetPageList(base.PageSize, base.PageIndex, ref base.RecordCount, strWhere, "", "[SysFunctionID]", "[SysFunctionID] desc");
            viewModel.PagerModel = new AdminViewModel.UserControl.XCLPagerVM()
            {
                RecordCount = base.RecordCount,
                PageIndex = base.PageIndex,
                PageSize = base.PageSize
            };
            return View("~/Views/SysFunction/SysFunctionList.cshtml",viewModel);
        }

        /// <summary>
        /// 添加与编辑页面首页
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysFunctionAdd)]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysFunctionEdit)]
        public ActionResult Add()
        {
            long sysFunctionID = XCLNetTools.StringHander.FormHelper.GetLong("SysFunctionID");

            XCLCMS.Data.BLL.SysFunction bll = new Data.BLL.SysFunction();
            XCLCMS.View.AdminViewModel.SysFunction.SysFunctionAddVM viewModel = new AdminViewModel.SysFunction.SysFunctionAddVM();

            switch (base.CurrentHandleType)
            {
                case XCLCMS.Lib.Common.Comm.HandleType.ADD:
                    viewModel.SysFunction = new Data.Model.SysFunction();
                    viewModel.FormAction = Url.Action("AddSubmit", "SysFunction");
                    break;
                case XCLCMS.Lib.Common.Comm.HandleType.UPDATE:
                    viewModel.SysFunction = bll.GetModel(sysFunctionID);
                    viewModel.FormAction = Url.Action("UpdateSubmit", "SysFunction");
                    break;
            }

            return View("~/Views/SysFunction/SysFunctionAdd.cshtml", viewModel);
        }

        /// <summary>
        /// 将表单值转为viewModel
        /// </summary>
        private XCLCMS.View.AdminViewModel.SysFunction.SysFunctionAddVM GetViewModel(FormCollection fm)
        {
            XCLCMS.View.AdminViewModel.SysFunction.SysFunctionAddVM viewModel = new AdminViewModel.SysFunction.SysFunctionAddVM();
            viewModel.SysFunction = new Data.Model.SysFunction();
            viewModel.SysFunction.FK_TypeID = XCLNetTools.StringHander.Common.GetLong(fm["selFK_TypeID"]);
            viewModel.SysFunction.FunctionName = (fm["txtFunctionName"] ?? "").Trim();
            viewModel.SysFunction.Remark= (fm["txtRemark"] ?? "").Trim();
            return viewModel;
        }

        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysFunctionAdd)]
        public override ActionResult AddSubmit(FormCollection fm)
        {
            base.AddSubmit(fm);
            XCLCMS.View.AdminViewModel.SysFunction.SysFunctionAddVM viewModel = this.GetViewModel(fm);

            XCLCMS.Data.BLL.SysFunction bll = new Data.BLL.SysFunction();
            XCLCMS.Data.Model.SysFunction model = null;
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            model = new Data.Model.SysFunction();
            model.CreaterID = base.CurrentUserModel.UserInfoID;
            model.CreaterName = base.CurrentUserModel.UserName;
            model.CreateTime = DateTime.Now;
            model.UpdaterID = base.CurrentUserModel.UserInfoID;
            model.UpdaterName = base.CurrentUserModel.UserName;
            model.UpdateTime = DateTime.Now;
            model.FK_TypeID = viewModel.SysFunction.FK_TypeID;
            model.FunctionName = viewModel.SysFunction.FunctionName;
            model.Remark = viewModel.SysFunction.Remark;
            model.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString();
            model.SysFunctionID = XCLCMS.Data.BLL.Common.Common.GenerateID(Data.CommonHelper.EnumType.IDTypeEnum.FUN);
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
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysFunctionEdit)]
        public override ActionResult UpdateSubmit(FormCollection fm)
        {
            base.UpdateSubmit(fm);
            long sysFunctionID = XCLNetTools.StringHander.FormHelper.GetLong("SysFunctionID");
            XCLCMS.View.AdminViewModel.SysFunction.SysFunctionAddVM viewModel = this.GetViewModel(fm);
            XCLCMS.Data.BLL.SysFunction bll = new Data.BLL.SysFunction();
            XCLCMS.Data.Model.SysFunction model = null;
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            model = bll.GetModel(sysFunctionID);
            model.FK_TypeID = viewModel.SysFunction.FK_TypeID;
            model.FunctionName = viewModel.SysFunction.FunctionName;
            model.UpdaterID = base.CurrentUserModel.UserInfoID;
            model.UpdaterName = base.CurrentUserModel.UserName;
            model.UpdateTime = DateTime.Now;
            model.Remark = viewModel.SysFunction.Remark;
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
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysFunctionDel)]
        public override ActionResult DelSubmit(FormCollection fm)
        {
            base.DelSubmit(fm);
            XCLCMS.Data.BLL.SysFunction bll = new Data.BLL.SysFunction();
            XCLCMS.Data.Model.SysFunction model = null;
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            DateTime dtNow = DateTime.Now;
            long[] ids = XCLNetTools.StringHander.Common.GetLongArrayByStringArray(XCLNetTools.StringHander.FormHelper.GetString("SysFunctionIDs").Split(','));
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
