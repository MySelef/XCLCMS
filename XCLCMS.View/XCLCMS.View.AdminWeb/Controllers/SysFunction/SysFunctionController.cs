using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.SysFunction
{
    /// <summary>
    /// 功能controller
    /// </summary>
    public class SysFunctionController : BaseController
    {
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysFunctionView)]
        public ActionResult Index()
        {
            return View("~/Views/SysFunction/SysFunctionList.cshtml");
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
                    viewModel.ParentID = sysFunctionID;
                    viewModel.SysFunctionID = -1;
                    viewModel.FormAction = Url.Action("AddSubmit", "SysFunction");
                    break;

                case XCLCMS.Lib.Common.Comm.HandleType.UPDATE:
                    viewModel.SysFunction = bll.GetModel(sysFunctionID);
                    viewModel.ParentID = viewModel.SysFunction.ParentID;
                    viewModel.SysFunctionID = viewModel.SysFunction.SysFunctionID;
                    viewModel.FormAction = Url.Action("UpdateSubmit", "SysFunction");
                    break;
            }

            viewModel.PathList = bll.GetLayerListBySysFunctionId(sysFunctionID);

            return View("~/Views/SysFunction/SysFunctionAdd.cshtml", viewModel);
        }

        /// <summary>
        /// 列表页中，ajax请求获取list
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysFunctionView)]
        public ActionResult GetList()
        {
            XCLCMS.Data.BLL.View.v_SysFunction bll = new Data.BLL.View.v_SysFunction();
            long parentID = XCLNetTools.StringHander.FormHelper.GetLong("id");
            List<XCLCMS.Data.Model.View.v_SysFunction> lst = bll.GetList(parentID);
            return XCLCMS.Lib.Common.Comm.XCLJsonResult(lst, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 将表单值转为viewModel
        /// </summary>
        private XCLCMS.View.AdminViewModel.SysFunction.SysFunctionAddVM GetViewModel(FormCollection fm)
        {
            XCLCMS.View.AdminViewModel.SysFunction.SysFunctionAddVM viewModel = new AdminViewModel.SysFunction.SysFunctionAddVM();
            viewModel.SysFunction = new Data.Model.SysFunction();
            viewModel.SysFunctionID = XCLNetTools.StringHander.Common.GetLong(fm["SysFunctionID"]);
            viewModel.ParentID = XCLNetTools.StringHander.Common.GetLong(fm["ParentID"]);
            viewModel.SysFunction.Code = (fm["txtCode"] ?? "").Trim();
            viewModel.SysFunction.FunctionName = (fm["txtFunctionName"] ?? "").Trim();
            viewModel.SysFunction.Remark = (fm["txtRemark"] ?? "").Trim();
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
            model.ParentID = viewModel.ParentID;
            model.FunctionName = viewModel.SysFunction.FunctionName;
            model.Remark = viewModel.SysFunction.Remark;
            model.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString();
            model.SysFunctionID = XCLCMS.Data.BLL.Common.Common.GenerateID(Data.CommonHelper.EnumType.IDTypeEnum.FUN);
            model.Code = viewModel.SysFunction.Code;
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
            XCLCMS.View.AdminViewModel.SysFunction.SysFunctionAddVM viewModel = this.GetViewModel(fm);
            XCLCMS.Data.BLL.SysFunction bll = new Data.BLL.SysFunction();
            XCLCMS.Data.Model.SysFunction model = null;
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            model = bll.GetModel(viewModel.SysFunctionID);
            model.FunctionName = viewModel.SysFunction.FunctionName;
            model.UpdaterID = base.CurrentUserModel.UserInfoID;
            model.UpdaterName = base.CurrentUserModel.UserName;
            model.UpdateTime = DateTime.Now;
            model.Remark = viewModel.SysFunction.Remark;
            model.Code = viewModel.SysFunction.Code;
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
            msgModel.Message = "删除成功！";
            return Json(msgModel);
        }

        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysFunctionDel)]
        public ActionResult DelChildSubmit(FormCollection fm)
        {
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            XCLCMS.Data.BLL.SysFunction bll = new Data.BLL.SysFunction();
            bll.DelChild(new Data.Model.SysFunction()
            {
                SysFunctionID = XCLNetTools.StringHander.FormHelper.GetLong("sysFunctionId"),
                UpdaterID = base.CurrentUserModel.UserInfoID,
                UpdaterName = base.CurrentUserModel.UserName,
                UpdateTime = DateTime.Now
            });
            msgModel.IsSuccess = true;
            msgModel.Message = "子节点清理成功！";
            return Json(msgModel);
        }
    }
}