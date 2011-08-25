<%@ Page Title="" Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpSiteConfig.aspx.cs" Inherits="FpSystem_FpHelper_FpSiteConfig" %>
<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div style="width: 800px;">
        <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td>
                    ���ع���
                </td>
            </tr>
            <tr class="table-bottom">
                <td>
                    ��������<asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox>
                    &nbsp; 
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="��ѯ" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click1" Text="���" />
                </td>
            </tr>
            <tr class="table-content">
                <td>
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;<asp:DataGrid ID="dgSites" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" OnItemCommand="dgSites_ItemCommand1"
                        Width="100%" >
                        <Columns>
                            <asp:BoundColumn DataField="id" HeaderText="���"></asp:BoundColumn>
                            <asp:BoundColumn DataField="name" HeaderText="������"></asp:BoundColumn>
                            <asp:BoundColumn DataField="descp" HeaderText="��������"></asp:BoundColumn>
                            <asp:BoundColumn DataField="limit" HeaderText="��������"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="��ϸ">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDetail" runat="server" AlternateText="��ϸ" CommandArgument='<%#Eval("id") %>'
                                        CommandName="Detail" ImageUrl="~/images/modify.gif" ToolTip="��ϸ" />
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

