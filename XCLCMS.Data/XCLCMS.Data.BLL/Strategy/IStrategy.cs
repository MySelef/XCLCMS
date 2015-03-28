using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.BLL.Strategy
{
    /// <summary>
    /// 策略接口
    /// </summary>
    public interface IStrategy
    {
        /// <summary>
        /// 当前策略名
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 当前策略链备注
        /// </summary>
        string Remark { get; set; }

        /// <summary>
        /// 当前策略执行结果
        /// </summary>
        XCLCMS.Data.BLL.Strategy.StrategyLib.ResultEnum Result { get; set; }

        /// <summary>
        /// 当前策略执行结果消息
        /// </summary>
        string ResultMessage { get; set; }

        /// <summary>
        /// 执行策略链
        /// </summary>
        void DoWork<T>(T context);
    }
}
