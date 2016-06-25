using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using XCLCMS.Data.WebAPIEntity;
using XCLCMS.Data.WebAPIEntity.RequestEntity;
using XCLNetTools.Generic;

namespace XCLCMS.WebAPI.Controllers
{
    /// <summary>
    /// 商户应用管理
    /// </summary>
    public class MerchantAppController : BaseAPIController
    {
        private XCLCMS.Data.BLL.View.v_MerchantApp vMerchantAppBLL = new Data.BLL.View.v_MerchantApp();
        private XCLCMS.Data.BLL.MerchantApp merchantAppBLL = new Data.BLL.MerchantApp();
        private XCLCMS.Data.BLL.Merchant merchantBLL = new Data.BLL.Merchant();

        /// <summary>
        /// 查询商户应用信息实体
        /// </summary>
        [HttpGet]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantAppView)]
        public APIResponseEntity<XCLCMS.Data.Model.MerchantApp> Detail([FromUri] string json)
        {
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<APIRequestEntity<long>>(System.Web.HttpUtility.UrlDecode(json));
            var response = new APIResponseEntity<XCLCMS.Data.Model.MerchantApp>();
            response.Body = merchantAppBLL.GetModel(request.Body);
            response.IsSuccess = true;

            //限制商户
            if (base.IsOnlyCurrentMerchant && null != response.Body && response.Body.FK_MerchantID != base.CurrentUserModel.FK_MerchantID)
            {
                response.Body = null;
                response.IsSuccess = false;
            }

            return response;
        }

        /// <summary>
        /// 查询商户应用信息分页列表
        /// </summary>
        [HttpGet]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantAppView)]
        public APIResponseEntity<XCLCMS.Data.WebAPIEntity.ResponseEntity.PageListResponseEntity<XCLCMS.Data.Model.View.v_MerchantApp>> PageList([FromUri] string json)
        {
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<APIRequestEntity<PageListConditionEntity>>(System.Web.HttpUtility.UrlDecode(json));
            var pager = request.Body.PagerInfoSimple.ToPagerInfo();
            var response = new APIResponseEntity<XCLCMS.Data.WebAPIEntity.ResponseEntity.PageListResponseEntity<XCLCMS.Data.Model.View.v_MerchantApp>>();
            response.Body = new Data.WebAPIEntity.ResponseEntity.PageListResponseEntity<Data.Model.View.v_MerchantApp>();

            //限制商户
            if (base.IsOnlyCurrentMerchant)
            {
                request.Body.Where = XCLNetTools.DataBase.SQLLibrary.JoinWithAnd(new List<string>() {
                    request.Body.Where,
                    string.Format("FK_MerchantID={0}",base.CurrentUserModel.FK_MerchantID)
                });
            }

            response.Body.ResultList = vMerchantAppBLL.GetPageList(pager, request.Body.Where, "", "[MerchantAppID]", "[MerchantAppID] desc");
            response.Body.PagerInfo = pager;
            response.IsSuccess = true;
            return response;
        }

        /// <summary>
        /// 判断商户应用名是否存在
        /// </summary>
        [HttpGet]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantAppView)]
        public APIResponseEntity<bool> IsExistMerchantAppName([FromUri] string json)
        {
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.MerchantApp.IsExistMerchantAppNameEntity>>(System.Web.HttpUtility.UrlDecode(json));
            var response = new APIResponseEntity<bool>();
            response.IsSuccess = true;
            response.Message = "该商户应用名可以使用！";

            request.Body.MerchantAppName = (request.Body.MerchantAppName ?? "").Trim();

            if (request.Body.MerchantAppID > 0)
            {
                var model = merchantAppBLL.GetModel(request.Body.MerchantAppID);
                if (null != model)
                {
                    if (string.Equals(request.Body.MerchantAppName, model.MerchantAppName, StringComparison.OrdinalIgnoreCase))
                    {
                        return response;
                    }
                }
            }

            if (!string.IsNullOrEmpty(request.Body.MerchantAppName))
            {
                bool isExist = merchantAppBLL.IsExistMerchantAppName(request.Body.MerchantAppName);
                if (isExist)
                {
                    response.IsSuccess = false;
                    response.Message = "该商户应用名已被占用！";
                }
            }

            return response;
        }

        /// <summary>
        /// 新增商户应用信息
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantAppAdd)]
        public APIResponseEntity<bool> Add(JObject obj)
        {
            var request = obj.ToObject<APIRequestEntity<XCLCMS.Data.Model.MerchantApp>>();
            var response = new APIResponseEntity<bool>();

            #region 数据校验

            request.Body.MerchantAppName = (request.Body.MerchantAppName ?? "").Trim();

            if (string.IsNullOrWhiteSpace(request.Body.MerchantAppName))
            {
                response.IsSuccess = false;
                response.Message = "请提供商户应用名！";
                return response;
            }

            if (null == merchantBLL.GetModel(request.Body.FK_MerchantID))
            {
                response.IsSuccess = false;
                response.Message = string.Format("您指定的商户ID【{0}】不存在！", request.Body.FK_MerchantID);
                return response;
            }

            if (this.merchantAppBLL.IsExistMerchantAppName(request.Body.MerchantAppName))
            {
                response.IsSuccess = false;
                response.Message = string.Format("商户应用名【{0}】已存在！", request.Body.MerchantAppName);
                return response;
            }

            //限制商户
            if (base.IsOnlyCurrentMerchant && request.Body.FK_MerchantID != base.CurrentUserModel.FK_MerchantID)
            {
                response.IsSuccess = false;
                response.Message = "只能在自己所属的商户下面添加应用信息！";
                return response;
            }

            #endregion 数据校验

            response.IsSuccess = this.merchantAppBLL.Add(request.Body);
            if (response.Body)
            {
                response.Message = "商户应用信息添加成功！";
            }
            else
            {
                response.Message = "商户应用信息添加失败！";
            }
            return response;
        }

        /// <summary>
        /// 修改商户应用信息
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantAppEdit)]
        public APIResponseEntity<bool> Update(JObject obj)
        {
            var request = obj.ToObject<APIRequestEntity<XCLCMS.Data.Model.MerchantApp>>();
            var response = new APIResponseEntity<bool>();

            #region 数据校验

            var model = merchantAppBLL.GetModel(request.Body.MerchantAppID);
            if (null == model)
            {
                response.IsSuccess = false;
                response.Message = "请指定有效的商户应用信息！";
                return response;
            }

            if (!string.Equals(model.MerchantAppName, request.Body.MerchantAppName))
            {
                if (this.merchantAppBLL.IsExistMerchantAppName(request.Body.MerchantAppName))
                {
                    response.IsSuccess = false;
                    response.Message = string.Format("商户应用名【{0}】已存在！", request.Body.MerchantAppName);
                    return response;
                }
            }

            //限制商户
            if (base.IsOnlyCurrentMerchant && request.Body.FK_MerchantID != base.CurrentUserModel.FK_MerchantID)
            {
                response.IsSuccess = false;
                response.Message = "只能在自己所属的商户下面修改应用信息！";
                return response;
            }

            #endregion 数据校验

            model.CopyRight = request.Body.CopyRight;
            model.MerchantAppName = request.Body.MerchantAppName;
            model.MetaDescription = request.Body.MetaDescription;
            model.MetaKeyWords = request.Body.MetaKeyWords;
            model.MetaTitle = request.Body.MetaTitle;
            model.ResourceVersion = request.Body.ResourceVersion;
            model.WebURL = request.Body.WebURL;
            model.Email = request.Body.Email;
            model.Remark = request.Body.Remark;
            model.UpdaterID = base.CurrentUserModel.UserInfoID;
            model.UpdaterName = base.CurrentUserModel.UserName;
            model.UpdateTime = DateTime.Now;

            response.IsSuccess = this.merchantAppBLL.Update(model);
            if (response.IsSuccess)
            {
                response.Message = "商户应用信息修改成功！";
            }
            else
            {
                response.Message = "商户应用信息修改失败！";
            }
            return response;
        }

        /// <summary>
        /// 删除商户应用信息
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantAppDel)]
        public APIResponseEntity<bool> Delete(JObject obj)
        {
            var request = obj.ToObject<APIRequestEntity<List<long>>>();
            var response = new APIResponseEntity<bool>();

            if (request.Body.IsNotNullOrEmpty())
            {
                request.Body = request.Body.Where(k => k > 0).Distinct().ToList();
            }

            if (request.Body.IsNullOrEmpty())
            {
                response.IsSuccess = false;
                response.Message = "请指定要删除的商户应用ID！";
                return response;
            }

            foreach (var k in request.Body)
            {
                var merchantAppModel = merchantAppBLL.GetModel(k);
                if (null == merchantAppModel)
                {
                    continue;
                }
                //限制商户
                if (base.IsOnlyCurrentMerchant && merchantAppModel.FK_MerchantID != base.CurrentUserModel.FK_MerchantID)
                {
                    continue;
                }
                var merchantModel = this.merchantBLL.GetModel(merchantAppModel.FK_MerchantID);
                if (null != merchantModel && merchantModel.MerchantSystemType == XCLCMS.Data.CommonHelper.EnumType.MerchantSystemTypeEnum.SYS.ToString())
                {
                    response.IsSuccess = false;
                    response.Message = string.Format("不可以删除系统内置商户的应用【{0}】！", merchantAppModel.MerchantAppName);
                    return response;
                }
                merchantAppModel.UpdaterID = base.CurrentUserModel.UserInfoID;
                merchantAppModel.UpdaterName = base.CurrentUserModel.UserName;
                merchantAppModel.UpdateTime = DateTime.Now;
                merchantAppModel.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.R.ToString();
                if (!merchantAppBLL.Update(merchantAppModel))
                {
                    response.IsSuccess = false;
                    response.Message = "删除失败！";
                    return response;
                }
            }

            response.IsSuccess = true;
            response.Message = "已成功删除商户应用信息！";
            response.IsRefresh = true;

            return response;
        }
    }
}