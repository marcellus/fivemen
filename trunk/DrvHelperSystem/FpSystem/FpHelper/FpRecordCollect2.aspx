<%@ Page Title="" Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpRecordCollect2.aspx.cs" Inherits="FpSystem_FpHelper_FpRecordCollect2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table style="width:70%" border="0" cellpadding="4" cellspacing="1" class="table-border">

 
                <tr>
                   <td colspan="2" class="table-content">
                       身份证号码:<asp:TextBox runat="server" ID="txtIDCard"  MaxLength="20" />&nbsp;&nbsp;
                       学员类型:<asp:DropDownList ID="ddlLocaltype" runat="server"   />&nbsp; &nbsp; 
                       <asp:Button ID="btnSaveStudent" runat="server" Text="保存学员信息" 
                           onclick="btnSaveStudent_Click"   /> &nbsp;
                       
                   </td>
                </tr>
                <tr>
                   <td colspan="2" class="table-content">
                                          <asp:Button ID="btnNewEnrolStudent" runat="server"  Text="指纹采集" 
                           onclick="btnNewEnrolStudent_Click" Visible="false"  /> 
                       <asp:Button runat="server" ID="btnVerifyStudent" Text="检查指纹" 
                             Visible="false"  />
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

