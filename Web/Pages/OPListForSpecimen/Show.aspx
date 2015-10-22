<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="RuRo.Web.OPListForSpecimen.Show" Title="显示页" %>
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
		病人唯一标识号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPatientId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		住院号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblInpNO" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		就诊号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblVisitId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		姓名
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		姓名拼音
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblNamePhonetic" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		性别
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSex" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		出生日期
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDateOfBirth" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		行政区名称
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBirthPlace" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		国家简称
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCitizenship" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		民族
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblNation" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		身份证号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblIDNO" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		患者工作身份
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblIdentity" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		病人收费类别
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblChargeType" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		永久通信地址
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMailingAddress" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		邮政编码
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblZipCode" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		家庭电话号码
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPhoneNumberHome" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		单位电话号码
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPhoneNumbeBusiness" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		亲属姓名
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblNextOfKin" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		亲属关系
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRelationShip" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		联系人地址
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblNextOfKinAddr" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		联系人邮政编码
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblNextOfKinZipCode" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		联系人电话号码
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblNextOfKinPhome" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		当前科室代码@名称
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDeptCode" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		病人所住床号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBedNO" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		入院日期及时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAdmissionDateTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		主治医生工号@姓名
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDoctorInCharge" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		手术id号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblScheduleId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		主要诊断
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDiagBeforeOperation" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		预约进行该次手术的日期及时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblScheduledDateTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		是否留标本
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblKeepSpecimenSign" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		手术室代码@名称
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOperatingRoom" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		手术医师工号@姓名
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSurgeon" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		现病史
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblInPatPreillness" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		既往史
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblInPatPastillness" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		家族史
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblInPatFamillness" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		乙肝梅毒等阳性结果
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblLabInfo" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




