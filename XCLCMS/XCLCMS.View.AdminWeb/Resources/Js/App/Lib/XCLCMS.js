define(function () {

    var app = {
        /**
         * XCLNetTools消息所在json名
         * @type String
         */
        XCLJsonMessageName: "",
        /**
         * 枚举项
         */
        EnumConfig: "",
        /**
         * 网站根路径
         * @type String
         */
        RootURL: "",
        /**
         * 验证插件错误的class
         * @type String
         */
        XCLValidErrorClassName: "XCLValidError",
        /**
         * 页面初始化时加载
         * @returns {undefined}
         */
        Init: function () {
            var mainThis = this;

            //溢出隐藏
            //$(".XCLTextEllipsis").textEllipsis();

            $.XCLTableList();

            //缓存清理
            $("a[xcl-sysdiccode='ClearCache']").on("click", function () {
                lib.Common.ClearCache();
                return false;
            });
            //垃圾数据清理
            $("a[xcl-sysdiccode='ClearRubbishData']").on("click", function () {
                lib.Common.ClearRubbishData();
                return false;
            });
            //退出
            $("#btnLoginOut").on("click", function () {
                lib.Common.LogOut();
                return false;
            });
        },
        /**
         * 公共验证方法
         * @param {type} validator
         * @returns {unresolved}
         */
        CommonFormValid: function (validator) {
            var result = validator.form();
            if (!result) {
                $("." + lib.XCLValidErrorClassName).filter(":visible:first").focus();
            }
            return result;
        },
        /**
         * 给linkbutton绑定事件（仅在LinkButton可用时执行事件）
         * @param {type} eventName
         * @param {type} $btn
         * @param {type} callback
         * @returns {undefined}
         */
        BindLinkButtonEvent: function (eventName, $btn, callback) {
            eventName = eventName || "click";
            $btn = $btn || $("#btnSave");
            $btn.on(eventName, function () {
                if (!($btn.linkbutton("options").disabled)) {
                    callback();
                }
                return false;
            });
        }
    };

    return app;
});