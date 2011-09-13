<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductAssignmentInShopScanner.aspx.cs" Inherits="Assignment_ProductAssignmentInShopScanner" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0px" cellpadding="0" cellspacing="0">

<tr><td style=" vertical-align:top;width:1000px">
<div>请输入调拨单号 
    <asp:TextBox ID="txtPlanName" Width="300px" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" CssClass="ButtonFlat" OnClick="btnSearch_Click" runat="server" Text="查询" />
    <asp:Button ID="btnFinishScanner"  OnClick="btnFinish_Click" CssClass="ButtonFlat" runat="server" Text="完成进店扫描" />
     </div>
     <div>
     
      <ft:GridViewEx CssClass="gvStyle" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" runat="server" AutoUpdateAfterCallBack="true"
                                    Width="100%" ID="gridview" 
            AutoGenerateColumns="False" AllowPaging="false" AllowSorting="false"
                                    >
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                    <Columns>
                                       
                                        <asp:TemplateField HeaderText="序号" HeaderStyle-Width="60px"  ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                            <%#String.Format("{0}", (((GridViewRow)Container).RowIndex + 1) )%>
                                            </ItemTemplate>

<HeaderStyle Width="60px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                       </asp:TemplateField>
                                        <asp:BoundField HeaderText="调拨单号" DataField="Name" 
                                            ReadOnly="true" HeaderStyle-Width="120px" ItemStyle-Width="120px" >
<HeaderStyle Width="120px"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
                                        </asp:BoundField>
                                        
                                        <asp:BoundField HeaderText="目标门店" DataField="ShopName"
                                            ReadOnly="true" HeaderStyle-Width="160px" ItemStyle-Width="160px" >
<HeaderStyle Width="160px"></HeaderStyle>

<ItemStyle Width="160px"></ItemStyle>
                                        </asp:BoundField>
                                          <asp:BoundField HeaderText="产品名称" DataField="Product_Name"
                                            ReadOnly="true" HeaderStyle-Width="120px" ItemStyle-Width="120px" >
<HeaderStyle Width="120px"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
                                        </asp:BoundField>
                                          <asp:BoundField HeaderText="条码" DataField="Barcode"
                                            ReadOnly="true" HeaderStyle-Width="120px" ItemStyle-Width="120px" >
<HeaderStyle Width="120px"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="出库时间" DataField="OutStoreTime" 
                                            ReadOnly="true"
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
     </div>
</td>


<td>
<uc:Product ID="product1" runat="server" OnScanChanged="scanChange_Click" />

</td></tr>

</table>
</asp:Content>

