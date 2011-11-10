<%@ Page Title="" Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpLocalTypeEdit.aspx.cs" Inherits="FpSystem_FpHelper_FpLocalTypeEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div>
     <table class="table-border" border="0" cellspacing="1" cellpadding="4" >
            <tr  class="poptable-title">
                <td  colspan="4">
                    编号<asp:Label ID="lbId" runat="server"></asp:Label>
                    地区类型信息：</td>
            </tr>
            <tr class="table-content">
                <td style="width:120px" class="table-title">
                    地区类型名：</td>
                <td  colspan="3" style="">
                    
                    <asp:TextBox ID="txtLocalTypeName" runat="server" Width="124px"></asp:TextBox>
                </td>
                
            </tr>
            
            <tr class="table-content">
                <td style="width:120px" class="table-title">
                    入场训练次数：</td>
                <td  colspan="3" style="">                   
                    <asp:TextBox ID="txtTrainTimes" runat="server" Width="124px"></asp:TextBox>
                </td>
                
            </tr>
            
                        <tr class="table-content">
                <td style="width:120px" class="table-title">
                    科目3考试审核：</td>
                <td  colspan="3" style="">                   
                    <asp:CheckBox ID="cbKm3VerifyInd" runat="server" />
                </td>
                
            </tr>
            
           <tr class="table-content">
                <td style="width:120px" class="table-title">
                    地区类型描述：</td>
                <td  colspan="3" style="">
                    
                    <asp:TextBox ID="txtLocalTypeDescp" runat="server" Width="124px" TextMode="MultiLine"  ></asp:TextBox>
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

