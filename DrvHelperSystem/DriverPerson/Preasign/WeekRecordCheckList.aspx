<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WeekRecordCheckList.aspx.cs" Inherits="DriverPerson_Preasign_WeekRecordCheckList" %>
<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="WC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>周排班列表待审核</title>
      <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/popcalendar.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td colspan="2">
                    周排班表
                </td>
            </tr>
            <tr class="table-bottom">
                <td colspan="2">
                    <input onclick="popUpCalendar(this,document.getElementById('txtBeginDate'),'yyyy-mm-dd')" id="txtBeginDate" runat="server" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server"  Text="查询" onclick="btnAdd_Click" />
                &nbsp;&nbsp;&nbsp;
                    </td>
            </tr>
            <tr class="table-content">
                <td colspan="2">
                    <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
                        Width="100%" onitemcommand="DataGrid1_ItemCommand">
                        <Columns>
                            <asp:BoundColumn DataField="id" HeaderText="编号"></asp:BoundColumn>
                            <asp:BoundColumn DataField="i_week_num" HeaderText="第几周"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_week_range" HeaderText="时间范围"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_check_operator" HeaderText="审核人"></asp:BoundColumn>
                            <asp:BoundColumn DataField="i_checked" HeaderText="审核结果"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="详细">
                            <ItemTemplate>
                            
                            <asp:ImageButton runat="server" AlternateText="详细" CommandArgument='<%#Eval("id") %>' ToolTip="详细" ID="btnDetail" CommandName="Detail" ImageUrl="~/images/modify.gif" />
                            </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="删除">
                            <ItemTemplate>
                            <asp:ImageButton runat="server" AlternateText="删除" CommandArgument='<%#Eval("id") %>' ToolTip="删除" OnClientClick="return confirm('确定删除吗？');" ID="btnDelete" CommandName="Delete" ImageUrl="~/images/delete.gif" />
                            </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <HeaderStyle CssClass="table-title" />
                        <ItemStyle CssClass="table-content" />
                        <EditItemStyle CssClass="table-content" />
                    </asp:DataGrid>
                    &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr class="table-bottom">
                <td colspan="2">
                   <WC:ProcedurePager ID="ProcedurePager1" runat="server" AllowBinded="True" 
                        BindControlString="DataGrid1">
                    </WC:ProcedurePager>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
