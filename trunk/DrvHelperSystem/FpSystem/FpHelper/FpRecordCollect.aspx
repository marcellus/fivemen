<%@ Page Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpRecordCollect.aspx.cs" Inherits="FpSystem_FpHelper_FpRecordCollect" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style>
  .alertMsg
  {
    color:Red;
    font-size:1.2em;
  }
</style>
<h1>指纹信息采集</h1>
<table style="width:80%" border="0" cellpadding="4" cellspacing="1" class="table-border">
     <tr>
        <td class="table-title" style="width:20%">学员身份证查询</td>
        <td class="table-content" style="width:50%">
        <asp:TextBox runat="server" ID="txtIDCard"  MaxLength="20" />
        <asp:Button  runat="server" ID="btnQueryStudent" Text="身份证查询" onclick="btnQueryStudent_Click" />
        <asp:Label runat="server" ID="lbQueryAlertMsg" CssClass="alertMsg"></asp:Label>
         
        </td>
  
     </tr>
     <tr>
        <td class="table-title">学员指纹查询</td>
        <td class="table-content">
          <asp:Button runat="server" ID="btnIdentity" Text="指纹查询" 
           onclick="btnIdentity_Click" />
           <asp:Label runat="server" ID="lbIdentityAlertMsg" CssClass="alertMsg"></asp:Label>
        </td>
     </tr>
     
     <tr class="table-content">
        <td  colspan="2">
            <table style="width:100%;"  border="0" cellpadding="4" cellspacing="1" class="table-border">
                <tr class="table-content">
                    <td  class="table-title" style="width:80px">
                        证件名称</td>
                    <td   style="width:120px">
                        <asp:Label ID="lbIDCardType" runat="server"></asp:Label>
                    </td>
                    <td class="table-title" width="80px">
                        证件号码</td>
                    <td width="200px">
                        <asp:Label ID="lbIdCard" runat="server"></asp:Label>
                    </td>
                    <td class="table-title" width="80px">
                        档案编号</td>
                    <td width="160px">
                        <asp:Label ID="lbDabh" runat="server"></asp:Label>
                    </td>
                    <td rowspan="4">
                        <asp:Image ID="imgPerson" runat="server" Height="160px" Width="133px" 
                            BorderStyle="Solid" BorderWidth="1px" />
                    </td>
                </tr>
                <tr class="table-content">
                    <td class="table-title">
                        姓名</td>
                    <td>
                        <asp:Label ID="lbXm" runat="server"></asp:Label>
                    </td>
                    <td class="table-title">
                        性别</td>
                    <td>
                        <asp:Label ID="lbSex" runat="server"></asp:Label>
                    </td>
                    <td class="table-title">
                        出生日期</td>
                    <td>
                        <asp:Label ID="lbBrithday" runat="server"></asp:Label>
                    </td>
                    
                </tr>
                <tr class="table-content">
                    <td class="table-title">
                        国籍</td>
                    <td>
                        <asp:Label ID="lbNation" runat="server"></asp:Label>
                    </td>
                    <td class="table-title">
                        准驾车型</td>
                    <td>
                        <asp:Label ID="lbLearnCar" runat="server"></asp:Label>
                    </td>
                    <td class="table-title">
                     </td>
                    <td>
                    </td>
                    
                </tr>
                 <tr class="table-content">
                    <td class="table-title">
                        登记住所</td>
                    <td colspan="5">
                    </td>
                    
                </tr>
                <tr class="table-content">
                    <td class="table-title">
                        邮政编码</td>
                    <td>

                    </td>
                    <td class="table-title">
                        联系电话</td>
                    <td colspan="4">

                    </td>
                    
                </tr>
                <tr class="table-content">
                    <td class="table-title">
                        备注</td>
                    <td colspan="6">
                        <asp:Label ID="lbDescription" runat="server"></asp:Label>
                    </td>
                    
                </tr>
                <tr>
                   <td colspan="4">
                       <asp:Button ID="btnSaveStudent" runat="server" Text="保存" 
                           onclick="btnSaveStudent_Click"  Visible="false" />    
                       <asp:Button ID="btnNewEnrolStudent" runat="server"  Text="指纹采集" 
                           onclick="btnNewEnrolStudent_Click" Visible="false"  /> 
                       <asp:Button runat="server" ID="btnVerifyStudent" Text="检查指纹" 
                            onclick="btnVerifyStudent_Click" Visible="false"  />   
                         
                   </td>
                </tr>
                <tr>
                    <td colspan="4" style="color:Red; font-size:1.5em">
                       <asp:Label runat="server" ID="lbAlertMsg" Visible="false"></asp:Label>
                    </td>
                </tr>
               
            </table>
        </td>
     </tr>
</table>
</asp:Content>

