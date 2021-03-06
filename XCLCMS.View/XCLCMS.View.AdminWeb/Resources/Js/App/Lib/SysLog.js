﻿define(["readmore"], function () {
    /*
    * 系统日志
    */
    var app = {};
    app.SysLogList = {
        Init: function () {
            var _this = this;
            $(".XCLCMSOverFlow").readmore({ collapsedHeight: 80 });
            $(".clearLogMenuItem").on("click", function () {
                _this.ClearLog($(this));
            });
        },
        ClearLog: function ($menuItem) {
            var data = $.parseJSON($menuItem.attr("xcl-data"));
            art.dialog.confirm("您确定要清空【" + data.txt + "】的所有日志信息吗？", function () {
                $.XGoAjax({
                    ajax: {
                        url: XCLCMSPageGlobalConfig.RootURL + "SysLog/ClearSubmit",
                        data: { dateType: data.val }, type: "POST"
                    }
                });
            });
        }
    };

    return app;
});