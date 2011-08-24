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
<table style="width:70%" border="0" cellpadding="4" cellspacing="1" class="table-border">
     <tr>
        <td class="table-title" style="width:20%">学员身份证查询</td>
        <td class="table-content" style="width:50%">
        <asp:TextBox runat="server" ID="txtIDCard"  MaxLength="20" />
        <asp:Button  runat="server" ID="btnQueryStudent" Text="身份证查询" onclick="btnQueryStudent_Click" />
        <asp:Label runat="server" ID="lbQueryAlertMsg" CssClass="alertMsg"></asp:Label>
         <asp:HiddenField runat="server" ID="hidIDCard" />
        </td>
  
     </tr>
     
     <!--
     <tr>
   
        <td class="table-title">学员指纹查询</td>
        <td class="table-content">
          <asp:Button runat="server" ID="btnIdentity" Text="指纹查询" 
           onclick="btnIdentity_Click" />
           <asp:Label runat="server" ID="lbIdentityAlertMsg" CssClass="alertMsg"></asp:Label>
        </td>
     </tr>
     -->
     <tr class="table-content">
        <td  colspan="2">
        <FpUCL:viewStudentInfo  runat="server" ID="ucStudentInfo" ></FpUCL:viewStudentInfo>
                </td>
                </tr>
                <tr>
                   <td colspan="2" class="table-content">
                      <asp:Button ID="btnClearStudent" runat="server" Text="清空" 
                           onclick="btnClearStudent_Click" />   &nbsp;
                       <asp:DropDownList ID="ddlLocaltype" runat="server" Visible="false"  />&nbsp; 
                       <asp:Button ID="btnSaveStudent" runat="server" Text="保存学员信息" 
                           onclick="btnSaveStudent_Click"  Visible="false" /> &nbsp;
                        


                   </td>
                </tr>
                <tr>
                   <td colspan="2" class="table-content">
                                          <asp:Button ID="btnNewEnrolStudent" runat="server"  Text="指纹采集" 
                           onclick="btnNewEnrolStudent_Click" Visible="false"  /> 
                        
                       <asp:Button runat="server" ID="btnVerifyStudent" Text="检查指纹" 
                            onclick="btnVerifyStudent_Click" Visible="false"  />
                   </td>
                </tr>
                <tr>
                    <td colspan="2" style="color:Red; font-size:1.5em">
                       <asp:Label runat="server" ID="lbAlertMsg" Visible="false"></asp:Label>
                    </td>
                </tr>
               
            </table>
        </td>
     </tr>
</table>
</asp:Content>

