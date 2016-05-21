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
        /// <param name="isGet">是否为get请求，默认为get</param>
        /// <returns>请求结果</returns>
        public static APIResponseEntity<TResponse> Request<TRequest, TResponse>(APIRequestEntity<TRequest> request, string path, bool isGet = true) where TRequest : new() where TResponse : new()
        {
            APIResponseEntity<TResponse> response = new APIResponseEntity<TResponse>();
            try
            {
                string requestURL = XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Common_WebAPIServiceURL + path.Trim().Trim('/');
                var httpClient = new HttpClient();
                var httpRequest = new HttpRequestMessage();
                string requestJson = JsonConvert.SerializeObject(request);
                if (isGet)
                {
                    httpRequest.RequestUri = new Uri(requestURL + "?json=" + System.Web.HttpUtility.UrlEncode(requestJson));
                    httpRequest.Method = HttpMethod.Get;
                }
                else
                {
                    httpRequest.RequestUri = new Uri(requestURL);
                    httpRequest.Method = HttpMethod.Post;
                    httpRequest.Content = new StringContent(requestJson);
                    httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                }
                httpRequest.Headers.Add(XCLCMS.Lib.Common.Comm.WebAPIUserTokenHeaderName, request.UserToken);
                httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = httpClient.SendAsync(httpRequest).Result.Content.ReadAsAsync<APIResponseEntity<TResponse>>().Result;
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
        public static APIRequestEntity<TRequest> CreateRequest<TRequest>(string userToken) where TRequest : new()
        {
            APIRequestEntity<TRequest> request = new APIRequestEntity<TRequest>();
            request.ClientIP = XCLNetTools.Common.IPHelper.GetClientIP();
            request.UserToken = userToken;
            request.Url = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            return request;
        }
    }
}