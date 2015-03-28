using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.BLL.Strategy.UserInfo
{
    /// <summary>
    /// 保存用户角色信息
    /// </summary>
    public class RoleInfo : BaseStrategy
    {
        public RoleInfo()
        {
            this.Name = "保存用户角色信息";
        }

        public void DoWork<T>(T context)
        {

        }
    }
}
