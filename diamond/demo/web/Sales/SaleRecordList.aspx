<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="产品销售查询" AutoEventWireup="true" CodeFile="SaleRecordList.aspx.cs" Inherits="Sales_SaleRecordList"  %>

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
            GridLines="Horizontal"  >
            
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                    <Columns>
                                      
                                      
                                        <asp:TemplateField HeaderText="序号" HeaderStyle-Width="60px"  ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                            <%#String.Format("{0}", (((GridViewRow)Container).RowIndex + 1) )%>
                                            </ItemTemplate>

<HeaderStyle Width="60px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                       </asp:TemplateField>
                                       
                                        <asp:BoundField HeaderText="销售人" DataField="Sales" 
                                            ReadOnly="true"  HeaderStyle-Width="120px" ItemStyle-Width="120px" >
<HeaderStyle Width="120px"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
                                        </asp:BoundField>
                                        
                                        
                                         <asp:BoundField HeaderText="销售时间" DataField="SaleTime" 
                                            ReadOnly="true"  HeaderStyle-Width="120px" ItemStyle-Width="120px" >
<HeaderStyle Width="120px"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
                                        </asp:BoundField>
                                        
                                       <asp:BoundField HeaderText="销售时间" DataField="CustomerName" 
                                            ReadOnly="true"  HeaderStyle-Width="120px" ItemStyle-Width="120px" >
<HeaderStyle Width="120px"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="品名" DataField="Product_Name" 
                                            ReadOnly="true"  HeaderStyle-Width="120px" ItemStyle-Width="120px" >
<HeaderStyle Width="120px"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
                                        </asp:BoundField>
                                        
                                        <asp:BoundField HeaderText="条码" DataField="Barcode"
                                            ReadOnly="true"  HeaderStyle-Width="120px" ItemStyle-Width="120px" >
<HeaderStyle Width="120px"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="款号" DataField="Style"
                                            ReadOnly="true" HeaderStyle-Width="160px" ItemStyle-Width="160px" >
<HeaderStyle Width="160px"></HeaderStyle>

<ItemStyle Width="160px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="材质" DataField="Cailiao" 
                                             ReadOnly="true"
                                            HeaderStyle-Width="80px" ItemStyle-Width="80px" >
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                         <asp:BoundField HeaderText="供货商" DataField="Factory_Name" 
                                            ReadOnly="true" HeaderStyle-Width="80px" ItemStyle-Width="80px" >
                                  
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                        
                                         <asp:BoundField HeaderText="工厂货重" DataField="Factory_Weight" 
                                            ReadOnly="true" HeaderStyle-Width="80px" ItemStyle-Width="80px" >
                                  
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                        
                                         <asp:BoundField HeaderText="净金重" DataField="Gold_NetWeight" 
                                            ReadOnly="true" HeaderStyle-Width="80px" ItemStyle-Width="80px" >
                                  
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>

                                        </asp:BoundField>
                                         <asp:BoundField HeaderText="零售价" DataField="Price" 
                                            ReadOnly="true" HeaderStyle-Width="80px" ItemStyle-Width="80px" >
                                  
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                         <asp:BoundField HeaderText="状    态" DataField="SaleState" 
                                            ReadOnly="true" HeaderStyle-Width="80px" ItemStyle-Width="80px" >
                                  
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                  
                                    </Columns>
                                    
    </ft:GridViewEx>

</ajax:AjaxPanel>
</asp:Content>

