<%@ Page Title="" Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpStudentRecordStatis.aspx.cs" Inherits="FpSystem_FpHelper_FpStudentRecordStatis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div>
       <table class="table-border">
         <tr class="table-content">
           <td style=" text-align:right">
               开始日期:<input  onclick="setday(this)"  id="qDateStart" runat="server" /> &nbsp;
               结束日期:<input  onclick="setday(this)"  id="qDateEnd" runat="server" /> &nbsp;
               <asp:Button ID="btnQuery" runat="server" Text="查询" onclick="btnQuery_Click" /> &nbsp;
               <asp:Button ID="btnExportDetailExcel" runat="server" Text="导出详细execl" 
                   onclick="btnExportDetailExcel_Click"   />
           </td>
         </tr>
         
       </table>
    </div>

    <div>
       <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="false" BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" Width="100%" >
         <Columns>
            <asp:BoundColumn DataField="c_depnickname" HeaderText="驾校"></asp:BoundColumn>
             <asp:BoundColumn DataField="c_depcode" HeaderText="驾校代码"></asp:BoundColumn>
            <asp:BoundColumn DataField="new_num" HeaderText="新导入"></asp:BoundColumn>
            <asp:BoundColumn DataField="fee_num" HeaderText="已收费"></asp:BoundColumn>
            <asp:BoundColumn DataField="lesson_finish_num" HeaderText="已上课"></asp:BoundColumn>
         </Columns>
         
          <HeaderStyle CssClass="table-title" />
          <ItemStyle CssClass="table-content" />
         
       </asp:DataGrid>
    </div>

</asp:Content>

