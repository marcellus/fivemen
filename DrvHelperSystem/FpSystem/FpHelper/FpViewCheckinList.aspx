<%@ Page Title="" Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpViewCheckinList.aspx.cs" Inherits="FpSystem_FpHelper_FpViewCheckinList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table class="table-border" style="  width:100%">
  
      <%
          ArrayList checkInLogs=ViewState[typeof(FpCheckinLog).Name] as ArrayList;
          for (int i = checkInLogs.Count; i > 0;i-- )
          {
              FpCheckinLog checkInLog = checkInLogs[i-1] as FpCheckinLog;    
          %> 
      <tr class="table-content" style="  padding:3px;">
      <!--<td ><%=i %></td> -->
      
      <td style=" width:60px"><%=checkInLog.CHECKIN_NAME %></td>
      <td  style=" width:150px"><%=checkInLog.CHECKIN_IDCARD %></td>
      <td ><%=checkInLog.CHECKIN_DATE.ToShortTimeString() %></td>
       </tr>
  <%} %>
 
  
</table>

</asp:Content>

