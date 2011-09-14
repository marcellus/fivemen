<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="销售确认" AutoEventWireup="true" CodeFile="SaleProductConfirm.aspx.cs" Inherits="Sales_SaleProductConfirm"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" Runat="Server">
<title>产品销售确认</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
 <asp:Button runat="server" id="btnConfirm" CssClass="ButtonFlat" OnClick="btnConfirm_Click" Text="销售确认" />
<table border="0" cellpadding="0"  cellspacing="0">
<tr><td>
&nbsp;客户姓名&nbsp;&nbsp;<asp:TextBox id="txtCustomerName" Width="230" runat="server"></asp:TextBox>

</td></tr>
<tr><td>

<uc:Product ID="product1" runat="server" OnScanChanged="scanChange_Click" />

</td></tr>


</table>
</asp:Content>

