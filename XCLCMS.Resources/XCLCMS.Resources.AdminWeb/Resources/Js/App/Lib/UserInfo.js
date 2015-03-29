define(["Lib/XCLCMS"],function (lib) {
    /**
     * 用户管理
     * @type type
     */
    var app = {};

    /**
     * 用户信息列表
     * @type type
     */
    app.UserInfoList = {
        Init: function () {
            var _this = this;
            $("#btnUpdate").on("click", function () {
                return _this.Update();
            });
            $("#btnDel").on("click", function () {
                return _this.Del();
            })
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
         * 打开用户信息【修改】页面
         */
        Update: function () {
            var $btn = $("#btnUpdate"), ids = this.GetSelectValue();
            if (ids && ids.length === 1) {

                var query = {
                    handletype: "update",
                    UserInfoID: ids[0]
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
         * 删除用户信息
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
                    url: XCLCMSPageGlobalConfig.RootURL + "UserInfo/DelSubmit",
                    data: { UserInfoIds: ids.join(',') },
                    beforeSendMsg: "正在删除中，请稍后...",
                    isRefreshSelf: true
                });
            }, function () {
            });

            return false;
        }
    };

    /**
     * 用户信息添加与修改页
     */
    app.UserAdd = {
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
                    txtUserName: {
                        required: true,
                        XCLCustomRemote: {
                            url: XCLCMSPageGlobalConfig.RootURL + "UserInfoCommon/IsExistUserName",
                            data: {
                                UserName: function () {
                                    return $("#txtUserName").val();
                                }
                            }
                        },
                        AccountNO: true
                    },
                    txtEmail: "email",
                    txtPwd1: { equalTo: "#txtPwd" },
                    selUserState: { required: true },
                    selSexType: { required: true },
                    ckRoles: { required: true }
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
         * 删除用户
         */
        Del: function () {
            var id = $("#UserInfoID").val();
            art.dialog.confirm("您确定要删除此信息吗？", function () {
                $.XCLGoAjax({
                    obj: $("#btnDel")[0],
                    url: XCLCMSPageGlobalConfig.RootURL + "UserInfo/DelSubmit",
                    data: { UserInfoIds: id },
                    beforeSendMsg: "正在删除中，请稍后...",
                    isRefreshSelf: true
                });
            });
            return false;
        }
    }
    return app;
});