<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="ProductEdit.aspx.cs" Inherits="Admin_ProductEdit" %>
<%@ Register assembly="FT.Web" namespace="WebControls" tagprefix="WC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品列表编辑</title>
     <meta content="no-cache" http-equiv="pragma">
    <meta content="no-cache,must-revalidate" http-equiv="Cache-Control">
    <link href="../css/main.css" rel="Stylesheet" type="text/css" />
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="4" cellspacing="1" class="table-border" >
            <tr class="poptable-title">
                <td colspan="4">
                    编号<asp:Label ID="lbId" runat="server"></asp:Label>
                    产品详细信息：
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title">
                    产品名称：
                </td>
                <td colspan="3" style="width: 50px">
                    <asp:TextBox ID="txtTitle" runat="server" Width="339px"></asp:TextBox>
                </td>
            </tr>
            <tr class="table-content">
                <td class="table-title" >
                    详细信息：
                </td>
                <td  colspan="3">
                    <asp:TextBox ID="txtContent" runat="server" Height="317px" TextMode="MultiLine" 
                        Width="335px"></asp:TextBox>
                </td>
               
            </tr>
            
            <tr class="table-content">
                <td class="table-title">
                    图片地址：
                </td>
                <td class="style2" colspan="3">
                    <asp:TextBox ID="txtPicUrl" runat="server" Width="332px"></asp:TextBox>
                </td>
               
            </tr>
            
            <tr class="table-content">
                <td class="table-title">
                    产品类别：
                </td>
                <td class="style2" colspan="3">
                    <asp:TextBox ID="txtTypeId" runat="server" Width="332px"></asp:TextBox>
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
