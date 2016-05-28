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
    }
}