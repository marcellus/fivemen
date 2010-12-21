<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZwRecordList.aspx.cs" Inherits="DriverPerson_ZhZw_ZwRecordList" %>
<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="WC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>入场训练指纹打卡记录</title>
      <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/popcalendar.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td>
                    入场训练指纹打卡记录<br />
                </td>
            </tr>
            <tr class="table-bottom">
                <td>
                    身份证明号码：<asp:TextBox ID="txtIdCard" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:Button ID="btnSearch" runat="server"  Text="查询" onclick="btnSearch_Click" 
                         />
                </td>
            </tr>
            <tr class="table-content">
                <td>
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;<asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
                        Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="idcard" HeaderText="身份证明号码"></asp:BoundColumn>
                             <asp:BoundColumn DataField="name" HeaderText="姓名"></asp:BoundColumn>
                            
                             <asp:BoundColumn DataField="train_enter_1" HeaderText="第一次入场训练时间"></asp:BoundColumn>
                             <asp:BoundColumn DataField="train_leave_1" HeaderText="第一次训练离场时间"></asp:BoundColumn>
                             <asp:BoundColumn DataField="train_enter_2" HeaderText="第二次入场训练时间"></asp:BoundColumn>
                             <asp:BoundColumn DataField="train_leave_2" HeaderText="第二次训练离场时间"></asp:BoundColumn>
                              <asp:BoundColumn DataField="train_enter_3" HeaderText="第三次入场训练时间"></asp:BoundColumn>
                             <asp:BoundColumn DataField="train_leave_3" HeaderText="第三次训练离场时间"></asp:BoundColumn>
                              <asp:BoundColumn DataField="train_enter_4" HeaderText="第四次入场训练时间"></asp:BoundColumn>
                             <asp:BoundColumn DataField="train_leave_4" HeaderText="第四次训练离场时间"></asp:BoundColumn>
                              <asp:BoundColumn DataField="train_enter_5" HeaderText="第五次入场训练时间"></asp:BoundColumn>
                             <asp:BoundColumn DataField="train_leave_5" HeaderText="第五次训练离场时间"></asp:BoundColumn>
                              <asp:BoundColumn DataField="train_enter_6" HeaderText="第六次入场训练时间"></asp:BoundColumn>
                             <asp:BoundColumn DataField="train_leave_6" HeaderText="第六次训练离场时间"></asp:BoundColumn>
                              <asp:BoundColumn DataField="train_enter_7" HeaderText="第七次入场训练时间"></asp:BoundColumn>
                             <asp:BoundColumn DataField="train_leave_7" HeaderText="第七次训练离场时间"></asp:BoundColumn>
                              <asp:BoundColumn DataField="train_enter_8" HeaderText="第八次入场训练时间"></asp:BoundColumn>
                             <asp:BoundColumn DataField="train_leave_8" HeaderText="第八次训练离场时间"></asp:BoundColumn>
                                <asp:BoundColumn DataField="phone" HeaderText="联系电话"></asp:BoundColumn> 
                            <asp:BoundColumn DataField="drv_school" HeaderText="驾校名称"></asp:BoundColumn>
                           
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
