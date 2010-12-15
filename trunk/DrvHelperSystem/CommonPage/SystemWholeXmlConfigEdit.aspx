<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemWholeXmlConfigEdit.aspx.cs" Inherits="CommonPage_SystemWholeXmlConfigEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统全局参数的编辑</title>
    <meta http-equiv="pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache,must-revalidate"> 
    <link href="../css/main.css" rel="Stylesheet" type="text/css" />
    <base target="_self"></base>
</head>
<body>
    <form id="form1" runat="server">
     <div>
        <div>
            <table border="0" cellpadding="4" cellspacing="1" class="table-border" >
                <tr class="table-content">
                    <td class="table-title"  style="width:130px;">
                        参数序号：
                    </td>
                    <td>
                        <asp:TextBox ID="txtId" runat="server" Width="75px"></asp:TextBox>
                    </td>
                </tr>
                <tr class="table-content">
                    <td class="table-title" >
                        参数关键字：
                    </td>
                    <td>
                        <asp:TextBox ID="txtKey" runat="server" Width="441px"></asp:TextBox>
                    </td>
                </tr>
                <tr class="table-content">
                    <td class="table-title" >
                        参数值：
                    </td>
                    <td>
                        <asp:TextBox ID="txtValue" runat="server" Width="439px"></asp:TextBox>
                    </td>
                </tr>
                <tr class="table-content">
                    <td class="table-title">
                        参数描述：
                    </td>
                    <td >
                        <asp:TextBox ID="txtDescription" runat="server" Width="437px" ></asp:TextBox>
                    </td>
                    
                </tr>
                <tr class="table-content">
                    <td class="table-title">
                        是否有效：
                    </td>
                    <td >
                        <asp:RadioButtonList ID="rblState" runat="server" RepeatColumns="2">
                            <asp:ListItem >无效</asp:ListItem>
                            <asp:ListItem Selected="True">有效</asp:ListItem>
                        </asp:RadioButtonList>
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
    </div>
    </form>
</body>
</html>
