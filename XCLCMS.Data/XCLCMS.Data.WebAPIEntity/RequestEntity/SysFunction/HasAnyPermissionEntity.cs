using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.SysFunction
{
    [Serializable]
    [DataContract]
    public class HasAnyPermissionEntity
    {
        [DataMember]
        public long UserId { get; set; }

        [DataMember]
        public List<long> FunctionIDList { get; set; }
    }
}