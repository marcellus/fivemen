<%@ Page Title="" Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpCheckinLogDetail.aspx.cs" Inherits="FpSystem_FpHelper_FpCheckinLogDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div>
   <table class="table-border">
      <tr class=" table-content">
        <td style=" text-align:right">
           身份证明号码：
           <asp:TextBox ID="txtIDCard" runat="server"></asp:TextBox>
           <asp:Button  ID="btnQuery" runat="server"  Text="查询" onclick="btnQuery_Click" />
        </td>
      </tr>
   </table>
</div>

<div>
  
   <table class="table-border">
      <tr class="table-content">
         <td><FpUCL:viewStudentInfo ID="ucStudentInfo" runat="server" /></td>
      </tr>
      <tr class="table-title">
         <td>上课签到情况</td>
      </tr>
      <tr class="table-content">
         <td>
             <table class="table-border">
               <tr>
                <td class="table-title" style="width:25%"></td>
                <td  class="table-title" style="width:30%">进场时间</td>
                <td class="table-title" style="width:30%">离场时间</td>
                </tr>
                
                <tr>
                  <td class="table-content">上午上课</td>
                  <td class="table-content"><asp:Label ID="lbStuLessonEnter1" runat="server"></asp:Label></td>
                  <td class="table-content"><asp:Label ID="lbStuLessonLeave1" runat="server"></asp:Label></td>
                </tr>
                
                <tr>
                  <td class="table-content">下午上课</td>
                  <td class="table-content"><asp:Label ID="lbStuLessonEnter2" runat="server"></asp:Label></td>
                  <td class="table-content"><asp:Label ID="lbStuLessonLeave2" runat="server"></asp:Label></td>
                </tr>
 

             </table>
         </td>
      </tr>
      
      <tr class="table-content">
         <td style=" text-align:left">
            科目一考勤时间 &nbsp;&nbsp;<asp:Label ID="lbStuKm1Enter" runat="server"></asp:Label>
         </td>
      </tr>
      
      <tr class="table-content">
         <td style=" text-align:left">
            科目二考勤时间&nbsp;&nbsp;<asp:Label ID="lbStuKm2Enter" runat="server"></asp:Label>
         </td>
      </tr>
      
      <tr class="table-title">
         <td>入场训练情况</td>
      </tr>
      <tr class="table-content">
          <td>
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
                </table>
          </td>
      </tr>
      
       <tr class="table-content">
         <td style=" text-align:left">
            科目三考勤时间 &nbsp;&nbsp;<asp:Label ID="lbStuKm3Enter" runat="server"></asp:Label>
         </td>
      </tr>
      
       <tr class="table-content">
                 <td   style="color:Red; font-size:1.5em"><asp:Label ID="lbStudentAlertMsg" runat="server"></asp:Label></td>
                </tr>
  
   </table>

</div>

</asp:Content>

