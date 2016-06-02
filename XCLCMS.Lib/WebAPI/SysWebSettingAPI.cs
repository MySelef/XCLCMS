using System.Collections.Generic;
using XCLCMS.Data.WebAPIEntity;
using XCLCMS.Data.WebAPIEntity.RequestEntity;

namespace XCLCMS.Lib.WebAPI
{
    /// <summary>
    /// 系统配置 API
    /// </summary>
    public static class SysWebSettingAPI
    {
        /// <summary>
        /// 查询系统配置信息实体
        /// </summary>
        public static APIResponseEntity<XCLCMS.Data.Model.SysWebSetting> Detail(APIRequestEntity<long> request)
        {
            return Library.Request<long, XCLCMS.Data.Model.SysWebSetting>(request, "SysWebSetting/Detail");
        }

        /// <summary>
        /// 查询系统配置分页列表
        /// </summary>
        public static APIResponseEntity<XCLCMS.Data.WebAPIEntity.ResponseEntity.PageListResponseEntity<XCLCMS.Data.Model.View.v_SysWebSetting>> PageList(APIRequestEntity<PageListConditionEntity> request)
        {
            return Library.Request<PageListConditionEntity, XCLCMS.Data.WebAPIEntity.ResponseEntity.PageListResponseEntity<XCLCMS.Data.Model.View.v_SysWebSetting>>(request, "SysWebSetting/PageList");
        }

        /// <summary>
        /// 判断系统配置名是否存在
        /// </summary>
        public static APIResponseEntity<bool> IsExistKeyName(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.SysWebSetting.IsExistKeyNameEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.SysWebSetting.IsExistKeyNameEntity, bool>(request, "SysWebSetting/IsExistKeyName");
        }

        /// <summary>
        /// 新增系统配置信息
        /// </summary>
        public static APIResponseEntity<bool> Add(APIRequestEntity<XCLCMS.Data.Model.SysWebSetting> request)
        {
            return Library.Request<XCLCMS.Data.Model.SysWebSetting, bool>(request, "SysWebSetting/Add", false);
        }

        /// <summary>
        /// 修改系统配置信息
        /// </summary>
        public static APIResponseEntity<bool> Update(APIRequestEntity<XCLCMS.Data.Model.SysWebSetting> request)
        {
            return Library.Request<XCLCMS.Data.Model.SysWebSetting, bool>(request, "SysWebSetting/Update", false);
        }

        /// <summary>
        /// 删除系统配置信息
        /// </summary>
        public static APIResponseEntity<bool> Delete(APIRequestEntity<List<long>> request)
        {
            return Library.Request<List<long>, bool>(request, "SysWebSetting/Delete", false);
        }
    }
}