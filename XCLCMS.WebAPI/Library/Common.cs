namespace XCLCMS.WebAPI.Library
{
    /// <summary>
    /// 公共类
    /// </summary>
    public class Common
    {
        /// <summary>
        /// 根据登录令牌获取用户实体
        /// </summary>
        public static XCLCMS.Data.Model.UserInfo GetUserInfoByUserToken(string token)
        {
            var tokenModel = XCLCMS.WebAPI.Library.EncryptHelper.GetUserNamePwdByToken(token);
            if (null != tokenModel)
            {
                return new XCLCMS.Data.BLL.UserInfo().GetModel(tokenModel.UserName, tokenModel.Pwd);
            }
            return null;
        }
    }
}