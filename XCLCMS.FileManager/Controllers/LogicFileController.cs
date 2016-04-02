using System.Collections.Generic;
using System.Web.Mvc;

namespace XCLCMS.FileManager.Controllers
{
    public class LogicFileController : BaseController
    {
        /// <summary>
        /// 逻辑文件列表
        /// </summary>
        /// <returns></returns>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.FileManager_LogicFileView)]
        public ActionResult List()
        {
            XCLCMS.FileManager.Models.LogicFile.ListVM viewModel = new Models.LogicFile.ListVM();

            #region 初始化查询条件

            viewModel.Search = new XCLNetSearch.Search();
            viewModel.Search.TypeList = new List<XCLNetSearch.SearchFieldInfo>() {
                new XCLNetSearch.SearchFieldInfo("文件ID","AttachmentID|number|text",""),
                new XCLNetSearch.SearchFieldInfo("主文件ID","ParentID|number|text",""),
                new XCLNetSearch.SearchFieldInfo("标题","Title|string|text",""),
                new XCLNetSearch.SearchFieldInfo("查看类型","ViewType|string|text",""),
                new XCLNetSearch.SearchFieldInfo("格式类型","FormatType|string|text",""),
                new XCLNetSearch.SearchFieldInfo("扩展名","Ext|string|text",""),
                new XCLNetSearch.SearchFieldInfo("相对路径","URL|string|text",""),
                new XCLNetSearch.SearchFieldInfo("描述信息","Description|string|text",""),
                new XCLNetSearch.SearchFieldInfo("下载数","DownLoadCount|number|text",""),
                new XCLNetSearch.SearchFieldInfo("查看数","ViewCount|number|text",""),
                new XCLNetSearch.SearchFieldInfo("大小（kb）","FileSize|number|text",""),
                new XCLNetSearch.SearchFieldInfo("图片宽度（如果是图片）","ImgWidth|number|text",""),
                new XCLNetSearch.SearchFieldInfo("图片高度（如果是图片）","ImgHeight|number|text",""),
                
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

            XCLCMS.Data.BLL.Attachment bll = new Data.BLL.Attachment();
            viewModel.AttachmentList = bll.GetPageList(base.PageParamsInfo, strWhere, "", "[AttachmentID]", "[AttachmentID] desc");
            viewModel.PagerModel = base.PageParamsInfo;
            return View(viewModel);
        }
    }
}