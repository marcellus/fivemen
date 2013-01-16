<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BackManage.aspx.cs" Inherits="YuanTuo_BackManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台管理主界面</title>
    <link href="../css/main.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style=" width:100%;height:768px; vertical-align:top;padding:0 0 0 0; margin:0 0 0 0; text-align:left;">
    <tr><td colspan="2"  style="height:50px; vertical-align:middle; margin-top:0px; background-image:url('../images/banner1.jpg'); padding-top:0px;background-color:#efefef;background-repeat:repeat">
    &nbsp;&nbsp;欢迎<asp:Label ID="lbUserName" runat="server" Text="Label"></asp:Label>登陆终端后台管理系统      <span  id="txtShowDate" ></span>
    </td></tr>
    <tr>
    <td style="width:15%;vertical-align:top; text-align:left; background-color:#eef3f9; padding:0 0 0 0; margin:0 0 0 0;">
    <ul style="list-style:none; float:left; text-align:left; margin-left:5px; padding-left:5px">
    <li></li>
    <li><a target="contentiframe" href="GroupManageList.aspx">分组以及广告管理</a></li>
    <li></li>
    <li><a target="contentiframe" href="TerminalList.aspx">终端管理</a></li>
    <li></li>
    <li><a target="contentiframe" href="BackProductList.aspx">产品管理</a></li>
    <li></li>
    <li><a target="contentiframe" href="TrafficLimitConfig.aspx">限行尾号基本设置</a></li>
    <li></li>
    <li><a target="contentiframe" href="TrafficExList.aspx">限行尾号扩展设置</a></li>
    <li></li>
    <li><a target="contentiframe" href="DiscountList.aspx">打折信息设置</a></li>
    <li></li>
    <li><a target="contentiframe" href="SendInfoList.aspx">赠送信息设置</a></li>
    <li></li>
    
    <li><a target="contentiframe" href="ReportCounter.aspx">销售报表统计</a></li>
    <li></li>
    <li><a target="contentiframe" href="SysConfig.aspx">系统基本设置</a></li>
    <li></li>
     <li><a target="contentiframe" href="../UserManage/ChangePwd.aspx">修改密码</a></li>
    </ul>
    
    </td><td style="vertical-align:top; margin-left:10px;width:85%">  
   <iframe name="contentiframe" id="contentiframe"  frameborder="0" 
    marginwidth="0" marginheight="0" scrolling="no" style="border:none;
        overflow:hidden" height="738px" width="100%" src="Welcome.aspx"></iframe></td></tr>
    
    
    </table>
    <script type="text/javascript">
    function startTime() 
{ 
//alert('beginstarttime');
var today=new Date(); 
var h=today.getHours(); 
//alert(h);
var m=today.getMinutes(); 
if(m.toString().length ==1)
m="0"+m.toString();
//alert(m);
var s=today.getSeconds();
//alert(s.length);
if(s.toString().length ==1)
s="0"+s.toString(); 
//alert(s)
//alert(s);
//alert(document.getElementById('txtShowDate'));
document.getElementById('txtShowDate').innerHTML="现在的时间是"+h+":"+m+":"+s; 
setTimeout('startTime()',1000); 
} 
startTime();
    </script>
    </form>
</body>
</html>
