<%@ Page Language="C#" MasterPageFile="~/Layout/Master/MainPage.master" AutoEventWireup="true" CodeFile="RoleEdit.aspx.cs" Inherits="System_RoleManage_RoleEdit" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <title>角色详细信息</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <div>
        <table class="table-border" style="width: 780px" border="0" cellspacing="1" cellpadding="4">
            <tr class="poptable-title">
                <td colspan="4">
                    编号<asp:Label ID="lbId" runat="server"></asp:Label>
                    部门详细信息：
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                   所属部门类别：
                </td>
                <td >
                    <asp:DropDownList ID="cbDepTypeValue" runat="server">
                    </asp:DropDownList>
                </td>
                 <td class="table-title">
                    角色名称：
                </td>
                <td style="width: 50px">
                    <asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox>
                </td>
            </tr>
            
            <tr class="table-content"> <td class="table-title" style="width: 127px; height: 3px;">
                        角色菜单：
                    </td>
                    <td colspan="3" style="height: 3px;">
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
                <td class="table-content" colspan="4" style="text-align: center">
                    <br />
                    <asp:Button ID="btnSure" runat="server" Width="120px" Text="确定" OnClick="btnSure_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="Button2" class="button" type="button" value="关闭" onclick="javascript:window.opener=null;window.close();" />
                    <div class="sep">
                    </div>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

