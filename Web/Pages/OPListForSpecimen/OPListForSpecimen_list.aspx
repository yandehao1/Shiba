<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OPListForSpecimen_list.aspx.cs" Inherits="RuRo.OPListForSpecimen_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head">
    <title>查询页面</title>
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
    <table id="OPListForSpecimen" title="日期查询" class="easyui-datagrid" style="width: auto; height: 460px;text-align:center"
        url="OPListForSpecimen_handler.ashx?mode=qrydate" fit='false'
        pagination="true" idfield="PatientId" rownumbers="true"
        fitcolumns="true" singleselect="true" toolbar="#toolbar"
        striped="false" pagelist="[10,30,50]"
        selectoncheck="true" checkonselect="true" remoteSort="false" multiSort="true">
        <thead>
            <tr>
                <%--<th field="ck" checkbox="true"></th>--%>
                <th field="id" width="100"  hidden="true" >id</th>
                <th field="PatientId" width="10%" sortable="true">病人唯一标识号</th>
                <th field="InpNO" width="10%" sortable="true">住院号</th>
                <th field="VisitId" width="10%" sortable="true">就诊号</th>
                <th field="Name" width="10%" sortable="true">姓名</th>
                <th field="NamePhonetic" width="100"  hidden="true">姓名拼音</th>
                <th field="DateOfBirth" width="100"  hidden="true">出生日期</th>
                <th field="BirthPlace" width="100"  hidden="true">行政区名称</th>
                <th field="Citizenship" width="100"  hidden="true">国家简称</th>
                <th field="Nation" width="100"  hidden="true">民族</th>
                <th field="IDNO" width="100" " hidden="true" >身份证号</th>
                <th field="Identity" width="100"  hidden="true">患者工作身份</th>
                <th field="ChargeType" width="100"  hidden="true">病人收费类别</th>
                <th field="MailingAddress" width="100"  hidden="true">永久通信地址</th>
                <th field="ZipCode" width="100"  hidden="true">邮政编码</th>
                <th field="PhoneNumberHome" width="100"  hidden="true">家庭电话号码</th>
                <th field="PhoneNumbeBusiness" width="100"  hidden="true">单位电话号码</th>
                <th field="NextOfKin" width="100" hidden="true">亲属姓名</th>
                <th field="RelationShip" width="100"  hidden="true">亲属关系</th>
                <th field="NextOfKinAddr" width="100" hidden="true">联系人地址</th>
                <th field="NextOfKinZipCode" width="100" hidden="true">联系人邮政编码</th>
                <th field="NextOfKinPhome" width="100" hidden="true">联系人电话号码</th>
                <th field="DeptCode" width="15%" sortable="true">科室代码@名称</th>
                <th field="BedNO" width="100" hidden="true">病人所住床号</th>
                <th field="AdmissionDateTime" width="100" hidden="true">入院日期及时间</th>
                <th field="DoctorInCharge" width="100" hidden="true">主治医生工号@姓名</th>
                <th field="ScheduleId" width="100"  hidden="true">手术id号</th>
                <th field="DiagBeforeOperation"width="14%" sortable="true">主要诊断</th>
                <th field="ScheduledDateTime" width="100" hidden="true">预约进行该次手术的日期及时间</th>
                <th field="KeepSpecimenSign" width="10%" sortable="true">是否留标本</th>
                <th field="OperatingRoom" width="100" hidden="true">手术室代码@名称</th>
                <th field="Surgeon" width="100" hidden="true">手术医师工号@姓名</th>
                <th field="InPatPreillness" width="100" hidden="true">现病史</th>
                <th field="InPatPastillness" width="100" hidden="true">既往史</th>
                <th field="InPatFamillness" width="100" hidden="true">家族史</th>
                <th field="LabInfo" width="10%" sortable="true">乙肝梅毒等阳性结果</th>
                <th field="Sex" width="10%" >性别</th>
            </tr>
        </thead>
    </table>

    <!--toolbar栏，用于datagrid的toolbar自定义内容-->
    <div id="toolbar">
        <table style="width: 100%;">
            <tr>
                <!--button按钮工具栏-->
                <td style="text-align: right;">
<%--                    <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonInfo" iconcls="icon-search" plain="false" onclick="infoForm();">查看</a>
                    <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonAdd" iconcls="icon-add" plain="false" onclick="newForm();">添加</a>
                    <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonEdit" iconcls="icon-edit" plain="false" onclick="editForm();">编辑</a>
                    <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonDel" iconcls="icon-cancel" plain="false" onclick="destroy();">删除</a>
                    <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonExport" iconcls="icon-save" plain="false" onclick="exportData();">导出</a>--%>
                </td>
            </tr>
        </table>
    </div>

    <!--diaglog窗口，用于编辑数据-->
    <div id="dlg" class="easyui-dialog" closed="true"></div>
    <div id="dd"></div>
    <script type="text/javascript">
        $(function () {
            //绑定双击行事件
            $('#OPListForSpecimen').datagrid({
                onDblClickRow:function(rowIndex,rowData) {
                    showData(rowData);
                }
            });
            //绑定列排序事件
            $("#OPListForSpecimen").datagrid({
                onSortColumn: function (sort, order) {
                    sortData(sort, order);
                }
            })
        })
        
        function PagePaging(loaddata) {
            $("#OPListForSpecimen").datagrid({
                data: loaddata.slice(0, 10)
            });
            var pager = $("#OPListForSpecimen").datagrid("getPager");
            pager.pagination({
                total: loaddata.length,
                onSelectPage: function (pageNo, pageSize) {
                    var start = (pageNo - 1) * pageSize;
                    var end = start + pageSize;
                    $("#OPListForSpecimen").datagrid("loadData", loaddata.slice(start, end));
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
        /*新增表单*/
        function newForm() {
            $('#dlg').dialog({
                title: 'OPListForSpecimen-添加数据',
                width: 650,
                height: 450,
                closed: false,
                cache: false,
                href: 'OPListForSpecimen_info.aspx?mode=ins'
            });
        }
        function showData(rowData) {
            if (!rowData) { $.messager.alert('提示', '请检查数据是否存在！', 'error'); }
            else {
                $('#dd').window({
                    title: '详细数据页面',
                    width: 800,
                    height: 600,
                    modal: true,
                    href: 'OPListForSpecimen/OPListForSpecimen_info.aspx',
                    onLoad: function () {
                        //var basedata = $.parseJSON(rowData);
                        //$("#frmAjax").form("load", basedata);
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
                        title: 'OPListForSpecimen-查看数据',
                        width: 650,
                        height: 450,
                        closed: false,
                        cache: true,
                        href: 'OPListForSpecimen_info.aspx?mode=inf&pk=' + row.id
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
                        title: 'OPListForSpecimen-修改数据',
                        width: 650,
                        height: 450,
                        closed: false,
                        cache: true,
                        href: 'OPListForSpecimen_info.aspx?mode=upd&pk=' + row.id
                    });
                } else {
                    $.messager.alert('警告', '修改操作只能选择一条数据', 'warning');
                }
            } else {
                $.messager.alert('警告', '请选择数据', 'warning');
            }
        }

        /*删除选择数据,多条记录PK主键参数用逗号,分开*/
        function destroy() {
            var rows = $('#datagrid').datagrid('getSelections');
            if (rows.length > 0) {
                var pkSelect = "";
                for (var i = 0; i < rows.length; i++) {
                    row = rows[i];
                    if (i == 0) {
                        pkSelect += row.id;
                    } else {
                        pkSelect += ',' + row.id;
                    }
                }
                $.messager.confirm('提示', '是否确认删除数据？', function (r) {
                    if (r) {
                        $.post('OPListForSpecimen_handler.ashx?mode=del&pk=' + pkSelect, function (result) {
                            if (result.success) {
                                $.messager.alert('提示', result.msg, 'info', function () {
                                    $('#datagrid').datagrid('reload');    //重新加载载数据
                                });
                            } else {
                                $.messager.alert('错误', result.msg, 'warning');
                            }
                        }, 'json');
                    }
                });
            } else {
                $.messager.alert('警告', '请选择数据', 'warning');
            }
        }

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
            var QryUrl = 'OPListForSpecimen_handler.ashx?mode=qry&' + Parm;
            $('#datagrid').datagrid({ url: QryUrl });
        }

        /*导出数据*/
        function exportData() {
            var Parm = getSearchParm();//获得查询条件参数构建，用URL传递查询参数
            var QryUrl = 'OPListForSpecimen_handler.ashx?mode=exp&' + Parm;
            $.post(QryUrl, function (result) {
                if (result.success) {
                    window.location.href = result.msg;
                } else {
                    $.messager.alert('错误', result.msg, 'warning');
                }
            }, 'json');
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
