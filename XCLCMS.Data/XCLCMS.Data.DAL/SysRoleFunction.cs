using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using XCLCMS.Data.DBUtility;

namespace XCLCMS.Data.DAL
{
    /// <summary>
    /// 数据访问类:SysRoleFunction
    /// </summary>
    public partial class SysRoleFunction
    {
        public SysRoleFunction()
        { }
        #region  Method

        /// <summary>
        ///  增加一条数据
        ///  注：如果functionIdList为空，则添加model.FK_SysFunctionID，否则，则添加functionIdList
        /// </summary>
        public bool Add(XCLCMS.Data.Model.SysRoleFunction model,List<long> functionIdList=null)
        {
            if (null == functionIdList || functionIdList.Count == 0)
            {
                if (model.FK_SysFunctionID > 0)
                {
                    functionIdList = new List<long>() { 
                        model.FK_SysFunctionID
                    };
                }
            }

            SqlParameter[] parameters = {
					new SqlParameter("@FK_SysRoleID", SqlDbType.BigInt,8),
					new SqlParameter("@FK_SysFunctionIDXML", SqlDbType.Xml),
					new SqlParameter("@RecordState", SqlDbType.Char,1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreaterID", SqlDbType.BigInt,8),
					new SqlParameter("@CreaterName", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdaterID", SqlDbType.BigInt,8),
					new SqlParameter("@UpdaterName", SqlDbType.NVarChar,50),
                                        
					new SqlParameter("@ResultCode", SqlDbType.Int,4),
					new SqlParameter("@ResultMessage", SqlDbType.NVarChar,1000)
                   };
            parameters[0].Value = model.FK_SysRoleID;
            parameters[1].Value = XCLNetTools.XML.SerializeHelper.Serializer<List<long>>(functionIdList);
            parameters[2].Value = model.RecordState;
            parameters[3].Value = model.CreateTime;
            parameters[4].Value = model.CreaterID;
            parameters[5].Value = model.CreaterName;
            parameters[6].Value = model.UpdateTime;
            parameters[7].Value = model.UpdaterID;
            parameters[8].Value = model.UpdaterName;

            parameters[9].Direction = ParameterDirection.Output;
            parameters[10].Direction = ParameterDirection.Output;

            DbHelperSQL.RunProcedure("sp_SysRoleFunction_ADD", parameters, "ds");

            var result = XCLCMS.Data.DAL.CommonDAL.CommonDALHelper.GetProcedureResult(parameters);
            if (result.IsSuccess)
            {
                return true;
            }
            else
            {
                throw new Exception(result.ResultMessage);
            }
        }

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

