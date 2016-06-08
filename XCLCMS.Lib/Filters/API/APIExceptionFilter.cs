using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace XCLCMS.Lib.Filters.API
{
    /// <summary>
    /// API异常处理
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class APIExceptionFilter : FilterAttribute, IExceptionFilter
    {
        /// <summary>
        /// 异常处理
        /// </summary>
        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
