<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="UserManage_UserList" %>
<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户列表</title>
    <link href="../css/main.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 800px;">
        <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td>
                    系统管理－用户管理
                </td>
            </tr>
            <tr class="table-bottom">
                <td>
                    用户全名：<asp:TextBox ID="txtUserName" runat="server" 
                        ></asp:TextBox>
                    
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="查询" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click1" Text="添加" />
                </td>
            </tr>
            <tr class="table-content">
                <td>
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;<asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" OnItemCommand="DataGrid1_ItemCommand1"
                        Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="id" HeaderText="编号"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_login_name" HeaderText="登陆名"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_full_name" HeaderText="用户全名"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_idcard" HeaderText="证明<br/>号码"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_workid" HeaderText="工号"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_beginip" HeaderText="IP起<br/>始地址"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_endip" HeaderText="IP结<br/>束地址"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_state" HeaderText="状态"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="重置<br/>密码">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnResetPwd" runat="server" AlternateText="重置密码" CommandArgument='<%#Eval("id") %>'
                                        CommandName="ResetPwd" ImageUrl="~/images/modify.gif" ToolTip="重置密码" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
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
                    <cc1:simplepager id="SimplePager1" runat="server" allowbinded="True" bindcontrolstring="DataGrid1">
                </cc1:simplepager>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
