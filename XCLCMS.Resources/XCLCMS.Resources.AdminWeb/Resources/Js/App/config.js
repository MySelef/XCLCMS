/**
*   requirejs配置
*   说明：使用requirejs只加载本项目的js模块，其它插件等不使用require加载
*/
var require = $.extend({}, window.require || {}, {
    //其它配置
    baseUrl: XCLCMSPageGlobalConfig.ResourceURL + "Resources/Js/App/"
});



//其它配置
$(function () {
    //art dialog config
    (function (config) {
        config.lock = true;
        config.opacity = 0.2;
        config.resize = true;
    })(art.dialog.defaults);
});