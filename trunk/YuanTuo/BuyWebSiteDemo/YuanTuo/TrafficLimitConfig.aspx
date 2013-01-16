<%@ Page Language="C#" MasterPageFile="~/Layout/BackManagerListLayout.master" AutoEventWireup="true" CodeFile="TrafficLimitConfig.aspx.cs" Inherits="YuanTuo_TrafficLimitConfig" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
 <fieldset>
    <legend>查询条件</legend>
     
    请选择城市：<asp:DropDownList ID="ddlCity" runat="server"  Width="195px">
    </asp:DropDownList>
     &nbsp;&nbsp;
    <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" />
&nbsp;&nbsp;<asp:Button ID="btnAdd" runat="server" Text="新增" 
         onclick="btnAdd_Click"  />
  </fieldset>
  <br />
</div>
<div>
 <WC:ProcedurePager ID="ProcedurePager1" runat="server" AllowBinded="True" 
        BindControlString="dgLists" FieldString="id,citycode,weekday,name,limitcontent" PageSize="10" 
        SortString="citycode asc" TableName="common_traffic_limitinfo left join common_weather_city on citycode=common_weather_city.code">
    </WC:ProcedurePager>
    </div>
    <div>
 <asp:DataGrid ID="dgLists" runat="server" AutoGenerateColumns="false" 
            BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
            Width="100%" onitemcommand="dgLists_ItemCommand" 
            onitemdatabound="dgLists_ItemDataBound" >
         <Columns>
            
            <asp:BoundColumn DataField="name" HeaderText="城市"  ItemStyle-Width="120"></asp:BoundColumn>
            <asp:BoundColumn DataField="weekday" HeaderText="星期几" ItemStyle-Width="60"></asp:BoundColumn>
            <asp:BoundColumn DataField="limitcontent" HeaderText="限行内容"  ItemStyle-Width="300"></asp:BoundColumn>
            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" HeaderText="详细">
                            <ItemTemplate>
                            
                            <asp:ImageButton   runat="server" AlternateText="详细" CommandArgument='<%#Eval("id") %>' ToolTip="详细" ID="btnDetail" CommandName="Detail" ImageUrl="~/images/modify.gif" />
                            </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="删除">
                            <ItemTemplate>
                            <asp:ImageButton runat="server" AlternateText="删除" CommandArgument='<%#Eval("id") %>' ToolTip="删除" OnClientClick="return confirm('确定删除吗？');" ID="btnDelete" CommandName="Delete" ImageUrl="~/images/delete.gif" />
                            </ItemTemplate>
                            </asp:TemplateColumn>
         </Columns>
         
          <HeaderStyle CssClass="table-title-grid" />
          <ItemStyle CssClass="table-content-grid" />
          <AlternatingItemStyle  CssClass="table-content-grid-alter"/>
       </asp:DataGrid>
       </div>
</asp:Content>

