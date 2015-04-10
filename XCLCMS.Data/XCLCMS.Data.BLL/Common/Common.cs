using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.BLL.Common
{
    /// <summary>
    /// BLL层公共操作类
    /// </summary>
    public class Common
    {
        /// <summary>
        /// 生成ID号
        /// </summary>
        public static long GenerateID(XCLCMS.Data.CommonHelper.EnumType.IDTypeEnum IDType, string remark = "")
        {
            return new XCLCMS.Data.BLL.GenerateID().GetGenerateID(IDType.ToString(), remark);
        }

        /// <summary>
        /// 垃圾数据清理
        /// </summary>
        public static void ClearRubbishData()
        {
            XCLCMS.Data.DAL.Common.Common.ClearRubbishData();
        }
    }
}
