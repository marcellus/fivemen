<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YuyueDayLimitList.aspx.cs" Inherits="DriverPerson_Preasign_YuyueDayLimit" %>
<%@ Register Assembly="FT.Web" Namespace="WebControls" tagprefix="WC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>预约间隔时间管理</title>
    <link href="../../css/main.css" rel="Stylesheet" type="text/css">
    <script type="text/javascript" src="../../js/popcalendar.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td colspan="2">
                    预约间隔限制管理
                </td>
            </tr>
            <tr class="table-bottom">
                <td colspan="2">
                    <asp:Button ID="btnAdd" runat="server"  Text="添加" onclick="btnAdd_Click" />
                </td>
            </tr>
            <tr class="table-content">
                <td colspan="2">
                    <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
                        Width="100%" onitemcommand="DataGrid1_ItemCommand">
                        <Columns>
                            <asp:BoundColumn DataField="id" HeaderText="编号"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_cartype" HeaderText="车辆类别"></asp:BoundColumn>
                            <asp:BoundColumn DataField="i_days" HeaderText="间隔时间"></asp:BoundColumn>
                            <asp:BoundColumn DataField="i_km" HeaderText="考试科目"></asp:BoundColumn>
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
                   <WC:simplepager id="SimplePager1" runat="server" allowbinded="True" bindcontrolstring="DataGrid1">
                </WC:simplepager>
                </td>
            </tr>
            </table>
    </form>
</body>
</html>
