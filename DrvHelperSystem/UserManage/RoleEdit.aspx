<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleEdit.aspx.cs" Inherits="UserManage_RoleManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色编辑页</title>
    <meta content="no-cache" http-equiv="pragma">
    <meta content="no-cache,must-revalidate" http-equiv="Cache-Control">
    <link href="../css/main.css" rel="Stylesheet" type="text/css" />
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <table border="0" cellpadding="4" cellspacing="1" class="table-border" style="width: 594px">
                <tr class="poptable-title">
                    <td colspan="2">
                        编号<asp:Label ID="lbId" runat="server"></asp:Label>
                        角色详细信息：
                    </td>
                </tr>
                <tr class="table-content">
                    <td class="table-title">
                        角色名称：
                    </td>
                    <td style="width: 50px">
                        <asp:TextBox ID="txtRoleName" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr class="table-content">
                    <td class="table-title" >
                        角色描述：
                    </td>
                    <td style="width: 50px">
                        <asp:TextBox ID="txtRoleDescription" runat="server"></asp:TextBox>
                    </td>
                   
                </tr>
                <tr class="table-content"> <td class="table-title" style="width: 127px; height: 3px;">
                        角色菜单：
                    </td>
                    <td style="height: 3px;">
                        <asp:TreeView ID="TreeView1" runat="server" MaxDataBindDepth="2" 
                            onload="TreeView1_Load" ontreenodepopulate="TreeView1_TreeNodePopulate" 
                            ShowCheckBoxes="All" BorderStyle="None">
                            <ParentNodeStyle BorderStyle="None" />
                            <HoverNodeStyle BorderStyle="None" />
                            <SelectedNodeStyle BorderStyle="None" />
                            <RootNodeStyle BorderStyle="None" />
                            <NodeStyle BorderStyle="None" />
                            <LeafNodeStyle BorderStyle="None" />
                        </asp:TreeView>
                    </td></tr>
               
                <tr class="table-content">
                    <td class="table-content" colspan="2" style="text-align: center">
                        <asp:Button ID="btnSure" runat="server" OnClick="btnSure_Click" Text="确定" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="Button2" class="button" onclick="javascript:window.opener=null;window.close();"
                            type="button" value="关闭" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
