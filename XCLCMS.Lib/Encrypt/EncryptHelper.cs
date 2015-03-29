using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCLCMS.Lib.Encrypt
{
    /// <summary>
    /// 加密解密相关
    /// </summary>
    public class EncryptHelper
    {
        /// <summary>
        /// 给字符串md5加密（使用key）
        /// </summary>
        public static string EncryptStringMD5(string str)
        {
            return XCLNetTools.Encrypt.MD5.EncodeMD5(str, XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Common_PwdKey);
        }

        /// <summary>
        /// 判断md5明文和密文是否匹配
        /// </summary>
        public static bool EncryptStringMD5IsEqual(string str, string md5Str)
        {
            return XCLNetTools.Encrypt.MD5.IsEqualMD5(str, md5Str, XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Common_PwdKey);
        }

        /// <summary>
        /// des加密(已带key)
        /// </summary>
        public static string EncryptStringDES(string str)
        {
            return XCLNetTools.Encrypt.DESEncrypt.Encrypt(str, XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Common_DESKey);
        }
        /// <summary>
        /// des 解密
        /// </summary>
        public static string DecryptStringDES(string desString)
        {
            return XCLNetTools.Encrypt.DESEncrypt.Decrypt(desString, XCLCMS.Lib.SysWebSetting.Setting.SettingModel.Common_DESKey);
        }
    }
}
