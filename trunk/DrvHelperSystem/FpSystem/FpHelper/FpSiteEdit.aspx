<%@ Page Title="" Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpSiteEdit.aspx.cs" Inherits="FpSystem_FpHelper_FpSiteEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div>
     <table class="table-border" border="0" cellspacing="1" cellpadding="4" >
            <tr  class="poptable-title">
                <td  colspan="4">
                    编号<asp:Label ID="lbId" runat="server"></asp:Label>
                    场地信息：</td>
            </tr>
            <tr class="table-content">
                <td style="width:120px" class="table-title">
                    场地名：</td>
                <td  colspan="3" style="">
                    
                    <asp:TextBox ID="txtSiteName" runat="server" Width="124px"></asp:TextBox>
                </td>
                
            </tr>
            
            <tr class="table-content">
                <td style="width:120px" class="table-title">
                    业务类型：</td>
                <td  colspan="3" style="">                   
                    <asp:DropDownList ID="dllBustype" runat="server" >
                      <asp:ListItem Text="上课" Value="lesson"></asp:ListItem>
                      <asp:ListItem Text="入场训练" Value="train"></asp:ListItem>
                      <asp:ListItem Text="科目1考试" Value="km1"></asp:ListItem>
                      <asp:ListItem Text="科目2考试" Value="km2"></asp:ListItem>
                      <asp:ListItem Text="科目3考试" Value="km3"></asp:ListItem>
                      <asp:ListItem Text="指纹采集" Value="collect"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                
            </tr>
            
           <tr class="table-content">
                <td style="width:120px" class="table-title">
                    当日人数限制：</td>
                <td  colspan="3" style="">
                    
                    <asp:TextBox ID="txtSiteLimit" runat="server" Width="124px"   ></asp:TextBox>
                </td>
                
            </tr>
           
           
            <tr  class="table-content">
                <td class="table-content" colspan="4" style="text-align: center">
                    <asp:Button ID="btnCommit" runat="server" Text="确定" onclick="btnCommit_Click" 
                        />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                         <input id="Button2" class="button"  type="button" value="关闭" onclick="javascript:window.opener=null;window.close();" />
                    </td>
            </tr>
        </table>
    </div>
</asp:Content>

