<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="UserManage_ChangePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改密码</title>
    <link  href="../css/main.css"  rel="Stylesheet" type="text/css" />
      <script type="text/javascript" language="javascript">
    
    function Check()
    {
       if(document.all.txtOldPwd.value=="")
       {
           alert("请输入旧密码！");
           return false;
       }
       else if(document.all.txtNewPwd.value=="")
       {
           alert("请输入新密码！");
           return false;
       }
       else if(document.all.txtNewPwd.value!=document.all.txtRepeatPwd.value)
       {
           alert("所输入的两个新密码不一致！");
           return false;
       }
       return true;
    }
    </script>
</head>
<body>
    <form id="form1" runat="server" style=" ">
   
     <div style="width:500px; height:100%; margin-top:130px;   vertical-align:middle; text-align:center">
    <table  align= "center" valign="middle"
 border="0px" width="0px" valign="middle" cellpadding="4" cellspacing="1" class="table-border">
    <tr class="table-content" >
    <td class="table-title">旧密码：</td>
    <td>
        <asp:TextBox ID="txtOldPwd" runat="server" BorderStyle="Solid" 
            BorderWidth="1px" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    
    <tr style="margin:0px; padding:0;" class="table-content">
    <td class="table-title" style="height: 10px">
        新密码：</td>
    <td style="height: 10px">
        <asp:TextBox ID="txtNewPwd" runat="server" BorderStyle="Solid" 
            BorderWidth="1px" TextMode="Password"></asp:TextBox>
       </td>
    </tr>
   <tr class="table-content">
    <td class="table-title">
        重复新密码：</td>
    <td >
        <asp:TextBox ID="txtRepeatPwd" runat="server" BorderStyle="Solid" 
            BorderWidth="1px" TextMode="Password"></asp:TextBox>
       </td>
    </tr>
    
    
    
 
    
    <tr>
    <td colspan="2" class="table-content" style="text-align:center">
        
        <asp:Button ID="btnSure" runat="server" 
            onclientclick="javascript:return Check();" Text="确定" 
            onclick="btnSure_Click" />
        
    </tr>
    
    </table>
    </div>
    </form>
</body>
</html>
