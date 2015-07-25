using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Lib.Model
{
    /// <summary>
    /// 站点配置model
    /// </summary>
    public class SettingModel
    {
        public string Common_AdminEmail { get; set; }
        public string Common_CopyRight { get; set; }
        public string Common_DESKey { get; set; }
        public string Common_MetaDescription { get; set; }
        public string Common_MetaKeyWords { get; set; }
        public string Common_MetaTitle { get; set; }
        public string Common_PwdKey { get; set; }
        public string Common_UserDefaultPwd { get; set; }
        public string Common_UserLoginFlagName { get; set; }
        public string Common_WebName { get; set; }
        public string Common_WebURL { get; set; }


        public string Admin_LoginURL { get; set; }
        public string Admin_ResourceRootURL { get; set; }
        public string Admin_ResourceVersion { get; set; }
        public string Admin_UploaderFilePath { get; set; }
        public string Admin_UploaderTempPath { get; set; }
    }
}
