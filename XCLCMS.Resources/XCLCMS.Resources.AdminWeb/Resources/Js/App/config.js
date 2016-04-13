/**
*   requirejs配置
*   说明：使用requirejs只加载部分js模块，剩余插件不使用require加载
*/
var require = {
    baseUrl: XCLCMSPageGlobalConfig.ResourceURL + "Resources/Js/App/",
    urlArgs: "v=" + XCLCMSPageGlobalConfig.ResourceVersion,
    paths: {
        "ckeditor": XCLCMSPageGlobalConfig.ResourceURL + "Resources/Js/ckeditor/ckeditor",
        "ckeditorCN": XCLCMSPageGlobalConfig.ResourceURL + "Resources/Js/ckeditor/lang/zh-cn",
        
        "readmore": XCLCMSPageGlobalConfig.ResourceURL + "Resources/Js/readmore"
    },
    shim: {
        "ckeditorCN": ["ckeditor"]
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

    $.XGoAjax.globalSettings({
        templateName: "artdialog",
        isExclusive: false
    });
});