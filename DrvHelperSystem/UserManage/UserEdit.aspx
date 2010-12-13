<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserEdit.aspx.cs" Inherits="UserManage_UserEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户详细</title>
      <meta content="no-cache" http-equiv="pragma">
    <meta content="no-cache,must-revalidate" http-equiv="Cache-Control">
     <link href="../css/main.css" rel="Stylesheet" type="text/css" />
    <base target="_self"></base>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table class="table-border" border="0" cellspacing="1" cellpadding="4" >
            <tr  class="poptable-title">
                <td  colspan="4">
                    编号<asp:Label ID="lbId" runat="server"></asp:Label>
                    用户详细信息：</td>
            </tr>
            <tr class="table-content">
                <td style="width:120px" class="table-title">
                    登陆名：</td>
                <td  colspan="3" style="">
                    
                    <asp:TextBox ID="txtUserLoginName" runat="server" Width="124px"></asp:TextBox>
                </td>
                
            </tr>
            <tr  class="table-content">
                <td  class="table-title">
                    用户全名：</td>
                <td style="width:260px">
                    <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                </td>
                <td  class="table-title">
                    角色：</td>
                <td >
                    <asp:DropDownList ID="cbRoleIdValue" runat="server" Height="16px" Width="180px" 
                        Font-Size="15pt">
                    </asp:DropDownList>
                </td>
               
            </tr>
            <tr  class="table-content">
             <td style="" class="table-title">
                    部门：</td>
                <td style="">
                    <asp:DropDownList ID="cbDepIdValue" runat="server" Height="16px" Width="200px" 
                        Font-Size="15pt">
                    </asp:DropDownList>
                </td>
                <td class="table-title">
                   身份证明号码：</td>
                <td >
                    <asp:TextBox ID="txtIdCard" runat="server"></asp:TextBox>
                </td>
                
            </tr>
            <tr  class="table-content">
            <td class="table-title">
                    工号：</td>
                <td >
                    <asp:TextBox ID="txtWorkId" runat="server"></asp:TextBox>
                </td>
                <td class="table-title">
                   状态：</td>
                <td>
                    <asp:RadioButtonList ID="rblState" runat="server" RepeatColumns="2">
                        <asp:ListItem Selected="True">有效</asp:ListItem>
                        <asp:ListItem>无效</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                
            </tr>
            <tr class="table-content">
            <td class="table-title">
                    IP起始地址：</td>
                <td style="width:300px">
                    <asp:TextBox ID="txtBeginIp1" runat="server" Width="26px"></asp:TextBox>
                    .<asp:TextBox ID="txtBeginIp2" runat="server" Width="26px"></asp:TextBox>
                    .<asp:TextBox ID="txtBeginIp3" runat="server" Width="26px"></asp:TextBox>
                    .<asp:TextBox ID="txtBeginIp4" runat="server" Width="26px"></asp:TextBox>
                </td>
                <td class="table-title">
                   IP结束地址：</td>
                <td >
                    <asp:TextBox ID="txtEndIp1" runat="server" Width="26px"></asp:TextBox>
                    .<asp:TextBox ID="txtEndIp2" runat="server" Width="26px"></asp:TextBox>
                    .<asp:TextBox ID="txtEndIp3" runat="server" Width="26px"></asp:TextBox>
                    .<asp:TextBox ID="txtEndIp4" runat="server" Width="26px"></asp:TextBox>
                </td>
                
            </tr>
           
           
            <tr  class="table-content">
                <td class="table-content" colspan="4" style="text-align: center">
                    <asp:Button ID="btnSure" runat="server" Text="确定" onclick="btnSure_Click" 
                        />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                         <input id="Button2" class="button"  type="button" value="关闭" onclick="javascript:window.opener=null;window.close();" />
                    </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
