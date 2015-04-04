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
    public class UserInfo : BaseStrategy
    {
        /// <summary>
        /// 构造
        /// </summary>
        public UserInfo()
        {
            this.Name = "保存用户基础信息";
        }

        /// <summary>
        /// 执行策略
        /// </summary>
        public override void DoWork<T>(T context)
        {
            var userInfoContext = context as XCLCMS.Data.BLL.Strategy.UserInfo.UserInfoContext;

            if (null == userInfoContext.UserInfo)
            {
                return;
            }

            bool flag = false;
            XCLCMS.Data.BLL.UserInfo bll = new BLL.UserInfo();
            switch (userInfoContext.HandleType)
            { 
                case StrategyLib.HandleType.ADD:
                    flag = bll.Add(userInfoContext.UserInfo);
                    break;
                case StrategyLib.HandleType.UPDATE:
                    flag = bll.Update(userInfoContext.UserInfo);
                    break;
            }

            if (flag)
            {
                this.Result = StrategyLib.ResultEnum.SUCCESS;
            }
            else
            {
                this.Result = StrategyLib.ResultEnum.FAIL;
                this.ResultMessage = "保存用户基础信息失败！";
            }
        }
    }
}
