<%@ Page Language="C#" MasterPageFile="~/FpSystem/FpHelper/FpHelper.master" AutoEventWireup="true" CodeFile="FpDataExport.aspx.cs" Inherits="FpSystem_FpHelper_FpDataExport" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

            <table style="width:70%" border="0" cellpadding="4" cellspacing="1" class="table-border">
                        <tr class="table-content">
                <td style=" width:200px">导出业务:</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlExportType">
                    </asp:DropDownList>
                
                </td>
            </tr>
            <tr class="table-content">
               <td>开始日期:</td>
               <td><input  onclick="setday(this)"  id="qDateStart" runat="server" /></td>
            </tr>
             <tr class="table-content">
               <td>结束日期:</td>
               <td><input  onclick="setday(this)"  id="qDateEnd" runat="server" /></td>
            </tr>
            
            <tr class="table-content">
                <td>数据格式:</td>
                <td>
                  <asp:RadioButtonList ID="rblFormat" runat="server">
                     <asp:ListItem Selected="True" Text="受理号,姓名" Value="{0},{1}"> </asp:ListItem>
                     <asp:ListItem Text="姓名,受理号" Value="{1},{0}" ></asp:ListItem>
                  </asp:RadioButtonList>
                </td>
            </tr>

            
            <tr>
                 <td colspan="2" style=" text-align:right">
                    <asp:Button runat="server"  Text="查询" ID="btnSearch" 
                         onclick="btnSearch_Click"  />&nbsp;
                    <asp:Button runat="server"  Text="导出txt" ID="btnExport" onclick="btnExport_Click" />
                 </td>
            </tr>
            </table>
            <p></p>
            <table class="table-border" cellspacing="1" cellpadding="1" rules="all" border="0" id="ctl00_ContentPlaceHolder1_dgSites" style="border-width:0px;width:70%;">
               <asp:Repeater ID="rpStuedts" runat="server">
               <HeaderTemplate>
                  <tr>
                    <td>受理号</td>
                    <td>姓名</td>
                    <td>证件号码</td>
                  </tr>
               </HeaderTemplate>
               <ItemTemplate>
                  <tr class="table-content">
                    <td><%# Eval("LSH") %></td>
                    <td><%# Eval("NAME") %></td>
                    <td><%# Eval("IDCARD") %></td>
                  </tr>
               </ItemTemplate>
               </asp:Repeater>
            </table>

</asp:Content>
   
