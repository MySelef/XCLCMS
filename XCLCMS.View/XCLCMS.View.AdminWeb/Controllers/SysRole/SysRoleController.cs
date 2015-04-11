using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.SysRole
{
    /// <summary>
    /// 角色controller
    /// </summary>
    public class SysRoleController : BaseController
    {
        public ActionResult Index()
        {
            return View("~/Views/SysRole/SysRoleList.cshtml");
        }

        /// <summary>
        /// 添加与编辑页面首页
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_SysRoleAdd)]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_SysRoleEdit)]
        public ActionResult Add()
        {
            long sysRoleID = XCLNetTools.StringHander.FormHelper.GetLong("SysRoleID");

            XCLCMS.Data.BLL.SysRole bll = new Data.BLL.SysRole();
            XCLCMS.Data.BLL.SysFunction functionBLL = new Data.BLL.SysFunction();
            XCLCMS.View.AdminViewModel.SysRole.SysRoleAddVM viewModel = new AdminViewModel.SysRole.SysRoleAddVM();

            switch (base.CurrentHandleType)
            {
                case XCLCMS.Lib.Common.Comm.HandleType.ADD:
                    viewModel.SysRole = new Data.Model.SysRole();
                    viewModel.ParentID = sysRoleID;
                    viewModel.SysRoleID = -1;
                    viewModel.FormAction = Url.Action("AddSubmit", "SysRole");
                    break;
                case XCLCMS.Lib.Common.Comm.HandleType.UPDATE:
                    viewModel.SysRole = bll.GetModel(sysRoleID);
                    viewModel.ParentID = viewModel.SysRole.ParentID;
                    viewModel.SysRoleID = viewModel.SysRole.SysRoleID;
                    var roleHadFunctions = functionBLL.GetListByRoleID(sysRoleID);
                    if (null != roleHadFunctions && roleHadFunctions.Count > 0)
                    {
                        viewModel.RoleFunctionIDList = roleHadFunctions.Select(m => m.SysFunctionID).ToList();
                    }      
                    viewModel.FormAction = Url.Action("UpdateSubmit", "SysRole");
                    break;
            }

            viewModel.PathList = bll.GetLayerListBySysRoleID(sysRoleID);

            return View("~/Views/SysRole/SysRoleAdd.cshtml", viewModel);
        }

        /// <summary>
        /// 列表页中，ajax请求获取list
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_SysRoleView)]
        public ActionResult GetList()
        {
            XCLCMS.Data.BLL.View.v_SysRole bll = new Data.BLL.View.v_SysRole();
            long parentID = XCLNetTools.StringHander.FormHelper.GetLong("id");
            List<XCLCMS.Data.Model.View.v_SysRole> lst = bll.GetList(parentID);
            return XCLCMS.Lib.Common.Comm.XCLJsonResult(lst, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 将表单值转为viewModel
        /// </summary>
        private XCLCMS.View.AdminViewModel.SysRole.SysRoleAddVM GetViewModel(FormCollection fm)
        {
            XCLCMS.View.AdminViewModel.SysRole.SysRoleAddVM viewModel = new AdminViewModel.SysRole.SysRoleAddVM();
            viewModel.SysRole = new Data.Model.SysRole();
            viewModel.SysRoleID = XCLNetTools.StringHander.Common.GetLong(fm["SysRoleID"]);
            viewModel.ParentID = XCLNetTools.StringHander.Common.GetLong(fm["ParentID"]);
            viewModel.SysRole.Code = (fm["txtCode"] ?? "").Trim();
            viewModel.SysRole.RoleName = (fm["txtRoleName"] ?? "").Trim();
            viewModel.SysRole.Remark = (fm["txtRemark"] ?? "").Trim();
            viewModel.SysRole.Weight = XCLNetTools.StringHander.Common.GetIntNull(fm["txtWeight"]);
            viewModel.RoleFunctionIDList = XCLNetTools.StringHander.FormHelper.GetLongList("txtRoleFunction");
            return viewModel;
        }

        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_SysRoleAdd)]
        public override ActionResult AddSubmit(FormCollection fm)
        {
            base.AddSubmit(fm);
            XCLCMS.View.AdminViewModel.SysRole.SysRoleAddVM viewModel = this.GetViewModel(fm);

            XCLCMS.Data.BLL.SysRole bll = new Data.BLL.SysRole();
            XCLCMS.Data.Model.SysRole model = null;
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            model = new Data.Model.SysRole();
            model.CreaterID = base.CurrentUserModel.UserInfoID;
            model.CreaterName = base.CurrentUserModel.UserName;
            model.CreateTime = DateTime.Now;
            model.UpdaterID = base.CurrentUserModel.UserInfoID;
            model.UpdaterName = base.CurrentUserModel.UserName;
            model.UpdateTime = DateTime.Now;
            model.ParentID = viewModel.ParentID;
            model.RoleName = viewModel.SysRole.RoleName;
            model.Remark = viewModel.SysRole.Remark;
            model.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString();
            model.SysRoleID = XCLCMS.Data.BLL.Common.Common.GenerateID(Data.CommonHelper.EnumType.IDTypeEnum.RLE);
            model.Code = viewModel.SysRole.Code;
            model.Weight = viewModel.SysRole.Weight;

            XCLCMS.Data.BLL.Strategy.SysRole.SysRoleContext sysRoleContext = new Data.BLL.Strategy.SysRole.SysRoleContext();
            sysRoleContext.CurrentUserInfo = base.CurrentUserModel;
            sysRoleContext.SysRole = model;
            sysRoleContext.FunctionIdList = viewModel.RoleFunctionIDList;
            sysRoleContext.HandleType = Data.BLL.Strategy.StrategyLib.HandleType.ADD;

            XCLCMS.Data.BLL.Strategy.ExecuteStrategy strategy = new Data.BLL.Strategy.ExecuteStrategy(new List<Data.BLL.Strategy.BaseStrategy>() { 
                new XCLCMS.Data.BLL.Strategy.SysRole.SysRole(),
                new XCLCMS.Data.BLL.Strategy.SysRole.SysRoleFunction()
            });
            strategy.Execute<XCLCMS.Data.BLL.Strategy.SysRole.SysRoleContext>(sysRoleContext);

            if (strategy.Result != Data.BLL.Strategy.StrategyLib.ResultEnum.FAIL)
            {
                msgModel.Message = "添加成功！";
                msgModel.IsSuccess = true;
            }
            else
            {
                msgModel.Message = strategy.ResultMessage;
                msgModel.IsSuccess = false;
                XCLNetLogger.Log.WriteLog(XCLNetLogger.Config.LogConfig.LogLevel.ERROR, "添加角色信息失败", strategy.ResultMessage);
            }

            return Json(msgModel);
        }

        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_SysRoleEdit)]
        public override ActionResult UpdateSubmit(FormCollection fm)
        {
            base.UpdateSubmit(fm);
            XCLCMS.View.AdminViewModel.SysRole.SysRoleAddVM viewModel = this.GetViewModel(fm);
            XCLCMS.Data.BLL.SysRole bll = new Data.BLL.SysRole();
            XCLCMS.Data.Model.SysRole model = null;
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            model = bll.GetModel(viewModel.SysRoleID);
            model.RoleName = viewModel.SysRole.RoleName;
            model.UpdaterID = base.CurrentUserModel.UserInfoID;
            model.UpdaterName = base.CurrentUserModel.UserName;
            model.UpdateTime = DateTime.Now;
            model.Remark = viewModel.SysRole.Remark;
            model.Code = viewModel.SysRole.Code;
            model.Weight = viewModel.SysRole.Weight;

            XCLCMS.Data.BLL.Strategy.SysRole.SysRoleContext sysRoleContext = new Data.BLL.Strategy.SysRole.SysRoleContext();
            sysRoleContext.CurrentUserInfo = base.CurrentUserModel;
            sysRoleContext.SysRole = model;
            sysRoleContext.FunctionIdList = viewModel.RoleFunctionIDList;
            sysRoleContext.HandleType = Data.BLL.Strategy.StrategyLib.HandleType.UPDATE;

            XCLCMS.Data.BLL.Strategy.ExecuteStrategy strategy = new Data.BLL.Strategy.ExecuteStrategy(new List<Data.BLL.Strategy.BaseStrategy>() { 
                new XCLCMS.Data.BLL.Strategy.SysRole.SysRole(),
                new XCLCMS.Data.BLL.Strategy.SysRole.SysRoleFunction()
            });
            strategy.Execute<XCLCMS.Data.BLL.Strategy.SysRole.SysRoleContext>(sysRoleContext);

            if (strategy.Result != Data.BLL.Strategy.StrategyLib.ResultEnum.FAIL)
            {
                msgModel.Message = "修改成功！";
                msgModel.IsSuccess = true;
            }
            else
            {
                msgModel.Message = strategy.ResultMessage;
                msgModel.IsSuccess = false;
                XCLNetLogger.Log.WriteLog(XCLNetLogger.Config.LogConfig.LogLevel.ERROR, "修改角色信息失败", strategy.ResultMessage);
            }

            return Json(msgModel);
        }

        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_SysRoleDel)]
        public override ActionResult DelSubmit(FormCollection fm)
        {
            base.DelSubmit(fm);
            XCLCMS.Data.BLL.SysRole bll = new Data.BLL.SysRole();
            XCLCMS.Data.Model.SysRole model = null;
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            DateTime dtNow = DateTime.Now;
            long[] ids = XCLNetTools.StringHander.Common.GetLongArrayByStringArray(XCLNetTools.StringHander.FormHelper.GetString("SysRoleIDs").Split(','));
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
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_SysRoleDel)]
        public ActionResult DelChildSubmit(FormCollection fm)
        {
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            XCLCMS.Data.BLL.SysRole bll = new Data.BLL.SysRole();
            bll.DelChild(new Data.Model.SysRole()
            {
                SysRoleID = XCLNetTools.StringHander.FormHelper.GetLong("sysRoleId"),
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
