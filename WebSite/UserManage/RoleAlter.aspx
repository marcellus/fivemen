<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleAlter.aspx.cs" Inherits="UserManage_RoleAlter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>权限管理</title>
    <link rel="stylesheet" type="text/css" href="../css/styles.css" />

    <script language="javascript" type="text/javascript">
<!--

function Reset1_onclick() {

}

// -->
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table align="center" border="0" width="800px" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title" align="center">
                <td colspan="4">
                    修改/添加角色
                </td>
            </tr>
            <tr class="table-content" style="text-align: right;">
                <td colspan="4">
                    <asp:Button ID="btnRoleAdd" runat="server" Text="添加角色" OnClick="btnRoleAdd_Click" CssClass="button" />
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" style="width: 76px">
                    角色名：
                </td>
                <td class="table-content" style="width: 505px">
                    <asp:TextBox ID="tbRoleName" runat="server"></asp:TextBox>
                    <input id="Hidden1" type="hidden" runat="server" />
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" style="width: 76px">
                    权限：</td>
                <td style="width: 505px; text-align: center;">
                    <table width="100%">
                        <tr>
                            <td class="table-title">
                                待选权限：</td>
                            <td rowspan="2" align="center" class="table-content" style="width: 74px">
                                <asp:Button ID="btnRight" runat="server" Text=">" Width="100%" OnClick="btnRight_Click"
                                    CssClass="functionButton" /><br />
                                <br />
                                <asp:Button ID="btnLeft" runat="server" Text="<" Width="100%" OnClick="btnLeft_Click"
                                    CssClass="functionButton" />
                            </td>
                            <td class="table-title">
                                现有权限：</td>
                        </tr>
                        <tr>
                            <td class="table-content">
                                <asp:ListBox ID="lstbOtherRight" runat="server" Rows="10" Width="100%" SelectionMode="Multiple">
                                </asp:ListBox></td>
                            <td>
                                <asp:ListBox ID="lstbNowRight" runat="server" Rows="10" Width="100%" SelectionMode="Multiple">
                                </asp:ListBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="table-content">
                <td height="100" class="table-title" style="width: 76px">
                    角色描述：</td>
                <td colspan="3">
                    <asp:TextBox ID="tbDscp" runat="server" TextMode="MultiLine" Height="86px" Width="258px"></asp:TextBox></td>
            </tr>
            <tr class="table-content">
                <td align="center" colspan="4">
                    <asp:Button ID="btnOK" runat="server" Text="确定" OnClick="btnOK_Click" CssClass="button" />
                    &nbsp;<input type="reset" value="重置" id="Reset1" language="javascript" onclick="return Reset1_onclick()"
                        class="button" />&nbsp;
                    <input type="button" value="返回" onclick="javascript:history.back(-1)" class="button" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
