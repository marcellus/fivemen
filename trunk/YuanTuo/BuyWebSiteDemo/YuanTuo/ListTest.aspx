<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListTest.aspx.cs" Inherits="YuanTuo_ListTest" %>

<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="WC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="code" HeaderText="城市代码" />
                <asp:BoundField DataField="name" HeaderText="城市名称" />
                <asp:BoundField DataField="description" HeaderText="备注" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    
    </div>
    <WC:ProcedurePager ID="ProcedurePager1" runat="server" AllowBinded="True" 
        BindControlString="GridView1" FieldString="*" PageSize="2" 
        SortString="code asc" TableName="common_weather_city">
    </WC:ProcedurePager>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        style="height: 26px" Text="Button" />
    </form>
</body>
</html>
