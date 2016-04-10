using System;

namespace XCLCMS.Data.Model.View
{
    public class v_Article
    {
        public v_Article()
        { }

        #region Model

        private string _updatername;
        private long _updaterid;
        private DateTime _updatetime;
        private string _creatername;
        private long _createrid;
        private DateTime _createtime;
        private string _recordstate;
        private DateTime? _publishtime;
        private string _linkurl;
        private string _comments;
        private string _tags;
        private string _keywords;
        private DateTime? _topendtime;
        private DateTime? _topbegintime;
        private string _istop;
        private string _isessence;
        private string _isrecommend;
        private string _verifystate;
        private string _articlestate;
        private string _urlopentype;
        private int _hotcount;
        private int _badcount;
        private int _middlecount;
        private int _goodcount;
        private int _commentcount;
        private string _iscancomment;
        private int _viewcount;
        private long? _mainimage3;
        private long? _mainimage2;
        private long? _mainimage1;
        private string _summary;
        private string _contents;
        private string _articlecontenttype;
        private string _frominfo;
        private string _authorname;
        private string _subtitle;
        private string _title;
        private string _code;
        private long _articleid;
        private string _articletypeids;
        private string _articletypenames;

        /// <summary>
        ///
        /// </summary>
        public string UpdaterName
        {
            set { _updatername = value; }
            get { return _updatername; }
        }

        /// <summary>
        ///
        /// </summary>
        public long UpdaterID
        {
            set { _updaterid = value; }
            get { return _updaterid; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }

        /// <summary>
        ///
        /// </summary>
        public string CreaterName
        {
            set { _creatername = value; }
            get { return _creatername; }
        }

        /// <summary>
        ///
        /// </summary>
        public long CreaterID
        {
            set { _createrid = value; }
            get { return _createrid; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }

        /// <summary>
        ///
        /// </summary>
        public string RecordState
        {
            set { _recordstate = value; }
            get { return _recordstate; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime? PublishTime
        {
            set { _publishtime = value; }
            get { return _publishtime; }
        }

        /// <summary>
        ///
        /// </summary>
        public string LinkUrl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Comments
        {
            set { _comments = value; }
            get { return _comments; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Tags
        {
            set { _tags = value; }
            get { return _tags; }
        }

        /// <summary>
        ///
        /// </summary>
        public string KeyWords
        {
            set { _keywords = value; }
            get { return _keywords; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime? TopEndTime
        {
            set { _topendtime = value; }
            get { return _topendtime; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime? TopBeginTime
        {
            set { _topbegintime = value; }
            get { return _topbegintime; }
        }

        /// <summary>
        ///
        /// </summary>
        public string IsTop
        {
            set { _istop = value; }
            get { return _istop; }
        }

        /// <summary>
        ///
        /// </summary>
        public string IsEssence
        {
            set { _isessence = value; }
            get { return _isessence; }
        }

        /// <summary>
        ///
        /// </summary>
        public string IsRecommend
        {
            set { _isrecommend = value; }
            get { return _isrecommend; }
        }

        /// <summary>
        ///
        /// </summary>
        public string VerifyState
        {
            set { _verifystate = value; }
            get { return _verifystate; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ArticleState
        {
            set { _articlestate = value; }
            get { return _articlestate; }
        }

        /// <summary>
        ///
        /// </summary>
        public string URLOpenType
        {
            set { _urlopentype = value; }
            get { return _urlopentype; }
        }

        /// <summary>
        ///
        /// </summary>
        public int HotCount
        {
            set { _hotcount = value; }
            get { return _hotcount; }
        }

        /// <summary>
        ///
        /// </summary>
        public int BadCount
        {
            set { _badcount = value; }
            get { return _badcount; }
        }

        /// <summary>
        ///
        /// </summary>
        public int MiddleCount
        {
            set { _middlecount = value; }
            get { return _middlecount; }
        }

        /// <summary>
        ///
        /// </summary>
        public int GoodCount
        {
            set { _goodcount = value; }
            get { return _goodcount; }
        }

        /// <summary>
        ///
        /// </summary>
        public int CommentCount
        {
            set { _commentcount = value; }
            get { return _commentcount; }
        }

        /// <summary>
        ///
        /// </summary>
        public string IsCanComment
        {
            set { _iscancomment = value; }
            get { return _iscancomment; }
        }

        /// <summary>
        ///
        /// </summary>
        public int ViewCount
        {
            set { _viewcount = value; }
            get { return _viewcount; }
        }

        /// <summary>
        ///
        /// </summary>
        public long? MainImage3
        {
            set { _mainimage3 = value; }
            get { return _mainimage3; }
        }

        /// <summary>
        ///
        /// </summary>
        public long? MainImage2
        {
            set { _mainimage2 = value; }
            get { return _mainimage2; }
        }

        /// <summary>
        ///
        /// </summary>
        public long? MainImage1
        {
            set { _mainimage1 = value; }
            get { return _mainimage1; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Summary
        {
            set { _summary = value; }
            get { return _summary; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Contents
        {
            set { _contents = value; }
            get { return _contents; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ArticleContentType
        {
            set { _articlecontenttype = value; }
            get { return _articlecontenttype; }
        }

        /// <summary>
        ///
        /// </summary>
        public string FromInfo
        {
            set { _frominfo = value; }
            get { return _frominfo; }
        }

        /// <summary>
        ///
        /// </summary>
        public string AuthorName
        {
            set { _authorname = value; }
            get { return _authorname; }
        }

        /// <summary>
        ///
        /// </summary>
        public string SubTitle
        {
            set { _subtitle = value; }
            get { return _subtitle; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }

        /// <summary>
        ///
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }

        /// <summary>
        ///
        /// </summary>
        public long ArticleID
        {
            set { _articleid = value; }
            get { return _articleid; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ArticleTypeIDs
        {
            set { _articletypeids = value; }
            get { return _articletypeids; }
        }

        /// <summary>
        ///
        /// </summary>
        public string ArticleTypeNames
        {
            set { _articletypenames = value; }
            get { return _articletypenames; }
        }

        #endregion Model
    }
}