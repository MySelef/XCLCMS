using System;

namespace XCLCMS.FileManager.Models.Uploader
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
    }
}