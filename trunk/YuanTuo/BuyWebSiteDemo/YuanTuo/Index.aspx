<%@ page language="C#" masterpagefile="~/Layout/YuanTuoWebToCustomer.master" AutoEventWireup="true" CodeFile="Index.aspx.cs"  Inherits="YuanTuo_Index" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height:20px">
    <script type="text/javascript">
    function changeLocation()
    {
    //  alert("changeLocation");
    var ad1=document.getElementById("ad1");
     var ad2=document.getElementById("ad2");
    //  var ifr=document.getElementById("hksiframe");
    // alert(document.frames["hksiframe"]);
      // alert(document.frames[0]);
      // alert(document.frames["hksiframe"].location.href);
     //  alert(document.frames[0].location.href);
      document.frames["hksiframe"].location.href="about:blank";
     // document.frames["hksiframe"].document.domain="";
     // document.frames[0].location.href =url; 
      //window.frames["iframeName属性"].location.href="xxxx.asp"
      //frames.youname.src = url;
     ad1.style.display="";
     ad2.style.display="none";
     Play2();
   
     //MediaPlayer.Play() 暂停: MediaPlayer.Pause() 
    }
    function changeHks()
    {
   // alert("changeHks");
    var ad1=document.getElementById("ad1");
     var ad2=document.getElementById("ad2");
      
    //  document.frames["hksiframe"].document.domain="http://www.hkstv.hk";
      document.frames["hksiframe"].location.href="http://www.hkstv.hk/front/online_play.action";
     ad1.style.display="none";
     ad2.style.display="";
     Pause2();
    }
    function Pause2()
    {
      var locvedio=document.getElementById("locvedio");
     locvedio.Pause();
    }
    function Play2()
    {
      var locvedio=document.getElementById("locvedio");
     locvedio.Play();
    }
    </script>
    </div>
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

<td style="width:850px; text-align:center; margin-top:10px; padding-top:10px; ">
<br />
<div id="ad1" style="position:absolute;top:240px;left:125px;display:none ">

<div style="z-index:-1;">
<object id="locvedio" type="video/x-msvideo" data="<%=VedioUrl%>"  width="850" height="480" style="z-index:-1">
<param id ="locvediosrc" name="src"value="<%=VedioUrl%>" />
        <param name="autostart" value="true" />
        
         <param name="loop" value="true" />
         <param name="ShowControls" value="0" />
</object> 
</div>
</div>

<div id="ad2" style="position:absolute;top:240px;left:220px;
      width:645px;height:475px; overflow:hidden; ">

<div style=" position:absolute;  background-color:Blue">

<iframe name="hksiframe" id="hksiframe" src="http://www.hkstv.hk/front/online_play.action" 
 scrolling="no" style="width:645px;height:675px; margin-top:-225px">

</iframe>
</div>
</div>
<br />


</td>
 
</tr>

</table>


</div>

<div style=" position:fixed;top:400px; text-align:left; margin-left:0px; width:140px;height:300px; ">
<div style="height:120px">
<input type="button" id="btnChangePanel2" onclick="changeLocation();"
 value="本地视频" style="z-index:56789;left:0px;top:0px; width:100px;height:60px"  />
 </div>
<input type="button" onclick="changeHks();"
 style="left:0px;top:0px;
     width:100px;height:60px; z-index:56789" id="Button1" value="香港卫视" />
     
</div>

</asp:Content>

