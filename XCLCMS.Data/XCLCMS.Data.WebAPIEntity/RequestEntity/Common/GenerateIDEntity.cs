using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.Common
{
    [Serializable]
    [DataContract]
    public class GenerateIDEntity
    {
        [DataMember]
        public string IDType { get; set; }

        [DataMember]
        public string Remark { get; set; }
    }
}
