<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="true" CodeFile="PaibanEdit.aspx.cs" Inherits="DriverPreson_Preasign_PaibanEdit" %>

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
<script type="text/javascript">
function printviewex()
{
//alert("beginprintview");
Table1.border='1';
//alert('1');
//Table1.style.borderWidth='3px';
Table1.cellspacing='0';
Table1.cellpadding='0';
//alert('2');
var obj=document.getElementById("wb");
//alert("obj:"+obj);
//alert(wb);
obj.ExecWB(7,1);
//alert("exebeginprintview");
Table1.border='0';
Table1.cellspacing='1';
Table1.cellpadding='4';
//alert('2');

}
</script>
<style   media="print "> 
.noprint   {   display:   none   } 
</style>

</head>
<body>
    <form id="form1" runat="server">
    <object id="wb" height="0" width="0"  
classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2" name="wb">

     </object>
    <div style=" width:100%" class="noprint">
    
        <asp:HiddenField ID="hidColOld" runat="server" Value="-1" />
        <asp:HiddenField ID="hidRowOld" runat="server" />
        <asp:HiddenField ID="hidRowNew" runat="server" />
        <asp:HiddenField ID="hidColNew" runat="server" />
    
        <br />
        
        查看日期&nbsp; 
        <input  onclick="setday(this)"  id="txtDate" runat="server" />
&nbsp;
        <asp:Button ID="btnSubmit" runat="server" Text="查看" onclick="btnSubmit_Click" />
&nbsp;

<input type="button" value="打印预览" style="" id="printview" onclick="javascript:printviewex();" />
    
<br />
    
        地点&nbsp;&nbsp;&nbsp; 
        <asp:DropDownList ID="cbKsdd" runat="server" Font-Size="15pt">
        </asp:DropDownList>
&nbsp;&nbsp; 场次&nbsp;&nbsp;&nbsp; 
        <asp:DropDownList ID="cbKscc" runat="server" Font-Size="15pt">
        </asp:DropDownList>
&nbsp; 驾校&nbsp;&nbsp;&nbsp; 
        <asp:DropDownList ID="cbSchool" runat="server" Font-Size="15pt">
        </asp:DropDownList>
&nbsp; 人数&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="txtNum" runat="server" Width="41px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbtn" runat="server" onclick="lbtn_Click">分配</asp:LinkButton>
        <br />
        <br />
    

    
        <br />
    
        <br />
    
    </div>
    
    <asp:Table ID="Table1" runat="server"  BorderWidth="0"  CellPadding="4" CellSpacing="1" CssClass="table-border" >
    <asp:TableRow CssClass="table-title">
    
    
    <asp:TableCell RowSpan="2">星期\科目</asp:TableCell>
     <asp:TableCell ColumnSpan="2">科目一</asp:TableCell>
      <asp:TableCell ColumnSpan="2">科目二</asp:TableCell>
       <asp:TableCell ColumnSpan="2">科目三</asp:TableCell>
      
    
    </asp:TableRow>
    
    <asp:TableRow CssClass="table-title">
     <asp:TableCell>总数</asp:TableCell>
      <asp:TableCell Width="80px">分配</asp:TableCell>
       <asp:TableCell>总数</asp:TableCell>
      <asp:TableCell>分配</asp:TableCell> 
      <asp:TableCell>总数</asp:TableCell>
      <asp:TableCell>分配</asp:TableCell>
      
    
    </asp:TableRow>
    <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期一</asp:TableCell>
     <asp:TableCell ID="xq1km1zs"><asp:TextBox ID="txtxq1km1zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton1" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton2" onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" />
     </asp:TableCell>
      <asp:TableCell ID="xq1km1fp"></asp:TableCell>
       <asp:TableCell ID="xq1km2zs"><asp:TextBox ID="txtxq1km2zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton   CssClass="noprint" ID="ImageButton39" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton40"  onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
        <asp:TableCell style="table-layout:fixed"></asp:TableCell>
         <asp:TableCell ID="xq1km3zs"><asp:TextBox ID="txtxq1km3zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton41" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton CssClass="noprint" ID="ImageButton42"  onclick="ImageButton_Click" ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期二</asp:TableCell>
     <asp:TableCell ID="xq2km1zs"><asp:TextBox ID="txtxq2km1zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton3" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton4" onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
      <asp:TableCell></asp:TableCell>
        <asp:TableCell ID="xq2km2zs"><asp:TextBox ID="txtxq2km2zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton35" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton36" onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell   ID="xq2km3zs"><asp:TextBox ID="txtxq2km3zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton37" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton38" onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期三</asp:TableCell>
     <asp:TableCell ID="xq3km1zs"><asp:TextBox ID="txtxq3km1zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton5" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton6" onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
      <asp:TableCell></asp:TableCell>
       <asp:TableCell ID="xq3km2zs"><asp:TextBox ID="txtxq3km2zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton31" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton32" onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell ID="xq3km3zs"><asp:TextBox ID="txtxq3km3zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton33" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton34" onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期四</asp:TableCell>
     <asp:TableCell ID="xq4km1zs"><asp:TextBox ID="txtxq4km1zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton7" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton8" onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
      <asp:TableCell></asp:TableCell>
       <asp:TableCell ID="xq4km2zs"><asp:TextBox ID="txtxq4km2zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton27" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton28" onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell ID="xq4km3zs"><asp:TextBox ID="txtxq4km3zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton29" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton30" onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期五</asp:TableCell>
     <asp:TableCell ID="xq5km1zs"><asp:TextBox ID="txtxq5km1zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton9" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton10" onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
      <asp:TableCell></asp:TableCell>
        <asp:TableCell ID="xq5km2zs"><asp:TextBox ID="txtxq5km2zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton23" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton24" onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell ID="xq5km3zs"><asp:TextBox ID="txtxq5km3zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton25" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton26" onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期六</asp:TableCell>
     <asp:TableCell ID="xq6km1zs"><asp:TextBox ID="txtxq6km1zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton11" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton12" onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
      <asp:TableCell></asp:TableCell>
        <asp:TableCell ID="xq6km2zs"><asp:TextBox ID="txtxq6km2zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton19" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton20" onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell ID="xq6km3zs"><asp:TextBox ID="txtxq6km3zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton21" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton22" onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期日</asp:TableCell>
     <asp:TableCell ID="xq7km1zs"><asp:TextBox ID="txtxq7km1zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton13" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton14" onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
      <asp:TableCell></asp:TableCell>
       <asp:TableCell ID="xq7km2zs"><asp:TextBox ID="txtxq7km2zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton15" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton16" onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell ID="xq7km3zs"><asp:TextBox ID="txtxq7km3zs" Width="40" runat="server"></asp:TextBox>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton17" onclick="ImageButton_Click" runat="server"   ToolTip="添加分配"  ImageUrl="~/images/add.gif"/>
         <asp:ImageButton  CssClass="noprint" ID="ImageButton18" onclick="ImageButton_Click"  ImageUrl="~/images/delete.gif"
             runat="server" ToolTip="重新分配" /></asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
    </asp:Table>
    <br />
    <br />
    <asp:Button ID="btnSave"  CssClass="noprint" runat="server" onclick="btnSave_Click" Text="保存本周排班" />
    </form>

</body>
</html>
