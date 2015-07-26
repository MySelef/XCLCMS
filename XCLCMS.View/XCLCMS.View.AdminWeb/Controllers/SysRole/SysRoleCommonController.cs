using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XCLNetTools.Generic;

namespace XCLCMS.View.AdminWeb.Controllers.SysRole
{
    /// <summary>
    /// 角色公共controller
    /// </summary>
    public class SysRoleCommonController : BaseController
    {
        /// <summary>
        /// 判断角色标识是否已经存在
        /// </summary>
        public JsonResult IsExistCode()
        {
            string code = XCLNetTools.StringHander.FormHelper.GetString("Code").Trim();
            long sysRoleID = XCLNetTools.StringHander.FormHelper.GetLong("SysRoleID");

            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel()
            {
                IsSuccess = true,
                Message = "该标识可以使用！"
            };
            XCLCMS.Data.BLL.SysRole bll = new Data.BLL.SysRole();
            XCLCMS.Data.Model.SysRole model = null;
            if (sysRoleID > 0)
            {
                model = bll.GetModel(sysRoleID);
                if (null != model)
                {
                    if (string.Equals(code, model.Code, StringComparison.OrdinalIgnoreCase))
                    {
                        return Json(msgModel, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            if (!string.IsNullOrEmpty(code))
            {
                bool isExist = new XCLCMS.Data.BLL.SysRole().IsExistCode(code);
                if (isExist)
                {
                    msgModel.IsSuccess = false;
                    msgModel.Message = "该标识名已存在！";
                }
            }
            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 判断角色名，在同一级别中是否存在
        /// </summary>
        public JsonResult IsExistRoleNameInSameLevel()
        {
            string roleName = XCLNetTools.StringHander.FormHelper.GetString("roleName").Trim();
            long parentID = XCLNetTools.StringHander.FormHelper.GetLong("parentID");
            long sysRoleID = XCLNetTools.StringHander.FormHelper.GetLong("SysRoleID");

            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel()
            {
                IsSuccess = true,
                Message = "该角色名可以使用！"
            };
            XCLCMS.Data.BLL.SysRole bll = new Data.BLL.SysRole();
            XCLCMS.Data.Model.SysRole model = null;

            if (sysRoleID > 0)
            {
                model = bll.GetModel(sysRoleID);
                if (null != model)
                {
                    if (string.Equals(roleName, model.RoleName, StringComparison.OrdinalIgnoreCase))
                    {
                        return Json(msgModel, JsonRequestBehavior.AllowGet);
                    }
                }
            }

            List<XCLCMS.Data.Model.SysRole> lst = bll.GetChildListByID(parentID);
            if (lst.IsNotNullOrEmpty())
            {
                if (lst.Exists(k => string.Equals(k.RoleName, roleName, StringComparison.OrdinalIgnoreCase)))
                {
                    msgModel.IsSuccess = false;
                    msgModel.Message = "该角色名在当前层级中已存在！";
                }
            }

            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取easyui tree格式的所有角色json
        /// </summary>
        public string GetAllJsonForEasyUITree()
        {
            List<XCLNetTools.EasyUI.Model.TreeItem> tree = new List<XCLNetTools.EasyUI.Model.TreeItem>();
            XCLCMS.Data.BLL.View.v_SysRole bll = new Data.BLL.View.v_SysRole();
            var allData = bll.GetModelList("");
            if (allData.IsNotNullOrEmpty())
            {
                var root = allData.Where(k => k.ParentID == 0).FirstOrDefault();//根节点
                if (null != root)
                {
                    tree.Add(new XCLNetTools.EasyUI.Model.TreeItem()
                    {
                        ID = root.SysRoleID.ToString(),
                        State = root.IsLeaf == 1 ? "open" : "closed",
                        Text = root.RoleName
                    });

                    Action<XCLNetTools.EasyUI.Model.TreeItem> getChildAction = null;
                    getChildAction = new Action<XCLNetTools.EasyUI.Model.TreeItem>((parentModel) =>
                    {
                        var childs = allData.Where(k => k.ParentID == Convert.ToInt64(parentModel.ID)).ToList();
                        if (childs.IsNotNullOrEmpty())
                        {
                            childs = childs.OrderBy(k => k.Weight).ToList();
                            parentModel.Children = new List<XCLNetTools.EasyUI.Model.TreeItem>();
                            childs.ForEach(m =>
                            {
                                var treeItem = new XCLNetTools.EasyUI.Model.TreeItem()
                                {
                                    ID = m.SysRoleID.ToString(),
                                    State = m.IsLeaf == 1 ? "open" : "closed",
                                    Text = m.RoleName
                                };
                                getChildAction(treeItem);
                                parentModel.Children.Add(treeItem);
                            });
                        }
                    });

                    //从根节点开始
                    getChildAction(tree[0]);

                }
            }
            return XCLNetTools.Serialize.JSON.Serialize(tree, XCLNetTools.Serialize.JSON.JsonProviderEnum.Newtonsoft);
        }
    }
}
