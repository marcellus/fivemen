     <%@ Page Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FPConfigEdit.aspx.cs" Inherits="FpSystem_FpHelper_FPConfigEdit" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                
                  <table style="width:80%" border="0" cellpadding="4" cellspacing="1" class="table-border">
  
            </tr>
            <tr class="table-content">
               <th>上课有效时间间隔:</th>
               <td><asp:TextBox runat="server" ID="tbFp_lesson_interval"></asp:TextBox>(单位：分钟)请输入数字</td>
               
            </tr>
            
            
                         <tr class="table-content">
               <th>早场第一节上课最迟有效时间:</th>
               <td>
                <asp:DropDownList ID="ddlLessonEnter1HH" runat="server"></asp:DropDownList>:
                <asp:DropDownList ID="ddlLessonEnter1MM" runat="server"></asp:DropDownList>
                
               </td>
            </tr>
            
                         <tr class="table-content">
               <th>早场第二节上课最迟有效时间:</th>
               <td>
                <asp:DropDownList ID="ddlLessonEnter2HH" runat="server"></asp:DropDownList>:
                <asp:DropDownList ID="ddlLessonEnter2MM" runat="server"></asp:DropDownList>
                
               </td>
            </tr>
            
             <tr class="table-content">
               <th>晚场第一节上课最迟有效时间:</th>
               <td>
                <asp:DropDownList ID="ddlLessonEnter3HH" runat="server"></asp:DropDownList>:
                <asp:DropDownList ID="ddlLessonEnter3MM" runat="server"></asp:DropDownList>
                
               </td>
            </tr>
            
             <tr class="table-content">
               <th>晚场第二节上课最迟有效时间:</th>
               <td>
                <asp:DropDownList ID="ddlLessonEnter4HH" runat="server"></asp:DropDownList>:
                <asp:DropDownList ID="ddlLessonEnter4MM" runat="server"></asp:DropDownList>
                
               </td>
            </tr>
            
            
             <tr class="table-content">
               <th>入场训练有效时间间隔:</th>
               <td><asp:TextBox runat="server" ID="tbFp_train_interval"></asp:TextBox>(单位：分钟)请输入数字</td>
            </tr>
            
             <tr class="table-content">
               <th>早场入场有效时段:</th>
               <td>
                <asp:DropDownList ID="ddlTrain1EnterFromHH" runat="server"></asp:DropDownList>:
                <asp:DropDownList ID="ddlTrain1EnterFromMM" runat="server"></asp:DropDownList>
                &nbsp;~&nbsp;
                <asp:DropDownList ID="ddlTrain1EnterToHH" runat="server"></asp:DropDownList>:
                <asp:DropDownList ID="ddlTrain1EnterToMM" runat="server"></asp:DropDownList>
               </td>
            </tr>
            
             <tr class="table-content">
               <th>午场入场有效时段:</th>
               <td>
                <asp:DropDownList ID="ddlTrain2EnterFromHH" runat="server"></asp:DropDownList>:
                <asp:DropDownList ID="ddlTrain2EnterFromMM" runat="server"></asp:DropDownList>
                &nbsp;~&nbsp;
                <asp:DropDownList ID="ddlTrain2EnterToHH" runat="server"></asp:DropDownList>:
                <asp:DropDownList ID="ddlTrain2EnterToMM" runat="server"></asp:DropDownList>
               </td>
            </tr>
            
              <tr class="table-content">
               <th>晚场入场有效时段:</th>
               <td>
                <asp:DropDownList ID="ddlTrain3EnterFromHH" runat="server"></asp:DropDownList>:
                <asp:DropDownList ID="ddlTrain3EnterFromMM" runat="server"></asp:DropDownList>
                &nbsp;~&nbsp;
                <asp:DropDownList ID="ddlTrain3EnterToHH" runat="server"></asp:DropDownList>:
                <asp:DropDownList ID="ddlTrain3EnterToMM" runat="server"></asp:DropDownList>
               </td>
            </tr>
            

             <tr class="table-content">
               <th>早场离场最早有效时间:</th>
               <td>
                <asp:DropDownList ID="ddlTrain1LeaveHH" runat="server"></asp:DropDownList>:
                <asp:DropDownList ID="ddlTrain1LeaveMM" runat="server"></asp:DropDownList>
                
               </td>
            </tr>
            
            <tr class="table-content">
               <th>中场离场最早有效时间:</th>
               <td>
                <asp:DropDownList ID="ddlTrain2LeaveHH" runat="server"></asp:DropDownList>:
                <asp:DropDownList ID="ddlTrain2LeaveMM" runat="server"></asp:DropDownList>
                
               </td>
            </tr>
            
            <tr class="table-content">
               <th>晚场离场最早有效时间:</th>
               <td>
                <asp:DropDownList ID="ddlTrain3LeaveHH" runat="server"></asp:DropDownList>:
                <asp:DropDownList ID="ddlTrain3LeaveMM" runat="server"></asp:DropDownList>
                
               </td>
            </tr>
            
            
            
            <tr>
                 <td colspan="2" style=" text-align:right">
                    <asp:Button runat="server"  Text="修改" ID="btnEdit" onclick="btnEdit_Click" 
                           />
                 </td>
            </tr>
            </table>
  
</asp:Content>

