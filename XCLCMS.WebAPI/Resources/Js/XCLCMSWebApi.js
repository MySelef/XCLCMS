; (function () {
    var _request = function () {
        this.UserToken = null;
        this.ClientIP = null;
        this.Url = null;
        this.Body = null;
    };

    var lib = {};

    lib.UserToken = null;

    lib.Init = function () {
        $.ajaxSetup({
            headers: { "XCLCMSWebAPIHeader": lib.UserToken }
        });
    };

    lib.CreateRequest = function () {
        var req = new _request();
        req.UserToken = lib.UserToken;
        return req;
    };

    window.XCLCMSWebApi = lib;
})();