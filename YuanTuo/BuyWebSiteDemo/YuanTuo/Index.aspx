<%@ Page Language="C#" MasterPageFile="~/Layout/YuanTuoWebToCustomer.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="YuanTuo_Index" Title="无标题页" %>

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
<div id="ad1" style="position:absolute;top:240px;left:125px; display:none">
<input type="button" style="position:absolute;left:10px;top:10px; z-index:56789" id="Button1" value="香港卫视" />
<object type="video/x-msvideo" data="<%=VedioUrl%>"  width="850" height="480" style="z-index:50">
<param name="src"value="<%=VedioUrl%>" />
        <param name="autostart" value="true" />
        
         <param name="loop" value="true" />
         <param name="ShowControls" value="0" />
</object> 
</div>
<div id="ad2" style="position:absolute;top:240px;left:125px">
<input type="button" id="btnChangePanel2" value="本地" style="position:absolute;left:10px;top:10px"  />
<iframe src="http://www.hkstv.hk/front/online_play.action" 
 scrolling="no" style="margin-left:-10px; margin-top:-221px;width:660px;height:650px">

</iframe>-
</div>

</td>
 
</tr>

</table>


</div>

</asp:Content>

