define(["Lib/Common", "Lib/EasyUI"], function (common, easyUI) {
    /**
      * 系统字典库
      */
    var app = {};
    app.SysDicList = {

        /**
         * 界面元素
         */
        Elements: {
            //tree右键菜单
            menu_SysDic: null,
            //tree右键菜单_刷新节点
            menu_SysDic_refresh: null,
            //tree右键菜单_添加节点
            menu_SysDic_add: null,
            //tree右键菜单_修改节点
            menu_SysDic_edit: null,
            //tree右键菜单_删除节点
            menu_SysDic_del: null,
            //tree右键菜单_清空子节点
            menu_SysDic_delSub: null,
            //tree右键菜单_分配功能权限
            menu_SysDicSetFunction:null,
            Init: function () {
                this.menu_SysDic = $("#menu_SysDic");
                this.menu_SysDic_refresh = $("#menu_SysDic_refresh");
                this.menu_SysDic_add = $("#menu_SysDic_add");
                this.menu_SysDic_edit = $("#menu_SysDic_edit");
                this.menu_SysDic_del = $("#menu_SysDic_del");
                this.menu_SysDic_delSub = $("#menu_SysDic_delSub");
                this.menu_SysDicSetFunction = $("#menu_SysDicSetFunction");
            }
        },

        /**
         * 数据列表jq对象
         */
        TreeObj: null,
        /**
         * 页面初始化
         */
        Init: function () {
            var _this = this;
            _this.Elements.Init();

            _this.TreeObj = $('#tableSysDicList');
            //加载列表树
            _this.TreeObj.treegrid({
                url: XCLCMSPageGlobalConfig.RootURL + 'SysDic/GetList',
                method: 'get',
                idField: 'SysDicID',
                treeField: 'DicName',
                rownumbers: true,
                loadFilter: function (data) {
                    if (data) {
                        for (var i = 0; i < data.length; i++) {
                            data[i].state = (data[i].IsLeaf === 1) ? "" : "closed";
                        }
                    }
                    return data;
                },
                columns: [[
                    { field: 'SysDicID', title: 'ID',width:'5%' },
                    { field: 'ParentID', title: '父ID', width: '5%' },
                    { field: 'NodeLevel', title: '层级', width: '2%' },
                    { field: 'DicName', title: '字典名', width: '25%' },
                    { field: 'DicValue', title: '字典值', width: '5%' },
                    { field: 'Weight', title: '权重', width: '2%' },
                    { field: 'Code', title: '唯一标识', width: '10%' },
                    { field: 'DicType', title: '字典类型', formatter: easyUI.EnumToDescription, width: '5%' },
                    { field: 'Sort', title: '排序号', width: '5%' },
                    { field: 'FK_FunctionID', title: '所属功能ID', width: '5%' },
                    { field: 'RecordState', title: '记录状态', formatter: easyUI.EnumToDescription, width: '5%' },
                    { field: 'Remark', title: '备注', width: '5%' },
                    { field: 'CreateTime', title: '创建时间', width: '5%' },
                    { field: 'CreaterName', title: '创建者名', width: '5%' },
                    { field: 'UpdateTime', title: '更新时间', width: '5%' },
                    { field: 'UpdaterName', title: '更新者名', width: '5%' }
                ]],
                onContextMenu: function (e, row) {
                    e.preventDefault();
                    _this.Elements.menu_SysDic_del.show();
                    _this.Elements.menu_SysDic_edit.show();
                    _this.Elements.menu_SysDic_delSub.show();

                    if (row.ParentID == 0) {
                        //根节点隐藏部分菜单 
                        _this.Elements.menu_SysDic_del.hide();
                        _this.Elements.menu_SysDic_edit.hide();
                    }
                    if (row.IsLeaf == 1) {
                        //叶子节点隐藏部分菜单
                        _this.Elements.menu_SysDic_delSub.hide();
                    }
                    if (row.DicType == 'S') {
                        //系统级字典库隐藏部分菜单
                        _this.Elements.menu_SysDic_del.hide();
                    }

                    $(this).treegrid('select', row.SysDicID);
                    _this.Elements.menu_SysDic.menu('show', {
                        left: e.pageX,
                        top: e.pageY
                    });
                }
            });

            //刷新节点
            _this.Elements.menu_SysDic_refresh.on("click", function () {
                var ids = _this.GetSelectedIds();
                _this.TreeObj.treegrid("reload", ids[0]);
            });
            //添加子项
            _this.Elements.menu_SysDic_add.on("click", function () {
                _this.Add();
            });
            //修改
            _this.Elements.menu_SysDic_edit.on("click", function () {
                _this.Update();
            });
            //删除
            _this.Elements.menu_SysDic_del.on("click", function () {
                _this.Del();
            });
            //清空子节点
            _this.Elements.menu_SysDic_delSub.on("click", function () {
                _this.Clear();
            });
            //分配功能权限
            _this.Elements.menu_SysDicSetFunction.on("click", function () {
                _this.SetFunction();
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
            art.dialog.open(XCLCMSPageGlobalConfig.RootURL + 'SysDic/Add?sysDicId=' + ids[0], {
                title: '添加子节点', width: 1100, height: 600, close: function () {
                    //叶子节点，刷新其父节点，非叶子节点刷新自己即可
                    var row = _this.TreeObj.treegrid("find", ids[0]);
                    _this.TreeObj.treegrid("reload", row.IsLeaf == 1 ? row.ParentID : row.SysDicID);
                }
            });
        },
        /**
         * 打开【修改】页面
         */
        Update: function () {
            var _this = this;
            var ids = _this.GetSelectedIds();
            art.dialog.open(XCLCMSPageGlobalConfig.RootURL + 'SysDic/Add?handletype=update&sysDicId=' + ids[0], {
                title: '修改节点', width: 1100, height: 600, close: function () {
                    var parent = _this.TreeObj.treegrid("getParent", ids[0]);
                    if (parent) {
                        _this.TreeObj.treegrid("reload", parent.SysDicID);
                    } else {
                        _this.Refresh();
                    }
                }
            });
        },
        /**
         * 删除
         */
        Del: function () {
            var _this = this;
            var ids = _this.GetSelectedIds();
            art.dialog.confirm("您确定要删除此信息吗？", function () {
                $.XCLGoAjax({
                    url: XCLCMSPageGlobalConfig.RootURL + "SysDic/DelSubmit",
                    data: { SysDicIds: ids.join(',') },
                    beforeSendMsg: "正在删除中，请稍后...",
                    afterSuccessFunction: function () {
                        $.each(ids, function (idx, n) {
                            _this.TreeObj.treegrid("remove", n);
                        });
                    }
                });
            }, function () { });
        },
        /**
         * 清空子节点
         */
        Clear: function () {
            var _this = this;
            var ids = _this.GetSelectedIds();
            art.dialog.confirm("您确定要清空此节点的所有子节点吗？", function () {
                $.XCLGoAjax({
                    url: XCLCMSPageGlobalConfig.RootURL + "SysDic/DelChildSubmit",
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
        },
        /**
         * 刷新列表
         */
        Refresh: function () {
            this.TreeObj.treegrid("reload");
        },
        /**
        * 分配功能权限
        */
        SetFunction: function () {
                
        }
    };





    app.SysDicAdd = {

        /**
        * 输入元素
        */
        Elements: {
            //字典所属功能输入框对象
            txtFunctionID: null,
            //字典所属功能输入框对象
            txtRoleFunction: null,
            Init: function () {
                this.txtFunctionID = $("#txtFunctionID");
                this.txtRoleFunction = $("#txtRoleFunction");
            }
        },
        /**
        * 界面初始化
        */
        Init: function () {
            var _this = this;
            _this.Elements.Init();
            _this.InitValidator();

            _this.CreateFunctionTree(_this.Elements.txtFunctionID);
            _this.CreateFunctionTree(_this.Elements.txtRoleFunction);
        },
        /**
        * 创建功能模块的combotree
        */
        CreateFunctionTree: function ($obj) {
            if (!$obj) {
                return;
            }
            $obj.combotree({
                url: XCLCMSPageGlobalConfig.RootURL + 'SysFunctionCommon/GetAllJsonForEasyUITree',
                method: 'get',
                checkbox: true,
                lines:true
            });
        },
        InitValidator: function () {
            var validator = $("form:first").validate({
                rules: {
                    txtDicName: {
                        required: true,
                        XCLCustomRemote: {
                            url: XCLCMSPageGlobalConfig.RootURL + "SysDicCommon/IsExistSysDicNameInSameLevel",
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
                        XCLCustomRemote: {
                            url: XCLCMSPageGlobalConfig.RootURL + "SysDicCommon/IsExistSysDicCode",
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
            common.BindLinkButtonEvent("click", $("#btnSave"), function () {
                if (!common.CommonFormValid(validator)) {
                    return false;
                }
                $.XCLGoAjax({ obj: $("#btnSave")[0] });
            });
        }
    };

    return app;
});