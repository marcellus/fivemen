<%@ Page Language="C#" MasterPageFile="~/Layout/Master/MainPage.master" AutoEventWireup="true" CodeFile="RoleList.aspx.cs" Inherits="System_RoleManage_RoleList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>角色管理</title>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
        <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td>
                    系统管理－角色管理
                </td>
            </tr>
            <tr class="table-bottom">
                <td>
                    角色名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    &nbsp; 
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="查询" />
                    &nbsp;&nbsp;&nbsp;
                   
                    <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="添加" /></td>
            </tr>
            <tr class="table-content">
                <td>
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;<asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px"  OnItemCommand="DataGrid1_ItemCommand1" CellPadding="1" CellSpacing="1" CssClass="table-border" 
                        Width="100%">
                        <Columns>
                            <asp:BoundColumn  ItemStyle-HorizontalAlign="Center" DataField="id" HeaderText="编号"></asp:BoundColumn>
                            <asp:BoundColumn  ItemStyle-HorizontalAlign="Center" DataField="c_role_name" HeaderText="角色名"></asp:BoundColumn>

                            <asp:BoundColumn  ItemStyle-HorizontalAlign="Center" DataField="i_dep_type" HeaderText="部门类别"></asp:BoundColumn>
                           
                            <asp:BoundColumn  ItemStyle-HorizontalAlign="Center" DataField="c_des1" HeaderText="预留字段1"></asp:BoundColumn>
                            <asp:BoundColumn  ItemStyle-HorizontalAlign="Center" DataField="c_des2" HeaderText="预留字段2"></asp:BoundColumn>
                            <asp:BoundColumn  ItemStyle-HorizontalAlign="Center" DataField="c_des3" HeaderText="预留字段3"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="详细" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            
                            <asp:ImageButton runat="server" AlternateText="详细" CommandArgument='<%#Eval("id") %>' ToolTip="详细" ID="btnDetail" CommandName="Detail" ImageUrl="~/images/modify.gif" />
                            </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="删除" ItemStyle-HorizontalAlign="Center">
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
                <td>
                    <cc1:ProcedurePager ID="ProcedurePager1" runat="server" AllowBinded="True" 
                        BindControlString="DataGrid1">
                    </cc1:ProcedurePager>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

