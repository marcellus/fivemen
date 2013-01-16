<%@ Page Language="C#" MasterPageFile="~/Layout/BackManagerListLayout.master" AutoEventWireup="true" CodeFile="TerminalList.aspx.cs" Inherits="YuanTuo_TerminalList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div>
 <fieldset>
    <legend>查询条件</legend>
     
    请选择分组：<asp:DropDownList ID="ddlGroups" runat="server"  Width="195px">
    </asp:DropDownList>&nbsp;&nbsp;
    <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click1" />&nbsp;
<asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click1" Text="添加新的终端" />
&nbsp;
     <asp:Button ID="btnExport" runat="server" Text="查询并导出" 
         onclick="btnExport_Click" /> 

  </fieldset>
  <br />
</div>
<div> <wc:procedurepager ID="ProcedurePager1" runat="server" AllowBinded="True" 
        BindControlString="dgLists" FieldString="*,'' status" PageSize="10" 
        SortString="id desc" TableName="yuantuo_terminals">
    </wc:procedurepager></div>
<div>
 <asp:DataGrid ID="dgLists" runat="server" AutoGenerateColumns="false" 
            BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
            Width="100%" onitemcommand="dgLists_ItemCommand" 
        onselectedindexchanged="dgLists_SelectedIndexChanged" onitemdatabound="dgLists_ItemDataBound"  
           >
         <Columns>
             <asp:BoundColumn DataField="name" HeaderText="终端名称"  ItemStyle-Width="120"></asp:BoundColumn>
              <asp:BoundColumn DataField="ip" HeaderText="IP地址" ></asp:BoundColumn>
            <asp:BoundColumn DataField="mac" HeaderText="Mac地址" ItemStyle-Width="350"></asp:BoundColumn>
           
            <asp:BoundColumn DataField="storename" HeaderText="门店名称" ItemStyle-Width="150"></asp:BoundColumn>
             <asp:BoundColumn DataField="storephone"  HeaderText="门店电话" ItemStyle-Width="150"></asp:BoundColumn>
             <asp:BoundColumn DataField="onlineseconds" HeaderText="在线时长" ></asp:BoundColumn>
             <asp:BoundColumn DataField="status" HeaderText="终端状态" ></asp:BoundColumn>
              <asp:TemplateColumn ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="开机">
                            <ItemTemplate>
                            
                            <asp:ImageButton   runat="server" AlternateText="开机" CommandArgument='<%#Eval("id") %>' ToolTip="开机" ID="btnOpen" CommandName="Open" ImageUrl="~/images/modify.gif" />
                            </ItemTemplate>
                            </asp:TemplateColumn>
              <asp:TemplateColumn ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="关机">
                            <ItemTemplate>
                            
                            <asp:ImageButton   runat="server" AlternateText="关机" CommandArgument='<%#Eval("id") %>' OnClientClick="javascript:return confirm('确定关闭终端吗？');" ToolTip="关机" ID="btnClose" CommandName="Close" ImageUrl="~/images/modify.gif" />
                            </ItemTemplate>
                            </asp:TemplateColumn>
                            
            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="详细">
                            <ItemTemplate>
                            
                            <asp:ImageButton   runat="server" AlternateText="详细" CommandArgument='<%#Eval("id") %>' ToolTip="详细" ID="btnDetail" CommandName="Detail" ImageUrl="~/images/modify.gif" />
                            </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="删除">
                            <ItemTemplate>
                            <asp:ImageButton runat="server" AlternateText="删除" CommandArgument='<%#Eval("id") %>' ToolTip="删除" OnClientClick="javascript:return confirm('确定删除吗？');" ID="btnDelete" CommandName="Delete" ImageUrl="~/images/delete.gif" />
                            </ItemTemplate>
                            </asp:TemplateColumn>
         </Columns>
         
         <HeaderStyle CssClass="table-title-grid" />
          <ItemStyle CssClass="table-content-grid" />
          <AlternatingItemStyle  CssClass="table-content-grid-alter"/>
       </asp:DataGrid>
    
    </div>
   

</asp:Content>

