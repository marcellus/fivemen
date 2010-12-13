<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleEdit.aspx.cs" Inherits="UserManage_RoleEdit" %>

<%@ Register Assembly="WebControls" Namespace="WebControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色管理</title>
    <link rel="Stylesheet" type="text/css" href="../css/styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <!--<div align=right>
    <input type=Button value="增加角色" onclick="javascript:window.location='RoleAlter.aspx';" /></div>-->
        <br />
        <div>
            <table align="center" border="0" cellpadding="4" cellspacing="1" class="table-border"
                width="800px">
                <tr align="center" class="table-title">
                    <td colspan="2">
                        角色管理</td>
                </tr>
                <tr class="table-content">
                    <td align="right" colspan=2>
                        角色名：<asp:TextBox ID="tbRoleName" runat="server"></asp:TextBox><asp:Button
                            ID="btnRoleName" CssClass="button" runat="server" Text="搜索" /></td>
                </tr>
                <tr class=table-content>
                    <td colspan="2" align="left">
                        <asp:DataGrid ID="dgRole" runat="server" AutoGenerateColumns="False" OnDeleteCommand="dgRole_DeleteCommand"
                            OnItemDataBound="dgRole_ItemDataBound" OnEditCommand="dgRole_EditCommand" Width="100%"
                            BorderWidth="0px" CellPadding="4" CellSpacing="1" CssClass="table-border">
                            <Columns>
                                <asp:BoundColumn DataField="roleid" HeaderText="roleid" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="rolename" HeaderText="角色名称"></asp:BoundColumn>
                                <asp:BoundColumn DataField="rolestring" HeaderText="权限字符串"></asp:BoundColumn>
                                <asp:BoundColumn DataField="roledsc" HeaderText="角色描述"></asp:BoundColumn>
                                <asp:EditCommandColumn CancelText="取消" EditText="&lt;img src=&quot;../images/modify.gif&quot; border=0 /&gt;"
                                    HeaderText="编辑" UpdateText="更新"></asp:EditCommandColumn>
                                <asp:ButtonColumn HeaderText="删除" Text="&lt;img src=&quot;../images/delete.gif&quot; border=0 /&gt;"
                                    CommandName="Delete"></asp:ButtonColumn>
                            </Columns>
                            <HeaderStyle CssClass="table-title" />
                            <SelectedItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" ForeColor="Red" />
                            <EditItemStyle CssClass="table-content" />
                            <ItemStyle CssClass="table-content" />
                        </asp:DataGrid>
                        <cc1:SimplePager ID="SimplePager1" runat="server" AllowBinded="True" BindControlString="dgRole">
                        </cc1:SimplePager>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
