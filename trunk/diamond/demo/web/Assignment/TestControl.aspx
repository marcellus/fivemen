<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestControl.aspx.cs" Inherits="Assignment_TestControl" %>
<%@ Register Src="~/Controls/ProductShow.ascx" TagName="Product" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <script type="text/javascript" src="../js/jquery-1.6.2.min.js" ></script>
    <title>测试页面</title>
    <style type="text/css">
  body
  {
  	font-size:11pt;
  }
  input
  {
  	width:80px;
  }
  table td
  {
  	padding:0px;
  	margin:0px;
  }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <uc1:Product id="product1" runat="server">
                </uc1:Product>
    </div>

    
   
    </form>
</body>
</html>

