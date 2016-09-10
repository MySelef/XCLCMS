using System.Collections.Generic;

namespace XCLCMS.FileManager.Models.LogicFile
{
    public class ListVM
    {
        /// <summary>
        /// 列表页面是否为选择文件的场景（用于站点选择附件）
        /// </summary>
        public bool IsSelectFile { get; set; }

        /// <summary>
        /// 选择文件场景下的callback
        /// </summary>
        public string SelectFileCallBack { get; set; }

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
        public List<XCLCMS.Data.Model.View.v_Attachment> AttachmentList { get; set; }
    }
}