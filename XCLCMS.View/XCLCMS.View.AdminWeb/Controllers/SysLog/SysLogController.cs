using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.SysLog
{
    /// <summary>
    /// 日志controller
    /// </summary>
    public class SysLogController : BaseController
    {
        /// <summary>
        /// 日志列表
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysLogView)]
        public ActionResult Index()
        {
            XCLCMS.View.AdminViewModel.SysLog.SysLogListVM viewModel = new AdminViewModel.SysLog.SysLogListVM();

            #region 初始化查询条件

            viewModel.Search = new XCLNetSearch.Search();
            viewModel.Search.TypeList = new List<XCLNetSearch.SearchFieldInfo>() {
                new XCLNetSearch.SearchFieldInfo("日志ID","SysLogID|number|text",""),
                new XCLNetSearch.SearchFieldInfo("日志级别","LogLevel|string|text",""),
                new XCLNetSearch.SearchFieldInfo("日志类别","LogType|string|text",""),
                new XCLNetSearch.SearchFieldInfo("来源URL","RefferUrl|string|text",""),
                new XCLNetSearch.SearchFieldInfo("Url","Url|string|text",""),
                new XCLNetSearch.SearchFieldInfo("日志代码","Code|string|text",""),
                new XCLNetSearch.SearchFieldInfo("标题","Title|string|text",""),
                new XCLNetSearch.SearchFieldInfo("内容","Contents|string|text",""),
                new XCLNetSearch.SearchFieldInfo("客户端IP","ClientIP|string|text",""),
                new XCLNetSearch.SearchFieldInfo("备注","Remark|string|text",""),
                new XCLNetSearch.SearchFieldInfo("创建时间",string.Format("CreateTime|dateTime{0}|text",(int)XCLNetSearch.Common.SearchDateFmt.yyyy_MM_dd_HH_mm_ss),"","yyyy-MM-dd HH:mm:ss")
            };
            string strWhere = viewModel.Search.StrSQL;

            #endregion 初始化查询条件

            XCLCMS.Data.BLL.SysLog bll = new Data.BLL.SysLog();
            viewModel.SysLogList = bll.GetPageList(base.PageParamsInfo, strWhere, "", "[SysLogID]", "[CreateTime] desc");
            viewModel.PagerModel = base.PageParamsInfo;

            viewModel.ClearLogDateTypeList = XCLNetTools.Enum.EnumHelper.GetEnumFieldModelList(typeof(XCLNetTools.Enum.CommonEnum.BeforeDateTypeEnum));

            return View("~/Views/SysLog/SysLogList.cshtml", viewModel);
        }

        /// <summary>
        /// 清空日志
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysLogDel)]
        public ActionResult ClearSubmit()
        {
            XCLNetTools.Enum.CommonEnum.BeforeDateTypeEnum dateType = XCLNetTools.Enum.CommonEnum.BeforeDateTypeEnum.SevenDay;
            Enum.TryParse<XCLNetTools.Enum.CommonEnum.BeforeDateTypeEnum>(XCLNetTools.StringHander.FormHelper.GetString("dateType"), out dateType);
            DateTime endTime = XCLNetTools.StringHander.DateHelper.GetBeforeDateTypeDateTime(dateType);
            XCLCMS.Data.BLL.SysLog bll = new Data.BLL.SysLog();
            bll.ClearListByDateTime(null, endTime);

            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel();
            msgModel.IsSuccess = true;
            msgModel.IsRefresh = true;
            msgModel.Message = "删除成功！";
            return Json(msgModel);
        }
    }
}