using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.BLL.Strategy.UserInfo
{
    /// <summary>
    /// 保存用户基础信息
    /// </summary>
    public class BaseInfo : BaseStrategy, IStrategy
    {
        public BaseInfo()
        {
            this.Name = "保存用户基础信息";
        }

        public void DoWork<T>(T context)
        {

        }
    }
}
