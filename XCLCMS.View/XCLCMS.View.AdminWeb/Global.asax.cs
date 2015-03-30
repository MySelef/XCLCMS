using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace XCLCMS.View.AdminWeb
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //静态资源配置信息
            XCLCMS.View.AdminWeb.Common.WebCommon.StaticResourceConfig = XCLNetTools.StringHander.Common.GetStaticResourceConfig(Server.MapPath("~/Config/StaticResourceConfig.config"));
            //XCLNetLogger配置信息
            XCLNetLogger.Config.LogConfig.SetConfig(Server.MapPath("~/Config/XCLNetLogger.config"));
            //消息输出及异常处理
            XCLNetTools.Message.Log.JsonMessageName = "XCL20141111";
            XCLNetTools.Message.Log.LogApplicationErrorAction = new Action<XCLNetTools.Message.MessageModel>((model) =>
            {
                //替换默认的异常输出 使用【既输出json，也使用XCLNetLogger写入】
                XCLNetLogger.Model.LogModel logModel = new XCLNetLogger.Model.LogModel();
                logModel.Contents =string.Format("{0}——{1}", model.Message,model.MessageMore);
                logModel.LogLevel = XCLNetLogger.Config.LogConfig.LogLevel.ERROR;
                logModel.RefferUrl = model.FromUrl;
                logModel.Title = model.Title;
                logModel.Url = model.Url;
                logModel.Code = model.ErrorCode;
                //写XCLNetLogger
                XCLNetLogger.Log.WriteLog(logModel);
                //输出json,置空堆栈跟踪信息
                model.MessageMore = null;
                if (model.IsAjax)
                {
                    XCLNetTools.Message.Log.WriteMessage(model);
                }
                else
                {
                    var context = HttpContext.Current;
                    if (null != context)
                    {
                        context.Session["XCLErrorSessionName"] = model;
                        context.Response.Redirect("~/Other/Error",true);
                        context.Response.End();
                    }
                    else
                    {
                        XCLNetTools.Message.Log.WriteMessage(model);
                    }
                }
            });
        }
    }
}