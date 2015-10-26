<!--基础代码由科发EasyUi代码生成器v3.5(build 20140519)代码生成器生成,免费版自动增加版权注释,请保留版权信息，尊重作者劳动成果，如您有更好的建议请发至邮箱：843330160@qq.com-->
<!--编辑表单form与datagrid列表数据分别放在两个独立的aspx页面中-->
<!--form页面:OPListForSpecimen_info.aspx-->

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OPListForSpecimen_info.aspx.cs" Inherits="RuRo.OPListForSpecimen_info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head">
    <title>导入样品源</title>
    <link rel="stylesheet" type="text/css" href="../../include/jquery-easyui-1.4.3/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../../include/jquery-easyui-1.4.3/themes/icon.css" />
    <script type="text/javascript" src="../../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script type="text/javascript" src="../../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../../include/jquery-easyui-1.4.3/locale/easyui-lang-zh_CN.js"></script>
    <link href="../../include/css/kfmis.css" rel="stylesheet" />
    <script type="text/javascript" src="../../include/js/page.js"></script>
    <script type="text/javascript" src="../../include/js/jquery.cookie.js"></script>
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
                <%--<div class="ftitle">OPListForSpecimen</div>--%>
                <form id="frmAjax" method="post" novalidate>
                    <!--如需控制表单控件为必填项，请增加class="easyui-validatebox" required="true" -->
                    <div class="fitem" style="display: none">
                        <div class="label">id:</div>
                        <div class="control">
                            <input id="id" name="id" disabled="disabled" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">病人唯一标识号:</div>
                        <div class="control">
                            <input id="PatientId" name="PatientId" data-options="required:true" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">住院号:</div>
                        <div class="control">
                            <input id="InpNO" name="InpNO" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">就诊号:</div>
                        <div class="control">
                            <input id="VisitId" name="VisitId" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">身份证号:</div>
                        <div class="control">
                            <input id="IDNO" name="IDNO" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">姓名:</div>
                        <div class="control">
                            <input id="Name" name="Name" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">姓名拼音:</div>
                        <div class="control">
                            <input id="NamePhonetic" name="NamePhonetic" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">性别:</div>
                        <div class="control">
                            <input id="Sex" name="Sex" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">出生日期:</div>
                        <div class="control">
                            <input id="DateOfBirth" name="DateOfBirth" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">行政区名称:</div>
                        <div class="control">
                            <input id="BirthPlace" name="BirthPlace" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">国家简称:</div>
                        <div class="control">
                            <input id="Citizenship" name="Citizenship" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">民族:</div>
                        <div class="control">
                            <input id="Nation" name="Nation" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">患者工作身份:</div>
                        <div class="control">
                            <input id="Identity" name="Identity" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">病人收费类别:</div>
                        <div class="control">
                            <input id="ChargeType" name="ChargeType" />
                        </div>
                    </div>

                    <div class="fitem">
                        <div class="label">邮政编码:</div>
                        <div class="control">
                            <input id="ZipCode" name="ZipCode" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">家庭电话号码:</div>
                        <div class="control">
                            <input id="PhoneNumberHome" name="PhoneNumberHome" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">单位电话号码:</div>
                        <div class="control">
                            <input id="PhoneNumbeBusiness" name="PhoneNumbeBusiness" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">亲属姓名:</div>
                        <div class="control">
                            <input id="NextOfKin" name="NextOfKin" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">亲属关系:</div>
                        <div class="control">
                            <input id="RelationShip" name="RelationShip" />
                        </div>
                    </div>

                    <div class="fitem">
                        <div class="label">联系人邮政编码:</div>
                        <div class="control">
                            <input id="NextOfKinZipCode" name="NextOfKinZipCode" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">联系人电话号码:</div>
                        <div class="control">
                            <input id="NextOfKinPhome" name="NextOfKinPhome" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">当前科室代码@名称:</div>
                        <div class="control">
                            <input id="DeptCode" name="DeptCode" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">病人所住床号:</div>
                        <div class="control">
                            <input id="BedNO" name="BedNO" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">入院日期及时间:</div>
                        <div class="control">
                            <input id="AdmissionDateTime" name="AdmissionDateTime" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">主治医生工号@姓名:</div>
                        <div class="control">
                            <input id="DoctorInCharge" name="DoctorInCharge" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">手术id号:</div>
                        <div class="control">
                            <input id="ScheduleId" name="ScheduleId" />
                        </div>
                    </div>

                    <div class="fitem">
                        <div class="label">手术的日期及时间:</div>
                        <div class="control">
                            <input id="ScheduledDateTime" name="ScheduledDateTime" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">是否留标本:</div>
                        <div class="control">
                            <input id="KeepSpecimenSign" name="KeepSpecimenSign" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">手术室代码@名称:</div>
                        <div class="control">
                            <input id="OperatingRoom" name="OperatingRoom" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">手术医师工号@姓名:</div>
                        <div class="control">
                            <input id="Surgeon" name="Surgeon" />
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">乙肝梅毒等阳性结果:</div>
                        <div class="control">
                            <textarea id="LabInfo" name="LabInfo"></textarea>
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">主要诊断:</div>
                        <div class="control">
                            <textarea id="DiagBeforeOperation" name="DiagBeforeOperation"></textarea>
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">现病史:</div>
                        <div class="control">
                            <textarea id="InPatPreillness" name="InPatPreillness"></textarea>
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">既往史:</div>
                        <div class="control">
                            <textarea id="InPatPastillness" name="InPatPastillness"></textarea>
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">家族史:</div>
                        <div class="control">
                            <textarea id="InPatFamillness" name="InPatFamillness"></textarea>
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">联系人地址:</div>
                        <div class="control">
                            <textarea id="NextOfKinAddr" name="NextOfKinAddr"></textarea>
                        </div>
                    </div>
                    <div class="fitem">
                        <div class="label">永久通信地址:</div>
                        <div class="control">
                            <textarea id="MailingAddress" name="MailingAddress"></textarea>
                        </div>
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
                <a href="javascript:void(0)" id="linkbuttonColse" class="easyui-linkbutton" iconcls="icon-cancel" onclick="$('#dlg').dialog('close');">关闭</a>
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
                url: '../../Fp_Ajax/PageConData.aspx?conMarc=ssType',
                panelHeight: 'auto',
                onChange: In_SSTypeChange,
                //selectOnNavigation:$(this).is(':checked'),
                onLoadSuccess: function (data) { //数据加载完毕事件
                    if (data) {
                        $('#sampleSourceType').combobox('setValue', data);
                        //绑定数据到页面
                    }
                }
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
            var PatientId = $('#PatientId').val();
            var sampleSourceType = $('#sampleSourceType').combobox('getText');
            if (isEmptyStr(PatientId)) {
                ShowMsg("患者唯一号为空"); return;
            }
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
                onSubmit: function(param){    
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
