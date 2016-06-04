using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.SysRole
{
    [Serializable]
    [DataContract]
    public class AddOrUpdateEntity
    {
        [DataMember]
        public XCLCMS.Data.Model.SysRole SysRole { get; set; }

        [DataMember]
        public List<long> FunctionIdList { get; set; }
    }
}