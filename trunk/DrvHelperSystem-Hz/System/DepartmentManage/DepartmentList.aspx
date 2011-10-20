<%@ Page Language="C#" MasterPageFile="~/Layout/Master/MainPage.master" AutoEventWireup="true" CodeFile="DepartmentList.aspx.cs" Inherits="System_DepartmentManage_DepartmentList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>车管部门管理</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
      <table border="0" class="table-border" cellpadding="4" cellspacing="1">
            <tr class="table-title">
                <td>
                    系统管理－车管部门管理</td>
            </tr>
            <tr class="table-bottom">
                <td >
                    部门全名：<asp:TextBox ID="txtDepName" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" />
&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="添加" />
                  
                </td>
            </tr>
            <tr  class="table-content">
               
                <td >
                    &nbsp; &nbsp;&nbsp; &nbsp;
                  
                    &nbsp;<asp:DataGrid ID="DataGrid1" runat="server" Width="100%" CssClass="table-border" CellPadding="1"
                         CellSpacing="1"  AutoGenerateColumns="False"
                          OnItemCommand="DataGrid1_ItemCommand1" BorderWidth="0px" >
                    <Columns>
                              <asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="id" HeaderText="编号" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="c_depfullname" HeaderText="部门全名" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="c_depnickname" HeaderText="部门<br/>简称" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="c_depcode" HeaderText="部门<br/>代码" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="c_glbm_code" HeaderText="管理单<br/>位代码" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="c_connector" HeaderText="联系人" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="c_mobile" HeaderText="联系电话" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="c_phone" HeaderText="固定电话" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="c_companycode" HeaderText="机构证<br/>书代码" />
                           
                           
                            <asp:TemplateColumn HeaderText="详细" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            
                            <asp:ImageButton runat="server" AlternateText="详细" CommandArgument='<%#Eval("id") %>' ToolTip="详细" ID="btnDetail" CommandName="Detail" ImageUrl="~/images/modify.gif" />
                            </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="删除" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:ImageButton runat="server" AlternateText="删除" CommandArgument='<%#Eval("id") %>' ToolTip="删除" OnClientClick="return confirm('确定删除吗？');" ID="btnDelete" CommandName="Delete" ImageUrl="~/images/delete.gif" />
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
            <tr class="table-bottom"><td> 
                <cc1:SimplePager ID="SimplePager1" runat="server" AllowBinded="true" 
                    BindControlString="DataGrid1">
                </cc1:SimplePager>
                </td></tr>
        </table>
        </div>

</asp:Content>

