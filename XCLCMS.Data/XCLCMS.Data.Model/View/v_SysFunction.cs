using System;
namespace XCLCMS.Data.Model.View
{
    /// <summary>
    /// v_SysFunction:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class v_SysFunction
    {
        public v_SysFunction()
        { }
        #region Model
        private long _sysfunctionid;
        private string _functionname;
        private long _fk_typeid;
        private string _remark;
        private string _recordstate;
        private DateTime _createtime;
        private long _createrid;
        private string _creatername;
        private DateTime _updatetime;
        private long _updaterid;
        private string _updatername;
        private string _c_typename;
        /// <summary>
        /// 
        /// </summary>
        public long SysFunctionID
        {
            set { _sysfunctionid = value; }
            get { return _sysfunctionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FunctionName
        {
            set { _functionname = value; }
            get { return _functionname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long FK_TypeID
        {
            set { _fk_typeid = value; }
            get { return _fk_typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
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
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
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
        public string CreaterName
        {
            set { _creatername = value; }
            get { return _creatername; }
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
        public long UpdaterID
        {
            set { _updaterid = value; }
            get { return _updaterid; }
        }
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
        public string C_TypeName
        {
            set { _c_typename = value; }
            get { return _c_typename; }
        }
        #endregion Model

    }
}

