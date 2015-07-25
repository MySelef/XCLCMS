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
        * 上传对象
        */
        _uploader:null,
        /**
         * model
         */
        FileModel: function () {
            this.IsImage = false;//是否为图片
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
            this.ThumbImgSettings = [];//要生成的缩略图选项设置
        },
        /**
        * 缩略图设置model
        */
        ThumbImgSettingModel: function () {
            this.Width = 0;//宽度
            this.Height = 0;//高度
            this.IsMain = false;//是否为主图
        },
        Init: function () {
            var _this = this;

            //初始化上传
            _this._uploader= new plupload.Uploader({
                browse_button: 'btnAddFile',
                url: XCLCMSPageGlobalConfig.RootURL + 'Upload/UploadSubmit',
                multipart_params: { FileSettings: _this._fileModelList },
                file_data_name: "FileInfo",
                filters: {
                    prevent_duplicates:true
                }
            });
            _this._uploader.init();
            //文件被添加进来的事件
            _this._uploader.bind('FilesAdded', function (up, files) {
                var lst = [];
                plupload.each(files, function (file) {
                    var model = new _this.FileModel();
                    model.Id = file.id;
                    model.Name = file.name;
                    model.Size = plupload.formatSize(file.size);
                    model.IsImage = XJ.ContentType.IsImage(file.type);
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
            //文件上传中的事件
            _this._uploader.bind("UploadProgress", function (up,file) {

            });
            //所有文件上传完成后事件
            _this._uploader.bind("UploadComplete", function (up, files) {
                art.dialog.tips("所有文件已上传完毕！");
            });
            //上传错误时事件
            _this._uploader.bind("Error", function (uploader, errObject) {
                art.dialog.tips("上传出错了！");
            });

            var tabFileUpload = $("#tabFileUpload");

            //修改文件
            var fileEditFunction = function () {
                var id = $(this).attr("xcl-Id");
                var model = _this._getModelById(id);

                //打开编辑的选项卡
                var tabTitle = "文件设置";
                
                if (tabFileUpload.tabs('exists', tabTitle)) {
                    tabFileUpload.tabs('close', tabTitle);
                }
                tabFileUpload.tabs('add', {
                    title: tabTitle,
                    content: template('divEditFileTemp', model),
                    closable: true,
                    onOpen: function () {
                        $.parser.parse();//重新渲染组件
                    }
                });


                //生成缩略图设置
                var thumbLines = function () {
                    var $con = $(this).closest("tr");
                    var $w = $con.find("input[id^='txtThumbWidth']"), $h = $con.find("input[id^='txtThumbHeight']");
                    var wVal = XJ.Data.GetInt($.trim($w.val())), hVal = XJ.Data.GetInt($.trim($h.val()));
                    $w.val(wVal);
                    $h.val(hVal);
                    if (wVal) {
                        $h.val(XJ.Data.GetInt((wVal * model.ImgCropHeight) / model.ImgCropWidth));
                    } else if (hVal) {
                        $w.val(XJ.Data.GetInt((hVal * model.ImgCropWidth) / model.ImgCropHeight));
                    }
                };
                $("body").off("click", ".btnEqualRatio").on("click", ".btnEqualRatio", function () {
                    //调整指定行
                    thumbLines.call(this);
                    return false;
                });
                $("body").off("click", ".btnEqualRatioAll").on("click", ".btnEqualRatioAll", function () {
                    //调整所有行
                    $(".btnEqualRatio").each(function () {
                        thumbLines.call(this);
                    });
                });

                //动态增删行
                $.DynamicCon();

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
                //保存设置
                $(document).off("click", "#btnSaveEdit").on("click", "#btnSaveEdit", function () {
                    model.ThumbImgSettings = [];
                    var $con = $(".dynamicCon"), $w = $con.find("input[name='txtThumbWidth']"), $h = $con.find("input[name='txtThumbHeight']"), $isMain = $con.find("input[name='ckIsMain']");
                    $w.each(function (idx, n) {
                        var obj = new _this.ThumbImgSettingModel();
                        obj.Width =XJ.Data.GetInt($.trim(n.value));
                        obj.Height = XJ.Data.GetInt($.trim($h[idx].value));
                        obj.IsMain = $isMain[idx].checked;
                        model.ThumbImgSettings.push(obj);
                    });
                    tabFileUpload.tabs('close', tabTitle);
                    return false;
                });
            };

            //文件详情
            var fileDetailFunction = function () {
                var id = $(this).attr("xcl-Id");
                var model = _this._getModelById(id);

                //打开编辑的选项卡
                var tabTitle = "文件详情";
                if (tabFileUpload.tabs('exists', tabTitle)) {
                    tabFileUpload.tabs('close', tabTitle);
                }
                tabFileUpload.tabs('add', {
                    title: tabTitle,
                    content: template('divFileDetailTemp', model),
                    closable: true
                });
            };

            //事件绑定
            $("body").on("click", "a[rel='fileEdit']", function () {
                fileEditFunction.call(this);
                return false;
            }).on("click", "a[rel='fileDetail']", function () {
                fileDetailFunction.call(this);
                return false;
            }).on("click", "#btnUploadFile", function () {
                _this.StartUpload();
                return false;
            });
        },
        /**
         * 图片预览
         */
        PreviewImage: function (options) {
            if (!options.file || !XJ.ContentType.IsImage(options.file.type)) return; //确保文件是图片
            if (XJ.ContentType.IsGif(options.file.type)) {//gif使用FileReader进行预览,因为mOxie.Image只支持jpg和png
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
        },
        /**
        * 开始上传文件
        */
        StartUpload: function () {
            if (this._uploader) {
                this._uploader.start();
            }
        }
    };

    return app;
});