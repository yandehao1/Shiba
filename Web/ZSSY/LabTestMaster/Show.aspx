<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="RuRo.Web.ZSSY.LabTestMaster.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		Id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		检验申请单号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTestNo" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		优先标志
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblpriorityIndicator" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		工作单号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblWorkingId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		检验目的
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTestCause" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		临床诊断
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRelevantClinicDiag" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		标本
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSpecimen" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		采样时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSpcmReceivedDateTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		开医嘱科室
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOrderingDept" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		医生工号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblorderingProvider" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		执行科室
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPerformedBy" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		执行情况
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblResultStatus" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		报告完成时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblResultsRptDateTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		报告者工号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbltranscriptionist" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		审核者工号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblVerifiedBy" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




