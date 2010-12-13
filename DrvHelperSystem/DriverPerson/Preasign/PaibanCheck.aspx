<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaibanCheck.aspx.cs" Inherits="DriverPreson_Preasign_PaibanCheck" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看周排班表</title>
     <meta content="no-cache" http-equiv="pragma">
    <meta content="no-cache,must-revalidate" http-equiv="Cache-Control">
     <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/popcalendar.js"></script>
     <script type="text/javascript" src="../../js/setday.js"></script>
    <base target="_self"></base>
    <script Language="text/javascript">
function a(x,y,color)
{document.write("<img border='0' style='position: absolute; left: "+(x)+"; top: "+(y)+";background-color: "+color+"' src='px.gif' width=1 height=1>")}
function getTop(tdobj)
{
vParent = tdobj.offsetParent;
t = tdobj.offsetTop;
while (vParent.tagName.toUpperCase() != "BODY")
{
t += vParent.offsetTop;
vParent = vParent.offsetParent;
}
return t;
}
function getLeft(tdobj)
{
vParent = tdobj.offsetParent;
t = tdobj.offsetLeft;
while (vParent.tagName.toUpperCase() != "BODY")
{
t += vParent.offsetLeft;
vParent = vParent.offsetParent;
}
return t;
}
function line(x1,y1,x2,y2,color)
{
  var tmp
  if(x1>=x2)
  {
    tmp=x1;
    x1=x2;
    x2=tmp;
    tmp=y1;
    y1=y2;
    y2=tmp;
  }
  for(var i=x1;i<=x2;i++)
  {
    x = i;
    y = (y2 - y1) / (x2 - x1) * (x - x1) + y1;
    a(x,y,color);
  }
}

</script>

</head>
<body>
    <form id="form1" runat="server">
    <div style=" width:100%">
    
    
        <br />
        
        查看日期&nbsp; 
        <input  onclick="setday(this)"  id="txtDate" runat="server" />
&nbsp;
        <asp:Button ID="btnSubmit" runat="server" Text="查看" onclick="btnSubmit_Click" />
        &nbsp;
    
    <asp:Button ID="btnCheck" runat="server" onclick="btnSave_Click" 
        Text="审核本周排班" />
    
    </div>
    
    <asp:Table ID="Table1" runat="server"  BorderWidth="0"  CellPadding="4" CellSpacing="1" CssClass="table-border">
    <asp:TableRow CssClass="table-title">
    
    
    <asp:TableCell RowSpan="2">星期\科目</asp:TableCell>
     <asp:TableCell ColumnSpan="2">科目一</asp:TableCell>
      <asp:TableCell ColumnSpan="2">科目二</asp:TableCell>
       <asp:TableCell ColumnSpan="2">科目三</asp:TableCell>
      
    
    </asp:TableRow>
    
    <asp:TableRow CssClass="table-title">
     <asp:TableCell>总数</asp:TableCell>
      <asp:TableCell>分配</asp:TableCell>
       <asp:TableCell>总数</asp:TableCell>
      <asp:TableCell>分配</asp:TableCell> 
      <asp:TableCell>总数</asp:TableCell>
      <asp:TableCell>分配</asp:TableCell>
      
    
    </asp:TableRow>
    <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期一</asp:TableCell>
     <asp:TableCell ID="xq1km1zs"><asp:TextBox ID="txtxq1km1zs"  ReadOnly="True" Width="40" runat="server"></asp:TextBox>
        
     </asp:TableCell>
      <asp:TableCell ID="xq1km1fp"></asp:TableCell>
       <asp:TableCell ID="xq1km2zs"><asp:TextBox ID="txtxq1km2zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
         </asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell ID="xq1km3zs"><asp:TextBox ID="txtxq1km3zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
         </asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期二</asp:TableCell>
     <asp:TableCell ID="xq2km1zs"><asp:TextBox ID="txtxq2km1zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
         </asp:TableCell>
      <asp:TableCell></asp:TableCell>
        <asp:TableCell ID="xq2km2zs"><asp:TextBox ID="txtxq2km2zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
         </asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell ID="xq2km3zs"><asp:TextBox ID="txtxq2km3zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
         </asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期三</asp:TableCell>
     <asp:TableCell ID="xq3km1zs"><asp:TextBox ID="txtxq3km1zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
         </asp:TableCell>
      <asp:TableCell></asp:TableCell>
       <asp:TableCell ID="xq3km2zs"><asp:TextBox ID="txtxq3km2zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
         </asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell ID="xq3km3zs"><asp:TextBox ID="txtxq3km3zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
         </asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期四</asp:TableCell>
     <asp:TableCell ID="xq4km1zs"><asp:TextBox ID="txtxq4km1zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
         </asp:TableCell>
      <asp:TableCell></asp:TableCell>
       <asp:TableCell ID="xq4km2zs"><asp:TextBox ID="txtxq4km2zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell ID="xq4km3zs"><asp:TextBox ID="txtxq4km3zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
         </asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期五</asp:TableCell>
     <asp:TableCell ID="xq5km1zs"><asp:TextBox ID="txtxq5km1zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
        </asp:TableCell>
      <asp:TableCell></asp:TableCell>
        <asp:TableCell ID="xq5km2zs"><asp:TextBox ID="txtxq5km2zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
         </asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell ID="xq5km3zs"><asp:TextBox ID="txtxq5km3zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
        </asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期六</asp:TableCell>
     <asp:TableCell ID="xq6km1zs"><asp:TextBox ID="txtxq6km1zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
         </asp:TableCell>
      <asp:TableCell></asp:TableCell>
        <asp:TableCell ID="xq6km2zs"><asp:TextBox ID="txtxq6km2zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
       </asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell ID="xq6km3zs"><asp:TextBox ID="txtxq6km3zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
        </asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期日</asp:TableCell>
     <asp:TableCell ID="xq7km1zs"><asp:TextBox ID="txtxq7km1zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
        </asp:TableCell>
      <asp:TableCell></asp:TableCell>
       <asp:TableCell ID="xq7km2zs"><asp:TextBox ID="txtxq7km2zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
         </asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell ID="xq7km3zs"><asp:TextBox ID="txtxq7km3zs" ReadOnly="True" Width="40" runat="server"></asp:TextBox>
        </asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
    </asp:Table>
    <br />
    <br />
    </form>

</body>
</html>
