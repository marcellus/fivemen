<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="index.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>欢迎使用驾驶人辅助系统</title>
    <META http-equiv="Content-Type" content="text/html" charset="UTF-8">
    <style type="text/css">

</style>
 <style media="print">
        .Noprint{display:none;}
        .PageNext{page-break-after: always;}
    </style>
<script type="text/javascript">
function GetUrlParms()    
{
    var args=new Object();   
    var query=location.search.substring(1);//获取查询串   
    var pairs=query.split("&");//在逗号处断开   
    for(var   i=0;i<pairs.length;i++)   
    {   
        var pos=pairs[i].indexOf('=');//查找name=value   
            if(pos==-1)   continue;//如果没有找到就跳过   
            var argname=pairs[i].substring(0,pos);//提取name   
            var value=pairs[i].substring(pos+1);//提取value   
            args[argname]=unescape(value);//存为属性   
    }
    return args;
}
function InitLoad()
{
    //debugger;
    var args = new Object();
    args = GetUrlParms();
    //如果要查找参数key:
    value = args["returnurl"] ;
    if(value)
    {
        //document.getElementsByName("main").location.href=value;
        window.frames["main"].location.href=value;
    }
}
function ResetHeight(obj)
{
debugger;
alert(parent.myall);
alert(obj.document);
  parent.myall.rows="40,"+obj.document.body.offestHeight;+",20";
  //onload="ResetHeight(this);"
}
</script>
</head>
<frameset rows="80,*,70" id="myall"  frameSpacing="0" frameBorder="0">
<frame frameborder="0"  src= "Layout/Top.aspx"  scrolling="no" />

 <frameset border="0" id="middleFrame" frameSpacing="0" frameBorder="0" cols="250,8,*"> 
  <frame name="submenus"  src="Layout/LeftMenu.aspx" noResize scrolling="no"/>
  <frame name="Links"  src="Layout/newspan.htm"  noResize scrolling="no"/>
  <!--<iframe name="main" id="main" src="Welcome.aspx" scrolling="yes" ></iframe>-->
  <frame name="main"  src="Layout/MainWelcome.aspx"  scrolling="yes"/>
</frameset>

<frame name="foot"  src="Layout/Bottom.aspx" noresize scrolling="no"/>

 
<noframes>
  <body onload="InitLoad();">

  <p>此网页使用了框架，但您的浏览器不支持框架。</p>

  </body>
</noframes>
</frameset>
</html>
