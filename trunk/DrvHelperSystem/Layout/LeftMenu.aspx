<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeftMenu.aspx.cs" Inherits="Layout_LeftMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>左边的树形菜单</title>
  
</head>
<body  style=" padding:0; margin:0; background-color: #eef3f9;text-align:left; vertical-align:top;">
    <form id="form1" runat="server" style=" padding:0; margin:0;text-align:left; vertical-align:top;">
    <div style=" padding:0; margin:0;text-align:left; vertical-align:top;">
    
        <asp:TreeView ID="TreeView1" runat="server" MaxDataBindDepth="2" 
            Target="main" Font-Size="15pt">
        </asp:TreeView>
    
    </div>
    </form>
</body>
</html>
