using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;

namespace XCLCMS.Data.Common
{
    /// <summary>
    /// DAL基类
    /// </summary>
    public class BaseDAL
    {
        /// <summary>
        /// 创建数据库连接
        /// </summary>
        public Database CreateDatabase()
        {
            return new DatabaseProviderFactory().Create("ConnectionString");
        }
    }
}
