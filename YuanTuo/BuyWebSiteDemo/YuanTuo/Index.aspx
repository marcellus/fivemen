<%@ Page Language="C#" MasterPageFile="~/Layout/YuanTuoWebToCustomer.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="YuanTuo_Index" Title="ÎÞ±êÌâÒ³" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height:20px"></div>
<div>
<div>
<table border="0" cellpadding="0" cellspacing="0">
<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
<td>
&nbsp;&nbsp;&nbsp;
</td>
</table>



</div>
<div style="height:20px"></div>
<div style="margin-left:110px;">
<table border="0" cellpadding="0" cellspacing="0">
<tr>

<td style="width:850px; text-align:center; margin-top:10px; padding-top:10px">
<br />
<object type="video/x-msvideo" data="<%=VedioUrl%>"  width="850" height="480">
<param name="src"value="<%=VedioUrl%>" />
        <param name="autostart" value="true" />
        
         <param name="loop" value="true" />
         <param name="ShowControls" value="0">
</object> 


</td>
 
</tr>

</table>


</div>

</asp:Content>

