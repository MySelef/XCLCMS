angular.module('ngUpload', []).controller('fileUpload', function ($scope) {
    var tabFileUpload = $("#tabFileUpload");

    //文件列表中的Model
    var fileModel = function () {
        this.IsImage = false;//是否为图片
        this.Path = "";//原路径
        this.ImgSmallPath = "";//较小尺寸（文件为图片时180*180）
        this.ImgBigPath = "";//较大尺寸（文件为图片时600*600）
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

        this.Title = "";//文件标题
        this.ViewType = "";//查看类型
        this.DownloadCount = 0;//下载数
        this.ViewCount = 0;//查看数
        this.Description = "";//描述

        this.IsCanEdit = true;//是否可以编辑信息
        this.IsCanDel = true;//是否可以删除该文件
    };

    //文件编辑中缩略图设置model
    var thumbImgSettingModel = function () {
        this.Width = 0;//宽度
        this.Height = 0;//高度
        this.IsMain = false;//是否为主图
    };

    //当前文件列表
    $scope.FileModelList = [];

    //是否允许添加待上传文件
    $scope.IsCanAddFile = true;

    //是否允许开始上传的操作
    $scope.IsCanUploadFile = true;

    //当前在操作中的model（如：查询该文件详情、修改该文件信息）
    $scope.CurrentFileModel = null;

    //上传对象
    var _uploader = null;

    //编辑时的图片裁剪对象
    var _jcp = null;

    /**
     * 根据文件id，返回该文件的json model信息
     */
    var getModelById = function (id) {
        var result = null, _this = this;
        if ($scope.FileModelList) {
            $.each($scope.FileModelList, function (index, n) {
                if (n.Id == id) {
                    result = n;
                    return false;
                }
            });
        }
        return result;
    };

    /**
     * 根据文件id，删除该文件的json model信息
     */
    var removeModelById = function (id) {
        if ($scope.FileModelList) {
            $scope.FileModelList = $.map($scope.FileModelList, function (n) {
                return n.Id == id ? null : n;
            });
        }
        if ($scope.CurrentFileModel && id === $scope.CurrentFileModel.Id) {
            $scope.CurrentFileModel = null;
        }
    };

    /*******************************文件列表页开始*************************************/

    /**
    *改变上传按钮的相关状态（可用、不可用）
    */
    var changeUploadButton = function (enable) {
        if (enable) {
            _uploader.disableBrowse(false);
            $scope.IsCanAddFile = true;
            $scope.IsCanUploadFile = true;
        } else {
            _uploader.disableBrowse(true);
            $scope.IsCanAddFile = false;
            $scope.IsCanUploadFile = false;
        }
    };

    //单击开始上传文件
    $scope.startUpload = function () {
        if (_uploader) {
            _uploader.start();
        }
    };

    //单击清空重来
    $scope.clearFunction = function () {
        $("#fileUploaderProgress").progressbar("setValue", 0);
        $scope.FileModelList = [];
        _uploader.splice(0, _uploader.files.length);
        _uploader.refresh();
    };

    //单击修改文件
    $scope.fileEditFunction = function (id) {
        $scope.CurrentFileModel = getModelById(id);
        if (null == $scope.CurrentFileModel.ThumbImgSettings || $scope.CurrentFileModel.ThumbImgSettings.length == 0) {
            $scope.CurrentFileModel.ThumbImgSettings = [new thumbImgSettingModel()];
        }
        tabFileUpload.tabs('select', "文件设置");

        if (_jcp) {
            _jcp.destroy();
        }

        ////生成缩略图设置
        //var thumbLines = function () {
        //    var $con = $(this).closest("tr");
        //    var $w = $con.find("input[id^='txtThumbWidth']"), $h = $con.find("input[id^='txtThumbHeight']");
        //    var wVal = XJ.Data.GetInt($.trim($w.val())), hVal = XJ.Data.GetInt($.trim($h.val()));
        //    $w.val(wVal);
        //    $h.val(hVal);
        //    if (wVal) {
        //        $h.val(XJ.Data.GetInt((wVal * $scope.CurrentFileModel.ImgCropHeight) / $scope.CurrentFileModel.ImgCropWidth));
        //    } else if (hVal) {
        //        $w.val(XJ.Data.GetInt((hVal * $scope.CurrentFileModel.ImgCropWidth) / $scope.CurrentFileModel.ImgCropHeight));
        //    }
        //};
        //$("body").off("click", ".btnEqualRatio").on("click", ".btnEqualRatio", function () {
        //    //调整指定行
        //    thumbLines.call(this);
        //    return false;
        //});
        //$("body").off("click", ".btnEqualRatioAll").on("click", ".btnEqualRatioAll", function () {
        //    //调整所有行
        //    $(".btnEqualRatio").each(function () {
        //        thumbLines.call(this);
        //    });
        //});
    };

    //单击文件详情
    $scope.fileDetailFunction = function (id) {
        $scope.CurrentFileModel = getModelById(id);
        tabFileUpload.tabs('select', "文件详情");
    };

    //单击删除文件
    $scope.fileDelFunction = function (id) {
        _uploader.removeFile(id);
        removeModelById(id);
    };

    /*******************************文件设置页开始*************************************/

    /**
     * 图片预览
     */
    var previewImage = function (options) {
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
    };

    //图片裁剪
    var getCropImgXYInfo = function (img) {
        $scope.CurrentFileModel.X1 = img.x;
        $scope.CurrentFileModel.X2 = img.x2;
        $scope.CurrentFileModel.Y1 = img.y;
        $scope.CurrentFileModel.Y2 = img.y2;
        $scope.CurrentFileModel.W = img.w;
        $scope.CurrentFileModel.H = img.h;
        $scope.CurrentFileModel.ImgX1 = parseInt(img.x / $scope.CurrentFileModel.ImgPreviewRatio);
        $scope.CurrentFileModel.ImgX2 = parseInt(img.x2 / $scope.CurrentFileModel.ImgPreviewRatio);
        $scope.CurrentFileModel.ImgY1 = parseInt(img.y / $scope.CurrentFileModel.ImgPreviewRatio);
        $scope.CurrentFileModel.ImgY2 = parseInt(img.y2 / $scope.CurrentFileModel.ImgPreviewRatio);
        $scope.CurrentFileModel.ImgCropWidth = parseInt(img.w / $scope.CurrentFileModel.ImgPreviewRatio);
        $scope.CurrentFileModel.ImgCropHeight = parseInt(img.h / $scope.CurrentFileModel.ImgPreviewRatio);
    };

    //单击查看原图
    $scope.showSourceImg = function () {
        $("#formShowImg").submit();
    };

    //添加缩略图配置行
    $scope.thumbImgSettingAdd = function () {
        $scope.CurrentFileModel.ThumbImgSettings.push(new thumbImgSettingModel());
    };

    //删除缩略图配置行
    $scope.thumbImgSettingDel = function (idx) {
        $scope.CurrentFileModel.ThumbImgSettings.splice(idx, 1);
    };

    var setEqualRatioFunction = function (model) {
        if (model.Width) {
            model.Height = XJ.Data.GetInt((model.Width * $scope.CurrentFileModel.ImgCropHeight) / $scope.CurrentFileModel.ImgCropWidth);
        } else {
            model.Width = XJ.Data.GetInt((model.Height * $scope.CurrentFileModel.ImgCropWidth) / $scope.CurrentFileModel.ImgCropHeight);
        }
    };

    //设置缩略图的等比值
    $scope.setEqualRatio = function (m) {
        if (m) {
            setEqualRatioFunction.call(this, m);
            return;
        }
        $.each($scope.CurrentFileModel.ThumbImgSettings, function (idx, k) {
            setEqualRatioFunction.call(this, k);
        });
    };

    ////单击保存编辑
    //$scope.saveEdit = function () {
    //    $scope.CurrentFileModel.ThumbImgSettings = [];
    //    var $con = $(".dynamicCon"), $w = $con.find("input[name='txtThumbWidth']"), $h = $con.find("input[name='txtThumbHeight']"), $isMain = $con.find("input[name='ckIsMain']");
    //    $w.each(function (idx, n) {
    //        var obj = new thumbImgSettingModel();
    //        obj.Width = XJ.Data.GetInt($.trim(n.value));
    //        obj.Height = XJ.Data.GetInt($.trim($h[idx].value));
    //        obj.IsMain = $isMain[idx].checked;
    //        $scope.CurrentFileModel.ThumbImgSettings.push(obj);
    //    });
    //    tabFileUpload.tabs('close', tabTitle);
    //};

    //图片编辑时，初始化裁剪插件
    $scope.initImgCrop = function () {
        $("img#ImgToEdit").Jcrop({
            onSelect: function () {
                getCropImgXYInfo.apply(this, arguments);
                $scope.$apply();
            },
            onChange: function () {
                getCropImgXYInfo.apply(this, arguments);
                $scope.$apply();
            },
            onRelease: function () {
                if ($scope.CurrentFileModel.ImgCropWidth == 0 || $scope.CurrentFileModel.ImgCropWidth == 0) {
                    this.setSelect([0, 0, $scope.CurrentFileModel.ImgPreviewWidth, $scope.CurrentFileModel.ImgPreviewHeight]);
                } else {
                    this.setSelect([$scope.CurrentFileModel.X1, $scope.CurrentFileModel.Y1, $scope.CurrentFileModel.X2, $scope.CurrentFileModel.Y2]);
                }
            }
        }, function () {
            _jcp = this;
            this.release.call(this);
        });
    };

    $scope.$watch("CurrentFileModel", function (model) {
        //tab选项卡状态更新
        try
        {
            if (model) {
                tabFileUpload.tabs('enableTab', "文件详情");
                tabFileUpload.tabs('enableTab', "文件设置");
            } else {
                tabFileUpload.tabs('select', "选择文件");
                tabFileUpload.tabs('disableTab', "文件详情");
                tabFileUpload.tabs('disableTab', "文件设置");
            }
        } catch (ex) { }
        ////计算等比值更新
        //if (model) {
        //    $scope.setEqualRatio();
        //}
    });

    //初始化
    $scope.init = function () {
        //初始化上传
        _uploader = new plupload.Uploader({
            browse_button: 'btnAddFile',
            url: AppConfig.RootUrl + 'Upload/UploadSubmit',
            file_data_name: "FileInfo",
            filters: {
                prevent_duplicates: true
            },
            flash_swf_url: AppConfig.RootUrl + "Resources/Js/plupload/Moxie.swf",
            silverlight_xap_url: AppConfig.RootUrl + "Resources/Js/plupload/Moxie.xap"
        });
        _uploader.init();

        //文件被添加进来的事件
        _uploader.bind('FilesAdded', function (up, files) {
            var lst = [];
            plupload.each(files, function (file) {
                var model = new fileModel();
                model.Id = file.id;
                model.Name = file.name;
                model.Size = plupload.formatSize(file.size);
                model.IsImage = XJ.ContentType.IsImage(file.type);
                //生成预览图
                previewImage({
                    file: file,
                    callback: function (preloader) {
                        model.ImgWidth = preloader.width;
                        model.ImgHeight = preloader.height;
                        model.Path = preloader.getAsDataURL();

                        preloader.downsize(180, 180);//预览图片的最大宽高，自动等比。
                        model.ImgSmallPath = preloader.getAsDataURL();

                        var imgObj = new mOxie.Image();
                        imgObj.onload = function () {
                            imgObj.downsize(600, 600);
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
            $scope.FileModelList = XJ.Array.Concat($scope.FileModelList, lst);
            $scope.$apply();
        });
        //文件上传前事件
        _uploader.bind("BeforeUpload", function (up) {
            var fileuplist = $.map($scope.FileModelList, function (n) {
                //去掉不使用的image-data数据，避免post到服务器
                n.ImgSmallPath = "";
                n.ImgBigPath = "";
                n.Path = "";
                return n;
            });
            up.settings.multipart_params = { FileSetting: JSON.stringify(fileuplist) };
            changeUploadButton(false);
            $scope.$apply();
        });
        //文件上传中的事件
        _uploader.bind("UploadProgress", function (up, file) {
            $("#fileUploaderProgress").progressbar("setValue", up.total.percent);
        });
        //所有文件上传完成后事件
        _uploader.bind("UploadComplete", function (up, files) {
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
        });
    };
    $scope.init();
});

$(function () {
    var tabFileUpload = $("#tabFileUpload");
    tabFileUpload.tabs('disableTab', "文件详情");
    tabFileUpload.tabs('disableTab', "文件设置");
});