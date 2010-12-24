<%@ Page Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpViewLessonRecord.aspx.cs" Inherits="FpSystem_FpHelper_FpViewStudentRecord" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<FpUCL:viewStudentInfo   runat="server"></FpUCL:viewStudentInfo>
           <table class="table-border">
               <tr>
                <td class="table-title" style="width:25%"></td>
                <td  class="table-title" style="width:30%">进场时间</td>
                <td class="table-title" style="width:30%">离场时间</td>
                </tr>
                
                <tr>
                  <td class="table-content">上午上课</td>
                  <td class="table-content"><asp:Label ID="lbStuLessonEnter1" runat="server"></asp:Label></td>
                  <td class="table-content"><asp:Label ID="lbStuLessonLeave1" runat="server"></asp:Label></td>
                </tr>
                
                <tr>
                  <td class="table-content">下午上课</td>
                  <td class="table-content"><asp:Label ID="lbStuLessonEnter2" runat="server"></asp:Label></td>
                  <td class="table-content"><asp:Label ID="lbStuLessonLeave2" runat="server"></asp:Label></td>
                </tr>
                
                <tr>
                  <td class="table-content" colspan="3" style="color:Red; font-size:1.5em"><asp:Label ID="lbStudentAlertMsg" runat="server"></asp:Label></td>
                </tr>
             </table>

</asp:Content>

