using Microsoft.Practices.EnterpriseLibrary.Data;

namespace XCLCMS.Data.DAL.Common
{
    /// <summary>
    /// DAL基类
    /// </summary>
    public class BaseDAL
    {
        private Database _createDatabase = null;

        /// <summary>
        /// 创建数据库连接
        /// </summary>
        public Database CreateDatabase()
        {
            if (null == this._createDatabase)
            {
                this._createDatabase = new DatabaseProviderFactory().Create("ConnectionString");
            }
            return this._createDatabase;
        }
    }
}