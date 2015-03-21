using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static string GetSysDicOptionsByCode(string code, XCLCMS.Data.CommonHelper.Model.SetOption options = null)
        {
            StringBuilder str = new StringBuilder();
            if (null != options && options.IsNeedPleaseSelect)
            {
                str.Append("<option value=''>--请选择--</option>");
            }
            var lst = new XCLCMS.Data.BLL.SysDic().GetChildListByCode(new Data.Model.SysDic() { 
                Code=code,
                RecordState=XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.N.ToString()
            });
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
