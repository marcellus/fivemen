<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="RoleManage" %>

<%@ Register Assembly="WebControls" Namespace="WebControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户管理</title>
    <link rel="Stylesheet" type="text/css" href="../css/styles.css" />
    <link type="text/javascript" href="../js/popcalendar.js" />
    <!--<link rel=stylesheet type="text/css" href="../css/table.css" />-->
</head>
<body leftmargin="0" rightmargin="0">
    <form runat="server">
        <table id="tb1" width="800" cellpadding="4" border="0" cellspacing="1" class="table-border"
            align="center">
            <tr align="center">
                <td colspan="2" class="table-title">
                    用户信息</td>
            </tr>
            <tr class="table-content">
                <td align="right" colspan="2">
                    用户名：<asp:TextBox ID="tbUserName" runat="server"></asp:TextBox><asp:Button ID="btnSearch"
                        runat="server" CssClass="button" Text="搜索" OnClick="btnSearch_Click" />
                    </td>
            </tr>
            <tr class="table-content">
                <td colspan="2">
                    <asp:DataGrid ID="dg" runat="server" AutoGenerateColumns="False" OnDeleteCommand="dg_DeleteCommand"
                        AllowPaging="True" OnPageIndexChanged="dg_PageIndexChanged" Width="100%" OnEditCommand="dg_EditCommand"
                        OnItemDataBound="dg_ItemDataBound" CssClass="table-border" BorderWidth="0px"
                        CellPadding="4" CellSpacing="1">
                        <Columns>
                            <asp:BoundColumn DataField="cuserid" HeaderText="cuserid" Visible="False"></asp:BoundColumn>
                            <asp:BoundColumn DataField="cusername" HeaderText="用户名"></asp:BoundColumn>
                            <asp:BoundColumn DataField="cpassword" HeaderText="密码" Visible="False"></asp:BoundColumn>
                            <asp:BoundColumn DataField="csex" HeaderText="性别"></asp:BoundColumn>
                            <asp:BoundColumn DataField="cphone" HeaderText="固定电话"></asp:BoundColumn>
                            <asp:BoundColumn DataField="cmphone" HeaderText="移动电话"></asp:BoundColumn>
                            <asp:BoundColumn DataField="email" HeaderText="Email"></asp:BoundColumn>
                            <asp:BoundColumn DataField="cfax" HeaderText="传真"></asp:BoundColumn>
                            <asp:BoundColumn DataField="province" HeaderText="所在省"></asp:BoundColumn>
                            <asp:BoundColumn DataField="birthday" HeaderText="出生日期" DataFormatString="{0:d}" Visible="False"></asp:BoundColumn>
                            <asp:BoundColumn DataField="typename" HeaderText="部门"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ctype" HeaderText="用户类型"></asp:BoundColumn>
                            <asp:BoundColumn DataField="rolename" HeaderText="角色"></asp:BoundColumn>
                            <asp:EditCommandColumn CancelText="取消" HeaderText="编辑" EditText="&lt;img src=&quot;../images/modify.gif&quot; border=&quot;0&quot;/&gt;">
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" />
                            </asp:EditCommandColumn>
                            <asp:ButtonColumn CommandName="Delete" HeaderText="删除" Text="&lt;img src=&quot;../images/delete.gif&quot; border=&quot;0&quot; /&gt;">
                            </asp:ButtonColumn>
                        </Columns>
                        <HeaderStyle Font-Size="9pt" CssClass="table-title" />
                        <FooterStyle Font-Size="9pt" />
                        <PagerStyle Visible="False" Mode="NumericPages" />
                        <EditItemStyle CssClass="table-content" />
                        <ItemStyle CssClass="table-content" />
                    </asp:DataGrid></td>
            </tr>
            <tr class=table-content>
                <td colspan=2>
                    <cc1:simplepager id="SimplePager1" runat="server" AllowBinded="True" BindControlString="dg"></cc1:simplepager>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
