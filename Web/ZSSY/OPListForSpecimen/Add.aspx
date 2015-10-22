<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Add.aspx.cs" Inherits="RuRo.Web.ZSSY.OPListForSpecimen.Add" Title="增加页" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <span style="padding-left:10px">
                    <label>选择样品源类型：</label>
                <asp:DropDownList ID="SampleSourceType" runat="server"></asp:DropDownList>
                    </span>
                <span style="padding-right:10px">
                <asp:Button ID="btnSave" runat="server" Text="保存"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                <asp:Button ID="btnCancle" runat="server" Text="取消"
                    OnClick="btnCancle_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                     </span>
            </td>
        </tr>
        <tr>
            <td class="tdbg">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="25" width="30%" align="right">病人唯一标识号：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtPatientId" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <%-- </tr>
                    <tr>--%>
                        <td height="25" width="30%" align="right">住院号：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtInpNO" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">就诊号：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtVisitId" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <%--</tr>
                    <tr>--%>
                        <td height="25" width="30%" align="right">姓名：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">姓名拼音：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtNamePhonetic" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <%--</tr>
                    <tr>--%>
                        <td height="25" width="30%" align="right">性别：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtSex" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">出生日期：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtDateOfBirth" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <%--</tr>
                    <tr>--%>
                        <td height="25" width="30%" align="right">乙肝梅毒等阳性结果：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtLabInfo" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">行政区名称：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtBirthPlace" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <%--</tr>
                    <tr>--%>
                        <td height="25" width="30%" align="right">国家简称：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtCitizenship" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">民族：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtNation" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <%--</tr>
                    <tr>--%>
                        <td height="25" width="30%" align="right">身份证号：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtIDNO" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">患者工作身份：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtIdentity" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <%--</tr>
                    <tr>--%>
                        <td height="25" width="30%" align="right">病人收费类别：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtChargeType" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">永久通信地址：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtMailingAddress" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <%--</tr>
                    <tr>--%>
                        <td height="25" width="30%" align="right">邮政编码：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtZipCode" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">家庭电话号码：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtPhoneNumberHome" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <%--</tr>
                    <tr>--%>
                        <td height="25" width="30%" align="right">单位电话号码：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtPhoneNumbeBusiness" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">亲属姓名：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtNextOfKin" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <%--</tr>
                    <tr>--%>
                        <td height="25" width="30%" align="right">亲属关系：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtRelationShip" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">联系人地址：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtNextOfKinAddr" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">联系人邮政编码：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtNextOfKinZipCode" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <%--</tr>
                    <tr>--%>
                        <td height="25" width="30%" align="right">联系人电话号码：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtNextOfKinPhome" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">当前科室代码@名称：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtDeptCode" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <%--</tr>
                    <tr>--%>
                        <td height="25" width="30%" align="right">病人所住床号：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtBedNO" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">入院日期及时间：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtAdmissionDateTime" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <%--</tr>
                    <tr>--%>
                        <td height="25" width="30%" align="right">主治医生工号@姓名：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtDoctorInCharge" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">手术id号：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtScheduleId" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <%--</tr>
                    <tr>--%>
                        <td height="25" width="30%" align="right">预约进行该次手术的日期及时间：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtScheduledDateTime" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td height="25" width="30%" align="right">是否留标本：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtKeepSpecimenSign" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">手术室代码@名称：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtOperatingRoom" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <%--</tr>
                    <tr>--%>
                        <td height="25" width="30%" align="right">手术医师工号@姓名：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtSurgeon" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">主要诊断：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtDiagBeforeOperation" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">现病史：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtInPatPreillness" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">既往史：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtInPatPastillness" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">家族史：</td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtInPatFamillness" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
