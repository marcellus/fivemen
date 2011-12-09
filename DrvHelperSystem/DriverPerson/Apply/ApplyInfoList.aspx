<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyInfoList.aspx.cs" Inherits="DriverPerson_Apply_ApplyInfoList" %>

<%@ Register Assembly="FT.Web" Namespace="WebControls" TagPrefix="WC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>初学+增驾申请名单列表</title>
    <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td colspan="2">
                    初学+增驾申请名单列表
                </td>
            </tr>
            <tr class="table-bottom">
                <td colspan="2">
                                  学员信息:
              <asp:DropDownList ID="ddlQueryType" runat="server">
              <asp:ListItem Text="证件号码" Value="c_sfzmhm"></asp:ListItem>
    
              <asp:ListItem Text="姓名" Value="c_xm"></asp:ListItem>
           </asp:DropDownList>
           <asp:TextBox ID="txtQueryValue" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click1" Text="添加" />
                </td>
            </tr>
            <tr class="table-content">
                <td colspan="2">
                    <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" OnItemCommand="DataGrid1_ItemCommand1"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border">
                        <Columns>
                            <asp:BoundColumn DataField="id" HeaderText="编号"></asp:BoundColumn>
                            
                            <asp:BoundColumn DataField="sfzmhm" HeaderText="身份证明号码"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_xm" HeaderText="姓名"></asp:BoundColumn>
                            
                            
                            <asp:BoundColumn DataField="i_checked" HeaderText="审核结果"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_check_result" HeaderText="审核信息"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_check_operator" HeaderText="经办人"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="详细">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" AlternateText="详细" CommandArgument='<%#Eval("id") %>'
                                        ToolTip="详细" ID="btnDetail" CommandName="Detail" ImageUrl="~/images/modify.gif" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="删除">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" AlternateText="删除" CommandArgument='<%#Eval("id") %>'
                                        ToolTip="删除" OnClientClick="return confirm('确定删除吗？');" ID="btnDelete" CommandName="Delete"
                                        ImageUrl="~/images/delete.gif" />
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
                <td colspan="2">
                    <WC:ProcedurePager ID="ProcedurePager1" runat="server" AllowBinded="True" BindControlString="DataGrid1">
                    </WC:ProcedurePager>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
