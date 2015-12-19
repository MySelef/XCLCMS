using System;
using System.Collections.Generic;
using System.Data;

namespace XCLCMS.Data.BLL
{
    /// <summary>
    /// 系统功能表
    /// </summary>
    public partial class SysFunction
    {
        private readonly XCLCMS.Data.DAL.SysFunction dal = new XCLCMS.Data.DAL.SysFunction();

        public SysFunction()
        { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.SysFunction model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(XCLCMS.Data.Model.SysFunction model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.SysFunction GetModel(long SysFunctionID)
        {
            return dal.GetModel(SysFunctionID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.SysFunction> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.SysFunction> DataTableToList(DataTable dt)
        {
            List<XCLCMS.Data.Model.SysFunction> modelList = new List<XCLCMS.Data.Model.SysFunction>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                XCLCMS.Data.Model.SysFunction model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        #endregion BasicMethod

        #region ExtensionMethod

        /// <summary>
        /// 判断功能标识是否存在
        /// </summary>
        public bool IsExistCode(string code)
        {
            return dal.IsExistCode(code);
        }

        /// <summary>
        /// 验证某个用户是否拥有指定功能列表中的某个功能权限
        /// </summary>
        public bool CheckUserHasAnyFunction(long userId, List<long> functionList)
        {
            return dal.CheckUserHasAnyFunction(userId, functionList);
        }

        /// <summary>
        /// 获取指定角色的所有功能
        /// </summary>
        /// <param name="sysRoleID">角色ID</param>
        public List<XCLCMS.Data.Model.SysFunction> GetListByRoleID(long sysRoleID)
        {
            List<XCLCMS.Data.Model.SysFunction> lst = null;
            DataTable dt = dal.GetListByRoleID(sysRoleID);
            if (null != dt && dt.Rows.Count > 0)
            {
                lst = this.DataTableToList(dt);
            }
            return lst;
        }

        /// <summary>
        /// 获取当前SysFunctionID所属的层级list
        /// 如:根目录/子目录/文件
        /// </summary>
        public List<XCLCMS.Data.Model.Custom.SysFunctionSimple> GetLayerListBySysFunctionId(long sysFunctionId)
        {
            List<XCLCMS.Data.Model.Custom.SysFunctionSimple> lst = null;
            DataTable dt = dal.GetLayerListBySysFunctionID(sysFunctionId);
            if (null != dt && dt.Rows.Count > 0)
            {
                lst = new List<XCLCMS.Data.Model.Custom.SysFunctionSimple>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    XCLCMS.Data.Model.Custom.SysFunctionSimple model = new XCLCMS.Data.Model.Custom.SysFunctionSimple()
                    {
                        FunctionName = dt.Rows[i]["FunctionName"].ToString(),
                        SysFunctionID = Convert.ToInt64(dt.Rows[i]["SysFunctionId"].ToString()),
                        ParentID = Convert.ToInt64(dt.Rows[i]["ParentID"].ToString())
                    };
                    lst.Add(model);
                }
                lst.Reverse();
            }
            return lst;
        }

        /// <summary>
        /// 删除指定SysFunctionId下面的子节点
        /// </summary>
        public bool DelChild(XCLCMS.Data.Model.SysFunction model)
        {
            return dal.DelChild(model);
        }

        /// <summary>
        /// 根据SysFunctionID查询其子项
        /// </summary>
        public List<XCLCMS.Data.Model.SysFunction> GetChildListByID(long sysFunctionID)
        {
            List<XCLCMS.Data.Model.SysFunction> lst = null;
            DataTable dt = dal.GetChildListByID(sysFunctionID);
            if (null != dt && dt.Rows.Count > 0)
            {
                lst = this.DataTableToList(dt);
            }
            return lst;
        }

        #endregion ExtensionMethod
    }
}