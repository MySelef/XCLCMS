//文件上传
var app = {};

app.FileInfo = {};
app.FileInfo.List = {
    Init: function () {
        $.XCheck();
    }
};


app.LogicFile = {};
app.LogicFile.List = {
    Init: function () {
        $.XCheck();
    }
};
app.LogicFile.Update = {
    Init: function () {
        var _this = this;
        $("#btnSave").on("click", function () {
            _this.SaveSubmit();
            return false;
        });
    },
    SaveSubmit: function () {
        $.XGoAjax({
            isExclusive: true,
            id: "btnSave"
        });
    }
};
