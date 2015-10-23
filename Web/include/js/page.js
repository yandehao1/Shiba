//给In_CodeType下拉框绑定值
$(function () {
    //var username = $.cookie('username');
    //var codeType = $.cookie(username + 'codeType');
    $('#codeType').combobox({
        editable: false,
        method: 'get',
        valueField: 'value',
        textField: 'text',
        url: '../Fp_Ajax/PageConData.aspx?conMarc=Mzzybz',
        panelHeight: 'auto',
        onChange: In_CodeTypeChange,
        //selectOnNavigation:$(this).is(':checked'),
        onLoadSuccess: function () { //数据加载完毕事件
            if (codeType) {
                $('#codeType').combobox('setValue', codeType);
                //绑定数据到页面
            }
        }
    })
})

function In_CodeTypeChange() {
    var username = $.cookie('username');
    var codeType = $('#codeType').combobox('getValue');
    //清除cookie
    $.cookie(username + "codeType", null);
    //重写cookie
    $.cookie(username + 'codeType', codeType, { expires: 7 });
}

//给departments下拉框绑定值
$(function () {
    $('#departments').combobox({
        editable: false,
        method: 'get',
        valueField: 'value',
        textField: 'text',
        url: '../Fp_Ajax/PageConData.aspx?conMarc=departments',
        panelHeight: 'auto',
        onLoadSuccess: function () { //数据加载完毕事件
            //$("#In_CodeType").combobox('setValue', '住院号');
        }
    })
})

//给性别下拉框绑定值
$(function () {
    $('#Sex').combobox({
        editable: false,
        method: 'get',
        valueField: 'SexFlag',
        textField: 'text',
        url: '../Fp_Ajax/PageConData.aspx?conMarc=SexFlag',
        panelHeight: 'auto'
    });
})

//
$(function () {
    $('#cc').combobox({
        onChange: function (newValue)
        {
            if (newValue == 2)
            {
                document.getElementById("getcode").style.visibility = "hidden";
                document.getElementById("getdate").style.visibility = "visible";
            }
            else {
                document.getElementById("getdate").style.visibility = "hidden";
                document.getElementById("getcode").style.visibility = "visible";
            }
        }
    });
})

//采用jquery easyui loading css效果
function ajaxLoading() {
    $("<div class=\"datagrid-mask\"></div>").css({ display: "block", width: "100%", height: $(window).height() }).appendTo("body");
    $("<div class=\"datagrid-mask-msg\"></div>").html("正在处理，请稍候。。。").appendTo("body").css({ display: "block", left: ($(document.body).outerWidth(true) - 190) / 2, top: ($(window).height() - 45) / 2 });
}
function ajaxLoadEnd() {
    $(".datagrid-mask").remove();
    $(".datagrid-mask-msg").remove();
}

function isEmptyStr(str) {
    if (str == '' || str == null) {
        return true;
    } else {
        return false;
    }
}

function ShowMsg(msg) {
    $.messager.show({
        title: "提示",
        msg: msg,
        timeout: 2000,
        showType: 'fade'
    });
}