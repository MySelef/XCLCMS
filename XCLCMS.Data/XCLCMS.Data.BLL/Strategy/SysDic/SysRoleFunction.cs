using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.BLL.Strategy.SysDic
{
    /// <summary>
    /// 保存字典库中的角色功能信息
    /// </summary>
    public class SysRoleFunction:BaseStrategy
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SysRoleFunction()
        {
            this.Name = "保存字典库中的角色功能信息";
        }

        /// <summary>
        /// 执行策略
        /// </summary>
        public override void DoWork<T>(T context)
        {
            var sysDicContext = context as XCLCMS.Data.BLL.Strategy.SysDic.SysDicContext;

            if (null == sysDicContext.FunctionIdList || sysDicContext.FunctionIdList.Count == 0)
            {
                return;
            }

            XCLCMS.Data.BLL.SysRoleFunction bll = new XCLCMS.Data.BLL.SysRoleFunction();

            XCLCMS.Data.Model.SysRoleFunction model = new XCLCMS.Data.Model.SysRoleFunction();
            model.CreaterID = sysDicContext.CurrentUserInfo.UserInfoID;
            model.CreaterName = sysDicContext.CurrentUserInfo.UserName;
            model.CreateTime = DateTime.Now;
            model.UpdaterID = model.CreaterID;
            model.UpdaterName = model.CreaterName;
            model.UpdateTime = model.CreateTime;
            model.FK_SysRoleID = sysDicContext.SysDic.SysDicID;
            model.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString();

            bool flag = bll.Add(model, sysDicContext.FunctionIdList);

            if (flag)
            {
                this.Result = StrategyLib.ResultEnum.SUCCESS;
            }
            else
            {
                this.Result = StrategyLib.ResultEnum.FAIL;
                this.ResultMessage = "保存字典库中的角色功能信息失败！";
            }
        }
    }
}
