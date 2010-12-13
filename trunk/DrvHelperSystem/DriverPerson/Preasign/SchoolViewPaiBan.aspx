<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolViewPaiBan.aspx.cs" Inherits="DriverPerson_Preasign_SchoolViewPaiBan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>排班表</title>
      <meta content="no-cache" http-equiv="pragma">
    <meta content="no-cache,must-revalidate" http-equiv="Cache-Control">
     <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/popcalendar.js"></script>
     <script type="text/javascript" src="../../js/setday.js"></script>
    <base target="_self"></base>
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
    

    
        <br />
        (输入想预约的日期，并点击查看按钮，查看相应的排班，然后根据排班分配给本驾校<br />
        的预约数量点击进入到预约界面，在预约界面输入身份证明号码，并点击预约，预约的结果可在1-2个工作日在预约反馈中查看)<br />
    
        <br />
    
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
     <asp:TableCell ID="xq1km1zs"><asp:Label ID="txtxq1km1zs"  ReadOnly="True" Width="40" runat="server"></asp:Label>
        
     </asp:TableCell>
      <asp:TableCell ID="xq1km1fp"></asp:TableCell>
       <asp:TableCell ID="xq1km2zs"><asp:Label ID="txtxq1km2zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
         </asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell ID="xq1km3zs"><asp:Label ID="txtxq1km3zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
         </asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期二</asp:TableCell>
     <asp:TableCell ID="xq2km1zs"><asp:Label ID="txtxq2km1zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
         </asp:TableCell>
      <asp:TableCell></asp:TableCell>
        <asp:TableCell ID="xq2km2zs"><asp:Label ID="txtxq2km2zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
         </asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell ID="xq2km3zs"><asp:Label ID="txtxq2km3zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
         </asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期三</asp:TableCell>
     <asp:TableCell ID="xq3km1zs"><asp:Label ID="txtxq3km1zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
         </asp:TableCell>
      <asp:TableCell></asp:TableCell>
       <asp:TableCell ID="xq3km2zs"><asp:Label ID="txtxq3km2zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
         </asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell ID="xq3km3zs"><asp:Label ID="txtxq3km3zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
         </asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期四</asp:TableCell>
     <asp:TableCell ID="xq4km1zs"><asp:Label ID="txtxq4km1zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
         </asp:TableCell>
      <asp:TableCell></asp:TableCell>
       <asp:TableCell ID="xq4km2zs"><asp:Label ID="txtxq4km2zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
        </asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell ID="xq4km3zs"><asp:Label ID="txtxq4km3zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
         </asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期五</asp:TableCell>
     <asp:TableCell ID="xq5km1zs"><asp:Label ID="txtxq5km1zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
        </asp:TableCell>
      <asp:TableCell></asp:TableCell>
        <asp:TableCell ID="xq5km2zs"><asp:Label ID="txtxq5km2zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
         </asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell ID="xq5km3zs"><asp:Label ID="txtxq5km3zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
        </asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期六</asp:TableCell>
     <asp:TableCell ID="xq6km1zs"><asp:Label ID="txtxq6km1zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
         </asp:TableCell>
      <asp:TableCell></asp:TableCell>
        <asp:TableCell ID="xq6km2zs"><asp:Label ID="txtxq6km2zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
       </asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell ID="xq6km3zs"><asp:Label ID="txtxq6km3zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
        </asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
     <asp:TableRow CssClass="table-content">
    <asp:TableCell CssClass="table-title">星期日</asp:TableCell>
     <asp:TableCell ID="xq7km1zs"><asp:Label ID="txtxq7km1zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
        </asp:TableCell>
      <asp:TableCell></asp:TableCell>
       <asp:TableCell ID="xq7km2zs"><asp:Label ID="txtxq7km2zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
         </asp:TableCell>
        <asp:TableCell></asp:TableCell>
         <asp:TableCell ID="xq7km3zs"><asp:Label ID="txtxq7km3zs" ReadOnly="True" Width="40" runat="server"></asp:Label>
        </asp:TableCell>
          <asp:TableCell></asp:TableCell>
    </asp:TableRow>
    </asp:Table>
    <br />
    <br />
    </form>

</body>
</html>
