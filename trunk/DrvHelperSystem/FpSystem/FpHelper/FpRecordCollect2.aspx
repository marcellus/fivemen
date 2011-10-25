<%@ Page Title="" Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpRecordCollect2.aspx.cs" Inherits="FpSystem_FpHelper_FpRecordCollect2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table style="width:70%" border="0" cellpadding="4" cellspacing="1" class="table-border">

 
                <tr class="table-content">
                   <td  >
                       身份证号码:
                   </td>
                   <td >
                   <asp:TextBox runat="server" ID="txtIDCard"  MaxLength="20" />
                   </td>
                </tr>
                
                <tr class="table-content">
                  <td>姓名</td>
                  <td><asp:TextBox runat="server"  ID="txtName" ></asp:TextBox></td>
                </tr>
                
                <tr class="table-content">
                  <td> 学员类型:</td>
                  <td><asp:DropDownList ID="ddlLocaltype" runat="server"   /></td>
                </tr>
                
                
                <tr >
                  <td colspan="2"  style=" text-align:right;">
                     <asp:Button ID="btnSaveStudent" runat="server" Text="保存学员信息" 
                           onclick="btnSaveStudent_Click"   />
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

