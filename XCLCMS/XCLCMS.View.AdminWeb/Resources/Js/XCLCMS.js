;(function(window) {

    if (window.XCLCMS) {
        return window.XCLCMS;
    }

    var lib = {
        /**
         * XCLNetTools消息所在json名
         * @type String
         */
        XCLJsonMessageName: "",
        /**
         * 枚举项
         */
        EnumConfig: "",
        /**
         * 网站根路径
         * @type String
         */
        RootURL: "",
        /**
         * 验证插件错误的class
         * @type String
         */
        XCLValidErrorClassName: "XCLValidError",
        /**
         * 页面初始化时加载
         * @returns {undefined}
         */
        Init: function() {
            var mainThis = this;

            //溢出隐藏
            //$(".XCLTextEllipsis").textEllipsis();

            $.XCLTableList();

            //缓存清理
            $("a[xcl-sysdiccode='ClearCache']").on("click", function () {
                lib.Common.ClearCache();
                return false;
            });
            //垃圾数据清理
            $("a[xcl-sysdiccode='ClearRubbishData']").on("click", function () {
                lib.Common.ClearRubbishData();
                return false;
            });
            //退出
            $("#btnLoginOut").on("click", function () {
                lib.Common.LogOut();
                return false;
            });
        },
        /**
         * 公共验证方法
         * @param {type} validator
         * @returns {unresolved}
         */
        CommonFormValid: function(validator) {
            var result = validator.form();
            if (!result) {
                $("." + lib.XCLValidErrorClassName).filter(":visible:first").focus();
            }
            return result;
        },
        /**
         * 给linkbutton绑定事件（仅在LinkButton可用时执行事件）
         * @param {type} eventName
         * @param {type} $btn
         * @param {type} callback
         * @returns {undefined}
         */
        BindLinkButtonEvent: function(eventName, $btn, callback) {
            eventName = eventName || "click";
            $btn = $btn || $("#btnSave");
            $btn.on(eventName, function() {
                if (!($btn.linkbutton("options").disabled)) {
                    callback();
                }
                return false;
            });
        }
    };
    
    $(function() {
        lib.Init();
    });


    /**
     * 公共方法
     */
    lib.Common = {
        /**
         * 枚举值字母转换为Description
         */
        EnumConvert: function(name, val) {
            var result = "";
            name = name + "Enum";
            if (lib.EnumConfig) {
                var valJson = lib.EnumConfig[name];
                if (valJson) {
                    result = valJson[val] || "";
                }
            }
            return result;
        },
        /**
         * 自动生成code
         */
        CreateAutoCode: function() {
            var data = XCLJsTool.Ajax.GetSyncData({
                url: lib.RootURL + "Common/CreateAutoCode",
                type: "JSON",
                data: {v: Math.random()}
            });
            return data ? data.Message : "";
        },
        /**
        * 缓存清理
        */
        ClearCache: function () {
            $.XCLGoAjax({
                obj: $("a[xcl-sysdiccode='ClearCache']")[0],
                url: lib.RootURL + "Common/ClearCache",
                data: { v:Math.random()},
                beforeSendMsg: "正在清理缓存中，请稍后...",
                isRefreshSelf: true
            });
        },
        /**
        * 退出系统
        */
        LogOut: function () {
            art.dialog.tips("正在安全退出中，请稍后......", 999999999);
            $.getJSON(lib.RootURL + "Login/LogOut", { v: Math.random() }, function (data) {
                if (data.IsSuccess) {
                    top.location.reload(true);
                } else {
                    art.dialog.tips("退出失败，请重试！");
                }
            });
        },
        /**
        * 垃圾数据清理
        */
        ClearRubbishData: function () {
            $.XCLGoAjax({
                obj: $("a[xcl-sysdiccode='ClearRubbishData']")[0],
                url: lib.RootURL + "Common/ClearRubbishData",
                data: { v: Math.random() },
                beforeSendMsg: "正在清理垃圾数据，请稍后..."
            });
        }
    };

    /**
     * Easyui相关
     */
    lib.EasyUI = {
        /**
         * 绑定数据时，将枚举转为描述信息
         */
        EnumToDescription: function(value, row, index) {
            return lib.Common.EnumConvert(this.field, value);
        }
    };

    /**
     * 首页
     * @type type
     */
    lib.Home = {
        /**
         * 页面加载时执行
         * @returns {undefined}
         */
        Init: function() {

        }
    };

    /***********************************************************************************************/

    /**
     * 用户管理
     * @type type
     */
    lib.UserInfo = {};

    /**
     * 用户信息列表
     * @type type
     */
    lib.UserInfo.UserInfoList = {
        Init: function() {
            var _this = this;
            $("#btnUpdate").on("click", function() {
                return _this.Update();
            });
            $("#btnDel").on("click", function() {
                return _this.Del();
            })
        },
        /**
         * 返回已选择的value数组
         */
        GetSelectValue: function() {
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
        Update: function() {
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
        Del: function() {
            var ids = this.GetSelectValue();
            if (!ids || ids.length == 0) {
                art.dialog.tips("请至少选择一条记录进行操作！");
                return false;
            }

            art.dialog.confirm("您确定要删除此信息吗？", function () {
                $.XCLGoAjax({
                    obj: $("#btnDel")[0],
                    url: lib.RootURL + "UserInfo/DelSubmit",
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
    lib.UserInfo.UserAdd = {
        Init: function() {
            var _this = this;
            _this.InitValidator();

            $("#btnDel").on("click", function() {
                return _this.Del();
            });
        },
        /**
         * 表单验证初始化
         */
        InitValidator: function() {
            var validator = $("form:first").validate({
                rules: {
                    txtUserName: {
                        required: true,
                        XCLCustomRemote: {
                            url: lib.RootURL + "UserInfoCommon/IsExistUserName",
                            data: {UserName: function() {
                                    return $("#txtUserName").val();
                                }}
                        },
                        AccountNO: true
                    },
                    txtEmail: "email",
                    txtPwd1: {equalTo: "#txtPwd"},
                    selUserState: {required: true},
                    selSexType: { required: true },
                    ckRoles: {required:true}
                }
            });
            lib.BindLinkButtonEvent("click", $("#btnSave"), function() {
                if (!lib.CommonFormValid(validator)) {
                    return false;
                }
                $.XCLGoAjax({obj: $("#btnSave")[0]});
            });
        },
        /**
         * 删除用户
         */
        Del: function() {
            var id = $("#UserInfoID").val();
            art.dialog.confirm("您确定要删除此信息吗？", function() {
                $.XCLGoAjax({
                    obj: $("#btnDel")[0],
                    url: lib.RootURL + "UserInfo/DelSubmit",
                    data: {UserInfoIds: id},
                    beforeSendMsg: "正在删除中，请稍后...",
                    isRefreshSelf: true
                });
            });
            return false;
        }
    }

    /***********************************************************************************************/

    /**
     * 系统字典库
     */
    lib.SysDic = {};
    lib.SysDic.SysDicList = {
        /**
         * 数据列表jq对象
         */
        TreeObj: null,
        /**
         * 页面初始化
         */
        Init: function() {
            var _this = this;
            _this.TreeObj = $('#tableSysDicList');
            //加载列表树
            _this.TreeObj.treegrid({
                url: lib.RootURL + 'SysDic/GetList',
                method: 'get',
                idField: 'SysDicID',
                treeField: 'DicName',
                loadFilter: function(data) {
                    if (data) {
                        for (var i = 0; i < data.length; i++) {
                            data[i].state = (data[i].IsLeaf === 1) ? "" : "closed";
                        }
                    }
                    return data;
                }
            });
            //按钮事件绑定
            $("#btnAdd").on("click", function() {
                return _this.Add();
            });
            $("#btnUpdate").on("click", function() {
                return _this.Update();
            });
            $("#btnDel").on("click", function() {
                return _this.Del();
            });
            $("#btnRefresh").on("click", function() {
                return _this.Refresh();
            });
            $("#btnClearChild").on("click", function() {
                return _this.Clear();
            });
        },
        /**
         * 获取已选择的行对象数组
         */
        GetSelectRows: function() {
            return this.TreeObj.treegrid("getSelections");
        },
        /**
         * 获取已选择的行id数组
         */
        GetSelectedIds: function() {
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
        Add: function() {
            var _this = this;
            var ids = _this.GetSelectedIds();
            if (ids && ids.length === 1) {
                art.dialog.open(lib.RootURL + 'SysDic/Add?sysDicId=' + ids[0], {
                    title: '添加子节点', width: 1100, height: 600, close: function () {
                        //叶子节点，刷新其父节点，非叶子节点刷新自己即可
                        var row = _this.TreeObj.treegrid("find", ids[0]);
                        _this.TreeObj.treegrid("reload",row.IsLeaf == 1 ? row.ParentID : row.SysDicID);
                    }});
                return true;
            } else {
                art.dialog.tips("请选择一条记录进行添加子节点的操作！");
                return false;
            }
        },
        /**
         * 打开【修改】页面
         */
        Update: function() {
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
                    }});
                return true;
            } else {
                art.dialog.tips("请选择一条记录进行修改操作！");
                return false;
            }
        },
        /**
         * 删除
         */
        Del: function() {
            var _this = this;
            var ids = _this.GetSelectedIds();
            if (!ids || ids.length === 0) {
                art.dialog.tips("请至少选择一条记录进行操作！");
                return false;
            };

            art.dialog.confirm("您确定要删除此节点吗？", function() {
                $.XCLGoAjax({
                    obj: $("#btnDel")[0],
                    url: lib.RootURL + "SysDic/DelSubmit",
                    data: {SysDicIds: ids.join(',')},
                    beforeSendMsg: "正在删除中，请稍后...",
                    afterSuccessFunction: function () {
                        $.each(ids, function (idx,n) {
                            _this.TreeObj.treegrid("remove", n);
                        });
                    }
                });
            }, function() {
            });
            return false;
        },
        /**
         * 清空子节点
         */
        Clear: function() {
            var _this = this;
            var ids = _this.GetSelectedIds();
            if (!ids || ids.length !== 1) {
                art.dialog.tips("请选择一条记录进行操作！");
                return false;
            };

            art.dialog.confirm("您确定要清空此节点的所有子节点吗？", function() {
                $.XCLGoAjax({
                    obj: $("#btnClearChild")[0],
                    url: lib.RootURL + "SysDic/DelChildSubmit",
                    data: {sysDicID: ids[0]},
                    beforeSendMsg: "正在清空中，请稍后...",
                    afterSuccessFunction: function() {
                        var parent = _this.TreeObj.treegrid("getParent", ids[0]);
                        if (parent) {
                            _this.TreeObj.treegrid("reload", parent.SysDicID);
                        } else {
                            _this.Refresh();
                        }
                    }
                });
            }, function() {
            });
            return false;
        },
        /**
         * 刷新列表
         */
        Refresh: function() {
            this.TreeObj.treegrid("reload");
        }
    };
    lib.SysDic.SysDicAdd = {
        Init: function() {
            var _this = this;
            _this.InitValidator();

            $("#btnCreateAutoCode").on("click", function() {
                $("#txtCode").val(lib.Common.CreateAutoCode());
            });
        },
        InitValidator: function() {
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
                                code: function() {
                                    return $("#txtCode").val();
                                },
                                SysDicID: function() {
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
            lib.BindLinkButtonEvent("click", $("#btnSave"), function() {
                if (!lib.CommonFormValid(validator)) {
                    return false;
                }
                $.XCLGoAjax({obj: $("#btnSave")[0]});
            });
        }
    };
    
    /***********************************************************************************************/

    lib.SysWebSetting={};
    lib.SysWebSetting.SysWebSettingList={
        Init:function(){
            var _this = this;
            $("#btnUpdate").on("click", function() {
                return _this.Update();
            });
            $("#btnDel").on("click", function() {
                return _this.Del();
            });            
        },
        /**
         * 返回已选择的value数组
         */
        GetSelectValue: function() {
            var selectVal = $(".XCLTableCheckAll").val();
            var ids = selectVal.split(',');
            if (selectVal && selectVal !== "" && ids.length > 0) {
                return ids;
            } else {
                return null;
            }
        },
        /**
         * 打开配置信息【修改】页面
         */
        Update: function() {
            var $btn = $("#btnUpdate"), ids = this.GetSelectValue();
            if (ids && ids.length === 1) {

                var query = {
                    handletype: "update",
                    SysWebSettingID: ids[0]
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
         * 删除配置信息
         */
        Del: function() {
            var ids = this.GetSelectValue();
            if (!ids || ids.length == 0) {
                art.dialog.tips("请至少选择一条记录进行操作！");
                return false;
            }

            art.dialog.confirm("您确定要删除此信息吗？", function() {
                $.XCLGoAjax({
                    obj: $("#btnDel")[0],
                    url: lib.RootURL + "SysWebSetting/DelSubmit",
                    data: {SysWebSettingIDs: ids.join(',')},
                    beforeSendMsg: "正在删除中，请稍后...",
                    isRefreshSelf: true
                });
            }, function() {
            })

            return false;
        }                
    };
    lib.SysWebSetting.SysWebSettingAdd={
        Init: function() {
            var _this = this;
            _this.InitValidator();

            $("#btnDel").on("click", function() {
                return _this.Del();
            });
        },
        /**
         * 表单验证初始化
         */
        InitValidator: function() {
            var validator = $("form:first").validate({
                rules: {
                    txtKeyName: {
                        required: true,
                        XCLCustomRemote: {
                            url: lib.RootURL + "SysWebSettingCommon/IsExistKeyName",
                            data: {
                                KeyName: function() {
                                    return $("#txtKeyName").val();
                                },
                                SysWebSettingID: function() {
                                    return $("#SysWebSettingID").val();
                                }
                            }
                        }
                    }
                }
            });
            lib.BindLinkButtonEvent("click", $("#btnSave"), function() {
                if (!lib.CommonFormValid(validator)) {
                    return false;
                }
                $.XCLGoAjax({obj: $("#btnSave")[0]});
            });
        },
        /**
         * 删除配置
         */
        Del: function() {
            var id = $("#SysWebSettingID").val();
            art.dialog.confirm("您确定要删除此信息吗？", function() {
                $.XCLGoAjax({
                    obj: $("#btnDel")[0],
                    url: lib.RootURL + "SysWebSetting/DelSubmit",
                    data: {SysWebSettingIDs: id},
                    beforeSendMsg: "正在删除中，请稍后...",
                    isRefreshSelf: true
                });
            });
            return false;
        }        
    };
    
    /***********************************************************************************************/
    lib.SysFunction = {};
    lib.SysFunction.SysFunctionList = {
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
    lib.SysFunction.SysFunctionAdd = {
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
                                functionName:function(){
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


    /***********************************************************************************************/


    /*
    * 系统日志
    */
    lib.SysLog = {};
    lib.SysLog.SysLogList = {
        Init: function () {
            var _this = this;
            $(".XCLCMSOverFlow").readmore({ collapsedHeight: 80 });
            $(".clearLogMenuItem").on("click", function () {
                _this.ClearLog($(this));
            });
        },
        ClearLog: function ($menuItem) {
            var data = $.parseJSON($menuItem.attr("xcl-data"));
            art.dialog.confirm("您确定要清空【"+data.txt+"】的所有日志信息吗？", function () {
                $.XCLGoAjax({
                    url: lib.RootURL + "SysLog/ClearSubmit",
                    data: { dateType: data.val },
                    beforeSendMsg: "正在删除中，请稍后...",
                    isRefreshSelf: true
                });
            });
        }
    };

    /***********************************************************************************************/
    
    /**
    * 文章
    */
    lib.Article = {};
    lib.Article.ArticleList = {
        Init: function () {

        }
    };

    lib.Article.ArticleAdd = {
        /**
        * 元素
        */
        Elements: {
            divContentNote: null,//内容字数统计
            Init: function () {
                this.divContentNote = $("#divContentNote");
            }
        },
        /**
        *  模板
        */
        HTMLTemps: {
            divContentNoteTemp: "divContentNoteTemp"
        },
        Init: function () {
            var _this = this;
            _this.Elements.Init();
            
            //初始化主图上传
            $("#btnMainImage1").on("click", function () {
                _this.UploadMainImage();
            });

            //初始化编辑器
            var editor=null;
            KindEditor.ready(function (K) {
                editor = K.create('textarea[name="txtContents"]', {
                    allowFileManager: true,
                    afterChange: function () {
                        var textCount = this.count('text');
                        var data = { WordCount: textCount };
                        _this.Elements.divContentNote.html(template(_this.HTMLTemps.divContentNoteTemp, data));
                    }
                });
            });
        },
        UploadMainImage: function () {
            art.dialog.open(lib.RootURL + 'Upload/Index', {title: '文件上传', width: 1100, height: 650});
        }
    };
    
    /***********************************************************************************************/
    //文件上传
    lib.Uploader = {};
    lib.Uploader.Add = {
        /**
         * 文件列表
         */
        _fileModelList:[],
        /**
         * 根据文件id，返回该文件的json model信息
         */
        _getModelById:function(id){
            var result=null,_this=this;
            if(_this._fileModelList){
                $.each(_this._fileModelList,function(index,n){
                    if(n.Id==id){
                      result=n;
                      return false;
                    }
                });
            }
            return result;
        },
        /**
         * model
         */
        FileModel:function(){
            this.Path = "";//原路径
            this.SmallPath="";//较小尺寸（文件为图片时180*180）
            this.BigPath="";//较大尺寸（文件为图片时400*400）
            this.Id = "";
            this.Size = "";
            this.Format = "";
            this.Name = "";
            this.Width=0;
            this.Height=0;
        },        
        Init: function () {
            var _this=this;
            //初始化上传
            var uploader = new plupload.Uploader({
                browse_button: 'btnAddFile',
                url: 'upload.php'
            });
            uploader.init();
            uploader.bind('FilesAdded', function (up, files) {
                var lst=[];
                plupload.each(files, function (file) {
                    var model = new _this.FileModel();
                    model.Id = file.id;
                    model.Name = file.name;
                    model.Size = plupload.formatSize(file.size);
                    _this.PreviewImage({file:file,callback:function (preloader) {
                        model.Width=preloader.width;
                        model.Height=preloader.height;
                        model.Path=preloader.getAsDataURL();
                        
                        preloader.downsize(180,180);//预览图片的最大宽高，自动等比。
                        model.SmallPath=preloader.getAsDataURL();
                        
                        var imgObj = new mOxie.Image();
                        imgObj.onload = function () {
                            imgObj.downsize(400,400);
                            model.BigPath=imgObj.getAsDataURL();
                            preloader.destroy();
                            preloader = null;
                        };
                        imgObj.load(file.getSource());
                        
                        $("img#" + file.id).attr({ src: model.SmallPath });
                    }});
                   lst.push(model);
                });
                $("#ItemsUL").append(template('fileItemTemp', {FileModelList:lst}));
                _this._fileModelList=XCLJsTool.Array.Concat(_this._fileModelList,lst);
            });
            //修改文件
            $("body").on("click","a[rel='fileEdit']",function(){
                var id=$(this).attr("xcl-Id");
                var model=_this._getModelById(id);
                $("#divEditFile").html(template('divEditFileTemp', model));
                $("#divEditFile .easyui-linkbutton").linkbutton();
                //图片裁剪
                $("img#ImgToEdit").Jcrop();
                //查看原图
                $(document).off("click", "#btnShowSource").on("click", "#btnShowSource", function () {
                    $("#divShowImg").html(template('divShowImgTemp', { ImgSrc: model.Path })).find("form").submit();
                    return false;
                });
                return false;
            });
            //图片旋转
            $("body").on("click","#btnLeftRotate",function(){
                //左旋转
                $("img#ImgToEdit").rotate(-90);
            });
            $("body").on("click","#btnRightRotate",function(){
                //右旋转
                $("img#ImgToEdit").rotate(90);
            });
        },
        /**
         * 图片预览
         */
        PreviewImage: function (options) {
            if (!options.file || !/image\//.test(options.file.type)) return; //确保文件是图片
            if (options.file.type == 'image/gif') {//gif使用FileReader进行预览,因为mOxie.Image只支持jpg和png
                var fr = new mOxie.FileReader();
                fr.onload = function () {
                    options.callback(fr.result);
                    fr.destroy();
                    fr = null;
                };
                fr.readAsDataURL(options.file.getSource());
            } else {
                var preloader = new mOxie.Image();
                preloader.onload = function () {
                    options.callback && options.callback(preloader);
                    preloader.destroy();
                    preloader = null;
                };
                preloader.load(options.file.getSource());
            }
        }
    };


    
    window.XCLCMS = lib;

})(window);