<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CoachCarSearch.aspx.cs" Inherits="DriverPerson_SystemCounter_CoachCarSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>教练车查询</title> 
    <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
  <script language="JavaScript" src="js/drv/commpage.js" type="text/javascript"></script>
	<script language="JavaScript" src="js/drv/common_check.js" type="text/javascript"></script>
	<script language="JavaScript" src="js/drv/tools.js" type="text/javascript"></script>
	<script language="javascript" src="js/drv/ajax.js" type="text/javascript"></script>
	<script language="javascript" src="js/drv/pcc.js" type="text/javascript"></script>
	<script language="javascript" src="js/drv/function.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
                    身份证明号码：<asp:textbox ID="txtIdCard" runat="server"></asp:textbox>
                    &nbsp; 
                  号码号牌
                    &nbsp;&nbsp;&nbsp;
        <asp:textbox ID="txtHmhp" runat="server">
        </asp:textbox>
                    &nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="查询" />
    </div>
    <div>
    <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
                        Width="100%" >
                        <Columns>
                            <asp:BoundColumn DataField="jxmc" HeaderText="驾校名称"></asp:BoundColumn>
                            <asp:BoundColumn DataField="jlzh" HeaderText="教练证号"></asp:BoundColumn>
                             <asp:BoundColumn DataField="sfzmhm" HeaderText="身份证明名称"></asp:BoundColumn>
                            <asp:BoundColumn DataField="xm" HeaderText="姓名"></asp:BoundColumn>
                             <asp:BoundColumn DataField="clpp" HeaderText="车辆品牌"></asp:BoundColumn>
                            <asp:BoundColumn DataField="hphm" HeaderText="号牌号码"></asp:BoundColumn>
                              <asp:BoundColumn DataField="regdate" HeaderText="入场日期"></asp:BoundColumn>
                            <asp:BoundColumn DataField="sj" HeaderText="联系手机"></asp:BoundColumn>
                            
                        </Columns>
                        <HeaderStyle CssClass="table-title" />
                        <ItemStyle CssClass="table-content" />
                        <EditItemStyle CssClass="table-content" />
                    </asp:DataGrid>
    
    </div>
    </form>
</body>
</html>
