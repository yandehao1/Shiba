<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LabTest.aspx.cs" Inherits="RuRo.Web.Pages.LabTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看检测信息</title>
    <link rel="stylesheet" type="text/css" href="../../include/jquery-easyui-1.4.3/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../../include/jquery-easyui-1.4.3/themes/icon.css" />
    <script type="text/javascript" src="../../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script type="text/javascript" src="../../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../../include/jquery-easyui-1.4.3/locale/easyui-lang-zh_CN.js"></script>
    <link rel="stylesheet" type="text/css" href="../../include/css/kfmis.css" />
    <script type="text/javascript" src="../../include/js/jquery.cookie.js"></script>
    <script type="text/javascript" src="../include/js/default.js"></script>
    <script type="text/javascript" src="../include/js/page.js"></script>
    <script type="text/javascript">
        function GetPatientLabMaster() {
            $('#name').textbox('setValue', "患者姓名");
            loadData({ total: 0, rows: [] });
            var PatientId = $('#PatientId').textbox('getValue');
            var VisitId = $('#VisitId').textbox('getValue');
            $.ajax({
                type: "get",
                url: "/Sever/LabTest.ashx?mod=getPLM&PatientId=" + PatientId + "&VisitId=" + VisitId,
                dataType: "json",
                success: function (response) {
                    if (response) {
                        // var data = JSON.parse(response);
                        var data = response;
                        if (data.State == "0") {
                            if (data.Data.ResultCode == 0) {
                                //获取数据成功
                                loadData(data.Data.LabTestMaste);
                                $('#name').textbox('setValue', data.Data.Name);
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
        //
    </script>
</head>
<body>
    <div class="easyui-panel">
        <form id="labTestForm">
            <div id="getcode" style="float: left">
                <input id="PatientId" class="easyui-textbox" name="PatientId" data-options="prompt:'请输入登记号',required:true" />
                <input id="VisitId" class="easyui-textbox" name="VisitId" data-options="prompt:'请输入就诊号',required:true" />
                <a href="javascript:void(0)" class="easyui-linkbutton" id="patientLabMaster" name="patientLabMaster" onclick="GetPatientLabMaster()">条码查询信息</a>
            <input id="name" class="easyui-textbox" name="name" data-options="prompt:'患者姓名'" disabled="disabled"  style="text-align:right"/>
            </div>
        </form>
    </div>
    <div class="easyui-panel" style="float: left; margin-top: 10px;" data-options="href:'LabTestMaster/LabTestMaster_list.aspx'">
    </div>
</body>
</html>
