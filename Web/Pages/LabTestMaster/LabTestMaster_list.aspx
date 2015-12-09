<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LabTestMaster_list.aspx.cs" Inherits="RuRo.LabTestMaster_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head">
    <title>检测信息</title>
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
    <table id="datagrid" title="LabTestMaster--临床检测数据" class="easyui-datagrid" style="width: auto; height: 460px; text-align: center"
        fit='false'
        pagination="false" idfield="TestNo" rownumbers="true"
        fitcolumns="true" singleselect="true" toolbar="#toolbar"
        striped="false" pagelist="[15,30,50,100,500]"
        selectoncheck="true" checkonselect="true" remotesort="true">
        <thead>
            <tr>
                <th field="id" width="100" sortable="true" hidden="true">id</th>
                <th field="TestNo" width="100" sortable="true">检验申请单号</th>
                <th field="priorityIndicator" width="100" sortable="true" hidden="true">优先标志</th>
                <th field="WorkingId" width="100" sortable="true">工作单号</th>
                <th field="TestCause" width="100" sortable="true">检验目的</th>
                <th field="RelevantClinicDiag" width="100" sortable="true">临床诊断</th>
                <th field="Specimen" width="100" sortable="true">标本</th>
                <th field="SpcmReceivedDateTime" width="100" sortable="true">采样时间</th>
                <th field="OrderingDept" width="100" sortable="true">开医嘱科室</th>
                <th field="orderingProvider" width="100" sortable="true" hidden="true">医生工号</th>
                <th field="PerformedBy" width="100" sortable="true">执行科室</th>
                <th field="ResultStatus" width="100" sortable="true" hidden="true">执行情况</th>
                <th field="ResultsRptDateTime" width="100" sortable="true" hidden="true">报告完成时间</th>
                <th field="transcriptionist" width="100" sortable="true" hidden="true">报告者工号</th>
                <th field="VerifiedBy" width="100" sortable="true" hidden="true">审核者工号</th>
            </tr>
        </thead>
    </table>

    <!--toolbar栏，用于datagrid的toolbar自定义内容-->
    <div id="toolbar">
        <table style="width: 100%;">
            <tr>
                <td style="text-align: right;">
                    <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonDel" iconcls="icon-search" plain="false" onclick="getLabTestResult();">查看详细检测值</a>
                </td>
            </tr>
        </table>
    </div>
    <!--diaglog窗口，用于编辑数据-->
    <div id="dlg" class="easyui-dialog" closed="true"></div>
    <div id="winmaster"></div>
    <div id="master"></div>
<input id="workingId" class="easyui-textbox" name="name" disabled="disabled"  hidden="false" />
<input id="testNo" class="easyui-textbox" name="name" disabled="disabled"  hidden="false" />

    <script type="text/javascript">
        function showLabTestMasterData(rowData) {
            if (!rowData) { $.messager.alert('提示', '请检查数据是否存在！', 'error'); }
            else {
                $('#master').window({
                    title: 'LabTestMaster--详细数据页面',
                    width: 800,
                    height: 500,
                    modal: true,
                    href: '/Pages/LabTestMaster/LabTestMaster_info.aspx?mod=inf',
                    onLoad: function () {
                        //var basedata = $.parseJSON(rowData);
                        //$("#frmAjax").form("load", basedata);
                        $("#frmAjax").form("load", rowData);
                    }
                });
            }
        }
        $(function () {
            //绑定双击行事件
            $('#datagrid').datagrid({
                onDblClickRow: function (rowIndex, rowData) {
                    showLabTestMasterData(rowData);
                }
            });
            //绑定列排序事件
            //$("#datagrid").datagrid({
            //    onSortColumn: function (sort, order) {
            //        //sortData(sort, order);
            //    }
            //})
        })
        /*关闭dialog重新加载datagrid数据*/
        $('#dlg').dialog({
            onClose: function () {
                $('#datagrid').datagrid('reload'); //重新加载载数据
            }
        });
        function loadTestResultData(workingId, testNo) {
            $('#name').textbox('setValue', "患者姓名");
            loadData({ total: 0, rows: [] });
            $.ajax({
                type: "get",
                url: "/Sever/LabTest.ashx?mod=getLTR&workingId=" + workingId + "&testNo=" + testNo,
                dataType: "json",
                success: function (response) {
                    if (response) {
                        // var data = JSON.parse(response);
                        var data = response;
                        if (data.State == "0") {
                            if (data.Data.ResultCode == 0) {
                                //获取数据成功
                                $("#datagridLTR").datagrid("loadData", data.Data.LabTestResul);
                                //$('#name').textbox('setValue', data.Data.Name);
                            } else {
                                //获取数据失败
                                alert(data.Data.ResultContent)
                            }
                        }
                        else if (data.State == "err") {
                            alert(data.Msg);
                        }
                        else {
                            alert("查询数据错误请检查数据")
                        }
                    } else {
                        alert("查询数据错误请检查数据")
                    }
                }
            });
        }
        function getLabTestResult() {
            var rows = $('#datagrid').datagrid('getSelections');
            if (rows.length > 0) {
                if (rows.length == 1) {
                    var row = $('#datagrid').datagrid('getSelected');
                    $('#winmaster').window({
                        title: 'LabTestMaster-查看结果',
                        width: 800,
                        height: 500,
                        modal: true,
                        href: '/Pages/LabTestResult/LabTestResult_list.aspx',
                        onOpen: function () {
                            loadTestResultData(row.WorkingId, row.TestNo);
                        }
                    })
                } else {
                    $.messager.alert('警告', '查看结果操作只能选择一条数据', 'warning');
                }
            } else {
                $.messager.alert('警告', '请选择数据', 'warning');
            }
        }
        function loadData(data) {
            $("#datagrid").datagrid("loadData", data);
        }

    </script>

</body>
</html>
