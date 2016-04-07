<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info_list.aspx.cs" Inherits="RuRo.Web.Pages.ShiBa.Info_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head">
    <title>Info</title>
    <link rel="stylesheet" type="text/css" href="/js/easyui/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/js/easyui/themes/icon.css" />
    <script type="text/javascript" src="/js/easyui/jquery.min.js"></script>
    <script type="text/javascript" src="/js/easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/js/easyui/locale/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="/js/gridPrint.js"></script>
    <link rel="stylesheet" type="text/css" href="/css/kfmis.css" />

</head>
<body>
    <!--datagrid栏-->
    <table id="Info_datagrid" title="信息列表页面" class="easyui-datagrid" style="width: auto; height: 460px; text-align: center"
        url="../Fp_Ajax/getData.ashx?mode=qry" fit='false'
        pagination="true" idfield="PatientId" rownumbers="true"
        fitcolumns="true" singleselect="true" toolbar="#toolbar"
        striped="false" pagelist="[10,30,50]"
        selectoncheck="true" checkonselect="true" remotesort="false" multisort="true">
        <thead>
            <tr>
                <th field="ck" checkbox="true" hidden="true"></th>
                <th field="id" width="100" sortable="true" hidden="true">id</th>
                <th field="部门" width="100" sortable="true">部门</th>
                <th field="姓名" width="100" sortable="true">姓名</th>
                <th field="性别" width="100" sortable="true">性别</th>
                <th field="年龄" width="100" sortable="true">年龄</th>
                <th field="医生" width="100" sortable="true" hidden="true">医生</th>
                <th field="流水号" width="100" sortable="true">流水号</th>
                <th field="卡号" width="100" sortable="true">卡号</th>
                <th field="PATIENT_NO" width="100" sortable="true">住院号</th>
                <th field="病历号" width="100" sortable="true">病历号</th>
                <th field="诊断" width="100" sortable="true">诊断</th>
                <th field="日期" width="100" sortable="true" hidden="true">日期</th>
            </tr>
        </thead>
    </table>

    <!--toolbar栏，用于datagrid的toolbar自定义内容-->
    <div id="toolbar">
        <table style="width: 100%;">
            <tr>
                <!--button按钮工具栏-->
                <td style="text-align: right;"></td>
            </tr>
        </table>
    </div>

    <!--diaglog窗口，用于编辑数据-->
    <div id="dlg" class="easyui-dialog" closed="true"></div>
    <div id="dd"></div>
    <script type="text/javascript">
        $(function () {
            //绑定双击行事件
            $('#Info_datagrid').datagrid({
                onDblClickRow: function (rowIndex, rowData) {
                    showData(rowData);
                }
            });
            //绑定列排序事件
            $("datagrid").datagrid({
                onSortColumn: function (sort, order) {
                    sortData(sort, order);
                }
            })
        })

        function PagePaging(loaddata) {
            //for (var i = 0; i < loaddata.length; i++) {
            //    var text = loaddata[i].DeptCode.split("-");
            //    loaddata[i].DeptCodeName = text[1];
            //    var age = 0
            //    if (loaddata[i].DateOfBirth != "") {
            //        var old = new Date(loaddata[i].DateOfBirth);
            //        var now = new Date();
            //        if (now.getTime() > old.getTime()) {
            //            age = now.getFullYear() - old.getFullYear();
            //        }
            //    }
            //    loaddata[i].DateOfAge = age.toString();
            //}
            $("#Info_datagrid").datagrid({
                data: loaddata.slice(0, 10)
            });
            var pager = $("#Info_datagrid").datagrid("getPager");
            pager.pagination({
                total: loaddata.length,
                onSelectPage: function (pageNo, pageSize) {
                    var start = (pageNo - 1) * pageSize;
                    var end = start + pageSize;
                    $("#Info_datagrid").datagrid("loadData", loaddata.slice(start, end));
                    pager.pagination('refresh', {
                        total: loaddata.length,
                        pageNumber: pageNo
                    });
                }
            });
        }
        function sortData(sort, order) {
            //alert('排序，要写...'+sort+':'+order);
        }
        var url;

        function showData(rowData) {
            if (!rowData) { $.messager.alert('提示', '请检查数据是否存在！', 'error'); }
            else {
                $('#dd').window({
                    title: '详细数据页面',
                    width: 800,
                    height: 400,
                    modal: true,
                    href: 'ShiBa/Info_info.aspx',
                    onLoad: function () {
                        $("#frmAjax").form("load", rowData);
                    }
                });
            }
        }
        /*查看数据*/
        function infoForm() {
            var rows = $('#datagrid').datagrid('getSelections');
            if (rows.length > 0) {
                if (rows.length == 1) {
                    var row = $('#datagrid').datagrid('getSelected');
                    $('#dlg').dialog({
                        title: '查看数据',
                        width: 650,
                        height: 400,
                        closed: false,
                        cache: true,
                        href: 'Info_info.aspx?mode=inf&pk=' + row.id
                    });
                } else {
                    $.messager.alert('警告', '查看操作只能选择一条数据', 'warning');
                }
            } else {
                $.messager.alert('警告', '请选择数据', 'warning');
            }
        }

        /*修改数据*/
        function editForm() {
            var rows = $('#datagrid').datagrid('getSelections');
            if (rows.length > 0) {
                if (rows.length == 1) {
                    var row = $('#datagrid').datagrid('getSelected');
                    $('#dlg').dialog({
                        title: 'Info-修改数据',
                        width: 650,
                        height: 400,
                        closed: false,
                        cache: true,
                        href: 'Info_info.aspx?mode=upd&pk=' + row.id
                    });
                } else {
                    $.messager.alert('警告', '修改操作只能选择一条数据', 'warning');
                }
            } else {
                $.messager.alert('警告', '请选择数据', 'warning');
            }
        }

        /*删除选择数据,多条记录PK主键参数用逗号,分开*/
        //function destroy() {
        //    var rows = $('#datagrid').datagrid('getSelections');
        //    if (rows.length > 0) {
        //        var pkSelect = "";
        //        for (var i = 0; i < rows.length; i++) {
        //            row = rows[i];
        //            if (i == 0) {
        //                pkSelect += row.id;
        //            } else {
        //                pkSelect += ',' + row.id;
        //            }
        //        }
        //        $.messager.confirm('提示', '是否确认删除数据？', function (r) {
        //            if (r) {
        //                $.post('Info_handler.ashx?mode=del&pk=' + pkSelect, function (result) {
        //                    if (result.success) {
        //                        $.messager.alert('提示', result.msg, 'info', function () {
        //                            $('#datagrid').datagrid('reload');    //重新加载载数据
        //                        });
        //                    } else {
        //                        $.messager.alert('错误', result.msg, 'warning');
        //                    }
        //                }, 'json');
        //            }
        //        });
        //    } else {
        //        $.messager.alert('警告', '请选择数据', 'warning');
        //    }
        //}

        /*查询条件参数构建*/
        function getSearchParm() {
            //增加条件，请追加参数名称
            /*combobox值获取方法,用于下拉条件查询条件组合*/
            //var v_so_字段名称 = $('#so_字段名称').combobox('getValue');
            var v_parm
            var v_so_keywords = $('#so_keywords').searchbox('getValue');
            v_parm = 'so_keywords=' + escape(v_so_keywords);
            return v_parm;
        }

        /*查询数据*/
        function searchData() {
            /*兼顾导出Excel公用条件，在这里datagrid不用load函数加载参数，直接用URL传递参数*/
            var Parm = getSearchParm();//获得查询条件参数构建，用URL传递查询参数
            var QryUrl = '../Fp_Ajax/getData.ashx?mode=qry&' + Parm;
            $('#datagrid').datagrid({ url: QryUrl });
        }
        /*关闭dialog重新加载datagrid数据*/
        $('#dlg').dialog({
            onClose: function () {
                $('#datagrid').datagrid('reload'); //重新加载载数据
            }
        });

    </script>
</body>
</html>
