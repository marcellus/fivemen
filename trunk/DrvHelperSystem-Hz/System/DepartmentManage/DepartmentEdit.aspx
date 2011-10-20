<%@ Page Language="C#" MasterPageFile="~/Layout/Master/MainPage.master" AutoEventWireup="true"
    CodeFile="DepartmentEdit.aspx.cs" Inherits="System_DepartmentManage_DepartmentEdit"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>车管部门详细信息</title>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table class="table-border" style="width: 780px" border="0" cellspacing="1" cellpadding="4">
            <tr class="poptable-title">
                <td colspan="4">
                    编号<asp:Label ID="lbId" runat="server"></asp:Label>
                    部门详细信息：
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                    部门全名：
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtDepFullName" runat="server" Width="458px"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                    部门简称：
                </td>
                <td style="width: 50px">
                    <asp:TextBox ID="txtDepNickName" runat="server"></asp:TextBox>
                </td>
                <td class="table-title">
                    发证机关：
                </td>
                <td style="width: 50px">
                    <asp:TextBox ID="txtFzjg" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                    部门代码：
                </td>
                <td style="width: 50px; height: 3px;">
                    <asp:TextBox ID="txtDepCode" runat="server"></asp:TextBox>
                </td>
                <td class="table-title">
                    管理部门代码：
                </td>
                <td>
                    <asp:TextBox ID="txtGlbmCode" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                    机构证书代码：
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtCompanyCode" runat="server"></asp:TextBox>
                </td>
                <td class="table-title">
                    联系人：
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtConnector" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                    移动电话：
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                </td>
                <td class="table-title">
                    固定电话：
                </td>
                <td class="style5">
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                    联系地址：
                </td>
                <td colspan="3" class="style2">
                    <asp:TextBox ID="txtAddress" runat="server" Width="457px"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-content" colspan="4" style="text-align: center">
                    <br />
                    <asp:Button ID="btnSure" runat="server" Width="120px" Text="确定" OnClick="btnSure_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="Button2" class="button" type="button" value="关闭" onclick="javascript:window.opener=null;window.close();" />
                    <div class="sep">
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
