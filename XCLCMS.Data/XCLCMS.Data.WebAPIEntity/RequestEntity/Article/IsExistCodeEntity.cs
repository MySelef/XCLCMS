using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.Article
{
    [Serializable]
    public class IsExistCodeEntity
    {
        public string Code { get; set; }

        public long ArticleID { get; set; }
    }
}
