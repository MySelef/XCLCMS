using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.BLL.Strategy.SysDic
{
    /// <summary>
    /// 保存字典库基本信息
    /// </summary>
    public class SysDic:BaseStrategy
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SysDic()
        {
            this.Name = "保存字典库基本信息";
        }

        /// <summary>
        /// 执行策略
        /// </summary>
        public override void DoWork<T>(T context)
        {
            var sysDicContext = context as XCLCMS.Data.BLL.Strategy.SysDic.SysDicContext;

            if (null == sysDicContext.SysDic)
            {
                return;
            }

            bool flag = false;
            XCLCMS.Data.BLL.SysDic bll = new BLL.SysDic();
            switch (sysDicContext.HandleType)
            {
                case StrategyLib.HandleType.ADD:
                    flag = bll.Add(sysDicContext.SysDic);
                    break;
                case StrategyLib.HandleType.UPDATE:
                    flag = bll.Update(sysDicContext.SysDic);
                    break;
            }

            if (flag)
            {
                this.Result = StrategyLib.ResultEnum.SUCCESS;
            }
            else
            {
                this.Result = StrategyLib.ResultEnum.FAIL;
                this.ResultMessage = "保存字典库基本信息失败！";
            }
        }
    }
}
