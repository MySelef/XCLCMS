namespace XCLCMS.WebAPI.Controllers
{
    /// <summary>
    /// web api基类
    /// </summary>
    [XCLCMS.Lib.Filters.API.APIPermissionFilter(IsMustLogin = true)]
    //[XCLCMS.Lib.Filters.API.APIExceptionFilter()]
    public class BaseAPIController : XCLCMS.Lib.Base.API.AdminBaseAPIController
    {

    }
}