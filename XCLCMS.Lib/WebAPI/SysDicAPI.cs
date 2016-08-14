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
        /// 查询字典信息实体
        /// </summary>
        public static APIResponseEntity<XCLCMS.Data.Model.SysDic> Detail(APIRequestEntity<long> request)
        {
            return Library.Request<long, XCLCMS.Data.Model.SysDic>(request, "SysDic/Detail");
        }

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
        /// 根据code来获取字典的easyui tree格式
        /// </summary>
        public static APIResponseEntity<List<XCLNetTools.Entity.EasyUI.TreeItem>> GetEasyUITreeByCode(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.SysDic.GetEasyUITreeByCodeEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.SysDic.GetEasyUITreeByCodeEntity, List<XCLNetTools.Entity.EasyUI.TreeItem>>(request, "SysDic/GetEasyUITreeByCode");
        }

        /// <summary>
        /// 查询所有字典列表
        /// </summary>
        public static APIResponseEntity<List<XCLCMS.Data.Model.View.v_SysDic>> GetList(APIRequestEntity<long> request)
        {
            return Library.Request<long, List<XCLCMS.Data.Model.View.v_SysDic>>(request, "SysDic/GetList");
        }

        /// <summary>
        /// 根据条件获取字典的easy tree 列表
        /// </summary>
        public static APIResponseEntity<List<XCLNetTools.Entity.EasyUI.TreeItem>> GetEasyUITreeByCondition(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.SysDic.GetEasyUITreeByConditionEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.SysDic.GetEasyUITreeByConditionEntity, List<XCLNetTools.Entity.EasyUI.TreeItem>>(request, "SysDic/GetEasyUITreeByCondition");
        }

        /// <summary>
        /// 获取XCLCMS管理后台系统的菜单
        /// </summary>
        public static APIResponseEntity<List<XCLCMS.Data.Model.View.v_SysDic>> GetSystemMenuModelList(APIRequestEntity<object> request)
        {
            return Library.Request<object, List<XCLCMS.Data.Model.View.v_SysDic>>(request, "SysDic/GetSystemMenuModelList");
        }

        /// <summary>
        /// 根据SysDicID查询其子项
        /// </summary>
        public static APIResponseEntity<List<XCLCMS.Data.Model.SysDic>> GetChildListByID(APIRequestEntity<long> request)
        {
            return Library.Request<long, List<XCLCMS.Data.Model.SysDic>>(request, "SysDic/GetChildListByID");
        }

        /// <summary>
        /// 获取当前sysDicID所属的层级list
        /// 如:根目录/子目录/文件
        /// </summary>
        public static APIResponseEntity<List<XCLCMS.Data.Model.Custom.SysDicSimple>> GetLayerListBySysDicID(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.SysDic.GetLayerListBySysDicIDEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.SysDic.GetLayerListBySysDicIDEntity, List<XCLCMS.Data.Model.Custom.SysDicSimple>>(request, "SysDic/GetLayerListBySysDicID");
        }

        /// <summary>
        /// 获取证件类型
        /// </summary>
        public static APIResponseEntity<Dictionary<string, long>> GetPassTypeDic(APIRequestEntity<object> request)
        {
            return Library.Request<object, Dictionary<string, long>>(request, "SysDic/GetPassTypeDic");
        }

        /// <summary>
        /// 递归获取指定SysDicID下的所有列表（不包含该SysDicID的记录）
        /// </summary>
        public static APIResponseEntity<List<XCLCMS.Data.Model.View.v_SysDic>> GetAllUnderListByID(APIRequestEntity<long> request)
        {
            return Library.Request<long, List<XCLCMS.Data.Model.View.v_SysDic>>(request, "SysDic/GetAllUnderListByID");
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
    }
}