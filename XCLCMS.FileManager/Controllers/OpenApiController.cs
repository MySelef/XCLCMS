using System.Web.Mvc;

namespace XCLCMS.FileManager.Controllers
{
    /// <summary>
    /// 公开的控制器
    /// </summary>
    public class OpenApiController : Controller
    {
        private XCLCMS.Data.BLL.Attachment attachmentBLL = new Data.BLL.Attachment();

        /// <summary>
        /// 查看附件
        /// </summary>
        public ActionResult ShowAttachment(long? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                XCLNetTools.StringHander.Common.ResponseClearWrite("请指定有效的附件ID！");
                return null;
            }

            string path = string.Empty;
            var model = attachmentBLL.GetModel(id.Value);
            if (null == model)
            {
                XCLNetTools.StringHander.Common.ResponseClearWrite("文件不存在，或已被删除！");
                return null;
            }
            path = model.URL;
            if (string.IsNullOrWhiteSpace(path))
            {
                XCLNetTools.StringHander.Common.ResponseClearWrite("文件路径不存在！");
                return null;
            }
            return Redirect(XCLCMS.Lib.Common.Tool.GetAttachmentAbsoluteURL(path));
        }
    }
}