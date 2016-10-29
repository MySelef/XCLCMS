namespace XCLCMS.WebAPI.Library
{
    /// <summary>
    /// 加密解密相关
    /// </summary>
    public class EncryptHelper
    {
        private const string PwdKey = "XCL1989";
        private const string DESKey = "XCL1989";

        /// <summary>
        /// 给字符串md5加密（使用key）
        /// </summary>
        public static string EncryptStringMD5(string str)
        {
            return XCLNetTools.Encrypt.MD5.EncodeMD5(str, PwdKey);
        }

        /// <summary>
        /// 判断md5明文和密文是否匹配
        /// </summary>
        public static bool EncryptStringMD5IsEqual(string str, string md5Str)
        {
            return XCLNetTools.Encrypt.MD5.IsEqualMD5(str, md5Str, PwdKey);
        }

        /// <summary>
        /// des加密(已带key)
        /// </summary>
        public static string EncryptStringDES(string str)
        {
            return XCLNetTools.Encrypt.DESEncrypt.Encrypt(str, DESKey);
        }

        /// <summary>
        /// des 解密
        /// </summary>
        public static string DecryptStringDES(string desString)
        {
            return XCLNetTools.Encrypt.DESEncrypt.Decrypt(desString, DESKey);
        }

        /// <summary>
        /// 根据用户名密码实体来生成登录令牌
        /// </summary>
        public static string CreateToken(XCLCMS.Data.Model.Custom.UserNamePwd model)
        {
            if (null == model)
            {
                return null;
            }
            return XCLCMS.WebAPI.Library.EncryptHelper.EncryptStringDES(string.Format("{0}^{1}", model.UserName, model.Pwd));
        }

        /// <summary>
        /// 从加密的令牌中获取用户名和密码实体
        /// </summary>
        public static XCLCMS.Data.Model.Custom.UserNamePwd GetUserNamePwdByToken(string token)
        {
            XCLCMS.Data.Model.Custom.UserNamePwd model = null;
            if (string.IsNullOrWhiteSpace(token))
            {
                return model;
            }
            var ut = XCLCMS.WebAPI.Library.EncryptHelper.DecryptStringDES(token);//解密为：admin^21232F297A57A5A743894A0E4A801FC3
            string[] strSplit = ut.Split('^');
            if (strSplit.Length == 2)
            {
                model = new Data.Model.Custom.UserNamePwd();
                model.UserName = strSplit[0];
                model.Pwd = strSplit[1];
            }
            return model;
        }
    }
}