<%@ Page Title="" Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpCheckinLogStatis.aspx.cs" Inherits="FpSystem_FpHelper_FpCheckinLogStatis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="../../js/setday.js"></script>

    <script language="javascript" type="text/javascript">

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div>
       <table class="table-border">
         <tr class="table-content">
           <td style=" text-align:right">
               开始日期:<input  onclick="setday(this)"  id="qDateStart" runat="server" /> &nbsp;
               开始日期:<input  onclick="setday(this)"  id="qDateEnd" runat="server" /> &nbsp;
               <asp:Button ID="btnQuery" runat="server" Text="查询" onclick="btnQuery_Click" />
           </td>
         </tr>
       </table>
    </div>

    <div>
       <asp:DataGrid ID="dgLogs" runat="server" AutoGenerateColumns="false" BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" Width="100%" >
         <Columns>
            <asp:BoundColumn DataField="name" HeaderText="场地名称"></asp:BoundColumn>
            <asp:BoundColumn DataField="bustype" HeaderText="业务类型"></asp:BoundColumn>
            <asp:BoundColumn DataField="tnum" HeaderText="成功审核次数"></asp:BoundColumn>
         </Columns>
         
          <HeaderStyle CssClass="table-title" />
          <ItemStyle CssClass="table-content" />
         
       </asp:DataGrid>
    </div>
</asp:Content>

