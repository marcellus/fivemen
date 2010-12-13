<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YuyueDayLimitEdit.aspx.cs" Inherits="DriverPerson_Preasign_YuyueDayLimitEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>预约间隔限制详细信息</title>
     <meta content="no-cache" http-equiv="pragma">
    <meta content="no-cache,must-revalidate" http-equiv="Cache-Control">
     <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/popcalendar.js"></script>
    <base target="_self"></base>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table border="0" cellpadding="4" cellspacing="1" class="table-border">
                <tr class="poptable-title">
                    <td colspan="2">
                        编号<asp:Label ID="lbId" runat="server"></asp:Label>
                        预约间隔限制详细信息：
                    </td>
                </tr>
                <tr class="table-content">
                    <td class="table-title" >
                       车辆类别：
                    </td>
                    <td>
                        <asp:TextBox ID="txtCarType" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr class="table-content">
                    <td class="table-title" >
                        间隔天数：
                    </td>
                    <td >
                        <asp:TextBox ID="txtDays" runat="server" ></asp:TextBox>
                    </td>
                    
                </tr>
                 <tr class="table-content">
                    <td class="table-title">
                       科目：
                    </td>
                    <td >
                        <asp:DropDownList ID="cbKmValue" runat="server" Height="16px" Width="127px" 
                            Font-Size="15pt">
                            <asp:ListItem Value="1">科目一</asp:ListItem>
                            <asp:ListItem Value="2">科目二</asp:ListItem>
                            <asp:ListItem Value="3">科目三</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    
                </tr>
                
                <tr class="table-content">
                    <td class="table-content" colspan="2" style="text-align: center">
                        <asp:Button ID="btnSure" runat="server" OnClick="btnSure_Click" Text="确定" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="Button2" class="button" onclick="javascript:window.opener=null;window.close();"
                            type="button" value="关闭" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
