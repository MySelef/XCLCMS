using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.UserInfo
{
    [Serializable]
    [DataContract]
    public class AddOrUpdateEntity
    {
        [DataMember]
        public XCLCMS.Data.Model.UserInfo UserInfo { get; set; }

        [DataMember]
        public List<long> RoleIdList { get; set; }
    }
}
