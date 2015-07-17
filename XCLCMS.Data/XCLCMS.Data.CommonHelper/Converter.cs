using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Data.CommonHelper
{
    /// <summary>
    /// 数据转换
    /// </summary>
    public class Converter
    {
        /// <summary>
        /// 将list long 转为datatable（列名为ID）
        /// </summary>
        public static DataTable ConvertToIDTable(List<long> lst)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(long));
            if (null != lst && lst.Count > 0)
            {
                foreach (var m in lst)
                {
                    var dr = dt.NewRow();
                    dr["ID"] = m;
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
    }
}
