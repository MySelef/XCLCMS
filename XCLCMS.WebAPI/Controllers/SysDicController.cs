using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using XCLCMS.Data.WebAPIEntity;

namespace XCLCMS.WebAPI.Controllers
{
    /// <summary>
    /// 字典库 管理
    /// </summary>
    public class SysDicController : BaseAPIController
    {
        private XCLCMS.Data.BLL.SysDic sysDicBLL = new Data.BLL.SysDic();
        private XCLCMS.Data.BLL.View.v_SysDic vSysDicBLL = new Data.BLL.View.v_SysDic();

        /// <summary>
        /// 查询所有字典列表
        /// </summary>
        [HttpGet]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysDicView)]
        public APIResponseEntity<List<XCLCMS.Data.Model.View.v_SysDic>> GetList(string json)
        {
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<APIRequestEntity<long>>(System.Web.HttpUtility.UrlDecode(json));
            var response = new APIResponseEntity<List<XCLCMS.Data.Model.View.v_SysDic>>();
            response.Body = this.vSysDicBLL.GetList(request.Body);
            response.IsSuccess = true;
            return response;
        }

        /// <summary>
        /// 添加字典
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysDicAdd)]
        public APIResponseEntity<bool> Add(JObject obj)
        {
            var request = obj.ToObject<APIRequestEntity<XCLCMS.Data.Model.SysDic>>();
            var response = new APIResponseEntity<bool>();

            #region 数据校验

            request.Body.DicName = (request.Body.DicName ?? "").Trim();
            request.Body.Code = (request.Body.Code ?? "").Trim();

            //字典名必填
            if (string.IsNullOrEmpty(request.Body.DicName))
            {
                response.IsSuccess = false;
                response.Message = "请提供字典名！";
                return response;
            }

            //若有code，则判断是否唯一
            if (!string.IsNullOrEmpty(request.Body.Code))
            {
                if (this.sysDicBLL.IsExistCode(request.Body.Code))
                {
                    response.IsSuccess = false;
                    response.Message = string.Format("字典唯一标识【{0}】已存在！", request.Body.Code);
                    return response;
                }
            }

            //当前用户只能加在自己的商户号下面
            var parentNodeModel = this.sysDicBLL.GetModel(request.Body.ParentID);
            if (null == parentNodeModel || parentNodeModel.FK_MerchantID != base.CurrentUserModel.FK_MerchantID)
            {
                response.IsSuccess = false;
                response.Message = string.Format("只能在自己商户的节点下面添加子节点！");
                return response;
            }

            #endregion 数据校验

            if (this.sysDicBLL.Add(request.Body))
            {
                response.IsSuccess = true;
                response.Message = "添加成功！";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "添加失败！";
            }

            return response;
        }

        /// <summary>
        /// 修改字典
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysDicEdit)]
        public APIResponseEntity<bool> Update(JObject obj)
        {
            var request = obj.ToObject<APIRequestEntity<XCLCMS.Data.Model.SysDic>>();
            var response = new APIResponseEntity<bool>();

            #region 数据校验

            var model = this.sysDicBLL.GetModel(request.Body.SysDicID);
            if (null == model)
            {
                response.IsSuccess = false;
                response.Message = "请指定有效的字典信息！";
                return response;
            }

            request.Body.DicName = (request.Body.DicName ?? "").Trim();
            request.Body.Code = (request.Body.Code ?? "").Trim();

            //字典名必填
            if (string.IsNullOrEmpty(request.Body.DicName))
            {
                response.IsSuccess = false;
                response.Message = "请提供字典名！";
                return response;
            }

            //若有code，则判断是否唯一
            if (!string.IsNullOrEmpty(request.Body.Code))
            {
                if (!string.Equals(model.Code, request.Body.Code) && this.sysDicBLL.IsExistCode(request.Body.Code))
                {
                    response.IsSuccess = false;
                    response.Message = string.Format("字典唯一标识【{0}】已存在！", request.Body.Code);
                    return response;
                }
            }

            //只能修改属于自己的商户节点
            if (model.FK_MerchantID != base.CurrentUserModel.FK_MerchantID)
            {
                response.IsSuccess = false;
                response.Message = string.Format("只能修改属于自己的商户节点！");
                return response;
            }

            #endregion 数据校验

            model.Code = request.Body.Code;
            model.DicName = request.Body.DicName;
            model.DicValue = request.Body.DicValue;
            model.FK_FunctionID = request.Body.FK_FunctionID;
            model.FK_MerchantAppID = request.Body.FK_MerchantAppID;
            model.ParentID = request.Body.ParentID;
            model.RecordState = request.Body.RecordState;
            model.Remark = request.Body.Remark;
            model.Sort = request.Body.Sort;
            model.UpdaterID = base.CurrentUserModel.UserInfoID;
            model.UpdaterName = base.CurrentUserModel.UserName;
            model.UpdateTime = DateTime.Now;

            if (this.sysDicBLL.Update(model))
            {
                response.IsSuccess = true;
                response.Message = "修改成功！";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "修改失败！";
            }

            return response;
        }

        /// <summary>
        /// 删除字典
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysDicDel)]
        public APIResponseEntity<bool> Delete(JObject obj)
        {
            var request = obj.ToObject<APIRequestEntity<List<long>>>();
            var response = new APIResponseEntity<bool>();

            if (null == request.Body || request.Body.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = "请指定要删除的字典ID！";
                return response;
            }

            request.Body = request.Body.Distinct().ToList();

            //只能删除自己商户的节点
            if (request.Body.Exists(id =>
            {
                var sysDicModel = sysDicBLL.GetModel(id);
                return null != sysDicModel && sysDicModel.FK_MerchantID != base.CurrentUserModel.FK_MerchantID;
            }))
            {
                response.IsSuccess = false;
                response.Message = "只能删除属于自己的商户节点！";
                return response;
            }

            int successCount = 0;

            request.Body.ForEach(id =>
            {
                var sysDicModel = sysDicBLL.GetModel(id);
                if (null != sysDicModel)
                {
                    sysDicModel.UpdaterID = base.CurrentUserModel.UserInfoID;
                    sysDicModel.UpdaterName = base.CurrentUserModel.UserName;
                    sysDicModel.UpdateTime = DateTime.Now;
                    sysDicModel.RecordState = XCLCMS.Data.CommonHelper.EnumType.RecordStateEnum.D.ToString();
                    if (sysDicBLL.Update(sysDicModel))
                    {
                        successCount++;
                    }
                }
            });

            response.IsSuccess = true;
            response.Message = string.Format("已成功删除【{0}】条记录！", successCount);

            return response;
        }

        /// <summary>
        /// 删除指定字典的所有节点
        /// </summary>
        [HttpPost]
        [XCLCMS.Lib.Filters.FunctionFilter(Function = XCLCMS.Lib.Permission.Function.FunctionEnum.SysFun_Set_SysDicDel)]
        public APIResponseEntity<bool> DelChild(JObject obj)
        {
            var request = obj.ToObject<APIRequestEntity<long>>();
            var response = new APIResponseEntity<bool>();

            if (request.Body <= 0)
            {
                response.IsSuccess = false;
                response.Message = "请指定要删除所有子节点的字典ID！";
                return response;
            }

            var sysDicModel = sysDicBLL.GetModel(request.Body);
            if (null != sysDicModel && sysDicModel.FK_MerchantID != base.CurrentUserModel.FK_MerchantID)
            {
                response.IsSuccess = false;
                response.Message = "只能删除属于自己的商户节点！";
                return response;
            }

            response.IsSuccess = this.sysDicBLL.DelChild(new Data.Model.SysDic()
            {
                SysDicID = request.Body,
                UpdaterID = base.CurrentUserModel.UserInfoID,
                UpdaterName = base.CurrentUserModel.UserName,
                UpdateTime = DateTime.Now
            });

            if (response.IsSuccess)
            {
                response.Message = "成功删除所有子节点！";
            }
            else
            {
                response.Message = "删除所有子节点失败！";
            }

            return response;
        }
    }
}