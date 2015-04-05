using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.View.AdminViewModel.SysDic
{
    /// <summary>
    /// 系统字典库添加页的视图
    /// </summary>
    public class SysDicAddVM
    {
        /// <summary>
        /// 表单action
        /// </summary>
        public string FormAction { get; set; }

        public long SysDicID { get; set; }

        public long ParentID { get; set; }

        /// <summary>
        /// 当前节点路径
        /// </summary>
        public List<XCLCMS.Data.Model.Custom.SysDicSimple> PathList { get; set; }

        /// <summary>
        /// 当前节点的Model
        /// </summary>
        public XCLCMS.Data.Model.SysDic SysDic { get; set; }

        /// <summary>
        /// 记录种类（便于不同类别，展示不同的处理逻辑）
        /// </summary>
        public SysDicCategoryEnum SysDicCategory{get;set;}

        /// <summary>
        /// 当SysDicCategory为角色时，此值为所有功能权限列表
        /// </summary>
        public List<XCLCMS.Data.Model.View.v_SysFunction> FunctionList { get; set; }

        /// <summary>
        /// 功能分类
        /// </summary>
        public List<XCLCMS.Data.Model.SysDic> FunctionTypes
        {
            get
            {
                List<XCLCMS.Data.Model.SysDic> lst = null;
                if (null != this.FunctionList && this.FunctionList.Count > 0)
                {
                    //var selList = (from k in this.FunctionList select new { TypeID = k.FK_TypeID, TypeName = k.C_TypeName }).Distinct().ToList();
                    //if (null != selList && selList.Count > 0)
                    //{
                    //    lst = new List<Data.Model.SysDic>();
                    //    selList.ForEach(k => {
                    //        lst.Add(new Data.Model.SysDic() { 
                    //            SysDicID=k.TypeID,
                    //            DicName=k.TypeName
                    //        });
                    //    });
                    //}
                }
                return lst;
            }
        }

        /// <summary>
        /// 角色的功能ID
        /// </summary>
        public List<long> RoleFunctionIDList { get; set; }
    }

    /// <summary>
    /// 字典记录的种类
    /// </summary>
    public enum SysDicCategoryEnum
    { 
        /// <summary>
        /// 未知
        /// </summary>
        None,
        /// <summary>
        /// 角色相关
        /// </summary>
        Role,
        /// <summary>
        /// 系统菜单
        /// </summary>
        SysMenu
    }
}
