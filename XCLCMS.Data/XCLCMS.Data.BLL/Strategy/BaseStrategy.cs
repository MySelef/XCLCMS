namespace XCLCMS.Data.BLL.Strategy
{
    /// <summary>
    /// 策略基类
    /// </summary>
    public class BaseStrategy
    {
        private XCLCMS.Data.BLL.Strategy.StrategyLib.ResultEnum _result = StrategyLib.ResultEnum.SUCCESS;

        /// <summary>
        /// 当前策略名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 当前策略链备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 当前策略执行结果（默认SUCCESS）
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
        /// 执行当前策略
        /// </summary>
        public virtual void DoWork<T>(T context)
        {
        }
    }
}