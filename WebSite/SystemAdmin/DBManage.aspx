<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DBManage.aspx.cs" Inherits="SystemAdmin_DBManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>数据库管理</title>
    <link href="../css/styles.css" rel="Stylesheet" type="text/css" />
</head>
<body style=" text-align:center; vertical-align:middle;margin-top:100px">
    <form id="form1" runat="server"  style=" text-align:center; vertical-align:middle;">
    
        <table border="0" class="table-border" cellpadding="4" cellspacing="1">
            <tr class="table-title">
                <td colspan="2">
                    系统管理－数据库管理</td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                    备份（备份数据库到本地）：</td>
                <td >
                    <asp:Button ID="Button1" runat="server" CssClass="button" Text="备份" OnClick="Button1_Click" /></td>
            </tr>
            <tr  class="table-content">
                <td class="table-title">
                    还原（把本地的备份还原到服务器上）：</td>
                <td >
                    <input id="File1" class="button" style="width: 249px" type="file" runat="server" />
                    &nbsp;&nbsp;<asp:Button ID="Button2" runat="server" CssClass="button" Text="还原" OnClick="Button2_Click" /></td>
            </tr>
        </table>
  
    
    
    </form>
</body>
</html>
