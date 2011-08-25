<%@ Page Title="" Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpSiteConfig.aspx.cs" Inherits="FpSystem_FpHelper_FpSiteConfig" %>
<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div style="width: 800px;">
        <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td>
                    场地管理
                </td>
            </tr>
            <tr class="table-bottom">
                <td>
                    场地名：<asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox>
                    &nbsp; 
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="查询" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click1" Text="添加" />
                </td>
            </tr>
            <tr class="table-content">
                <td>
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;<asp:DataGrid ID="dgSites" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" OnItemCommand="dgSites_ItemCommand1"
                        Width="100%" >
                        <Columns>
                            <asp:BoundColumn DataField="id" HeaderText="编号"></asp:BoundColumn>
                            <asp:BoundColumn DataField="name" HeaderText="场地名"></asp:BoundColumn>
                            <asp:BoundColumn DataField="descp" HeaderText="场地描述"></asp:BoundColumn>
                            <asp:BoundColumn DataField="limit" HeaderText="限制人数"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="详细">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDetail" runat="server" AlternateText="详细" CommandArgument='<%#Eval("id") %>'
                                        CommandName="Detail" ImageUrl="~/images/modify.gif" ToolTip="详细" />
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
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

