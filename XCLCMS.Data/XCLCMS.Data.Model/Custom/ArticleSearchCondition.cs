namespace XCLCMS.Data.Model.Custom
{
    /// <summary>
    /// 文章查询条件
    /// </summary>
    public class ArticleSearchCondition
    {
        private string _recordState = "N";

        /// <summary>
        /// 文章类型
        /// </summary>
        public long? ArticleTypeID { get; set; }

        /// <summary>
        /// 记录状态
        /// </summary>
        public string RecordState
        {
            get { return this._recordState; }
            set { this._recordState = value; }
        }
    }
}