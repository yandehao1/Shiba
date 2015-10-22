<%@ Page Title="FP中样本源记录" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="RuRo.Web.ZSSY.LabTestMaster.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
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
                         <b>关键字：</b>
                    </td>
                    <td class="tdbg">                       
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询"  OnClick="btnSearch_Click" >
                    </asp:Button>                    
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="TestNo" HeaderText="检验申请单号" SortExpression="TestNo" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="priorityIndicator" HeaderText="优先标志" SortExpression="priorityIndicator" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="WorkingId" HeaderText="工作单号" SortExpression="WorkingId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="TestCause" HeaderText="检验目的" SortExpression="TestCause" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="RelevantClinicDiag" HeaderText="临床诊断" SortExpression="RelevantClinicDiag" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Specimen" HeaderText="标本" SortExpression="Specimen" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="SpcmReceivedDateTime" HeaderText="采样时间" SortExpression="SpcmReceivedDateTime" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="OrderingDept" HeaderText="开医嘱科室" SortExpression="OrderingDept" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="orderingProvider" HeaderText="医生工号" SortExpression="orderingProvider" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PerformedBy" HeaderText="执行科室" SortExpression="PerformedBy" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ResultStatus" HeaderText="执行情况" SortExpression="ResultStatus" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ResultsRptDateTime" HeaderText="报告完成时间" SortExpression="ResultsRptDateTime" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="transcriptionist" HeaderText="报告者工号" SortExpression="transcriptionist" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="VerifiedBy" HeaderText="审核者工号" SortExpression="VerifiedBy" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="" DataNavigateUrlFormatString="Show.aspx?"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="" DataNavigateUrlFormatString="Modify.aspx?"
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
