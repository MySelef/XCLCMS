using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.SysDic
{
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

            var roles = XCLCMS.Lib.Permission.PerHelper.GetRoleList();
            if (null != roles && roles.Count > 0)
            {
                if (roles.Exists(k => k.SysDicID == sysDicId))
                {
                    viewModel.SysDicCategory = AdminViewModel.SysDic.SysDicCategoryEnum.Role;
                    viewModel.FunctionList = XCLCMS.Lib.Permission.PerHelper.GetFunctionList();
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
            XCLCMS.Data.Model.Custom.SysDicWithMore sysDicModel = new Data.Model.Custom.SysDicWithMore();
            sysDicModel.SysDic = new Data.Model.SysDic();
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();

            sysDicModel.SysDic.Code = viewModel.SysDic.Code;
            sysDicModel.SysDic.CreaterID = base.CurrentUserModel.UserInfoID;
            sysDicModel.SysDic.CreaterName = base.CurrentUserModel.UserName;
            sysDicModel.SysDic.CreateTime = DateTime.Now;
            sysDicModel.SysDic.UpdaterID = base.CurrentUserModel.UserInfoID;
            sysDicModel.SysDic.UpdaterName = base.CurrentUserModel.UserName;
            sysDicModel.SysDic.UpdateTime = DateTime.Now;
            sysDicModel.SysDic.DicName = viewModel.SysDic.DicName;
            sysDicModel.SysDic.DicType = viewModel.SysDic.DicType;
            sysDicModel.SysDic.DicValue = viewModel.SysDic.DicValue;
            sysDicModel.SysDic.ParentID = viewModel.ParentID;
            sysDicModel.SysDic.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString();
            sysDicModel.SysDic.Sort = viewModel.SysDic.Sort;
            sysDicModel.SysDic.Remark = viewModel.SysDic.Remark;
            sysDicModel.SysDic.Weight = viewModel.SysDic.Weight;
            sysDicModel.SysDic.FK_FunctionID = viewModel.SysDic.FK_FunctionID;
            sysDicModel.SysDic.SysDicID = XCLCMS.Data.BLL.Common.Common.GenerateID(Data.CommonHelper.EnumType.IDTypeEnum.DIC);
            sysDicModel.RoleFunctionList = viewModel.RoleFunctionIDList;
            sysDicModel.WithMoreState = 3;
            if (sysDicBLL.Add(sysDicModel))
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

                        var sysDicMoreModel = new XCLCMS.Data.Model.Custom.SysDicWithMore();
                        sysDicMoreModel.SysDic = sysDicModel;
                        sysDicMoreModel.WithMoreState = 1;
                        sysDicBLL.Update(sysDicMoreModel);
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

        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysDicEdit)]
        public override ActionResult UpdateSubmit(FormCollection fm)
        {
            base.UpdateSubmit(fm);
            XCLCMS.View.AdminViewModel.SysDic.SysDicAddVM viewModel = this.GetViewModel(fm);

            XCLCMS.Data.BLL.SysDic sysDicBLL = new Data.BLL.SysDic();
            XCLCMS.Data.Model.Custom.SysDicWithMore sysDicModel = new Data.Model.Custom.SysDicWithMore();
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            sysDicModel.SysDic = sysDicBLL.GetModel(viewModel.SysDicID);
            sysDicModel.SysDic.Code = viewModel.SysDic.Code;
            sysDicModel.SysDic.UpdaterID = base.CurrentUserModel.UserInfoID;
            sysDicModel.SysDic.UpdaterName = base.CurrentUserModel.UserName;
            sysDicModel.SysDic.UpdateTime = DateTime.Now;
            sysDicModel.SysDic.DicName = viewModel.SysDic.DicName;
            sysDicModel.SysDic.DicType = viewModel.SysDic.DicType;
            sysDicModel.SysDic.DicValue = viewModel.SysDic.DicValue;
            sysDicModel.SysDic.Sort = viewModel.SysDic.Sort;
            sysDicModel.SysDic.Remark = viewModel.SysDic.Remark;
            sysDicModel.SysDic.Weight = viewModel.SysDic.Weight;
            sysDicModel.SysDic.FK_FunctionID = viewModel.SysDic.FK_FunctionID;

            sysDicModel.RoleFunctionList = viewModel.RoleFunctionIDList;
            sysDicModel.WithMoreState = 3;

            if (sysDicBLL.Update(sysDicModel))
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

    }
}
