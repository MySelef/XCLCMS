using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.CommonHelper
{
    public class EnumHelper
    {
        /// <summary>
        /// 将枚举转为options
        /// <param name="t">枚举type</param>
        /// <param name="options">选项</param>
        /// </summary>
        public static string GetOptions(Type t, XCLCMS.Data.CommonHelper.Model.SetOption options = null)
        {
            StringBuilder str = new StringBuilder();
            if (null != options && options.IsNeedPleaseSelect)
            {
                str.Append("<option value=''>--请选择--</option>");
            }
            var lst = XCLNetTools.Enum.EnumHelper.GetEnumFieldModelList(t);
            if (null != lst && lst.Count > 0)
            {
                lst.ForEach(m =>
                {
                    if (null != options)
                    {
                        str.AppendFormat("<option value='{0}' {2}>{1}</option>", m.Text, m.Description, string.Equals(options.DefaultValue, m.Text, StringComparison.OrdinalIgnoreCase) ? " selected='selected' " : "");
                    }
                    else
                    {
                        str.AppendFormat("<option value='{0}'>{1}</option>", m.Text, m.Description);
                    }
                });
            }
            return str.ToString();
        }

        /// <summary>
        /// 将所有枚举以json形式显示
        /// 如：{"Enum1":{"N":"正常","D":"已删除"},"Enum2":{"S":"系统","U":"用户"}}
        /// </summary>
        public static readonly string GetAllEnumJson = new Func<string>(() => {
            StringBuilder str = new StringBuilder();
            Type t = typeof(XCLCMS.Data.CommonHelper.EnumType);
            var ms = t.GetNestedTypes();
            if (null != ms && ms.Count() > 0)
            {
                var enumlist = ms.Where(k => k.IsEnum).ToList();
                if (null != enumlist && enumlist.Count > 0)
                {
                    str.Append("{");
                    for (int i = 0; i < enumlist.Count; i++)
                    {
                        var m = enumlist[i];
                        str.AppendFormat(@"""{0}"":{{", m.Name);
                        var fields = m.GetFields().Where(k => k.FieldType.IsEnum).ToList();
                        for (int j = 0; j < fields.Count; j++)
                        {
                            string val = fields[j].Name;
                            string des = "";

                            Object[] customObjs = fields[j].GetCustomAttributes(typeof(DescriptionAttribute), false);
                            if (null != customObjs && customObjs.Length > 0)
                            {
                                des = ((DescriptionAttribute)customObjs[0]).Description;
                            }

                            str.AppendFormat(@"""{0}"":""{1}""", val, des);
                            if (j != fields.Count - 1)
                            {
                                str.Append(",");
                            }
                        }
                        str.Append("}");
                        if (i != enumlist.Count - 1)
                        {
                            str.Append(",");
                        }
                    }
                    str.Append("}");
                }
            }
            return str.ToString();
        }).Invoke();
    }
}
