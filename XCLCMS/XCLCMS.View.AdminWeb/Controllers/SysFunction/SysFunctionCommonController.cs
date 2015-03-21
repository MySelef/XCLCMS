using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers.SysFunction
{
    public class SysFunctionCommonController : BaseController
    {
        /// <summary>
        /// 判断功能名是否已经存在
        /// </summary>
        public ActionResult IsExistSysFunctionName()
        {
            string functionName = XCLNetTools.StringHander.FormHelper.GetString("FunctionName").Trim();
            long sysFunctionID = XCLNetTools.StringHander.FormHelper.GetLong("SysFunctionID");

            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel()
            {
                IsSuccess = true,
                Message = "该名称可以使用！"
            };
            XCLCMS.Data.BLL.SysFunction bll = new Data.BLL.SysFunction();
            XCLCMS.Data.Model.SysFunction model = null;
            if (sysFunctionID > 0)
            {
                model = bll.GetModel(sysFunctionID);
                if (null != model)
                {
                    if (string.Equals(functionName, model.FunctionName, StringComparison.OrdinalIgnoreCase))
                    {
                        return Json(msgModel, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            if (!string.IsNullOrEmpty(functionName))
            {
                bool isExist = new XCLCMS.Data.BLL.SysFunction().IsExistFunctionName(functionName);
                if (isExist)
                {
                    msgModel.IsSuccess = false;
                    msgModel.Message = "该名称已存在！";
                }
            }
            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// json列表
        /// </summary>
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysFunctionView)]
        public JsonResult GetList()
        {
            XCLCMS.Data.BLL.View.v_SysFunction bll = new Data.BLL.View.v_SysFunction();
            var lst = bll.GetModelList("");
            if (null != lst && lst.Count > 0)
            {
                lst = lst.OrderBy(k => k.FK_TypeID).ThenBy(k => k.FunctionName).ToList();
            }
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
    }
}
