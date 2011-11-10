<%@ Control Language="C#" AutoEventWireup="true" CodeFile="viewStudentInfo.ascx.cs" Inherits="FpSystem_UserControler_viewStudentInfo" %>
<table style="width:100%;"  border="0" cellpadding="4" cellspacing="1" class="table-border">

                <tr class="table-content">
                    <th class="table-title" width="120px">
                        受理号</th>
                    <td colspan="3">
                        <asp:Label ID="lbLsh" runat="server"></asp:Label>
                    </td>

                </tr>
                
                <tr class="table-content">
                    <th class="table-title" >
                        证件号码</th>
                    <td width="250px">
                        <asp:Label ID="lbIdCard" runat="server"></asp:Label>
                    </td>
                    
                    <th class="table-title">
                        姓名</th>
                    <td>
                        <asp:Label ID="lbName" runat="server"></asp:Label>
                    </td>
                 </tr>

                <tr class="table-content">
          
                     <th class="table-title">
                        学员类型</th>
                    <td>
                        <asp:Label ID="lbLocalType" runat="server"></asp:Label>
                    </td>
                   


                    
                                        <th class="table-title">
                        考勤状态</th>
                    <td>
                        <asp:Label ID="lbStaute" runat="server"></asp:Label>
                    </td>
  </tr>
  
                  <tr class="table-content">
          
                    <th class="table-title" >
                        驾校</th>
                    <td width="250px">
                        <asp:Label ID="lbSchoolName" runat="server"></asp:Label>
                    </td>

                    <th class="table-title" >
                        准驾车型</th>
                    <td width="250px">
                        <asp:Label ID="lbCarType" runat="server"></asp:Label>
                    </td>
  </tr>
  
  
                    <tr class="table-content">
          
                    <th class="table-title" >
                        已收费</th>
                    <td width="250px">
                        <asp:Label ID="lbFeeStatue" runat="server"></asp:Label>
                    </td>

                    <th class="table-title">
                        已通过科目三审核</th>
                    <td>
                        <asp:Label ID="lbKm3Verify" runat="server"></asp:Label>
                    </td>
  </tr>
  
  
                <tr class="table-content">
                    <th class="table-title">
                        备注</th>
                    <td colspan="3">
                        <asp:Label ID="lbRemark" runat="server"></asp:Label>
                    </td>
                    
                </tr>
                
                  <tr>
                    <td colspan="4" style="color:Red; font-size:1.5em">
                       <asp:Label runat="server" ID="lbAlertMsg" ></asp:Label>
                    </td>
                </tr>
                
                                   
              </table>