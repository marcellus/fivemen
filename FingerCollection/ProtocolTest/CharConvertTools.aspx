<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CharConvertTools.aspx.cs" Inherits="ProtocolTest.CharConvertTools" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>转码小工具</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr><td colspan="2">转码小工具</td></tr>
    <tr><td colspan="2">
        <asp:Button ID="Button1" runat="server" Text="Button" />&nbsp;<asp:Button ID="Button2"
            runat="server" Text="Button" />
            &nbsp;<asp:Button ID="Button3"
            runat="server" Text="Button" />
            &nbsp;<asp:Button ID="Button4"
            runat="server" Text="Button" />
            &nbsp;<asp:Button ID="Button5"
            runat="server" Text="Button" />
            </td></tr>
    <tr><td>转换前</td><td>转换后</td></tr>
    <tr><td>
        <asp:TextBox ID="TextBox1" runat="server" Height="140px" TextMode="MultiLine" 
            Width="327px"></asp:TextBox></td><td>
            <asp:TextBox ID="TextBox2" runat="server" Height="139px" TextMode="MultiLine" 
                Width="325px"></asp:TextBox></td></tr>
    
    </table>
    </div>
    </form>
</body>
</html>
