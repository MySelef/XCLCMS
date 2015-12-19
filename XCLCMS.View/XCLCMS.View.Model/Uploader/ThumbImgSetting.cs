using System;

namespace XCLCMS.View.Model.Uploader
{
    /// <summary>
    /// 缩略图参数设置model
    /// </summary>
    [Serializable]
    public class ThumbImgSetting
    {
        /// <summary>
        /// 宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 是否为主图
        /// </summary>
        public bool IsMain { get; set; }
    }
}