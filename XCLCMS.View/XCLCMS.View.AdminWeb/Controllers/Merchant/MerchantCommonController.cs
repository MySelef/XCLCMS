using System;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.Merchant
{
    public class MerchantCommonController : BaseController
    {
        public ActionResult IsExistMerchantName()
        {
            string merchantName = XCLNetTools.StringHander.FormHelper.GetString("MerchantName").Trim();
            long merchantID = XCLNetTools.StringHander.FormHelper.GetLong("MerchantID");

            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel()
            {
                IsSuccess = true,
                Message = "该唯一标识可以使用！"
            };
            XCLCMS.Data.BLL.Merchant bll = new Data.BLL.Merchant();
            XCLCMS.Data.Model.Merchant model = null;
            if (merchantID > 0)
            {
                model = bll.GetModel(merchantID);
                if (null != model)
                {
                    if (string.Equals(merchantName, model.MerchantName, StringComparison.OrdinalIgnoreCase))
                    {
                        return Json(msgModel, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            if (!string.IsNullOrEmpty(merchantName))
            {
                bool isExist = new XCLCMS.Data.BLL.Merchant().IsExistMerchantName(merchantName);
                if (isExist)
                {
                    msgModel.IsSuccess = false;
                    msgModel.Message = "该商户名已存在！";
                }
            }
            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }
    }
}