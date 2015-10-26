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
    <script type="text/javascript" src="../../include/js/page.js"></script>
</head>
<body>
    <form id="SearchForm" runat="server">
        <!--Search -->
        <%--    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td style="width: 80px" align="right" class="tdbg">
                <select id="cc" class="easyui-combobox" name="dept" style="width:200px;">   
                    <option value="1">编码</option>   
                    <option value="2">日期</option>    
                </select>  
            </td>
            <td class="tdbg">
                <div id="getcode">
                    <input id="code" class="easyui-textbox" name="code" data-options="prompt:'请输入条码',required:true" />
                    <a href="javascript:void(0)" class="easyui-linkbutton" id="btnGet" name="btnGet" plain="false" onclick="querybycode()">条码查询患者信息</a>
                </div>
                <div id="getdate" style="visibility: hidden">
                    <div>
                        开始日期：<input id="ksrq" class="easyui-datebox" name="ksrq" data-options="required:false" />
                    </div>
                    <div>
                        结束日期：<input id="jsrq" class="easyui-datebox" name="jsrq" data-options="required:false" />
                    </div>
                     <a href="javascript:void(0)" class="easyui-linkbutton" id="btnGet" name="btnGet" plain="false" onclick="">日期查询信息</a>
                </div>
            </td>
            <td class="tdbg"></td>
        </tr>
    </table>--%>
        <div style="display: inline;">
            <div style="float: left">
                <select id="cc" class="easyui-combobox" name="dept" style="width: 200px;">
                    <option value="1">编码</option>
                    <option value="2">日期</option>
                </select>
            </div>
            <div id="getcode" style="float: left ;display:block">
                <input id="code" class="easyui-textbox" name="code" data-options="prompt:'请输入条码',required:true" />
                <a href="javascript:void(0)" class="easyui-linkbutton" id="btnGet" name="btnGet" plain="false" onclick="querybycode()">条码查询患者信息</a>
            </div>
            <div id="getdate" style="visibility: hidden; display: inline;">
                <div style="float: right">
                    开始日期：<input id="ksrq" class="easyui-datebox" name="ksrq" data-options="required:true" />
                </div>
                <div style="float: right">
                    结束日期：<input id="jsrq" class="easyui-datebox" name="jsrq" data-options="required:true" />
                </div>
                <div style="float: right">
                    <a href="javascript:void(0)" class="easyui-linkbutton" id="btnGet" name="btnGet" plain="false" onclick="">日期查询信息</a>
                </div>
            </div>
        </div>
        <!--Search end-->
    </form>
    <script type="text/javascript">
        $(function () {
            $('#cc').combobox({
                onChange: function (newValue) {
                    if (newValue == 2) {
                        document.getElementById("getcode").style.display = "none";
                        document.getElementById("getdate").style.display = "block";
                    }
                    else {
                        document.getElementById("getdate").style.display = "none";
                        document.getElementById("getcode").style.display = "block";
                    }
                }
            });
        })
        //绑定数据 条码
        function querybycode() {
            var code = $('#code').textbox('getValue');//获取数据源
            if (/.*[\u4e00-\u9fa5]+.*$/.test(code)) { $.messager.alert('错误', '不能输入中文', 'error'); $('#code').textbox('clear'); return; }
            if (code.length > 14) { $.messager.alert('错误', '条码最高不能超过15位', 'error'); $('#code').textbox('clear'); return; }
            if (isEmptyStr(code)) { $.messager.alert('提示', '请检查条码号', 'error'); }
            else {
                ajaxLoading();
                $.ajax({
                    type: 'GET',
                    url: '../Sever/OPListForSpecimen_handler.ashx?mode=qrycode&code=' + code,
                    onSubmit: function () { },
                    success: function (data) {
                        alert(data);
                        ajaxLoadEnd();
                        $('#code').textbox('setValue', '');
                        if (!data) { $.messager.alert('提示', '查询不到数据,请检查数据是否存在！', 'error'); }
                        else {
                            //弹出窗口

                            //赋值
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
            if (/.*[\u4e00-\u9fa5]+.*$/.test(code)) { $.messager.alert('错误', '不能输入中文', 'error'); $('#ksrq').textbox('clear'); return; }
            if (isEmptyStr(ksdate) || isEmptyStr(jsdate)) { $.messager.alert('提示', '请检查条码类型和条码号', 'error'); }
            else {
                ajaxLoading();
                $.ajax({
                    type: 'GET',
                    url: '../Sever/OPListForSpecimen_handler.ashx?mode=qrydate&ksdate=' + ksdate + '&jsdate=' + jsdate,
                    onSubmit: function () { },
                    success: function (data) {
                        ajaxLoadEnd();
                        //$('#ksrq').textbox('setValue', '');
                        //$('#jsrq').textbox('setValue', '');
                        clearForm();
                        if (!data) { $.messager.alert('提示', '查询不到数据,请检查数据是否存在！', 'error'); }
                        else {
                            //测试代码
                        }
                    }
                });
                ajaxLoadEnd();
            }
        }
    </script>
</body>
</html>
