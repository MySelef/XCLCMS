using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.FileManager.Models.LogicFile
{
    public class ShowVM
    {
        public long AttachmentID { get; set; }

        public XCLCMS.Data.Model.View.v_Attachment Attachment { get; set; }

        public List<XCLCMS.Data.Model.Attachment> SubAttachmentList { get; set; }
    }
}
