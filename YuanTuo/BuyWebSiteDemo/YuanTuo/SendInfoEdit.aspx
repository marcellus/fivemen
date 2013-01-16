<%@ Page Language="C#" MasterPageFile="~/Layout/BackManagerDetail.master" AutoEventWireup="true" CodeFile="SendInfoEdit.aspx.cs" Inherits="YuanTuo_SendInfoEdit" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="text-align:center">
<table class="table-border" border="0" cellspacing="1" cellpadding="4" style="width:800px">
            <tr  class="poptable-title">
                <td  colspan="4">
                    编号<asp:Label ID="lbId" runat="server"></asp:Label>
                    赠送详细信息：</td>
            </tr>
           
            <tr class="table-content">
             <td  class="table-title">
                    主购产品：</td>
                <td >
                    
                   <asp:DropDownList ID="cbProductIdValue" runat="server"  Width="195px"></asp:DropDownList>
                </td>
                <td  class="table-title">
                    购买数量：</td>
                <td >
                    
                    <asp:TextBox ID="txtNum" runat="server" Width="50px" ></asp:TextBox>
                </td>
                
            </tr>
            <tr class="table-content">
             <td  class="table-title">
                    赠送产品：</td>
                <td  colspan="3">
                    
                   <asp:DropDownList ID="cbSendProductIdValue" runat="server"  Width="195px"></asp:DropDownList>
                </td>
                
                
            </tr>
            
            <tr class="table-content"><td class="table-title">
                  开始时间：</td>
                <td colspan="3" class="style7">
                   
                    <input type="text" id="txtBeginDate" runat="server"  onclick="setday(this);" style="width:250px; "/>
                </td></tr>
                
                <tr class="table-content"><td class="table-title">
                 结束时间：</td>
                <td colspan="3" class="style7">
                    <input type="text" id="txtEndDate" runat="server"  onclick="setday(this);" style="width:250px; "/>
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

