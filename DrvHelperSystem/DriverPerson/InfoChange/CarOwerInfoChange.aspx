<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarOwerInfoChange.aspx.cs" Inherits="DriverPerson_PersonInfoChange_CarOwerInfoChange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>车主联系方式变更备案</title>
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
  if(document.all.txtHmhpEnd.value.length<5)
    {
     alert("号码必须输入！");
     return false;
    }
    if(document.all.txtCjh.value.length==0)
    {
     alert("车架号必须输入！");
     return false;
    }
    if(document.all.txtFdjh.value.length==0)
    {
     alert("发动机号必须输入！");
     return false;
    }
    if(document.all.txtDjzs.value.length==0)
    {
     alert("登记证书必须输入！");
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
function citychange()
{
document.all.txtHmhpEnd.value=document.all.cbcity.value;
}

</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<table border="0" cellpadding="4" cellspacing="1" width="200px" class="table-border">
<tr class="table-title">
<td >
车主联系方式变更备案 
</td>
</tr>
<tr class="table-title">
<td style="height: 50px" style="text-align: left">
以下项目均为必填（选）项：
</td>
</tr>
<tr class="table-content">
<td class="table-title">
 请选择证件核发地<select  id="cbcity" name="city" onchange="citychange();" style="font-size:15pt;height:17px;width:213px;">
                                    <option value="">请选择</option>
                                    <option selected="" value="A">广州</option>
                                    <option value="B">深圳</option>
                                    <option value="S">东莞</option>
                                    <option value="E">佛山</option>
                                    <option value="Y">南海</option>
                                    <option value="X">顺德</option>
                                    <option value="G">湛江</option>
                                    <option value="C">珠海</option>
                                    <option value="D">汕头</option>
                                    <option value="F">韶关</option>
                                    <option value="H">肇庆</option>
                                    <option value="J">江门</option>
                                    <option value="K">茂名</option>
                                    <option value="L">惠州</option>
                                    <option value="M">梅州</option>
                                    <option value="N">汕尾</option>
                                    <option value="P">河源</option>
                                    <option value="Q">阳江</option>
                                    <option value="R">清远</option>
                                    <option value="T">中山</option>
                                    <option value="U">潮州</option>
                                    <option value="V">揭阳</option>
                                    <option value="W">云浮</option>


</td>
</tr>
<tr class="table-content">
<td class="table-title">
号 牌 号 码
    <asp:textbox id="txtHmhpPrefix" runat="server" value="粤" enable="false" width="30px">
    </asp:textbox>&nbsp;<asp:textbox id="txtHmhpEnd" onkeyup="this.value=this.value.toUpperCase();" runat="server"></asp:textbox>
   
</td>
</tr>
<tr class="table-content">
<td class="table-title">
号 牌 种 类&nbsp;&nbsp;&nbsp;&nbsp;
<asp:dropdownlist id="cbHpzlValue" style="font-size:15pt;height:17px;width:213px;" runat="server">
    <asp:ListItem Value="01">大型汽车</asp:ListItem>
    <asp:ListItem Value="02">小型汽车</asp:ListItem>
                                <asp:ListItem Value="05">境外汽车</asp:ListItem>
                                <asp:ListItem Value="06">外籍汽车</asp:ListItem>
                                <asp:ListItem Value="07">两、三轮摩托车</asp:ListItem>
                                <asp:ListItem Value="11">境外摩托车</asp:ListItem>
                                <asp:ListItem Value="12">外籍摩托车</asp:ListItem>
                                <asp:ListItem Value="15">挂车</asp:ListItem>
                                <asp:ListItem Value="20">临时入境汽车</asp:ListItem>
                                <asp:ListItem Value="21">临时入境摩托车</asp:ListItem>
                                <asp:ListItem Value="22" Selected="True">临时行驶汽车</asp:ListItem>
                                <asp:ListItem Value="23">公安警车</asp:ListItem>
                                <asp:ListItem Value="99">其它</asp:ListItem>                            
    </asp:dropdownlist>
</td>
</tr>
<tr class="table-content">
<td class="table-title">
车架号码后5位&nbsp;&nbsp;
<asp:textbox id="txtCjh" runat="server">
</asp:textbox>
</td>
</tr>
<tr class="table-content">
<td class="table-title">
发动机号码后5位
<asp:textbox id="txtFdjh" runat="server">
</asp:textbox>
</td>
</tr>
<tr class="table-content">
<td class="table-title">
登记证书号码&nbsp;&nbsp;&nbsp;
<asp:textbox id="txtDjzs" runat="server">
</asp:textbox>
</td>
</tr>
<tr class="table-content">
<td class="table-title">
手 机 号 码&nbsp;&nbsp;&nbsp;&nbsp;
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
联 系 地 址&nbsp;&nbsp;&nbsp;&nbsp;

<asp:textbox id="txtNewAddress" runat="server" width="384px">
</asp:textbox>
(必须包含省、直辖市、自治区的名字)
</td>
</tr>
<tr class="table-content">
<td class="table-title">
邮 政 编 码&nbsp;&nbsp;&nbsp;&nbsp;

<asp:textbox id="txtNewPostCode" runat="server">
</asp:textbox>
</td>
</tr>
<tr class="table-content">
<td class="table-title">
联 系 电 话&nbsp;&nbsp;&nbsp;&nbsp;


    <asp:TextBox ID="txtNewPhone" runat="server"></asp:TextBox>


</td>
</tr>
<tr class="table-content">
<td class="table-title">
电 子 邮 箱&nbsp;&nbsp;&nbsp;&nbsp;


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
