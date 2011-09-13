<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShopManageList.aspx.cs" Inherits="Shop_ShopManageList" Title="门店管理" Theme="DefaultTheme" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div>
<fieldset>
    <legend>
        查询条件
    </legend>
    <div style="margin-left:10px">
        店&nbsp;&nbsp;名&nbsp;&nbsp;<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        &nbsp;&nbsp;<asp:Button ID="btnSearch"  CssClass="ButtonFlat"  OnClick="btnSearch_Click"  runat="server" Text="查询" />
    </div>
</fieldset>
</div>
<br />
<br />
<ft:GridViewEx CssClass="gvStyle" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" runat="server" AutoUpdateAfterCallBack="true"
                                    Width="100%" ID="gridview" 
            AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True"
                                    DefaultSortExp="Id" 
            GridLines="Horizontal" IsIndexChange="False" lblpageIndex="0" 
            lblSortDirection="" lblSortExp="" lbltotal="0" PageSize="5" WhereClause="">
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                    <Columns>
                                       
                                        <asp:TemplateField HeaderText="序号" HeaderStyle-Width="60px"  ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                            <%#String.Format("{0}", (((GridViewRow)Container).RowIndex + 1) )%>
                                            </ItemTemplate>

<HeaderStyle Width="60px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                       </asp:TemplateField>
                                        <asp:BoundField HeaderText="门店名" DataField="Name" SortExpression="Name"
                                            ReadOnly="true" HeaderStyle-Width="120px" ItemStyle-Width="120px" >
<HeaderStyle Width="120px"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="地  址" DataField="Address" SortExpression="Address"
                                            ReadOnly="true" HeaderStyle-Width="160px" ItemStyle-Width="160px" >
<HeaderStyle Width="160px"></HeaderStyle>

<ItemStyle Width="160px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="联系人" DataField="Connector" 
                                            SortExpression="Connector" ReadOnly="true"
                                            HeaderStyle-Width="80px" ItemStyle-Width="80px" >
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                         <asp:BoundField HeaderText="联系电话" DataField="Mobile" SortExpression="Mobile"
                                            ReadOnly="true" HeaderStyle-Width="80px" ItemStyle-Width="80px" >
                                  
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                  
                                    </Columns>
                           
                                    <PagerSettings Mode="NumericFirstLast" Position="Top" PageButtonCount="5" />
                                    
    </ft:GridViewEx>

  


</asp:Content>