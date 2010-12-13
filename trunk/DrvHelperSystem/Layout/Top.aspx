<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top.aspx.cs" Inherits="Layout_Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>页头(只放图片和注销用户和欢迎用语)</title>
    
</head>
<body style=" vertical-align:top; margin-top:0px; background-image:url('../images/banner1.jpg'); padding-top:0px;background-color:#efefef;background-repeat:repeat">
    <form id="form1" runat="server" style="margin-top:20px; font-size:15pt; position:relative;padding-top:0px;vertical-align:top;">
    
    <div style=" line-height:20px;height:20px; font-size:11pt;margin-top:0px;position:relative;vertical-align:top; margin-top:0px;width:200px; vertical-align:top; text-align: right;float:right"><a href="../Layout/MainWelcome.aspx"  onclick="" target="main">返回首页</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" onclick="javascript:window.external.AddFavorite('http://localhost:12345/DrvHelperSystem/index.aspx','驾驶人辅助系统');return false">收藏</a>
<br />
<a href="../UserManage/ChangePwd.aspx"  onclick="" target="main">修改密码</a>&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton
    ID="lbtnCancel" runat="server" onclick="lbtnCancel_Click">注销</asp:LinkButton></div>

  
    欢迎<%=this.Session["OperatorInfo"] == null ? "" : Operator.OperatorName%>
   
    使用驾驶人辅助系统！！！！

    </form>
</body>
</html>
