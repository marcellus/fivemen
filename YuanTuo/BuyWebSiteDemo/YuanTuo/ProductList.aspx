<%@ Page Language="C#" MasterPageFile="~/Layout/YuanTuoSearch.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="YuanTuo_ProductList" Title="无标题页" %>

<%-- 在此处添加内容控件 --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <input id="hidPages" runat="server" type="hidden"  value="1"/>
<table  border="0"  style=" table-layout:fixed" ><tr><td style="width:100px">&nbsp;
&nbsp;
&nbsp;
&nbsp;</td>
<td>

<table width="100%" border="0" align="center" style="vertical-align:top">
<%=GeneratorHtml%>


</table> 

<div style="margin-top:-2px; text-align:center">
<span style="float:left;width:205px;height:45px">
<asp:ImageButton ID="btnPrePage" ImageUrl="~/YuanTuo/images/prepage.png"  
        Width="205" Height="45" runat="server" onclick="btnPrePage_Click" />
</span>
<span style="text-align:center; clear:both; height:45px; width:650px; position:relative;top:0px;left:0px">
<marquee style="text-align:center; vertical-align:middle" scrollAmount="4" width="650" onmouseover="stop()" onmouseout="start()">
<div  style="text-align:center; vertical-align:middle; color:red;  margin-top:10px;font-size:20pt" >
<%=AdContent%>
</div>
</marquee>
</span><span style="float:right;width:205px;height:45px">
<asp:ImageButton ID="btnNextPage" ImageUrl="~/YuanTuo/images/nextpage.png" 
        Width="205" Height="45" runat="server" onclick="btnNextPage_Click" />
</span>

</div>

</td>

</tr></table>

  
</asp:Content>