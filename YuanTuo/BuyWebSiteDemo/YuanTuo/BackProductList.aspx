<%@ Page Language="C#" MasterPageFile="~/Layout/BackManagerListLayout.master" AutoEventWireup="true" CodeFile="BackProductList.aspx.cs" Inherits="YuanTuo_BackProductList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div>
 <fieldset>
    <legend>查询条件</legend>
     
    请选择产品类别：<asp:DropDownList ID="ddlProductType" runat="server"  Width="195px">
    </asp:DropDownList>&nbsp;&nbsp;请输入产品名称：<asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click1" />&nbsp;
<asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click1" Text="添加新的产品" />
&nbsp;
     <asp:Button ID="btnExport" runat="server" Text="查询并导出" 
         onclick="btnExport_Click" /> 
  </fieldset>
  <br />
</div>
<div> <wc:procedurepager ID="ProcedurePager1" runat="server" AllowBinded="True" 
        BindControlString="dgLists" FieldString="*" PageSize="10" 
        SortString="id desc" TableName="yuantuo_product_info">
    </wc:procedurepager></div>
<div>
 <asp:DataGrid ID="dgLists" runat="server" AutoGenerateColumns="false" 
            BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
            Width="100%" onitemcommand="dgLists_ItemCommand" 
    onitemdatabound="dgLists_ItemDataBound"  
           >
         <Columns>
             <asp:BoundColumn DataField="name" HeaderText="产品名称"  ItemStyle-Width="120"></asp:BoundColumn>
              <asp:BoundColumn DataField="no" HeaderText="产品编号" ></asp:BoundColumn>
            <asp:BoundColumn DataField="price" DataFormatString="{0:N2}" HeaderText="价格" ></asp:BoundColumn>
           
            <asp:BoundColumn DataField="pinpai" HeaderText="品牌" ItemStyle-Width="150"></asp:BoundColumn>
             <asp:BoundColumn DataField="guige"  HeaderText="规格" ItemStyle-Width="150"></asp:BoundColumn>
             <asp:BoundColumn DataField="chandi" HeaderText="场地" ></asp:BoundColumn>
             <asp:BoundColumn DataField="getproductdays" HeaderText="取货天数" ></asp:BoundColumn>
             <asp:BoundColumn DataField="seetimes" HeaderText="浏览次数" ></asp:BoundColumn>
             <asp:BoundColumn DataField="status" HeaderText="产品状态" ></asp:BoundColumn>
              <asp:TemplateColumn ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="上架">
                            <ItemTemplate>
                            
                            <asp:ImageButton   runat="server" AlternateText="上架" CommandArgument='<%#Eval("id") %>' ToolTip="上架" ID="btnOpen" CommandName="Up" ImageUrl="~/images/modify.gif" />
                            </ItemTemplate>
                            </asp:TemplateColumn>
              <asp:TemplateColumn ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="下架">
                            <ItemTemplate>
                            
                            <asp:ImageButton   runat="server" AlternateText="下架" CommandArgument='<%#Eval("id") %>' OnClientClick="javascript:return confirm('确定下架产品吗？');" ToolTip="下架" ID="btnClose" CommandName="Down" ImageUrl="~/images/modify.gif" />
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

