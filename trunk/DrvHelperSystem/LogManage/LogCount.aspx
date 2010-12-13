<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogCount.aspx.cs" Inherits="LogManage_LogCount" %>
<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="WC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="WC" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>日志统计</title>
    <link href="../css/main.css" rel="Stylesheet" type="text/css" />
        <script type="text/javascript" src="../js/popcalendar.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div style="width: 800px;">
        <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td>
                    系统管理－日志统计
                </td>
            </tr>
            <tr class="table-bottom">
                <td>
                    操作时间起：<input onclick="popUpCalendar(this,document.getElementById('txtBeginDate'),'yyyy-mm-dd')" id="txtBeginDate" runat="server" />
                    &nbsp; 
                   操作时间止
                    &nbsp;&nbsp;&nbsp;
                    
                    <input onclick="popUpCalendar(this,document.getElementById('txtEndDate'),'yyyy-mm-dd')" id="txtEndDate" runat="server" />
                    
                </td>
            </tr>
            <tr class="table-bottom">
                <td>
                    操作者：<asp:TextBox ID="txtOperator" runat="server"></asp:TextBox>
                    &nbsp; 
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="查询" />
                    &nbsp;&nbsp;&nbsp;</td>
            </tr>
            <tr class="table-content">
                <td>
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;<asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
                        Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="编号" HeaderText="编号"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_operator" HeaderText="操作者"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_bustype" HeaderText="业务类别"></asp:BoundColumn>
                            <asp:BoundColumn DataField="sl" HeaderText="数量"></asp:BoundColumn>
                           
                        </Columns>
                        <HeaderStyle CssClass="table-title" />
                        <ItemStyle CssClass="table-content" />
                        <EditItemStyle CssClass="table-content" />
                    </asp:DataGrid>
                    &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr class="table-bottom">
                <td>
                    <WC:ProcedurePager ID="ProcedurePager1" AllowBinded="True"  runat="server" BindControlString="DataGrid1">
                    </WC:ProcedurePager>
&nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
