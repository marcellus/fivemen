<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="Admin_ProductList" %>
<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="WC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品列表编辑</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td>
                   产品列表<br />
                   <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click1" Text="添加" />
                    &nbsp;&nbsp;<asp:Button ID="Button1" runat="server"  Text="刷新" onclick="Button1_Click" />
                </td>
            </tr>
            
            <tr class="table-content">
                <td>
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;<asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" OnItemCommand="DataGrid1_ItemCommand1"
                        Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="id" HeaderText="编号"></asp:BoundColumn>
                             <asp:BoundColumn DataField="title" HeaderText="产品名称"></asp:BoundColumn>

                            <asp:TemplateColumn HeaderText="详细">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDetail" runat="server" AlternateText="详细" CommandArgument='<%#Eval("id") %>'
                                        CommandName="Detail" ImageUrl="~/images/modify.gif" ToolTip="详细" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="删除">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDelete" runat="server" AlternateText="删除" CommandArgument='<%#Eval("id") %>'
                                        CommandName="Delete" ImageUrl="~/images/delete.gif" OnClientClick="return confirm('确定删除吗？');"
                                        ToolTip="删除" />
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
                <td>
                 <WC:simplepager id="SimplePager1" runat="server" allowbinded="True" bindcontrolstring="DataGrid1">
                </WC:simplepager>
                 
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
