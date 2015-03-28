using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.BLL.Strategy
{
    /// <summary>
    /// 策略基类
    /// </summary>
    public class BaseStrategy:IStrategy
    {
        /// <summary>
        /// 当前策略名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 当前策略链备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 当前策略执行结果
        /// </summary>
        public XCLCMS.Data.BLL.Strategy.StrategyLib.ResultEnum Result { get; set; }

        /// <summary>
        /// 当前策略执行结果消息
        /// </summary>
        public string ResultMessage { get; set; }

        /// <summary>
        /// 执行当前策略
        /// </summary>
        public virtual void DoWork<T>(T context)
        {

        }
    }
}
