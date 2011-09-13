<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Theme="DefaultTheme" Inherits="index" %>

<%@ Register Assembly="ACE.Common.Web.UI" Namespace="ACE.Common.Web.UI" TagPrefix="ace" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<script language="javascript">
    function Clear() {
        document.getElementById("txt_UserName").value = "";
        document.getElementById("txt_Pwd").value = "";
        return false;
    }
</script>
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width: 20%; height: 25px">
                </td>
                <td style="width: 20%">
                </td>
                <td align="center" style="width: 20%">
                </td>
                <td style="width: 20%">
                </td>
                <td style="width: 20%">
                </td>
            </tr>
            <tr>
                <td style="width: 20%" >
                    &nbsp;</td>
                <td align="center" colspan="3">
                <img src="Images/logo.gif" alt="dtzImage"/>
                </td>
                <td style="width: 20%" >
                </td>
            </tr>
            <tr>
                <td colspan="5" >
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="width: 10%; height: 25px; hight: 30px;">
                            </td>
                            <td style="width: 10%; height: 25px;">
                            </td>
                            <td style="width: 117px; height: 25px;">
                            </td>
                            <td style="width: 10%; height: 25px;">
                            </td>
                            <td style="width: 10%; height: 25px;">
                            </td>
                            <td style="width: 10%; height: 25px;">
                            </td>
                            <td style="width: 10%; height: 25px;">
                            </td>
                            <td style="width: 10%; height: 25px;">
                            </td>
                            <td style="width: 10%; height: 25px;">
                            </td>
                            <td style="width: 10%; height: 25px;">
                            </td>
                        </tr>
                        <tr align="center">
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 117px">
                            </td>
                            <td colspan="4">
                                <ace:LabelEx ID="LabelEx4" runat="server" CssClass="Label" Font-Bold="True" Font-Names="Arial"
                                    Font-Size="Large" ForeColor="Red">Product online management system</ace:LabelEx>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 25px">
                            </td>
                            <td style="height: 25px">
                            </td>
                            <td style="width: 117px; height: 25px">
                            </td>
                            <td style="height: 25px">
                            </td>
                            <td style="height: 25px">
                            </td>
                            <td style="height: 25px">
                            </td>
                            <td style="height: 25px">
                            </td>
                            <td style="height: 25px">
                            </td>
                            <td style="height: 25px">
                            </td>
                            <td style="height: 25px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 117px">
                            </td>
                            <td>
                            </td>
                            <td colspan="2">
                                <ace:LabelEx ID="lbl_ErrorMessage" runat="server" CssClass="Label" ForeColor="Red"></ace:LabelEx></td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 117px">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 117px">
                            </td>
                            <td>
                            </td>
                            <td>
                                <ace:labelex id="LabelEx1" runat="server" cssclass="Label" font-bold="True">User Name:</ace:labelex>
                            </td>
                            <td>
                                <ace:TextBoxEx ID="txt_UserName" runat="server"></ace:TextBoxEx></td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 117px">
                            </td>
                            <td>
                            </td>
                            <td>
                                <ace:labelex id="LabelEx2" runat="server" cssclass="Label" font-bold="True">Password:</ace:labelex>
                            </td>
                            <td>
                                <ace:textboxex id="txt_Pwd" runat="server" TextMode="Password"></ace:textboxex>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 117px">
                            </td>
                            <td>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 50px">
                            </td>
                            <td>
                            </td>
                            <td style="width: 117px">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width: 117px">
                            </td>
                            <td>
                            </td>
                            <td align="center">
                                <ace:buttonex id="btn_OK" runat="server" text="Login" OnClick="btn_OK_Click"></ace:buttonex>
                            </td>
                            <td align="center">
                                <ace:buttonex id="btn_Cancel" runat="server" text="Clear" onClientClick="javascript:return Clear();"></ace:buttonex>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
