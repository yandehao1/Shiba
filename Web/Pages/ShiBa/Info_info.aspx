<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info_info.aspx.cs" Inherits="RuRo.Web.Pages.ShiBa.Info_info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head">
    <title>Info</title>
    <link href="../../include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../../include/jquery-easyui-1.4.3/themes/icon.css" />
    <script src="../../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script src="../../include/jquery-easyui-1.4.3/locale/easyui-lang-zh_CN.js"></script>
    <link href="../../include/css/kfmis.css" rel="stylesheet" />
</head>
<body>
    <!--�洢��������input�ؼ����ж������������޸�-->
    <input value="" id="mode" type="text" style="display: none" runat="server" />
    <input value="" id="pk" type="text" style="display: none" runat="server" />
    <!--�༭����-->
    <!--�༭��������ť�̶��ڵײ�-->
    <div class="easyui-layout" data-options="fit:true">
        <div data-options="region:'center',split:true" style="width: 100px; padding: 10px">
            <div id="printBody">
                <%--<div class="ftitle">Info</div>--%>
                <form id="frmAjax" method="post" novalidate>
                    <!--������Ʊ��ؼ�Ϊ�����������class="easyui-validatebox" required="true" -->
                    <%--        <div class="fitem">
            <div class="label">id:</div>
            <div class="control"><input id="id"  name="id"  disabled="disabled" /></div>
        </div>--%>
                    <div class="fitem">
                        <div class="label">����:</div>
                        <div class="control">
                            <input id="����" name="����" /></div>
                    </div>
                    <div class="fitem">
                        <div class="label">����:</div>
                        <div class="control">
                            <input id="����" name="����" /></div>
                    </div>
                    <div class="fitem">
                        <div class="label">�Ա�:</div>
                        <div class="control">
                            <input id="�Ա�" name="�Ա�" /></div>
                    </div>
                    <div class="fitem">
                        <div class="label">����:</div>
                        <div class="control">
                            <input id="����" name="����" /></div>
                    </div>
                    <div class="fitem">
                        <div class="label">ҽ��:</div>
                        <div class="control">
                            <input id="ҽ��" name="ҽ��" /></div>
                    </div>
                    <div class="fitem">
                        <div class="label">��ˮ��:</div>
                        <div class="control">
                            <input id="��ˮ��" name="��ˮ��" /></div>
                    </div>
                    <div class="fitem">
                        <div class="label">����:</div>
                        <div class="control">
                            <input id="����" name="����" /></div>
                    </div>
                    <div class="fitem">
                        <div class="label">סԺ��:</div>
                        <div class="control">
                            <input id="PATIENT_NO" name="PATIENT_NO" /></div>
                    </div>
                    <div class="fitem">
                        <div class="label">������:</div>
                        <div class="control">
                            <input id="������" name="������" /></div>
                    </div>
                    <div class="fitem">
                        <div class="label">���:</div>
                        <div class="control">
                            <textarea id="���" name="���"></textarea></div>
                    </div>
                    <div class="fitem">
                        <div class="label">����:</div>
                        <div class="control">
                            <input id="����" name="����" /></div>
                    </div>
                </form>
                <div class="ftitle"></div>
            </div>
        </div>

        <div data-options="region:'south'" style="height: 40px; background: #f2f2f2;">
            <!--��ť-->
            <div class="fsubmit">
                <%--��ƷԴ����ѡ��--%>
                <td style="width: 100px;">��ƷԴ����:</td>
                <input class="easyui-combobox" name="sampleSourceType" id="sampleSourceType" data-options="required:true,multiple:false,panelHeight: 'auto',prompt:'��ѡ����ƷԴ����'" />
                <a href="javascript:void(0)" id="linkbuttonSave" class="easyui-linkbutton" iconcls="icon-ok" onclick="saveForm()">����</a>
                <a href="javascript:void(0)" id="linkbuttonClear" class="easyui-linkbutton" iconcls="icon-back" onclick="clearForm();">���</a>
                <%--<a href="javascript:void(0)" id="linkbuttonColse" class="easyui-linkbutton" iconcls="icon-cancel" onclick="$('#dlg').dialog('close');">�ر�</a>--%>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        ////�������
        //$(function ()
        //{
        //    alert(GetQueryString('basedata'));
        //    //alert(getdata);
        //    //var jsonData = $.parseJSON(data);
        //    //$("#frmAjax").form("load", jsonData);
        //})

        //��sampleSourceType�������ֵ
        $(function () {
            $('#sampleSourceType').combobox({
                editable: false,
                method: 'get',
                valueField: 'value',
                textField: 'text',
                url: '../../Fp_Ajax/PageConData.ashx?conMarc=ssType',
                panelHeight: 'auto',
                onChange: In_SSTypeChange
                //selectOnNavigation:$(this).is(':checked'),
                //onLoadSuccess: function (data) { //���ݼ�������¼�
                //    if (data) {
                //       // $('#sampleSourceType').combobox('setValue', data);
                //        //�����ݵ�ҳ��
                //    }
                //}
            })
        })

        function In_SSTypeChange() {
            var username = $.cookie('username');
            var ssType = $('#sampleSourceType').combobox('getValue');
            //���cookie
            $.cookie(username + "sampleSourceType", null);
            //��дcookie
            $.cookie(username + 'sampleSourceType', ssType, { expires: 7 });
        }

        /*��ճ���*/
        function clearForm() {
            $('#frmAjax').form('clear');
        }
        /*���������*/
        function saveForm() {
            //var frmAjax = $("#frmAjax").serializeArray();
            //var Tem;
            //if (frmAjax) { Tem = JSON.stringify(frmAjax); } else {
            //    return;
            //}
            var Parm = $('#frmAjax').serialize();
            var cardno = $('#������').val();
            var patient_no = $('#PATIENT_NO').val();
            var sampleSourceType = $('#sampleSourceType').combobox('getText');
            if (isEmptyStr(cardno) && isEmptyStr(patient_no)) {
                ShowMsg("����,סԺ��Ϊ��"); return;
            }
            if (isEmptyStr(sampleSourceType)) {
                ShowMsg("��ѡ����ƷԴ����"); return;
            }
            var count = Math.random();
            var url = "../Fp_Ajax/getData.ashx" + "?count" + count;
            var PatientId = patient_no;
            if (isEmptyStr(patient_no)) {
                PatientId = cardno
            }
            else {
                PatientId = patient_no;
            }
            ajaxLoading();
            $('#frmAjax').form('submit', {
                url: url,
                onSubmit: function (param) {
                    param.mode = 'ins';
                    param.pId = PatientId;
                    param.ssType = sampleSourceType;
                },
                success: function (response) {
                    ajaxLoadEnd();
                    if (response) {
                        var res = JSON.parse(response);
                        if (res.success || res.message.indexOf('should be unique.') > -1) {
                            ShowMsg("������Ϣ��" + "����ɹ�" + res.message);
                        } else {
                            ShowMsg("������Ϣ��" + "����ʧ��" + res.message);
                        }
                    }
                    else { $.messager.alert('��ʾ', '��ѯ������ƷԴ', 'error'); }
                }
            });
            ajaxLoadEnd();
        }
    </script>

</body>
</html>
