using System;
using System.Data;
using System.Collections.Generic;
using XCLCMS.Data.Model;
namespace XCLCMS.Data.BLL
{
    /// <summary>
    /// ID生成表
    /// </summary>
    public partial class GenerateID
    {
        private readonly XCLCMS.Data.DAL.GenerateID dal = new XCLCMS.Data.DAL.GenerateID();
        public GenerateID()
        { }
        #region  BasicMethod

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 生成主键
        /// </summary>
        /// <param name="IDType">类型</param>
        public long GetGenerateID(string IDType, string remark = "")
        {
            return dal.GetGenerateID(IDType, remark);
        }
        #endregion  ExtensionMethod
    }
}

