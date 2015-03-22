
require.config({
    baseUrl: "http://localhost:3781/Resources/Js/App/"
});


//require(["Lib/XCLCMS", "Lib/Article", "Lib/Common", "Lib/EasyUI", "Lib/Home", "Lib/SysDic", "Lib/SysFunction", "Lib/SysLog", "Lib/SysWebSetting", "Lib/Uploader", "Lib/UserInfo"],
//function (lib, article, common, easyUI, home, sysDic, sysFunction, sysLog, sysWebSetting, uploader, userInfo) {
//    var app = lib;
//    app.Article = article;
//    app.Common = common;
//    app.EasyUI = easyUI;
//    app.Home = home;
//    app.SysDic = sysDic;
//    app.SysFunction = sysFunction;
//    app.SysLog = sysLog;
//    app.SysWebSetting = sysWebSetting;
//    app.Uploader = uploader;
//    app.UserInfo = userInfo;
    
//    $(function () {
//        app.Init();
//    });

//    window.XCLCMS = app;
//    return app;
//});


require(["Lib/XCLCMS"], function (lib) {
    $(function () {
        lib.Init();
    });
});