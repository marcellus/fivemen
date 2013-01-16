<%@ Page Language="C#" MasterPageFile="~/Layout/BackManagerDetail.master" AutoEventWireup="true" CodeFile="GroupEdit.aspx.cs" Inherits="YuanTuo_GroupEdit" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align:center">
<table class="table-border" border="0" cellspacing="1" cellpadding="4" style="width:500px;">
            <tr  class="poptable-title">
                <td  colspan="4">
                    编号<asp:Label ID="lbId" runat="server"></asp:Label>
                    分组详细信息：</td>
            </tr>
           
            <tr class="table-content">
                <td  class="table-title">
                    分组名称：</td>
                <td  colspan="3" >
                    
                    <asp:TextBox ID="txtName" runat="server" Width="250px" ></asp:TextBox>
                </td>
                
            </tr>
             <tr class="table-content">
                <td  class="table-title">
                    分组流媒体地址：</td>
                <td  colspan="3" >
                    
                    <asp:TextBox ID="txtAdUrl" runat="server" Width="250px" ></asp:TextBox>
                </td>
                
            </tr>
            <tr class="table-content"><td class="table-title">
                  促销内容：</td>
                <td colspan="3" class="style7">
                    <asp:TextBox ID="txtAdContent" runat="server" Width="239px" Height="73px" 
                        TextMode="MultiLine" ></asp:TextBox>
                </td></tr>
            <tr class="table-content"><td class="table-title">
                  备注：</td>
                <td colspan="3" class="style7">
                    <asp:TextBox ID="txtDescription" runat="server" Width="250px" ></asp:TextBox>
                </td></tr>
           
            <tr  class="table-bottom-buttons">
                <td  colspan="4" style="text-align: center">
                    <asp:Button ID="btnSure" runat="server" Width="120px" Text="确定" onclick="btnSure_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                         <input id="Button2" class="button"  type="button" value="关闭" onclick="javascript:window.opener=null;window.close();" />
                    </td>
            </tr>
        </table>
        </div>
</asp:Content>

