<%@ Page Language="C#" MasterPageFile="~/Layout/BackManagerListLayout.master" AutoEventWireup="true" CodeFile="TerminalList.aspx.cs" Inherits="TerminalManager_TerminalList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    查询类别：<asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Selected="True">分组一</asp:ListItem>
        <asp:ListItem>分组二</asp:ListItem>
        <asp:ListItem>分组三</asp:ListItem>
    </asp:DropDownList>
   IP: <asp:TextBox ID="txtIp" runat="server"></asp:TextBox>
   &nbsp;<asp:Button ID="Button1"
       runat="server" Text="搜索" />
    
    <br />
    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" AutoGenerateColumns="False" 
        BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" onrowcommand="GridView1_RowCommand">
        <RowStyle BackColor="#F7F7DE" />
        <Columns>
            <asp:BoundField DataField="name" HeaderText="终端名字" />
            <asp:BoundField DataField="ip" HeaderText="终端IP" />
            <asp:BoundField DataField="mac" HeaderText="终端MAC" />
            <asp:BoundField DataField="status" HeaderText="终端状态" />
            <asp:ButtonField ButtonType="Button" CommandName="Refresh" Text="刷新" 
                HeaderText="刷新" />
            <asp:ButtonField ButtonType="Button" CommandName="WakeUp" Text="开机" 
                HeaderText="开机" />
            <asp:ButtonField Text="关机" ButtonType="Button" CommandName="Close" 
                HeaderText="关机" />
            <asp:ButtonField CommandName="Delete" Text="删除" ButtonType="Button" 
                HeaderText="删除" />
            <asp:ButtonField CommandName="Edit" Text="编辑" ButtonType="Button" 
                HeaderText="编辑" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>

</asp:Content>

