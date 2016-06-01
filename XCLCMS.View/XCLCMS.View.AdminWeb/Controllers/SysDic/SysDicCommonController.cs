using System;
using System.Collections.Generic;
using System.Linq;
using XCLNetTools.Generic;

namespace XCLCMS.View.AdminWeb.Controllers.SysDic
{
    /// <summary>
    /// 字典库公共controller
    /// </summary>
    public class SysDicCommonController : BaseController
    {
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

            List<XCLNetTools.Entity.EasyUI.TreeItem> tree = new List<XCLNetTools.Entity.EasyUI.TreeItem>();
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

                    tree.Add(new XCLNetTools.Entity.EasyUI.TreeItem()
                    {
                        ID = current.SysDicID.ToString(),
                        Text = current.DicName
                    });

                    Action<XCLNetTools.Entity.EasyUI.TreeItem> getChildAction = null;
                    getChildAction = new Action<XCLNetTools.Entity.EasyUI.TreeItem>((parentModel) =>
                    {
                        var childs = allData.Where(k => k.ParentID == Convert.ToInt64(parentModel.ID)).ToList();
                        if (childs.IsNotNullOrEmpty())
                        {
                            parentModel.Children = new List<XCLNetTools.Entity.EasyUI.TreeItem>();
                            childs.ForEach(m =>
                            {
                                var treeItem = new XCLNetTools.Entity.EasyUI.TreeItem()
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

                    getChildAction(tree.Find(k => k.ID == current.SysDicID.ToString()));
                }
            }
            return XCLNetTools.Serialize.JSON.Serialize(tree, XCLNetTools.Serialize.JSON.JsonProviderEnum.Newtonsoft);
        }
    }
}