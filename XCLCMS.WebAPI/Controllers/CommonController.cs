using System;
using System.Web.Http;
using XCLCMS.Data.WebAPIEntity;

namespace XCLCMS.WebAPI.Controllers
{
    /// <summary>
    /// 公共
    /// </summary>
    public class CommonController : BaseAPIController
    {
        /// <summary>
        /// 生成ID号
        /// </summary>
        [HttpGet]
        public APIResponseEntity<long> GenerateID(string json)
        {
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.Common.GenerateIDEntity>>(System.Web.HttpUtility.UrlDecode(json));
            var response = new APIResponseEntity<long>();
            response.Body = XCLCMS.Data.BLL.Common.Common.GenerateID((Data.CommonHelper.EnumType.IDTypeEnum)Enum.Parse(typeof(Data.CommonHelper.EnumType.IDTypeEnum), request.Body.IDType), request.Body.Remark);
            if (response.Body > 0)
            {
                response.IsSuccess = true;
                response.Message = "生成ID成功！";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "生成ID失败！";
            }

            return response;
        }

        /// <summary>
        /// 垃圾数据清理
        /// </summary>
        [HttpGet]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_ClearRubbishData)]
        public APIResponseEntity<bool> ClearRubbishData(string json)
        {
            var response = new APIResponseEntity<bool>();
            XCLCMS.Data.BLL.Common.Common.ClearRubbishData();
            response.IsSuccess = true;
            response.Message = "垃圾数据清理成功！";
            return response;
        }
    }
}