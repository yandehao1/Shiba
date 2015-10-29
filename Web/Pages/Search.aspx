<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="RuRo.Web.Pages.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查询数据</title>
    <link rel="stylesheet" type="text/css" href="../../include/jquery-easyui-1.4.3/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../../include/jquery-easyui-1.4.3/themes/icon.css" />
    <script type="text/javascript" src="../../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script type="text/javascript" src="../../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../../include/jquery-easyui-1.4.3/locale/easyui-lang-zh_CN.js"></script>
    <link rel="stylesheet" type="text/css" href="../../include/css/kfmis.css" />
    <script type="text/javascript" src="../../include/js/jquery.cookie.js"></script>
    <script type="text/javascript" src="../include/js/default.js"></script>
    <script type="text/javascript" src="../include/js/page.js"></script>
    <style type="text/css">
        #SearchForm {
           margin: 5px;
        }
        #SearchForm div{margin:5px}
    </style>
</head>
<body style="width: 1000px">
    <div class="easyui-panel">
        <form id="SearchForm" runat="server">
            <div style="float: left">
                查询方式：
                    <select id="ss" class="easyui-combobox" name="dept" style="width: 130px;">
                        <option value="1">编码</option>
                        <option value="2">日期</option>
                    </select>
            </div>
            <div id="getcode" style="float: left">
                <input id="code" class="easyui-textbox" name="code" data-options="prompt:'请输入条码',required:true" />
                <a href="javascript:void(0)" class="easyui-linkbutton" id="btnGet" name="btnGet" plain="false" onclick="querybycode()">条码查询信息</a>
            </div>
            <div id="getdate" style="display: none; float: left">
                开始日期：<input id="ksrq" class="easyui-datebox" name="ksrq" data-options="required:true" style="width: 130px" />
                结束日期：<input id="jsrq" class="easyui-datebox" name="jsrq" data-options="required:true" style="width: 130px" />
                <a href="javascript:void(0)" class="easyui-linkbutton" id="btnGet" name="btnGet" plain="false" onclick="querybydate()">日期查询信息</a>
            </div>
            <!--Search end-->
        </form>
    </div>
    <div class="easyui-panel" style="float: left; margin-top: 10px;" data-options="href:'OPListForSpecimen/OPListForSpecimen_list.aspx'"></div>
    <script type="text/javascript">
        //给日期框设置值
        function SetDate() {
            var begindate = new Date();
            $('#ksrq').textbox('setValue', myformatter(begindate))
            $('#jsrq').textbox('setValue', myformatter(begindate))
        }
        var getdatageid;
        //样品数据绑定
        $(function () {
            $('#ss').combobox({
                onChange: function (newValue) {
                    if (newValue == 2) {
                        //日期
                        $("#getdate").show();
                        $("#getcode").hide();
                        SetDate();
                    }
                    else {
                        $("#getdate").hide();
                        $("#getcode").show();
                    }
                }
            });
        })
        //绑定数据 条码
        function querybycode() {
            var code = $('#code').textbox('getValue');//获取数据源
            if (/.*[\u4e00-\u9fa5]+.*$/.test(code)) { $.messager.alert('错误', '不能输入中文', 'error'); $('#code').textbox('clear'); return; }
            if (code.length > 14) { $.messager.alert('错误', '条码最高不能超过15位', 'error'); $('#code').textbox('clear'); return; }
            if (code == "") { $.messager.alert('提示', '条码不能为空', 'error'); }
            else {
                ajaxLoading();
                $.ajax({
                    type: 'GET',
                    url: '/Sever/OPListForSpecimen_handler.ashx?mode=qrycode&code=' + code,
                    onSubmit: function () { },
                    success: function (data) {
                        ajaxLoadEnd();
                        $('#code').textbox('setValue', '');
                        if (!data) { $.messager.alert('提示', '查询不到数据,请检查数据是否存在！', 'error'); }
                        else {
                            $('#dd').window({
                                title: '详细数据页面',
                                width: 700,
                                height: 500,
                                modal: true,
                                href: 'OPListForSpecimen/OPListForSpecimen_info.aspx',
                                onLoad: function () {
                                    var basedata = $.parseJSON(data);
                                    $("#frmAjax").form("load", basedata);
                                }
                            });
                        }
                    }
                });
                ajaxLoadEnd();
            }
        }
        //绑定数据日期
        function querybydate() {
            var ksdate = $('#ksrq').textbox('getValue');
            var jsdate = $('#jsrq').textbox('getValue');
            if (!checkdate(ksdate) || !checkdate(jsdate)) {
                $.messager.alert('提示', '日期格式不正确', 'error'); return;
            }
            //if (/.*[\u4e00-\u9fa5]+.*$/.test(code)) { $.messager.alert('错误', '不能输入中文', 'error'); $('#ksrq').textbox('clear'); return; }
            if (isEmptyStr(ksdate) || isEmptyStr(jsdate)) { $.messager.alert('提示', '日期不能为空', 'error'); return; }
            else {
                ajaxLoading();
                $.ajax({
                    type: 'GET',
                    url: '../Sever/OPListForSpecimen_handler.ashx?mode=qrydate&ksdate=' + ksdate + '&jsdate=' + jsdate,
                    onSubmit: function () { },
                    success: function (data) {
                        ajaxLoadEnd();
                        if (!data) { $.messager.alert('提示', '查询不到数据,请检查数据是否存在！', 'error'); }
                        else {
                            var loaddata = $.parseJSON(data);
                            //$('#OPListForSpecimen').datagrid('loadData', loaddata);
                            PagePaging(loaddata);
                        }
                    }
                });
                ajaxLoadEnd();
            }
        }
    </script>
</body>
</html>
