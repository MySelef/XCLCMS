define(["pluploadCN"],function () {
    //文件上传
    var app = {};
    app.Add = {
        /**
         * 文件列表
         */
        _fileModelList: [],
        /**
         * 根据文件id，返回该文件的json model信息
         */
        _getModelById: function (id) {
            var result = null, _this = this;
            if (_this._fileModelList) {
                $.each(_this._fileModelList, function (index, n) {
                    if (n.Id == id) {
                        result = n;
                        return false;
                    }
                });
            }
            return result;
        },
        /**
         * model
         */
        FileModel: function () {
            this.Path = "";//原路径
            this.ImgSmallPath = "";//较小尺寸（文件为图片时180*180）
            this.ImgBigPath = "";//较大尺寸（文件为图片时400*400）
            this.Id = "";//选择文件时，自动分配的id
            this.Size = "";//文件大小
            this.Format = "";//文件格式
            this.Name = "";//文件名
            this.ImgWidth = 0;//原图宽度
            this.ImgHeight = 0;//原图高度
            this.ImgPreviewWidth = 0;//裁剪界面中操作的图片的宽度
            this.ImgPreviewHeight = 0;//裁剪界面中操作的图片的高度
            this.ImgPreviewRatio = 0;//当前操作的预览图与原图的比例，因为裁剪的操作是在预览的小图片上面进行的，最终提交上传的时候，是要对原图进行操作，而不是该小图片。
            this.ImgX1 = 0;//裁剪后的坐标x1
            this.ImgY1 = 0;//裁剪后的坐标y1
            this.ImgX2 = 0;//裁剪后的坐标x2
            this.ImgY2 = 0;//裁剪后的坐标y2
            this.ImgCropWidth = 0;//裁剪后最终图片的宽度
            this.ImgCropHeight = 0;//裁剪后最终图片的高度
        },
        Init: function () {
            var _this = this;

            //初始化上传
            var uploader = new plupload.Uploader({
                browse_button: 'btnAddFile',
                url: 'upload.php'
            });
            uploader.init();
            uploader.bind('FilesAdded', function (up, files) {
                var lst = [];
                plupload.each(files, function (file) {
                    var model = new _this.FileModel();
                    model.Id = file.id;
                    model.Name = file.name;
                    model.Size = plupload.formatSize(file.size);
                    _this.PreviewImage({
                        file: file, callback: function (preloader) {
                            model.ImgWidth = preloader.width;
                            model.ImgHeight = preloader.height;
                            model.Path = preloader.getAsDataURL();

                            preloader.downsize(180, 180);//预览图片的最大宽高，自动等比。
                            model.ImgSmallPath = preloader.getAsDataURL();

                            var imgObj = new mOxie.Image();
                            imgObj.onload = function () {
                                imgObj.downsize(400, 400);
                                model.ImgBigPath = imgObj.getAsDataURL();
                                model.ImgPreviewWidth = imgObj.width;
                                model.ImgPreviewHeight = imgObj.height;
                                model.ImgPreviewRatio = model.ImgPreviewWidth / model.ImgWidth;
                                preloader.destroy();
                                preloader = null;
                            };
                            imgObj.load(file.getSource());

                            $("img#" + file.id).attr({ src: model.ImgSmallPath });
                        }
                    });
                    lst.push(model);
                });
                $("#ItemsUL").append(template('fileItemTemp', { FileModelList: lst }));
                _this._fileModelList = XJ.Array.Concat(_this._fileModelList, lst);
            });

            //修改文件
            var fileEditFunction = function () {
                //打开编辑的选项卡
                var tabFileUpload = $("#tabFileUpload");
                if (tabFileUpload.tabs('exists', '修改图片')) {
                    tabFileUpload.tabs('close', '修改图片');
                }
                tabFileUpload.tabs('add', {
                    title: '修改图片',
                    content: '<div id="divEditFile"></div><div id="divShowImg" style="display:none;"></div>',
                    closable: true
                });

                var id = $(this).attr("xcl-Id");
                var model = _this._getModelById(id);
                $("#divEditFile").html(template('divEditFileTemp', model));
                $.parser.parse();//重新渲染组件

                //缩略图的宽高只能输入数字
                $("input[id^='txtThumbWidth'],input[id^='txtThumbHeight']").numberbox();
                var thumbLines = function () {
                    var $con = $(this).closest("tr");
                    var $w = $con.find("input[id^='txtThumbWidth']"), $h = $con.find("input[id^='txtThumbHeight']");
                    var wVal = $w.numberbox('getValue'), hVal = $h.numberbox('getValue');
                    if (wVal) {
                        $h.numberbox('setValue', (wVal * model.ImgCropHeight) / model.ImgCropWidth);
                    } else if (hVal) {
                        $w.numberbox('setValue', (hVal * model.ImgCropWidth) / model.ImgCropHeight);
                    }
                };
                $("body").on("click", ".btnEqualRatio", function () {
                    thumbLines.call(this);
                    return false;
                });



                //动态增删行
                $.DynamicCon({
                    afterAddOrDel: function () {
                        $.parser.parse();
                    }
                });

                //图片裁剪
                var getCropImgXYInfo = function (img) {
                    model.ImgX1 = parseInt(img.x / model.ImgPreviewRatio);
                    model.ImgX2 = parseInt(img.x2 / model.ImgPreviewRatio);
                    model.ImgY1 = parseInt(img.y / model.ImgPreviewRatio);
                    model.ImgY2 = parseInt(img.y2 / model.ImgPreviewRatio);
                    model.ImgCropWidth = parseInt(img.w / model.ImgPreviewRatio);
                    model.ImgCropHeight = parseInt(img.h / model.ImgPreviewRatio);
                    $("#divImgCropInfo").html("X1：" + model.ImgX1 + "，Y1：" + model.ImgY1 + "，X2：" + model.ImgX2 + "，Y2：" + model.ImgY2 + "。宽高：" + model.ImgCropWidth + "*" + model.ImgCropHeight);
                };
                var defaultCropImgInfo = { x: 0, y: 0, x2: model.ImgPreviewWidth, y2: model.ImgPreviewHeight, w: model.ImgPreviewWidth, h: model.ImgPreviewHeight };
                getCropImgXYInfo(defaultCropImgInfo);
                $("img#ImgToEdit").Jcrop({
                    onSelect: getCropImgXYInfo,
                    onChange: getCropImgXYInfo,
                    onRelease: function () {
                        getCropImgXYInfo(defaultCropImgInfo);
                    }
                });
                //查看原图
                $(document).off("click", "#btnShowSource").on("click", "#btnShowSource", function () {
                    $("#divShowImg").html(template('divShowImgTemp', { ImgSrc: model.Path })).find("form").submit();
                    return false;
                });
            };

            //事件绑定
            $("body").on("click", "a[rel='fileEdit']", function () {
                fileEditFunction.call(this);
                return false;
            });
        },
        /**
         * 图片预览
         */
        PreviewImage: function (options) {
            if (!options.file || !/image\//.test(options.file.type)) return; //确保文件是图片
            if (options.file.type == 'image/gif') {//gif使用FileReader进行预览,因为mOxie.Image只支持jpg和png
                var fr = new mOxie.FileReader();
                fr.onload = function () {
                    options.callback(fr.result);
                    fr.destroy();
                    fr = null;
                };
                fr.readAsDataURL(options.file.getSource());
            } else {
                var preloader = new mOxie.Image();
                preloader.onload = function () {
                    options.callback && options.callback(preloader);
                    preloader.destroy();
                    preloader = null;
                };
                preloader.load(options.file.getSource());
            }
        }
    };

    return app;
});