using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Lib.Permission
{
    /// <summary>
    /// 系统功能相关
    /// </summary>
    public class Function
    {
        /// <summary>
        /// 所有功能枚举（数据来源于存储过程proc_Sys_GetFunctionEnumList）
        /// </summary>
        public enum FunctionEnum
        {
            /// <summary>
            ///用户基本信息-用户基本信息添加
            /// </summary>
            [Description("用户基本信息-用户基本信息添加")]
            SysFun_UserAdmin_UserAdd = 400135,
            /// <summary>
            ///用户基本信息-用户基本信息删除
            /// </summary>
            [Description("用户基本信息-用户基本信息删除")]
            SysFun_UserAdmin_UserDel = 400136,
            /// <summary>
            ///用户基本信息-用户基本信息修改
            /// </summary>
            [Description("用户基本信息-用户基本信息修改")]
            SysFun_UserAdmin_UserEdit = 400137,
            /// <summary>
            ///用户基本信息-用户基本信息查看
            /// </summary>
            [Description("用户基本信息-用户基本信息查看")]
            SysFun_UserAdmin_UserView = 400138,
            /// <summary>
            ///系统日志-系统日志查看
            /// </summary>
            [Description("系统日志-系统日志查看")]
            SysFun_Set_SysLogView = 400140,
            /// <summary>
            ///系统日志-系统日志删除
            /// </summary>
            [Description("系统日志-系统日志删除")]
            SysFun_Set_SysLogDel = 400141,
            /// <summary>
            ///系统字典-系统字典添加
            /// </summary>
            [Description("系统字典-系统字典添加")]
            SysFun_Set_SysDicAdd = 400143,
            /// <summary>
            ///系统字典-系统字典删除
            /// </summary>
            [Description("系统字典-系统字典删除")]
            SysFun_Set_SysDicDel = 400144,
            /// <summary>
            ///系统字典-系统字典修改
            /// </summary>
            [Description("系统字典-系统字典修改")]
            SysFun_Set_SysDicEdit = 400145,
            /// <summary>
            ///系统字典-系统字典查看
            /// </summary>
            [Description("系统字典-系统字典查看")]
            SysFun_Set_SysDicView = 400146,
            /// <summary>
            ///系统配置-系统配置添加
            /// </summary>
            [Description("系统配置-系统配置添加")]
            SysFun_Set_SysWebSettingAdd = 400148,
            /// <summary>
            ///系统配置-系统配置删除
            /// </summary>
            [Description("系统配置-系统配置删除")]
            SysFun_Set_SysWebSettingDel = 400149,
            /// <summary>
            ///系统配置-系统配置修改
            /// </summary>
            [Description("系统配置-系统配置修改")]
            SysFun_Set_SysWebSettingEdit = 400150,
            /// <summary>
            ///系统配置-系统配置查看
            /// </summary>
            [Description("系统配置-系统配置查看")]
            SysFun_Set_SysWebSettingView = 400151,
            /// <summary>
            ///功能模块-功能模块添加
            /// </summary>
            [Description("功能模块-功能模块添加")]
            SysFun_Set_SysFunctionAdd = 400153,
            /// <summary>
            ///功能模块-功能模块删除
            /// </summary>
            [Description("功能模块-功能模块删除")]
            SysFun_Set_SysFunctionDel = 400154,
            /// <summary>
            ///功能模块-功能模块修改
            /// </summary>
            [Description("功能模块-功能模块修改")]
            SysFun_Set_SysFunctionEdit = 400155,
            /// <summary>
            ///功能模块-功能模块查看
            /// </summary>
            [Description("功能模块-功能模块查看")]
            SysFun_Set_SysFunctionView = 400156,
            /// <summary>
            ///其它-垃圾数据清理
            /// </summary>
            [Description("其它-垃圾数据清理")]
            SysFun_Set_ClearRubbishData = 400158,
            /// <summary>
            ///其它-缓存清理
            /// </summary>
            [Description("其它-缓存清理")]
            SysFun_Set_ClearCache = 400159,

        }
    }
}
