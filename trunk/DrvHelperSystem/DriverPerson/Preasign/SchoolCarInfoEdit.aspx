<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolCarInfoEdit.aspx.cs" Inherits="DriverPerson_Preasign_SchoolCarInfoEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>教练车信息编辑</title>
     <meta content="no-cache" http-equiv="pragma">
    <meta content="no-cache,must-revalidate" http-equiv="Cache-Control">
     <link href="../../css/main.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/popcalendar.js"></script>
    <base target="_self"></base>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table border="0" cellpadding="4"  cellspacing="1" class="table-border" >
                <tr class="poptable-title">
                    <td colspan="4">
                        编号<asp:Label ID="lbId" runat="server"></asp:Label>
                        教练车详细信息：
                    </td>
                </tr>
                 <tr class="table-content">
                    <td class="table-title" style="width: 100px">
                       所属驾校：
                    </td>
                    <td colspan="3">
                        <asp:DropDownList ID="cbDepCodeValue" runat="server" Height="16px"  
                            Width="450px" Font-Size="15pt">
                           
                        </asp:DropDownList>
                    </td>
                    
                </tr>
                <tr class="table-content">
                    <td class="table-title" style="">
                       车辆品牌：
                    </td>
                    <td>
                        <asp:TextBox ID="txtClpp" runat="server"></asp:TextBox>
                    </td>
                    <td class="table-title" style="">
                       号码号牌：
                    </td>
                    <td>
                        <asp:TextBox ID="txtHmhp" runat="server"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr class="table-content">
                <td class="table-title" style="">
                       教练名字：
                    </td>
                    <td>
                        <asp:TextBox ID="txtCoachName" runat="server"></asp:TextBox>
                    </td>
                    <td class="table-title" style="">
                        身份证明号码：
                    </td>
                    <td >
                        <asp:TextBox ID="txtIdCard" runat="server" ></asp:TextBox>
                    </td>
                
                </tr>
                <tr class="table-content">
                    
                    <td class="table-title" style="">
                       教练证号：
                    </td>
                    <td>
                        <asp:TextBox ID="txtCoachNo" runat="server"></asp:TextBox>
                    </td>
                    <td class="table-title" style="">
                       联系电话：
                    </td>
                    <td>
                        <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                    </td>
                    
                </tr>
                
                
                <tr class="table-content">
                    <td class="table-content" colspan="4" style="text-align: center">
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
