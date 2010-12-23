<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="FpSystem_FpHelper_Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
<form id="fingerform" style="width:30px" runat="server">
  <asp:Button  runat="server" Text="指纹验证" ID="Button1" 
        onclick="btnIdentity_Click" />

</form>

    <form id="form1" runat="server">
    <div>
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
    </div>
    </form>
</body>
</html>
