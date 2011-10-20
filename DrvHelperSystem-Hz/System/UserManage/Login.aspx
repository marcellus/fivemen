<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="System_UserManage_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>系统登录</title>
     <script type="text/javascript">
    function CheckInput()
    {
      if(document.all.txtLoginName.value=="")
      {
         alert("请输入登陆名!");
         
         return false;
      }
      if(document.all.txtPwd.value=="")
      {
        //alert("请输入密码!");
         return true;
      }
      return true;
    }
    
    


    
    </script>
    <script   type="text/javascript"> 
　　if   (top.location   !=   location) 
　　    top.location.href   =   location.href; 

　　 </script> 
</head>
<body style="vertical-align:middle; height:100%; margin-top:0px; text-align:center;">
    <form id="form1" runat="server" style="vertical-align:middle;height:100%;">
    
   <div  style="vertical-align:middle; padding-top:100px; text-align:center;height:100%; ">

    <table style="vertical-align:middle;" border="0" cellspacing="2" cellpadding="0" align="center" bgcolor="#28629B">
    <tr>
      <td style="FILTER: progid:DXImageTransform.Microsoft.Gradient(startColorStr='#33A9FF', endColorStr='#E8E8F0', gradientType='1')" align="center">
        <img src='<%=  this.ResolveUrl("~/images/mainback.jpg") %>' width="600" height="290"></td>
    </tr>
    <tr height="50">
      <td align="center" style=" font-family:宋体;font-size:12pt;">
        <b>用户名</b>&nbsp;<asp:TextBox ID="txtLoginName" runat="server" Height="22px" 
              MaxLength="20" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox>
&nbsp;
          
          &nbsp;&nbsp;
        <b>密码&nbsp;<asp:TextBox ID="txtPwd" runat="server"  Height="22px"   
              MaxLength="20" BorderStyle="Solid" BorderWidth="1px" TextMode="Password"></asp:TextBox>
          </b>&nbsp;
          &nbsp;
          
          <asp:ImageButton ID="imgBtnLogin"  runat="server" 
              ImageUrl="~/images/login_btn.gif" Width="74px" Height="24px" 
              onclientclick="javascript:return CheckInput();" 
              onclick="imgBtnLogin_Click" />
          
          </td>
    </tr>
  </table>
    </div>
    </form>
</body>
</html>

