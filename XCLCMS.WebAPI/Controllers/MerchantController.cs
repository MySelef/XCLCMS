using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.Http;
using XCLCMS.Data.WebAPIEntity;
using XCLCMS.Data.WebAPIEntity.RequestEntity.Merchant;
using XCLNetTools.Generic;

namespace XCLCMS.WebAPI.Controllers
{
    /// <summary>
    /// 商户管理
    /// </summary>
    public class MerchantController : BaseAPIController
    {
        private XCLCMS.Data.BLL.View.v_Merchant vMerchantBLL = new Data.BLL.View.v_Merchant();
        private XCLCMS.Data.BLL.Merchant merchantBLL = new Data.BLL.Merchant();
        private XCLCMS.Data.BLL.MerchantApp merchantAppBLL = new XCLCMS.Data.BLL.MerchantApp();

        /// <summary>
        /// 查询商户信息实体
        /// </summary>
        [HttpGet]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantView)]
        public APIResponseEntity<XCLCMS.Data.Model.Merchant> MerchantDetail(string json)
        {
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<APIRequestEntity<long>>(System.Web.HttpUtility.UrlDecode(json));
            var response = new APIResponseEntity<XCLCMS.Data.Model.Merchant>();
            response.Body = merchantBLL.GetModel(request.Body);
            response.IsSuccess = true;
            return response;
        }

        /// <summary>
        /// 查询商户信息分页列表
        /// </summary>
        [HttpGet]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantView)]
        public APIResponseEntity<XCLCMS.Data.WebAPIEntity.ResponseEntity.Merchant.MerchantPageListResponseEntity> MerchantPageList(string json)
        {
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<APIRequestEntity<MerchantPageListConditionEntity>>(System.Web.HttpUtility.UrlDecode(json));
            var response = new APIResponseEntity<XCLCMS.Data.WebAPIEntity.ResponseEntity.Merchant.MerchantPageListResponseEntity>();
            response.Body = new Data.WebAPIEntity.ResponseEntity.Merchant.MerchantPageListResponseEntity();
            response.Body.MerchantList = vMerchantBLL.GetPageList(request.Body.PageInfo, request.Body.Where, "", "[MerchantID]", "[MerchantID] desc");
            response.Body.PagerInfo = request.Body.PageInfo;
            response.IsSuccess = true;
            return response;
        }

        /// <summary>
        /// 新增商户信息
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantAdd)]
        public APIResponseEntity<bool> MerchantAdd(JObject obj)
        {
            var request = obj.ToObject<APIRequestEntity<XCLCMS.Data.Model.Merchant>>();
            var response = new APIResponseEntity<bool>();

            #region 数据校验

            request.Body.MerchantName = (request.Body.MerchantName ?? "").Trim();

            if (string.IsNullOrWhiteSpace(request.Body.MerchantName))
            {
                response.IsSuccess = false;
                response.Message = "请提供商户名！";
                return response;
            }

            if (this.merchantBLL.IsExistMerchantName(request.Body.MerchantName))
            {
                response.IsSuccess = false;
                response.Message = string.Format("商户名【{0}】已存在！", request.Body.MerchantName);
                return response;
            }

            #endregion 数据校验

            response.IsSuccess = this.merchantBLL.Add(request.Body);
            if (response.Body)
            {
                response.Message = "商户信息添加成功！";
            }
            else
            {
                response.Message = "商户信息添加失败！";
            }
            return response;
        }

        /// <summary>
        /// 修改商户信息
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantEdit)]
        public APIResponseEntity<bool> MerchantUpdate(JObject obj)
        {
            var request = obj.ToObject<APIRequestEntity<XCLCMS.Data.Model.Merchant>>();
            var response = new APIResponseEntity<bool>();

            #region 数据校验

            var model = merchantBLL.GetModel(request.Body.MerchantID);
            if (null == model)
            {
                response.IsSuccess = false;
                response.Message = "请指定有效的商户信息！";
                return response;
            }

            if (!string.Equals(model.MerchantName, request.Body.MerchantName))
            {
                if (this.merchantBLL.IsExistMerchantName(request.Body.MerchantName))
                {
                    response.IsSuccess = false;
                    response.Message = string.Format("商户名【{0}】已存在！", request.Body.MerchantName);
                    return response;
                }
            }

            #endregion 数据校验

            model.Address = request.Body.Address;
            model.ContactName = request.Body.ContactName;
            model.Domain = request.Body.Domain;
            model.Email = request.Body.Email;
            model.Landline = request.Body.Landline;
            model.LogoURL = request.Body.LogoURL;
            model.MerchantName = request.Body.MerchantName;
            model.MerchantRemark = request.Body.MerchantRemark;
            model.MerchantState = request.Body.MerchantState;
            model.FK_MerchantType = request.Body.FK_MerchantType;
            model.OtherContact = request.Body.OtherContact;
            model.PassNumber = request.Body.PassNumber;
            model.FK_PassType = request.Body.FK_PassType;
            model.QQ = request.Body.QQ;
            model.RegisterTime = request.Body.RegisterTime;
            model.Remark = request.Body.Remark;
            model.Tel = request.Body.Tel;
            model.UpdaterID = base.CurrentUserModel.UserInfoID;
            model.UpdaterName = base.CurrentUserModel.UserName;
            model.UpdateTime = DateTime.Now;

            response.IsSuccess = this.merchantBLL.Update(model);
            if (response.IsSuccess)
            {
                response.Message = "商户信息修改成功！";
            }
            else
            {
                response.Message = "商户信息修改失败！";
            }
            return response;
        }

        /// <summary>
        /// 删除商户信息
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantDel)]
        public APIResponseEntity<bool> MerchantDelete(JObject obj)
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
                response.Message = "请指定要删除的商户ID！";
                return response;
            }

            using (var scope = new TransactionScope())
            {
                foreach (var k in request.Body)
                {
                    //删除商户基础信息
                    var merchantModel = merchantBLL.GetModel(k);
                    if (null != merchantModel)
                    {
                        merchantModel.UpdaterID = base.CurrentUserModel.UserInfoID;
                        merchantModel.UpdaterName = base.CurrentUserModel.UserName;
                        merchantModel.UpdateTime = DateTime.Now;
                        merchantModel.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.R.ToString();
                        merchantModel.MerchantState = XCLCMS.Data.CommonHelper.EnumType.MerchantStateEnum.N.ToString();
                        if (!merchantBLL.Update(merchantModel))
                        {
                            response.IsSuccess = false;
                            response.Message = "删除失败！";
                            return response;
                        }
                        //删除商户应用信息
                        var merchantAppModelList = this.merchantAppBLL.GetModelList(merchantModel.MerchantID);
                        if (merchantAppModelList.IsNotNullOrEmpty())
                        {
                            foreach (var app in merchantAppModelList)
                            {
                                app.UpdaterID = base.CurrentUserModel.UserInfoID;
                                app.UpdaterName = base.CurrentUserModel.UserName;
                                app.UpdateTime = DateTime.Now;
                                app.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.R.ToString();
                                if (!this.merchantAppBLL.Update(app))
                                {
                                    response.IsSuccess = false;
                                    response.Message = "删除失败！";
                                    return response;
                                }
                            }
                        }
                    }
                }
                scope.Complete();
            }

            response.IsSuccess = true;
            response.Message = "已成功删除商户信息！";
            response.IsRefresh = true;

            return response;
        }

        /// <summary>
        /// 判断商户名是否存在
        /// </summary>
        [HttpGet]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_UserAdmin_MerchantView)]
        public APIResponseEntity<bool> IsExistMerchantName(string json)
        {
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<APIRequestEntity<XCLCMS.Data.WebAPIEntity.RequestEntity.Merchant.IsExistMerchantNameEntity>>(System.Web.HttpUtility.UrlDecode(json));
            var response = new APIResponseEntity<bool>();
            response.IsSuccess = true;
            response.Message = "该商户名可以使用！";

            request.Body.MerchantName = (request.Body.MerchantName ?? "").Trim();

            if (request.Body.MerchantID > 0)
            {
                var model = merchantBLL.GetModel(request.Body.MerchantID);
                if (null != model)
                {
                    if (string.Equals(request.Body.MerchantName, model.MerchantName, StringComparison.OrdinalIgnoreCase))
                    {
                        return response;
                    }
                }
            }

            if (!string.IsNullOrEmpty(request.Body.MerchantName))
            {
                bool isExist = merchantBLL.IsExistMerchantName(request.Body.MerchantName);
                if (isExist)
                {
                    response.IsSuccess = false;
                    response.Message = "该商户名已被占用！";
                }
            }

            return response;
        }
    }
}