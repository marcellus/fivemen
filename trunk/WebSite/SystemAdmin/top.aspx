<%@ Page Language="C#" AutoEventWireup="true" CodeFile="top.aspx.cs" Inherits="SystemAdmin_top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
<!--
#Layer1 {
	position:absolute;
	width:760px;
	height:115px;
	z-index:1;
}
#Layer2 {
	position:absolute;
	width:787px;
	height:96px;
	z-index:1;
	left: 0px;
	top: 0;
    background-image: url(imgs/banner.jpg);
    background-repeat:norepeat;
}
body {
	background-image: url(imgs/banner_bg.jpg);
	background-repeat: repeat-x;
	font-size:9pt;
}
-->
    </style>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="Layer2">
            <span style="left: 700px; position: relative; top: 30px">
              <font color="blue">登陆时间：</font><asp:Label ID="Label2" runat="server" Text="11-12-30"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
              <img src="../images/user.gif" />  <asp:Label ID="Label1" runat="server" Text="admin" style="color:#3c4b50"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                               <asp:Button ID="btnCancel" Text="退出" OnClientClick="return confirm('是否确认退出');" runat=server OnClick="btnCancel_Click" />
                               <asp:LinkButton runat="server" ID="help" Text="帮助" OnClick="help_Click"></asp:LinkButton>
                               
                                </span>
        </div>
    </form>
</body>
</html>
