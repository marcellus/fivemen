<%@ Control Language="C#" AutoEventWireup="true" CodeFile="viewSiteInfo.ascx.cs" Inherits="FpSystem_UserControler_viewSiteInfo" %>
     <table style=" width:100%; height:100%; font-weight:bold" class="table-border" >
        <tr class="table-content">
          <td class="table-title" style=" width:80px; text-align:right">日期:</td>
          <td style=" width:180px"> <asp:Label ID="lbToday" runat="server"></asp:Label></td>
          <td class="table-title" style=" width:80px; text-align:right">场地: </td>
          <td  style=" font-size:1.3e " ><asp:Label ID="lbSiteName" runat="server"></asp:Label></td>
          <td class="table-title" style=" width:120px; text-align:right">限制人数: </td>
          <td style=" width:120px"><asp:Label ID="lbSiteLimit" runat="server"></asp:Label> </td>
        </tr>
     </table>