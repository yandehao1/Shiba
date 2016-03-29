<!--���������ɿƷ�EasyUi����������v3.5(build 20140519)��������������,��Ѱ��Զ����Ӱ�Ȩע��,�뱣����Ȩ��Ϣ�����������Ͷ��ɹ��������и��õĽ����뷢�����䣺843330160@qq.com-->
<!--�༭��form��datagrid�б����ݷֱ��������������aspxҳ����-->
<!--formҳ��:Info_info.aspx-->

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info_info.aspx.cs" Inherits="RURO.Info_info" %>

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
    <!--�洢��������input�ؼ����ж������������޸�-->
    <input value="" id="mode" type="text" style="display: none" runat="server" />
    <input value="" id="pk" type="text" style="display: none" runat="server" />
    <!--�༭����-->
    <!--�༭��������ť�̶��ڵײ�-->
    <div class="easyui-layout" data-options="fit:true">
        <div data-options="region:'center',split:true" style="width: 100px; padding: 10px">
            <div id="printBody">
                <div class="ftitle">Info</div>
                <form id="frmAjax" method="post" novalidate>
                    <!--������Ʊ��ؼ�Ϊ�����������class="easyui-validatebox" required="true" -->
                    <div class="fitem">
                        <div class="label">id:</div>
                        <div class="control">
                            <input id="id" name="id" disabled="disabled" /></div>
                    </div>
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
                            <input id="סԺ��" name="סԺ��" /></div>
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
            </div>
        </div>
    </div>

    <script type="text/javascript">

        //Ϊ����Դ���͸�ֵ
        $(function () {
            $('#sampleSourceType').combobox({
                editable: false,
                method: 'get',
                valueField: 'value',
                textField: 'text',
                url: '../../Fp_Ajax/PageConData.aspx?conMarc=ssType',
                panelHeight: 'auto',
                onChange: In_SSTypeChange
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

        //var mode = $('#mode').val();
        //var pk = $('#pk').val();
        ///*�༭��鿴״̬�¿ؼ���ֵ*/
        //if (mode == 'upd' || mode == 'inf') {
        //    url = 'Info_handler.ashx?mode=inf&pk=' + pk;
        //    $.post(url, function (data) {
        //        $('#frmAjax').form('load', data);
        //    }, 'json');
        //    $('#linkbuttonClear').linkbutton({ disabled: true });
        //}

        /*�鿴״̬��disabled�ؼ�*/
        if (mode == 'inf') {
            $('#linkbuttonSave').linkbutton({ disabled: true });
            $('input').attr('disabled', 'disabled');
            $('textarea').attr('disabled', 'disabled');
        }

        if (mode == 'ins') url = 'Info_handler.ashx?mode=ins';
        if (mode == 'upd') url = 'Info_handler.ashx?mode=upd&pk=' + pk;

        /*��ճ���*/
        function clearForm() {
            $('#frmAjax').form('clear');
        }

        /*���������*/
        function saveForm() {
            var Parm = $('#frmAjax').serialize();
            var PatientId = $('#סԺ��').val();
            var cardNO = $('#����').val();
            var sampleSourceType = $('#sampleSourceType').combobox('getText');
            if (isEmptyStr(sampleSourceType)) {
                ShowMsg("��ѡ����ƷԴ����"); return;
            }
            var count = Math.random();
            var url = "../../Sever/OPListForSpecimen_handler.ashx" + "?count" + count;
            ajaxLoading();
            //$.ajax({
            //    type: "POST",
            //    url: "../../Sever/OPListForSpecimen_handler.ashx" + "?count" + count,
            //    data: {
            //        "mode": "ins",
            //        //"Parm": Parm,
            //        "pId": PatientId,
            //        "ssType": sampleSourceType
            //    },
            //    success: function (response) {
            //        ajaxLoadEnd();
            //        if (response) {
            //            var res = JSON.parse(response);
            //            if (res.success || res.message.indexOf('should be unique.') > -1) {
            //                ShowMsg("������Ϣ��" + "����ɹ�" + res.message);
            //            } else {
            //                ShowMsg("������Ϣ��" + "����ʧ��" + res.message);
            //            }
            //        }
            //        else { $.messager.alert('��ʾ', '��ѯ������ƷԴ', 'error'); }
            //    }
            //});
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
