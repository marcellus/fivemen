<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestConnection.aspx.cs" Inherits="TestConnection" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript" src="js/ajax.js" ></script>
     <script type="text/javascript" src="js/print.js" ></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
        <a href="#" onclick="printgzd();">测试打印</a>
    
    </div>
    </form>
</body>
</html>
