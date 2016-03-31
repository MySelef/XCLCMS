using System;
using System.Collections.Generic;

namespace XCLCMS.FileManager.Models.Uploader
{
    /// <summary>
    /// 上传文件设置的一些参数model
    /// </summary>
    [Serializable]
    public class FileSetting
    {
        /// <summary>
        /// 是否为图片
        /// </summary>
        public bool IsImage { get; set; }

        /// <summary>
        /// 原路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 较小尺寸（文件为图片时180*180）
        /// </summary>
        public string ImgSmallPath { get; set; }

        /// <summary>
        /// 较大尺寸（文件为图片时600*600）
        /// </summary>
        public string ImgBigPath { get; set; }

        /// <summary>
        /// 选择文件时，自动分配的id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// 文件格式
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 原图宽度
        /// </summary>
        public int ImgWidth { get; set; }

        /// <summary>
        /// 原图高度
        /// </summary>
        public int ImgHeight { get; set; }

        /// <summary>
        /// 裁剪界面中操作的图片的宽度
        /// </summary>
        public int ImgPreviewWidth { get; set; }

        /// <summary>
        /// 裁剪界面中操作的图片的高度
        /// </summary>
        public int ImgPreviewHeight { get; set; }

        /// <summary>
        /// 当前操作的预览图与原图的比例，因为裁剪的操作是在预览的小图片上面进行的，最终提交上传的时候，是要对原图进行操作，而不是该小图片。
        /// </summary>
        public decimal ImgPreviewRatio { get; set; }

        /// <summary>
        /// 编辑预览时的坐标x1
        /// </summary>
        public int X1 { get; set; }

        /// <summary>
        /// 编辑预览时的坐标y1
        /// </summary>
        public int Y1 { get; set; }

        /// <summary>
        /// 编辑预览时的坐标x2
        /// </summary>
        public int X2 { get; set; }

        /// <summary>
        /// 编辑预览时的坐标y2
        /// </summary>
        public int Y2 { get; set; }

        /// <summary>
        /// 编辑预览时，所选的预览图的宽度
        /// </summary>
        public int W { get; set; }

        /// <summary>
        /// 编辑预览时，所选的预览图的高度
        /// </summary>
        public int H { get; set; }

        /// <summary>
        /// 裁剪后的坐标x1
        /// </summary>
        public int ImgX1 { get; set; }

        /// <summary>
        /// 裁剪后的坐标y1
        /// </summary>
        public int ImgY1 { get; set; }

        /// <summary>
        /// 裁剪后的坐标x2
        /// </summary>
        public int ImgX2 { get; set; }

        /// <summary>
        /// 裁剪后的坐标y2
        /// </summary>
        public int ImgY2 { get; set; }

        /// <summary>
        /// 裁剪后最终图片的宽度
        /// </summary>
        public int ImgCropWidth { get; set; }

        /// <summary>
        /// 裁剪后最终图片的高度
        /// </summary>
        public int ImgCropHeight { get; set; }

        /// <summary>
        /// 要生成的缩略图选项设置
        /// </summary>
        public List<ThumbImgSetting> ThumbImgSettings { get; set; }

        /// <summary>
        /// 文件标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 查看类型
        /// </summary>
        public string ViewType { get; set; }

        /// <summary>
        /// 下载数
        /// </summary>
        public int DownloadCount { get; set; }

        /// <summary>
        /// 查看数
        /// </summary>
        public int ViewCount { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 原图是否需要裁剪（如果裁剪后的宽高和原图宽高一样，则判断为原图不需要剪裁操作）
        /// </summary>
        public bool IsNeedCrop
        {
            get
            {
                if (!this.IsImage)
                {
                    return false;
                }
                if (this.ImgCropWidth == 0 || this.ImgCropHeight == 0)
                {
                    return false;
                }
                if (this.ImgCropWidth == this.ImgWidth && this.ImgCropHeight == this.ImgHeight && this.ImgWidth > 0 && this.ImgHeight > 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}