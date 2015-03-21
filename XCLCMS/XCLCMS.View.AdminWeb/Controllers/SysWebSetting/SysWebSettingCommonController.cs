using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.SysWebSetting
{
    public class SysWebSettingCommonController : BaseController
    {
        /// <summary>
        /// 检查配置名是否已存在
        /// </summary>
        public ActionResult IsExistKeyName()
        {
            string keyName = XCLNetTools.StringHander.FormHelper.GetString("KeyName").Trim();
            long sysWebSettingID = XCLNetTools.StringHander.FormHelper.GetLong("SysWebSettingID");

            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel()
            {
                IsSuccess = true,
                Message = "该配置名可以使用！"
            };
            XCLCMS.Data.BLL.SysWebSetting bll = new Data.BLL.SysWebSetting();
            XCLCMS.Data.Model.SysWebSetting model = null;
            if (sysWebSettingID > 0)
            {
                model = bll.GetModel(sysWebSettingID);
                if (null != model)
                {
                    if (string.Equals(keyName, model.KeyName, StringComparison.OrdinalIgnoreCase))
                    {
                        return Json(msgModel, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            if (!string.IsNullOrEmpty(keyName))
            {
                bool isExist = new XCLCMS.Data.BLL.SysWebSetting().IsExistKeyName(keyName);
                if (isExist)
                {
                    msgModel.IsSuccess = false;
                    msgModel.Message = "该配置名已存在！";
                }
            }
            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }

    }
}
