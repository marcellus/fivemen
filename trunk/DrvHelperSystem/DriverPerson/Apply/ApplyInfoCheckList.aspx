<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyInfoCheckList.aspx.cs" Inherits="DriverPerson_Apply_ApplyInfoCheckList" %>
<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="WC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>初学+增驾审核列表</title>
     <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/popcalendar.js"></script>
    
    <script type="text/javascript">
    var checkFlag=true;
    function ChooseAll()
　　　　{
 　　　　　　//if( !document.all("CheckAll").Checked ) // 全选　
 　　　　　　if( checkFlag ) // 全选　
　　　　　　{
  　　　　　　　　var inputs = document.all.tags("INPUT");
  　　　　　　　　for (var i=0; i < inputs.length; i++) // 遍历页面上所有的 input 
  　　　　　　　　{
  　　　　　　　　　　if (inputs[i].type == "checkbox" && inputs[i].id != "CheckAll" )
   　　　　　　　　　　{
    　　　　　　　　　　　　inputs[i].checked = true;
   　　　　　　　　　　}     
  　　　　　　　　}
  　　　　　　　　checkFlag = false;
 　　　　　　}
 　　　　　　else  // 取消全选
 　　　　　　{
  　　　　　　　　var inputs = document.all.tags("INPUT");
  　　　　　　　　for (var i=0; i < inputs.length; i++) // 遍历页面上所有的 input 
  　　　　　　　　{
   　　　　　　　　　　if (inputs[i].type == "checkbox" && inputs[i].id != "CheckAll" )
   　　　　　　　　　　{
    　　　　　　　　　　　　inputs[i].checked = false;
   　　　　　　　　　　}     
  　　　　　　　　}
  　　　　　　　　checkFlag = true;
 　　　　　　}
　　　　}

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td >
                   初学+增驾审核列表
                </td>
            </tr>
            <tr class="table-bottom">
                <td  style="text-align:right">
              &nbsp; 证件号码&nbsp;<asp:TextBox ID="txtIdCard" runat="server"></asp:TextBox>
                &nbsp;驾校：<asp:DropDownList ID="cbJxdm" runat="server"></asp:DropDownList>
                
&nbsp;审核结果：<asp:DropDownList ID="cbCheckResult" runat="server" >
                        <asp:ListItem Value="0">未审核</asp:ListItem>
                        <asp:ListItem Value="1">已审核</asp:ListItem>
                        <asp:ListItem Value="2">审核失败</asp:ListItem>
                        <asp:ListItem Value="-1">全部</asp:ListItem>
                    </asp:DropDownList>
&nbsp;<asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="查询" />
<br/><hr /><asp:Button ID="btnCheck" runat="server" Text="批量审核" onclick="btnCheck_Click"  />
                    &nbsp; 
                    
                </td>
            </tr>
            <tr class="table-content">
                <td >
                     <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
                        Width="100%" onitemcommand="DataGrid1_ItemCommand" >
                        <Columns>
                            <asp:TemplateColumn> 
                                    <HeaderStyle   HorizontalAlign= "Center"> </HeaderStyle> 
                                    <ItemStyle   HorizontalAlign= "Center"> </ItemStyle> 
                                         <HeaderTemplate> 
                                            <asp:CheckBox   id= "CheckAll"  onclick="ChooseAll()"   runat= "server"   Text= "全选 "> </asp:CheckBox> 
                                        </HeaderTemplate> 
                                     <ItemTemplate> 
                                        <asp:CheckBox   id= "CheckBox1"    runat= "server"> </asp:CheckBox> 
                                     </ItemTemplate> 
                            </asp:TemplateColumn> 


                         <asp:BoundColumn DataField="id" HeaderText="编号"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_lsh" HeaderText="流水号"></asp:BoundColumn>
                             <asp:BoundColumn DataField="sfzmhm" HeaderText="身份证明号码"></asp:BoundColumn>
                              <asp:BoundColumn DataField="c_xm" HeaderText="姓名"></asp:BoundColumn>
                              <asp:BoundColumn DataField="c_jxmc" HeaderText="驾校名称"></asp:BoundColumn>
                            
                            <asp:BoundColumn DataField="c_check_operator" HeaderText="经办人"></asp:BoundColumn>
                             <asp:BoundColumn DataField="i_checked" HeaderText="信息审核"></asp:BoundColumn>
                             <asp:BoundColumn DataField="c_check_result" HeaderText="审核信息"></asp:BoundColumn>
                              <asp:BoundColumn DataField="i_photo_syn" HeaderText="相片同步"></asp:BoundColumn>
                              <asp:TemplateColumn HeaderText="详细">
                            <ItemTemplate>
                            
                            <asp:ImageButton runat="server" AlternateText="详细" CommandArgument='<%#Eval("id") %>' ToolTip="详细" ID="btnDetail" CommandName="Detail" ImageUrl="~/images/modify.gif" />
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
                    </td></tr>
                      <tr class="table-bottom">
                <td>
                   <WC:ProcedurePager ID="ProcedurePager1" runat="server" AllowBinded="True" 
                        BindControlString="DataGrid1" PageSize="30"></WC:ProcedurePager>
                </td>
            </tr>
                    
                    </table>
    </div>
    </form>
</body>
</html>
