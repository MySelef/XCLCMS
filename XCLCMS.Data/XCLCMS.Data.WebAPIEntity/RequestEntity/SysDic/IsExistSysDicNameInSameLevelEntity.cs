using System;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.SysDic
{
    [Serializable]
    [DataContract]
    public class IsExistSysDicNameInSameLevelEntity
    {
        [DataMember]
        public string SysDicName { get; set; }

        [DataMember]
        public long ParentID { get; set; }

        [DataMember]
        public long SysDicID { get; set; }
    }
}