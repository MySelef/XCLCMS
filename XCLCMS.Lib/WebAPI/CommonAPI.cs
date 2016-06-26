using XCLCMS.Data.WebAPIEntity;

namespace XCLCMS.Lib.WebAPI
{
    /// <summary>
    /// 公共API
    /// </summary>
    public static class CommonAPI
    {
        /// <summary>
        /// 生成ID号
        /// </summary>
        public static APIResponseEntity<long> GenerateID(APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.Common.GenerateIDEntity> request)
        {
            return Library.Request<XCLCMS.Data.WebAPIEntity.RequestEntity.Common.GenerateIDEntity, long>(request, "Common/GenerateID");
        }

        /// <summary>
        /// 垃圾数据清理
        /// </summary>
        public static APIResponseEntity<bool> ClearRubbishData(APIRequestEntity<object> request)
        {
            return Library.Request<object, bool>(request, "Common/ClearRubbishData");
        }
    }
}