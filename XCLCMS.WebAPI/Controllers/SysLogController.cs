using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Web.Http;
using XCLCMS.Data.WebAPIEntity;
using XCLCMS.Data.WebAPIEntity.RequestEntity;

namespace XCLCMS.WebAPI.Controllers
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public class SysLogController : BaseAPIController
    {
        public XCLCMS.Data.BLL.SysLog sysLogBLL = new Data.BLL.SysLog();

        /// <summary>
        /// 查询系统日志信息分页列表
        /// </summary>
        [HttpGet]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysLogView)]
        public APIResponseEntity<XCLCMS.Data.WebAPIEntity.ResponseEntity.PageListResponseEntity<XCLCMS.Data.Model.SysLog>> PageList([FromUri] string json)
        {
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<APIRequestEntity<PageListConditionEntity>>(System.Web.HttpUtility.UrlDecode(json));
            var pager = request.Body.PagerInfoSimple.ToPagerInfo();
            var response = new APIResponseEntity<XCLCMS.Data.WebAPIEntity.ResponseEntity.PageListResponseEntity<XCLCMS.Data.Model.SysLog>>();
            response.Body = new Data.WebAPIEntity.ResponseEntity.PageListResponseEntity<Data.Model.SysLog>();

            //限制商户
            if (base.IsOnlyCurrentMerchant)
            {
                request.Body.Where = XCLNetTools.DataBase.SQLLibrary.JoinWithAnd(new List<string>() {
                    request.Body.Where,
                    string.Format("FK_MerchantID={0}",base.CurrentUserModel.FK_MerchantID)
                });
            }

            response.Body.ResultList = sysLogBLL.GetPageList(pager, request.Body.Where, "", "[SysLogID]", "[SysLogID] desc");
            response.Body.PagerInfo = pager;
            response.IsSuccess = true;
            return response;
        }

        /// <summary>
        /// 批量删除系统日志信息
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysLogDel)]
        public APIResponseEntity<bool> Delete([FromBody] APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.SysLog.ClearConditionEntity> request)
        {
            var response = new APIResponseEntity<bool>();
            if (this.sysLogBLL.ClearListByDateTime(request.Body.StartTime, request.Body.EndTime, base.IsOnlyCurrentMerchant ? base.CurrentUserModel.FK_MerchantID : 0))
            {
                response.IsSuccess = true;
                response.IsRefresh = true;
                response.Message = "删除成功！";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "删除失败！";
            }
            return response;
        }
    }
}