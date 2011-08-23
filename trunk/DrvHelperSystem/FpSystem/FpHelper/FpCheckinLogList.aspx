<%@ Page Title="" Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpCheckinLogList.aspx.cs" Inherits="FpSystem_FpHelper_FpCheckinLogList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" src="../../js/setday.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
       <table class="table-border">
         <tr class="table-content">
           <td style=" text-align:right">
               场地: <asp:DropDownList ID="dllSite" runat="server"></asp:DropDownList>&nbsp;
               业务: <asp:DropDownList ID="dllBustype" runat="server">
                   <asp:ListItem Text="上课" Value="lesson"></asp:ListItem>
                    <asp:ListItem Text="科目一" Value="km1"></asp:ListItem>
                    <asp:ListItem Text="科目二" Value="km2"></asp:ListItem>
                    <asp:ListItem Text="科目三" Value="km3"></asp:ListItem>
                    <asp:ListItem Text="入场训练" Value="train"></asp:ListItem>
               </asp:DropDownList>&nbsp;
               开始日期:<input  onclick="setday(this)"  id="qDateStart" runat="server" /> &nbsp;
               结束日期:<input  onclick="setday(this)"  id="qDateEnd" runat="server" /> &nbsp;
               <asp:Button ID="btnQuery" runat="server" Text="查询" onclick="btnQuery_Click"  />
           </td>
         </tr>
       </table>
    </div>

    <div>
       <asp:DataGrid ID="dgLogs" runat="server" AutoGenerateColumns="false" BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" Width="100%" >
         <Columns>
            <asp:BoundColumn DataField="idcard" HeaderText="证件号码"></asp:BoundColumn>
            <asp:BoundColumn DataField="name" HeaderText="姓名"></asp:BoundColumn>
            <asp:BoundColumn DataField="site_name" HeaderText="场地名称"></asp:BoundColumn>
            <asp:BoundColumn DataField="checkin_date" HeaderText="验证时间"></asp:BoundColumn> 
            <asp:BoundColumn DataField="remark" HeaderText="备注"></asp:BoundColumn>
         </Columns>
         
          <HeaderStyle CssClass="table-title" />
          <ItemStyle CssClass="table-content" />
         
       </asp:DataGrid>
    </div>
</asp:Content>

