using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace XCLCMS.Data.CommonHelper
{
    /// <summary>
    /// 枚举类型
    /// </summary>
    /// <remarks>
    /// 所有枚举，定长char
    /// </remarks>
    public class EnumType
    {
        #region 公共
        /// <summary>
        /// 主体类型
        /// </summary>
        public enum  ObjectTypeEnum
        {
            /// <summary>
            /// 文章表 Article
            /// </summary>
            [Description("文章表")]
            ART,
            /// <summary>
            /// 产品表 Product
            /// </summary>
            [Description("产品表")]
            PRO
        }

        /// <summary>
        /// 是否
        /// </summary>
        public enum YesNoEnum
        { 
            /// <summary>
            /// 是 Yes
            /// </summary>
            [Description("是")]
            Y,
            /// <summary>
            /// 否 No
            /// </summary>
            [Description("否")]
            N
        }

        /// <summary>
        /// 记录状态
        /// </summary>
        public enum RecordStateEnum
        {
            /// <summary>
            /// 正常 Normal
            /// </summary>
            [Description("正常")]
            N,
            /// <summary>
            /// 回收 Recycle
            /// </summary>
            [Description("回收")]
            R,
            /// <summary>
            /// 已删除 Deleted
            /// </summary>
            [Description("已删除")]
            D
        }

        /// <summary>
        /// 链接打开方式
        /// </summary>
        public enum URLOpenTypeEnum
        { 
            /// <summary>
            /// 默认 None
            /// </summary>
            [Description("NON")]
            NON,
            /// <summary>
            /// 新窗口 _blank
            /// </summary>
            [Description("新窗口")]
            BLA
        }

        /// <summary>
        /// 审核状态
        /// </summary>
        public enum VerifyStateEnum
        {
            /// <summary>
            /// 待审核  Wait
            /// </summary>
            [Description("待审核")]
            WAT,
            /// <summary>
            /// 审核不通过 No
            /// </summary>
            [Description("审核不通过")]
            NON,
            /// <summary>
            /// 审核通过 Yes
            /// </summary>
            [Description("审核通过")]
            YES
        }
        #endregion

        #region 文章
        /// <summary>
        /// 文章状态
        /// </summary>
        public enum ArticleStateEnum
        { 
            /// <summary>
            /// 草稿 Draft
            /// </summary>
            [Description("草稿")]
            DRA,
            /// <summary>
            /// 已发布 Published
            /// </summary>
            [Description("已发布")]
            PUB
        }

        /// <summary>
        /// 文章内容类型
        /// </summary>
        public enum ArticleContentTypeEnum
        {
            /// <summary>
            /// 普通文章 Normal
            /// </summary>
            [Description("普通文章")]
            NOR,
            /// <summary>
            /// 图片浏览 Image
            /// </summary>
            [Description("图片浏览")]
            IMG,
            /// <summary>
            /// 视频观看 Video
            /// </summary>
            [Description("视频观看")]
            VID,
            /// <summary>
            /// 仅跳转链接 URL
            /// </summary>
            [Description("仅跳转链接")]
            URL
        }
        #endregion

        #region 附件
        /// <summary>
        /// 附件浏览方式
        /// </summary>
        public enum AttachmentViewTypeEnum
        { 
            /// <summary>
            /// 普通 Normal
            /// </summary>
            [Description("普通")]
            NOR,
            /// <summary>
            /// 需要下载 Download
            /// </summary>
            [Description("需要下载")]
            DOW
        }

        /// <summary>
        /// 附件格式类型
        /// </summary>
        public enum AttachmentFormatTypeEnum
        { 
            /// <summary>
            /// 文字 Word
            /// </summary>
            [Description("文字")]
            WOR,
            /// <summary>
            /// 图片 Image
            /// </summary>
            [Description("图片")]
            IMG,
            /// <summary>
            /// 视频 Video
            /// </summary>
            [Description("视频")]
            VID,
            /// <summary>
            /// 压缩包 RAR
            /// </summary>
            [Description("压缩包")]
            RAR,
            /// <summary>
            /// 其它 Other
            /// </summary>
            [Description("其它")]
            OTH
        }


        #endregion

        #region 建议反馈
        /// <summary>
        /// 反馈类型
        /// </summary>
        public enum FeedbackTypeEnum
        { 
            /// <summary>
            /// 建议 Advise
            /// </summary>
            [Description("建议与意见")]
            ADV,
            /// <summary>
            /// 系统异常 Error
            /// </summary>
            [Description("系统异常")]
            ERR
        }
        #endregion

        #region 字典库
        /// <summary>
        /// 字典类型
        /// </summary>
        public enum DicTypeEnum
        { 
            /// <summary>
            /// 系统级 System
            /// </summary>
            [Description("系统级")]
            S,
            /// <summary>
            /// 用户级 User
            /// </summary>
            [Description("用户级")]
            U
        }
        #endregion

        #region 用户
        /// <summary>
        /// 性别
        /// </summary>
        public enum UserSexTypeEnum
        { 
            /// <summary>
            /// 男 Man
            /// </summary>
            [Description("男")]
            M,
            /// <summary>
            /// 女 Female
            /// </summary>
            [Description("女")]
            F
        }
        /// <summary>
        /// 用户状态
        /// </summary>
        public enum UserStateEnum
        { 
            /// <summary>
            /// 正常 Normal
            /// </summary>
            [Description("正常")]
            N,
            /// <summary>
            /// 禁用 Disabled
            /// </summary>
            [Description("禁用")]
            D
        }
        #endregion

        #region 日志
        /// <summary>
        /// 日志类型  (该类型varchar(50))
        /// </summary>
        public enum LogTypeEnum
        { 
            /// <summary>
            /// 系统日志 System
            /// </summary>
            [Description("系统日志")]
            SYSTEM,
            /// <summary>
            /// 登录日志 Logon
            /// </summary>
            [Description("登录日志")]
            LOGIN,
            /// <summary>
            /// 其它日志 Other
            /// </summary>
            [Description("其它日志")]
            OTHER
        }
        #endregion

        #region 广告
        /// <summary>
        /// 广告类型
        /// </summary>
        public enum AdsTypeEnum
        { 
            /// <summary>
            /// 文字 Word
            /// </summary>
            [Description("文字")]
            WOR,
            /// <summary>
            /// 图片 Image
            /// </summary>
            [Description("图片")]
            IMG,
            /// <summary>
            /// 纯代码 Code
            /// </summary>
            [Description("纯代码")]
            COD
        }
        #endregion

        #region 商户
        /// <summary>
        /// 商户状态
        /// </summary>
        public enum MerchantStateEnum
        {
            /// <summary>
            /// 有效 Yes
            /// </summary>
            [Description("有效")]
            Y,
            /// <summary>
            /// 无效 No
            /// </summary>
            [Description("无效")]
            N
        }
        #endregion

        #region ID生成
        /// <summary>
        /// ID生成类型
        /// </summary>
        public enum IDTypeEnum
        { 
            /// <summary>
            /// 用户信息  UserInfo
            /// </summary>
            [Description("用户信息")]
            USR,
            /// <summary>
            /// 系统配置  SysWebSetting
            /// </summary>
            [Description("系统配置")]
            SET,
            /// <summary>
            /// 系统字典 SysDic
            /// </summary>
            [Description("系统字典")]
            DIC,
            /// <summary>
            /// 系统功能 SysFunction
            /// </summary>
            [Description("系统功能")]
            FUN,
            /// <summary>
            /// 角色 Role
            /// </summary>
            [Description("角色")]
            RLE,
            /// <summary>
            /// 商户 Merchant
            /// </summary>
            [Description("商户")]
            MER
        }
        #endregion

    }

}
