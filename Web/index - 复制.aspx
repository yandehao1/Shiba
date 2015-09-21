<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FreezerProPlugin.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>FreezerPro Enterprise</title>
    <link href="include/jquery-easyui-1.4.1/themes/default/easyui.css" rel="stylesheet" />
    <link href="include/jquery-easyui-1.4.1/themes/icon.css" rel="stylesheet" />
    <link href="include/css/default.css" rel="stylesheet" />
    <script src="include/jquery-easyui-1.4.1/jquery.min.js"></script>
    <script src="include/jquery-easyui-1.4.1/jquery.easyui.min.js"></script>
    <script src="include/js/default.js"></script>
</head>
<body id="body">
    <iframe runat="server" id="FreezerPro" name="FreezerPro" frameborder="0"></iframe>
    <!--菜单栏-->
    <div id="MenuBar" runat="server"></div>
    <!--登陆框-->
    <div id="Login" class="easyui-dialog" style="width: 300px; padding: 30px 50px 20px 50px" title="请登录助手" closed="true">
        <form id="frmLogin" runat="server" enableviewstate="false">
            <div style="margin-bottom: 10px">
                <input class="easyui-textbox" id="username" name="username" style="width: 100%; height: 40px; padding: 12px" data-options="prompt:'username',iconCls:'icon-man',iconWidth:38">
            </div>
            <div style="margin-bottom: 20px">
                <input class="easyui-textbox" id="password" name="password" style="width: 100%; height: 40px; padding: 12px" type="password" data-options="prompt:'password',iconCls:'icon-lock',iconWidth:38">
            </div>
            <div style="text-align: center; padding: 5px">
                <a href="javascript:void(0)" style="margin: 0px 10px 0px 10px" class="easyui-linkbutton" onclick="login()">登陆</a>
                <a href="javascript:void(0)" style="margin: 0px 10px 0px 10px" class=" easyui-linkbutton" onclick="$('#Login').dialog('close')">取消</a>
            </div>
        </form>
    </div>
    <!--日期选择框-->
    <div id="dodatesearch" class="easyui-dialog" title="请选择日期" style="width: 400px; padding: 10px 10px 10px 10px;" closed="true">
        <form id="dateform">
            <input class="easyui-datebox" name="begindate" id="begindate" data-options="required:true,showSeconds:false,prompt:'开始日期'">
            <input class="easyui-datebox" name="enddate" id="enddate" data-options="required:true,showSeconds:false,prompt:'结束日期'" />
            <a href="javascript:void(0)" class="easyui-linkbutton" onclick="dateSearch()">确定</a>
        </form>
    </div>
    <!--条码输入框-->
    <div id="barcodeiputbox" class="easyui-dialog" title="请输入条码" closed="true">
        <input class="easyui-textbox" name="barcodebox" id="barcodebox" onclick="barcode" data-options="required:true,showSeconds:false,prompt:'输入条码'">
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="getdatabybarcode()">确定</a>
    </div>
    <!--主体显示面板-->
    <div id="mainopanels" class="easyui-window" style="width: 60%; height: 60%; padding: 0px;" border="false" title="FP功能扩展" closed="true" runat="server" enableviewstate="false">
        <!--菜单按钮区-->
        <div id="menu" style="padding: 5px,10px">
            <a id="barcodeimportbtn" name="barcodeimportbtn" href="#" class="easyui-linkbutton" onclick="openbarcodeiputbox()">条码查询</a>
            <a id="dateimportbtn" name="dateimportbtn" href="#" class="easyui-linkbutton" onclick="doquerydatabytime()">日期查询</a>
            <a id="batchImport" name="batchImport" href="#" class="easyui-linkbutton" onclick="batchImport()">批量导入</a>
            <a id="menzhenhaoimportbtn" name="barcodeimportbtn" href="#" class="easyui-linkbutton" onclick="removeSelections()">删除</a>
            <a id="respondhsi" name="barcodeimportbtn" href="#" class="easyui-linkbutton" onclick="reshis()">回发</a>
        </div>
        <!--显示面板-->
        <div id="dgcontent" style="width: 100%;">
            <table id="sampleSourceDataGrid" class="easyui-datagrid" title="样品源信息" style="width: 100%"
                data-options="onClickRow: onClickRow,singleSelect: false,checkOnSelect:true,rownumbers:true" runat="server">
                <thead>
                    <tr>
                        <th data-options="field:'ck',checkbox:true" width="5%"></th>
                        <th data-options="field:'sampleSourceType',formatter:function(value,row){return row.sampleSourceTypeName;},
                            editor:{
                            type:'combobox',
                            options:{
                            valueField:'sampleSourceType',
                            textField:'sampleSourceTypeName',
                            method:'get',
                            url:'GetData.ashx?type=getSampleSourceType',
							required:true}
                            }"
                            width="15%">源类型</th>
                        <th data-options="field:'sampleSourceName',editor:'text'" width="15%">源名称</th>
                        <th data-options="field:'sampleSourceDescription',editor:'text'" width="10%">源描述</th>
                        <th data-options="field:'patientName'" width="10%">姓名</th>
                        <th data-options="field:'importStatus'" width="10%">状态</th>
                        <th data-options="field:'scheduledDateTime'" width="10%">预约手术日期</th>
                        <th data-options="field:'diagBeforeOperation'" width="10%">主要诊断</th>
                        <th data-options="field:'hidden'" hidden="hidden"></th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
</body>
</html>
