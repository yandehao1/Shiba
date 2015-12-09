<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResHis.aspx.cs" Inherits="RuRo.Web.Pages.ResHis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>回发数据</title>
    <link rel="stylesheet" type="text/css" href="../../include/jquery-easyui-1.4.3/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../../include/jquery-easyui-1.4.3/themes/icon.css" />
    <script type="text/javascript" src="../../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script type="text/javascript" src="../../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../../include/jquery-easyui-1.4.3/locale/easyui-lang-zh_CN.js"></script>
    <link rel="stylesheet" type="text/css" href="../../include/css/kfmis.css" />
    <script type="text/javascript" src="../../include/js/jquery.cookie.js"></script>
    <script type="text/javascript" src="../include/js/loading.js"></script>
    <%--<script type="text/javascript" src="../../include/js/page.js"></script>--%>
</head>
<body>
    <div id="main">
        <div id="funcTool"></div>
        <div>
        </div>
        <div class="easyui-panel" style="float: left; margin-top: 10px;" data-options="href:'ZSSY/SpecimenRtLog/List.aspx'"></div>
    </div>
    <script type="text/javascript">
        //function reshis() {
        //    $.post('RespondHis.ashx', { action: respondhis })
        //}
    </script>
</body>
</html>
