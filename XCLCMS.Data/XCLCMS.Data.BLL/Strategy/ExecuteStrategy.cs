using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.BLL.Strategy
{
    /// <summary>
    /// 执行策略链
    /// </summary>
    public class ExecuteStrategy
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strategyList">当前待执行的策略链list</param>
        public ExecuteStrategy(List<XCLCMS.Data.BLL.Strategy.BaseStrategy> strategyList)
        {
            this.StrategyList = strategyList;
        }

        private XCLCMS.Data.BLL.Strategy.StrategyLib.ResultEnum _result = StrategyLib.ResultEnum.NONE;

        /// <summary>
        /// 当前策略链执行结果（默认NONE）
        /// </summary>
        public XCLCMS.Data.BLL.Strategy.StrategyLib.ResultEnum Result
        {
            get
            {
                return this._result;
            }
            set
            {
                this._result = value;
            }
        }

        /// <summary>
        /// 当前策略执行结果消息
        /// </summary>
        public string ResultMessage { get; set; }

        /// <summary>
        /// 当前待执行的策略链
        /// </summary>
        public List<XCLCMS.Data.BLL.Strategy.BaseStrategy> StrategyList { get; set; }

        /// <summary>
        /// 执行策略链
        /// </summary>
        public void Execute<T>(T context)
        {
            if (null != this.StrategyList && this.StrategyList.Count > 0)
            {
                for (int i = 0; i < this.StrategyList.Count; i++)
                {
                    var m = this.StrategyList[i];
                    m.DoWork(context);
                    if (m.Result == StrategyLib.ResultEnum.FAIL)
                    {
                        this.Result = StrategyLib.ResultEnum.FAIL;
                        this.ResultMessage = string.Format("第【{0}】个策略【{0}】执行失败！",i+1,m.Name);
                        break;
                    }
                }
            }
        }
    }
}
