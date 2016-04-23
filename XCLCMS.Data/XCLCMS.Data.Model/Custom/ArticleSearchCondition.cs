using System.Collections.Generic;

namespace XCLCMS.Data.Model.Custom
{
    /// <summary>
    /// 文章查询条件
    /// </summary>
    public class ArticleSearchCondition
    {
        /// <summary>
        /// 文章类型
        /// </summary>
        public List<long> ArticleTypeIDList { get; set; }

        /// <summary>
        /// 记录状态
        /// </summary>
        public string RecordState { get; set; }

        /// <summary>
        /// 文章审核状态
        /// </summary>
        public string VerifyState { get; set; }

        /// <summary>
        /// 文章状态
        /// </summary>
        public string ArticleState { get; set; }
    }
}