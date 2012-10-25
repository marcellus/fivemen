<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProtocolTest._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       发送内容：<br />
        <asp:TextBox ID="txtSend" runat="server" Height="89px" TextMode="MultiLine" 
            Width="392px"></asp:TextBox>
        <br />
        <asp:Button ID="btnSend" runat="server" onclick="btnSend_Click" 
            style="width: 40px" Text="发送" />
        <br />
        接受到的内容：<br />
        <asp:TextBox ID="txtGet" runat="server" Height="153px" TextMode="MultiLine" 
            Width="386px"></asp:TextBox>
    </div>
    </form>
</body>
</html>
