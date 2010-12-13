<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YuyueResultSearch.aspx.cs" Inherits="DriverPerson_Preasign_YuyueResultSearch" %>
<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="WC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>预约结果反馈</title>
    <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td>
                    预约结果反馈<br />
                </td>
            </tr>
            <tr class="table-bottom">
                <td>
                    身份证明号码：<asp:TextBox ID="txtIdCard" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:Button ID="btnSearch" runat="server"  Text="查询" 
                        onclick="btnSearch_Click" />
                   
                </td>
            </tr>
            <tr class="table-content">
                <td>
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;<asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
                        Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="id" HeaderText="编号"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_lsh" HeaderText="流水号"></asp:BoundColumn>
                             <asp:BoundColumn DataField="c_idcard" HeaderText="身份证明号码"></asp:BoundColumn>
                              <asp:BoundColumn DataField="c_xm" HeaderText="姓名"></asp:BoundColumn>
                              <asp:BoundColumn DataField="i_km" HeaderText="科目"></asp:BoundColumn>
                             <asp:BoundColumn DataField="c_ksdd" HeaderText="考试地点"></asp:BoundColumn>
                              <asp:BoundColumn DataField="c_kscc" HeaderText="考试场次"></asp:BoundColumn>
                             <asp:BoundColumn DataField="date_ksrq" HeaderText="考试时间"></asp:BoundColumn>
                             
                             
                            <asp:BoundColumn DataField="date_pxshrq" HeaderText="培训审核日期"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_hmhp" HeaderText="号码号牌"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_jbr" HeaderText="经办人"></asp:BoundColumn>
                             <asp:BoundColumn DataField="i_checked" HeaderText="审核结果"></asp:BoundColumn>
                             <asp:BoundColumn DataField="c_check_result" HeaderText="审核信息"></asp:BoundColumn>
                        </Columns>
                        <HeaderStyle CssClass="table-title" />
                        <ItemStyle CssClass="table-content" />
                        <EditItemStyle CssClass="table-content" />
                    </asp:DataGrid>
                    &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr class="table-bottom">
                <td>
                 
                    <WC:ProcedurePager ID="ProcedurePager1" runat="server" AllowBinded="True" 
                        BindControlString="DataGrid1">
                    </WC:ProcedurePager>
                 
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
