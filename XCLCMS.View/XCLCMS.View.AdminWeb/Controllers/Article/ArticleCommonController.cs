using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.Article
{
    /// <summary>
    /// 文章公共controller
    /// </summary>
    public class ArticleCommonController : BaseController
    {
        /// <summary>
        /// 检查文章code是否已存在
        /// </summary>
        public ActionResult IsExistCode()
        {
            var request = XCLCMS.Lib.WebAPI.Library.CreateRequest<XCLCMS.Data.WebAPIEntity.RequestEntity.Article.IsExistCodeEntity>(base.UserToken);
            request.Body = new Data.WebAPIEntity.RequestEntity.Article.IsExistCodeEntity()
            {
                Code = XCLNetTools.StringHander.FormHelper.GetString("code").Trim(),
                ArticleID = XCLNetTools.StringHander.FormHelper.GetLong("ArticleID")
            };
            var response = XCLCMS.Lib.WebAPI.ArticleAPI.IsExistCode(request);

            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel()
            {
                IsSuccess = response.IsSuccess,
                Message = response.Message
            };
            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }
    }
}