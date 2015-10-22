<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="RuRo.Web.ZSSY.LabTestMaster.Add" Title="增加页" %>

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
		<asp:TextBox id="txtId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		检验申请单号
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTestNo" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		优先标志
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtpriorityIndicator" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		工作单号
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtWorkingId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		检验目的
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTestCause" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		临床诊断
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtRelevantClinicDiag" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		标本
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSpecimen" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		采样时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSpcmReceivedDateTime" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		开医嘱科室
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtOrderingDept" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		医生工号
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtorderingProvider" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		执行科室
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPerformedBy" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		执行情况
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtResultStatus" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		报告完成时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtResultsRptDateTime" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		报告者工号
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txttranscriptionist" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		审核者工号
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtVerifiedBy" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
</table>

            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="保存"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                <asp:Button ID="btnCancle" runat="server" Text="取消"
                    OnClick="btnCancle_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
