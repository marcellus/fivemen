<%@ Page Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpAttendLesson.aspx.cs" Inherits="FpSystem_FpHelper_FpAttendLesson" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>上课指纹考勤</h1>
  <asp:Button  runat="server" Text="指纹验证" ID="btnIdentity" 
        onclick="btnIdentity_Click" />
   <br />
   <asp:Label runat="server"  ID="lbUserID" />
   
   <table class="table-border">
      <tr>
         <td class="table-title">学员身份证</td>
         <td  class="table-content"><asp:Label  ID="lbStuIdCard" runat="server" /></td>
         <td  class="table-title">学员姓名</td>
         <td class="table-content"><asp:Label ID="lbStrName" runat="server" /></td>
      </tr>
      
      <tr>
         <td colspan="4" class="table-content">
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
         </td>
      </tr>
   </table>
</asp:Content>

