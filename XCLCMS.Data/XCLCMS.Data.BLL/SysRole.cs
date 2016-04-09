using System;
using System.Collections.Generic;
using System.Data;

namespace XCLCMS.Data.BLL
{
    /// <summary>
    /// 角色表
    /// </summary>
    public partial class SysRole
    {
        private readonly XCLCMS.Data.DAL.SysRole dal = new XCLCMS.Data.DAL.SysRole();

        public SysRole()
        { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.SysRole model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(XCLCMS.Data.Model.SysRole model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.SysRole GetModel(long SysRoleID)
        {
            return dal.GetModel(SysRoleID);
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
        public List<XCLCMS.Data.Model.SysRole> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return XCLNetTools.Generic.ListHelper.DataTableToList<XCLCMS.Data.Model.SysRole>(ds.Tables[0]) as List<XCLCMS.Data.Model.SysRole>;
        }

        #endregion BasicMethod

        #region ExtensionMethod

        /// <summary>
        /// 获取指定userid的角色
        /// </summary>
        public List<XCLCMS.Data.Model.SysRole> GetListByUserID(long userId)
        {
            DataTable dt = dal.GetListByUserID(userId);
            return XCLNetTools.Generic.ListHelper.DataTableToList<XCLCMS.Data.Model.SysRole>(dt) as List<XCLCMS.Data.Model.SysRole>;
        }

        /// <summary>
        /// 判断功能标识是否存在
        /// </summary>
        public bool IsExistCode(string code)
        {
            return dal.IsExistCode(code);
        }

        /// <summary>
        /// 获取当前SysRoleID所属的层级list
        /// 如:根目录/子目录/文件
        /// </summary>
        public List<XCLCMS.Data.Model.Custom.SysRoleSimple> GetLayerListBySysRoleID(long sysRoleID)
        {
            List<XCLCMS.Data.Model.Custom.SysRoleSimple> lst = null;
            DataTable dt = dal.GetLayerListBySysRoleID(sysRoleID);
            if (null != dt && dt.Rows.Count > 0)
            {
                lst = new List<XCLCMS.Data.Model.Custom.SysRoleSimple>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    XCLCMS.Data.Model.Custom.SysRoleSimple model = new XCLCMS.Data.Model.Custom.SysRoleSimple()
                    {
                        RoleName = dt.Rows[i]["RoleName"].ToString(),
                        SysRoleID = Convert.ToInt64(dt.Rows[i]["SysRoleID"].ToString()),
                        ParentID = Convert.ToInt64(dt.Rows[i]["ParentID"].ToString())
                    };
                    lst.Add(model);
                }
                lst.Reverse();
            }
            return lst;
        }

        /// <summary>
        /// 删除指定SysRoleId下面的子节点
        /// </summary>
        public bool DelChild(XCLCMS.Data.Model.SysRole model)
        {
            return dal.DelChild(model);
        }

        /// <summary>
        /// 根据SysRoleID查询其子项
        /// </summary>
        public List<XCLCMS.Data.Model.SysRole> GetChildListByID(long sysRoleID)
        {
            DataTable dt = dal.GetChildListByID(sysRoleID);
            return XCLNetTools.Generic.ListHelper.DataTableToList<XCLCMS.Data.Model.SysRole>(dt) as List<XCLCMS.Data.Model.SysRole>;
        }

        #endregion ExtensionMethod
    }
}