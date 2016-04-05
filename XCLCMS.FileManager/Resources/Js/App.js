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
        var _this = this;
        $.XCheck();
        $("#btnBatchDel").on("click", function () {
            _this.DelSubmit($(":checkbox.xcheckValue").val());
            return false;
        });
    },
    DelSubmit: function (ids) {
        if (!ids) {
            art.dialog.tips("请指定要删除的记录！");
            return false;
        }

        art.dialog.confirm("您确定要删除此信息吗？", function () {
            $.XGoAjax({
                ajax: [{
                    data: { attachmentIDs: ids },
                    url: AppConfig.RootUrl + "LogicFile/DelSubmit",
                    type: "POST"
                }]
            });
        }, function () {
        });
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