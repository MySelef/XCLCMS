using System.Collections.Generic;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.Merchant
{
    /// <summary>
    /// 商户应用信息Controller
    /// </summary>
    public class MerchantAppController : BaseController
    {
        /// <summary>
        /// 商户应用信息列表
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantAppView)]
        public ActionResult Index()
        {
            XCLCMS.View.AdminWeb.Models.Merchant.MerchantAppListVM viewModel = new XCLCMS.View.AdminWeb.Models.Merchant.MerchantAppListVM();

            #region 初始化查询条件

            viewModel.Search = new XCLNetSearch.Search();
            viewModel.Search.TypeList = new List<XCLNetSearch.SearchFieldInfo>() {
                new XCLNetSearch.SearchFieldInfo("商户应用ID","MerchantAppID|number|text",""),
                new XCLNetSearch.SearchFieldInfo("商户应用名","MerchantAppName|string|text",""),
                new XCLNetSearch.SearchFieldInfo("所属商户ID","FK_MerchantID|number|text",""),
                new XCLNetSearch.SearchFieldInfo("所属商户名","MerchantName|string|text",""),
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

            XCLCMS.Data.BLL.View.v_MerchantApp bll = new Data.BLL.View.v_MerchantApp();
            viewModel.MerchantAppList = bll.GetPageList(base.PageParamsInfo, strWhere, "", "[MerchantAppID]", "[MerchantAppID] desc");
            viewModel.PagerModel = base.PageParamsInfo;

            return View("~/Views/Merchant/MerchantAppList.cshtml", viewModel);
        }

        public ActionResult Add()
        {
            return View("~/Views/Merchant/MerchantAppAdd.cshtml");
        }
    }
}