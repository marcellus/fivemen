<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolCommitCheckTest.aspx.cs" Inherits="DriverPerson_Preasign_SchoolCommitCheckTest" %>
<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="WC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>测试数据同步</title>
     <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/popcalendar.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
                        Width="100%" >
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
                             <asp:BoundColumn DataField="c_idcard" HeaderText="身份证明号码"></asp:BoundColumn>
                               <asp:BoundColumn DataField="i_km" HeaderText="考试科目"></asp:BoundColumn>
                             <asp:BoundColumn DataField="date_ksrq" HeaderText="考试日期"></asp:BoundColumn>
                              <asp:BoundColumn DataField="c_xm" HeaderText="姓名"></asp:BoundColumn>
                            <asp:BoundColumn DataField="date_pxshrq" HeaderText="培训审核日期"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_hmhp" HeaderText="号码号牌"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_jbr" HeaderText="经办人"></asp:BoundColumn>
                             <asp:BoundColumn DataField="i_checked" HeaderText="审核结果"></asp:BoundColumn>
                            
                        </Columns>
                        <HeaderStyle CssClass="table-title" />
                        <ItemStyle CssClass="table-content" />
                        <EditItemStyle CssClass="table-content" />
                    </asp:DataGrid>
                     <WC:ProcedurePager ID="ProcedurePager1" runat="server" AllowBinded="True" 
                        BindControlString="DataGrid1" PageSize="30"></WC:ProcedurePager>
    </div>
    </form>
</body>
</html>
