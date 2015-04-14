using System;
using System.Data;
using System.Collections.Generic;
using XCLCMS.Data.Model;
namespace XCLCMS.Data.BLL
{
    /// <summary>
    /// 系统字典表
    /// </summary>
    public partial class SysDic
    {
        private readonly XCLCMS.Data.DAL.SysDic dal = new XCLCMS.Data.DAL.SysDic();
        public SysDic()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLCMS.Data.Model.SysDic GetModel(long SysDicID)
        {

            return dal.GetModel(SysDicID);
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
        public List<XCLCMS.Data.Model.SysDic> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLCMS.Data.Model.SysDic> DataTableToList(DataTable dt)
        {
            List<XCLCMS.Data.Model.SysDic> modelList = new List<XCLCMS.Data.Model.SysDic>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                XCLCMS.Data.Model.SysDic model;
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

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 获取当前sysDicID所属的层级list
        /// 如:根目录/子目录/文件
        /// </summary>
        public List<XCLCMS.Data.Model.Custom.SysDicSimple> GetLayerListBySysDicID(long sysDicID)
        {
            List<XCLCMS.Data.Model.Custom.SysDicSimple> lst = null;
            DataTable dt = dal.GetLayerListBySysDicID(sysDicID);
            if (null != dt && dt.Rows.Count > 0)
            {
                lst = new List<XCLCMS.Data.Model.Custom.SysDicSimple>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    XCLCMS.Data.Model.Custom.SysDicSimple model = new XCLCMS.Data.Model.Custom.SysDicSimple()
                    {
                        DicName = dt.Rows[i]["DicName"].ToString(),
                        SysDicID = Convert.ToInt64(dt.Rows[i]["SysDicID"].ToString()),
                        ParentID = Convert.ToInt64(dt.Rows[i]["ParentID"].ToString())
                    };
                    lst.Add(model);
                }
                lst.Reverse();
            }
            return lst;
        }

         /// <summary>
        /// 判断指定唯一标识是否存在
        /// </summary>
        public bool IsExistCode(string code)
        {
            return dal.IsExistCode(code);
        }

         /// <summary>
        /// 删除指定sysDicID下面的子节点
        /// </summary>
        public bool DelChild(XCLCMS.Data.Model.SysDic model)
        {
            return dal.DelChild(model);
        }

        /// <summary>
        /// 根据code查询其子项
        /// </summary>
        public List<XCLCMS.Data.Model.SysDic> GetChildListByCode(string code)
        {
            List<XCLCMS.Data.Model.SysDic> lst = null;
            DataTable dt = dal.GetChildListByCode(code);
            if (null != dt && dt.Rows.Count > 0)
            {
                lst = this.DataTableToList(dt);
            }
            return lst;
        }

         /// <summary>
        /// 根据SysDicID查询其子项
        /// </summary>
        public List<XCLCMS.Data.Model.SysDic> GetChildListByID(long sysDicID)
        {
            List<XCLCMS.Data.Model.SysDic> lst = null;
            DataTable dt = dal.GetChildListByID(sysDicID);
            if (null != dt && dt.Rows.Count > 0)
            {
                lst = this.DataTableToList(dt);
            }
            return lst;
        }

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public bool Add(XCLCMS.Data.Model.SysDic model)
        {
            return dal.Add(model);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(XCLCMS.Data.Model.SysDic model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 获取后台系统菜单
        /// </summary>
        public List<XCLCMS.Data.Model.SysDic> GetSysMenuList()
        {
            return this.GetChildListByCode(XCLCMS.Data.CommonHelper.SysDicConst.SysDicCodeEnum.SysMenu.ToString());
        }

        /// <summary>
        /// 获取证件类型
        /// </summary>
        public Dictionary<string, string> GetPassTypeDic()
        {
            Dictionary<string, string> passTypeDic = null;
            var passTypeList = this.GetChildListByCode(XCLCMS.Data.CommonHelper.SysDicConst.SysDicCodeEnum.PassType.ToString());
            if (null != passTypeList && passTypeList.Count > 0)
            {
                passTypeDic = new Dictionary<string, string>();
                passTypeList.ForEach(k =>
                {
                    passTypeDic.Add(k.DicName, k.DicValue);
                });
            }
            return passTypeDic;
        }
        #endregion  ExtensionMethod
    }
}

