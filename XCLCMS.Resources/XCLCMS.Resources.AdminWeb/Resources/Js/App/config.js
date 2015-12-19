/**
*   requirejs配置
*   说明：使用requirejs只加载部分js模块，剩余插件不使用require加载
*/
var require = {
    baseUrl: XCLCMSPageGlobalConfig.ResourceURL + "Resources/Js/App/",
    urlArgs: "v=" + XCLCMSPageGlobalConfig.ResourceVersion,
    paths: {
        "kindeditor-all": XCLCMSPageGlobalConfig.ResourceURL + "Resources/Js/kindeditor/kindeditor-all",
        "kindeditorCN": XCLCMSPageGlobalConfig.ResourceURL + "Resources/Js/kindeditor/lang/zh_CN",

        "moxie": XCLCMSPageGlobalConfig.ResourceURL + "Resources/Js/plupload/moxie.min",
        "jquery.plupload.queue": XCLCMSPageGlobalConfig.ResourceURL + "Resources/Js/plupload/jquery.plupload.queue/jquery.plupload.queue",
        "plupload": XCLCMSPageGlobalConfig.ResourceURL + "Resources/Js/plupload/plupload.full.min",
        "pluploadCN": XCLCMSPageGlobalConfig.ResourceURL + "Resources/Js/plupload/i18n/zh_CN",

        "jquery.color": XCLCMSPageGlobalConfig.ResourceURL + "Resources/Js/jquery/jquery.color",
        "jquery.jcrop": XCLCMSPageGlobalConfig.ResourceURL + "Resources/Js/Jcrop/js/jquery.jcrop",

        "readmore": XCLCMSPageGlobalConfig.ResourceURL + "Resources/Js/readmore"
    },
    shim: {
        "kindeditorCN": ["kindeditor-all"],

        "plupload": ["moxie"],
        "jquery.plupload.queue": ["plupload"],
        "pluploadCN": ["moxie", "jquery.plupload.queue", "plupload", "jquery.color", "jquery.jcrop"]
    }
};

//其它配置
$(function () {
    //art dialog config
    (function (config) {
        config.lock = true;
        config.opacity = 0.2;
        config.resize = true;
    })(art.dialog.defaults);
});