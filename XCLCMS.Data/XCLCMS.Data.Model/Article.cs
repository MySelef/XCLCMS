using System;
namespace XCLCMS.Data.Model
{
    /// <summary>
    /// 文章表
    /// </summary>
    [Serializable]
    public partial class Article
    {
        public Article()
        { }
        #region Model
        private long _articleid;
        private string _code;
        private string _title;
        private string _subtitle;
        private string _authorname;
        private string _frominfo;
        private string _articletype;
        private string _contents;
        private string _summary;
        private string _mainimage;
        private int _viewcount;
        private string _iscancomment;
        private int _commentcount;
        private int _goodcount;
        private int _middlecount;
        private int _badcount;
        private int _hotcount;
        private string _urlopentype;
        private string _articlestate;
        private string _recordstate;
        private DateTime _createtime;
        private long _createrid;
        private string _creatername;
        private DateTime _updatetime;
        private long _updaterid;
        private string _updatername;
        /// <summary>
        /// 
        /// </summary>
        public long ArticleID
        {
            set { _articleid = value; }
            get { return _articleid; }
        }
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 子标题
        /// </summary>
        public string SubTitle
        {
            set { _subtitle = value; }
            get { return _subtitle; }
        }
        /// <summary>
        /// 所属作者
        /// </summary>
        public string AuthorName
        {
            set { _authorname = value; }
            get { return _authorname; }
        }
        /// <summary>
        /// 来源
        /// </summary>
        public string FromInfo
        {
            set { _frominfo = value; }
            get { return _frominfo; }
        }
        /// <summary>
        /// 文章类型(ArticleTypeEnum)
        /// </summary>
        public string ArticleType
        {
            set { _articletype = value; }
            get { return _articletype; }
        }
        /// <summary>
        /// 内容正文
        /// </summary>
        public string Contents
        {
            set { _contents = value; }
            get { return _contents; }
        }
        /// <summary>
        /// 概述
        /// </summary>
        public string Summary
        {
            set { _summary = value; }
            get { return _summary; }
        }
        /// <summary>
        /// 主图片地址
        /// </summary>
        public string MainImage
        {
            set { _mainimage = value; }
            get { return _mainimage; }
        }
        /// <summary>
        /// 浏览数
        /// </summary>
        public int ViewCount
        {
            set { _viewcount = value; }
            get { return _viewcount; }
        }
        /// <summary>
        /// 是否能够评论(YesNoEnum)
        /// </summary>
        public string IsCanComment
        {
            set { _iscancomment = value; }
            get { return _iscancomment; }
        }
        /// <summary>
        /// 评论数
        /// </summary>
        public int CommentCount
        {
            set { _commentcount = value; }
            get { return _commentcount; }
        }
        /// <summary>
        /// 点【好】数
        /// </summary>
        public int GoodCount
        {
            set { _goodcount = value; }
            get { return _goodcount; }
        }
        /// <summary>
        /// 点【中】数
        /// </summary>
        public int MiddleCount
        {
            set { _middlecount = value; }
            get { return _middlecount; }
        }
        /// <summary>
        /// 点【差】数
        /// </summary>
        public int BadCount
        {
            set { _badcount = value; }
            get { return _badcount; }
        }
        /// <summary>
        /// 热度
        /// </summary>
        public int HotCount
        {
            set { _hotcount = value; }
            get { return _hotcount; }
        }
        /// <summary>
        /// 打开方式(URLOpenTypeEnum)
        /// </summary>
        public string URLOpenType
        {
            set { _urlopentype = value; }
            get { return _urlopentype; }
        }
        /// <summary>
        /// 文章状态(ArticleStateEnum)
        /// </summary>
        public string ArticleState
        {
            set { _articlestate = value; }
            get { return _articlestate; }
        }
        /// <summary>
        /// 记录状态(RecordStateEnum)
        /// </summary>
        public string RecordState
        {
            set { _recordstate = value; }
            get { return _recordstate; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 创建者ID
        /// </summary>
        public long CreaterID
        {
            set { _createrid = value; }
            get { return _createrid; }
        }
        /// <summary>
        /// 创建者名
        /// </summary>
        public string CreaterName
        {
            set { _creatername = value; }
            get { return _creatername; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 更新人ID
        /// </summary>
        public long UpdaterID
        {
            set { _updaterid = value; }
            get { return _updaterid; }
        }
        /// <summary>
        /// 更新人名
        /// </summary>
        public string UpdaterName
        {
            set { _updatername = value; }
            get { return _updatername; }
        }
        #endregion Model

    }
}

