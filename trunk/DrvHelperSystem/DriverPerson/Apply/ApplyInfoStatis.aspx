<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyInfoStatis.aspx.cs" Inherits="DriverPerson_Apply_ApplyInfoStatis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
     <script type="text/javascript" src="../../js/setday.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td>
                    预录入统计<br />
                </td>
            </tr>
            <tr class="table-bottom">
                <td>
                    审核时间起：<input onclick="setday(this)" id="txtBeginDate" runat="server" />
                    &nbsp; 
                   审核时间止：
                    &nbsp;&nbsp;&nbsp;
                    
                    <input onclick="setday(this)" id="txtEndDate" runat="server" />
                    <asp:Button ID="btnSearch" runat="server"  Text="查询" 
                        onclick="btnSearch_Click" />
                   
                </td>
            </tr>
            <tr class="table-content">
                <td>
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;<asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
                        Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="jxmc" HeaderText="驾校"></asp:BoundColumn>
                            <asp:BoundColumn DataField="total" HeaderText="总数"></asp:BoundColumn>
                             <asp:BoundColumn DataField="total_checked" HeaderText="已审核"></asp:BoundColumn>
                              <asp:BoundColumn DataField="total_uncheck" HeaderText="未审核"></asp:BoundColumn>
                              <asp:BoundColumn DataField="total_checkfail" HeaderText="审核失败"></asp:BoundColumn>
                            
                            <asp:BoundColumn DataField="local_total_checked" HeaderText="已审核(本地)"></asp:BoundColumn>
                              <asp:BoundColumn DataField="local_total_uncheck" HeaderText="未审核(本地)"></asp:BoundColumn>
                              <asp:BoundColumn DataField="local_total_checkfail" HeaderText="审核失败(本地)"></asp:BoundColumn>
                              
                             <asp:BoundColumn DataField="nolocal_total_checked" HeaderText="已审核(非本地)"></asp:BoundColumn>
                              <asp:BoundColumn DataField="nolocal_total_uncheck" HeaderText="未审核(非本地)"></asp:BoundColumn>
                              <asp:BoundColumn DataField="nolocal_total_checkfail" HeaderText="审核失败(非本地)"></asp:BoundColumn>
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
