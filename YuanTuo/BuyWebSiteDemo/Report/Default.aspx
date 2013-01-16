<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="PigeonInfo_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>小键盘</title>
    <link href="softkey.css" type="text/css" rel="stylesheet">

    <script language="javascript" src="softkeyborad.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
     
            <input id="Text1" type="text" onclick="password1=Text1;showkeyboard();Text1.readOnly=1;Calc.password.value='';" /></div>
    </form>
</body>
</html>
