using System.Collections.Generic;
using System.Web.Http;
using XCLCMS.Data.WebAPIEntity;

namespace XCLCMS.WebAPI.Controllers
{
    /// <summary>
    /// 字典库 管理
    /// </summary>
    public class SysDicController : BaseAPIController
    {
        private XCLCMS.Data.BLL.View.v_SysDic vSysDicBLL = new Data.BLL.View.v_SysDic();

        /// <summary>
        /// 查询所有字典列表
        /// </summary>
        [HttpGet]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysDicView)]
        public APIResponseEntity<List<XCLCMS.Data.Model.View.v_SysDic>> GetList(string json)
        {
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<APIRequestEntity<long>>(System.Web.HttpUtility.UrlDecode(json));
            var response = new APIResponseEntity<List<XCLCMS.Data.Model.View.v_SysDic>>();
            response.Body = this.vSysDicBLL.GetList(request.Body);
            response.IsSuccess = true;
            return response;
        }
    }
}