<!--基础代码由科发EasyUi代码生成器v3.5(build 20140519)代码生成器生成,免费版自动增加版权注释,请保留版权信息，尊重作者劳动成果，如您有更好的建议请发至邮箱：843330160@qq.com-->
<!--编辑表单form与datagrid列表数据分别放在两个独立的aspx页面中-->
<!--form页面:Info_info.aspx-->

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
    <!--存储参数属性input控件，判断是新增还是修改-->
    <input value="" id="mode" type="text" style="display: none" runat="server" />
    <input value="" id="pk" type="text" style="display: none" runat="server" />
    <!--编辑数据-->
    <!--编辑容器，按钮固定在底部-->
    <div class="easyui-layout" data-options="fit:true">
        <div data-options="region:'center',split:true" style="width: 100px; padding: 10px">
            <div id="printBody">
                <div class="ftitle">Info</div>
                <form id="frmAjax" method="post" novalidate>
                    <!--如需控制表单控件为必填项，请增加class="easyui-validatebox" required="true" -->
                    <div class="fitem">
                        <div class="label">id:</div>
                        <div class="control">
                            <input id="id" name="id" disabled="disabled" /></div>
                    </div>
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
                            <input id="住院号" name="住院号" /></div>
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
            </div>
        </div>
    </div>

    <script type="text/javascript">

        //为样本源类型赋值
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
            //清除cookie
            $.cookie(username + "sampleSourceType", null);
            //重写cookie
            $.cookie(username + 'sampleSourceType', ssType, { expires: 7 });
        }

        //var mode = $('#mode').val();
        //var pk = $('#pk').val();
        ///*编辑或查看状态下控件赋值*/
        //if (mode == 'upd' || mode == 'inf') {
        //    url = 'Info_handler.ashx?mode=inf&pk=' + pk;
        //    $.post(url, function (data) {
        //        $('#frmAjax').form('load', data);
        //    }, 'json');
        //    $('#linkbuttonClear').linkbutton({ disabled: true });
        //}

        /*查看状态下disabled控件*/
        if (mode == 'inf') {
            $('#linkbuttonSave').linkbutton({ disabled: true });
            $('input').attr('disabled', 'disabled');
            $('textarea').attr('disabled', 'disabled');
        }

        if (mode == 'ins') url = 'Info_handler.ashx?mode=ins';
        if (mode == 'upd') url = 'Info_handler.ashx?mode=upd&pk=' + pk;

        /*清空充填*/
        function clearForm() {
            $('#frmAjax').form('clear');
        }

        /*保存表单数据*/
        function saveForm() {
            var Parm = $('#frmAjax').serialize();
            var PatientId = $('#住院号').val();
            var cardNO = $('#卡号').val();
            var sampleSourceType = $('#sampleSourceType').combobox('getText');
            if (isEmptyStr(sampleSourceType)) {
                ShowMsg("请选择样品源类型"); return;
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
            //                ShowMsg("患者信息：" + "导入成功" + res.message);
            //            } else {
            //                ShowMsg("患者信息：" + "导入失败" + res.message);
            //            }
            //        }
            //        else { $.messager.alert('提示', '查询不到样品源', 'error'); }
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
