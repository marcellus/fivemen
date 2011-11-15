<%@ Page Title="" Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpStudentRecordEdit.aspx.cs" Inherits="FpSystem_FpHelper_FpStudentRecordEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript" src="../../js/SmartCalendar.js"></script>

<div>
   <table class="table-border">
      <tr class=" table-content">
      <td style=" text-align:right">
         查询类型:<asp:DropDownList ID="ddlQueryType" runat="server">
              <asp:ListItem Text="证件号码" Value="idcard"></asp:ListItem>
              <asp:ListItem Text="受理号" Value="lsh"></asp:ListItem>
              <asp:ListItem Text="姓名" Value="name"></asp:ListItem>
           </asp:DropDownList>
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
                  <td class="table-content">
                  <input type="text" id="lbStuLessonEnter1" runat="server"   onclick="setday(this);" style="width:250px; border-left-style:none; border-bottom-style:none; border-right-style:none; border-top:none"/>
                  </td>
                  <td class="table-content"><input type="text" id="lbStuLessonLeave1" runat="server"  onclick="setday(this);" style="width:250px;border-style:none"/></td>
                </tr>
                
                <tr>
                  <td class="table-content">下午上课</td>
                   <td class="table-content"><input type="text" id="lbStuLessonEnter2" runat="server"  onclick="setday(this);" style="width:250px;border-style:none"/></td>
                    <td class="table-content"><input type="text" id="lbStuLessonLeave2" runat="server"  onclick="seday(this);" style="width:250px;border-style:none"/></td>
                 
                </tr>
 

             </table>
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
                        <td class="table-content"><input type="text" id="lbStuTrainEnter1" runat="server"  onclick="setday(this);" style="width:250px;border-style:none"/></td>
                    <td class="table-content"><input type="text" id="lbStuTrainLeave1" runat="server"  onclick="setday(this);" style="width:250px;border-style:none"/></td>
                        </tr>
                        
                        <tr>
                          <td class="table-content">入场训练2</td>
                          <td class="table-content"><input type="text" id="lbStuTrainEnter2" runat="server"  onclick="setday(this);" style="width:250px;border-style:none"/></td>
                    <td class="table-content"><input type="text" id="lbStuTrainLeave2" runat="server"  onclick="setday(this);" style="width:250px;border-style:none"/></td>
                        </tr>
                        
                                        <tr>
                          <td class="table-content">入场训练3</td>
                          <td class="table-content"><input type="text" id="lbStuTrainEnter3" runat="server"  onclick="setday(this);" style="width:250px;border-style:none"/></td>
                    <td class="table-content"><input type="text" id="lbStuTrainLeave3" runat="server"  onclick="setday(this);" style="width:250px;border-style:none"/></td>
                        </tr>
                        
                                        <tr>
                          <td class="table-content">入场训练4</td>
                         <td class="table-content"><input type="text" id="lbStuTrainEnter4" runat="server"  onclick="setday(this);" style="width:250px;border-style:none"/></td>
                    <td class="table-content"><input type="text" id="lbStuTrainLeave4" runat="server"  onclick="setday(this);" style="width:250px;border-style:none"/></td>
                        </tr>
                        
                                        <tr>
                          <td class="table-content">入场训练5</td>
                     <td class="table-content"><input type="text" id="lbStuTrainEnter5" runat="server"  onclick="setday(this);" style="width:250px;border-style:none"/></td>
                    <td class="table-content"><input type="text" id="lbStuTrainLeave5" runat="server"  onclick="setday(this);" style="width:250px;border-style:none"/></td>
                        </tr>
                        
                                        <tr>
                          <td class="table-content">入场训练6</td>
                        <td class="table-content"><input type="text" id="lbStuTrainEnter6" runat="server"  onclick="setday(this);" style="width:250px;border-style:none"/></td>
                    <td class="table-content"><input type="text" id="lbStuTrainLeave6" runat="server"  onclick="setday(this);" style="width:250px;border-style:none"/></td>
                        </tr>
                        
                                        <tr>
                          <td class="table-content">入场训练7</td>
                         <td class="table-content"><input type="text" id="lbStuTrainEnter7" runat="server"  onclick="setday(this);" style="width:250px;border-style:none"/></td>
                    <td class="table-content"><input type="text" id="lbStuTrainLeave7" runat="server"  onclick="setday(this);" style="width:250px;border-style:none"/></td>
                        </tr>
                        
                                        <tr>
                          <td class="table-content">入场训练8</td>
                           <td class="table-content"><input type="text" id="lbStuTrainEnter8" runat="server"  onclick="setday(this);" style="width:250px;border-style:none"/></td>
                    <td class="table-content"><input type="text" id="lbStuTrainLeave8" runat="server"  onclick="setday(this);" style="width:250px;border-style:none"/></td>
                         
                        </tr>
                </table>
          </td>
      </tr>
     
 <tr class="table-content">
         <td style=" text-align:left">
            入场训练完成时间
         <input type="text" id="lbStuTrainEndDate" runat="server"  onclick="setday(this);" 
style="width:500px;border-style:none"/></td>
      </tr>
 <tr class="table-content">
         <td style=" text-align:left">
            科目一考勤时间
         <input type="text" id="lbStuKm1Enter" runat="server"  onclick="setday(this);" 
style="width:500px;border-style:none"/></td>
      </tr>
<tr class="table-content">
      <td style=" text-align:left">
            科目二考勤时间 
      <input type="text" id="lbStuKm2Enter" runat="server"  onclick="setday(this);" 
style="width:500px;border-style:none"/></td>
      </tr>
       <tr class="table-content">
       <td style=" text-align:left">
            九选三考勤时间
        <input type="text" id="lbKM23IN9ENTER" runat="server"  onclick="setday(this);" 
style="width:500px;border-style:none"/></td>
         </tr>
          <tr class="table-content">
         <td style=" text-align:left">
            科目三考勤时间
        <input type="text" id="lbStuKm3Enter" runat="server"  onclick="setday(this);" 
style="width:500px;border-style:none"/></td>
      </tr>
      <tr class="table-content">
                 <td   style="font-size:1.5em">学员状态：<asp:DropDownList ID="ddlStatue" runat="server">
  
              <asp:ListItem Text="完成考勤" Value="9"></asp:ListItem>
              
           </asp:DropDownList></td>
                </tr>
        <tr class="table-content">
        <td style=" text-align:right">
            <asp:Button ID="btnSave" runat="server" Text="保存学员考勤信息"  Enabled="false"
                onclick="btnSave_Click" />
        </td>
        </tr>
       
   </table>

</div>

</asp:Content>

