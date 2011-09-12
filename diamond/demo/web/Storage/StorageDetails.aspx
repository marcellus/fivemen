<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StorageDetails.aspx.cs" Inherits="Storage_StorageDetails" Theme="DefaultTheme" %>

<%@ Register Assembly="ACE.Common.Web.UI" Namespace="ACE.Common.Web.UI" TagPrefix="ace" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>入库单信息</title>
    <style type="text/css">
        .DLabel
        {
            text-align: right;
            font-weight: bold;
            font-size: small;
            float: left;
        }
        .DText
        {
            text-align: right;
            margin-left: 6px;
            font-size: small;
            float: left;
        }
        .DButton
        {
            float: right;
            margin-left: 10px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function ConfirmCancel() {
            var re = window.confirm("是否关闭当前页面？");
            if (re) {
                window.opener = null; window.close();
            }
            else {
                return false;
            }
        }
    
    
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="width: 100%">
            <div class="DLabel">
                入库单号:
            </div>
            <div class="DText">
                <asp:TextBox ID="txt_SNo" runat="server"></asp:TextBox>
            </div>
            <div class="DLabel">
                生成日期:
            </div>
            <div class="DText">
                <asp:TextBox ID="txt_Date" runat="server" ReadOnly="true" BorderStyle="None"></asp:TextBox>
            </div>
        </div>
        <div style="margin-top: 8px">
            <div class="DLabel">
                描述:
            </div>
            <div class="DText">
                <asp:TextBox ID="txt_Description" runat="server" TextMode="MultiLine" Width="99%" Height="80px"></asp:TextBox>
            </div>
        </div>
    </div>
    <div style="clear: left;">
    </div>
    <div style="width: 100%">
        <div class="DButton" id="dvClose">
            <ace:ButtonEx ID="btn_Close" runat="server" DialogHeight="400px" DialogWidth="400px"
                LeftSpace="0" RightSpace="0" ShowConfirmMsg="False" ShowWaitingPanel="False" onClientClick="javascript:ConfirmCancel()"
                Text="关 闭" Width="70px" />
        </div>
        <div class="DButton" id="dvSave">
            <ace:ButtonEx ID="btn_Save" runat="server" DialogHeight="400px" DialogWidth="400px"
                LeftSpace="0" RightSpace="0" ShowConfirmMsg="False" ShowWaitingPanel="False"
                Text="保 存" Width="70px" onclick="btn_Save_Click" />
        </div>
    </div>
    </form>
</body>
</html>
