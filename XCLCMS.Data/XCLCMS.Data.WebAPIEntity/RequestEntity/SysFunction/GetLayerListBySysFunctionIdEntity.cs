using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.SysFunction
{
    [Serializable]
    [DataContract]
    public class GetLayerListBySysFunctionIdEntity
    {
        [DataMember]
        public long SysFunctionId { get; set; }
    }
}
