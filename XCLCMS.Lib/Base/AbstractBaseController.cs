using System;
using System.Web.Mvc;

namespace XCLCMS.Lib.Base
{
    /// <summary>
    /// 抽象基类
    /// </summary>
    public abstract class AbstractBaseController : Controller
    {
        private XCLCMS.Data.Model.UserInfo _currentUserModel = null;
        private XCLCMS.Data.Model.Custom.ContextModel _contextModel = null;
        private string _userToken = null;
        private XCLCMS.Data.Model.MerchantApp _currentApplicationMerchantApp = null;
        private XCLCMS.Data.Model.Merchant _currentApplicationMerchant = null;
        private XCLCMS.Data.Model.MerchantApp _currentUserMerchantApp = null;
        private XCLCMS.Data.Model.Merchant _currentUserMerchant = null;
        private XCLCMS.Data.BLL.Merchant merchantBLL = new Data.BLL.Merchant();
        private XCLCMS.Data.BLL.MerchantApp merchantAppBLL = new XCLCMS.Data.BLL.MerchantApp();

        #region 当前登录用户相关

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
                if (null != this.CurrentUserModel)
                {
                    this._userToken = XCLCMS.Lib.Login.LoginHelper.CreateUserToken(this.CurrentUserModel.UserName, this.CurrentUserModel.Pwd);
                }
                return this._userToken;
            }
        }

        /// <summary>
        /// 当前用户所属的商户应用实体
        /// </summary>
        public XCLCMS.Data.Model.MerchantApp CurrentUserMerchantApp
        {
            get
            {
                if (null == this._currentUserMerchantApp)
                {
                    this._currentUserMerchantApp = this.merchantAppBLL.GetModel(this.CurrentUserModel.FK_MerchantAppID);
                }
                return this._currentUserMerchantApp;
            }
        }

        /// <summary>
        /// 当前用户所属的商户信息实体
        /// </summary>
        public XCLCMS.Data.Model.Merchant CurrentUserMerchant
        {
            get
            {
                if (null == this._currentUserMerchant)
                {
                    this._currentUserMerchant = this.merchantBLL.GetModel(this.CurrentUserModel.FK_MerchantID);
                }
                return this._currentUserMerchant;
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
                if (null == this._contextModel)
                {
                    this._contextModel = new Data.Model.Custom.ContextModel()
                    {
                        UserInfoID = this.CurrentUserModel.UserInfoID,
                        UserName = this.CurrentUserModel.UserName
                    };
                }
                return this._contextModel;
            }
        }

        /// <summary>
        /// 当前应用程序的商户应用实体
        /// </summary>
        public XCLCMS.Data.Model.MerchantApp CurrentApplicationMerchantApp
        {
            get
            {
                if (null == this._currentApplicationMerchantApp)
                {
                    this._currentApplicationMerchantApp = XCLCMS.Lib.Common.Comm.CurrentApplicationMerchantApp;
                }
                return this._currentApplicationMerchantApp;
            }
        }

        /// <summary>
        /// 当前应用程序的商户信息实体
        /// </summary>
        public XCLCMS.Data.Model.Merchant CurrentApplicationMerchant
        {
            get
            {
                if (null == this._currentApplicationMerchant)
                {
                    this._currentApplicationMerchant = this.merchantBLL.GetModel(this.CurrentApplicationMerchantApp.FK_MerchantID);
                }
                return this._currentApplicationMerchant;
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
        /// OnActionExecuting
        /// </summary>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            //操作类型
            ViewBag.CurrentHandleType = this.CurrentHandleType;
            ViewBag.UserID = this.UserID;
            ViewBag.ResourceVersion = this.CurrentApplicationMerchantApp.ResourceVersion;
            ViewBag.CurrentApplicationMerchantApp = this.CurrentApplicationMerchantApp;
            ViewBag.CurrentApplicationMerchant = this.CurrentApplicationMerchant;
            ViewBag.CurrentUserMerchantApp = this.CurrentUserMerchantApp;
            ViewBag.CurrentUserMerchant = this.CurrentUserMerchant;

            //公共信息
            XCLCMS.Lib.Model.CommonModel commonModel = new XCLCMS.Lib.Model.CommonModel();
            commonModel.CurrentUserModel = this.CurrentUserModel;
            ViewBag.CommonModel = commonModel;

            //分页信息
            this.PageParamsInfo = new XCLNetTools.Entity.PagerInfo(XCLNetTools.StringHander.FormHelper.GetInt("page", 1), XCLNetTools.StringHander.FormHelper.GetInt("pageSize", 10), 0);

            //页面全局配置信息
            var pageConfig = new XCLCMS.Lib.Model.PageGlobalConfig();
            if (null != commonModel)
            {
                pageConfig.IsLogOn = commonModel.IsLogOn;
                if (null != commonModel.CurrentUserModel)
                {
                    pageConfig.UserID = commonModel.CurrentUserModel.UserInfoID;
                    pageConfig.UserName = commonModel.CurrentUserModel.UserName;
                }
            }
            pageConfig.RootURL = XCLNetTools.StringHander.Common.RootUri;
            pageConfig.UserToken = this.UserToken;
            pageConfig.FileManagerFileListURL = XCLCMS.Lib.SysWebSetting.Setting.SettingModel.FileManager_FileListURL;
            pageConfig.FileManagerLogicFileListURL = XCLCMS.Lib.SysWebSetting.Setting.SettingModel.FileManager_LogicFileListURL;
            pageConfig.WebAPIServiceURL = XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Common_WebAPIServiceURL;
            pageConfig.EnumConfig = string.Empty;
            ViewBag.PageGlobalConfigJSON = string.Format("var XCLCMSPageGlobalConfig={0};XCLCMSPageGlobalConfig.EnumConfig={1};", Newtonsoft.Json.JsonConvert.SerializeObject(pageConfig), XCLCMS.Data.CommonHelper.EnumHelper.GetAllEnumJson);
        }

        /// <summary>
        /// OnActionExecuted
        /// </summary>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            //设置title
            if (string.IsNullOrWhiteSpace(ViewBag.Title))
            {
                ViewBag.Title = this.CurrentApplicationMerchantApp.MetaTitle;
            }
            else
            {
                ViewBag.Title = string.Format("{0}—{1}", ViewBag.Title, this.CurrentApplicationMerchantApp.MetaTitle);
            }
            //设置keywords
            if (string.IsNullOrWhiteSpace(ViewBag.KeyWords))
            {
                ViewBag.KeyWords = this.CurrentApplicationMerchantApp.MetaKeyWords;
            }
            else
            {
                ViewBag.KeyWords = string.Format("{0}—{1}", ViewBag.KeyWords, this.CurrentApplicationMerchantApp.MetaKeyWords);
            }
            //设置description
            if (string.IsNullOrWhiteSpace(ViewBag.Description))
            {
                ViewBag.Description = this.CurrentApplicationMerchantApp.MetaDescription;
            }
            else
            {
                ViewBag.Description = string.Format("{0}—{1}", ViewBag.Description, this.CurrentApplicationMerchantApp.MetaDescription);
            }
        }

        #endregion 拦截器
    }
}