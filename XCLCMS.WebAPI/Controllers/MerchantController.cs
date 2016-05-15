using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using XCLCMS.Data.WebAPIEntity;
using XCLCMS.Data.WebAPIEntity.RequestEntity.Merchant;
using XCLNetTools.Generic;

namespace XCLCMS.WebAPI.Controllers
{
    public class MerchantController : BaseAPIController
    {
        private XCLCMS.Data.BLL.View.v_Merchant vMerchantBLL = new Data.BLL.View.v_Merchant();
        private XCLCMS.Data.BLL.Merchant merchantBLL = new Data.BLL.Merchant();

        /// <summary>
        /// 查询商户信息实体
        /// </summary>
        [HttpGet]
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
        public APIResponseEntity<bool> MerchantAdd(JObject obj)
        {
            var request = obj.ToObject<APIRequestEntity<XCLCMS.Data.Model.Merchant>>();
            var response = new APIResponseEntity<bool>();
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
        public APIResponseEntity<bool> MerchantUpdate(JObject obj)
        {
            var request = obj.ToObject<APIRequestEntity<XCLCMS.Data.Model.Merchant>>();
            var response = new APIResponseEntity<bool>();

            var model = merchantBLL.GetModel(request.Body.MerchantID);
            if (null == model)
            {
                response.IsSuccess = false;
                response.Message = "请指定有效的商户信息！";
                return response;
            }

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

            request.Body.ForEach(k =>
            {
                var merchantModel = merchantBLL.GetModel(k);
                if (null != merchantModel)
                {
                    merchantModel.UpdaterID = base.CurrentUserModel.UserInfoID;
                    merchantModel.UpdaterName = base.CurrentUserModel.UserName;
                    merchantModel.UpdateTime = DateTime.Now;
                    merchantModel.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.R.ToString();
                    merchantModel.MerchantState = XCLCMS.Data.CommonHelper.EnumType.MerchantStateEnum.N.ToString();
                    merchantBLL.Update(merchantModel);
                }
            });

            response.IsSuccess = true;
            response.Message = "已成功删除商户信息！";

            return response;
        }
    }
}