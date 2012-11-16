<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SocketProtocolTest.aspx.cs" Inherits="ProtocolTest._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       
       <table border="1" cellpadding="0" cellspacing="0">
       <tr>
       <td>目标主机IP：<asp:TextBox ID="TextBox5" runat="server" Width="249px"></asp:TextBox></td>
             <td>目标主机端口：<asp:TextBox ID="TextBox8" runat="server" Width="87px"></asp:TextBox></td>
           
            
       </tr>
       <tr>
       <td colspan="2">发送内容：</td>
       </tr>
       <tr>
       <td>字符串</td>
             <td>ASCII码</td>
           
            
       </tr>
       <tr>
       <td><asp:TextBox ID="TextBox2" runat="server" Height="89px" TextMode="MultiLine" 
            Width="383px"></asp:TextBox></td>
             <td><asp:TextBox ID="TextBox3" runat="server" Height="89px" TextMode="MultiLine" 
            Width="383px"></asp:TextBox></td>
             <td>
            
       </tr>
       <tr>  <td>十六进制</td><td>二进制</td></tr>
       <tr>
       <td><asp:TextBox ID="txtSend" runat="server" Height="89px" TextMode="MultiLine" 
            Width="383px"></asp:TextBox></td>
             <td><asp:TextBox ID="TextBox1" runat="server" Height="89px" TextMode="MultiLine" 
            Width="383px"></asp:TextBox></td>
             <td>
            
       </tr>
       
       
       <tr>
       <td colspan="2"><asp:Button ID="btnSend" runat="server" onclick="btnSend_Click" 
            style="width: 40px" Text="发送" /></td>
       </tr>
       <tr>
       <td colspan="2">接受到的内容：</td>
       </tr>
       
       <tr>
       <td>字符串</td>
             <td>ASCII码</td>
            
            
       </tr>
       <tr>
       <td><asp:TextBox ID="TextBox6" runat="server" Height="89px" TextMode="MultiLine" 
            Width="383px"></asp:TextBox></td>
             <td><asp:TextBox ID="TextBox7" runat="server" Height="89px" TextMode="MultiLine" 
            Width="383px"></asp:TextBox></td>
             <td>
            
       </tr>
             
       </tr>
       <tr>  <td>十六进制</td><td>二进制</td></tr>
        <tr>
       <td><asp:TextBox ID="txtGet" runat="server" Height="89px" TextMode="MultiLine" 
            Width="383px"></asp:TextBox></td>
             <td><asp:TextBox ID="TextBox4" runat="server" Height="89px" TextMode="MultiLine" 
            Width="383px"></asp:TextBox></td>
             <td>
            
       </tr>
       </table>
       
       
    </div>
    </form>
</body>
</html>
