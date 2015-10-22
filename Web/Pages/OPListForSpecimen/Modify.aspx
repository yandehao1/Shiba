<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="RuRo.Web.OPListForSpecimen.Modify" Title="修改页" %>
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
		<asp:label id="lblId" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		病人唯一标识号
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPatientId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		住院号
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtInpNO" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		就诊号
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtVisitId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		姓名
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		姓名拼音
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtNamePhonetic" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		性别
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSex" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		出生日期
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDateOfBirth" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		行政区名称
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBirthPlace" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		国家简称
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCitizenship" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		民族
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtNation" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		身份证号
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtIDNO" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		患者工作身份
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtIdentity" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		病人收费类别
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtChargeType" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		永久通信地址
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtMailingAddress" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		邮政编码
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtZipCode" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		家庭电话号码
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPhoneNumberHome" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		单位电话号码
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPhoneNumbeBusiness" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		亲属姓名
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtNextOfKin" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		亲属关系
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtRelationShip" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		联系人地址
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtNextOfKinAddr" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		联系人邮政编码
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtNextOfKinZipCode" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		联系人电话号码
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtNextOfKinPhome" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		当前科室代码@名称
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDeptCode" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		病人所住床号
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBedNO" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		入院日期及时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtAdmissionDateTime" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		主治医生工号@姓名
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDoctorInCharge" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		手术id号
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtScheduleId" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		主要诊断
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtDiagBeforeOperation" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		预约进行该次手术的日期及时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtScheduledDateTime" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		是否留标本
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtKeepSpecimenSign" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		手术室代码@名称
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtOperatingRoom" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		手术医师工号@姓名
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSurgeon" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		现病史
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtInPatPreillness" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		既往史
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtInPatPastillness" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		家族史
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtInPatFamillness" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		乙肝梅毒等阳性结果
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtLabInfo" runat="server" Width="200px"></asp:TextBox>
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
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>

