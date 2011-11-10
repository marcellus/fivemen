<%@ Page Title="" Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpRecordCollect2.aspx.cs" Inherits="FpSystem_FpHelper_FpRecordCollect2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style>
  th
  {
  	 text-align:right;
  	}
</style>
<table style="width:70%" border="0" cellpadding="4" cellspacing="1" class="table-border">


                 <tr class="table-content">
                   <th >身份证号码：</th>
                   <td >
                   <asp:TextBox runat="server" ID="txtIDCard"  MaxLength="20" /> &nbsp;
                   <asp:Button ID="btnQueryStuent" runat="server" Text="查询学员" 
                           onclick="btnQueryStuent_Click" />
                   </td>
                   
                </tr>

                 <tr class="table-content">
                   <th>流水号：</th>
                   <td><asp:TextBox runat="server"  ID="txtLsh"></asp:TextBox></td>
                 </tr>


                
                <tr class="table-content">
                  <th>姓名：</th>
                  <td><asp:TextBox runat="server"  ID="txtName" ></asp:TextBox></td>
                </tr>
                
                <tr class="table-content">
                  <th> 学员类型：</th>
                  <td><asp:DropDownList ID="ddlLocaltype" runat="server"   /></td>
                </tr>
                
                
                <tr class="table-content">
                  <th> 驾校：</th>
                  <td><asp:DropDownList ID="ddlSchool" runat="server"   /></td>
                </tr>
                
                
                <tr class="table-content">
                  <th> 准驾车型：</th>
                  <td><asp:DropDownList ID="ddlCarType" runat="server"   /></td>
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

