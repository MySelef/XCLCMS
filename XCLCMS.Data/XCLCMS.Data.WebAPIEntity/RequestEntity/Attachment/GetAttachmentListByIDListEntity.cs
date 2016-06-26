using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.Attachment
{
    [Serializable]
    [DataContract]
    public class GetAttachmentListByIDListEntity
    {
        [DataMember]
        public List<long> AttachmentIDList { get; set; }
    }
}
