<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="StorageListMange.aspx.cs" Inherits="Storage_StorageListMange" Theme="DefaultTheme" %>

<%@ Register Assembly="ACE.Common.Web.UI" Namespace="ACE.Common.Web.UI" TagPrefix="ace" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register Src="../Controls/DateSelectorEX.ascx" TagName="DateSelectorEX" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="JavaScript" type="text/javascript" src="../Js/calendar.js"></script>

    <script language="javascript" type="text/javascript" src="../Js/common.js"></script>

    <script language="JavaScript" type="text/javascript" src="../Js/calendar-en.js"></script>

    <script language="JavaScript" type="text/javascript" src="../Js/calendar-setup.js"></script>

    <script language="javascript" type="text/javascript" src="../Controls/cal/popcalendar_en.js"></script>

    <script language="javascript" type="text/javascript">

        function CheckSearch() {
            if (document.getElementById(local + "ddl_OrderName").value.trim() == "" && document.getElementById(local + "txt_Barcode").value.trim() == "") {
                alert("Please input either Order name or Barcode as searching criteria.");
                return false;
            }
            else {
                return true;
            }
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
            var re = window.confirm("确定要删除此入库单吗 ?");
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
                alert("您没有选择任何记录");
                return false;
            }
        }
        function ResetSearch() {
            debugger;
            document.getElementById(local + "ddl_Type0").value = "";
            document.getElementById(local + "ddl_Type").value = "";
            document.getElementById(local + "ddl_OrderName").value = "";
            document.getElementById(local + "txt_ProductName").value = "";
            document.getElementById(local + "txt_Barcode").value = "";
            return false;
        }
        function Open_AddWindow() {
            //获得窗口的垂直位置
            var iTop = (window.screen.availHeight - 30 - 600) / 2;
            //获得窗口的水平位置
            var iLeft = (window.screen.availWidth - 10 - 830) / 2;
            window.open('StorageDetails.aspx?type=new&rnd=' + Math.random(), '入库单', 'height=300px,width=530px,status=no,toolbar=no,menubar=no,top=' + iTop + ',left=' + iLeft + ',location=no,scrollbars=yes,resizable=no');
            return false;

            //return window.showModalDialog('Product_Profile.aspx?PROID=0&flag=Add','Product','dialogWidth=830px;dialogHeight=600px;center:1;help:0;status:0;resizable:0');
        }
        function Open_Normal(strUrl, windowName) {
            var vTmd = Math.random();
            //获得窗口的垂直位置
            var iTop = (window.screen.availHeight - 30 - 200) / 2;
            //获得窗口的水平位置
            var iLeft = (window.screen.availWidth - 10 - 520) / 2;
            window.open(strUrl + '&rnd=' + Math.random(), windowName, 'height=200px,width=520px,status=no,toolbar=no,menubar=no,top=' + iTop + ',left=' + iLeft + ',location=no,scrollbars=yes,resizable=no');

            //return window.showModalDialog(strUrl,windowName,'dialogWidth=830px;dialogHeight=600px;center:1;help:0;status:0;resizable:0');
        }
    </script>

    <ajax:AjaxPanel ID="ajaxPan1" runat="server" Width="100%">
        <table onkeydown="DoSearch()" width="100%">
            <tr>
                <td>
                    <table  width="100%" border="0">
                        <tr >
                            <td align="left">
                                <b><font color="gray" size="4">
                                    <asp:Label ID="lbl_BuildingProfile" runat="server" Font-Size="Large" Text="入库单管理"></asp:Label>
                                </font></b>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 23px; width: 12%">
                                <ace:LabelEx ID="LabelEx1" runat="server" CssClass="Label">入库单号:</ace:LabelEx>
                            </td>
                            <td style="height: 23px; width: 15%">
                                <ace:TextBoxEx ID="txt_StoNo" runat="server"></ace:TextBoxEx>
                            </td>
                            <%--</ajax:AjaxPanel>--%>
                            <td align="right" style="height: 23px; width: 10%">
                                <ace:LabelEx ID="LabelEx3" runat="server" CssClass="Label">起始时间:</ace:LabelEx>
                            </td>
                            <td style="height: 23px; width: 15%; margin-top:5px;">
                                <uc:DateSelectorEX ID="txt_startDate" runat="server"  />
                            </td>
                            <td align="right" style="height: 23px; width: 12%">
                                <ace:LabelEx ID="LabelEx5" runat="server" CssClass="Label">截止时间:</ace:LabelEx>
                            </td>
                            <td style="height: 23px;margin-top:5px;">
                                <uc:DateSelectorEX ID="txt_endDate" runat="server" />
                            </td>
                            <%--<input type="button" id="hiddenButton" runat="server" style="width: 83px" onclick="hiddenButton_Click"/>--%>
                            <td>
                                <ace:ButtonEx ID="btn_Search" runat="server" CssClass="ButtonFlat" DialogHeight="400px"
                                    DialogWidth="600px" LeftSpace="0" OnClick="btn_Search_Click" RightSpace="0" ShowConfirmMsg="False"
                                    ShowWaitingPanel="False" Text="查询" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <%--</ajax:AjaxPanel>--%>
                </td>
            </tr>
            <tr>
                <td class="NCLabelSmall">
                    <table border="0" cellpadding="1" cellspacing="0" width="100%">
                        <tr>
                            <td style="white-space: nowrap">
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <ace:ButtonEx ID="btn_Add" runat="server" CssClass="ButtonFlat" DialogHeight="400px"
                                    DialogWidth="400px" LeftSpace="0" onClientClick="javascript:return Open_AddWindow();"
                                    RightSpace="0" ShowConfirmMsg="False" ShowWaitingPanel="False" Text="新增" Width="70px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <ace:ButtonEx ID="btn_Delete" runat="server" CssClass="ButtonFlat" DialogHeight="400px"
                                    DialogWidth="400px" LeftSpace="0" OnClick="btn_Delete_Click" onClientClick="javascript:return DeleteCheck();"
                                    RightSpace="0" ShowConfirmMsg="False" ShowWaitingPanel="False" Text="删除" Width="70px" />
                            </td>
                            <td align="left" style="width: 100%; display: none;">
                                <asp:Button ID="hiddenButton" runat="server" />
                                <ace:ButtonEx ID="btn_Reset" runat="server" onClientClick="javascript:return ResetSearch();"
                                    Text="重置" Visible="False" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <ace:DataGridEx ID="dgProduct" runat="server" AllowExport="False" AllowPaging="True"
                                    AllowSorting="True" AutoGenerateColumns="False" CssClass="Grid" CurrentPageIndexEx="0"
                                    DownloadFileName="" HighLight="False" HighLightCssClass="DataGridHighLight" MAXRowCount="500"
                                    OnBuildDataSource="dgProduct_BuildDataSource" OnItemDataBound="dgProduct_ItemDataBound"
                                    OnSortCommand="dgProduct_SortCommand" PageCountEx="1" PageSize="20" ShowFooter="True"
                                    SQLString="" Width="100%">
                                    <Columns>
                                        <ace:CheckBoxColumn DataField="StorageNo">
                                            <HeaderStyle Width="8px" HorizontalAlign="Center" />
                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                Font-Underline="False" Width="8px"  HorizontalAlign="Center"/>
                                        </ace:CheckBoxColumn>
                                        <ace:MultiQueryStringColumn CharCount="0" DataNavigateUrlField="StorageNo" DataNavigateUrlFormatString="javascript:Open_Normal('StorageDetails.aspx?type=edit&amp;sid={0}','入库单');"
                                            DataTextField="StorageNo" HeaderText="入库单号" NavigateUrl="" PopupWin="False" Text=""
                                            WinHeight="700px" WinType="Normal" WinWidth="1050px">
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </ace:MultiQueryStringColumn>
                                        <asp:BoundColumn DataField="GenerationTime" HeaderText="生成时间" DataFormatString="{0:yyyy-MM-dd}"
                                            SortExpression="GenerationTime">
                                            <ItemStyle HorizontalAlign="Center" Width="12%" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="StorageDescription" HeaderText="描述">
                                            <ItemStyle HorizontalAlign="Left" Width="69%" />
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
                </td>
            </tr>
        </table>
    </ajax:AjaxPanel>
</asp:Content>
