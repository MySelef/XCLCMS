using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using XCLCMS.Data.DBUtility;//Please add references
namespace XCLCMS.Data.DAL
{
    /// <summary>
    /// 数据访问类:UserInfo
    /// </summary>
    public partial class UserInfo
    {
        public UserInfo()
        { }
        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.UserInfo GetModel(long UserInfoID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UserInfoID", SqlDbType.BigInt,8)			};
            parameters[0].Value = UserInfoID;

            XCLCMS.Data.Model.UserInfo model = new XCLCMS.Data.Model.UserInfo();
            DataSet ds = DbHelperSQL.Query("select * from UserInfo where UserInfoID=@UserInfoID", parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.UserInfo DataRowToModel(DataRow row)
        {
            XCLCMS.Data.Model.UserInfo model = new XCLCMS.Data.Model.UserInfo();
            if (row != null)
            {
                if (row["UserInfoID"] != null && row["UserInfoID"].ToString() != "")
                {
                    model.UserInfoID = long.Parse(row["UserInfoID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["RealName"] != null)
                {
                    model.RealName = row["RealName"].ToString();
                }
                if (row["NickName"] != null)
                {
                    model.NickName = row["NickName"].ToString();
                }
                if (row["Pwd"] != null)
                {
                    model.Pwd = row["Pwd"].ToString();
                }
                if (row["Age"] != null && row["Age"].ToString() != "")
                {
                    model.Age = int.Parse(row["Age"].ToString());
                }
                if (row["SexType"] != null)
                {
                    model.SexType = row["SexType"].ToString();
                }
                if (row["Birthday"] != null && row["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(row["Birthday"].ToString());
                }
                if (row["Tel"] != null)
                {
                    model.Tel = row["Tel"].ToString();
                }
                if (row["QQ"] != null)
                {
                    model.QQ = row["QQ"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["OtherContact"] != null)
                {
                    model.OtherContact = row["OtherContact"].ToString();
                }
                if (row["AccessType"] != null)
                {
                    model.AccessType = row["AccessType"].ToString();
                }
                if (row["AccessToken"] != null)
                {
                    model.AccessToken = row["AccessToken"].ToString();
                }
                if (row["UserState"] != null)
                {
                    model.UserState = row["UserState"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["RoleName"] != null)
                {
                    model.RoleName = row["RoleName"].ToString();
                }
                if (row["RoleMaxWeight"] != null && row["RoleMaxWeight"].ToString() != "")
                {
                    model.RoleMaxWeight = int.Parse(row["RoleMaxWeight"].ToString());
                }
                if (row["RecordState"] != null)
                {
                    model.RecordState = row["RecordState"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["CreaterID"] != null && row["CreaterID"].ToString() != "")
                {
                    model.CreaterID = long.Parse(row["CreaterID"].ToString());
                }
                if (row["CreaterName"] != null)
                {
                    model.CreaterName = row["CreaterName"].ToString();
                }
                if (row["UpdateTime"] != null && row["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
                }
                if (row["UpdaterID"] != null && row["UpdaterID"].ToString() != "")
                {
                    model.UpdaterID = long.Parse(row["UpdaterID"].ToString());
                }
                if (row["UpdaterName"] != null)
                {
                    model.UpdaterName = row["UpdaterName"].ToString();
                }
            }
            return model;
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserInfoID,UserName,RealName,NickName,Pwd,Age,SexType,Birthday,Tel,QQ,Email,OtherContact,AccessType,AccessToken,UserState,Remark,RoleName,RoleMaxWeight,RecordState,CreateTime,CreaterID,CreaterName,UpdateTime,UpdaterID,UpdaterName ");
            strSql.Append(" FROM UserInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
        #region  MethodEx
        /// <summary>
        /// 分页数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.UserInfo>  GetPageList(int pageSize, int pageIndex, ref int recordCount, string strWhere, string fieldName, string fieldKey, string fieldOrder)
        {
            DataTable dt= XCLCMS.Data.DAL.CommonDAL.CommonDALHelper.GetPageList("UserInfo", pageSize, pageIndex, ref recordCount, strWhere, fieldName, fieldKey, fieldOrder);
            return XCLNetTools.Generic.ListHelper<XCLCMS.Data.Model.UserInfo>.DataTableToList(dt) as List<XCLCMS.Data.Model.UserInfo>;
        }

        /// <summary>
        /// 判断指定用户名是否存在
        /// </summary>
        public bool IsExistUserName(string userName)
        {
            string strSql = " select top 1 1 from UserInfo where UserName=@UserName";
            SqlParameter[] parameters = { 
                                        new SqlParameter("@UserName", SqlDbType.VarChar, 50)
                                        };
            parameters[0].Value = userName;
            return DbHelperSQL.Exists(strSql, parameters);
        }

        /// <summary>
        /// 根据用户名和密码获取用户实体
        /// </summary>
        public XCLCMS.Data.Model.UserInfo GetModel(string userName, string pwd)
        {
            XCLCMS.Data.Model.UserInfo model = null;
            string strSql = " select top 1 * from UserInfo where UserName=@UserName and Pwd=@Pwd";
            SqlParameter[] parameters = { 
                                        new SqlParameter("@UserName", SqlDbType.VarChar, 50),
                                        new SqlParameter("@Pwd", SqlDbType.VarChar, 50)
                                        };
            parameters[0].Value = userName;
            parameters[1].Value = pwd;
            DataSet ds= DbHelperSQL.Query(strSql, parameters);
            if (null != ds && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count>0)
            {
                model = this.DataRowToModel(ds.Tables[0].Rows[0]);
            }
            return model;
        }

        /// <summary>
        ///  增加一条数据(带其它信息)
        /// </summary>
        public bool Add(XCLCMS.Data.Model.Custom.UserInfoWithMore model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@UserInfoID", SqlDbType.BigInt,8),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@NickName", SqlDbType.NVarChar,50),
					new SqlParameter("@Pwd", SqlDbType.VarChar,50),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@SexType", SqlDbType.Char,1),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@OtherContact", SqlDbType.NVarChar,500),
					new SqlParameter("@AccessType", SqlDbType.VarChar,50),
					new SqlParameter("@AccessToken", SqlDbType.VarChar,100),
					new SqlParameter("@UserState", SqlDbType.Char,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,1000),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,100),
					new SqlParameter("@RoleMaxWeight", SqlDbType.Int,4),
					new SqlParameter("@RecordState", SqlDbType.Char,1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreaterID", SqlDbType.BigInt,8),
					new SqlParameter("@CreaterName", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdaterID", SqlDbType.BigInt,8),
					new SqlParameter("@UpdaterName", SqlDbType.NVarChar,50),

                    new SqlParameter("@UserRoleIDXML",SqlDbType.Xml),//用户角色id
                    new SqlParameter("@WithMoreState",SqlDbType.Int)//存储过程功能分组状态位
                                        };
            parameters[0].Value = model.UserInfo.UserInfoID;
            parameters[1].Value = model.UserInfo.UserName;
            parameters[2].Value = model.UserInfo.RealName;
            parameters[3].Value = model.UserInfo.NickName;
            parameters[4].Value = model.UserInfo.Pwd;
            parameters[5].Value = model.UserInfo.Age;
            parameters[6].Value = model.UserInfo.SexType;
            parameters[7].Value = model.UserInfo.Birthday;
            parameters[8].Value = model.UserInfo.Tel;
            parameters[9].Value = model.UserInfo.QQ;
            parameters[10].Value = model.UserInfo.Email;
            parameters[11].Value = model.UserInfo.OtherContact;
            parameters[12].Value = model.UserInfo.AccessType;
            parameters[13].Value = model.UserInfo.AccessToken;
            parameters[14].Value = model.UserInfo.UserState;
            parameters[15].Value = model.UserInfo.Remark;
            parameters[16].Value = model.UserInfo.RoleName;
            parameters[17].Value = model.UserInfo.RoleMaxWeight;
            parameters[18].Value = model.UserInfo.RecordState;
            parameters[19].Value = model.UserInfo.CreateTime;
            parameters[20].Value = model.UserInfo.CreaterID;
            parameters[21].Value = model.UserInfo.CreaterName;
            parameters[22].Value = model.UserInfo.UpdateTime;
            parameters[23].Value = model.UserInfo.UpdaterID;
            parameters[24].Value = model.UserInfo.UpdaterName;

            //角色处理
            string roleXML = string.Empty;
            if (null != model.UserRoleIDs && model.UserRoleIDs.Count > 0)
            {
                roleXML = XCLNetTools.XML.SerializeHelper.Serializer<List<long>>(model.UserRoleIDs);
            }
            parameters[25].Value = roleXML;
            parameters[26].Value = model.WithMoreState;


            DbHelperSQL.RunProcedure("UserInfo_ADD", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  更新一条数据(带其它信息)
        /// </summary>
        public bool Update(XCLCMS.Data.Model.Custom.UserInfoWithMore model)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@UserInfoID", SqlDbType.BigInt,8),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@RealName", SqlDbType.NVarChar,50),
					new SqlParameter("@NickName", SqlDbType.NVarChar,50),
					new SqlParameter("@Pwd", SqlDbType.VarChar,50),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@SexType", SqlDbType.Char,1),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@OtherContact", SqlDbType.NVarChar,500),
					new SqlParameter("@AccessType", SqlDbType.VarChar,50),
					new SqlParameter("@AccessToken", SqlDbType.VarChar,100),
					new SqlParameter("@UserState", SqlDbType.Char,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,1000),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,100),
					new SqlParameter("@RoleMaxWeight", SqlDbType.Int,4),
					new SqlParameter("@RecordState", SqlDbType.Char,1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreaterID", SqlDbType.BigInt,8),
					new SqlParameter("@CreaterName", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdaterID", SqlDbType.BigInt,8),
					new SqlParameter("@UpdaterName", SqlDbType.NVarChar,50),
                    new SqlParameter("@UserRoleIDXML",SqlDbType.Xml),//用户角色id
                    new SqlParameter("@WithMoreState",SqlDbType.Int)//存储过程功能分组状态位
                                        };
            parameters[0].Value = model.UserInfo.UserInfoID;
            parameters[1].Value = model.UserInfo.UserName;
            parameters[2].Value = model.UserInfo.RealName;
            parameters[3].Value = model.UserInfo.NickName;
            parameters[4].Value = model.UserInfo.Pwd;
            parameters[5].Value = model.UserInfo.Age;
            parameters[6].Value = model.UserInfo.SexType;
            parameters[7].Value = model.UserInfo.Birthday;
            parameters[8].Value = model.UserInfo.Tel;
            parameters[9].Value = model.UserInfo.QQ;
            parameters[10].Value = model.UserInfo.Email;
            parameters[11].Value = model.UserInfo.OtherContact;
            parameters[12].Value = model.UserInfo.AccessType;
            parameters[13].Value = model.UserInfo.AccessToken;
            parameters[14].Value = model.UserInfo.UserState;
            parameters[15].Value = model.UserInfo.Remark;
            parameters[16].Value = model.UserInfo.RoleName;
            parameters[17].Value = model.UserInfo.RoleMaxWeight;
            parameters[18].Value = model.UserInfo.RecordState;
            parameters[19].Value = model.UserInfo.CreateTime;
            parameters[20].Value = model.UserInfo.CreaterID;
            parameters[21].Value = model.UserInfo.CreaterName;
            parameters[22].Value = model.UserInfo.UpdateTime;
            parameters[23].Value = model.UserInfo.UpdaterID;
            parameters[24].Value = model.UserInfo.UpdaterName;

            //角色处理
            string roleXML = string.Empty;
            if (null != model.UserRoleIDs && model.UserRoleIDs.Count > 0)
            {
                roleXML = XCLNetTools.XML.SerializeHelper.Serializer<List<long>>(model.UserRoleIDs);
            }
            parameters[25].Value = roleXML;
            parameters[26].Value = model.WithMoreState;

            DbHelperSQL.RunProcedure("UserInfo_Update", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  MethodEx
    }
}

