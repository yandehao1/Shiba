<!--基础代码由科发EasyUi代码生成器v3.5(build 20140519)代码生成器生成,免费版自动增加版权注释,请保留版权信息，尊重作者劳动成果，如您有更好的建议请发至邮箱：843330160@qq.com-->
<!--编辑表单form与datagrid列表数据分别放在两个独立的aspx页面中-->
<!--datagrid页面:LabTestResult_list.aspx-->

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LabTestResult_list.aspx.cs" Inherits="RuRo.LabTestResult_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head">
    <title>LabTestResult</title>
    <link rel="stylesheet" type="text/css" href="../../include/jquery-easyui-1.4.3/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../../include/jquery-easyui-1.4.3/themes/icon.css" />
    <script type="text/javascript" src="../../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script type="text/javascript" src="../../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../../include/jquery-easyui-1.4.3/locale/easyui-lang-zh_CN.js"></script>
    <link rel="stylesheet" type="text/css" href="../../include/css/kfmis.css" />
    <script type="text/javascript" src="../../include/js/page.js"></script>
    <script type="text/javascript" src="../../include/js/jquery.cookie.js"></script>
</head>
<body>
    <!--datagrid栏-->
    <table id="datagridLTR" class="easyui-datagrid" style="width: auto; height: 460px"
        fit='false'
        pagination="false" idfield="ReportItemName" rownumbers="true"
        fitcolumns="true" singleselect="true"
        striped="false" pagelist="[15,30,50,100,500]"
        selectoncheck="true" checkonselect="true" remotesort="true">
        <thead>
            <tr>
                <th field="id" width="100" sortable="true" hidden="true">id</th>
                <th field="ReportItemName" width="100" sortable="true">子项名称</th>
                <th field="ReportItemCode" width="100" sortable="true">子项编码</th>
                <th field="AbnormalIndicator" width="100" sortable="true">结果</th>
                <th field="Result" width="100" sortable="true">正文描述</th>
                <th field="Units" width="100" sortable="true">检验结果</th>
                <th field="ResultDateTime" width="100" sortable="true">检验日期及时间</th>
                <th field="ReferenceResult" width="100" sortable="true">结果参考值</th>
            </tr>
        </thead>
    </table>
    <!--toolbar栏，用于datagrid的toolbar自定义内容-->
    <!--diaglog窗口，用于编辑数据-->
    <div id="dlg" class="easyui-dialog" closed="true"></div>
    <div id="win" class="easyui-window" closed="true"></div>
    <script type="text/javascript">
        function showLabTestResult_listData(rowData) {
            if (!rowData) { $.messager.alert('提示', '请检查数据是否存在！', 'error'); }
            else {
                $('#win').window({
                    title: 'LabTestResult_list--详细数据页面',
                    width: 800,
                    height: 500,
                    modal: true,
                    href: '/Pages/LabTestResult/LabTestResult_info.aspx?mod=inf',
                    onLoad: function () {
                        $("#frmAjaxLTR").form("load", rowData);
                    }
                });
            }
        }
        $(function () {
            //绑定双击行事件
            $('#datagridLTR').datagrid({
                onDblClickRow: function (rowIndex, rowData) {
                    showLabTestResult_listData(rowData);
                }
            });
        })
        /*关闭dialog重新加载datagrid数据*/
        //$('#dlg').dialog({
        //    onClose: function () {
        //        $('#datagridLTR').datagrid('reload'); //重新加载载数据
        //    }
        //});
    </script>

</body>
</html>
