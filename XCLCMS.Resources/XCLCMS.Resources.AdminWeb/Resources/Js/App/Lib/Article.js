define(function () {
    /**
    * 文章
    */
    var app = {};
    app.ArticleList = {
        Init: function () {

        }
    };

    app.ArticleAdd = {
        /**
        * 元素
        */
        Elements: {
            divContentNote: null,//内容字数统计
            Init: function () {
                this.divContentNote = $("#divContentNote");
            }
        },
        /**
        *  模板
        */
        HTMLTemps: {
            divContentNoteTemp: "divContentNoteTemp"
        },
        Init: function () {
            var _this = this;
            _this.Elements.Init();

            //初始化主图上传
            $("#btnMainImage1").on("click", function () {
                _this.UploadMainImage();
            });

            //初始化编辑器
            var editor = null;
            KindEditor.ready(function (K) {
                editor = K.create('textarea[name="txtContents"]', {
                    allowFileManager: true,
                    afterChange: function () {
                        var textCount = this.count('text');
                        var data = { WordCount: textCount };
                        _this.Elements.divContentNote.html(template(_this.HTMLTemps.divContentNoteTemp, data));
                    }
                });
            });
        },
        UploadMainImage: function () {
            art.dialog.open(XCLCMSPageGlobalConfig.RootURL + 'Upload/Index', { title: '文件上传', width: 1100, height: 650 });
        }
    };

    return app;
});