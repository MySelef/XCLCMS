using System;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.SysFunction
{
    [Serializable]
    [DataContract]
    public class IsExistCodeEntity
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public long SysFunctionID { get; set; }
    }
}