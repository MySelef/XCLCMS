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
            ///后台_系统设置模块缓存清理
            /// </summary>
            [Description("后台_系统设置模块缓存清理")]
            SysFun_Set_ClearCache = 400125,
            /// <summary>
            ///后台_系统设置模块垃圾数据清理
            /// </summary>
            [Description("后台_系统设置模块垃圾数据清理")]
            SysFun_Set_ClearRubbishData = 400124,
            /// <summary>
            ///后台_系统设置模块系统字典添加
            /// </summary>
            [Description("后台_系统设置模块系统字典添加")]
            SysFun_Set_SysDicAdd = 400113,
            /// <summary>
            ///后台_系统设置模块系统字典删除
            /// </summary>
            [Description("后台_系统设置模块系统字典删除")]
            SysFun_Set_SysDicDel = 400115,
            /// <summary>
            ///后台_系统设置模块系统字典修改
            /// </summary>
            [Description("后台_系统设置模块系统字典修改")]
            SysFun_Set_SysDicEdit = 400114,
            /// <summary>
            ///后台_系统设置模块系统字典查看
            /// </summary>
            [Description("后台_系统设置模块系统字典查看")]
            SysFun_Set_SysDicView = 400112,
            /// <summary>
            ///后台_系统设置模块功能模块添加
            /// </summary>
            [Description("后台_系统设置模块功能模块添加")]
            SysFun_Set_SysFunctionAdd = 400123,
            /// <summary>
            ///后台_系统设置模块功能模块删除
            /// </summary>
            [Description("后台_系统设置模块功能模块删除")]
            SysFun_Set_SysFunctionDel = 400122,
            /// <summary>
            ///后台_系统设置模块功能模块修改
            /// </summary>
            [Description("后台_系统设置模块功能模块修改")]
            SysFun_Set_SysFunctionEdit = 400121,
            /// <summary>
            ///后台_系统设置模块功能模块查看
            /// </summary>
            [Description("后台_系统设置模块功能模块查看")]
            SysFun_Set_SysFunctionView = 400120,
            /// <summary>
            ///后台_系统设置模块系统日志删除
            /// </summary>
            [Description("后台_系统设置模块系统日志删除")]
            SysFun_Set_SysLogDel = 400111,
            /// <summary>
            ///后台_系统设置模块系统日志查看
            /// </summary>
            [Description("后台_系统设置模块系统日志查看")]
            SysFun_Set_SysLogView = 400110,
            /// <summary>
            ///后台_系统设置模块系统配置添加
            /// </summary>
            [Description("后台_系统设置模块系统配置添加")]
            SysFun_Set_SysWebSettingAdd = 400119,
            /// <summary>
            ///后台_系统设置模块系统配置删除
            /// </summary>
            [Description("后台_系统设置模块系统配置删除")]
            SysFun_Set_SysWebSettingDel = 400118,
            /// <summary>
            ///后台_系统设置模块系统配置修改
            /// </summary>
            [Description("后台_系统设置模块系统配置修改")]
            SysFun_Set_SysWebSettingEdit = 400117,
            /// <summary>
            ///后台_系统设置模块系统配置查看
            /// </summary>
            [Description("后台_系统设置模块系统配置查看")]
            SysFun_Set_SysWebSettingView = 400116,
            /// <summary>
            ///后台_用户管理模块用户信息添加
            /// </summary>
            [Description("后台_用户管理模块用户信息添加")]
            SysFun_UserAdmin_UserAdd = 400106,
            /// <summary>
            ///后台_用户管理模块用户信息删除
            /// </summary>
            [Description("后台_用户管理模块用户信息删除")]
            SysFun_UserAdmin_UserDel = 400108,
            /// <summary>
            ///后台_用户管理模块用户信息修改
            /// </summary>
            [Description("后台_用户管理模块用户信息修改")]
            SysFun_UserAdmin_UserEdit = 400107,
            /// <summary>
            ///后台_用户管理模块用户信息查看
            /// </summary>
            [Description("后台_用户管理模块用户信息查看")]
            SysFun_UserAdmin_UserView = 400109,


        }
    }
}
