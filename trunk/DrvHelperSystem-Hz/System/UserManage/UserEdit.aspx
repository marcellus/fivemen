<%@ Page Language="C#" MasterPageFile="~/Layout/Master/MainPage.master" AutoEventWireup="true"
    CodeFile="UserEdit.aspx.cs" Inherits="System_UserManage_UserEdit" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>系统管理-用户管理</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table class="table-border" border="0" cellspacing="1" cellpadding="4">
            <tr class="poptable-title">
                <td colspan="4">
                    编号<asp:Label ID="lbId" runat="server"></asp:Label>
                    用户详细信息：
                </td>
            </tr>
            <tr class="table-content">
                <td style="" class="table-title">
                    部门类别：
                </td>
                <td style="">
                    <asp:DropDownList ID="cbDepTypeValue" runat="server" Height="16px" Width="200px"
                        Font-Size="15pt">
                    </asp:DropDownList>
                </td>
                <td style="" class="table-title">
                    部门：
                </td>
                <td style="">
                    <asp:DropDownList ID="cbDepIdValue" runat="server" Height="16px" Width="200px" Font-Size="15pt">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="table-content">
                <td style="width: 120px" class="table-title">
                    登陆名：
                </td>
                <td style="">
                    <asp:TextBox ID="txtUserLoginName" runat="server"></asp:TextBox>
                </td>
                <td class="table-title">
                    姓名：
                </td>
                <td style="width: 260px">
                    <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                    固定电话：
                </td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
                <td style="" class="table-title">
                    联系手机：
                </td>
                <td style="">
                    <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                    角色：
                </td>
                <td>
                    <asp:DropDownList ID="cbRoleIdValue" runat="server" Height="16px" Width="180px" Font-Size="15pt">
                    </asp:DropDownList>
                </td>
                <td class="table-title">
                    身份证明号码：
                </td>
                <td>
                    <asp:TextBox ID="txtIdCard" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                    联系地址：
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                    工号：
                </td>
                <td>
                    <asp:TextBox ID="txtWorkId" runat="server"></asp:TextBox>
                </td>
                <td class="table-title">
                    状态：
                </td>
                <td>
                    <asp:RadioButtonList ID="rblState" runat="server" RepeatColumns="2">
                        <asp:ListItem Selected="True" Value="1">有效</asp:ListItem>
                        <asp:ListItem Value="0">无效</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                    MAC地址
                </td>
                <td>
                    <asp:TextBox ID="txtMac" runat="server"></asp:TextBox>
                    </td><td  colspan="2">
                    &nbsp;<asp:RadioButtonList ID="rblIsMac" runat="server" RepeatColumns="2">
                        <asp:ListItem Value="1">绑定</asp:ListItem>
                        <asp:ListItem Selected="True" Value="0">不绑定</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                    IP起始地址：
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtBeginIp1" runat="server" Width="26px"></asp:TextBox>
                    .<asp:TextBox ID="txtBeginIp2" runat="server" Width="26px"></asp:TextBox>
                    .<asp:TextBox ID="txtBeginIp3" runat="server" Width="26px"></asp:TextBox>
                    .<asp:TextBox ID="txtBeginIp4" runat="server" Width="26px"></asp:TextBox>
                </td>
                <td class="table-title">
                    IP结束地址：
                </td>
                <td>
                    <asp:TextBox ID="txtEndIp1" runat="server" Width="26px"></asp:TextBox>
                    .<asp:TextBox ID="txtEndIp2" runat="server" Width="26px"></asp:TextBox>
                    .<asp:TextBox ID="txtEndIp3" runat="server" Width="26px"></asp:TextBox>
                    .<asp:TextBox ID="txtEndIp4" runat="server" Width="26px"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                    默认管理科目：
                </td>
                <td colspan="3" style="width: 300px">
                    <asp:DropDownList ID="cbKmValue" runat="server" Font-Size="15pt">
                        <asp:ListItem Selected="True" Value="1">科目一</asp:ListItem>
                        <asp:ListItem Value="2">科目二</asp:ListItem>
                        <asp:ListItem Value="3">科目三</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-content" colspan="4" style="text-align: center">
                    <asp:Button ID="btnSure" runat="server" Text="确定" OnClick="btnSure_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="Button2" class="button" type="button" value="关闭" onclick="javascript:window.opener=null;window.close();" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
