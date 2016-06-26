﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.Open
{
    [Serializable]
    [DataContract]
    public class LogonCheckEntity
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Pwd { get; set; }
    }
}
