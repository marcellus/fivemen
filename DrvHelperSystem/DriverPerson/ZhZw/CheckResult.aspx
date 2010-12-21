<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckResult.aspx.cs" Inherits="DriverPerson_ZhZw_CheckResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>检查学时和入场训练结果</title>
       <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/popcalendar.js"></script>
</head>
<body>
    <form id="form1" runat="server">
     <div>
    <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td>
                    检查学时和入场训练结果<br />
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
                            
                             <asp:BoundColumn DataField="lesson_result" HeaderText="科目一教育学时是否完成"></asp:BoundColumn>
                             <asp:BoundColumn DataField="train_result" HeaderText="入场训练是否完成"></asp:BoundColumn>
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
            
        </table>
    </div>
    </form>
</body>
</html>
