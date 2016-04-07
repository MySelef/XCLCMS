using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.FileManager.Models.LogicFile
{
    public class ListVM
    {
        /// <summary>
        /// 列表页面是否以简版显示（用于站点选择附件）
        /// </summary>
        public bool IsSimple { get; set; }

        /// <summary>
        /// 查询控件
        /// </summary>
        public XCLNetSearch.Search Search { get; set; }

        /// <summary>
        /// 分页控件
        /// </summary>
        public XCLNetTools.Entity.PagerInfo PagerModel { get; set; }

        /// <summary>
        /// 文件信息列表
        /// </summary>
        public List<XCLCMS.Data.Model.Attachment> AttachmentList { get; set; }
    }
}
