using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XCLCMS.Data.DBUtility;//Please add references
namespace XCLCMS.Data.DAL
{
    /// <summary>
    /// 数据访问类:GenerateID
    /// </summary>
    public partial class GenerateID
    {
        public GenerateID()
        { }
        #region  Method

        #endregion  Method
        #region  MethodEx
        /// <summary>
        /// 生成主键
        /// </summary>
        /// <param name="IDType">类型</param>
        public long GetGenerateID(string IDType,string remark="")
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ResultCode", SqlDbType.Int,4),
                    new SqlParameter("@ResultMessage", SqlDbType.NVarChar,1000),
                    new SqlParameter("@IDValue", SqlDbType.BigInt,8),
                    new SqlParameter("@IDCode", SqlDbType.BigInt,8),
                    new SqlParameter("@IDType", SqlDbType.Char,3),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,100)
                    };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Direction = ParameterDirection.Output;
            parameters[2].Direction = ParameterDirection.Output;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Value = IDType;
            parameters[5].Value = remark;
            DbHelperSQL.RunProcedure("proc_GenerateID", parameters,"ds");

            long value = XCLNetTools.StringHander.Common.GetLong(parameters[3].Value);
            if (value > 0)
            {
                return value;
            }
            else
            {
                throw new Exception(Convert.ToString(parameters[1].Value));
            }
        }
        #endregion  MethodEx
    }
}

