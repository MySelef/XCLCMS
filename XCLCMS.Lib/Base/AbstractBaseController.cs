using System;
using System.Web.Mvc;

namespace XCLCMS.Lib.Base
{
    /// <summary>
    /// 抽象基类
    /// </summary>
    public abstract class AbstractBaseController : Controller
    {
        #region 当前登录用户相关

        private XCLCMS.Data.Model.UserInfo _currentUserModel = null;
        private XCLCMS.Data.Model.Custom.ContextModel _contextModel = null;
        private string _userToken = null;

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

        /// <summary>
        /// 当前用户标识
        /// </summary>
        public string UserToken
        {
            get
            {
                if (!string.IsNullOrEmpty(this._userToken))
                {
                    return this._userToken;
                }
                this._userToken = XCLCMS.Lib.Login.LoginHelper.CreateUserToken(this.CurrentUserModel.UserName, this.CurrentUserModel.Pwd);
                return this._userToken;
            }
        }

        #endregion 当前登录用户相关

        #region 其它

        /// <summary>
        /// db上下文
        /// </summary>
        public XCLCMS.Data.Model.Custom.ContextModel ContextModel
        {
            get
            {
                if (null != this._contextModel)
                {
                    return this._contextModel;
                }
                return new Data.Model.Custom.ContextModel()
                {
                    UserInfo = this.CurrentUserModel
                };
            }
        }

        #endregion 其它

        #region 页面操作相关

        /// <summary>
        /// 当前页面分页参数信息
        /// </summary>
        public XCLNetTools.Entity.PagerInfo PageParamsInfo { get; set; }

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

            this.PageParamsInfo = new XCLNetTools.Entity.PagerInfo(XCLNetTools.StringHander.FormHelper.GetInt("page", 1), XCLNetTools.StringHander.FormHelper.GetInt("pageSize", 10), 0);
        }

        #endregion 拦截器
    }
}