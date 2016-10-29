using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using XCLCMS.Data.WebAPIEntity;

namespace XCLCMS.WebAPI.Filters
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
            return Task.Run(() =>
            {
                XCLNetLogger.Log.WriteLog(actionExecutedContext.Exception);
                actionExecutedContext.Response = new System.Net.Http.HttpResponseMessage()
                {
                    Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new APIResponseEntity<object>()
                    {
                        IsSuccess = false,
                        Message = actionExecutedContext.Exception.Message
                    }), System.Text.Encoding.UTF8)
                };
            });
        }
    }
}