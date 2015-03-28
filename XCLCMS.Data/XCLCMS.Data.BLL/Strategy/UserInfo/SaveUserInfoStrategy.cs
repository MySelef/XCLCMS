using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.BLL.Strategy.UserInfo
{
    /// <summary>
    /// 保存用户信息
    /// </summary>
    public class SaveUserInfoStrategy:BaseStrategy
    {
        public SaveUserInfoStrategy()
        {
            this.Name = "保存用户信息";
            this.Result = StrategyLib.ResultEnum.SUCCESS;
        }

        public void DoWork<T>(T context)
        {
            var strategeList = new List<XCLCMS.Data.BLL.Strategy.BaseStrategy>() { 
                new XCLCMS.Data.BLL.Strategy.UserInfo.BaseInfo(),
                new XCLCMS.Data.BLL.Strategy.UserInfo.RoleInfo()
            };

            if (null != strategeList && strategeList.Count > 0)
            {
                foreach (var m in strategeList)
                {
                    m.DoWork(context);
                    if (m.Result == StrategyLib.ResultEnum.FAIL)
                    {
                        this.Result = StrategyLib.ResultEnum.FAIL;
                        break;
                    }
                }
            }
        }
    }
}
