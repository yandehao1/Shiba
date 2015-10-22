<%@ Page Title="" Language="C#" MasterPageFile="~/FpExtendMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FreezerProPlugin.Login1" %>

<asp:Content ID="FpExtendPageLoginHeld" ContentPlaceHolderID="head" runat="server">
    <title>登陆FreezerPro扩展系统</title>
</asp:Content>
<asp:Content ID="FpExtendPageLoginFrom" ContentPlaceHolderID="FpExtendPage" runat="server" EnableViewState="true">
    <form action="/" method="post"  runat="server" >
        <div style="margin-left: 15%; margin-top: 10%">
            <div class="easyui-panel" title="登录" style="width: 80%; height: auto;" id="center">
                <div style="margin: 10%">
                    <input runat="server" class="easyui-textbox" id="username" name="username" style="width: 90%; height: 40px; padding: 12px" data-options="prompt:'username',iconCls:'icon-man',iconWidth:38" />
                </div>
                <div style="margin: 10%">
                    <input runat="server" class="easyui-textbox" id="password" name="password" style="width: 90%; height: 40px; padding: 12px" type="password" data-options="prompt:'password',iconCls:'icon-lock',iconWidth:38" />
                </div>
                <div style="text-align: center; padding: 5px">
                    <a runat="server" href="javascript:void(0)" style="margin: 5px" class="easyui-linkbutton" onclick="<% %>">">登陆</a>
                    <a runat="server" href="javascript:void(0)" style="margin: 5px" class=" easyui-linkbutton" onclick="">取消</a>
                </div>
                <div id="loginhiddendate" hidden="hidden" runat="server"></div>
            </div>
        </div>
    </form>
</asp:Content>
