<%@ Page Language="C#" MasterPageFile="~/Layout/YuanTuoSearch.master" AutoEventWireup="true" CodeFile="Store.aspx.cs" Inherits="YuanTuo_Store" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<table  border="0" style="vertical-align:top" ><tr style="vertical-align:top"><td style="width:130px">&nbsp;
&nbsp;
&nbsp;
&nbsp;</td><td style="vertical-align:top;">
&nbsp;
<asp:Button ID="btnClear" runat="server" Text="清空购物车" 
        onclick="btnClear_Click" />
        <br />
   <asp:Repeater runat="server" id="repeater1" 
        > 
<HeaderTemplate> 
<table width="100%" border="0" align="center"><tr> 
</HeaderTemplate> 
<ItemTemplate> 
<td>
<table border="0" style="width:380px"><tr>

<td style="width:166px;height:169px">
<img width="166" height="169" alt="" onclick='javascript:location.href="ProductDetail.aspx?id=<%#Eval("id") %>";' src='<%#Eval("ad1") %>' /></td>
<td style="">
<span>产品名称：<%#Eval("product_name") %></span>
<br />
<span>品   牌：<%#Eval("pinpai") %></span>
<br />
<span>规   格：<%#Eval("guige") %></span>
<br />
<span>产   地：<%#Eval("changdi") %></span>
<div style="height:30px"></div>
<span style="color:Red;font-size:20pt">$<%#Eval("price") %></span>
<span style=" color:Gray;text-decoration:line-through;font-size:20pt">$<%#Eval("disaccount") %></span>

</td>
</tr></table>
</td> 
</tr>
</ItemTemplate> 
<FooterTemplate> 
</table> 
</FooterTemplate> 
</asp:Repeater>
</td></tr></table>
</asp:Content>

