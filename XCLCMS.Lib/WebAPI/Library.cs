using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using XCLCMS.Data.WebAPIEntity;

namespace XCLCMS.Lib.WebAPI
{
    /// <summary>
    /// 基类
    /// </summary>
    public class Library
    {
        /// <summary>
        /// 请求
        /// </summary>
        /// <typeparam name="TRequest">请求类型</typeparam>
        /// <typeparam name="TResponse">返回类型</typeparam>
        /// <param name="request">请求类对象</param>
        /// <param name="path">请求路径</param>
        /// <returns>请求结果</returns>
        public static APIResponseEntity<TResponse> Request<TRequest, TResponse>(APIRequestEntity<TRequest> request, string path) where TRequest : new() where TResponse : new()
        {
            APIResponseEntity<TResponse> response = default(APIResponseEntity<TResponse>);
            try
            {
                var requestJson = JsonConvert.SerializeObject(request);
                HttpContent httpContent = new StringContent(requestJson);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var httpClient = new HttpClient();
                var json = httpClient.PostAsync(XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Common_WebAPIServiceURL + path.Trim().Trim('/'), httpContent).Result.Content.ReadAsStringAsync().Result;
                response = Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponseEntity<TResponse>>(json);
            }
            catch (Exception ex)
            {
                XCLNetLogger.Log.WriteLog(ex);
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 创建request对象
        /// </summary>
        /// <returns>request对象</returns>
        public static APIRequestEntity<TRequest> CreateRequest<TRequest>(XCLCMS.Data.Model.UserInfo userInfo) where TRequest : new()
        {
            APIRequestEntity<TRequest> request = new APIRequestEntity<TRequest>();
            request.ClientIP = XCLNetTools.Common.IPHelper.GetClientIP();
            request.PWD = userInfo.Pwd;
            request.UserName = userInfo.UserName;
            request.Url = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            return request;
        }
    }
}