namespace XCLCMS.View.AdminWeb.Controllers.API
{
    /// <summary>
    /// web api基类
    /// </summary>
    [XCLCMS.Lib.Filters.API.APIPermissionFilter(IsMustLogin = true)]
    public class BaseAPIController : XCLCMS.Lib.Base.API.AdminBaseAPIController
    {

    }
}