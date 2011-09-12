<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Theme="DefaultTheme"
    CodeFile="BulkStorage.aspx.cs" Inherits="Storage_BulkStorage" %>
<%@ Register Assembly="ACE.Common.Web.UI" Namespace="ACE.Common.Web.UI" TagPrefix="ace" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="Server">
<script  type="text/javascript">
    function Product_OpenNormal(strUrl, windowName) {
        var vTmd = Math.random();
        //获得窗口的垂直位置
        var iTop = (window.screen.availHeight - 30 - 600) / 2;
        //获得窗口的水平位置
        var iLeft = (window.screen.availWidth - 10 - 830) / 2;
        window.open(strUrl, windowName, 'height=600px,width=830px,status=no,toolbar=no,menubar=no,top=' + iTop + ',left=' + iLeft + ',location=no,scrollbars=yes,resizable=no');

        //return window.showModalDialog(strUrl,windowName,'dialogWidth=830px;dialogHeight=600px;center:1;help:0;status:0;resizable:0');
    }

    function HaveSelect() {
        var o = document.getElementsByTagName("input");
        for (i = 0; i < o.length; i++) {
            if (o[i].name.indexOf('dgProduct_cbSelect') > -1) {
                if (o[i].checked) {
                    return true;
                }
            }
        }
        return false;
    }
    function DeleteConfirm() {
        var re = window.confirm("确定要删除此商品吗 ?");
        if (re) {
            return true;
        }
        else {
            return false;
        }
    }
    function DeleteCheck() {
        if (HaveSelect()) {
            DeleteConfirm();
        }
        else {
            alert("You do not select any record!");
            return false;
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0">
        <tr>
            <td align="left">
                <b><font size="4" color="gray">
                    <asp:Label ID="lbl_BuildingProfile" runat="server" Text="批量入库" Font-Size="Large"></asp:Label></font></b>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="height: 23px; width: 12%" align="right">
                <ace:LabelEx ID="LabelEx1" runat="server" CssClass="Label">入库单号:</ace:LabelEx>
            </td>
            <td style="height: 23px; width: 15%">
               
           
                 <ace:DropDownListEx ID="ddl_StoNo" runat="server" Width="180px" DataTextField="StorageNo" AutoPostBack="true"
                    DataValueField="StorageNo" OnSelectedIndexChanged="ddl_StoNo_SelectedIndexChanged">
                </ace:DropDownListEx>
            </td>
           
            <td style="height: 23px; width: 10%" align="right">
                <ace:LabelEx ID="LabelEx3" runat="server" CssClass="Label">选择文件:</ace:LabelEx>
            </td>
            <td style="height: 23px; width: 35%">
                <asp:FileUpload ID="FileUpload1" runat="server"  />
                <ace:ButtonEx ID="btn_Import" runat="server" CssClass="ButtonFlat" DialogHeight="200px" 
                    DialogWidth="400px" LeftSpace="0" RightSpace="0" ShowConfirmMsg="False" ShowWaitingPanel="False"
                    Text="导 入" Width="70px" OnClick="btn_Import_Click" />
            </td>
            <td style="height: 23px;">
            </td>
        </tr>
    </table>
    <ajax:AjaxPanel ID="ajaxPan1" runat="server" Width="100%" >
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <ace:ButtonEx ID="btn_Delete" runat="server" CssClass="ButtonFlat" DialogHeight="200px"
                    DialogWidth="400px" LeftSpace="0" RightSpace="0" ShowConfirmMsg="False" ShowWaitingPanel="False" onClientClick="javascript:return DeleteCheck();"
                    Text="删 除" Width="70px" OnClick="btn_Delete_Click" />
            </td>
        </tr>
    </table>
    <table width="100%" border="0" >
        <tr>
            <td>
                <ace:DataGridEx ID="dgProduct" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" PageSize="20" OnBuildDataSource="dgProduct_BuildDataSource"
                    ShowFooter="True" Width="100%" AllowExport="False" DownloadFileName="" CssClass="Grid"
                    HighLight="False" HighLightCssClass="DataGridHighLight" SQLString="" PageCountEx="1"
                    CurrentPageIndexEx="0" MAXRowCount="500">
                    <Columns>
                        <ace:CheckBoxColumn DataField="Product_ID">
                            <HeaderStyle Width="8px" />
                            <ItemStyle Width="8px" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                Font-Strikeout="False" Font-Underline="False" />
                        </ace:CheckBoxColumn>
                        <ace:MultiQueryStringColumn WinType="Normal" DataTextField="Product_Name" HeaderText="品名"
                            SortExpression="Product_Name" DataNavigateUrlField="Product_ID" DataNavigateUrlFormatString="javascript:Product_OpenNormal('../Product_Profile.aspx?PROID={0}&flag=Edit','Product');"
                            PopupWin="False" WinHeight="700px"  CharCount="0" NavigateUrl=""
                            Text="">
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </ace:MultiQueryStringColumn>
                        <asp:BoundColumn DataField="Barcode" HeaderText="条码">
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Factory_Weight" HeaderText="工厂货重">
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Gold_NetWeight" HeaderText="净金重" >
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ShouCun" HeaderText="手寸">
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Style" HeaderText="款号">
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Factory_Name" HeaderText="供货商" >
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descriptions" HeaderText="描述">
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                    <ItemStyle CssClass="ItemStyle" />
                    <AlternatingItemStyle CssClass="AlternatingItemStyle" />
                    <FooterStyle CssClass="GridFoot" />
                </ace:DataGridEx>
            </td>
        </tr>
    </table>
    </ajax:AjaxPanel>
</asp:Content>
