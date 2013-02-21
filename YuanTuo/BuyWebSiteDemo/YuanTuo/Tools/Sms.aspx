<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sms.aspx.cs" Inherits="YuanTuo_Tools_Sms" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>短信发送页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color:AppWorkspace">
    <div style="border-bottom:solid 1px black;color:Teal; font-family: 宋体, Arial, Helvetica, sans-serif; font-size: xx-large; font-weight: bolder;">
    请输入以下内容后点击发送：
    </div>
    <div>
     <br />
      <br />
    &nbsp;
    对方手机号：
    <br />
        &nbsp;
        <asp:TextBox ID="txtMobile" runat="server" Width="170px"></asp:TextBox>
        <br />
&nbsp;
        短信内容：<br />
&nbsp;
        <asp:TextBox ID="txtContent" runat="server" Height="66px" TextMode="MultiLine" 
            Width="350px"></asp:TextBox>
        <br />
        <br />
&nbsp;
        <asp:Button ID="btnSend" runat="server" Height="29px" onclick="btnSend_Click" 
            Text="发   送" Width="100px" />
&nbsp;&nbsp;
        <asp:Label ID="lbSend" runat="server" Font-Bold="True" Font-Names="Arial" 
            ForeColor="Red"></asp:Label>
    </div>
    </div>
    </form>
</body>
</html>
