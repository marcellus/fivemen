﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BusLogSearch.aspx.cs" Inherits="DriverPreson_Hospital_BusLogSearch" %>
<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="WC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>体检业务日志查询</title>
     <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/popcalendar.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 800px;">
        <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td colspan="2">
                    体检业务日志查询
                </td>
            </tr>
             <tr class="table-bottom">
                <td>
                    证件号码：<asp:TextBox ID="txtIdCard" runat="server"></asp:TextBox>
                    
</td><td> 档案编号： 
                    <asp:TextBox ID="txtDabh" runat="server"></asp:TextBox>
                    
                </td>
            </tr>
             <tr class="table-bottom">
                <td>
                    操作时间起：<input onclick="popUpCalendar(this,document.getElementById('txtBeginDate'),'yyyy-mm-dd')" id="txtBeginDate" runat="server" />
                    </td><td>
                   操作时间止：
   
                    
                    <input onclick="popUpCalendar(this,document.getElementById('txtEndDate'),'yyyy-mm-dd')" id="txtEndDate" runat="server" />
                    
                </td>
            </tr>
             <tr class="table-bottom">
                <td>
                    操&nbsp; 作&nbsp; 者：<asp:TextBox ID="txtOperator" runat="server"></asp:TextBox>
                    </td><td>
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="查询" />
                    &nbsp;&nbsp;&nbsp;</td>
            </tr>
           
           
            <tr class="table-content">
                <td colspan="2"><asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
                        Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="id" HeaderText="编号"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_operator" HeaderText="操作者"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_bustype" HeaderText="业务类别"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_content" HeaderText="操作内容"></asp:BoundColumn>
                            <asp:BoundColumn DataField="regdate" HeaderText="操作时间"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_des1" HeaderText="证件号码"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_des2" HeaderText="档案编号"></asp:BoundColumn>
                        </Columns>
                        <HeaderStyle CssClass="table-title" />
                        <ItemStyle CssClass="table-content" />
                        <EditItemStyle CssClass="table-content" />
                    </asp:DataGrid>
                    &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr class="table-bottom">
                <td colspan="2">
                    <WC:ProcedurePager ID="ProcedurePager1" runat="server" 
                        BindControlString="DataGrid1" AllowBinded="True">
                    </WC:ProcedurePager>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
