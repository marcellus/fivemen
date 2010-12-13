<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolCommitUser.aspx.cs" Inherits="DriverPreson_Preasign_SchoolCommitUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>驾校录入窗口</title>
     <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/setday.js"></script>
</head>
<body>
    <form id="form1" runat="server">
      <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td >
                    约考日期<asp:Label ID="lbYkrq" runat="server" ForeColor="Red"></asp:Label>
                    &nbsp;驾校<asp:Label ID="lbSchoolName" runat="server" ForeColor="Red"></asp:Label>
                    预约申请名单
                 
                     
                    <asp:HiddenField ID="hidPaiBanId" runat="server" />
                 
                    <br />
                    科目 
        <asp:DropDownList ID="cbKm" runat="server" Enabled="False" Font-Size="15pt">
            <asp:ListItem Value="1">科目一</asp:ListItem>
            <asp:ListItem Value="2">科目二</asp:ListItem>
            <asp:ListItem Value="3">科目三</asp:ListItem>
        </asp:DropDownList>
                    &nbsp; 地点&nbsp; 
        <asp:DropDownList ID="cbKsdd" runat="server" Enabled="False" Width="273px" Font-Size="15pt">
        </asp:DropDownList>
                    &nbsp; 场次&nbsp;<asp:DropDownList ID="cbKscc" runat="server" Enabled="False" 
                        Font-Size="15pt">
        </asp:DropDownList>
                    &nbsp;
                </td>
            </tr>
            <tr class="table-bottom">
                <td >
                &nbsp;&nbsp; 证件号码&nbsp;<asp:TextBox ID="txtIdCard" runat="server"></asp:TextBox>
                
                &nbsp;培训审核日期 
        <input  onclick="setday(this)"  id="txtDate" runat="server" /> 号码号牌&nbsp;&nbsp;&nbsp; 
        <asp:DropDownList ID="cbCarNo" runat="server" Height="16px" Width="114px" Font-Size="15pt">
        </asp:DropDownList>
                    &nbsp; 
                    <asp:Button ID="btnAdd" runat="server" Text="约考" onclick="btnAdd_Click" />
                    &nbsp;&nbsp; 
                    
                </td>
            </tr>
            <tr class="table-content">
                <td >
                     <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" CellPadding="1" CellSpacing="1" CssClass="table-border" 
                        Width="100%" >
                        <Columns>
                            <asp:BoundColumn DataField="id" HeaderText="编号"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_lsh" HeaderText="流水号"></asp:BoundColumn>
                             <asp:BoundColumn DataField="c_idcard" HeaderText="身份证明号码"></asp:BoundColumn>
                              <asp:BoundColumn DataField="c_xm" HeaderText="姓名"></asp:BoundColumn>
                            <asp:BoundColumn DataField="date_pxshrq" HeaderText="培训审核日期"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_hmhp" HeaderText="号码号牌"></asp:BoundColumn>
                            <asp:BoundColumn DataField="c_jbr" HeaderText="经办人"></asp:BoundColumn>
                             <asp:BoundColumn DataField="i_checked" HeaderText="审核结果"></asp:BoundColumn>
                             <asp:BoundColumn DataField="c_check_result" HeaderText="审核信息"></asp:BoundColumn>
                             
                            
                        </Columns>
                        <HeaderStyle CssClass="table-title" />
                        <ItemStyle CssClass="table-content" />
                        <EditItemStyle CssClass="table-content" />
                    </asp:DataGrid></td>
            </tr>
           
        </table>
    </form>
</body>
</html>
