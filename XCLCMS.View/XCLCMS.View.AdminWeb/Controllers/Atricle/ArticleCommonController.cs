using System;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.Atricle
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
            string code = XCLNetTools.StringHander.FormHelper.GetString("code").Trim();
            long articleID = XCLNetTools.StringHander.FormHelper.GetLong("ArticleID");

            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel()
            {
                IsSuccess = true,
                Message = "该唯一标识可以使用！"
            };
            XCLCMS.Data.BLL.Article bll = new Data.BLL.Article();
            XCLCMS.Data.Model.Article model = null;
            if (articleID > 0)
            {
                model = bll.GetModel(articleID);
                if (null != model)
                {
                    if (string.Equals(code, model.Code, StringComparison.OrdinalIgnoreCase))
                    {
                        return Json(msgModel, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            if (!string.IsNullOrEmpty(code))
            {
                bool isExist = new XCLCMS.Data.BLL.Article().IsExistCode(code);
                if (isExist)
                {
                    msgModel.IsSuccess = false;
                    msgModel.Message = "该唯一标识已存在！";
                }
            }
            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }
    }
}