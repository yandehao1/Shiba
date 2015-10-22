<%@ Page Title="FP中样本源记录" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="RuRo.Web.OPListForSpecimen.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
<script type="text/javascript" src="../../include/My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript">
    function getQuery(sel)
    {
        var change = sel.value;
        if (change == 2) {
            document.getElementById("getcode").style.visibility = "hidden";
            document.getElementById("getdate").style.visibility = "visible";
        }
        else {
            document.getElementById("getdate").style.visibility = "hidden";
            document.getElementById("getcode").style.visibility = "visible";
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--Title -->

            <!--Title end -->

            <!--Add  -->

            <!--Add end -->

            <!--Search -->
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td style="width: 80px" align="right" class="tdbg">
                        <select onchange="getQuery(this)">
                            <option value ="1">按编码</option>  
                            <option value ="2">按日期</option> 
                        </select>
                    </td>
                    <td class="tdbg" >
                        <div id="getcode">
                            <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:Button ID="btnSearch" runat="server" Text="条码查询"  OnClick="btnCode_Click" ></asp:Button> 
                        </div>
                        <div id="getdate" style="visibility:hidden">
                            <div>
                                开始日期：<input class="Wdate" type="text" runat="server" id="ksrq" name="ksrq"  onClick="WdatePicker()">
                            </div> 
                            <div>
                                结束日期：<input class="Wdate" type="text" runat="server" id="jsrq" name="jsrq"  onClick="WdatePicker()">
                            </div> 
                            <asp:Button ID="Button1" runat="server" Text="日期查询"  OnClick="btnSelDate_Click" ></asp:Button>  
                        </div>                       
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="Id" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="PatientId" HeaderText="病人唯一标识号" SortExpression="PatientId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="InpNO" HeaderText="住院号" SortExpression="InpNO" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="VisitId" HeaderText="就诊号" SortExpression="VisitId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Name" HeaderText="姓名" SortExpression="Name" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="NamePhonetic" HeaderText="姓名拼音" SortExpression="NamePhonetic" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Sex" HeaderText="性别" SortExpression="Sex" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="DateOfBirth" HeaderText="出生日期" SortExpression="DateOfBirth" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BirthPlace" HeaderText="行政区名称" SortExpression="BirthPlace" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Citizenship" HeaderText="国家简称" SortExpression="Citizenship" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Nation" HeaderText="民族" SortExpression="Nation" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="IDNO" HeaderText="身份证号" SortExpression="IDNO" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Identity" HeaderText="患者工作身份" SortExpression="Identity" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ChargeType" HeaderText="病人收费类别" SortExpression="ChargeType" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MailingAddress" HeaderText="永久通信地址" SortExpression="MailingAddress" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ZipCode" HeaderText="邮政编码" SortExpression="ZipCode" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PhoneNumberHome" HeaderText="家庭电话号码" SortExpression="PhoneNumberHome" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PhoneNumbeBusiness" HeaderText="单位电话号码" SortExpression="PhoneNumbeBusiness" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="NextOfKin" HeaderText="亲属姓名" SortExpression="NextOfKin" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="RelationShip" HeaderText="亲属关系" SortExpression="RelationShip" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="NextOfKinAddr" HeaderText="联系人地址" SortExpression="NextOfKinAddr" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="NextOfKinZipCode" HeaderText="联系人邮政编码" SortExpression="NextOfKinZipCode" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="NextOfKinPhome" HeaderText="联系人电话号码" SortExpression="NextOfKinPhome" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="DeptCode" HeaderText="当前科室代码@名称" SortExpression="DeptCode" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BedNO" HeaderText="病人所住床号" SortExpression="BedNO" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="AdmissionDateTime" HeaderText="入院日期及时间" SortExpression="AdmissionDateTime" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="DoctorInCharge" HeaderText="主治医生工号@姓名" SortExpression="DoctorInCharge" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ScheduleId" HeaderText="手术id号" SortExpression="ScheduleId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="DiagBeforeOperation" HeaderText="主要诊断" SortExpression="DiagBeforeOperation" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ScheduledDateTime" HeaderText="预约进行该次手术的日期及时间" SortExpression="ScheduledDateTime" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="KeepSpecimenSign" HeaderText="是否留标本" SortExpression="KeepSpecimenSign" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="OperatingRoom" HeaderText="手术室代码@名称" SortExpression="OperatingRoom" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Surgeon" HeaderText="手术医师工号@姓名" SortExpression="Surgeon" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="InPatPreillness" HeaderText="现病史" SortExpression="InPatPreillness" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="InPatPastillness" HeaderText="既往史" SortExpression="InPatPastillness" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="InPatFamillness" HeaderText="家族史" SortExpression="InPatFamillness" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="LabInfo" HeaderText="乙肝梅毒等阳性结果" SortExpression="LabInfo" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                                Text="编辑"  />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="false"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                </asp:GridView>
               <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td align="left">
                        <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"/>                       
                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
