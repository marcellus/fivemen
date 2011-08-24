<%@ Page Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpViewExamRecord.aspx.cs" Inherits="FpSystem_FpHelper_FpViewExamRecord" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <FpUCL:viewStudentInfo ID="ucStudentInfo"   runat="server"></FpUCL:viewStudentInfo>
  
  <table class="table-border">
        <tr>
                  <td class="table-content" colspan="3" style="color:Red; font-size:1.5em"><asp:Label ID="lbStudentAlertMsg" runat="server"></asp:Label></td>
         </tr>
  </table>
  
</asp:Content>

