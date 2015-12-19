using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.Merchant
{
    /// <summary>
    /// 商户信息controller
    /// </summary>
    public class MerchantController : BaseController
    {
        /// <summary>
        /// 商户信息列表首页
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantView)]
        public ActionResult Index()
        {
            XCLCMS.View.AdminViewModel.Merchant.MerchantListVM viewModel = new XCLCMS.View.AdminViewModel.Merchant.MerchantListVM();

            #region 初始化查询条件

            viewModel.Search = new XCLNetSearch.Search();
            viewModel.Search.TypeList = new List<XCLNetSearch.SearchFieldInfo>() {
                new XCLNetSearch.SearchFieldInfo("商户ID","MerchantID|number|text",""),
                new XCLNetSearch.SearchFieldInfo("商户名","MerchantName|string|text",""),
                new XCLNetSearch.SearchFieldInfo("商户类型","MerchantTypeID|number|text",""),
                new XCLNetSearch.SearchFieldInfo("绑定的域名","Domain|string|text",""),
                new XCLNetSearch.SearchFieldInfo("联系人","ContactName|number|text",""),
                new XCLNetSearch.SearchFieldInfo("手机","Tel|string|text",""),
                new XCLNetSearch.SearchFieldInfo("固话","Landline|string|text",""),
                new XCLNetSearch.SearchFieldInfo("电子邮件","Email|string|text",""),
                new XCLNetSearch.SearchFieldInfo("QQ","QQ|string|text",""),
                new XCLNetSearch.SearchFieldInfo("证件类型","PassTypeID|number|text",""),
                new XCLNetSearch.SearchFieldInfo("证件号","PassNumber|string|text",""),
                new XCLNetSearch.SearchFieldInfo("地址","Address|string|text",""),
                new XCLNetSearch.SearchFieldInfo("其它联系信息","OtherContact|string|text",""),
                new XCLNetSearch.SearchFieldInfo("商户备注","MerchantRemark|string|text",""),
                new XCLNetSearch.SearchFieldInfo("注册时间","RegisterTime|dateTime|text",""),
                new XCLNetSearch.SearchFieldInfo("商户状态","MerchantState|string|select",XCLNetTools.Control.HtmlControl.Lib.GetOptions(typeof(XCLCMS.Data.CommonHelper.EnumType.MerchantStateEnum))),

                new XCLNetSearch.SearchFieldInfo("备注","Remark|string|text",""),
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

            XCLCMS.Data.BLL.Merchant uBLL = new Data.BLL.Merchant();
            viewModel.MerchantList = uBLL.GetPageList(base.PageSize, base.PageIndex, ref base.RecordCount, strWhere, "", "[MerchantID]", "[MerchantID] desc");
            viewModel.PagerModel = new XCLNetTools.Entity.PagerInfo(base.PageIndex, base.PageSize, base.RecordCount);

            return View("~/Views/Merchant/MerchantList.cshtml", viewModel);
        }

        /// <summary>
        /// 添加与编辑商户页面首页
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantAdd)]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantEdit)]
        public ActionResult Add()
        {
            long merchantId = XCLNetTools.StringHander.FormHelper.GetLong("merchantId");

            XCLCMS.Data.BLL.SysDic dicBLL = new Data.BLL.SysDic();
            XCLCMS.Data.BLL.Merchant merchantBLL = new Data.BLL.Merchant();
            XCLCMS.View.AdminViewModel.Merchant.MerchantAddVM viewModel = new AdminViewModel.Merchant.MerchantAddVM();
            viewModel.Merchant = new XCLCMS.Data.Model.Merchant();

            var merchantTypeDic = merchantBLL.GetMerchantTypeDic();
            var passTypeDic = dicBLL.GetPassTypeDic();

            switch (base.CurrentHandleType)
            {
                case XCLCMS.Lib.Common.Comm.HandleType.ADD:
                    viewModel.Merchant = new Data.Model.Merchant();
                    viewModel.MerchantTypeOptions = XCLNetTools.Control.HtmlControl.Lib.GetOptions(merchantTypeDic, new XCLNetTools.Entity.SetOptionEntity()
                    {
                        IsNeedPleaseSelect = true
                    });
                    viewModel.PassTypeOptions = XCLNetTools.Control.HtmlControl.Lib.GetOptions(passTypeDic, new XCLNetTools.Entity.SetOptionEntity()
                    {
                        IsNeedPleaseSelect = true
                    });
                    viewModel.MerchantStateOptions = XCLNetTools.Control.HtmlControl.Lib.GetOptions(typeof(XCLCMS.Data.CommonHelper.EnumType.MerchantStateEnum));
                    viewModel.FormAction = Url.Action("AddSubmit", "Merchant");
                    break;

                case XCLCMS.Lib.Common.Comm.HandleType.UPDATE:
                    viewModel.Merchant = merchantBLL.GetModel(merchantId);
                    viewModel.MerchantTypeOptions = XCLNetTools.Control.HtmlControl.Lib.GetOptions(merchantTypeDic, new XCLNetTools.Entity.SetOptionEntity()
                    {
                        DefaultValue = viewModel.Merchant.MerchantType,
                        IsNeedPleaseSelect = true
                    });
                    viewModel.PassTypeOptions = XCLNetTools.Control.HtmlControl.Lib.GetOptions(passTypeDic, new XCLNetTools.Entity.SetOptionEntity()
                    {
                        DefaultValue = viewModel.Merchant.PassType,
                        IsNeedPleaseSelect = true
                    });
                    viewModel.MerchantStateOptions = XCLNetTools.Control.HtmlControl.Lib.GetOptions(typeof(XCLCMS.Data.CommonHelper.EnumType.MerchantStateEnum), new XCLNetTools.Entity.SetOptionEntity()
                    {
                        DefaultValue = viewModel.Merchant.MerchantState
                    });
                    viewModel.FormAction = Url.Action("UpdateSubmit", "Merchant");
                    break;
            }

            return View("~/Views/Merchant/MerchantAdd.cshtml", viewModel);
        }

        /// <summary>
        /// 将表单值转为viewModel
        /// </summary>
        private XCLCMS.View.AdminViewModel.Merchant.MerchantAddVM GetViewModel(FormCollection fm)
        {
            XCLCMS.View.AdminViewModel.Merchant.MerchantAddVM viewModel = new AdminViewModel.Merchant.MerchantAddVM();
            viewModel.Merchant = new Data.Model.Merchant();
            viewModel.Merchant.Address = (fm["txtAddress"] ?? "").Trim();
            viewModel.Merchant.ContactName = (fm["txtContactName"] ?? "").Trim();
            viewModel.Merchant.Domain = (fm["txtDomain"] ?? "").Trim();
            viewModel.Merchant.Email = (fm["txtEmail"] ?? "").Trim();
            viewModel.Merchant.Landline = (fm["txtLandline"] ?? "").Trim();
            viewModel.Merchant.LogoURL = (fm["txtLogoURL"] ?? "").Trim();
            viewModel.Merchant.MerchantName = (fm["txtMerchantName"] ?? "").Trim();
            viewModel.Merchant.MerchantRemark = (fm["txtMerchantRemark"] ?? "").Trim();
            viewModel.Merchant.MerchantState = (fm["selMerchantState"] ?? "").Trim();
            viewModel.Merchant.MerchantType = (fm["selMerchantType"] ?? "").Trim();
            viewModel.Merchant.OtherContact = (fm["txtOtherContact"] ?? "").Trim();
            viewModel.Merchant.PassNumber = (fm["txtPassNumber"] ?? "").Trim();
            viewModel.Merchant.PassType = (fm["selPassType"] ?? "").Trim();
            viewModel.Merchant.QQ = (fm["txtQQ"] ?? "").Trim();
            viewModel.Merchant.RegisterTime = XCLNetTools.StringHander.Common.GetDateTimeNullable((fm["txtRegisterTime"] ?? "").Trim());
            viewModel.Merchant.Remark = (fm["txtRemark"] ?? "").Trim();
            viewModel.Merchant.Tel = (fm["txtTel"] ?? "").Trim();
            return viewModel;
        }

        /// <summary>
        /// 添加用户信息
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantAdd)]
        public override ActionResult AddSubmit(FormCollection fm)
        {
            XCLCMS.View.AdminViewModel.Merchant.MerchantAddVM viewModel = this.GetViewModel(fm);
            XCLCMS.Data.BLL.Merchant merchantBLL = new Data.BLL.Merchant();
            XCLCMS.Data.Model.Merchant model = new XCLCMS.Data.Model.Merchant();
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            model.MerchantID = XCLCMS.Data.BLL.Common.Common.GenerateID(Data.CommonHelper.EnumType.IDTypeEnum.MER);
            model.Address = viewModel.Merchant.Address;
            model.ContactName = viewModel.Merchant.ContactName;
            model.CreaterID = base.CurrentUserModel.UserInfoID;
            model.CreaterName = base.CurrentUserModel.UserName;
            model.CreateTime = DateTime.Now;
            model.Domain = viewModel.Merchant.Domain;
            model.Email = viewModel.Merchant.Email;
            model.Landline = viewModel.Merchant.Landline;
            model.LogoURL = viewModel.Merchant.LogoURL;
            model.MerchantName = viewModel.Merchant.MerchantName;
            model.MerchantRemark = viewModel.Merchant.MerchantRemark;
            model.MerchantState = viewModel.Merchant.MerchantState;
            model.MerchantType = viewModel.Merchant.MerchantType;
            model.OtherContact = viewModel.Merchant.OtherContact;
            model.PassNumber = viewModel.Merchant.PassNumber;
            model.PassType = viewModel.Merchant.PassType;
            model.QQ = viewModel.Merchant.QQ;
            model.RecordState = viewModel.Merchant.RecordState;
            model.RegisterTime = viewModel.Merchant.RegisterTime;
            model.Remark = viewModel.Merchant.Remark;
            model.Tel = viewModel.Merchant.Tel;
            model.UpdaterID = model.CreaterID;
            model.UpdaterName = model.CreaterName;
            model.UpdateTime = model.CreateTime;

            if (merchantBLL.Add(model))
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

        /// <summary>
        /// 更新用户信息
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantEdit)]
        public override ActionResult UpdateSubmit(FormCollection fm)
        {
            base.UpdateSubmit(fm);
            long merchantId = XCLNetTools.StringHander.FormHelper.GetLong("merchantId");
            XCLCMS.View.AdminViewModel.Merchant.MerchantAddVM viewModel = this.GetViewModel(fm);
            XCLCMS.Data.BLL.Merchant merchantBLL = new Data.BLL.Merchant();
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            XCLCMS.Data.Model.Merchant model = merchantBLL.GetModel(merchantId);
            model.Address = viewModel.Merchant.Address;
            model.ContactName = viewModel.Merchant.ContactName;
            model.CreaterID = base.CurrentUserModel.UserInfoID;
            model.CreaterName = base.CurrentUserModel.UserName;
            model.CreateTime = DateTime.Now;
            model.Domain = viewModel.Merchant.Domain;
            model.Email = viewModel.Merchant.Email;
            model.Landline = viewModel.Merchant.Landline;
            model.LogoURL = viewModel.Merchant.LogoURL;
            model.MerchantName = viewModel.Merchant.MerchantName;
            model.MerchantRemark = viewModel.Merchant.MerchantRemark;
            model.MerchantState = viewModel.Merchant.MerchantState;
            model.MerchantType = viewModel.Merchant.MerchantType;
            model.OtherContact = viewModel.Merchant.OtherContact;
            model.PassNumber = viewModel.Merchant.PassNumber;
            model.PassType = viewModel.Merchant.PassType;
            model.QQ = viewModel.Merchant.QQ;
            model.RecordState = viewModel.Merchant.RecordState;
            model.RegisterTime = viewModel.Merchant.RegisterTime;
            model.Remark = viewModel.Merchant.Remark;
            model.Tel = viewModel.Merchant.Tel;
            model.UpdaterID = model.CreaterID;
            model.UpdaterName = model.CreaterName;
            model.UpdateTime = model.CreateTime;

            if (merchantBLL.Update(model))
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

        /// <summary>
        /// 删除商户信息
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantDel)]
        public override ActionResult DelSubmit(FormCollection fm)
        {
            base.DelSubmit(fm);
            XCLCMS.Data.BLL.Merchant merchantBLL = new Data.BLL.Merchant();
            XCLCMS.Data.Model.Merchant merchantModel = null;
            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            long[] merchantIds = XCLNetTools.StringHander.Common.GetLongArrayByStringArray(XCLNetTools.StringHander.FormHelper.GetString("merchantIds").Split(','));
            if (null != merchantIds && merchantIds.Length > 0)
            {
                for (int i = 0; i < merchantIds.Length; i++)
                {
                    merchantModel = merchantBLL.GetModel(merchantIds[i]);
                    if (null != merchantModel)
                    {
                        merchantModel.UpdaterID = base.CurrentUserModel.UserInfoID;
                        merchantModel.UpdaterName = base.CurrentUserModel.UserName;
                        merchantModel.UpdateTime = DateTime.Now;
                        merchantModel.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.R.ToString();
                        merchantModel.MerchantState = XCLCMS.Data.CommonHelper.EnumType.MerchantStateEnum.N.ToString();
                        merchantBLL.Update(merchantModel);
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