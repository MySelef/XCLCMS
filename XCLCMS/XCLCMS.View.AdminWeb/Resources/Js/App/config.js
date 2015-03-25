var require = {
    baseUrl: "http://localhost:3781/Resources/Js/App/",
    paths: {
        "jquery": "../Jquery/jquery-1.11.2",
        "ajaxfileupload": "../AjaxFileUpload/ajaxfileupload",
        "artDialog": "../artDialog/artDialog",
        "artTemplate": "../artTemplate/template",
        "easyUI": "../EasyUI/jquery.easyui.min",
        "jcrop": "../Jcrop/js/jquery.Jcrop",
        "jQuery.Color": "../Jquery/jquery.color",
        "kindeditor": "../kindeditor/kindeditor-all",
        "kindeditor.zh_CN": "../kindeditor/lang/zh_CN",
        "plupload": "../plupload/plupload.full.min",
        "plupload.moxie": "../plupload/moxie",
        "validate": "../Validate/jquery.validate",
        "wdatePicker": "../WdatePicker/WdatePicker",
        "dynamicCon": "../dynamicCon",
        "goAjax": "../GoAjax",
        "jquery.metadata": "../jquery.metadata",
        "readmore": "../readmore",
        "table": "../table",
        "XCLJsTool": "../XCLJsTool"
    },
    shim: {
        "ajaxfileupload": {
            deps: ["jquery"]
        },
        "easyUI": {
            deps: ["jquery"]
        },
        "jcrop": {
            deps: ["jquery"]
        },
        "jQuery.Color": {
            deps: ["jquery"]
        },
        "kindeditor.zh_CN": {
            deps: ["kindeditor"]
        },
        "validate": {
            deps: ["jquery"]
        },
        "dynamicCon": {
            deps: ["jquery"]
        },
        "goAjax": {
            deps: ["jquery"]
        },
        "jquery.metadata": {
            deps: ["jquery"]
        },
        "readmore": {
            deps: ["jquery"]
        },
        "table": {
            deps: ["jquery"]
        },
        "XCLJsTool": {
            deps: ["jquery"]
        }
    }
};