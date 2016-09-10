using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.FileManager.Models.LogicFile
{
    public class UpdateVM
    {
        public long AttachmentID { get; set; }

        public XCLCMS.Data.Model.View.v_Attachment Attachment { get; set; }
    }
}
