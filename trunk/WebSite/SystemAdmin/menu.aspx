<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu.aspx.cs" Inherits="SystemAdmin_menu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 
<html  xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>菜单</title>
    <META http-equiv=Content-Type content="text/html; charset=gb2312">
    <META content="Microsoft FrontPage 4.0" name=GENERATOR>
    <LINK href="include/outlook.css"  type=text/css rel=stylesheet>
    
</head>
<body  id="xu" onkeydown="if(event.keyCode==116){event.keyCode=0;return false}" 
onresize="myOnResize();" leftMargin="0" topMargin="0" onload="resize_op5();">
    <form id="form1" runat="server">
   
 
  
 <TABLE id=SHOW height="100%" cellSpacing=0 cellPadding=0 width="100%" 
  border=0><TBODY>
<TR>
    <TD vAlign=top width="100%" style="height: 389px">
      <SCRIPT src="include/crossbrowser.js"></SCRIPT>


      <SCRIPT src="include/outlook.js"></SCRIPT>

      <SCRIPT language=JavaScript>
function right(e) {
  if (navigator.appName == 'Netscape' && (e.which == 3 || e.which == 2))
     return false;
  else if (navigator.appName == 'Microsoft Internet Explorer' &&
    (event.button == 2 || event.button == 3)) {
   // alert("同望科技欢迎您！");
    return false;
  }
 return true;
}
//document.onmousedown=right;
</SCRIPT>


      

<!-- need an onResize event to redraw outlookbar after pagesize changes! --><!-- OP5 does not support onResize event! use setTimeout every 100ms --></TD></TR></TBODY></TABLE>   
    </form>
</body>
</html>
