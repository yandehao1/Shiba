//$(document).ready(function () {
//    displayToolbar();
//});

$.fn.extend({
    resizeDataGrid: function (heightMargin, widthMargin, minHeight, minWidth) {
        var height = $(document.body).height() - heightMargin;
        var width = $(document.body).width() - widthMargin;
        height = height < minHeight ? minHeight : height;
        width = width < minWidth ? minWidth : width;
        $(this).datagrid('resize', {
            height: height,
            width: width
        });
    }
});

var heightMargin = $("#menu").height() + 60;
var widthMargin = $(document.body).width() - $("#tb").width();
// 第一次加载时和当窗口大小发生变化时，自动变化大小
$('#sampleSourceDataGrid').resizeDataGrid(heightMargin, widthMargin, 0, 0);
$(window).resize(function () {
    $('#sampleSourceDataGrid').resizeDataGrid(heightMargin, widthMargin, 0, 0);
});
$('#sampleSourceDataGrid').resizeDataGrid(heightMargin, widthMargin, 0, 0);
$(window).resize(function () {
    $('#sampleSourceDataGrid').resizeDataGrid(heightMargin, widthMargin, 0, 0);
});


function reshis() {
    $.post('RespondHis.ashx',{action:respondhis})
}
////页面加载时访问
function displayToolbar() {
    $.ajax({
        type: 'POST',
        url: 'Login.ashx',
        data: { type: 'checklogin' },
        success: function (data) {
            $('#MenuBar').html(data);
        },
        dataType: "text"
    });
}
//打开登陆框
function dologin() {
    $('#frmLogin').form("clear");
    $('#Login').dialog('open');
}
$(function () {
    $("input", $("#password").next("span")).keydown(function (e) {
        if (e.keyCode == 13) {
            login();
        }
    });
})
//登陆
function login() {
    $('#frmLogin').form({
        type: 'POST',
        url: "Login.ashx?type=login",
        onSubmit: function () {
            // 做某些检查 
            // 返回 false 来阻止提交 
        },
        success: function (data) {
            if (data == "恭喜你,登录成功,欢迎使用FreezerPro协同助手！") {
                $('#Login').dialog('close');
                displayToolbar();
            }
            else if (data == "对不起,用户名或密码错误,请重新输入！") {
                $.messager.alert('提示', data, 'info');
            }
        }
    });
    $('#frmLogin').submit();
}
//注销登陆
function logout() {
    $.messager.confirm('询问', '确定要注销当前登录用户么？', function (ok) {
        if (ok) {
            $.ajax({
                type: 'POST',
                url: 'Login.ashx?type=logout',
                success: function (data) {
                    $('#MenuBar').html(data);
                },
                dataType: "text",
            });
        }
    });
}
//格式化文档中的日期控件
$.fn.datebox.defaults.formatter = function (date) {
    var y = date.getFullYear();
    var m = date.getMonth() + 1;
    var d = date.getDate();
    return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
};
$.fn.datebox.defaults.parser = function (s) {
    if (!s) return new Date();
    var ss = s.split('-');
    var y = parseInt(ss[0], 10);
    var m = parseInt(ss[1], 10);
    var d = parseInt(ss[2], 10);
    if (!isNaN(y) && !isNaN(m) && !isNaN(d)) {
        return new Date(y, m - 1, d);
    } else {
        return new Date();
    }

};
//全局操作
(function ($) {
    function getCacheContainer(t) {
        var view = $(t).closest('div.datagrid-view');
        var c = view.children('div.datagrid-editor-cache');
        if (!c.length) {
            c = $('<div class="datagrid-editor-cache" style="position:absolute;display:none"></div>').appendTo(view);
        }
        return c;
    }
    function getCacheEditor(t, field) {
        var c = getCacheContainer(t);
        return c.children('div.datagrid-editor-cache-' + field);
    }
    function setCacheEditor(t, field, editor) {
        var c = getCacheContainer(t);
        c.children('div.datagrid-editor-cache-' + field).remove();
        var e = $('<div class="datagrid-editor-cache-' + field + '"></div>').appendTo(c);
        e.append(editor);
    }

    var editors = $.fn.datagrid.defaults.editors;
    for (var editor in editors) {
        var opts = editors[editor];
        (function () {
            var init = opts.init;
            opts.init = function (container, options) {
                var field = $(container).closest('td[field]').attr('field');
                var ed = getCacheEditor(container, field);
                if (ed.length) {
                    ed.appendTo(container);
                    return ed.find('.datagrid-editable-input');
                } else {
                    return init(container, options);
                }
            }
        })();
        (function () {
            var destroy = opts.destroy;
            opts.destroy = function (target) {
                if ($(target).hasClass('datagrid-editable-input')) {
                    var field = $(target).closest('td[field]').attr('field');
                    setCacheEditor(target, field, $(target).parent().children());
                } else if (destroy) {
                    destroy(target);
                }
            }
        })();
    }
})(jQuery);


//打开导入界面
function doimport() {
    $('#mainopanels').window('open');
}
//datagrid操作
var editIndex = undefined;
//编辑
function endEditing() {
    if (editIndex == undefined) { return true }
    if ($('#sampleSourceDataGrid').datagrid('validateRow', editIndex)) {
        var ed = $('#sampleSourceDataGrid').datagrid('getEditor', {
            index: editIndex,
            field: 'sampleSourceType'
        });
        var sampleSourceTypeName = $(ed.target).combobox('getText');
        $('#sampleSourceDataGrid').datagrid('getRows')[editIndex]['sampleSourceTypeName'] = sampleSourceTypeName;
        $('#sampleSourceDataGrid').datagrid('updateRow', {
            index: editIndex,
            row: { 'sampleSourceDescription': sampleSourceTypeName + "病区" }
        });
        $('#sampleSourceDataGrid').datagrid('endEdit', editIndex);
        editIndex = undefined;
        return true;
    } else {
        return false;
    }
}
//点击
function onClickRow(index) {
    accept();
    if (editIndex != index) {
        if (endEditing()) {
            $('#sampleSourceDataGrid').datagrid('selectRow', index).datagrid('beginEdit', index);
            editIndex = index;
        } else {
            $('#sampleSourceDataGrid').datagrid('selectRow', editIndex);
        }
    }
}
//添加
function append() {
    if (endEditing()) {
        $('#sampleSourceDataGrid').datagrid('appendRow', { status: 'P' });
        editIndex = $('#sampleSourceDataGrid').datagrid('getRows').length - 1;
        $('#sampleSourceDataGrid').datagrid('selectRow', editIndex).datagrid('beginEdit', editIndex);
    }
}
//删除当前编辑项
function removeit() {
    if (editIndex == undefined) { return }
    $('#sampleSourceDataGrid').datagrid('cancelEdit', editIndex).datagrid('deleteRow', editIndex);
    editIndex = undefined;
}
//保存
function accept() {
    if (endEditing()) {
        $('#sampleSourceDataGrid').datagrid('acceptChanges');
    }
}
//撤销
function reject() {
    $('#sampleSourceDataGrid').datagrid('rejectChanges');
    editIndex = undefined;
}
//获取更改行
function getChanges() {
    var rows = $('#sampleSourceDataGrid').datagrid('getChanges');
}
//重新加载grid
function relode() {
    $('#sampleSourceDataGrid').datagrid('reload');
}
function openbarcodeiputbox() {
    $('#barcodeiputbox').dialog('open');
    $('#barcodeiputbox input.validatebox-text').focus();
}
//条码框按钮回车事件
$(function () {
    $("input", $("#barcodebox").next("span")).keydown(function (e) {
        if (e.keyCode == 13) {
            var code = $('#barcodebox').textbox('getValue');
            if ($.trim(code)) {
                barcode(code);
                var code = $('#barcodebox').textbox('clear');
            }
            var code = $('#barcodebox').textbox('clear');
        }
    });
})
//点击确定按钮提交请求
function getdatabybarcode() {
    var code = $('#barcodebox').textbox('getValue');
    if ($.trim(code)) {
        barcode(code);
        var code = $('#barcodebox').textbox('clear');
    }
    var code = $('#barcodebox').textbox('clear');
}
//根据barcode查询数据
function barcode(code) {
    accept();
    $.ajax({
        url: "GetData.ashx",
        type: "post",
        data: { "GetType": "getdatabybarcode", "barcode": code },
        dataType: "text",
        success: function (data) {
            //var barcode = $('#barcode').textbox('getText');
            //$('#barcode').textbox('setText', '');
            if (data == "") {
                alert("无数据");
            }
            if (data != "") {
                var dataStr = eval("(" + data + ")")
                if (dataStr.success) {
                    $('#sampleSourceDataGrid').datagrid('insertRow', {
                        index: 0,
                        row: dataStr['result']
                    });
                }
                else if (!dataStr.success) {
                    alert(dataStr['result']);
                }
            }
        },
        cache: false,
        error: function () {
            alert("获取数据超时");
        }
    });
}
//打开时间选择框
function doquerydatabytime() {
    $('#dodatesearch').dialog('open');
    var begindate = new Date();
    $('#begindate').textbox('setValue', myformatter(begindate))
}
//格式化日期
function myformatter(date) {
    var y = date.getFullYear();
    var m = date.getMonth() + 1;
    var d = date.getDate();
    return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
}
function getdateinterval(dategegin, dateend) {
    var sDate = new Date(dategegin);
    var eDate = new Date(dateend);
    var fen = ((eDate.getTime() - sDate.getTime()) / 1000) / 60;
    var distance = parseInt(fen / (24 * 60));   //相隔distance天
    return distance;
};
//时间验证
function dateSearch() {
    var begindate = $('#begindate').datetimebox('getValue')
    var enddate = $('#enddate').datetimebox('getValue')
    if (begindate == "") {
        alert("请输入开始日期");
        $('begindate').focus;
    }
    else if (enddate == "") {
        alert("请输入结束日期");
    }
    else if (getdateinterval(begindate, enddate) < 0) {
        alert("结束日期不能小于起始日期");
    }
    else if (getdateinterval(begindate, enddate) > 5) {
        alert("时间间隔超过5天")
    }
    else {
        $('#dodatesearch').dialog('close');
        querydatabydate(begindate, enddate);
    }
}
//提交日期查询
function querydatabydate(begindate, enddate) {
    accept();
    $.ajax({
        url: "GetData.ashx",
        type: "post",
        data: { "GetType": "dateSearch", "begindate": begindate, "enddate": enddate },
        dataType: "text",
        success: function (data) {
            if (data == "") {
                alert("无数据");
            }
            if (data != "") {
                var dataStr = eval("(" + data + ")")
                if (dataStr.success) {
                    var arr = eval(dataStr['result']);
                    for (var a in arr) {
                        //alert(a);
                        //alert(arr[a]['patientName']);
                        $('#sampleSourceDataGrid').datagrid('insertRow', {
                            index: 0,
                            row: arr[a]
                        });
                    }
                }
                else if (!dataStr.success) {
                    alert(dataStr['result']);
                }
            }
        },
        cache: false,
        error: function () {
            alert("获取数据超时");
        }
    });
}
//导入数据
function batchImport() {
    accept();
    var rows = $('#sampleSourceDataGrid').datagrid('getSelections');
    for (var i = 0; i < rows.length; i++) {
        if (rows[i].sampleSourceType != "") {
            if (rows[i].importStatus != "成功") {
                $.ajax({
                    type: 'POST',
                    url: 'ImportData.ashx',
                    data: rows[i],
                    dataType: "text",
                    cache: false,
                    success: function (data) {
                        var result = eval('(' + data + ')')
                        //if (result['success'] == "成功") {
                        ////var patientId = result['patientId']//此处只有1行数据
                        changeState(result)
                    }
                })
            }
        }
    }
}
//导入样本源已存在，或者成功
function changeState(result) {
    var rows = $('#sampleSourceDataGrid').datagrid('getRows');
    for (var i = 0; i < rows.length; i++) {
        if (rows[i].patientId == result['patientId']) {
            if (result['Reason'] == "成功") {
                $('#sampleSourceDataGrid').datagrid('updateRow', {
                    index: i,
                    row: {
                        importStatus: result['success']
                    }
                });
            }
            else {
                $('#sampleSourceDataGrid').datagrid('updateRow', {
                    index: i,
                    row: {
                        importStatus: result['success'] + ';' + result['Reason']
                    }
                });
            }
            relode();
        }
    }
}

function removeSelections() {
    var rows = $('#sampleSourceDataGrid').datagrid("getSelections");
    var copyRows = [];
    for (var j = 0; j < rows.length; j++) { copyRows.push(rows[j]); }
    for (var i = 0; i < copyRows.length; i++) {
        var index = $('#sampleSourceDataGrid').datagrid('getRowIndex', copyRows[i]);
        $('#sampleSourceDataGrid').datagrid('deleteRow', index);
    }
}

//测试数据
function removechecked() {
    var getRows = $('#sampleSourceDataGrid').datagrid('getRows');
    alert('getRows:' + getRows.length);

    var getRowIndex = $('#sampleSourceDataGrid').datagrid('getRowIndex', getRows);
    alert("getRowIndexWithGetRows:" + getRowIndex)

    var getChecked = $('#sampleSourceDataGrid').datagrid('getChecked');
    alert('getChecked:' + getChecked.length);

    var getSelections = $('#sampleSourceDataGrid').datagrid('getSelections');
    alert('getSelections:' + getSelections.length);

    for (var row in getRows) {
        if (row['ck']) {
            alert(1);
        }
    }
    relode();
}
