using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XCLNetTools.Generic;

namespace XCLCMS.View.AdminWeb.Controllers.SysFunction
{
    /// <summary>
    /// 功能公共controller
    /// </summary>
    public class SysFunctionCommonController : BaseController
    {
        /// <summary>
        /// 判断功能标识是否已经存在
        /// </summary>
        public JsonResult IsExistCode()
        {
            string code = XCLNetTools.StringHander.FormHelper.GetString("Code").Trim();
            long sysFunctionID = XCLNetTools.StringHander.FormHelper.GetLong("SysFunctionID");

            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel()
            {
                IsSuccess = true,
                Message = "该标识可以使用！"
            };
            XCLCMS.Data.BLL.SysFunction bll = new Data.BLL.SysFunction();
            XCLCMS.Data.Model.SysFunction model = null;
            if (sysFunctionID > 0)
            {
                model = bll.GetModel(sysFunctionID);
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
                bool isExist = new XCLCMS.Data.BLL.SysFunction().IsExistCode(code);
                if (isExist)
                {
                    msgModel.IsSuccess = false;
                    msgModel.Message = "该标识名已存在！";
                }
            }
            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 判断功能名，在同一级别中是否存在
        /// </summary>
        public JsonResult IsExistFunctionNameInSameLevel()
        {
            string functionName = XCLNetTools.StringHander.FormHelper.GetString("functionName").Trim();
            long parentID = XCLNetTools.StringHander.FormHelper.GetLong("parentID");
            long sysFunctionID = XCLNetTools.StringHander.FormHelper.GetLong("SysFunctionID");

            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel()
            {
                IsSuccess = true,
                Message = "该功能名可以使用！"
            };
            XCLCMS.Data.BLL.SysFunction bll = new Data.BLL.SysFunction();
            XCLCMS.Data.Model.SysFunction model = null;

            if (sysFunctionID > 0)
            {
                model = bll.GetModel(sysFunctionID);
                if (null != model)
                {
                    if (string.Equals(functionName, model.FunctionName, StringComparison.OrdinalIgnoreCase))
                    {
                        return Json(msgModel, JsonRequestBehavior.AllowGet);
                    }
                }
            }

            List<XCLCMS.Data.Model.SysFunction> lst = bll.GetChildListByID(parentID);
            if (lst.IsNotNullOrEmpty())
            {
                if (lst.Exists(k => string.Equals(k.FunctionName, functionName, StringComparison.OrdinalIgnoreCase)))
                {
                    msgModel.IsSuccess = false;
                    msgModel.Message = "该功能名在当前层级中已存在！";
                }
            }

            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取easyui tree格式的所有功能json
        /// </summary>
        public string GetAllJsonForEasyUITree()
        {
            List<XCLNetTools.EasyUI.Model.TreeItem> tree = new List<XCLNetTools.EasyUI.Model.TreeItem>();
            XCLCMS.Data.BLL.View.v_SysFunction bll = new Data.BLL.View.v_SysFunction();
            var allData = bll.GetModelList("");
            if (allData.IsNotNullOrEmpty())
            {
                var root = allData.Where(k => k.ParentID == 0).FirstOrDefault();//根节点
                if (null != root)
                {
                    tree.Add(new XCLNetTools.EasyUI.Model.TreeItem() { 
                        ID=root.SysFunctionID.ToString(),
                        State=root.IsLeaf==1?"open":"closed",
                        Text=root.FunctionName
                    });

                    Action<XCLNetTools.EasyUI.Model.TreeItem> getChildAction = null;
                    getChildAction = new Action<XCLNetTools.EasyUI.Model.TreeItem>((parentModel) =>
                    {
                        var childs = allData.Where(k => k.ParentID ==Convert.ToInt64(parentModel.ID)).ToList();
                        if (childs.IsNotNullOrEmpty())
                        {
                            parentModel.Children = new List<XCLNetTools.EasyUI.Model.TreeItem>();
                            childs.ForEach(m => {
                                var treeItem = new XCLNetTools.EasyUI.Model.TreeItem() {
                                    ID = m.SysFunctionID.ToString(),
                                    State =m.IsLeaf==1?"open":"closed",
                                    Text = m.FunctionName
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
            return XCLNetTools.Serialize.JSON.Serialize(tree,XCLNetTools.Serialize.JSON.JsonProviderEnum.Newtonsoft);
        }
    }
}
