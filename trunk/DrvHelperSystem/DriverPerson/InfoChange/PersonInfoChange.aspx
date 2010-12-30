<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonInfoChange.aspx.cs"
Inherits="DriverPerson_PersonInfoChange_PersonInfoChange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>驾驶人联系方式变更备案</title>
<link href="../../css/main.css" rel="Stylesheet" type="text/css" />
<style type="text/css">
table{table-layout: fixed;}
td{width:0}
table th,td{word-wrap:break-word;overflow:hidden/* for ff2 */}



</style>
<script type="text/javascript">
function synphone()
{
document.all.txtNewPhone.value=document.all.txtOldPhone.value;
}
function checkinput()
{
    if(document.all.txtName.value.length==0)
    {
     alert("姓名必须输入！");
     return false;
    }
    if(document.all.txtIdCard.value.length==0)
    {
     alert("证件号码必须输入！");
     return false;
    }
    if(document.all.txtDabh.value.length==0)
    {
     alert("档案编号必须输入！");
     return false;
    }
    if(document.all.txtOldPhone.value.length==0)
    {
     alert("手机号码必须输入！");
     return false;
    }
    
    if(document.all.txtNewAddress.value.length==0)
    {
     alert("联系地址必须输入！");
     return false;
    }
     if(document.all.txtNewAddress.value.indexOf('省')==-1)
    {
     alert("联系地址必须输入省！");
     return false;
    }
       if(document.all.txtNewAddress.value.indexOf('市')==-1)
    {
     alert("联系地址必须输入市！");
     return false;
    }
    if(document.all.txtNewPostCode.value.length==0)
    {
     alert("邮政编码必须输入！");
     return false;
    }
    if(document.all.txtNewPhone.value.length==0)
    {
     alert("联系电话必须输入！");
     return false;
    }
}

</script>

</head>
<body>
<form id="form1" runat="server" onsubmit="return checkinput();">
<div>
<table border="0" cellpadding="4" cellspacing="1" width="200px" class="table-border">
<tr class="table-title">
<td >
驾驶人联系方式变更备案
</td>
</tr>
<tr class="table-title">
<td style="height: 50px" style="text-align: left">
以下项目均为必填（选）项：
</td>
</tr>
<tr class="table-content">
<td class="table-title">
驾驶人姓名&nbsp;&nbsp;

<asp:textbox id="txtName" runat="server">
</asp:textbox>
</td>
</tr>
<tr class="table-content">
<td class="table-title">
身份证明种类

    <asp:dropdownlist runat="server" id="cbIdCardTypeValue" Height="17px" Width="213px" Font-Size="15pt">
    </asp:dropdownlist>
</td>
</tr>
<tr class="table-content">
<td class="table-title">
身份证明号码

<asp:textbox id="txtIdCard" runat="server">
</asp:textbox>
(身份证号码要求18位)
</td>
</tr>
<tr class="table-content">
<td class="table-title">
档 案 编 号&nbsp;
<asp:textbox id="txtDabh" runat="server">
</asp:textbox>
</td>
</tr>
<tr class="table-content">
<td class="table-title">
手 机 号 码&nbsp;
<asp:textbox id="txtOldPhone" runat="server" onblur="synphone();">
</asp:textbox>
<span style="color: red">*</span>
</td>
</tr>
<tr class="table-title">
<td  style="height: 50px" style="text-align: left">
请填写变更后的联系方式，三项都必须输入。
</td>
</tr>
<tr class="table-content">
<td class="table-title">
联 系 地 址&nbsp;

<asp:textbox id="txtNewAddress" runat="server" width="384px">
</asp:textbox>
(必须包含省、直辖市、自治区的名字)
</td>
</tr>
<tr class="table-content">
<td class="table-title">
邮 政 编 码&nbsp;

<asp:textbox id="txtNewPostCode" runat="server">
</asp:textbox>
</td>
</tr>
<tr class="table-content">
<td class="table-title">
联 系 电 话&nbsp;


    <asp:TextBox ID="txtNewPhone" runat="server"></asp:TextBox>


</td>
</tr>
<tr class="table-content">
<td class="table-title">
电 子 邮 箱&nbsp;


    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>


</td>
</tr>

<tr class="table-content">
<td class="table-title">

    <asp:Button ID="btnSave" runat="server" Text="确定" onclick="btnSave_Click" />

</td>
</tr>
</table>
</div>
</form>
</body>
</html>
