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
            this.SmallPath = "";//较小尺寸（文件为图片时180*180）
            this.BigPath = "";//较大尺寸（文件为图片时400*400）
            this.Id = "";
            this.Size = "";
            this.Format = "";
            this.Name = "";
            this.Width = 0;
            this.Height = 0;
            this.X1 = 0;
            this.Y1 = 0;
            this.X2 = 0;
            this.Y2 = 0;
            this.CropWidth = 0;
            this.CropHeight = 0;
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
                            model.Width = preloader.width;
                            model.Height = preloader.height;
                            model.Path = preloader.getAsDataURL();

                            preloader.downsize(180, 180);//预览图片的最大宽高，自动等比。
                            model.SmallPath = preloader.getAsDataURL();

                            var imgObj = new mOxie.Image();
                            imgObj.onload = function () {
                                imgObj.downsize(400, 400);
                                model.BigPath = imgObj.getAsDataURL();
                                preloader.destroy();
                                preloader = null;
                            };
                            imgObj.load(file.getSource());

                            $("img#" + file.id).attr({ src: model.SmallPath });
                        }
                    });
                    lst.push(model);
                });
                $("#ItemsUL").append(template('fileItemTemp', { FileModelList: lst }));
                _this._fileModelList = XCLJsTool.Array.Concat(_this._fileModelList, lst);
            });
            //修改文件
            $("body").on("click", "a[rel='fileEdit']", function () {
                var id = $(this).attr("xcl-Id");
                var model = _this._getModelById(id);
                $("#divEditFile").html(template('divEditFileTemp', model));
                $("#divEditFile .easyui-linkbutton").linkbutton();
                //图片裁剪
                var getCropImgXYInfo = function (img) {
                    model.X1 = img.x;
                    model.X2 = img.x2;
                    model.Y1 = img.y;
                    model.Y2 = img.y2;
                    model.CropWidth = img.w;
                    model.CropHeight = img.h;
                    $("#divImgCropInfo").html("X1：" + model.X1 + "，Y1：" + model.Y1 + "，X2：" + model.X2 + "，Y2：" + model.Y2 + "。宽高：" + model.CropWidth + "*" + model.CropHeight);
                };
                $("img#ImgToEdit").Jcrop({
                    onSelect: getCropImgXYInfo,
                    onChange: getCropImgXYInfo,
                    onRelease: function () {
                        getCropImgXYInfo({x:0,y:0,x2:0,y2:0,w:0,h:0});
                    }
                });
                //查看原图
                $(document).off("click", "#btnShowSource").on("click", "#btnShowSource", function () {
                    $("#divShowImg").html(template('divShowImgTemp', { ImgSrc: model.Path })).find("form").submit();
                    return false;
                });
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