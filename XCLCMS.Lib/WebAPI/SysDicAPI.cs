using System.Collections.Generic;
using XCLCMS.Data.WebAPIEntity;

namespace XCLCMS.Lib.WebAPI
{
    /// <summary>
    /// 系统字典 API
    /// </summary>
    public static class SysDicAPI
    {
        /// <summary>
        /// 查询所有字典列表
        /// </summary>
        public static APIResponseEntity<List<XCLCMS.Data.Model.View.v_SysDic>> GetList(APIRequestEntity<long> request)
        {
            return Library.Request<long, List<XCLCMS.Data.Model.View.v_SysDic>>(request, "SysDic/GetList");
        }

        /// <summary>
        /// 添加字典
        /// </summary>
        public static APIResponseEntity<bool> Add(APIRequestEntity<XCLCMS.Data.Model.SysDic> request)
        {
            return Library.Request<XCLCMS.Data.Model.SysDic, bool>(request, "SysDic/Add", false);
        }

        /// <summary>
        /// 修改字典
        /// </summary>
        public static APIResponseEntity<bool> Update(APIRequestEntity<XCLCMS.Data.Model.SysDic> request)
        {
            return Library.Request<XCLCMS.Data.Model.SysDic, bool>(request, "SysDic/Update", false);
        }

        /// <summary>
        /// 删除字典
        /// </summary>
        public static APIResponseEntity<bool> Delete(APIRequestEntity<List<long>> request)
        {
            return Library.Request<List<long>, bool>(request, "SysDic/Delete", false);
        }

        /// <summary>
        /// 删除指定字典的所有节点
        /// </summary>
        public static APIResponseEntity<bool> DelChild(APIRequestEntity<long> request)
        {
            return Library.Request<long, bool>(request, "SysDic/DelChild", false);
        }
    }
}