using System;
using System.Text;

namespace XCLCMS.Lib.Common
{
    /// <summary>
    /// 公共工具类
    /// </summary>
    public class Tool
    {
        #region 数据字典相关

        /// <summary>
        /// 将指定code的SysDic的子项转为options
        /// </summary>
        public static string GetSysDicOptionsByCode(string code, XCLNetTools.Entity.SetOptionEntity options = null)
        {
            StringBuilder str = new StringBuilder();
            if (null != options && options.IsNeedPleaseSelect)
            {
                str.Append("<option value=''>--请选择--</option>");
            }
            var lst = new XCLCMS.Data.BLL.SysDic().GetChildListByCode(code);
            if (null != lst && lst.Count > 0)
            {
                lst.ForEach(m =>
                {
                    if (null != options)
                    {
                        str.AppendFormat("<option value='{0}' {2}>{1}</option>", m.SysDicID, m.DicName, string.Equals(options.DefaultValue, m.SysDicID.ToString(), StringComparison.OrdinalIgnoreCase) ? " selected='selected' " : "");
                    }
                    else
                    {
                        str.AppendFormat("<option value='{0}'>{1}</option>", m.SysDicID, m.DicName);
                    }
                });
            }
            return str.ToString();
        }

        #endregion 数据字典相关

        #region 文件管理相关

        /// <summary>
        /// 根据文件id，返回用于网站上显示的文件地址
        /// </summary>
        public static string GetAttachmentAbsoluteURL(long id)
        {
            if (id <= 0)
            {
                return null;
            }
            var model = new XCLCMS.Data.BLL.Attachment().GetModel(id);
            return null != model ? GetAttachmentAbsoluteURL(model.URL) : null;
        }

        /// <summary>
        /// 将文件管理中的文件相对路径转为url绝对路径
        /// 如：~/upload/files/123.jpg -> //www.w.com/filemanager/upload/files/123.jpg
        /// </summary>
        public static string GetAttachmentAbsoluteURL(string relativeUrl)
        {
            if (string.IsNullOrWhiteSpace(relativeUrl))
            {
                throw new Exception("未指定参数：relativeUrl！");
            }
            return System.Web.HttpUtility.UrlDecode(relativeUrl).Trim().Replace("~/", XCLCMS.Lib.SysWebSetting.Setting.SettingModel.FileManager_RootURL);
        }

        #endregion 文件管理相关
    }
}