<%@ Control Language="C#" AutoEventWireup="true" CodeFile="viewStudentInfo.ascx.cs" Inherits="FpSystem_UserControler_viewStudentInfo" %>
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
                    <td class="table-title" width="120px">
                        档案编号</td>
                    <td width="160px">
                        <asp:Label ID="lbDocNum" runat="server"></asp:Label>
                    </td>
                    <td rowspan="4">
                        <asp:Image ID="imgPerson" runat="server" Height="160px" Width="150px" 
                            BorderStyle="Solid" BorderWidth="1px" ImageUrl="~/images/no_photo.jpg" />
                    </td>
                </tr>
                <tr class="table-content">
                    <td class="table-title">
                        姓名</td>
                    <td>
                        <asp:Label ID="lbName" runat="server"></asp:Label>
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
                      所属驾校</td>
                    <td>
                        <asp:Label ID="lbDrvSchool" runat="server"></asp:Label>
                    </td>
                    <td class="table-title">
                        准驾车型</td>
                    <td>
                        <asp:Label ID="lbDrvType" runat="server"></asp:Label>
                    </td>
                    <td class="table-title">联系电话
                     </td>
                    <td>
                     <asp:Label ID="lbPhone" runat="server"></asp:Label>
                    </td>
                    
                </tr>
                 <tr class="table-content">
                    <td class="table-title">
                        登记住所</td>
                    <td colspan="5">
                     <asp:Label ID="lbAddress" runat="server"></asp:Label>
                    </td>
                    
                </tr>

                <tr class="table-content">
                    <td class="table-title">
                        备注</td>
                    <td colspan="6">
                        <asp:Label ID="lbRemark" runat="server"></asp:Label>
                    </td>
                    
                </tr>
                
                  <tr>
                    <td colspan="4" style="color:Red; font-size:1.5em">
                       <asp:Label runat="server" ID="lbAlertMsg" ></asp:Label>
                    </td>
                </tr>
                
                                      
              </table>