<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExtraAssignList.aspx.cs" Inherits="DriverPreson_Preasign_ExtraAssignList" %>
<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="WC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>预约特批</title>
     <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/setday.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td>
                    预约特批<br />
                </td>
            </tr>
            <tr class="table-bottom">
                <td>
                      查看日期&nbsp; 
        <input  onclick="setday(this)"  id="txtDate" runat="server" />
&nbsp;
        <asp:Button ID="btnSubmit" runat="server" Text="查看" onclick="btnSubmit_Click"  />
        
        &nbsp;&nbsp;&nbsp;&nbsp;特批数量&nbsp;<asp:TextBox ID="txtNum" runat="server"></asp:TextBox>
                   
                </td>
            </tr>
            <tr class="table-content">
                <td>
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;<asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" OnItemCommand="DataGrid1_ItemCommand1"
                        Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="id" HeaderText="编号"></asp:BoundColumn>
                            
                             <asp:BoundColumn DataField="c_ksdd" HeaderText="考试地点"></asp:BoundColumn>
                             <asp:BoundColumn DataField="c_kscc" HeaderText="考试场次"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_school_name" HeaderText="驾校名字"></asp:BoundColumn>
                            <asp:BoundColumn DataField="i_total" HeaderText="考试人数"></asp:BoundColumn>
                             <asp:BoundColumn DataField="i_tptotal" HeaderText="特批人数"></asp:BoundColumn>
                              
                            <asp:TemplateColumn HeaderText="特批">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDetail" runat="server" AlternateText="特批" CommandArgument='<%#Eval("id") %>'
                                        CommandName="Tp" ImageUrl="~/images/modify.gif" ToolTip="特批" />
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
