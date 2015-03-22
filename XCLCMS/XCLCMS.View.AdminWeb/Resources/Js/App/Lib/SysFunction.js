define(["Lib/XCLCMS"], function (lib) {
    var app = {};
    app.SysFunctionList = {
        Init: function () {
            var _this = this;
            $("#btnUpdate").on("click", function () {
                return _this.Update();
            });
            $("#btnDel").on("click", function () {
                return _this.Del();
            });
        },
        /**
         * 返回已选择的value数组
         */
        GetSelectValue: function () {
            var selectVal = $(".XCLTableCheckAll").val();
            var ids = selectVal.split(',');
            if (selectVal && selectVal !== "" && ids.length > 0) {
                return ids;
            } else {
                return null;
            }
        },
        /**
         * 打开功能信息【修改】页面
         */
        Update: function () {
            var $btn = $("#btnUpdate"), ids = this.GetSelectValue();
            if (ids && ids.length === 1) {

                var query = {
                    handletype: "update",
                    SysFunctionID: ids[0]
                }

                var url = XCLJsTool.URL.AddParam($btn.attr("href"), query);
                $btn.attr("href", url);
                return true;
            } else {
                art.dialog.tips("请选择一条记录进行修改操作！");
                return false;
            }
        },
        /**
         * 删除功能信息
         */
        Del: function () {
            var ids = this.GetSelectValue();
            if (!ids || ids.length == 0) {
                art.dialog.tips("请至少选择一条记录进行操作！");
                return false;
            }

            art.dialog.confirm("您确定要删除此信息吗？", function () {
                $.XCLGoAjax({
                    obj: $("#btnDel")[0],
                    url: lib.RootURL + "SysFunction/DelSubmit",
                    data: { SysFunctionIDs: ids.join(',') },
                    beforeSendMsg: "正在删除中，请稍后...",
                    isRefreshSelf: true
                });
            }, function () {
            })

            return false;
        }
    };
    app.SysFunctionAdd = {
        Init: function () {
            var _this = this;
            _this.InitValidator();

            $("#btnDel").on("click", function () {
                return _this.Del();
            });
        },
        /**
         * 表单验证初始化
         */
        InitValidator: function () {
            var validator = $("form:first").validate({
                rules: {
                    selFK_TypeID: { required: true },
                    txtFunctionName: {
                        required: true,
                        XCLCustomRemote: {
                            url: lib.RootURL + "SysFunctionCommon/IsExistSysFunctionName",
                            data: {
                                functionName: function () {
                                    return $("#txtFunctionName").val();
                                }
                            }
                        }
                    }
                }
            });
            lib.BindLinkButtonEvent("click", $("#btnSave"), function () {
                if (!lib.CommonFormValid(validator)) {
                    return false;
                }
                $.XCLGoAjax({ obj: $("#btnSave")[0] });
            });
        },
        /**
         * 删除配置
         */
        Del: function () {
            var id = $("#SysFunctionID").val();
            art.dialog.confirm("您确定要删除此信息吗？", function () {
                $.XCLGoAjax({
                    obj: $("#btnDel")[0],
                    url: lib.RootURL + "SysFunction/DelSubmit",
                    data: { SysFunctionIDs: id },
                    beforeSendMsg: "正在删除中，请稍后...",
                    isRefreshSelf: true
                });
            });
            return false;
        }
    };

    return app;
});