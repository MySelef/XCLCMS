using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XCLCMS.View.AdminWeb.Controllers
{
    [XCLCMS.Lib.Filters.PermissionFilter(IsMustLogin = true)]
    public class BaseController : XCLCMS.Lib.Base.AdminBaseController
    {
        #region 拦截器
        /// <summary>
        /// 拦截action
        /// </summary>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            //主模板数据
            XCLCMS.View.AdminViewModel.Main.MainVM mainViewModel = new XCLCMS.View.AdminViewModel.Main.MainVM();
            XCLCMS.Data.BLL.SysDic sysDicBLL = new Data.BLL.SysDic();
            var allMenuList = sysDicBLL.GetChildListByCode(new Data.Model.SysDic()
            {
                Code = XCLCMS.Data.CommonHelper.SysDicConst.SysMenu,
                RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString()
            });
            if (null != allMenuList && allMenuList.Count > 0)
            {
                mainViewModel.MenuList = allMenuList.Where(k =>k.FK_FunctionID==null || XCLCMS.Lib.Permission.PerHelper.HasPermission(base.UserID, (XCLCMS.Lib.Permission.Function.FunctionEnum)k.FK_FunctionID)).ToList();
            }
            mainViewModel.CurrentMenuModel = sysDicBLL.GetModel(XCLNetTools.StringHander.FormHelper.GetLong(XCLCMS.View.AdminWeb.Common.WebCommon.MenuIDsParamName));
            ViewBag.Title = mainViewModel.PagePath;
            ViewBag.MainViewModel = mainViewModel;
        }
        #endregion
    }
}
