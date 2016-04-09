define(["kindeditorCN", "Lib/Common"], function (kindeditorCN, common) {
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
            btnRandomCount: null,//随机生成点赞数的按钮
            selArticleType: null,//文章分类
            selArticleContentType: null,//文章内容类型
            Init: function () {
                this.divContentNote = $("#divContentNote");
                this.btnRandomCount = $("#btnRandomCount");
                this.selArticleType = $("#selArticleType");
                this.selArticleContentType = $("#selArticleContentType");
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
            _this.InitValidator();

            //初始化编辑器
            var editor = null;
            KindEditor.ready(function (K) {
                editor = K.create('textarea[name="txtContents"]', {
                    allowFileManager: true,
                    afterChange: function () {
                        var textCount = this.count('text');
                        var data = { WordCount: textCount };
                        _this.Elements.divContentNote.html(template(_this.HTMLTemps.divContentNoteTemp, data));
                    },
                    afterBlur: function () { this.sync(); }
                });
            });

            //随机生成点赞数
            common.BindLinkButtonEvent("click", _this.Elements.btnRandomCount, function () {
                var r1 = XJ.Random.Range(100, 800), r2 = XJ.Random.Range(0, 100), r3 = XJ.Random.Range(0, 10);
                $("#txtGoodCount").numberbox('setValue', r1);
                $("#txtMiddleCount").numberbox('setValue', r2);
                $("#txtBadCount").numberbox('setValue', r3);
                $("#txtViewCount").numberbox('setValue', r1 + r2 + r3 + XJ.Random.Range(10, 100));
                $("#txtHotCount").numberbox('setValue', (r1 + r2 + r3) * XJ.Random.Range(1, 5));
            });

            //文章分类
            _this.Elements.selArticleType.combotree({
                url: XCLCMSPageGlobalConfig.RootURL + "SysDicCommon/GetEasyUITreeByCode?code=ArticleType",
                checkbox: true,
                onlyLeafCheck: true
            });
        },
        /**
         * 表单验证初始化
         */
        InitValidator: function () {
            var validator = $("form:first").validate({
                rules: {
                    txtCode: {
                        XCLCustomRemote: {
                            url: XCLCMSPageGlobalConfig.RootURL + "ArticleCommon/IsExistCode",
                            data: {
                                code: function () {
                                    return $("#txtCode").val();
                                }
                            }
                        },
                        AccountNO: true
                    },
                    txtTitle: { required: true }
                }
            });
            common.BindLinkButtonEvent("click", $("#btnSave"), function () {
                if (!common.CommonFormValid(validator)) {
                    return false;
                }
                $.XGoAjax({ target: $("#btnSave")[0] });
            });
        }
    };

    return app;
});