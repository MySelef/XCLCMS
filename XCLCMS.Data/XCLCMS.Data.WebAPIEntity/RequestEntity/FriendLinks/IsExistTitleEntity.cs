using System;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.FriendLinks
{
    [Serializable]
    [DataContract]
    public class IsExistTitleEntity
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public long FriendLinkID { get; set; }
    }
}