using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XCLCMS.View.AdminWeb.Models.Tags
{
    public class TagsAddVM
    {
        /// <summary>
        /// 记录状态select的option
        /// </summary>
        public string RecordStateOptions { get; set; }

        public string FormAction { get; set; }

        public XCLCMS.Data.Model.Tags Tags { get; set; }
    }
}