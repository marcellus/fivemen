<%@ Page Title="" Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpViewCheckinList.aspx.cs" Inherits="FpSystem_FpHelper_FpViewCheckinList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table class="table-border">
  
    <asp:Repeater ID="rpLogs" runat="server">
    
    <ItemTemplate>   
       <tr class="table-content">
      <td style="width:30px">1</td>
      <td style="width:60px"><%# Eval("CHECKIN_NAME") %></td>
      <td style="width:160px"><%# Eval("CHECKIN_IDCARD") %></td>
      <td style="width:160px"><%# Eval("CHECKIN_DATE") %></td>
      </tr>
    </ItemTemplate>
    
    </asp:Repeater>
 
  
</table>

</asp:Content>

