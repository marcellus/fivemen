<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BusCountByCgs.aspx.cs" Inherits="DriverPreson_Hospital_BusCountByCgs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>各医院体检工作统计</title>
     <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/popcalendar.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="">
        <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td colspan="2">
                    各医院体检工作统计
                </td>
            </tr>
            
             <tr class="table-bottom">
                <td>
                    操作时间起：<input onclick="popUpCalendar(this,document.getElementById('txtBeginDate'),'yyyy-mm-dd')" id="txtBeginDate" runat="server" />
                    </td><td>
                   操作时间止：
   
                    
                    <input onclick="popUpCalendar(this,document.getElementById('txtEndDate'),'yyyy-mm-dd')" id="txtEndDate" runat="server" />
                     <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="统计" />
                </td>
            </tr>
            
           
           
            <tr class="table-content">
                <td colspan="2"><asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
                        Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="hospital" HeaderText="体检医院"></asp:BoundColumn>
                            <asp:BoundColumn DataField="desp1" HeaderText="已受理未体检"></asp:BoundColumn>
                            <asp:BoundColumn DataField="desp2" HeaderText="已年度体检"></asp:BoundColumn>
                            <asp:BoundColumn DataField="desp3" HeaderText="受理退办"></asp:BoundColumn>
                            <asp:BoundColumn DataField="desp4" HeaderText="更新联系方式"></asp:BoundColumn>
                            <asp:BoundColumn DataField="desp5" HeaderText="补打身体证明"></asp:BoundColumn>
                            <asp:BoundColumn DataField="desp6" HeaderText="补打体检回执"></asp:BoundColumn>
                        </Columns>
                        <HeaderStyle CssClass="table-title" />
                        <ItemStyle CssClass="table-content" />
                        <EditItemStyle CssClass="table-content" />
                    </asp:DataGrid>
                    &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
           
        </table>
    </div>
    </form>
</body>
</html>
