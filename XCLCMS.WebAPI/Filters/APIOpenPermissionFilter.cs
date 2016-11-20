using System;

namespace XCLCMS.WebAPI.Filters
{
    /// <summary>
    /// 完全公开访问的特性标识
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class APIOpenPermissionFilter : Attribute
    {
    }
}