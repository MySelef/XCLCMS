using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using XCLCMS.Data.WebAPIEntity;

namespace XCLCMS.WebAPI.Controllers
{
    /// <summary>
    /// 附件管理
    /// </summary>
    public class AttachmentController : BaseAPIController
    {
        private XCLCMS.Data.BLL.Attachment attachmentBLL = new XCLCMS.Data.BLL.Attachment();
        private XCLCMS.Data.BLL.ObjectAttachment objectAttachmentBLL = new XCLCMS.Data.BLL.ObjectAttachment();

        /// <summary>
        /// 根据附件关系信息查询附件列表
        /// </summary>
        [HttpGet]
        public APIResponseEntity<List<XCLCMS.Data.Model.Attachment>> GetObjectAttachmentList([FromUri] string json)
        {
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.Attachment.GetObjectAttachmentListEntity>>(System.Web.HttpUtility.UrlDecode(json));
            var response = new APIResponseEntity<List<XCLCMS.Data.Model.Attachment>>();
            var lst= this.objectAttachmentBLL.GetModelList((XCLCMS.Data.CommonHelper.EnumType.ObjectTypeEnum)Enum.Parse(typeof(XCLCMS.Data.CommonHelper.EnumType.ObjectTypeEnum), request.Body.ObjectType), request.Body.ObjectID);
            List<long> ids = new List<long>();
            if (null != lst && lst.Count > 0)
            {
                ids = lst.Select(k => k.FK_AttachmentID).ToList();
            }
            response.Body = this.attachmentBLL.GetList(ids);
            response.IsSuccess = true;
            return response;
        }


        /// <summary>
        /// 根据文件id，查询文件详情列表
        /// </summary>
        [HttpGet]
        public APIResponseEntity<List<XCLCMS.Data.Model.Attachment>> GetAttachmentListByIDList([FromUri] string json)
        {
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.Attachment.GetAttachmentListByIDListEntity>>(System.Web.HttpUtility.UrlDecode(json));
            var response = new APIResponseEntity<List<XCLCMS.Data.Model.Attachment>>();
            response.Body = this.attachmentBLL.GetList(request.Body.AttachmentIDList);
            response.IsSuccess = true;
            return response;
        }
    }
}