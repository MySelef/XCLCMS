using System;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.SysRole
{
    [Serializable]
    [DataContract]
    public class IsExistCodeEntity
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public long SysRoleID { get; set; }
    }
}