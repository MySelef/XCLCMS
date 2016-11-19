namespace XCLCMS.Lib.Model
{
    /// <summary>
    /// 站点配置model
    /// </summary>
    public class SettingModel
    {
        /// <summary>
        /// 添加用户信息时的默认密码
        /// </summary>
        public string Common_UserDefaultPwd { get; set; }

        /// <summary>
        /// 后台系统退出地址
        /// </summary>
        public string Admin_LogOutURL { get; set; }

        /// <summary>
        /// 后台系统登录页地址
        /// </summary>
        public string Admin_LogOnURL { get; set; }

        /// <summary>
        /// 文件管理根路径
        /// </summary>
        public string FileManager_RootURL { get; set; }

        /// <summary>
        /// 文件管理中的文件列表首页
        /// </summary>
        public string FileManager_FileListURL { get; set; }

        /// <summary>
        /// 文件管理中的文件上传页面
        /// </summary>
        public string FileManager_FileUploadURL { get; set; }

        /// <summary>
        /// 文件管理中的逻辑文件列表首页
        /// </summary>
        public string FileManager_LogicFileListURL { get; set; }

        /// <summary>
        /// 文件管理查看附件的公共地址
        /// </summary>
        public string FileManager_OpenAPI_ShowAttachmentURL { get; set; }
    }
}