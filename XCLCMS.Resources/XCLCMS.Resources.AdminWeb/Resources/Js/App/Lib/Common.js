define(["Lib/XCLCMS"], function (lib) {
    var app = {
        /**
         * 枚举值字母转换为Description
         */
        EnumConvert: function (name, val) {
            var result = "";
            name = name + "Enum";
            if (XCLCMSPageGlobalConfig.EnumConfig) {
                var valJson = XCLCMSPageGlobalConfig.EnumConfig[name];
                if (valJson) {
                    result = valJson[val] || "";
                }
            }
            return result;
        },
        /**
         * 自动生成code
         */
        CreateAutoCode: function () {
            var data = XCLJsTool.Ajax.GetSyncData({
                url: XCLCMSPageGlobalConfig.RootURL + "Common/CreateAutoCode",
                type: "JSON",
                data: { v: Math.random() }
            });
            return data ? data.Message : "";
        },
        /**
        * 缓存清理
        */
        ClearCache: function () {
            $.XCLGoAjax({
                obj: $("a[xcl-sysdiccode='ClearCache']")[0],
                url: XCLCMSPageGlobalConfig.RootURL + "Common/ClearCache",
                data: { v: Math.random() },
                beforeSendMsg: "正在清理缓存中，请稍后...",
                isRefreshSelf: true
            });
        },
        /**
        * 退出系统
        */
        LogOut: function () {
            art.dialog.tips("正在安全退出中，请稍后......", 999999999);
            $.getJSON(XCLCMSPageGlobalConfig.RootURL + "Login/LogOut", { v: Math.random() }, function (data) {
                if (data.IsSuccess) {
                    top.location.reload(true);
                } else {
                    art.dialog.tips("退出失败，请重试！");
                }
            });
        },
        /**
        * 垃圾数据清理
        */
        ClearRubbishData: function () {
            $.XCLGoAjax({
                obj: $("a[xcl-sysdiccode='ClearRubbishData']")[0],
                url: XCLCMSPageGlobalConfig.RootURL + "Common/ClearRubbishData",
                data: { v: Math.random() },
                beforeSendMsg: "正在清理垃圾数据，请稍后..."
            });
        }
    };
    return app;
});