using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace XCLCMS.FileManager.Controllers
{
    public class LogicFileController : BaseController
    {
        /// <summary>
        /// 逻辑文件列表
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.FileManager_LogicFileView)]
        public ActionResult List()
        {
            XCLCMS.FileManager.Models.LogicFile.ListVM viewModel = new Models.LogicFile.ListVM();
            viewModel.IsSimple = XCLNetTools.StringHander.FormHelper.GetInt("IsSimple") == 1;

            #region 初始化查询条件

            viewModel.Search = new XCLNetSearch.Search();
            viewModel.Search.TypeList = new List<XCLNetSearch.SearchFieldInfo>() {
                new XCLNetSearch.SearchFieldInfo("文件ID","AttachmentID|number|text",""),
                new XCLNetSearch.SearchFieldInfo("主文件ID","ParentID|number|text",""),
                new XCLNetSearch.SearchFieldInfo("标题","Title|string|text",""),
                new XCLNetSearch.SearchFieldInfo("文件名","FileName|string|text",""),
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
            base.PageParamsInfo.PageSize = 15;
            viewModel.AttachmentList = bll.GetPageList(base.PageParamsInfo, strWhere, "", "[AttachmentID]", "[AttachmentID] desc");
            viewModel.PagerModel = base.PageParamsInfo;
            return View(viewModel);
        }

        /// <summary>
        /// 查看文件详情
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.FileManager_LogicFileView)]
        public ActionResult Show()
        {
            var bll = new XCLCMS.Data.BLL.Attachment();
            XCLCMS.FileManager.Models.LogicFile.ShowVM viewModel = new Models.LogicFile.ShowVM();
            viewModel.AttachmentID = XCLNetTools.StringHander.FormHelper.GetLong("AttachmentID");
            viewModel.Attachment = bll.GetModel(viewModel.AttachmentID) ?? new Data.Model.Attachment();
            if (viewModel.Attachment.AttachmentID > 0)
            {
                viewModel.SubAttachmentList = bll.GetCorrelativeList(viewModel.Attachment.AttachmentID);
            }
            return View(viewModel);
        }

        /// <summary>
        /// 修改文件信息
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.FileManager_LogicFileUpdate)]
        public ActionResult Update()
        {
            var bll = new XCLCMS.Data.BLL.Attachment();
            XCLCMS.FileManager.Models.LogicFile.UpdateVM viewModel = new Models.LogicFile.UpdateVM();
            viewModel.AttachmentID = XCLNetTools.StringHander.FormHelper.GetLong("AttachmentID");
            viewModel.Attachment = bll.GetModel(viewModel.AttachmentID) ?? new Data.Model.Attachment();
            return View(viewModel);
        }

        /// <summary>
        /// 修改文件信息 提交操作
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.FileManager_LogicFileUpdate)]
        public override ActionResult UpdateSubmit(FormCollection fm)
        {
            XCLNetTools.Message.MessageModel msg = new XCLNetTools.Message.MessageModel();
            var bll = new XCLCMS.Data.BLL.Attachment();
            long attachmentID = XCLNetTools.StringHander.FormHelper.GetLong("AttachmentID");
            var model = bll.GetModel(attachmentID);
            if (null == model)
            {
                msg.IsSuccess = false;
                msg.Message = "未找到该记录！";
                return Json(msg);
            }
            model.Title = XCLNetTools.StringHander.FormHelper.GetString("Title");
            model.Description = XCLNetTools.StringHander.FormHelper.GetString("Description");
            model.UpdaterID = base.UserID;
            model.UpdaterName = base.CurrentUserModel.UserName;
            model.UpdateTime = DateTime.Now;
            if (bll.Update(model))
            {
                msg.IsSuccess = true;
                msg.Message = "更新成功！";
            }
            else
            {
                msg.IsSuccess = false;
                msg.Message = "更新失败！";
            }
            return Json(msg);
        }

        /// <summary>
        /// 文件删除操作
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.FileManager_LogicFileDel)]
        public override ActionResult DelSubmit(FormCollection fm)
        {
            XCLNetTools.Message.MessageModel msg = new XCLNetTools.Message.MessageModel();
            var bll = new XCLCMS.Data.BLL.Attachment();
            var ids = (XCLNetTools.StringHander.FormHelper.GetString("attachmentIDs") ?? "").Split(',').ToList().ConvertAll(k => XCLNetTools.Common.DataTypeConvert.ToLong(k));
            if (null == ids || ids.Count == 0)
            {
                msg.IsSuccess = false;
                msg.Message = "请指定要删除的记录！";
                return Json(msg);
            }
            if (bll.Delete(ids, base.ContextModel))
            {
                msg.IsSuccess = true;
                msg.Message = "删除成功！";
                msg.IsRefresh = true;

                //删除物理文件
                foreach (var id in ids)
                {
                    var model = bll.GetModel(id);
                    if (null == model)
                    {
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(model.URL))
                    {
                        continue;
                    }
                    XCLNetTools.FileHandler.ComFile.DeleteFile(Server.MapPath(model.URL));
                }
            }
            else
            {
                msg.IsSuccess = false;
                msg.Message = "删除失败！";
            }
            return Json(msg);
        }
    }
}