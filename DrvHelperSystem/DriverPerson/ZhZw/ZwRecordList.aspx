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
                    教练车列表<br />
                </td>
            </tr>
            <tr class="table-bottom">
                <td>
                    号码号牌：<asp:TextBox ID="txtHphm" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:Button ID="btnSearch" runat="server"  Text="查询" 
                         />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server"  Text="添加"  />
                </td>
            </tr>
            <tr class="table-content">
                <td>
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;<asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
                        Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="id" HeaderText="编号"></asp:BoundColumn>
                             <asp:BoundColumn DataField="clpp" HeaderText="车辆品牌"></asp:BoundColumn>
                            
                             <asp:BoundColumn DataField="hmhp" HeaderText="号码号牌"></asp:BoundColumn>
                             <asp:BoundColumn DataField="name" HeaderText="教练名"></asp:BoundColumn>
                            <asp:BoundColumn DataField="idcard" HeaderText="身份证号"></asp:BoundColumn>
                            <asp:BoundColumn DataField="coachno" HeaderText="教练证号"></asp:BoundColumn>
                             <asp:BoundColumn DataField="mobile" HeaderText="联系电话"></asp:BoundColumn>
                            
                           
                            <asp:BoundColumn DataField="depname" HeaderText="驾校名称"></asp:BoundColumn>
                           
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
