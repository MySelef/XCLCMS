using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.UserInfo
{
    /// <summary>
    /// 用户controller
    /// </summary>
    public class UserInfoController : BaseController
    {
        /// <summary>
        /// 用户信息列表首页
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function=XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_UserView)]
        public ActionResult Index()
        {
            XCLCMS.View.AdminViewModel.UserInfo.UserInfoListVM viewModel = new XCLCMS.View.AdminViewModel.UserInfo.UserInfoListVM();

            #region 初始化查询条件
            viewModel.Search = new XCLNetSearch.Search();
            viewModel.Search.TypeList = new List<XCLNetSearch.SearchFieldInfo>() { 
                new XCLNetSearch.SearchFieldInfo("用户ID","UserInfoID|number|text",""),
                new XCLNetSearch.SearchFieldInfo("用户名","UserName|string|text",""),
                new XCLNetSearch.SearchFieldInfo("真实姓名","RealName|string|text",""),
                new XCLNetSearch.SearchFieldInfo("昵称","NickName|string|text",""),
                new XCLNetSearch.SearchFieldInfo("年龄","Age|number|text",""),
                new XCLNetSearch.SearchFieldInfo("性别","SexType|string|select",XCLCMS.Data.CommonHelper.EnumHelper.GetOptions(typeof(XCLCMS.Data.CommonHelper.EnumType.UserSexTypeEnum))),
                new XCLNetSearch.SearchFieldInfo("出生日期","Birthday|dateTime|text",""),
                new XCLNetSearch.SearchFieldInfo("手机号","Tel|string|text",""),
                new XCLNetSearch.SearchFieldInfo("QQ","QQ|string|text",""),
                new XCLNetSearch.SearchFieldInfo("电子邮件","Email|string|text",""),
                new XCLNetSearch.SearchFieldInfo("其它联系方式","OtherContact|string|text",""),
                new XCLNetSearch.SearchFieldInfo("备注","Remark|string|text",""),
                new XCLNetSearch.SearchFieldInfo("角色","RoleName|string|text",""),
                new XCLNetSearch.SearchFieldInfo("用户状态","UserState|string|select",XCLCMS.Data.CommonHelper.EnumHelper.GetOptions(typeof(XCLCMS.Data.CommonHelper.EnumType.UserStateEnum))),
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

            XCLCMS.Data.BLL.UserInfo uBLL = new Data.BLL.UserInfo();
            viewModel.UserInfoList = uBLL.GetPageList(base.PageSize, base.PageIndex, ref base.RecordCount, strWhere, "", "[UserInfoID]", "[UserInfoID] desc");
            viewModel.PagerModel = new AdminViewModel.UserControl.XCLPagerVM()
            {
                RecordCount = base.RecordCount,
                PageIndex = base.PageIndex,
                PageSize = base.PageSize
            };

            return View("~/Views/UserInfo/UserInfoList.cshtml", viewModel);
        }

        /// <summary>
        /// 添加与编辑用户页面首页
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_UserAdd)]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_UserEdit)]
        public ActionResult Add()
        {
            long userInfoId = XCLNetTools.StringHander.FormHelper.GetLong("userInfoId");

            XCLCMS.Data.BLL.UserInfo userInfoBLL = new Data.BLL.UserInfo();
            XCLCMS.View.AdminViewModel.UserInfo.UserInfoAddVM viewModel = new AdminViewModel.UserInfo.UserInfoAddVM();
            viewModel.UserInfo = new XCLCMS.Data.Model.UserInfo();

            viewModel.AllRoleList = XCLCMS.Lib.Permission.PerHelper.GetRoleList();

            switch (base.CurrentHandleType)
            {
                case XCLCMS.Lib.Common.Comm.HandleType.ADD:
                    viewModel.UserInfo = new Data.Model.UserInfo();
                    viewModel.UserInfo.SexType = XCLCMS.Data.CommonHelper.EnumType.UserSexTypeEnum.M.ToString();
                    viewModel.UserInfo.UserState = XCLCMS.Data.CommonHelper.EnumType.UserStateEnum.N.ToString();
                    viewModel.FormAction = Url.Action("AddSubmit", "UserInfo");
                    break;
                case XCLCMS.Lib.Common.Comm.HandleType.UPDATE:
                    viewModel.UserInfo = userInfoBLL.GetModel(userInfoId);
                    viewModel.FormAction = Url.Action("UpdateSubmit", "UserInfo");
                    var roleList = XCLCMS.Lib.Permission.PerHelper.GetRoleByUserID(viewModel.UserInfo.UserInfoID);
                    if (null != roleList && roleList.Count > 0)
                    {
                        viewModel.UserRoleIDs = roleList.Select(k => (long)k.SysDicID).ToList();
                    }
                    break;
            }

            return View("~/Views/UserInfo/UserInfoAdd.cshtml",viewModel);
        }

        /// <summary>
        /// 将表单值转为viewModel
        /// </summary>
        private XCLCMS.View.AdminViewModel.UserInfo.UserInfoAddVM GetViewModel(FormCollection fm)
        {
            XCLCMS.View.AdminViewModel.UserInfo.UserInfoAddVM viewModel = new AdminViewModel.UserInfo.UserInfoAddVM();
            viewModel.UserInfo = new Data.Model.UserInfo();
            viewModel.UserInfo.Age = XCLNetTools.StringHander.Common.GetInt((fm["txtAge"] ?? "").Trim());
            viewModel.UserInfo.Birthday = XCLNetTools.StringHander.Common.GetDateTimeNullable((fm["txtBirthday"] ?? "").Trim());
            viewModel.UserInfo.Email = (fm["txtEmail"] ?? "").Trim();
            viewModel.UserInfo.NickName = (fm["txtNickName"] ?? "").Trim();
            viewModel.UserInfo.OtherContact = (fm["txtOtherContact"] ?? "").Trim();
            viewModel.UserInfo.Pwd = (fm["txtPwd"] ?? "").Trim();
            viewModel.UserInfo.QQ = (fm["txtQQ"] ?? "").Trim();
            viewModel.UserInfo.RealName = (fm["txtRealName"] ?? "").Trim();
            viewModel.UserInfo.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString();
            viewModel.UserInfo.Remark = (fm["txtRemark"] ?? "").Trim();
            viewModel.UserInfo.SexType = (fm["selSexType"] ?? "").Trim();
            viewModel.UserInfo.Tel = (fm["txtTel"] ?? "").Trim();
            viewModel.UserInfo.UserName = (fm["txtUserName"] ?? "").Trim();
            viewModel.UserInfo.UserState = (fm["selUserState"] ?? "").Trim();
            string roles = fm["ckRoles"] ?? "";
            if (!string.IsNullOrEmpty(roles))
            {
                viewModel.UserRoleIDs = XCLNetTools.StringHander.Common.GetLongArrayByStringArray(roles.Split(',')).ToList();
            }
            return viewModel;
        }

        /// <summary>
        /// 添加用户信息
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function=XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_UserAdd)]
        public override ActionResult AddSubmit(FormCollection fm)
        {
            XCLCMS.View.AdminViewModel.UserInfo.UserInfoAddVM viewModel = this.GetViewModel(fm);
            XCLCMS.Data.BLL.UserInfo userInfoBLL = new Data.BLL.UserInfo();
            XCLCMS.Data.Model.UserInfo model = new XCLCMS.Data.Model.UserInfo();
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            model.UserInfoID = XCLCMS.Data.BLL.Common.Common.GenerateID(Data.CommonHelper.EnumType.IDTypeEnum.USR);
            model.AccessToken = viewModel.UserInfo.AccessType;
            model.AccessType = viewModel.UserInfo.AccessType;
            model.Age = viewModel.UserInfo.Age;
            model.Birthday = viewModel.UserInfo.Birthday;
            model.CreaterID = base.CurrentUserModel.UserInfoID;
            model.CreaterName = base.CurrentUserModel.UserName;
            model.CreateTime = DateTime.Now;
            model.UpdaterID = base.CurrentUserModel.UserInfoID;
            model.UpdaterName = base.CurrentUserModel.UserName;
            model.UpdateTime = DateTime.Now;
            model.Email = viewModel.UserInfo.Email;
            model.NickName = viewModel.UserInfo.NickName;
            model.OtherContact = viewModel.UserInfo.OtherContact;
            model.Pwd = XCLCMS.Lib.Encrypt.EncryptHelper.EncryptStringMD5(string.IsNullOrEmpty(viewModel.UserInfo.Pwd) ? XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Common_UserDefaultPwd : viewModel.UserInfo.Pwd);
            model.QQ = viewModel.UserInfo.QQ;
            model.RealName = viewModel.UserInfo.RealName;
            model.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString();
            model.Remark = viewModel.UserInfo.Remark;
            model.SexType = viewModel.UserInfo.SexType;
            model.Tel = viewModel.UserInfo.Tel;
            model.UserName = viewModel.UserInfo.UserName;
            model.UserState = viewModel.UserInfo.UserState;

            XCLCMS.Data.BLL.Strategy.UserInfo.UserInfoContext userInfoContext = new Data.BLL.Strategy.UserInfo.UserInfoContext();
            userInfoContext.CurrentUserInfo = base.CurrentUserModel;
            userInfoContext.UserInfo = model;
            userInfoContext.UserRoleIDs = viewModel.UserRoleIDs;
            userInfoContext.HandleType = Data.BLL.Strategy.StrategyLib.HandleType.ADD;

            XCLCMS.Data.BLL.Strategy.ExecuteStrategy strategy = new Data.BLL.Strategy.ExecuteStrategy(new List<Data.BLL.Strategy.BaseStrategy>() { 
                new XCLCMS.Data.BLL.Strategy.UserInfo.UserInfo(),
                new XCLCMS.Data.BLL.Strategy.UserInfo.RoleInfo()
            });
            strategy.Execute<XCLCMS.Data.BLL.Strategy.UserInfo.UserInfoContext>(userInfoContext);

            if (strategy.Result != Data.BLL.Strategy.StrategyLib.ResultEnum.FAIL)
            {
                msgModel.Message = "添加成功！";
                msgModel.IsSuccess = true;
            }
            else
            {
                msgModel.Message = strategy.ResultMessage;
                msgModel.IsSuccess = false;
            }

            return Json(msgModel);
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_UserEdit)]
        public override ActionResult UpdateSubmit(FormCollection fm)
        {
            base.UpdateSubmit(fm);
            long userInfoId = XCLNetTools.StringHander.FormHelper.GetLong("userInfoId");
            XCLCMS.View.AdminViewModel.UserInfo.UserInfoAddVM viewModel = this.GetViewModel(fm);
            XCLCMS.Data.BLL.UserInfo userInfoBLL = new Data.BLL.UserInfo();
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            XCLCMS.Data.Model.UserInfo model = userInfoBLL.GetModel(userInfoId);
            model.AccessToken = viewModel.UserInfo.AccessType;
            model.AccessType = viewModel.UserInfo.AccessType;
            model.Age = viewModel.UserInfo.Age;
            model.Birthday = viewModel.UserInfo.Birthday;
            model.UpdaterID = base.CurrentUserModel.UserInfoID;
            model.UpdaterName = base.CurrentUserModel.UserName;
            model.UpdateTime = DateTime.Now;
            model.Email = viewModel.UserInfo.Email;
            model.NickName = viewModel.UserInfo.NickName;
            model.OtherContact = viewModel.UserInfo.OtherContact;
            if (!string.IsNullOrEmpty(viewModel.UserInfo.Pwd))
            {
                model.Pwd = XCLCMS.Lib.Encrypt.EncryptHelper.EncryptStringMD5(viewModel.UserInfo.Pwd);
            }
            model.QQ = viewModel.UserInfo.QQ;
            model.RealName = viewModel.UserInfo.RealName;
            model.Remark = viewModel.UserInfo.Remark;
            model.SexType = viewModel.UserInfo.SexType;
            model.Tel = viewModel.UserInfo.Tel;
            model.UserState = viewModel.UserInfo.UserState;

            XCLCMS.Data.BLL.Strategy.UserInfo.UserInfoContext userInfoContext = new Data.BLL.Strategy.UserInfo.UserInfoContext();
            userInfoContext.CurrentUserInfo = base.CurrentUserModel;
            userInfoContext.UserInfo = model;
            userInfoContext.UserRoleIDs = viewModel.UserRoleIDs;
            userInfoContext.HandleType = Data.BLL.Strategy.StrategyLib.HandleType.UPDATE;

            XCLCMS.Data.BLL.Strategy.ExecuteStrategy strategy = new Data.BLL.Strategy.ExecuteStrategy(new List<Data.BLL.Strategy.BaseStrategy>() { 
                new XCLCMS.Data.BLL.Strategy.UserInfo.UserInfo(),
                new XCLCMS.Data.BLL.Strategy.UserInfo.RoleInfo()
            });
            strategy.Execute<XCLCMS.Data.BLL.Strategy.UserInfo.UserInfoContext>(userInfoContext);

            if (strategy.Result != Data.BLL.Strategy.StrategyLib.ResultEnum.FAIL)
            {
                msgModel.Message = "修改成功！";
                msgModel.IsSuccess = true;
            }
            else
            {
                msgModel.Message = strategy.ResultMessage;
                msgModel.IsSuccess = false;
            }

            return Json(msgModel);
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_UserDel)]
        public override ActionResult DelSubmit(FormCollection fm)
        {
            base.DelSubmit(fm);
            XCLCMS.Data.BLL.UserInfo userInfoBLL = new Data.BLL.UserInfo();
            XCLCMS.Data.Model.UserInfo userInfoModel = null;
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            long[] userInfoIds = XCLNetTools.StringHander.Common.GetLongArrayByStringArray(XCLNetTools.StringHander.FormHelper.GetString("UserInfoIds").Split(','));
            if (null != userInfoIds && userInfoIds.Length > 0)
            {
                for (int i = 0; i < userInfoIds.Length; i++)
                {
                    userInfoModel = userInfoBLL.GetModel(userInfoIds[i]);
                    if (null != userInfoModel)
                    {
                        userInfoModel.UpdaterID = base.CurrentUserModel.UserInfoID;
                        userInfoModel.UpdaterName = base.CurrentUserModel.UserName;
                        userInfoModel.UpdateTime = DateTime.Now;
                        userInfoModel.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.R.ToString();
                        userInfoModel.UserState = XCLCMS.Data.CommonHelper.EnumType.UserStateEnum.D.ToString();
                        userInfoBLL.Update(userInfoModel);
                    }
                }
            }
            msgModel.IsSuccess = true;
            msgModel.IsRefresh = true;
            msgModel.Message = "删除成功！";
            return Json(msgModel);
        }

    }
}
