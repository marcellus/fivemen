<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="SystemAdmin_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户登录</title>
    <link href="../css/styles.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" class="table-border" cellpadding="4" cellspacing="1">
    <tr class="table-content">
                <td class="table-title">用户名</td><td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td></tr>
                  <tr class="table-content">
                <td class="table-title">密码</td><td>
                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td></tr>
     <tr class="table-content">
                <td  colspan="2" style=" text-align:center">
                    <asp:Button ID="Button1" runat="server" CssClass="button" Text="登录" OnClick="Button1_Click" /></td></tr>
    
    </table>
    </div>
    </form>
</body>
</html>
