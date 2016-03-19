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
     * 根据文件id，删除该文件的json model信息
     */
    _removeModelById: function (id) {
        if (this._fileModelList) {
            this._fileModelList = $.map(this._fileModelList, function (n) {
                return n.Id == id ? null : n;
            });
        }
    },
    /**
    * 文件添加至队列后或移除队列后要执行的方法
    */
    _afterQueueChanged: function () {
        var _this = this;
        //更新文件note提示信息
        $("#fileNote").html(template("fileNoteTemp", {
            FileCount: _this._fileModelList.length
        }));
    },
    /**
    * 禁止编辑和删除的功能
    */
    _removeFileEditFunction: function () {
        $("a[rel='fileEdit'],a[rel='fileDel']").hide("slow", function () {
            $(this).remove();
        });
    },
    /**
    * 上传对象
    */
    _uploader: null,
    /**
    * 上传进度条对象
    */
    _fileUploaderProgress: $("#fileUploaderProgress"),
    /**
    *改变上传按钮的相关状态（可用、不可用）
    */
    _changeUploadButton: function (enable) {
        if (enable) {
            this._uploader.disableBrowse(false);
            $("#btnAddFile,#btnUploadFile").linkbutton("enable");
        } else {
            this._uploader.disableBrowse(true);
            $("#btnAddFile,#btnUploadFile").linkbutton("disable");
        }
    },
    /**
    * 改变清空按钮的状态（可用、不可用）
    */
    _changeClearButtonState: function (enable) {
        $("#btnClear").linkbutton(enable ? "enable" : "disable");
    },
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
        this.X1 = 0;//编辑预览时的坐标x1
        this.Y1 = 0;//编辑预览时的坐标y1
        this.X2 = 0;//编辑预览时的坐标x2
        this.Y2 = 0;//编辑预览时的坐标y2
        this.W = 0;//编辑预览时，所选的预览图的宽度
        this.H = 0;//编辑预览时，所选的预览图的高度
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
        _this._uploader = new plupload.Uploader({
            browse_button: 'btnAddFile',
            url: AppConfig.RootUrl + 'Upload/UploadSubmit',
            file_data_name: "FileInfo",
            filters: {
                prevent_duplicates: true
            },
            flash_swf_url: AppConfig.RootUrl + "Resources/Js/plupload/Moxie.swf",
            silverlight_xap_url: AppConfig.RootUrl + "Resources/Js/plupload/Moxie.xap"
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
                    file: file,
                    callback: function (preloader) {
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
            _this._afterQueueChanged();
        });
        //文件被移出队列的事件
        _this._uploader.bind("FilesRemoved", function (up, files) {
            _this._afterQueueChanged();
        });
        //文件上传前事件
        _this._uploader.bind("BeforeUpload", function (up) {
            var fileuplist = $.map(_this._fileModelList, function (n) {
                //去掉不使用的image-data数据，避免post到服务器
                n.ImgSmallPath = "";
                n.ImgBigPath = "";
                n.Path = "";
                return n;
            });
            up.settings.multipart_params = { FileSetting: JSON.stringify(fileuplist) };
            _this._removeFileEditFunction();
            _this._changeUploadButton(false);
            _this._changeClearButtonState(false);
        });
        //文件上传中的事件
        _this._uploader.bind("UploadProgress", function (up, file) {
            _this._fileUploaderProgress.progressbar("setValue", up.total.percent);
        });
        //所有文件上传完成后事件
        _this._uploader.bind("UploadComplete", function (up, files) {
            if (files.length > 0) {
                art.dialog({
                    icon: "succeed",
                    content: "所有文件已上传完毕！",
                    ok: true
                });
            } else {
                art.dialog({
                    icon: "face-smile",
                    content: "当前没有待上传的文件！",
                    ok: true
                });
            }
            _this._changeClearButtonState(true);
        });
        //上传错误时事件
        _this._uploader.bind("Error", function (uploader, errObject) {
        });
        //文件队列变化时事件
        _this._uploader.bind("QueueChanged", function (up) {
        });
        //上传完成事件
        _this._uploader.bind("FileUploaded", function (uploader, file, responseObject) {
        });

        var tabFileUpload = $("#tabFileUpload");

        //修改文件
        var fileEditFunction = function () {
            var id = $(this).attr("xcl-Id");
            var model = _this._getModelById(id);
            if (null == model.ThumbImgSettings || model.ThumbImgSettings.length == 0) {
                model.ThumbImgSettings = [];
                model.ThumbImgSettings.push(new _this.ThumbImgSettingModel());
            }

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
                model.X1 = img.x;
                model.X2 = img.x2;
                model.Y1 = img.y;
                model.Y2 = img.y2;
                model.W = img.w;
                model.H = img.h;
                model.ImgX1 = parseInt(img.x / model.ImgPreviewRatio);
                model.ImgX2 = parseInt(img.x2 / model.ImgPreviewRatio);
                model.ImgY1 = parseInt(img.y / model.ImgPreviewRatio);
                model.ImgY2 = parseInt(img.y2 / model.ImgPreviewRatio);
                model.ImgCropWidth = parseInt(img.w / model.ImgPreviewRatio);
                model.ImgCropHeight = parseInt(img.h / model.ImgPreviewRatio);
                $("#divImgCropInfo").html("X1：" + model.ImgX1 + "，Y1：" + model.ImgY1 + "，X2：" + model.ImgX2 + "，Y2：" + model.ImgY2 + "。宽高：" + model.ImgCropWidth + "*" + model.ImgCropHeight);
            };
            var defaultCropImgInfo = null;
            if (model.X1 + model.X2 + model.Y1 + model.Y2 == 0) {
                //如果没有已选的坐标信息，则默认为整个图坐标
                defaultCropImgInfo = { x: 0, y: 0, x2: model.ImgPreviewWidth, y2: model.ImgPreviewHeight, w: model.ImgPreviewWidth, h: model.ImgPreviewHeight };
            } else {
                //如果已有选择过的坐标信息，则默认为该选择的坐标信息
                defaultCropImgInfo = { x: model.X1, y: model.Y1, x2: model.X2, y2: model.Y2, w: model.W, h: model.H };
            }
            getCropImgXYInfo(defaultCropImgInfo);
            $("img#ImgToEdit").Jcrop({
                onSelect: getCropImgXYInfo,
                onChange: getCropImgXYInfo,
                onRelease: function () {
                    getCropImgXYInfo(defaultCropImgInfo);
                }
            }, function () {
                if (model.X1 + model.X2 + model.Y1 + model.Y2 > 0) {
                    this.setSelect([model.X1, model.Y1, model.X2, model.Y2]);
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
                    obj.Width = XJ.Data.GetInt($.trim(n.value));
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

        //删除文件
        var fileDelFunction = function () {
            var id = $(this).attr("xcl-Id");
            _this._uploader.removeFile(id);
            _this._removeModelById(id);
            $("#" + id).closest("li").hide("normal", function () {
                $(this).remove();
            });
            _this._afterQueueChanged();
        };

        //清空重来
        var clearFunction = function () {
            _this._fileUploaderProgress.progressbar("setValue", 0);
            _this._fileModelList = [];
            _this._changeUploadButton(true);
            $(".UploadItemDiv #ItemsUL").html("");
            _this._uploader.splice(0, _this._uploader.files.length);
            _this._uploader.refresh();
        };

        //事件绑定
        $("body").on("click", "a[rel='fileEdit']", function () {
            fileEditFunction.call(this);
            return false;
        }).on("click", "a[rel='fileDetail']", function () {
            fileDetailFunction.call(this);
            return false;
        }).on("click", "a[rel='fileDel']", function () {
            fileDelFunction.call(this);
            return false;
        });
        $("#btnUploadFile").on("click", function () {
            _this.StartUpload();
            return false;
        });
        $("#btnClear").on("click", function () {
            clearFunction.call(this);
            return false;
        });
        _this._afterQueueChanged();
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