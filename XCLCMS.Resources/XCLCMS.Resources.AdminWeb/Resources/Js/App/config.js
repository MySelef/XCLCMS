/**
*   requirejs配置
*   说明：使用requirejs只加载部分js模块，剩余插件不使用require加载
*/
var require = {
    baseUrl: XCLCMSPageGlobalConfig.ResourceURL + "Resources/Js/App/",
    urlArgs: "v=" + XCLCMSPageGlobalConfig.ResourceVersion,
    paths: {
        "kindeditor-all": XCLCMSPageGlobalConfig.ResourceURL + "Resources/Js/kindeditor/kindeditor-all-min",
        "kindeditorCN": XCLCMSPageGlobalConfig.ResourceURL + "Resources/Js/kindeditor/lang/zh-CN",
        
        "readmore": XCLCMSPageGlobalConfig.ResourceURL + "Resources/Js/readmore"
    },
    shim: {
        "kindeditorCN": ["kindeditor-all"]
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