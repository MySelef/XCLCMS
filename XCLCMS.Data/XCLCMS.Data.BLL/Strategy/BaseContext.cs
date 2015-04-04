using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.BLL.Strategy
{
    /// <summary>
    /// 上下文基类
    /// </summary>
    public class BaseContext
    {
        /// <summary>
        /// 当前用户信息
        /// </summary>
        public XCLCMS.Data.Model.UserInfo CurrentUserInfo { get; set; }

        /// <summary>
        /// 操作类型枚举
        /// </summary>
        public XCLCMS.Data.BLL.Strategy.StrategyLib.HandleType HandleType { get; set; }
    }
}
