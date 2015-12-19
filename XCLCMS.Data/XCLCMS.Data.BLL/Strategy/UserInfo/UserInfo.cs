using System;

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

            try
            {
                switch (userInfoContext.HandleType)
                {
                    case StrategyLib.HandleType.ADD:
                        flag = bll.Add(userInfoContext.UserInfo);
                        break;

                    case StrategyLib.HandleType.UPDATE:
                        flag = bll.Update(userInfoContext.UserInfo);
                        break;
                }
            }
            catch (Exception ex)
            {
                flag = false;
                this.ResultMessage += string.Format("异常信息：{0}", ex.Message);
            }

            if (flag)
            {
                this.Result = StrategyLib.ResultEnum.SUCCESS;
            }
            else
            {
                this.Result = StrategyLib.ResultEnum.FAIL;
                this.ResultMessage = string.Format("保存用户基础信息失败！{0}", this.ResultMessage);
            }
        }
    }
}