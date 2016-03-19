using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XCLCMS.FileManager.Models.Common;

namespace XCLCMS.FileManager.Controllers
{
    public class CommonController : Controller
    {
        /// <summary>
        /// 图片显示
        /// </summary>
        public ActionResult ShowImg()
        {
            ShowImgVM viewModel = new ShowImgVM();
            viewModel.ImgSrc = XCLNetTools.StringHander.FormHelper.GetString("ImgSrc");
            return View(viewModel);
        }
    }
}