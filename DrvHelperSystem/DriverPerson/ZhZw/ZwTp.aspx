<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZwTp.aspx.cs" Inherits="DriverPerson_ZhZw_ZwTp" %>

<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="WC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>指纹审核特批</title>
      <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/popcalendar.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div>
    <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td>
                    指纹审核特批<br />
                </td>
            </tr>
            <tr class="table-bottom">
            <td>
            身份证明号码：<asp:TextBox ID="txtIdCardInput" runat="server"></asp:TextBox>
            &nbsp;&nbsp;特批类型：<asp:DropDownList ID="DropDownList1" runat="server" 
                    Font-Size="15pt">
                    <asp:ListItem>上课</asp:ListItem>
                    <asp:ListItem>入场训练</asp:ListItem>
                </asp:DropDownList>
&nbsp;<asp:Button ID="btnAdd" runat="server"  Text="特批" onclick="btnAdd_Click" />
            </td>
            </tr>
            <tr class="table-bottom">
                <td>
                    身份证明号码：<asp:TextBox ID="txtIdCard" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:Button ID="btnSearch" runat="server"  Text="查询" 
                        onclick="btnSearch_Click" />
                    &nbsp;&nbsp;&nbsp;
                    
                </td>
            </tr>
            <tr class="table-content">
                <td>
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;<asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" OnItemCommand="DataGrid1_ItemCommand1"
                        Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="id" HeaderText="编号"></asp:BoundColumn>
                             <asp:BoundColumn DataField="school" HeaderText="驾校"></asp:BoundColumn>
                             <asp:BoundColumn DataField="idcard" HeaderText="身份证明号码"></asp:BoundColumn>
                            
                             <asp:BoundColumn DataField="name" HeaderText="姓名"></asp:BoundColumn>
                              <asp:BoundColumn DataField="type" HeaderText="特批类别"></asp:BoundColumn>
                            
                            <asp:BoundColumn DataField="approver" HeaderText="特批人"></asp:BoundColumn>
                            <asp:BoundColumn DataField="approve_time" HeaderText="特批时间"></asp:BoundColumn>
                           
                            <asp:TemplateColumn HeaderText="删除">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDelete" runat="server" AlternateText="删除" CommandArgument='<%#Eval("id") %>'
                                        CommandName="Delete" ImageUrl="~/images/delete.gif" OnClientClick="return confirm('确定删除吗？');"
                                        ToolTip="删除" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
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
