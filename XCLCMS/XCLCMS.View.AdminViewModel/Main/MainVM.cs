using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.View.AdminViewModel.Main
{
    /// <summary>
    /// 主模板视图model
    /// </summary>
    public class MainVM
    {
        /// <summary>
        /// 主菜单
        /// </summary>
        public List<XCLCMS.Data.Model.SysDic> MenuList { get; set; }

        /// <summary>
        /// 当前菜单model
        /// </summary>
        public XCLCMS.Data.Model.SysDic CurrentMenuModel { get; set; }

        /// <summary>
        /// 当前父菜单 ID
        /// </summary>
        public long CurrentParentMenuID
        {
            get
            {
                return null != this.CurrentMenuModel ? this.CurrentMenuModel.ParentID : -1;
            }
        }

        /// <summary>
        /// 当前菜单ID
        /// </summary>
        public long CurrentMenuID
        {
            get
            {
                return null != this.CurrentMenuModel ? this.CurrentMenuModel.SysDicID : -1;
            }
        }

        private string _pagePath = string.Empty;
        /// <summary>
        /// 当前页面路径导航文字
        /// </summary>
        public string PagePath
        {
            get
            {
                if (string.IsNullOrEmpty(this._pagePath))
                {
                    XCLCMS.Data.BLL.SysDic bll = new Data.BLL.SysDic();
                    XCLCMS.Data.Model.SysDic model = null;
                    List<string> strLst = new List<string>();
                    //第一级
                    model = bll.GetModel(this.CurrentParentMenuID);
                    if (null != model)
                    {
                        strLst.Add(model.DicName);
                        //第二级
                        model = bll.GetModel(this.CurrentMenuID);
                        if (null != model)
                        {
                            strLst.Add(model.DicName);
                        }
                    }
                    this._pagePath=string.Join("->", strLst.ToArray());            
                }
                return this._pagePath;
            }
        }
    }
}
