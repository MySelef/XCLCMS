using System.Collections.Generic;
using XCLCMS.Data.WebAPIEntity;

namespace XCLCMS.Lib.WebAPI
{
    /// <summary>
    /// 附件API
    /// </summary>
    public static class AttachmentAPI
    {
        /// <summary>
        /// 根据附件关系信息查询附件列表
        /// </summary>
        public static APIResponseEntity<List<XCLCMS.Data.Model.Attachment>> GetObjectAttachmentList(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.Attachment.GetObjectAttachmentListEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.Attachment.GetObjectAttachmentListEntity, List<XCLCMS.Data.Model.Attachment>>(request, "Attachment/GetObjectAttachmentList");
        }

        /// <summary>
        /// 根据文件id，查询文件详情列表
        /// </summary>
        public static APIResponseEntity<List<XCLCMS.Data.Model.Attachment>> GetAttachmentListByIDList(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.Attachment.GetAttachmentListByIDListEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.Attachment.GetAttachmentListByIDListEntity, List<XCLCMS.Data.Model.Attachment>>(request, "Attachment/GetAttachmentListByIDList");
        }
    }
}