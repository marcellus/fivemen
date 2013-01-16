<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>购物软件Demo</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <OBJECT ID="DLPrinter" CLASSID="CLSID:5C230622-45E5-4e3c-893C-3BFDDC4DB5E4"  codebase="cab/DLPrinter.cab" height="0" width="0" ></OBJECT>
 <script>
   DLPrinter.MarginLeft=20;
   DLPrinter.MarginRight=20;
   DLPrinter.MarginTop=20;
   DLPrinter.MarginBottom=20;
   DLPrinter.CopyCount=2;
   DLPrinter.PageHeader="这是测试的页眉";
   DLPrinter.PageFooter="这是测试的页脚";
   DLPrinter.IsLandScape=1;
   DLPrinter.ContentURL="testiis1.htm";
 </script>
 
<input type="button" id="btnPrint" value="Print Preview" onclick="DLPrinter.PrintPreview()" />
 <input type="button" id="btnPrint" value="Print with prompt" onclick="DLPrinter.Print()" />
 <input type="button" id="btnPrint" value="Print without prompt" onclick="DLPrinter.PrintDirect()" />

    </div>
    </form>
</body>
</html>
