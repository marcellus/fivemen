<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserEdit.aspx.cs" Inherits="UserEdit" %>

<%@ Register Assembly="WebControls" Namespace="HMG.WebControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户管理</title>
    <link rel="Stylesheet" type="text/css" href="../css/styles.css" />

    <script language="javascript" src="../js/popcalendar.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="800" border="0" cellpadding="4" cellspacing="1" class="table-border">
                <tr>
                    <td colspan="4" class="table-title">
                        用户信息管理<font color="red">(*为必填项)</font></td>
                </tr>
                <tr>
                    <td colspan="4" class="table-content" style="text-align: right">
                        <asp:Button ID="btnAddUser" runat="server" CssClass="button" OnClick="btnAddUser_Click"
                            Text="添加用户" />
                        <asp:Button ID="btnModifyRole" runat="server" CssClass="button" Text="角色/权限修改" OnClick="btnModifyRole_Click" /></td>
                </tr>
                <tr>
                    <td class="mytable-title">
                        用户名：</td>
                    <td class="table-content">
                        <asp:TextBox ID="tbUser" runat="server"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*</span>(4-20个字符,注册后不可修改)</td>
                    <td class="mytable-title" style="width: 124px">
                        性别：</td>
                    <td class="table-content">
                        <asp:RadioButtonList ID="ddlSex" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">男</asp:ListItem>
                            <asp:ListItem Value="2">女</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td class="mytable-title" style="height: 10px">
                        固定电话：</td>
                    <td class="table-content" style="height: 10px">
                        <asp:TextBox ID="tbPhone" runat="server"></asp:TextBox>&nbsp;(010-XXXXXXXX)</td>
                    <td class="mytable-title" style="height: 10px">
                        移动电话：</td>
                    <td class="table-content" style="height: 10px">
                        <asp:TextBox ID="tbMPhone" runat="server"></asp:TextBox>&nbsp;(请填写手机号码)</td>
                </tr>
                <tr>
                    <td class="mytable-title">
                        Email：</td>
                    <td class="table-content">
                        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>&nbsp;(xxx@sina.com.cn)</td>
                    <td class="mytable-title">
                        传真：</td>
                    <td class="table-content">
                        <asp:TextBox ID="tbFax" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="mytable-title">
                        所在省：</td>
                    <td class="table-content">
                        <asp:DropDownList ID="ddlProvince" runat="server">
                            <asp:ListItem Value="重庆" Selected=True>重庆</asp:ListItem>
                            <asp:ListItem Value="北京">北京</asp:ListItem>
                            <asp:ListItem Value="上海">上海</asp:ListItem>
                            <asp:ListItem Value="天津">天津</asp:ListItem>
                            <asp:ListItem Value="河北">河北</asp:ListItem>
                            <asp:ListItem Value="辽宁">辽宁</asp:ListItem>
                            <asp:ListItem Value="吉林">吉林</asp:ListItem>
                            <asp:ListItem Value="黑龙江">黑龙江</asp:ListItem>
                            <asp:ListItem Value="江苏">江苏</asp:ListItem>
                            <asp:ListItem Value="安徽">安徽</asp:ListItem>
                            <asp:ListItem Value="山东">山东</asp:ListItem>
                            <asp:ListItem Value="福建">福建</asp:ListItem>
                            <asp:ListItem Value="江西">江西</asp:ListItem>
                            <asp:ListItem Value="湖南">湖南</asp:ListItem>
                            <asp:ListItem Value="四川">四川</asp:ListItem>
                            <asp:ListItem Value="贵州">贵州</asp:ListItem>
                            <asp:ListItem Value="云南">云南</asp:ListItem>
                            <asp:ListItem Value="西藏">西藏</asp:ListItem>
                            <asp:ListItem Value="内蒙古">内蒙古</asp:ListItem>
                            <asp:ListItem Value="湖北">湖北</asp:ListItem>
                            <asp:ListItem Value="广东">广东</asp:ListItem>
                            <asp:ListItem Value="广西">广西</asp:ListItem>
                            <asp:ListItem Value="海南">海南</asp:ListItem>
                            <asp:ListItem Value="山西">山西</asp:ListItem>
                            <asp:ListItem Value="陕西">陕西</asp:ListItem>
                            <asp:ListItem Value="青海">青海</asp:ListItem>
                            <asp:ListItem Value="浙江">浙江</asp:ListItem>
                            <asp:ListItem Value="新疆">新疆</asp:ListItem>
                            <asp:ListItem Value="宁夏">宁夏</asp:ListItem>
                            <asp:ListItem Value="甘肃">甘肃</asp:ListItem>
                            <asp:ListItem Value="河南">河南</asp:ListItem>
                            <asp:ListItem Value="香港">香港</asp:ListItem>
                            <asp:ListItem Value="澳门">澳门</asp:ListItem>
                            <asp:ListItem Value="台湾">台湾</asp:ListItem>
                        </asp:DropDownList></td>
                    <td class="mytable-title" style="width: 124px">
                        出生日期：</td>
                    <td class="table-content">
                        <input id="tbBirthday" runat="server" onclick="popUpCalendar(this,document.getElementById('tbBirthday'),'yyyy-mm-dd')" /></td>
                </tr>
                <tr>
                    <td class="mytable-title">
                        部门：</td>
                    <td class="table-content">
                        <asp:DropDownList ID="ddlDept" runat="server">
                        </asp:DropDownList></td>
                    <td class="mytable-title">
                        用户类型：</td>
                    <td class="table-content">
                        <asp:DropDownList ID="ddlType" runat="server">
                            <asp:ListItem Value="未验证">未验证</asp:ListItem>
                            <asp:ListItem Value="已验证">已验证</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="mytable-title">
                        角色：</td>
                    <td colspan="3" class="table-content">
                        <asp:DropDownList ID="ddlRole" runat="server" DataTextField="rolename" DataValueField="roleid">
                        </asp:DropDownList></td>
                </tr>
                <tr class="table-content" style="text-align: center;">
                    <td colspan="4">
                        <cc1:SubmitOnceButton ID="btnOK" runat="server" CssClass="button" OnClick="btnOK_Click"
                            SubmitSuccessStyle="Redirect" Text="修改" />&nbsp;
                        <input type="reset" value="重置" class="button" />&nbsp;
                        <input type="button" value="返回" onclick="javascript:history.back(-2)" class="button" /></td>
                </tr>
            </table>
        </div>
    </form>

    <script language="javascript" src="../js/prototype.js"></script>

    <script language="javascript" src="../js/commonRules.js"></script>

    <script language="javascript" src="../js/simpleValidation.js"></script>

    <script language="javascript" src="../js/usermanage.js"></script>

</body>
</html>
