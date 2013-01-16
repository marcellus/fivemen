<%@ Page Language="C#" MasterPageFile="~/Layout/BackManagerDetail.master" AutoEventWireup="true" CodeFile="TerminalEdit.aspx.cs" Inherits="YuanTuo_TerminalEdit" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="text-align:center">
<table class="table-border" border="0" cellspacing="1" cellpadding="4" style="width:800px">
            <tr  class="poptable-title">
                <td  colspan="4">
                    编号<asp:Label ID="lbId" runat="server"></asp:Label>
                    终端详细信息：</td>
            </tr>
           
            <tr class="table-content">
             <td  class="table-title-right">
                    分组：</td>
                <td >
                    
                   <asp:DropDownList ID="cbMachineGroupIdValue" runat="server"  Width="195px"></asp:DropDownList>
                </td>
                <td  class="table-title-right">
                    城市：</td>
                <td >
                    <asp:DropDownList ID="cbCityCodeValue" runat="server"  Width="195px">
    </asp:DropDownList>
                </td>
                
            </tr>
            
            
             <tr class="table-content">
             <td  class="table-title-right">
                     <asp:Label ID="lbCurrentStatus" runat="server" Text="当前状态"></asp:Label>终端名称：</td>
                <td >
                    <asp:TextBox ID="txtMachineName" runat="server"></asp:TextBox>
                   
                </td>
                <td  class="table-title-right">
                    终端地址：</td>
                <td >
                    <asp:TextBox ID="txtMachineAddress" runat="server"></asp:TextBox>
                  
                </td>
                
                
            </tr>
             <tr class="table-content">
             <td  class="table-title-right">
                    IP：</td>
                <td >
                    <asp:TextBox ID="txtMachineIp" runat="server"></asp:TextBox>
                </td>
                <td  class="table-title-right">
                  MAC： </td>
                <td >
                   <asp:TextBox ID="txtMachineMac" runat="server"></asp:TextBox> 在线时长： <asp:Label ID="lbOnlineSeconds" runat="server" Text=""></asp:Label>
                  
                </td>
                
            </tr>
             <tr class="table-content">
            <td  class="table-title-right">
                    门店序号：</td>
                <td >
                    <asp:TextBox ID="txtStoreNo" runat="server"></asp:TextBox>
                  
                </td>
                <td  class="table-title-right">
                    门店名称：</td>
                <td >
                    <asp:TextBox ID="txtStoreName" runat="server"></asp:TextBox>
                </td>
                
            </tr>
             <tr class="table-content">
             <td  class="table-title-right">
                    门店电话：</td>
                <td >
                    <asp:TextBox ID="txtStorePhone" runat="server"></asp:TextBox>
                </td>
            <td  class="table-title-right">
                    订单前缀：</td>
                <td >
                    <asp:TextBox ID="txtStorePrefix" runat="server"></asp:TextBox>
                  
                </td>
               
                
            </tr>
            
            <tr class="table-content"><td class="table-title-right">
                  最近上线时间：</td>
                <td  class="style7">
                    <asp:Label ID="lbLastOnlineTimeShow" runat="server" Text=""></asp:Label>
                </td>
                
                <td class="table-title-right">
                 最近离线时间：</td>
                <td class="style7">
                    <asp:Label ID="lbLastOutlineTimeShow" runat="server" Text=""></asp:Label>
                    <div style="display:none"><asp:Label ID="lbLastOutlineTime" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lbLastOnlineTime" runat="server" Text=""></asp:Label>
                    </div>
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

