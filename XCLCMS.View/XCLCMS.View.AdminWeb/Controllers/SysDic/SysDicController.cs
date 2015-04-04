using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [XCLCMS.Lib.Filters.FunctionFilter(Function=XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysDicView)]
        public ActionResult Index()
        {
            return View("~/Views/SysDic/SysDicList.cshtml");
        }

        /// <summary>
        /// 列表页中，ajax请求获取list
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysDicView)]
        public ActionResult GetList()
        {
            XCLCMS.Data.BLL.View.v_SysDic bll = new Data.BLL.View.v_SysDic();
            long parentID = XCLNetTools.StringHander.FormHelper.GetLong("id");
            List<XCLCMS.Data.Model.View.v_SysDic> lst = bll.GetList(parentID, string.Format("RecordState='{0}'",XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString()));
            return XCLCMS.Lib.Common.Comm.XCLJsonResult(lst, JsonRequestBehavior.AllowGet);
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
            XCLCMS.Data.BLL.SysFunction functionBLL=new Data.BLL.SysFunction();
            XCLCMS.View.AdminViewModel.SysDic.SysDicAddVM viewModel = new AdminViewModel.SysDic.SysDicAddVM();

            //判断当前字典是否属于【角色】
            if (viewModel.SysDicCategory == AdminViewModel.SysDic.SysDicCategoryEnum.None)
            {
                var roles = XCLCMS.Lib.Permission.PerHelper.GetRoleList();
                if (null != roles && roles.Count > 0)
                {
                    if (roles.Exists(k => k.SysDicID == sysDicId || (k.ParentID==sysDicId && base.CurrentHandleType==Lib.Common.Comm.HandleType.ADD)))
                    {
                        viewModel.SysDicCategory = AdminViewModel.SysDic.SysDicCategoryEnum.Role;
                        viewModel.FunctionList = XCLCMS.Lib.Permission.PerHelper.GetFunctionList();
                    }
                }
            }

            //判断当前字典是否属于【系统菜单】
            if (viewModel.SysDicCategory == AdminViewModel.SysDic.SysDicCategoryEnum.None)
            {
                var menus = new XCLCMS.Data.BLL.View.v_SysDic_SysMenu().GetModelList("");
                if (null != menus && menus.Count > 0)
                {
                    if (menus.Exists(k => k.SysDicID == sysDicId || (k.ParentID==sysDicId && base.CurrentHandleType==Lib.Common.Comm.HandleType.ADD)))
                    {
                        viewModel.SysDicCategory = AdminViewModel.SysDic.SysDicCategoryEnum.SysMenu;
                    }
                }
            }


            switch (base.CurrentHandleType)
            {
                case XCLCMS.Lib.Common.Comm.HandleType.ADD:
                    viewModel.SysDic = new Data.Model.SysDic();
                    viewModel.SysDic.DicType = XCLCMS.Data.CommonHelper.EnumType.DicTypeEnum.U.ToString();
                    viewModel.ParentID = sysDicId;
                    viewModel.SysDicID = -1;
                    viewModel.SysDic.Code = XCLNetTools.StringHander.RandomHelper.GenerateStringId();
                    viewModel.FormAction = Url.Action("AddSubmit", "SysDic");
                    break;
                case XCLCMS.Lib.Common.Comm.HandleType.UPDATE:
                    viewModel.SysDicID = sysDicId;
                    viewModel.SysDic = bll.GetModel(sysDicId);
                    viewModel.ParentID = viewModel.SysDic.ParentID;
                    if (viewModel.SysDicCategory == AdminViewModel.SysDic.SysDicCategoryEnum.Role)
                    {
                        var roleHadFunctions = functionBLL.GetListByRoleID(sysDicId);
                        if (null != roleHadFunctions && roleHadFunctions.Count > 0)
                        {
                            viewModel.RoleFunctionIDList = roleHadFunctions.Select(m => m.SysFunctionID).ToList();
                        }                    
                    }
                    viewModel.FormAction = Url.Action("UpdateSubmit", "SysDic");
                    break;
            }

            viewModel.PathList = bll.GetLayerListBySysDicID(sysDicId);

            return View("~/Views/SysDic/SysDicAdd.cshtml", viewModel);
        }

        /// <summary>
        /// 将表单值转为viewModel
        /// </summary>
        private XCLCMS.View.AdminViewModel.SysDic.SysDicAddVM GetViewModel(FormCollection fm)
        {
            XCLCMS.View.AdminViewModel.SysDic.SysDicAddVM viewModel = new AdminViewModel.SysDic.SysDicAddVM();
            viewModel.SysDic = new Data.Model.SysDic();
            viewModel.SysDicID = XCLNetTools.StringHander.Common.GetLong(fm["SysDicID"]);
            viewModel.ParentID = XCLNetTools.StringHander.Common.GetLong(fm["ParentID"]);
            viewModel.SysDic.Code = (fm["txtCode"] ?? "").Trim();
            viewModel.SysDic.DicName = (fm["txtDicName"] ?? "").Trim();
            viewModel.SysDic.DicType = (fm["selDicType"] ?? "").Trim();
            viewModel.SysDic.DicValue = (fm["txtDicValue"] ?? "").Trim();
            viewModel.SysDic.Sort = XCLNetTools.StringHander.Common.GetInt(fm["txtSort"] ?? "");
            viewModel.SysDic.Remark = (fm["txtRemark"] ?? "").Trim();
            viewModel.SysDic.Weight = XCLNetTools.StringHander.Common.GetIntNull(fm["txtWeight"] ?? "");
            viewModel.SysDic.FK_FunctionID = XCLNetTools.StringHander.Common.GetLongNull(fm["selFunctionID"] ?? "");
            viewModel.RoleFunctionIDList = XCLNetTools.StringHander.FormHelper.GetLongList("ckRoleFunction");
            return viewModel;
        }

        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysDicAdd)]
        public override ActionResult AddSubmit(FormCollection fm)
        {
            base.AddSubmit(fm);
            XCLCMS.View.AdminViewModel.SysDic.SysDicAddVM viewModel = this.GetViewModel(fm);

            XCLCMS.Data.BLL.SysDic sysDicBLL = new Data.BLL.SysDic();
            XCLCMS.Data.Model.SysDic sysDicModel = new Data.Model.SysDic();
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();

            sysDicModel.Code = viewModel.SysDic.Code;
            sysDicModel.CreaterID = base.CurrentUserModel.UserInfoID;
            sysDicModel.CreaterName = base.CurrentUserModel.UserName;
            sysDicModel.CreateTime = DateTime.Now;
            sysDicModel.UpdaterID = base.CurrentUserModel.UserInfoID;
            sysDicModel.UpdaterName = base.CurrentUserModel.UserName;
            sysDicModel.UpdateTime = DateTime.Now;
            sysDicModel.DicName = viewModel.SysDic.DicName;
            sysDicModel.DicType = viewModel.SysDic.DicType;
            sysDicModel.DicValue = viewModel.SysDic.DicValue;
            sysDicModel.ParentID = viewModel.ParentID;
            sysDicModel.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString();
            sysDicModel.Sort = viewModel.SysDic.Sort;
            sysDicModel.Remark = viewModel.SysDic.Remark;
            sysDicModel.Weight = viewModel.SysDic.Weight;
            sysDicModel.FK_FunctionID = viewModel.SysDic.FK_FunctionID;
            sysDicModel.SysDicID = XCLCMS.Data.BLL.Common.Common.GenerateID(Data.CommonHelper.EnumType.IDTypeEnum.DIC);

            XCLCMS.Data.BLL.Strategy.SysDic.SysDicContext sysDicContext = new Data.BLL.Strategy.SysDic.SysDicContext();
            sysDicContext.CurrentUserInfo = base.CurrentUserModel;
            sysDicContext.FunctionIdList = viewModel.RoleFunctionIDList;
            sysDicContext.HandleType = Data.BLL.Strategy.StrategyLib.HandleType.ADD;
            sysDicContext.SysDic = sysDicModel;

            XCLCMS.Data.BLL.Strategy.ExecuteStrategy strategy = new Data.BLL.Strategy.ExecuteStrategy(new List<Data.BLL.Strategy.BaseStrategy>() { 
                new XCLCMS.Data.BLL.Strategy.SysDic.SysDic(),
                new XCLCMS.Data.BLL.Strategy.SysDic.SysRoleFunction()
            });
            strategy.Execute<XCLCMS.Data.BLL.Strategy.SysDic.SysDicContext>(sysDicContext);

            if (strategy.Result != Data.BLL.Strategy.StrategyLib.ResultEnum.FAIL)
            {
                msgModel.Message = "添加成功！";
                msgModel.IsSuccess = true;
            }
            else
            {
                msgModel.Message = strategy.ResultMessage;
                msgModel.IsSuccess = false;
                XCLNetLogger.Log.WriteLog(XCLNetLogger.Config.LogConfig.LogLevel.ERROR, "添加字典库失败", strategy.ResultMessage);
            }

            return Json(msgModel);
        }

        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysDicEdit)]
        public override ActionResult UpdateSubmit(FormCollection fm)
        {
            base.UpdateSubmit(fm);
            XCLCMS.View.AdminViewModel.SysDic.SysDicAddVM viewModel = this.GetViewModel(fm);

            XCLCMS.Data.BLL.SysDic sysDicBLL = new Data.BLL.SysDic();
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            XCLCMS.Data.Model.SysDic sysDicModel = sysDicBLL.GetModel(viewModel.SysDicID);
            sysDicModel.Code = viewModel.SysDic.Code;
            sysDicModel.UpdaterID = base.CurrentUserModel.UserInfoID;
            sysDicModel.UpdaterName = base.CurrentUserModel.UserName;
            sysDicModel.UpdateTime = DateTime.Now;
            sysDicModel.DicName = viewModel.SysDic.DicName;
            sysDicModel.DicType = viewModel.SysDic.DicType;
            sysDicModel.DicValue = viewModel.SysDic.DicValue;
            sysDicModel.Sort = viewModel.SysDic.Sort;
            sysDicModel.Remark = viewModel.SysDic.Remark;
            sysDicModel.Weight = viewModel.SysDic.Weight;
            sysDicModel.FK_FunctionID = viewModel.SysDic.FK_FunctionID;


            XCLCMS.Data.BLL.Strategy.SysDic.SysDicContext sysDicContext = new Data.BLL.Strategy.SysDic.SysDicContext();
            sysDicContext.CurrentUserInfo = base.CurrentUserModel;
            sysDicContext.FunctionIdList = viewModel.RoleFunctionIDList;
            sysDicContext.HandleType = Data.BLL.Strategy.StrategyLib.HandleType.UPDATE;
            sysDicContext.SysDic = sysDicModel;

            XCLCMS.Data.BLL.Strategy.ExecuteStrategy strategy = new Data.BLL.Strategy.ExecuteStrategy(new List<Data.BLL.Strategy.BaseStrategy>() { 
                new XCLCMS.Data.BLL.Strategy.SysDic.SysDic(),
                new XCLCMS.Data.BLL.Strategy.SysDic.SysRoleFunction()
            });
            strategy.Execute<XCLCMS.Data.BLL.Strategy.SysDic.SysDicContext>(sysDicContext);

            if (strategy.Result != Data.BLL.Strategy.StrategyLib.ResultEnum.FAIL)
            {
                msgModel.Message = "修改成功！";
                msgModel.IsSuccess = true;
            }
            else
            {
                msgModel.Message = strategy.ResultMessage;
                msgModel.IsSuccess = false;
                XCLNetLogger.Log.WriteLog(XCLNetLogger.Config.LogConfig.LogLevel.ERROR, "修改字典库失败", strategy.ResultMessage);
            }

            return Json(msgModel);
        }

        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysDicDel)]
        public override ActionResult DelSubmit(FormCollection fm)
        {
            base.DelSubmit(fm);
            XCLCMS.Data.BLL.SysDic sysDicBLL = new Data.BLL.SysDic();
            XCLCMS.Data.Model.SysDic sysDicModel = null;
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            long[] sysDicIds = XCLNetTools.StringHander.Common.GetLongArrayByStringArray(XCLNetTools.StringHander.FormHelper.GetString("SysDicIds").Split(','));
            if (null != sysDicIds && sysDicIds.Length > 0)
            {
                for (int i = 0; i < sysDicIds.Length; i++)
                {
                    sysDicModel = sysDicBLL.GetModel(sysDicIds[i]);
                    if (null != sysDicModel && !string.Equals(sysDicModel.DicType,XCLCMS.Data.CommonHelper.EnumType.DicTypeEnum.S.ToString()))
                    {
                        sysDicModel.UpdaterID = base.CurrentUserModel.UserInfoID;
                        sysDicModel.UpdaterName = base.CurrentUserModel.UserName;
                        sysDicModel.UpdateTime = DateTime.Now;
                        sysDicModel.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.D.ToString();
                        sysDicBLL.Update(sysDicModel);
                    }
                }
            }
            msgModel.IsSuccess = true;
            msgModel.Message = "删除成功！";
            return Json(msgModel);
        }

        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysDicDel)]
        public ActionResult DelChildSubmit(FormCollection fm)
        {
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            XCLCMS.Data.BLL.SysDic bll = new Data.BLL.SysDic();
            bll.DelChild(new Data.Model.SysDic() { 
                SysDicID=XCLNetTools.StringHander.FormHelper.GetLong("sysDicID"),
                UpdaterID=base.CurrentUserModel.UserInfoID,
                UpdaterName=base.CurrentUserModel.UserName,
                UpdateTime=DateTime.Now
            });
            msgModel.IsSuccess = true;
            msgModel.Message = "子节点清理成功！";
            return Json(msgModel);
        }

    }
}
