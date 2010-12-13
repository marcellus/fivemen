<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DictTypeEdit.aspx.cs" Inherits="CommonPage_DictTypeEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>字典类别编辑</title>
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
                <tr class="poptable-title">
                    <td colspan="2">
                        编号<asp:Label ID="lbId" runat="server"></asp:Label>
                        字典类别详细信息：
                    </td>
                </tr>
                <tr class="table-content">
                    <td class="table-title" >
                        类别名：
                    </td>
                    <td>
                        <asp:TextBox ID="txtTypeName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr class="table-content">
                    <td class="table-title">
                        类别描述：
                    </td>
                    <td >
                        <asp:TextBox ID="txtDescription" runat="server" ></asp:TextBox>
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
