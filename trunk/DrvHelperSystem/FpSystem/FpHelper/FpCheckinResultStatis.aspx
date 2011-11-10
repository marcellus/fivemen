<%@ Page Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpCheckinResultStatis.aspx.cs" Inherits="FpSystem_FpHelper_FpCheckinResultStatis" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

          <table style="width:70%" border="0" cellpadding="4" cellspacing="1" class="table-border">

            <tr class="table-content">
               <th>开始日期:</th>
               <td><input  onclick="setday(this)"  id="qDateStart" runat="server" /></td>
            </tr>
             <tr class="table-content">
               <th>结束日期:</th>
               <td><input  onclick="setday(this)"  id="qDateEnd" runat="server" /></td>
            </tr>
            
            
            <tr>
                 <td colspan="2" style=" text-align:right">
                    <asp:Button runat="server"  Text="查询" ID="btnSearch" onclick="btnSearch_Click" 
                           />&nbsp;
                 </td>
            </tr>
            
            
            
            </table>
            <p></p>
            <table style="width:70%" border="0" cellpadding="4" cellspacing="1" class="table-border">
              <tr class="table-content">
                <th>查询日期</th>
                 <td><asp:Label runat="server" ID="lbStartDate"></asp:Label>&nbsp;~&nbsp;<asp:Label runat="server" ID="lbEndDate"></asp:Label></td>
              </tr>
               
              <tr class="table-content">
                 <th>已完成上课人数</th>
                 <td><asp:Label runat="server" ID="lbCountFinishLesson"></asp:Label></td>
              </tr>
              
              <tr class="table-content">
                 <th>已完成入场训练人数</th>
                 <td><asp:Label runat="server" ID="lbCountFinishTrain"></asp:Label></td>
              </tr>
               
            </table>

</asp:Content>

