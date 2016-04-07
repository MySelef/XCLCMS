using System;

namespace XCLCMS.View.AdminWeb.Models.UserControl
{
    public class FileSelectVM
    {
        private string _id = Guid.NewGuid().ToString("N");
        private int _maxFileCount = 1;
        private string _txtName = "txtFileSelectValue";

        /// <summary>
        /// 容器ID
        /// </summary>
        public string ID
        {
            get { return this._id; }
            private set { this._id = value; }
        }

        /// <summary>
        /// 最多选择的文件数量
        /// </summary>
        public int MaxFileCount
        {
            get { return this._maxFileCount; }
            set { this._maxFileCount = value; }
        }

        /// <summary>
        /// 已选结果的存放表单控件的name名称
        /// </summary>
        public string TxtName
        {
            get { return this._txtName; }
            set { this._txtName = value; }
        }

        /// <summary>
        /// 已选结果表单控件的默认值
        /// </summary>
        public string TxtDefaultValue
        {
            get;set;
        }

    }
}