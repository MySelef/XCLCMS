using System.Web;

namespace XCLCMS.View.AdminWeb.Common
{
    /// <summary>
    /// 站点公共信息
    /// </summary>
    public class WebCommon
    {
        #region 路径相关

        /// <summary>
        /// 上一步的URL
        /// </summary>
        public static string RefferUrl
        {
            get
            {
                string url = null == HttpContext.Current.Request.UrlReferrer ? string.Empty : HttpContext.Current.Request.UrlReferrer.AbsoluteUri;
                if (string.IsNullOrEmpty(url))
                {
                    url = XCLNetTools.StringHander.Common.RootUri;
                }
                return url;
            }
        }

        #endregion 路径相关

        #region 其它

        /// <summary>
        /// 根据记录的状态值返回其css类
        /// </summary>
        /// <param name="recordState">记录状态</param>
        /// <returns>css类，如：XCLBgWarn</returns>
        public static string GetRecordStateClass(string recordState)
        {
            if (recordState.Equals(XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.D.ToString()))
            {
                return "XCLBgError";
            }
            if (recordState.Equals(XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.R.ToString()))
            {
                return "XCLBgWarn";
            }
            return string.Empty;
        }

        #endregion 其它
    }
}