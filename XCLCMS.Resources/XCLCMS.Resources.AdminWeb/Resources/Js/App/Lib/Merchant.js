define(["Lib/Common"], function (common) {
    /**
     * 商户管理
     * @type type
     */
    var app = {};

    /**
     * 商户信息列表
     * @type type
     */
    app.MerchantList = {
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
         * 打开商户信息【修改】页面
         */
        Update: function () {
            var $btn = $("#btnUpdate"), ids = this.GetSelectValue();
            if (ids && ids.length === 1) {

                var query = {
                    handletype: "update",
                    MerchantID: ids[0]
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
         * 删除商户信息
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
                    url: XCLCMSPageGlobalConfig.RootURL + "Merchant/DelSubmit",
                    data: { MerchantIds: ids.join(',') },
                    beforeSendMsg: "正在删除中，请稍后...",
                    isRefreshSelf: true
                });
            }, function () {
            });

            return false;
        }
    };

    /**
     * 商户信息添加与修改页
     */
    app.MerchantAdd = {
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
                    txtMerchantName: {
                        required: true,
                        XCLCustomRemote: {
                            url: XCLCMSPageGlobalConfig.RootURL + "MerchantCommon/IsExistMerchantName",
                            data: {
                                MerchantName: function () {
                                    return $("#txtMerchantName").val();
                                }
                            }
                        },
                        AccountNO: true
                    },
                    txtEmail: "email",
                    selMerchantState: { required: true }
                }
            });
            common.BindLinkButtonEvent("click", $("#btnSave"), function () {
                if (!common.CommonFormValid(validator)) {
                    return false;
                }
                $.XCLGoAjax({ obj: $("#btnSave")[0] });
            });
        },
        /**
         * 删除商户
         */
        Del: function () {
            var id = $("#MerchantID").val();
            art.dialog.confirm("您确定要删除此信息吗？", function () {
                $.XCLGoAjax({
                    obj: $("#btnDel")[0],
                    url: XCLCMSPageGlobalConfig.RootURL + "Merchant/DelSubmit",
                    data: { MerchantIds: id },
                    beforeSendMsg: "正在删除中，请稍后...",
                    isRefreshSelf: true
                });
            });
            return false;
        }
    }
    return app;
});