<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BusListPrint.aspx.cs" Inherits="DriverPreson_Hospital_BusListPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>打印体检清单</title>
     <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/popcalendar.js"></script>
    
    
</head>
<body>
    <form id="form1" runat="server">
    <div>医院名称：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;生成时间：<asp:Label
        ID="Label2" runat="server" Text="Label"></asp:Label></div>
    <div>
    <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
                        Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="id" HeaderText="流水号"></asp:BoundColumn>
                           
                            <asp:BoundColumn DataField="c_des1" HeaderText="证件号码"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_des2" HeaderText="档案编号"></asp:BoundColumn>
                             <asp:BoundColumn DataField="c_operator" HeaderText="姓名"></asp:BoundColumn>
                            
                        </Columns>
                        <HeaderStyle CssClass="table-title" />
                        <ItemStyle CssClass="table-content" />
                        <EditItemStyle CssClass="table-content" />
                    </asp:DataGrid>
    </div>
    </form>
</body>
</html>
