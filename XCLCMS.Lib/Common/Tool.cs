using System;
using System.Text;

namespace XCLCMS.Lib.Common
{
    /// <summary>
    /// 公共工具类
    /// </summary>
    public class Tool
    {
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
    }
}