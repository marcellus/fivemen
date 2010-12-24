<%@ Page Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpViewTrainRecord.aspx.cs" Inherits="FpSystem_FpHelper_FpViewTrainRecord" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <FpUCL:viewStudentInfo ID="ViewStudentInfo1"   runat="server"></FpUCL:viewStudentInfo>
             <table class="table-border">
               <tr>
                <td class="table-title" style="width:25%"></td>
                <td  class="table-title" style="width:30%">进场时间</td>
                <td class="table-title" style="width:30%">离场时间</td>
                </tr>
                
                <tr>
                  <td class="table-content">入场训练1</td>
                  <td class="table-content"><asp:Label ID="lbStuTrainEnter1" runat="server"></asp:Label></td>
                  <td class="table-content"><asp:Label ID="lbStuTrainLeave1" runat="server"></asp:Label></td>
                </tr>
                
                <tr>
                  <td class="table-content">入场训练2</td>
                  <td class="table-content"><asp:Label ID="lbStuTrainEnter2" runat="server"></asp:Label></td>
                  <td class="table-content"><asp:Label ID="lbStuTrainLeave2" runat="server"></asp:Label></td>
                </tr>
                
                                <tr>
                  <td class="table-content">入场训练3</td>
                  <td class="table-content"><asp:Label ID="lbStuTrainEnter3" runat="server"></asp:Label></td>
                  <td class="table-content"><asp:Label ID="lbStuTrainLeave3" runat="server"></asp:Label></td>
                </tr>
                
                                <tr>
                  <td class="table-content">入场训练4</td>
                  <td class="table-content"><asp:Label ID="lbStuTrainEnter4" runat="server"></asp:Label></td>
                  <td class="table-content"><asp:Label ID="lbStuTrainLeave4" runat="server"></asp:Label></td>
                </tr>
                
                                <tr>
                  <td class="table-content">入场训练5</td>
                  <td class="table-content"><asp:Label ID="lbStuTrainEnter5" runat="server"></asp:Label></td>
                  <td class="table-content"><asp:Label ID="lbStuTrainLeave5" runat="server"></asp:Label></td>
                </tr>
                
                                <tr>
                  <td class="table-content">入场训练6</td>
                  <td class="table-content"><asp:Label ID="lbStuTrainEnter6" runat="server"></asp:Label></td>
                  <td class="table-content"><asp:Label ID="lbStuTrainLeave6" runat="server"></asp:Label></td>
                </tr>
                
                                <tr>
                  <td class="table-content">入场训练7</td>
                  <td class="table-content"><asp:Label ID="lbStuTrainEnter7" runat="server"></asp:Label></td>
                  <td class="table-content"><asp:Label ID="lbStuTrainLeave7" runat="server"></asp:Label></td>
                </tr>
                
                                <tr>
                  <td class="table-content">入场训练8</td>
                  <td class="table-content"><asp:Label ID="lbStuTrainEnter8" runat="server"></asp:Label></td>
                  <td class="table-content"><asp:Label ID="lbStuTrainLeave8" runat="server"></asp:Label></td>
                </tr>
                
               
                
                <tr>
                  <td class="table-content" colspan="3" style="color:Red; font-size:1.5em"><asp:Label ID="lbStudentAlertMsg" runat="server"></asp:Label></td>
                </tr>
             </table>
</asp:Content>

