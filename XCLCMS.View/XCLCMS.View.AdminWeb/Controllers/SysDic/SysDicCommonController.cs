using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.SysDic
{
    /// <summary>
    /// 字典库公共controller
    /// </summary>
    public class SysDicCommonController : BaseController
    {
        /// <summary>
        /// 判断字典的唯一标识是否已经存在
        /// </summary>
        public ActionResult IsExistSysDicCode()
        {
            string code = XCLNetTools.StringHander.FormHelper.GetString("code").Trim();
            long sysDicID = XCLNetTools.StringHander.FormHelper.GetLong("SysDicID");

            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel()
            {
                IsSuccess = true,
                Message = "该唯一标识可以使用！"
            };
            XCLCMS.Data.BLL.SysDic bll = new Data.BLL.SysDic();
            XCLCMS.Data.Model.SysDic model = null;
            if (sysDicID > 0)
            {
                model= bll.GetModel(sysDicID);
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
                bool isExist = new XCLCMS.Data.BLL.SysDic().IsExistCode(code);
                if (isExist)
                {
                    msgModel.IsSuccess = false;
                    msgModel.Message = "该唯一标识已存在！";
                }
            }
            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 判断字典名，在同一级别中是否存在
        /// </summary>
        public ActionResult IsExistSysDicNameInSameLevel()
        {
            string sysDicName = XCLNetTools.StringHander.FormHelper.GetString("sysDicName").Trim();
            long parentID = XCLNetTools.StringHander.FormHelper.GetLong("parentID");
            long sysDicID = XCLNetTools.StringHander.FormHelper.GetLong("SysDicID");

            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel()
            {
                IsSuccess = true,
                Message = "该字典名可以使用！"
            };
            XCLCMS.Data.BLL.SysDic bll = new Data.BLL.SysDic();
            XCLCMS.Data.Model.SysDic model = null;

            if (sysDicID > 0)
            {
                model = bll.GetModel(sysDicID);
                if (null != model)
                {
                    if (string.Equals(sysDicName, model.DicName, StringComparison.OrdinalIgnoreCase))
                    {
                        return Json(msgModel, JsonRequestBehavior.AllowGet);
                    }
                }
            }

            List<XCLCMS.Data.Model.SysDic> lst = bll.GetChildListByID(parentID);
            if (null != lst && lst.Count > 0)
            {
                if (lst.Exists(k => string.Equals(k.DicName, sysDicName, StringComparison.OrdinalIgnoreCase)))
                {
                    msgModel.IsSuccess = false;
                    msgModel.Message = "该字典名在当前层级中已存在！";
                }
            }

            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }
    }
}
