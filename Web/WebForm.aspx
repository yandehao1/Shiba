<%@ Page Title="" Language="C#" MasterPageFile="~/BaseFp.Master" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="RuRo.Web.WebForm" EnableViewState="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FpExtend" runat="server">
    <div id="ffff">
        <asp:LinkButton runat="server" ID="fp" Text="打开扩展"  OnClick="fp_Click"></asp:LinkButton>
    </div>
</asp:Content>
