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
            viewModel.UserInfoWithMore = new Data.Model.Custom.UserInfoWithMore();

            viewModel.AllRoleList = XCLCMS.Lib.Permission.PerHelper.GetRoleList();

            switch (base.CurrentHandleType)
            {
                case XCLCMS.Lib.Common.Comm.HandleType.ADD:
                    viewModel.UserInfoWithMore.UserInfo = new Data.Model.UserInfo();
                    viewModel.UserInfoWithMore.UserInfo.SexType = XCLCMS.Data.CommonHelper.EnumType.UserSexTypeEnum.M.ToString();
                    viewModel.UserInfoWithMore.UserInfo.UserState = XCLCMS.Data.CommonHelper.EnumType.UserStateEnum.N.ToString();
                    viewModel.FormAction = Url.Action("AddSubmit", "UserInfo");
                    break;
                case XCLCMS.Lib.Common.Comm.HandleType.UPDATE:
                    viewModel.UserInfoWithMore.UserInfo = userInfoBLL.GetModel(userInfoId);
                    viewModel.FormAction = Url.Action("UpdateSubmit", "UserInfo");
                    var roleList = XCLCMS.Lib.Permission.PerHelper.GetRoleByUserID(viewModel.UserInfoWithMore.UserInfo.UserInfoID);
                    if (null != roleList && roleList.Count > 0)
                    {
                        viewModel.UserInfoWithMore.UserRoleIDs = roleList.Select(k => (long)k.SysDicID).ToList();
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
            viewModel.UserInfoWithMore = new Data.Model.Custom.UserInfoWithMore();
            viewModel.UserInfoWithMore.UserInfo = new Data.Model.UserInfo();
            viewModel.UserInfoWithMore.UserInfo.Age = XCLNetTools.StringHander.Common.GetInt((fm["txtAge"] ?? "").Trim());
            viewModel.UserInfoWithMore.UserInfo.Birthday = XCLNetTools.StringHander.Common.GetDateTimeNullable((fm["txtBirthday"] ?? "").Trim());
            viewModel.UserInfoWithMore.UserInfo.Email = (fm["txtEmail"] ?? "").Trim();
            viewModel.UserInfoWithMore.UserInfo.NickName = (fm["txtNickName"] ?? "").Trim();
            viewModel.UserInfoWithMore.UserInfo.OtherContact = (fm["txtOtherContact"] ?? "").Trim();
            viewModel.UserInfoWithMore.UserInfo.Pwd = (fm["txtPwd"] ?? "").Trim();
            viewModel.UserInfoWithMore.UserInfo.QQ = (fm["txtQQ"] ?? "").Trim();
            viewModel.UserInfoWithMore.UserInfo.RealName = (fm["txtRealName"] ?? "").Trim();
            viewModel.UserInfoWithMore.UserInfo.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString();
            viewModel.UserInfoWithMore.UserInfo.Remark = (fm["txtRemark"] ?? "").Trim();
            viewModel.UserInfoWithMore.UserInfo.SexType = (fm["selSexType"] ?? "").Trim();
            viewModel.UserInfoWithMore.UserInfo.Tel = (fm["txtTel"] ?? "").Trim();
            viewModel.UserInfoWithMore.UserInfo.UserName = (fm["txtUserName"] ?? "").Trim();
            viewModel.UserInfoWithMore.UserInfo.UserState = (fm["selUserState"] ?? "").Trim();
            string roles = fm["ckRoles"] ?? "";
            if (!string.IsNullOrEmpty(roles))
            {
                viewModel.UserInfoWithMore.UserRoleIDs = XCLNetTools.StringHander.Common.GetLongArrayByStringArray(roles.Split(',')).ToList();
            }
            return viewModel;
        }

        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function=XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_UserAdd)]
        public override ActionResult AddSubmit(FormCollection fm)
        {
            XCLCMS.View.AdminViewModel.UserInfo.UserInfoAddVM viewModel = this.GetViewModel(fm);
            XCLCMS.Data.BLL.UserInfo userInfoBLL = new Data.BLL.UserInfo();
            XCLCMS.Data.Model.Custom.UserInfoWithMore model = new Data.Model.Custom.UserInfoWithMore();
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            model.UserInfo = new Data.Model.UserInfo();
            model.UserInfo.UserInfoID = XCLCMS.Data.BLL.Common.Common.GenerateID(Data.CommonHelper.EnumType.IDTypeEnum.USR);
            model.UserInfo.AccessToken = viewModel.UserInfoWithMore.UserInfo.AccessType;
            model.UserInfo.AccessType = viewModel.UserInfoWithMore.UserInfo.AccessType;
            model.UserInfo.Age = viewModel.UserInfoWithMore.UserInfo.Age;
            model.UserInfo.Birthday = viewModel.UserInfoWithMore.UserInfo.Birthday;
            model.UserInfo.CreaterID = base.CurrentUserModel.UserInfoID;
            model.UserInfo.CreaterName = base.CurrentUserModel.UserName;
            model.UserInfo.CreateTime = DateTime.Now;
            model.UserInfo.UpdaterID = base.CurrentUserModel.UserInfoID;
            model.UserInfo.UpdaterName = base.CurrentUserModel.UserName;
            model.UserInfo.UpdateTime = DateTime.Now;
            model.UserInfo.Email = viewModel.UserInfoWithMore.UserInfo.Email;
            model.UserInfo.NickName = viewModel.UserInfoWithMore.UserInfo.NickName;
            model.UserInfo.OtherContact = viewModel.UserInfoWithMore.UserInfo.OtherContact;
            model.UserInfo.Pwd = XCLCMS.Lib.Encrypt.EncryptHelper.EncryptStringMD5(string.IsNullOrEmpty(viewModel.UserInfoWithMore.UserInfo.Pwd) ? XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Common_UserDefaultPwd : viewModel.UserInfoWithMore.UserInfo.Pwd);
            model.UserInfo.QQ = viewModel.UserInfoWithMore.UserInfo.QQ;
            model.UserInfo.RealName = viewModel.UserInfoWithMore.UserInfo.RealName;
            model.UserInfo.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString();
            model.UserInfo.Remark = viewModel.UserInfoWithMore.UserInfo.Remark;
            model.UserInfo.SexType = viewModel.UserInfoWithMore.UserInfo.SexType;
            model.UserInfo.Tel = viewModel.UserInfoWithMore.UserInfo.Tel;
            model.UserInfo.UserName = viewModel.UserInfoWithMore.UserInfo.UserName;
            model.UserInfo.UserState = viewModel.UserInfoWithMore.UserInfo.UserState;
            model.UserRoleIDs = viewModel.UserInfoWithMore.UserRoleIDs;
            model.WithMoreState = 3;
            if (userInfoBLL.Add(model))
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
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_UserEdit)]
        public override ActionResult UpdateSubmit(FormCollection fm)
        {
            base.UpdateSubmit(fm);
            long userInfoId = XCLNetTools.StringHander.FormHelper.GetLong("userInfoId");
            XCLCMS.View.AdminViewModel.UserInfo.UserInfoAddVM viewModel = this.GetViewModel(fm);
            XCLCMS.Data.BLL.UserInfo userInfoBLL = new Data.BLL.UserInfo();
            XCLCMS.Data.Model.Custom.UserInfoWithMore model = new Data.Model.Custom.UserInfoWithMore();
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            model.UserInfo = userInfoBLL.GetModel(userInfoId);
            model.UserInfo.AccessToken = viewModel.UserInfoWithMore.UserInfo.AccessType;
            model.UserInfo.AccessType = viewModel.UserInfoWithMore.UserInfo.AccessType;
            model.UserInfo.Age = viewModel.UserInfoWithMore.UserInfo.Age;
            model.UserInfo.Birthday = viewModel.UserInfoWithMore.UserInfo.Birthday;
            model.UserInfo.UpdaterID = base.CurrentUserModel.UserInfoID;
            model.UserInfo.UpdaterName = base.CurrentUserModel.UserName;
            model.UserInfo.UpdateTime = DateTime.Now;
            model.UserInfo.Email = viewModel.UserInfoWithMore.UserInfo.Email;
            model.UserInfo.NickName = viewModel.UserInfoWithMore.UserInfo.NickName;
            model.UserInfo.OtherContact = viewModel.UserInfoWithMore.UserInfo.OtherContact;
            if (!string.IsNullOrEmpty(viewModel.UserInfoWithMore.UserInfo.Pwd))
            {
                model.UserInfo.Pwd = XCLCMS.Lib.Encrypt.EncryptHelper.EncryptStringMD5(viewModel.UserInfoWithMore.UserInfo.Pwd);
            }
            model.UserInfo.QQ = viewModel.UserInfoWithMore.UserInfo.QQ;
            model.UserInfo.RealName = viewModel.UserInfoWithMore.UserInfo.RealName;
            model.UserInfo.Remark = viewModel.UserInfoWithMore.UserInfo.Remark;
            model.UserInfo.SexType = viewModel.UserInfoWithMore.UserInfo.SexType;
            model.UserInfo.Tel = viewModel.UserInfoWithMore.UserInfo.Tel;
            model.UserInfo.UserState = viewModel.UserInfoWithMore.UserInfo.UserState;
            model.UserRoleIDs = viewModel.UserInfoWithMore.UserRoleIDs;
            model.WithMoreState = 3;
            if (userInfoBLL.Update(model))
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

                        var userInfoMoreModel = new Data.Model.Custom.UserInfoWithMore();
                        userInfoMoreModel.UserInfo = userInfoModel;
                        userInfoMoreModel.WithMoreState = 1;
                        userInfoBLL.Update(userInfoMoreModel);
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
