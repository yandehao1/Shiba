<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestEnum.aspx.cs" Inherits="RuRo.Web.Test.TestEnum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button id ="test1" runat="server" Text="测试枚举序列化" OnClick="test1_Click"/>
        <asp:Label ID="ResLab" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
