using Microsoft.Practices.EnterpriseLibrary.Data;

namespace XCLCMS.Data.DAL.Common
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