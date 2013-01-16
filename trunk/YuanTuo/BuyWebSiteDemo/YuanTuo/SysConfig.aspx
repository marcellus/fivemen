<%@ Page Language="C#" MasterPageFile="~/Layout/BackManagerListLayout.master" AutoEventWireup="true" CodeFile="SysConfig.aspx.cs" Inherits="YuanTuo_SysConfig" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
 <div style="text-align:center">
    <table class="table-border" cellspacing="1" cellpadding="1" rules="all" border="0" id="ctl00_ContentPlaceHolder1_dgLists" style="border-width:0px;width:720px;">
	<tr class="table-header">
		<td colspan="4">系统配置<asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
        </td>
	</tr><tr class="table-content">
		<td class="table-title-right">打印图标地址：</td><td colspan="3">
            <asp:TextBox ID="txtPrintLogoUrl" runat="server" Width="500px"></asp:TextBox></td>
            </tr>
            <tr class="table-content"><td  class="table-title-right">图标X距离：</td><td>
                            
                <asp:TextBox ID="txtPrintLogoX" runat="server" Width="50px"></asp:TextBox> 
                            </td><td  class="table-title-right">
                           图标Y距离：
                            </td>
                            <td>
                                <asp:TextBox ID="txtPrintLogoY" runat="server" Width="50px"></asp:TextBox></td>
	</tr>
	
	<tr class="table-content">
		<td class="table-title-right">实时路况地址：</td><td colspan="3">
            <asp:TextBox ID="txtRealRoadConditionurl" runat="server" Width="500px"></asp:TextBox></td>
           </tr> <tr class="table-content">
            <td  class="table-title-right">流媒体地址：</td><td colspan="3">
                            
                <asp:TextBox ID="txtAdUrl" runat="server" Width="500px"></asp:TextBox> 
                            </td> </tr> <tr class="table-content"><td class="table-title-right">
                           VOIP地址：
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtVoipUrl" runat="server" Width="500px"></asp:TextBox></td>
	</tr>
	
	<tr class="table-bottom-buttons">
                            <td colspan="4">
                                <asp:Button ID="btnSave" runat="server" Text="保存配置" onclick="btnSave_Click" /> </td>
	</tr>
</table>

</div>
</asp:Content>

