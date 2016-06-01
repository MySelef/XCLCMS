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
        /// 判断字典的唯一标识是否已经存在
        /// </summary>
        public static APIResponseEntity<bool> IsExistSysDicCode(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.SysDic.IsExistSysDicCodeEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.SysDic.IsExistSysDicCodeEntity, bool>(request, "SysDic/IsExistSysDicCode");
        }

        /// <summary>
        /// 判断字典名，在同一级别中是否存在
        /// </summary>
        public static APIResponseEntity<bool> IsExistSysDicNameInSameLevel(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.SysDic.IsExistSysDicNameInSameLevelEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.SysDic.IsExistSysDicNameInSameLevelEntity, bool>(request, "SysDic/IsExistSysDicNameInSameLevel");
        }

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