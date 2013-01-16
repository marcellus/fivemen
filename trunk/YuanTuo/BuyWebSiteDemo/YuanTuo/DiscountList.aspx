<%@ Page Language="C#" MasterPageFile="~/Layout/BackManagerListLayout.master" AutoEventWireup="true" CodeFile="DiscountList.aspx.cs" Inherits="YuanTuo_DiscountList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div>
 <fieldset>
    <legend>查询条件</legend>
     
    请选择产品：<asp:DropDownList ID="ddlProducts" runat="server"  Width="195px">
    </asp:DropDownList>&nbsp;&nbsp;
    <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click1" />&nbsp;
<asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click1" Text="添加折扣信息" />
  </fieldset>
  <br />
</div>
<div> <wc:procedurepager ID="ProcedurePager1" runat="server" AllowBinded="True" 
        BindControlString="dgLists" FieldString="id,productid,discount,startdate,enddate,(select name from yuantuo_product_info where id=productid) as name,(select price from yuantuo_product_info where id=productid) as price" PageSize="10" 
        SortString="id desc" TableName="yuantuo_product_discount">
    </wc:procedurepager></div>
<div>
 <asp:DataGrid ID="dgLists" runat="server" AutoGenerateColumns="false" 
            BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
            Width="100%" onitemcommand="dgLists_ItemCommand" onselectedindexchanged="dgLists_SelectedIndexChanged" 
           >
         <Columns>
             <asp:BoundColumn DataField="name" HeaderText="产品名称"  ItemStyle-Width="120"></asp:BoundColumn>
              <asp:BoundColumn DataField="price" HeaderText="价格" DataFormatString="{0:N1}" ItemStyle-Width="120"></asp:BoundColumn>
            <asp:BoundColumn DataField="discount" HeaderText="折扣" DataFormatString="{0:N1}"  ItemStyle-Width="300"></asp:BoundColumn>
            <asp:BoundColumn DataField="startdate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="开始时间" ItemStyle-Width="150"></asp:BoundColumn>
             <asp:BoundColumn DataField="enddate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="结束时间" ItemStyle-Width="150"></asp:BoundColumn>

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
   

</div>
</asp:Content>

