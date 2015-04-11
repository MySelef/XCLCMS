using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.BLL.Strategy.SysRole
{
    /// <summary>
    /// 保存角色功能信息
    /// </summary>
    public class SysRoleFunction:BaseStrategy
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SysRoleFunction()
        {
            this.Name = "保存角色功能信息";
        }

        /// <summary>
        /// 执行策略
        /// </summary>
        public override void DoWork<T>(T context)
        {
            var sysRoleContext = context as XCLCMS.Data.BLL.Strategy.SysRole.SysRoleContext;
            
            XCLCMS.Data.BLL.SysRoleFunction bll = new XCLCMS.Data.BLL.SysRoleFunction();

            XCLCMS.Data.Model.SysRoleFunction model = new XCLCMS.Data.Model.SysRoleFunction();
            model.CreaterID = sysRoleContext.CurrentUserInfo.UserInfoID;
            model.CreaterName = sysRoleContext.CurrentUserInfo.UserName;
            model.CreateTime = DateTime.Now;
            model.UpdaterID = model.CreaterID;
            model.UpdaterName = model.CreaterName;
            model.UpdateTime = model.CreateTime;
            model.FK_SysRoleID = sysRoleContext.SysRole.SysRoleID;
            model.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString();

            bool flag = false;
            try
            {
                flag = bll.Add(model, sysRoleContext.FunctionIdList);
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
                this.ResultMessage = string.Format("保存角色功能信息失败！{0}", this.ResultMessage);
            }
        }
    }
}
