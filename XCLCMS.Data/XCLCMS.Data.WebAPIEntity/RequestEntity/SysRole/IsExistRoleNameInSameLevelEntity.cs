using System;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.SysRole
{
    [Serializable]
    [DataContract]
    public class IsExistRoleNameInSameLevelEntity
    {
        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public long ParentID { get; set; }

        [DataMember]
        public long SysRoleID { get; set; }
    }
}