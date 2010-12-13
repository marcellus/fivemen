<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DictEdit.aspx.cs" Inherits="CommonPage_DictEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>字典编辑</title>
    <meta content="no-cache" http-equiv="pragma">
    <meta content="no-cache,must-revalidate" http-equiv="Cache-Control">
    <link href="../css/main.css" rel="Stylesheet" type="text/css" />
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="4" cellspacing="1" class="table-border" >
            <tr class="poptable-title">
                <td colspan="4">
                    编号<asp:Label ID="lbId" runat="server"></asp:Label>
                    字典详细信息：
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                    类别名：
                </td>
                <td colspan="3" style="width: 50px">
                    <asp:DropDownList ID="cbTypeName" runat="server" Height="16px" Width="233px" 
                        CssClass="ddl" Font-Size="15pt">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" >
                    文本值：
                </td>
                <td >
                    <asp:TextBox ID="txtDictText" runat="server"></asp:TextBox>
                </td>
                <td class="table-title" >
                    代码值：
                </td>
                <td >
                    <asp:TextBox ID="txtDictValue" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" >
                    说明1：
                </td>
                <td >
                    <asp:TextBox ID="txtDes1" runat="server"></asp:TextBox>
                </td>
                <td class="table-title">
                    说明2：
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtDes2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                    说明3：
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtDes3" runat="server"></asp:TextBox>
                </td>
                <td class="table-title">
                    状态：
                </td>
                <td class="style5">
                    <asp:RadioButtonList ID="rblState" runat="server" RepeatColumns="2" 
                        >
                        <asp:ListItem Selected="True">有效</asp:ListItem>
                        <asp:ListItem>无效</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            
            <tr class="table-content">
                <td class="table-content" colspan="4" style="text-align: center">
                    <asp:Button ID="btnSure" runat="server" OnClick="btnSure_Click" Text="确定" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="Button2" class="button" onclick="javascript:window.opener=null;window.close();"
                        type="button" value="关闭" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
