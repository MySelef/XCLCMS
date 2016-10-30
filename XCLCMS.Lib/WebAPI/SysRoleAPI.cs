using System.Collections.Generic;
using XCLCMS.Data.WebAPIEntity;

namespace XCLCMS.Lib.WebAPI
{
    /// <summary>
    /// 角色管理 API
    /// </summary>
    public static class SysRoleAPI
    {
        /// <summary>
        /// 查询角色信息实体
        /// </summary>
        public static APIResponseEntity<XCLCMS.Data.Model.SysRole> Detail(APIRequestEntity<long> request)
        {
            return Library.Request<long, XCLCMS.Data.Model.SysRole>(request, "SysRole/Detail");
        }

        /// <summary>
        /// 判断角色标识是否已经存在
        /// </summary>
        public static APIResponseEntity<bool> IsExistCode(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.SysRole.IsExistCodeEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.SysRole.IsExistCodeEntity, bool>(request, "SysRole/IsExistCode");
        }

        /// <summary>
        /// 判断角色名，在同一级别中是否存在
        /// </summary>
        public static APIResponseEntity<bool> IsExistRoleNameInSameLevel(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.SysRole.IsExistRoleNameInSameLevelEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.SysRole.IsExistRoleNameInSameLevelEntity, bool>(request, "SysRole/IsExistRoleNameInSameLevel");
        }

        /// <summary>
        /// 查询所有角色列表
        /// </summary>
        public static APIResponseEntity<List<XCLCMS.Data.Model.View.v_SysRole>> GetList(APIRequestEntity<long> request)
        {
            return Library.Request<long, List<XCLCMS.Data.Model.View.v_SysRole>>(request, "SysRole/GetList");
        }

        /// <summary>
        /// 获取easyui tree格式的所有角色json
        /// </summary>
        public static APIResponseEntity<List<XCLNetTools.Entity.EasyUI.TreeItem>> GetAllJsonForEasyUITree(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.SysRole.GetAllJsonForEasyUITreeEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.SysRole.GetAllJsonForEasyUITreeEntity, List<XCLNetTools.Entity.EasyUI.TreeItem>>(request, "SysRole/GetAllJsonForEasyUITree");
        }

        /// <summary>
        /// 获取当前SysRoleID所属的层级list
        /// 如:根目录/子目录/文件
        /// </summary>
        public static APIResponseEntity<List<XCLCMS.Data.Model.Custom.SysRoleSimple>> GetLayerListBySysRoleID(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.SysRole.GetLayerListBySysRoleIDEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.SysRole.GetLayerListBySysRoleIDEntity, List<XCLCMS.Data.Model.Custom.SysRoleSimple>>(request, "SysRole/GetLayerListBySysRoleID");
        }

        /// <summary>
        /// 获取指定用户的角色
        /// </summary>
        public static APIResponseEntity<List<XCLCMS.Data.Model.SysRole>> GetRoleByUserID(APIRequestEntity<long> request)
        {
            return Library.Request<long, List<XCLCMS.Data.Model.SysRole>>(request, "SysRole/GetRoleByUserID");
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        public static APIResponseEntity<bool> Add(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.SysRole.AddOrUpdateEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.SysRole.AddOrUpdateEntity, bool>(request, "SysRole/Add", false);
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        public static APIResponseEntity<bool> Update(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.SysRole.AddOrUpdateEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.SysRole.AddOrUpdateEntity, bool>(request, "SysRole/Update", false);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        public static APIResponseEntity<bool> Delete(APIRequestEntity<List<long>> request)
        {
            return Library.Request<List<long>, bool>(request, "SysRole/Delete", false);
        }
    }
}