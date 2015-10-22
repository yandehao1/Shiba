<%@ Page Title="FP中样本源记录" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="RuRo.Web.ZSSY.ImportSampleSourceLog.List" %>
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
                    BorderWidth="1px" DataKeyNames="id" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="sampleSourceName" HeaderText="样本源Name" SortExpression="sampleSourceName" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="sampleSourceType" HeaderText="样本源类型" SortExpression="sampleSourceType" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="sampleSourceDescription" HeaderText="样本源描述" SortExpression="sampleSourceDescription" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="patientId" HeaderText="患者唯一标识" SortExpression="patientId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="patientName" HeaderText="患者姓名" SortExpression="patientName" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="patientSex" HeaderText="患者性别" SortExpression="patientSex" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="importStatus" HeaderText="导入数据之前的状态" SortExpression="importStatus" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="hidden" HeaderText="隐藏域数据" SortExpression="hidden" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ResultStatus" HeaderText="导入数据之后的状态" SortExpression="ResultStatus" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ImportDate" HeaderText="执行导入的时间" SortExpression="ImportDate" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Modify.aspx?id={0}"
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
