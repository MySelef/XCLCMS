using System;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.Attachment
{
    [Serializable]
    [DataContract]
    public class GetObjectAttachmentListEntity
    {
        [DataMember]
        public string ObjectType { get; set; }

        [DataMember]
        public long ObjectID { get; set; }
    }
}