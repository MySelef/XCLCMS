using System;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.SysWebSetting
{
    [Serializable]
    [DataContract]
    public class IsExistKeyNameEntity
    {
        [DataMember]
        public string KeyName { get; set; }

        [DataMember]
        public long SysWebSettingID { get; set; }
    }
}