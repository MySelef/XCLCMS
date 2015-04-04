//by:xcl @2012-10-24
//请求成功后需要返回的数据:{"msg":"提示信息","isReload":"为1则需要刷新，否则只显示提示信息不刷新页面"}
; (function ($) {
    $.extend({
        XCLGoAjax: function (options) {
            options = $.extend({}, funs.Defaults, options);
            funs.Init(options);
        }
    });
    var funs = {
        Defaults: {
            obj: null, //指定对象
            type: "POST", // post或get
            data: null, //数据
            url: null, //url
            isLockBtn: true, //为true则disabled对象obj
            isRefreshSelf: false, // 为true刷新当前页面页不是父页面
            successFunction: null, //请求成功后执行的函数
            afterSuccessFunction:null,//执行默认的成功函数后要执行的内容
            isAlertShowMsg: false, //true:以alert的方式弹出消息，点确定或关闭执行刷新或其它函数。false:以tips弹出消息
            beforeSendMsg: "" //请求前要提示的信息
        },
        Init: function (options) {
            var _this = this;
            var existObj=(null!=options.obj);//obj对象是否存在，便于后续的代码中不要对obj对象进行操作

            if (!existObj) {
                options.isLockBtn = false;
            }

            if (options.url == null) {
                if (existObj) {
                    options.url = $(options.obj).closest("form").attr("action");
                } else {
                    options.url = $("form:first").attr("action");
                }
            }

            var oldValue = "";

            if (existObj)
            {
                oldValue = $(options.obj).linkbutton("options").text;//按钮的原始文字
                oldValue = (oldValue == "") ? "保 存" : oldValue;
            }

            if (options.data == null) {
                if (existObj) {
                    options.data = $(options.obj).closest("form").serialize();
                } else {
                    options.data = $("form:first").serialize();
                }
            }

            if (options.beforeSendMsg != "") {//写在$.ajax中时，当网络不好时，可能会卡
                art.dialog.tips(options.beforeSendMsg, 500000);
            }

            if (options.isLockBtn) {
                _this.SetBtnEnable(options.obj, oldValue, false);
            }

            $.ajax({
                type: options.type,
                data: options.data,
                dataType: "JSON",
                url: options.url,
                error: function () {
                    art.dialog.tips("抱歉，出错啦！请稍后再试！");
                },
                success: function (data) {
                    var data = data[XCLCMSPageGlobalConfig.XCLJsonMessageName] || data;
                    var dialogIcon = "succeed";

                    if (data && data.Message && !data.IsSuccess) {
                        //如果【该请求返回的json中的IsSuccess为false】，则弹出对话框提示相关信息。
                        options.isAlertShowMsg = true;
                        dialogIcon = "error";
                    }

                    if (null != options.successFunction) {
                        options.successFunction(data);
                        if(null!=options.afterSuccessFunction){
                            options.afterSuccessFunction(data);
                        }
                        return;
                    }
                    if (options.isLockBtn) {
                        //延迟1秒，防止点击过快
                        setTimeout(function () {
                            _this.SetBtnEnable(options.obj, oldValue, true);
                        }, 1000);
                    }
                    if (data.Message != "") {
                        if (options.isAlertShowMsg) {
                            var list = art.dialog.list["Tips"];
                            if (null != list) {
                                list.close();
                            }
                            art.dialog({
                                icon: dialogIcon,
                                width:500,
                                content: data.Message,
                                cancelVal: '知道了',
                                cancel: function () {
                                    funs.Refresh(options, data);
                                }
                            });
                        } else {
                            //以tips方式显示消息
                            art.dialog.tips(data.Message);
                            funs.Refresh(options, data);
                        }
                    }
                    if(null!=options.afterSuccessFunction){
                        options.afterSuccessFunction(data);
                    }
                },
                complete: function () {
                    if (options.isLockBtn) {
                        _this.SetBtnEnable(options.obj, oldValue, true);
                    }
                }
            });
        },
        //设置linkbutton按钮状态
        SetBtnEnable: function (btnObj, text, enable) {
            if (enable) {
                $(btnObj).prop({"disabled":false});
                $(btnObj).linkbutton({
                    text: text,
                    disabled: false
                });
            } else {
                $(btnObj).prop({ "disabled": true });
                $(btnObj).linkbutton({
                    text: "提交中，请稍后...",
                    disabled: true
                });
            }
        },

        Refresh: function (options, data) {
            var time = 700;
            if (options.isAlertShowMsg) {
                time = 0;
            }
            if (data.IsRefresh) {
                setTimeout(function () {
                    if (options.isRefreshSelf) {
                        location.reload();
                    } else {
                        art.dialog.open.origin.location.reload();
                    }
                }, time);
            }
        }
    }
})(jQuery);