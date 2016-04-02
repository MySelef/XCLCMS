using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return View();
        }
    }
}