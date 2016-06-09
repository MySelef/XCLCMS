using System;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.SysFunction
{
    [Serializable]
    [DataContract]
    public class IsExistFunctionNameInSameLevelEntity
    {
        [DataMember]
        public string FunctionName { get; set; }

        [DataMember]
        public long ParentID { get; set; }

        [DataMember]
        public long SysFunctionID { get; set; }
    }
}