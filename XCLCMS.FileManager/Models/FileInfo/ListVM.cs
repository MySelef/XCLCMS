using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.FileManager.Models.FileInfo
{
    public class ListVM
    {
        /// <summary>
        /// 当前目录
        /// </summary>
        public string CurrentDirectory { get; set; }

        /// <summary>
        /// 目录导航
        /// </summary>
        public List<XCLNetTools.Entity.TextValue> DirectoryNavigation { get; set; }
    }
}
