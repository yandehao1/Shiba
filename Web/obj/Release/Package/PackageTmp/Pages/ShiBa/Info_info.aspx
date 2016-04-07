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
    <!--存储参数属性input控件，判断是新增还是修改-->
    <input value="" id="mode" type="text" style="display: none" runat="server" />
    <input value="" id="pk" type="text" style="display: none" runat="server" />
    <!--编辑数据-->
    <!--编辑容器，按钮固定在底部-->
    <div class="easyui-layout" data-options="fit:true">
        <div data-options="region:'center',split:true" style="width: 100px; padding: 10px">
            <div id="printBody">
                <%--<div class="ftitle">Info</div>--%>
                <form id="frmAjax" method="post" novalidate>
                    <!--如需控制表单控件为必填项，请增加class="easyui-validatebox" required="true" -->
                    <%--        <div class="fitem">
            <div class="label">id:</div>
            <div class="control"><input id="id"  name="id"  disabled="disabled" /></div>
        </div>--%>
                    <div class="fitem">
                        <div class="label">部门:</div>
                        <div class="control">
                            <input id="部门" name="部门" /></div>
                    </div>
                    <div class="fitem">
                        <div class="label">姓名:</div>
                        <div class="control">
                            <input id="姓名" name="姓名" /></div>
                    </div>
                    <div class="fitem">
                        <div class="label">性别:</div>
                        <div class="control">
                            <input id="性别" name="性别" /></div>
                    </div>
                    <div class="fitem">
                        <div class="label">年龄:</div>
                        <div class="control">
                            <input id="年龄" name="年龄" /></div>
                    </div>
                    <div class="fitem">
                        <div class="label">医生:</div>
                        <div class="control">
                            <input id="医生" name="医生" /></div>
                    </div>
                    <div class="fitem">
                        <div class="label">流水号:</div>
                        <div class="control">
                            <input id="流水号" name="流水号" /></div>
                    </div>
                    <div class="fitem">
                        <div class="label">卡号:</div>
                        <div class="control">
                            <input id="卡号" name="卡号" /></div>
                    </div>
                    <div class="fitem">
                        <div class="label">住院号:</div>
                        <div class="control">
                            <input id="PATIENT_NO" name="PATIENT_NO" /></div>
                    </div>
                    <div class="fitem">
                        <div class="label">病历号:</div>
                        <div class="control">
                            <input id="病历号" name="病历号" /></div>
                    </div>
                    <div class="fitem">
                        <div class="label">诊断:</div>
                        <div class="control">
                            <textarea id="诊断" name="诊断"></textarea></div>
                    </div>
                    <div class="fitem">
                        <div class="label">日期:</div>
                        <div class="control">
                            <input id="日期" name="日期" /></div>
                    </div>
                </form>
                <div class="ftitle"></div>
            </div>
        </div>

        <div data-options="region:'south'" style="height: 40px; background: #f2f2f2;">
            <!--按钮-->
            <div class="fsubmit">
                <%--样品源类型选择--%>
                <td style="width: 100px;">样品源类型:</td>
                <input class="easyui-combobox" name="sampleSourceType" id="sampleSourceType" data-options="required:true,multiple:false,panelHeight: 'auto',prompt:'请选择样品源类型'" />
                <a href="javascript:void(0)" id="linkbuttonSave" class="easyui-linkbutton" iconcls="icon-ok" onclick="saveForm()">导入</a>
                <a href="javascript:void(0)" id="linkbuttonClear" class="easyui-linkbutton" iconcls="icon-back" onclick="clearForm();">清空</a>
                <%--<a href="javascript:void(0)" id="linkbuttonColse" class="easyui-linkbutton" iconcls="icon-cancel" onclick="$('#dlg').dialog('close');">关闭</a>--%>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        ////填充数据
        //$(function ()
        //{
        //    alert(GetQueryString('basedata'));
        //    //alert(getdata);
        //    //var jsonData = $.parseJSON(data);
        //    //$("#frmAjax").form("load", jsonData);
        //})

        //给sampleSourceType下拉框绑定值
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
                //onLoadSuccess: function (data) { //数据加载完毕事件
                //    if (data) {
                //       // $('#sampleSourceType').combobox('setValue', data);
                //        //绑定数据到页面
                //    }
                //}
            })
        })

        function In_SSTypeChange() {
            var username = $.cookie('username');
            var ssType = $('#sampleSourceType').combobox('getValue');
            //清除cookie
            $.cookie(username + "sampleSourceType", null);
            //重写cookie
            $.cookie(username + 'sampleSourceType', ssType, { expires: 7 });
        }

        /*清空充填*/
        function clearForm() {
            $('#frmAjax').form('clear');
        }
        /*保存表单数据*/
        function saveForm() {
            //var frmAjax = $("#frmAjax").serializeArray();
            //var Tem;
            //if (frmAjax) { Tem = JSON.stringify(frmAjax); } else {
            //    return;
            //}
            var Parm = $('#frmAjax').serialize();
            var cardno = $('#病历号').val();
            var patient_no = $('#PATIENT_NO').val();
            var sampleSourceType = $('#sampleSourceType').combobox('getText');
            if (isEmptyStr(cardno) && isEmptyStr(patient_no)) {
                ShowMsg("卡号,住院号为空"); return;
            }
            if (isEmptyStr(sampleSourceType)) {
                ShowMsg("请选择样品源类型"); return;
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
                            ShowMsg("患者信息：" + "导入成功" + res.message);
                        } else {
                            ShowMsg("患者信息：" + "导入失败" + res.message);
                        }
                    }
                    else { $.messager.alert('提示', '查询不到样品源', 'error'); }
                }
            });
            ajaxLoadEnd();
        }
    </script>

</body>
</html>
