; (function (window,$,undefined) {

    var lib = {};

    lib.Home = {};
    lib.Home.Init = function () {
        $.XGoAjax({
            id:"getFileList",
            ajax: { url: AppConfig.RootUrl + "Home/GetFileList" }
        });
    };




    window.App = lib;

})(window,jQuery);