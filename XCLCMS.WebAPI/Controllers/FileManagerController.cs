using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using XCLCMS.Data.WebAPIEntity;

namespace XCLCMS.WebAPI.Controllers
{
    /// <summary>
    /// 文件管理 API
    /// </summary>
    public class FileManagerController : BaseAPIController
    {
        #region 磁盘文件管理

        /// <summary>
        /// 返回磁盘文件列表
        /// </summary>
        [HttpGet]
        public async Task<APIResponseEntity<List<XCLNetTools.Entity.FileInfoEntity>>> GetDiskFileList([FromUri] APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.FileManager.GetDiskFileListEntity> request)
        {
            return await Task.Run(() =>
            {
                if (string.IsNullOrWhiteSpace(request.Body.DirectoryPath))
                {
                    request.Body.DirectoryPath = XCLCMS.Lib.SysWebSetting.Setting.SettingModel.FileManager_UploadPath;
                }
                request.Body.DirectoryPath = request.Body.DirectoryPath.Trim();

                var response = new APIResponseEntity<List<XCLNetTools.Entity.FileInfoEntity>>();
                response.Body = XCLNetTools.FileHandler.FileDirectory.GetFileList(request.Body.DirectoryPath, XCLCMS.Lib.SysWebSetting.Setting.SettingModel.FileManager_UploadPath, XCLCMS.Lib.SysWebSetting.Setting.SettingModel.FileManager_UploadPath.Replace("~/", XCLNetTools.StringHander.Common.RootUri));
                response.IsSuccess = true;
                return response;
            });
        }

        #endregion 磁盘文件管理
    }
}