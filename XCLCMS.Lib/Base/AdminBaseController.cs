using System;
using System.Web.Mvc;

namespace XCLCMS.Lib.Base
{
    /// <summary>
    /// 后台基类
    /// </summary>
    public class AdminBaseController : Controller, IBaseController
    {
        #region 当前登录用户相关

        private XCLCMS.Data.Model.UserInfo _currentUserModel = null;

        /// <summary>
        /// 当前登录的用户实体
        /// </summary>
        public XCLCMS.Data.Model.UserInfo CurrentUserModel
        {
            get
            {
                if (this._currentUserModel == null)
                {
                    this._currentUserModel = XCLCMS.Lib.Login.LoginHelper.GetUserInfoFromLoginInfo();
                }
                return this._currentUserModel;
            }
        }

        /// <summary>
        /// 当前已登录用户的ID
        /// </summary>
        public long UserID
        {
            get
            {
                return null != this.CurrentUserModel ? this.CurrentUserModel.UserInfoID : 0;
            }
        }

        #endregion 当前登录用户相关

        #region 页面操作相关

        /// <summary>
        /// 当前页面操作类型
        /// </summary>
        public XCLCMS.Lib.Common.Comm.HandleType CurrentHandleType
        {
            get
            {
                XCLCMS.Lib.Common.Comm.HandleType type = XCLCMS.Lib.Common.Comm.HandleType.ADD;
                string handleType = XCLNetTools.StringHander.FormHelper.GetString("HandleType").ToUpper();
                if (!string.IsNullOrEmpty(handleType))
                {
                    if (!Enum.TryParse(handleType, out type))
                    {
                        type = XCLCMS.Lib.Common.Comm.HandleType.OTHER;
                    }
                }
                return type;
            }
        }

        /// <summary>
        /// 页面操作类型HandleType的参数值
        /// </summary>
        public string CurrentHandleTypeValue
        {
            get
            {
                return XCLNetTools.StringHander.FormHelper.GetString("HandleType").ToUpper();
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        [ValidateInput(false)]
        [HttpPost]
        public virtual ActionResult AddSubmit(FormCollection fm)
        {
            return null;
        }

        /// <summary>
        /// 删除
        /// </summary>
        [HttpPost]
        public virtual ActionResult DelSubmit(FormCollection fm)
        {
            return null;
        }

        /// <summary>
        /// 更新
        /// </summary>
        [ValidateInput(false)]
        [HttpPost]
        public virtual ActionResult UpdateSubmit(FormCollection fm)
        {
            return null;
        }

        /// <summary>
        /// 导入
        /// </summary>
        [ValidateInput(false)]
        [HttpPost]
        public virtual ActionResult InputSubmit(FormCollection fm)
        {
            return null;
        }

        /// <summary>
        /// 导出
        /// </summary>
        [HttpPost]
        public virtual ActionResult OutputSubmit(FormCollection fm)
        {
            return null;
        }

        #endregion 页面操作相关

        #region 拦截器

        /// <summary>
        /// 拦截action
        /// </summary>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //操作类型
            ViewBag.CurrentHandleType = this.CurrentHandleType;
            ViewBag.UserID = this.UserID;

            XCLCMS.Lib.Model.CommonModel commonModel = new XCLCMS.Lib.Model.CommonModel();
            commonModel.CurrentUserModel = this.CurrentUserModel;
            ViewBag.CommonModel = commonModel;
        }

        #endregion 拦截器

        #region 分页相关

        private int _pageSize = 10;

        public int PageSize
        {
            get
            {
                return this._pageSize;
            }
            set
            {
                this._pageSize = value;
            }
        }

        public int PageIndex
        {
            get
            {
                return XCLNetTools.StringHander.FormHelper.GetInt("page", 1);
            }
        }

        public int RecordCount = 0;

        #endregion 分页相关
    }
}