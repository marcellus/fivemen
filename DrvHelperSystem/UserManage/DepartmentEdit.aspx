<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepartmentEdit.aspx.cs" Inherits="UserManage_DepartmentEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>部门详细信息</title>
      <meta content="no-cache" http-equiv="pragma">
    <meta content="no-cache,must-revalidate" http-equiv="Cache-Control">
    <link href="../css/main.css" rel="Stylesheet" type="text/css" />
    <base target="_self"></base>
    <style type="text/css">
        .style2
        {
            width: 50px;
            height: 23px;
        }
        .style5
        {
            width: 50px;
            height: 21px;
        }
        .style7
        {
            width: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table class="table-border" border="0" cellspacing="1" cellpadding="4">
            <tr  class="poptable-title">
                <td  colspan="4">
                    编号<asp:Label ID="lbId" runat="server"></asp:Label>
                    部门详细信息：</td>
            </tr>
            <tr class="table-content">
                <td  class="table-title">
                    部门类别：</td>
                <td  colspan="3" >
                    <asp:DropDownList ID="cbDepType" runat="server" Font-Size="15pt">
                        <asp:ListItem>医院</asp:ListItem>
                        <asp:ListItem>驾校</asp:ListItem>
                    </asp:DropDownList>
                    
                </td>
                
            </tr>
            <tr class="table-content">
                <td  class="table-title">
                    部门全名：</td>
                <td  colspan="3" >
                    
                    <asp:TextBox ID="txtDepFullName" runat="server" Width="458px"></asp:TextBox>
                </td>
                
            </tr>
            <tr  class="table-content">
                <td  class="table-title">
                    部门简称：</td>
                <td style="width: 50px">
                    <asp:TextBox ID="txtDepNickName" runat="server"></asp:TextBox>
                </td>
                <td  class="table-title">
                    部门代码：</td>
                <td style="width: 50px; height: 3px;">
                    <asp:TextBox ID="txtDepCode" runat="server"></asp:TextBox>
                </td>
               
            </tr>
            <tr  class="table-content">
             <td  class="table-title">
                    管理部门代码：</td>
                <td >
                    <asp:TextBox ID="txtParentCode" runat="server"></asp:TextBox>
                </td>
                <td class="table-title">
                   联系人：</td>
                <td class="style2">
                    <asp:TextBox ID="txtConnector" runat="server"></asp:TextBox>
                </td>
                
            </tr>
            <tr  class="table-content">
            <td class="table-title">
                    移动电话：</td>
                <td class="style2">
                    <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                </td>
                <td class="table-title">
                   固定电话：</td>
                <td class="style5">
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
                
            </tr>
            <tr class="table-content"><td class="table-title">
                   机构证书代码：</td>
                <td colspan="3" class="style7">
                    <asp:TextBox ID="txtCompanyCode" runat="server" Width="457px"></asp:TextBox>
                </td></tr>
           
            <tr  class="table-content">
                <td class="table-content" colspan="4" style="text-align: center">
                    <asp:Button ID="btnSure" runat="server" Width="120px" Text="确定" onclick="btnSure_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                         <input id="Button2" class="button"  type="button" value="关闭" onclick="javascript:window.opener=null;window.close();" />
                    </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
