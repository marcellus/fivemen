<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="Controls_Menu" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html><head><title>OpenCube Visual Design Pad - Save Document</title><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

<!--[imcss] *** Infinite Menus Core CSS: Keep this section in the document head for full validation. -->
<style type="text/css">.imcm ul,.imcm li,.imcm div,.imcm span,.imcm a{text-align:left;vertical-align:top;padding:0px;margin:0;list-style:none outside none;border-style:none;background-image:none;clear:none;float:none;display:block;position:static;overflow:visible;line-height:normal;}.imcm li a img{vertical-align:top;display:inline;border-width:0px;}.imcm span{display:inline;}.imcm .imclear,.imclear{clear:both;height:0px;visibility:hidden;line-height:0px;}.imcm .imsc{position:relative;}.imcm .imsubc{position:absolute;visibility:hidden;}.imcm li{list-style:none;font-size:1px;float:left;}.imcm ul ul li{width:100%;float:none !important;}.imcm a{display:block;position:relative;}.imcm ul .imsc,.imcm ul .imsubc {z-index:10;}.imcm ul ul .imsc,.imcm ul ul .imsubc{z-index:20;}.imcm ul ul ul .imsc,.imcm ul ul .imsubc{z-index:30;}.imde ul li:hover .imsubc{visibility:visible;}.imde ul ul li:hover  .imsubc{visibility:visible;}.imde ul ul ul li:hover  .imsubc{visibility:visible;}.imde li:hover ul  .imsubc{visibility:hidden;}.imde li:hover ul ul .imsubc{visibility:hidden;}.imde li:hover ul ul ul  .imsubc{visibility:hidden;}.imcm .imea{display:block;position:relative;left:0px;font-size:1px;line-height:0px;height:0px;float:right;}.imcm .imea span{display:block;position:relative;font-size:1px;line-height:0px;}.dvs,.dvm{border-width:0px}/*\*//*/.imcm .imclear,.imclear{font-size:1px;}/**/</style><!--[if IE]><style type="text/css">.imcm .imclear,.imclear{display:none;}.imcm{zoom:1;} .imcm li{curosr:hand;} .imcm ul{zoom:1}.imcm a{zoom:1;}</style><![endif]--><!--[if gte IE 7]><style type="text/css">.imcm .imsubc{background-image:url(ie_css_fix);}</style><![endif]--><!--end-->

<!--[imstyles] *** Infinite Menu Styles: Keep this section in the document head for full validation. -->
<style type="text/css">
    
  
		
		

	/* --[[ Main Expand Icons ]]-- */
	#imenus0 .imeam span,#imenus0 .imeamj span {background-image:url(../Images/sample3_main_arrow.gif); width:7px; height:5px; left:-1px; top:5px; background-repeat:no-repeat;background-position:top left;}
	#imenus0 li:hover .imeam span,#imenus0 li a.iactive .imeamj span {background-image:url(sample3_main_arrow.gif); background-repeat:no-repeat;background-position:top left;}


	/* --[[ Sub Expand Icons ]]-- */
	#imenus0 ul .imeas span,#imenus0 ul .imeasj span {background-image:url(../Images/arrow_sub.gif); width:10px; height:13px; left:0px; top:0px; background-repeat:no-repeat;background-position:top left;}
	#imenus0 ul li:hover .imeas span,#imenus0 ul li a.iactive .imeasj span {background-image:url(../images/arrow_sub.gif); background-repeat:no-repeat;background-position:top left;}


	/* --[[ Main Container ]]-- */
	#imouter0 {background-color:#6fbbf9; border-style:solid; border-color:#769bba; border-width:1px; padding:0px; margin:0px; }


	/* --[[ Sub Container ]]-- */
	#imenus0 li ul {background-color:#cce3f8; border-style:solid; border-color:#356595; border-width:1px; padding:5px; }

/* --[[ Main Items ]]-- */
	#imenus0 li a {color:#330066; text-align:center; font-family:Arial; font-size:12px; font-weight:bold; text-decoration:none; border-style:none; border-color:#000000; border-width:0px; padding:4px 5px 4px 12px; }

		/* [hover] - These settings must be duplicated for IE compatibility.*/
		#imenus0 li:hover>a {background-color:#cce3f8; color:#111111; }
		#imenus0 li a.ihover, .imde imenus0 a:hover {background-color:#cce3f8; color:#111111; }
		/* [active] */
		


	/* --[[ Sub Items ]]-- */
	#imenus0 ul a {color:#111111; text-align:left; font-size:12px; font-weight:normal; text-decoration:none; border-style:none; border-color:#000000; border-width:1px; padding:2px 5px; }

		/* [hover] - These settings must be duplicated for IE comptatibility.*/
		#imenus0 ul li:hover>a {background-color:#ffffff; color:#255585; }
		#imenus0 ul li a.ihover {background-color:#ffffff; color:#255585; }


			/* [active] */
		#imenus0 li a.iactive {background-color:#cce3f8; color:#111111; }

</style><!--end-->
<script language="javascript" type="text/javascript">
  function BuildUrl(ob)
  {
    if(ob.name!="")
    {
        ob.href+="?menu_id="+ob.name;
        ob.id=ob.name;
    }
  }
  function AnchorMenu()
  {
     var nstart,nend,menuID;
     var url=window.location.search;
     if(url.length!=0)
     {
         nstart=url.indexOf("menu_id");
         if(url.indexOf("&")!=-1)
         {
           end=url.indexOf("&");
           menuID=url.substring(nstart+8,end);
         }
         else
         {
            menuID=url.substring(nstart+8,url.length);
         }
         if(menuID.indexOf("$")!=-1)
         {
           menuID=menuID.substring(0,menuID.indexOf("$"));
         }
         var ob=document.getElementById(menuID);
         if(ob!=null)
         {
           ob.style.color="white";
         }
     }
  }
</script>
</head><body link="#0000FF" vlink="#800080" alink="#FF0000" topmargin="0" leftmargin="0"><script language="JavaScript" type="text/javascript">ulm_save_doc=true</script>
<%--<div style=" padding-left:0px; padding-top:0px; width:99.8%" nowrap="nowrap">--%>
<%--<div class="imrcmain0 imgl" style="z-index:999999;position:relative; width:100%">--%>
<div class="imcm imde" id="imouter0" style=" width:100%; height:25px">
<ul id="imenus0">
<%=InitHtml() %>
</ul><%--<div class="imclear">&nbsp;</div>--%>
</div>
<%--</div>--%>
<%--</div>--%>
<script>AnchorMenu();</script>
<!--[imcode]*** Infinite Menus Settings / Code - This script reference must appear last. ***

      *Note: This script is required for scripted add on support only, and IE 6 sub menu functionality.
      *Note: This menu will fully function in all CSS2 browsers with the script removed.-->

<script language="JavaScript" src="../JS/ocscript.js" type="text/javascript"></script>

</body></html>
