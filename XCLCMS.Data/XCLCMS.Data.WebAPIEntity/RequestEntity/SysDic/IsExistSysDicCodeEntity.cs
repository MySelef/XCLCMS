using System;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.SysDic
{
    [Serializable]
    [DataContract]
    public class IsExistSysDicCodeEntity
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public long SysDicID { get; set; }
    }
}