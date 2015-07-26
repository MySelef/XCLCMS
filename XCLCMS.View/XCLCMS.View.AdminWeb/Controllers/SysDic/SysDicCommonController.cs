using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XCLNetTools.Generic;

namespace XCLCMS.View.AdminWeb.Controllers.SysDic
{
    /// <summary>
    /// 字典库公共controller
    /// </summary>
    public class SysDicCommonController : BaseController
    {
        /// <summary>
        /// 判断字典的唯一标识是否已经存在
        /// </summary>
        public ActionResult IsExistSysDicCode()
        {
            string code = XCLNetTools.StringHander.FormHelper.GetString("code").Trim();
            long sysDicID = XCLNetTools.StringHander.FormHelper.GetLong("SysDicID");

            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel()
            {
                IsSuccess = true,
                Message = "该唯一标识可以使用！"
            };
            XCLCMS.Data.BLL.SysDic bll = new Data.BLL.SysDic();
            XCLCMS.Data.Model.SysDic model = null;
            if (sysDicID > 0)
            {
                model= bll.GetModel(sysDicID);
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
                bool isExist = new XCLCMS.Data.BLL.SysDic().IsExistCode(code);
                if (isExist)
                {
                    msgModel.IsSuccess = false;
                    msgModel.Message = "该唯一标识已存在！";
                }
            }
            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 判断字典名，在同一级别中是否存在
        /// </summary>
        public ActionResult IsExistSysDicNameInSameLevel()
        {
            string sysDicName = XCLNetTools.StringHander.FormHelper.GetString("sysDicName").Trim();
            long parentID = XCLNetTools.StringHander.FormHelper.GetLong("parentID");
            long sysDicID = XCLNetTools.StringHander.FormHelper.GetLong("SysDicID");

            XCLNetTools.Message.MessageModel msgModel = new XCLNetTools.Message.MessageModel()
            {
                IsSuccess = true,
                Message = "该字典名可以使用！"
            };
            XCLCMS.Data.BLL.SysDic bll = new Data.BLL.SysDic();
            XCLCMS.Data.Model.SysDic model = null;

            if (sysDicID > 0)
            {
                model = bll.GetModel(sysDicID);
                if (null != model)
                {
                    if (string.Equals(sysDicName, model.DicName, StringComparison.OrdinalIgnoreCase))
                    {
                        return Json(msgModel, JsonRequestBehavior.AllowGet);
                    }
                }
            }

            List<XCLCMS.Data.Model.SysDic> lst = bll.GetChildListByID(parentID);
            if (lst.IsNotNullOrEmpty())
            {
                if (lst.Exists(k => string.Equals(k.DicName, sysDicName, StringComparison.OrdinalIgnoreCase)))
                {
                    msgModel.IsSuccess = false;
                    msgModel.Message = "该字典名在当前层级中已存在！";
                }
            }

            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 返回指定code下面的所有节点的easyui tree形式的json
        /// 注：返回的结果中，不包含code所在的节点
        /// </summary>
        public string GetEasyUITreeByCode()
        {
            string code = XCLNetTools.StringHander.FormHelper.GetString("code");
            if (string.IsNullOrEmpty(code))
            {
                return string.Empty;
            }

            List<XCLNetTools.EasyUI.Model.TreeItem> tree = new List<XCLNetTools.EasyUI.Model.TreeItem>();
            XCLCMS.Data.BLL.View.v_SysDic bll = new Data.BLL.View.v_SysDic();
            XCLCMS.Data.BLL.SysDic sysDicBLL = new Data.BLL.SysDic();
            var rootModel = sysDicBLL.GetModelByCode(code);
            if (null == rootModel)
            {
                return string.Empty;
            }

            var allData = bll.GetAllUnderListByCode(code);
            var rootLayer = allData.Where(k => k.ParentID == rootModel.SysDicID).ToList();
            if (rootLayer.IsNotNullOrEmpty())
            {
                for (int idx = 0; idx < rootLayer.Count; idx++)
                {
                    var current = rootLayer[idx];

                    tree.Add(new XCLNetTools.EasyUI.Model.TreeItem()
                    {
                        ID = current.SysDicID.ToString(),
                        Text = current.DicName
                    });

                    Action<XCLNetTools.EasyUI.Model.TreeItem> getChildAction = null;
                    getChildAction = new Action<XCLNetTools.EasyUI.Model.TreeItem>((parentModel) =>
                    {
                        var childs = allData.Where(k => k.ParentID == Convert.ToInt64(parentModel.ID)).ToList();
                        if (childs.IsNotNullOrEmpty())
                        {
                            parentModel.Children = new List<XCLNetTools.EasyUI.Model.TreeItem>();
                            childs.ForEach(m =>
                            {
                                var treeItem = new XCLNetTools.EasyUI.Model.TreeItem()
                                {
                                    ID = m.SysDicID.ToString(),
                                    State = m.IsLeaf == 1 ? "open" : "closed",
                                    Text = m.DicName
                                };
                                getChildAction(treeItem);
                                parentModel.Children.Add(treeItem);
                            });
                        }
                    });

                    getChildAction(tree.Find(k=>k.ID==current.SysDicID.ToString()));

                }
            }
            return XCLNetTools.Serialize.JSON.Serialize(tree, XCLNetTools.Serialize.JSON.JsonProviderEnum.Newtonsoft);
        }
    }
}
