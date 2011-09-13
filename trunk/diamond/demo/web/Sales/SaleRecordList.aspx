<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SaleRecordList.aspx.cs" Inherits="Sales_SaleRecordList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<ajax:AjaxPanel>

<div>
<fieldset>
    <legend>
        查询条件
    </legend>
    <div style="margin-left:10px">
        目标门店&nbsp;
        <asp:DropDownList ID="ddlShop" runat="server">
        </asp:DropDownList>
        
        &nbsp;&nbsp;销售员&nbsp;<asp:TextBox ID="txtSaleName" runat="server"></asp:TextBox>
        &nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server"  OnClick="btnSearch_Click" CssClass="ButtonFlat" Text="查询" />

    </div>
    <div style="margin-left:10px">
      
    </div>
</fieldset>
</div>
<br />
<br />
<ft:GridViewEx CssClass="gvStyle" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" runat="server" AutoUpdateAfterCallBack="true"
                                    Width="100%" ID="gridview" 
            AutoGenerateColumns="False" AllowPaging="false" AllowSorting="false"
                                    
            GridLines="Horizontal" >
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                    <Columns>
                                       
                                        <asp:TemplateField HeaderText="序号" HeaderStyle-Width="60px"  ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                            <%#String.Format("{0}", (((GridViewRow)Container).RowIndex + 1) )%>
                                            </ItemTemplate>

<HeaderStyle Width="60px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                       </asp:TemplateField>
                                       <asp:HyperLinkField DataNavigateUrlFormatString="ProductAssignmentPlanDetail.aspx?id={0}" 
                DataTextField="Name"  DataNavigateUrlFields="Id" Target="_blank" HeaderText="调拨单号" HeaderStyle-Width="120px" ItemStyle-Width="120px"  SortExpression="Name" Visible="true" />
                                        
                                        <asp:BoundField HeaderText="目标门店" DataField="ShopName" 
                                            ReadOnly="true" HeaderStyle-Width="160px" ItemStyle-Width="160px" >
<HeaderStyle Width="160px"></HeaderStyle>

<ItemStyle Width="160px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="出库时间" DataField="OutStoreTime" 
                                            SortExpression="Connector" ReadOnly="true"
                                            HeaderStyle-Width="80px" ItemStyle-Width="80px" >
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                         <asp:BoundField HeaderText="出 库 人" DataField="OutStoreScanner" 
                                            ReadOnly="true" HeaderStyle-Width="80px" ItemStyle-Width="80px" >
                                  
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                        
                                         <asp:BoundField HeaderText="签收时间" DataField="InShopTime" 
                                            ReadOnly="true" HeaderStyle-Width="80px" ItemStyle-Width="80px" >
                                  
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                        
                                         <asp:BoundField HeaderText="签 收 人" DataField="InShopScanner" 
                                            ReadOnly="true" HeaderStyle-Width="80px" ItemStyle-Width="80px" >
                                  
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>

                                        </asp:BoundField>
                                         <asp:BoundField HeaderText="状    态" DataField="State" 
                                            ReadOnly="true" HeaderStyle-Width="80px" ItemStyle-Width="80px" >
                                  
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                  
                                    </Columns>
                           
    </ft:GridViewEx>

</ajax:AjaxPanel>
</asp:Content>

