define(["Lib/XCLCMS"], function (lib) {
    /**
      * 系统字典库
      */
    var app = {};
    app.SysDicList = {
        /**
         * 数据列表jq对象
         */
        TreeObj: null,
        /**
         * 页面初始化
         */
        Init: function () {
            var _this = this;
            _this.TreeObj = $('#tableSysDicList');
            //加载列表树
            _this.TreeObj.treegrid({
                url: lib.RootURL + 'SysDic/GetList',
                method: 'get',
                idField: 'SysDicID',
                treeField: 'DicName',
                loadFilter: function (data) {
                    if (data) {
                        for (var i = 0; i < data.length; i++) {
                            data[i].state = (data[i].IsLeaf === 1) ? "" : "closed";
                        }
                    }
                    return data;
                }
            });
            //按钮事件绑定
            $("#btnAdd").on("click", function () {
                return _this.Add();
            });
            $("#btnUpdate").on("click", function () {
                return _this.Update();
            });
            $("#btnDel").on("click", function () {
                return _this.Del();
            });
            $("#btnRefresh").on("click", function () {
                return _this.Refresh();
            });
            $("#btnClearChild").on("click", function () {
                return _this.Clear();
            });
        },
        /**
         * 获取已选择的行对象数组
         */
        GetSelectRows: function () {
            return this.TreeObj.treegrid("getSelections");
        },
        /**
         * 获取已选择的行id数组
         */
        GetSelectedIds: function () {
            var ids = [];
            var rows = this.GetSelectRows();
            if (rows && rows.length > 0) {
                for (var i = 0; i < rows.length; i++) {
                    ids.push(rows[i].SysDicID);
                }
            }
            return ids;
        },
        /**
         * 打开【添加】页面
         */
        Add: function () {
            var _this = this;
            var ids = _this.GetSelectedIds();
            if (ids && ids.length === 1) {
                art.dialog.open(lib.RootURL + 'SysDic/Add?sysDicId=' + ids[0], {
                    title: '添加子节点', width: 1100, height: 600, close: function () {
                        //叶子节点，刷新其父节点，非叶子节点刷新自己即可
                        var row = _this.TreeObj.treegrid("find", ids[0]);
                        _this.TreeObj.treegrid("reload", row.IsLeaf == 1 ? row.ParentID : row.SysDicID);
                    }
                });
                return true;
            } else {
                art.dialog.tips("请选择一条记录进行添加子节点的操作！");
                return false;
            }
        },
        /**
         * 打开【修改】页面
         */
        Update: function () {
            var _this = this;
            var ids = this.GetSelectedIds();
            if (ids && ids.length === 1) {
                art.dialog.open(lib.RootURL + 'SysDic/Add?handletype=update&sysDicId=' + ids[0], {
                    title: '修改节点', width: 1100, height: 600, close: function () {
                        var parent = _this.TreeObj.treegrid("getParent", ids[0]);
                        if (parent) {
                            _this.TreeObj.treegrid("reload", parent.SysDicID);
                        } else {
                            _this.Refresh();
                        }
                    }
                });
                return true;
            } else {
                art.dialog.tips("请选择一条记录进行修改操作！");
                return false;
            }
        },
        /**
         * 删除
         */
        Del: function () {
            var _this = this;
            var ids = _this.GetSelectedIds();
            if (!ids || ids.length === 0) {
                art.dialog.tips("请至少选择一条记录进行操作！");
                return false;
            };

            art.dialog.confirm("您确定要删除此节点吗？", function () {
                $.XCLGoAjax({
                    obj: $("#btnDel")[0],
                    url: lib.RootURL + "SysDic/DelSubmit",
                    data: { SysDicIds: ids.join(',') },
                    beforeSendMsg: "正在删除中，请稍后...",
                    afterSuccessFunction: function () {
                        $.each(ids, function (idx, n) {
                            _this.TreeObj.treegrid("remove", n);
                        });
                    }
                });
            }, function () {
            });
            return false;
        },
        /**
         * 清空子节点
         */
        Clear: function () {
            var _this = this;
            var ids = _this.GetSelectedIds();
            if (!ids || ids.length !== 1) {
                art.dialog.tips("请选择一条记录进行操作！");
                return false;
            };

            art.dialog.confirm("您确定要清空此节点的所有子节点吗？", function () {
                $.XCLGoAjax({
                    obj: $("#btnClearChild")[0],
                    url: lib.RootURL + "SysDic/DelChildSubmit",
                    data: { sysDicID: ids[0] },
                    beforeSendMsg: "正在清空中，请稍后...",
                    afterSuccessFunction: function () {
                        var parent = _this.TreeObj.treegrid("getParent", ids[0]);
                        if (parent) {
                            _this.TreeObj.treegrid("reload", parent.SysDicID);
                        } else {
                            _this.Refresh();
                        }
                    }
                });
            }, function () {
            });
            return false;
        },
        /**
         * 刷新列表
         */
        Refresh: function () {
            this.TreeObj.treegrid("reload");
        }
    };

    app.SysDicAdd = {
        Init: function () {
            var _this = this;
            _this.InitValidator();

            $("#btnCreateAutoCode").on("click", function () {
                $("#txtCode").val(lib.Common.CreateAutoCode());
            });
        },
        InitValidator: function () {
            var validator = $("form:first").validate({
                rules: {
                    txtDicName: {
                        required: true,
                        XCLCustomRemote: {
                            url: lib.RootURL + "SysDicCommon/IsExistSysDicNameInSameLevel",
                            data: {
                                sysDicName: function () {
                                    return $("#txtDicName").val();
                                },
                                parentID: function () {
                                    return $("#ParentID").val();
                                },
                                SysDicID: function () {
                                    return $("#SysDicID").val();
                                }
                            }
                        }
                    },
                    txtCode: {
                        required: true,
                        XCLCustomRemote: {
                            url: lib.RootURL + "SysDicCommon/IsExistSysDicCode",
                            data: {
                                code: function () {
                                    return $("#txtCode").val();
                                },
                                SysDicID: function () {
                                    return $("#SysDicID").val();
                                }
                            }
                        }
                    },
                    selDicType: {
                        required: true
                    }
                }
            });
            lib.BindLinkButtonEvent("click", $("#btnSave"), function () {
                if (!lib.CommonFormValid(validator)) {
                    return false;
                }
                $.XCLGoAjax({ obj: $("#btnSave")[0] });
            });
        }
    };

    return app;
});