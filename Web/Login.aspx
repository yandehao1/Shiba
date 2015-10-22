<%@ Page Language="c#" CodeBehind="Login.aspx.cs" AutoEventWireup="True" Inherits="RuRo.Web.Login" %>

<!doctype html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Images/Images/login.css" rel="stylesheet" />
    <script src="include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <title>系统登录</title>
    <script type="text/javascript">
        function isEmptyStr(str) {
            if (str == '' || str == null) {
                return true;
            } else {
                return false;
            }
        }
        function focusNext(nextName, evt, num, t) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.which) ? evt.which : evt.keyCode);
            if (charCode == 13 || charCode == 3) {
                var nextobj = document.getElementById(nextName);
                if (num == 1 && isEmptyStr(t.value)) {
                    alert("请输入用户名！");
                    t.focus();
                    return false;
                }
                if (num == 2 && isEmptyStr(t.value)) {
                    alert("请输入密码！");
                    t.focus();
                    return false;
                }
                //if (num == 3 && isEmptyStr(t.value) && t.value == "--请选择--") {
                //    alert("请选择科室！");
                //    t.focus();
                //    return false;
                //}
                nextobj.focus();
                return false;
            }
            return true;
        }
        $(function () {
            $("#btnLogin").click(function () {
                var txtU = $("#<%=txtUsername.ClientID%>").val();
                if (isEmptyStr(txtU)) {
                    alert("请输入用户名！");
                    $("#<%=txtUsername.ClientID%>").focus();
                    return false;
                }
                var txtP = $("#<%=txtPass.ClientID%>").val();
                if (isEmptyStr(txtP)) {
                    alert("请输入密码！");
                    $("#<%=txtPass.ClientID%>").focus();
                    return false;
                }
                //var department = $('select#department option:selected').text();
                //if (isEmptyStr(department) || department == "--请选择--") {
                //    alert("请选择科室！");
                //    return false;
                //}
            });
        })
    </script>
</head>
<body leftmargin="0" topmargin="0" marginheight="0" marginwidth="0">

    <form id="Form1" method="post" runat="server">
        <br />
        <br />
        <br />
        <br />
        <br />
        <table width="620" border="0" align="center" cellpadding="0" cellspacing="0">
            <tbody>
                <tr>
                    <td width="620">
                        <img height="11" src="Images/Images/login_p_img02.gif" width="650">
                    </td>
                </tr>
                <tr>
                    <td align="center" background="Images/Images/login_p_img03.gif">
                        <br />
                        <table width="570" border="0" cellspacing="0" cellpadding="0">
                            <%--                            <tr>
                                <td>
                                    <table cellspacing="0" cellpadding="0" width="570" border="0">
                                        <tbody>
                                            <tr>
                                                <td width="245" height="80" align="center" valign="top"></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>--%>
                            <tr>
                                <img src="../Images/szy_Logo.jpg" style="width: 450px; height: 70px; z-index: 100; float: left; padding-left: 40px"></img>
                                <td>
                                    <img src="Images/Images/a_te01.gif" width="570" height="3">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" background="Images/Images/a_te02.gif">
                                    <table width="520" border="0" cellspacing="0" cellpadding="0" style="height: 147px">
                                        <tr>
                                            <td width="123" height="120">
                                                <img height="95" src="Images/Images/login_p_img05.gif" width="123" border="0">
                                            </td>
                                            <td align="center">
                                                <table cellspacing="0" cellpadding="0" border="0">
                                                    <tr>
                                                        <td width="210" height="25" valign="top">用户名：
                                                            <asp:TextBox runat="server" class="nemo01" TabIndex="1" MaxLength="22" size="22" name="user" ID="txtUsername" onkeypress="return focusNext('txtPass', event,1,this)" />
                                                        </td>
                                                        <td width="80" rowspan="3" align="right" valign="middle">
                                                            <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="Images/Images/login_p_img11.gif"></asp:ImageButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="bottom" height="12">密&nbsp;&nbsp;&nbsp;码：
                                                        <input name="user" type="password" class="nemo01" tabindex="1" size="22" maxlength="22"
                                                            id="txtPass" runat="server" onkeypress="return focusNext('btnLogin', event,2,this)">
                                                        </td>
                                                    </tr>
                                                    <%-- <tr>
                                                        <td valign="bottom" height="12">科&nbsp;&nbsp;&nbsp;室：
                                                            <asp:DropDownList ID="department" Style="margin-top: 8px" runat="server" class="nemo01" TabIndex="1" Font-Size="Small"></asp:DropDownList>
                                                        </td>
                                                    </tr>--%>
                                                </table>
                                                <br />
                                                <asp:Label ID="lblMsg" runat="server" BackColor="Transparent" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#d5d5d5"></td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="80" align="center">广东省中医院</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <img height="11" src="Images/Images/login_p_img04.gif" width="650" />
                    </td>
                </tr>
            </tbody>
        </table>
        <br />
    </form>
</body>
</html>