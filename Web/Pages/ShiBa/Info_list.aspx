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
    <!--datagrid��-->
    <table id="Info_datagrid" title="��Ϣ�б�ҳ��" class="easyui-datagrid" style="width: auto; height: 460px; text-align: center"
        url="../Fp_Ajax/getData.ashx?mode=qry" fit='false'
        pagination="true" idfield="PatientId" rownumbers="true"
        fitcolumns="true" singleselect="true" toolbar="#toolbar"
        striped="false" pagelist="[10,30,50]"
        selectoncheck="true" checkonselect="true" remotesort="false" multisort="true">
        <thead>
            <tr>
                <th field="ck" checkbox="true" hidden="true"></th>
                <th field="id" width="100" sortable="true" hidden="true">id</th>
                <th field="����" width="100" sortable="true">����</th>
                <th field="����" width="100" sortable="true">����</th>
                <th field="�Ա�" width="100" sortable="true">�Ա�</th>
                <th field="����" width="100" sortable="true">����</th>
                <th field="ҽ��" width="100" sortable="true" hidden="true">ҽ��</th>
                <th field="��ˮ��" width="100" sortable="true">��ˮ��</th>
                <th field="����" width="100" sortable="true">����</th>
                <th field="PATIENT_NO" width="100" sortable="true">סԺ��</th>
                <th field="������" width="100" sortable="true">������</th>
                <th field="���" width="100" sortable="true">���</th>
                <th field="����" width="100" sortable="true" hidden="true">����</th>
            </tr>
        </thead>
    </table>

    <!--toolbar��������datagrid��toolbar�Զ�������-->
    <div id="toolbar">
        <table style="width: 100%;">
            <tr>
                <!--button��ť������-->
                <td style="text-align: right;"></td>
            </tr>
        </table>
    </div>

    <!--diaglog���ڣ����ڱ༭����-->
    <div id="dlg" class="easyui-dialog" closed="true"></div>
    <div id="dd"></div>
    <script type="text/javascript">
        $(function () {
            //��˫�����¼�
            $('#Info_datagrid').datagrid({
                onDblClickRow: function (rowIndex, rowData) {
                    showData(rowData);
                }
            });
            //���������¼�
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
            //alert('����Ҫд...'+sort+':'+order);
        }
        var url;

        function showData(rowData) {
            if (!rowData) { $.messager.alert('��ʾ', '���������Ƿ���ڣ�', 'error'); }
            else {
                $('#dd').window({
                    title: '��ϸ����ҳ��',
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
        /*�鿴����*/
        function infoForm() {
            var rows = $('#datagrid').datagrid('getSelections');
            if (rows.length > 0) {
                if (rows.length == 1) {
                    var row = $('#datagrid').datagrid('getSelected');
                    $('#dlg').dialog({
                        title: '�鿴����',
                        width: 650,
                        height: 400,
                        closed: false,
                        cache: true,
                        href: 'Info_info.aspx?mode=inf&pk=' + row.id
                    });
                } else {
                    $.messager.alert('����', '�鿴����ֻ��ѡ��һ������', 'warning');
                }
            } else {
                $.messager.alert('����', '��ѡ������', 'warning');
            }
        }

        /*�޸�����*/
        function editForm() {
            var rows = $('#datagrid').datagrid('getSelections');
            if (rows.length > 0) {
                if (rows.length == 1) {
                    var row = $('#datagrid').datagrid('getSelected');
                    $('#dlg').dialog({
                        title: 'Info-�޸�����',
                        width: 650,
                        height: 400,
                        closed: false,
                        cache: true,
                        href: 'Info_info.aspx?mode=upd&pk=' + row.id
                    });
                } else {
                    $.messager.alert('����', '�޸Ĳ���ֻ��ѡ��һ������', 'warning');
                }
            } else {
                $.messager.alert('����', '��ѡ������', 'warning');
            }
        }

        /*ɾ��ѡ������,������¼PK���������ö���,�ֿ�*/
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
        //        $.messager.confirm('��ʾ', '�Ƿ�ȷ��ɾ�����ݣ�', function (r) {
        //            if (r) {
        //                $.post('Info_handler.ashx?mode=del&pk=' + pkSelect, function (result) {
        //                    if (result.success) {
        //                        $.messager.alert('��ʾ', result.msg, 'info', function () {
        //                            $('#datagrid').datagrid('reload');    //���¼���������
        //                        });
        //                    } else {
        //                        $.messager.alert('����', result.msg, 'warning');
        //                    }
        //                }, 'json');
        //            }
        //        });
        //    } else {
        //        $.messager.alert('����', '��ѡ������', 'warning');
        //    }
        //}

        /*��ѯ������������*/
        function getSearchParm() {
            //������������׷�Ӳ�������
            /*comboboxֵ��ȡ����,��������������ѯ�������*/
            //var v_so_�ֶ����� = $('#so_�ֶ�����').combobox('getValue');
            var v_parm
            var v_so_keywords = $('#so_keywords').searchbox('getValue');
            v_parm = 'so_keywords=' + escape(v_so_keywords);
            return v_parm;
        }

        /*��ѯ����*/
        function searchData() {
            /*��˵���Excel����������������datagrid����load�������ز�����ֱ����URL���ݲ���*/
            var Parm = getSearchParm();//��ò�ѯ����������������URL���ݲ�ѯ����
            var QryUrl = '../Fp_Ajax/getData.ashx?mode=qry&' + Parm;
            $('#datagrid').datagrid({ url: QryUrl });
        }
        /*�ر�dialog���¼���datagrid����*/
        $('#dlg').dialog({
            onClose: function () {
                $('#datagrid').datagrid('reload'); //���¼���������
            }
        });

    </script>
</body>
</html>
