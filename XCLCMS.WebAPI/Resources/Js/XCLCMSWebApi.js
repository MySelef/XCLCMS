; (function () {
    var _request = function () {
        this.UserToken = null;
        this.Body = null;
    };

    if (!XCLCMSPageGlobalConfig) {
        throw new Error("请指定全局配置UserToken！");
    }

    var lib = {};

    lib.CreateRequest = function () {
        var req = new _request();
        req.UserToken = XCLCMSPageGlobalConfig.UserToken;
        req.AppID = XCLCMSPageGlobalConfig.AppID;
        req.AppKey = XCLCMSPageGlobalConfig.AppKey;
        return req;
    };

    window.XCLCMSWebApi = lib;
})();