define(function () {
    //主模板js
    var app = {
        Init: function () {
            var $DivMenuTabs=$("#DivMenuTabs");
            var tabs = $DivMenuTabs.tabs('tabs');
            //选项卡处理
            for (var i = 0; i < tabs.length; i++) {
                //鼠标划过，选中选项卡
                tabs[i].panel('options').tab.unbind().bind('mouseenter', { index: i }, function (e) {
                    $DivMenuTabs.tabs('select', e.data.index);
                });
                //无菜单按钮，隐藏选项卡
                if(tabs[i].panel().find(".easyui-linkbutton").length==0){
                    tabs[i].panel('options').tab.hide();
                }
            }
            //鼠标移出菜单时，回到当前选中的菜单
            if (XCLCMSPageGlobalConfig.CurrentParentMenuID > 0 && XCLCMSPageGlobalConfig.CurrentMenuID > 0) {
                var m1 = XCLCMSPageGlobalConfig.CurrentParentMenuID;
                var m2 = XCLCMSPageGlobalConfig.CurrentMenuID;
                var $m2=$DivMenuTabs.find("a[xcl-sysdicid='"+m2+"']");
                $DivMenuTabs.on("mouseleave",function(){
                    if(!($m2.is(":visible"))){
                        var index=$m2.closest(".panel").index();
                        $DivMenuTabs.tabs('select', index);
                    }
                });
            };

        },
        /**
        * 向form标签中追加附加信息
        */
        AppendToForm: function (val) {
            $("form").append(val);
        }
    };
    return app;
});