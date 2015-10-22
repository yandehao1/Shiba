<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="RuRo.Web.ZSSY.ImportSampleSourceLog.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		自增列
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		样本源Name
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblsampleSourceName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		样本源类型
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblsampleSourceType" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		样本源描述
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblsampleSourceDescription" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		患者唯一标识
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpatientId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		患者姓名
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpatientName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		患者性别
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpatientSex" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		导入数据之前的状态
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblimportStatus" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		隐藏域数据
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblhidden" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		导入数据之后的状态
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblResultStatus" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		执行导入的时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblImportDate" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




