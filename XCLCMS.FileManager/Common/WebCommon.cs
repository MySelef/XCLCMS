using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.FileManager.Common
{
    public class WebCommon
    {
        public static string RootUploadFolder=XCLNetTools.XML.ConfigClass.GetConfigString("RootUploadFolder");
    }
}
