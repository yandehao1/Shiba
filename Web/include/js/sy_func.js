//设置页面DataGrid分页
function pagerFilter(data) {
    if (typeof data.length == 'number' && typeof data.splice == 'function') {	// is array
        data = { total: data.length, rows: data }
    }
    var dg = $(this);
    var opts = dg.datagrid('options');
    var pager = dg.datagrid('getPager');
    pager.pagination({
        onSelectPage: function (pageNum, pageSize) {
            opts.pageNumber = pageNum;
            opts.pageSize = pageSize;
            pager.pagination('refresh', { pageNumber: pageNum, pageSize: pageSize });
            dg.datagrid('loadData', data);
        }
    });
    if (!data.originalRows) { data.originalRows = (data.rows); }
    var start = (opts.pageNumber - 1) * parseInt(opts.pageSize);
    var end = start + parseInt(opts.pageSize);
    data.rows = (data.originalRows.slice(start, end));
    return data;
}
//绑定数据
function querybycode() {
    clearForm();
    var codeType = $('#codeType').combobox('getValue');
    var code = $('#code').textbox('getValue');//获取数据源
    if (/.*[\u4e00-\u9fa5]+.*$/.test(code)) { $.messager.alert('错误', '不能输入中文', 'error'); $('#In_Code').textbox('clear'); return; }
    if (code.length > 14) { $.messager.alert('错误', '条码最高不能超过15位', 'error'); $('#In_Code').textbox('clear'); return; }
    if (isEmptyStr(codeType) || isEmptyStr(code)) { $.messager.alert('提示', '请检查条码类型和条码号', 'error'); }
    else {
        ajaxLoading();
        $.ajax({
            type: 'GET',
            url: '/Sever/EmpiInfo.ashx?mode=qry&codeType=' + codeType + '&code=' + code,
            onSubmit: function () { },
            success: function (data) {
                ajaxLoadEnd();
                $('#code').textbox('setValue', '');
                clearForm();
                if (!data) { $.messager.alert('提示', '查询不到数据,请检查数据是否存在！', 'error'); }
                else {
                    //测试代码
                    var obj = $.parseJSON(data);
                    if (obj.Statu == "err") {
                        ShowMsg(obj.Msg);
                        return;
                    }
                    else {
                        $("#BaseInfoForm").form("load", obj.Data);
                        $('#oldCode').textbox('setValue', code);
                        $('#oldCodeType').textbox('setValue', codeType);
                        GetNormalLisReportInfo();
                        GetPatientDiagnoseInfo();
                        //发送请求请求临床数据
                        //请求条件？1、条码号；2、日期
                    }
                }
            }
        });
        ajaxLoadEnd();
    }
}
//增加月
function AddMonths(d, value) {
    d.setMonth(d.getMonth() + value);
    return d;
}
//增加天
function AddDays(d, value) {
    d.setDate(d.getDate() + value);
    return d;
}
//增加时
function AddHours(d, value) {
    d.setHours(d.getHours() + value);
    return d;
}
//查询NormalLisReport数据
function GetNormalLisReportInfo() {
    //<Request>
    //  <hospnum></hospnum>
    //  <ksrq00></ksrq00>
    //  <jsrq00></jsrq00>
    //</Request>
    var code = $('#oldCode').textbox('getValue');
    var codeType = $('#oldCodeType').textbox('getValue');
    if (code) {
        //开始查询日期为当前日期前五天
        //结束日期为当前日期后一天
        var dateNow = AddDays(new Date(), 0).toDateString();
        $.ajax({
            type: "POST",
            url: "/Sever/NormalLisReport.ashx",
            data: {
                "mode": "qry",
                "code": code,
                "codeType": codeType,
                "dateNow": dateNow
            },
            success: function (data) {
                if (!data) { $.messager.alert('提示', '查询不到数据,请检查数据是否存在！', 'error') }
                else {
                    var obj = $.parseJSON(data);
                    if (obj.Statu == "err") {
                        ShowMsg("临床监测数据：" + obj.Msg);
                        return;
                    }
                    else if (obj.Statu == "ok") {
                        $('#NormalLisReportDg').datagrid("loadData", obj.Data);
                        // var row = $('#NormalLisReportDg').datagrid('getRows');
                    }
                }
            }
        });
    }
    ajaxLoadEnd();
}
//查询PatientDiagnose数据
function GetPatientDiagnoseInfo() {
    //<Request>
    //  <cardno></cardno>
    //  <cxrq00></cxrq00>
    //</Request>
    var code = $('#oldCode').textbox('getValue');
    var codeType = $('#oldCodeType').textbox('getValue');
    if (code) {
        var dateNow = AddDays(new Date(), 0).toDateString();
        $.ajax({
            type: "POST",
            url: "/Sever/PatientDiagnose.ashx",
            data: {
                "mode": "qry",
                "code": code,
                "codeType": codeType,
                "dateNow": dateNow
            },
            success: function (data) {
            if (!data) { $.messager.alert('提示', '查询不到数据,请检查数据是否存在！', 'error') }
            else {
                var obj = $.parseJSON(data);
                if (obj.Statu == "err") {
                    ShowMsg("诊断数据：" + obj.Msg);
                    return;
                }
                else if (obj.Statu == "ok") {
                    $('#PatientDiagnoseDg').datagrid("loadData", obj.Data);
                    // var row = $('#NormalLisReportDg').datagrid('getRows');
                }
            }
        }
        });
    }
    ajaxLoadEnd();
}
//清除控件值
function clearForm() {
    $('#BaseInfoForm').form('clear');
    $('#NormalLisReportDg').datagrid('loadData', { total: 0, rows: [] });
    $('#PatientDiagnoseDg').datagrid('loadData', { total: 0, rows: [] });
}
//条码框按钮回车事件
$(function () {
    $("input", $("#code").next("span")).keydown(function (e) {
        if (e.keyCode == 13) { querybycode(); }
    });
});
//ESC事件,点击ESC后清空所有值
$(document).keyup(function (e) {
    var key = e.which;
    if (key == 27
        ) {
        clearForm();
    }
});
//F2快捷键
$(document).keyup(function (e) {
    var key = e.which;
    if (key == 113) {
        postPatientInfo();
    }
});
//点击确定按钮提交请求
function getdatabybarcode() {
    var code = $('#barcodebox').textbox('getValue');
    if ($.trim(code)) { barcode(code); var code = $('#barcodebox').textbox('clear'); }
    var code = $('#barcodebox').textbox('clear');
}
//POST数据
function postPatientInfo() {
    //验证表单
    var username = $.cookie('username');
    var kk = $("#BaseInfoForm").form('validate');
    if (kk) {
        postEmpiInfo();
    }
}
function getSampleInfoFormData() {
    var sampleinfo = $("#SampleInfoForm").serializeArray();
    var ii = $("#_116").combobox('getText');
    var base;
    if (sampleinfo) { base = JSON.stringify(sampleinfo); }
    return base;
}
//添加值到ClinicalInfoDg
function submitFormClinicalInfoDg() {
    //验证当前表单？？
    var isValid = $('#setClinicalInfoDg').form('validate');
    if (isValid) {
        var from = $('#setClinicalInfoDg').serializeArray();
        $('#ClinicalInfoDg').datagrid('insertRow', {
            index: 1,	// 索引从0开始
            row: {
                DiagnoseTypeFlag: from[0].value,
                DiagnoseDateTime: from[1].value,
                ICDCode: from[2].value,
                DiseaseName: from[3].value,
                Description: from[4].value
            }
        });
        $('#setClinicalInfoDg').form('clear');
        $('#w').window('close');
    }
}
function clearsetClinicalInfoDg() { $('#setClinicalInfoDg').form('clear'); }
//添加样本信息到Dg
function AddSampleInfoToDg() {
    var isValid = $('#sampleInfoFormToDg').form('validate');
    if (isValid) {
        var from = $('#sampleInfoFormToDg').serializeArray();
        $('#dg_SampleInfo').datagrid('insertRow', {
            index: 1,	// 索引从0开始
            row: {
                SampleType: from[0].value,
                Volume: from[1].value,
                Scount: from[2].value
            }
        });
    }
}
function clearSampleInfoAddForm() { $('#sampleInfoFormToDg').form('clear'); }
//采用jquery easyui loading css效果
function ajaxLoading() {
    $("<div class=\"datagrid-mask\"></div>").css({ display: "block", width: "100%", height: $(window).height() }).appendTo("body");
    $("<div class=\"datagrid-mask-msg\"></div>").html("正在处理，请稍候。。。").appendTo("body").css({ display: "block", left: ($(document.body).outerWidth(true) - 190) / 2, top: ($(window).height() - 45) / 2 });
}
function ajaxLoadEnd() {
    $(".datagrid-mask").remove();
    $(".datagrid-mask-msg").remove();
}

function ShowMsg(msg) {
    $.messager.show({
        title: "提示",
        msg: msg,
        timeout: 2000,
        showType: 'fade'
    });
}