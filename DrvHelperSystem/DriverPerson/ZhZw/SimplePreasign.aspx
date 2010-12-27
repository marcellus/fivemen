<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SimplePreasign.aspx.cs" Inherits="DriverPerson_ZhZw_SimplePreasign" %>

<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="WC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>考试预约</title>
       <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/popcalendar.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table border="0" cellpadding="4" cellspacing="1" class="table-border">
            <tr class="table-title">
                <td >
                  
                    &nbsp;
                    预约申请名单
                 
                     
                    <asp:HiddenField ID="hidPaiBanId" value="-1" runat="server" />
                 
                   
                   </td>
                   </tr>
                   <tr class="table-content"><td>
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
                &nbsp;&nbsp; 证件号码&nbsp;<asp:TextBox ID="txtIdCard" runat="server" Width="181px"></asp:TextBox>
                  约考日期 <input  onclick="setday(this)"  id="txtYkrq" runat="server" />
                &nbsp;培训审核日期 
        <input  onclick="setday(this)"  id="txtDate" runat="server" />
        </td>
        </tr>
         <tr class="table-bottom">
         <td>
        驾校 <asp:DropDownList ID="cbSchool" runat="server" Height="16px" Width="114px" Font-Size="15pt">
        </asp:DropDownList>&nbsp;
         号码号牌&nbsp;&nbsp;&nbsp; 
        <asp:DropDownList ID="cbCarNo" runat="server" Height="16px" Width="114px" Font-Size="15pt">
        </asp:DropDownList>
                    &nbsp; 
                    <asp:Button ID="btnAdd" runat="server" Text="约考" onclick="btnAdd_Click" />
                    &nbsp;&nbsp; 
                    
                </td>
            </tr>
            <tr class="table-content"><td>
            
            证件号码&nbsp;<asp:TextBox ID="txtIdCardSearch" runat="server" Width="181px"></asp:TextBox>&nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" />
            </td></tr>
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
