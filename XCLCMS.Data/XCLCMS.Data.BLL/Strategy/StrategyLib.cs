using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.BLL.Strategy
{
    /// <summary>
    /// 策略链公共类
    /// </summary>
    public class StrategyLib
    {
        /// <summary>
        /// 执行结果状态枚举
        /// </summary>
        public enum ResultEnum
        { 
            /// <summary>
            /// 成功
            /// </summary>
            SUCCESS,
            /// <summary>
            /// 失败
            /// </summary>
            FAIL
        }

        /// <summary>
        /// 页面操作类型
        /// </summary>
        public enum HandleType
        {
            /// <summary>
            /// 未知
            /// </summary>
            NONE,
            /// <summary>
            /// 添加
            /// </summary>
            ADD,
            /// <summary>
            /// 删除
            /// </summary>
            DEL,
            /// <summary>
            /// 更新
            /// </summary>
            UPDATE,
            /// <summary>
            /// 其它
            /// </summary>
            OTHER
        }
    }
}
