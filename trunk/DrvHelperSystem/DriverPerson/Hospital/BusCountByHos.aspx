<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BusCountByHos.aspx.cs" Inherits="DriverPreson_Hospital_BusCountByHos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>医院体检统计信息</title>
    <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/popcalendar.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 800px;">
        <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td colspan="2">
                    医院体检统计信息
                </td>
            </tr>
            
             <tr class="table-bottom">
                <td>
                    操作时间起：<input onclick="popUpCalendar(this,document.getElementById('txtBeginDate'),'yyyy-mm-dd')" id="txtBeginDate" runat="server" />
                    </td><td>
                   操作时间止：
   
                    
                    <input onclick="popUpCalendar(this,document.getElementById('txtEndDate'),'yyyy-mm-dd')" id="txtEndDate" runat="server" />
                     
                </td>
            </tr>
             <tr class="table-bottom">
                <td>
                    统计方式：<asp:DropDownList ID="DropDownList1" runat="server" Height="16px" 
                        Width="154px" Font-Size="15pt">
                        <asp:ListItem Selected="True">按医院名称</asp:ListItem>
                        <asp:ListItem>按医院用户</asp:ListItem>
                    </asp:DropDownList>
                    </td><td>
                     <asp:Button ID="Button1" runat="server" OnClick="btnSearch_Click" Text="统计" />
                </td>
            </tr>
            
           
           
            <tr class="table-content">
                <td colspan="2"><asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
                        Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="hospital" HeaderText="体检医院/用户"></asp:BoundColumn>
                            <asp:BoundColumn DataField="desp1" HeaderText="已受理未体检"></asp:BoundColumn>
                            <asp:BoundColumn DataField="desp2" HeaderText="已年度体检"></asp:BoundColumn>
                            <asp:BoundColumn DataField="desp3" HeaderText="车管所已核对"></asp:BoundColumn>
                            <asp:BoundColumn DataField="desp4" HeaderText="受理退办"></asp:BoundColumn>

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
