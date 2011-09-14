<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    Theme="DefaultTheme" CodeFile="ComfirmStorage.aspx.cs" Inherits="Storage_ComfirmStorage" %>

<%@ Register Assembly="ACE.Common.Web.UI" Namespace="ACE.Common.Web.UI" TagPrefix="ace" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="Server">

    <script type="text/javascript">
        function Product_OpenNormal(strUrl, windowName) {
            var vTmd = Math.random();
            //获得窗口的垂直位置
            var iTop = (window.screen.availHeight - 30 - 600) / 2;
            //获得窗口的水平位置
            var iLeft = (window.screen.availWidth - 10 - 830) / 2;
            window.open(strUrl, windowName, 'height=600px,width=830px,status=no,toolbar=no,menubar=no,top=' + iTop + ',left=' + iLeft + ',location=no,scrollbars=yes,resizable=no');

            //return window.showModalDialog(strUrl,windowName,'dialogWidth=830px;dialogHeight=600px;center:1;help:0;status:0;resizable:0');
        }
        function Product_OpenSmall(strUrl, windowName) {
            var vTmd = Math.random();
            //获得窗口的垂直位置
            var iTop = (window.screen.availHeight - 30 - 600) / 2;
            //获得窗口的水平位置
            var iLeft = (window.screen.availWidth - 10 - 830) / 2;
            window.open(strUrl, windowName, 'height=100px,width=230px,status=no,toolbar=no,menubar=no,top=' + iTop + ',left=' + iLeft + ',location=no,scrollbars=yes,resizable=no');

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
        function checkBacode() {

            if (document.getElementById('txt_BarCode').Text != null) {
                return true;

            }
            else {
                alert("请先输入条码!");
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
                    <asp:Label ID="lbl_BuildingProfile" runat="server" Text="入库确认" Font-Size="Large"></asp:Label></font></b>
            </td>
        </tr>
    </table>
    <ajax:AjaxPanel ID="ajaxPan1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" class="NCLabelSmall">
            <tr>
                <td>
                    <ace:LabelEx ID="LabelEx3" runat="server" CssClass="Label">
                                               入库单：</ace:LabelEx>
                </td>
                <td style="color: #FF0000" width="225">
                    <ace:DropDownListEx ID="ddl_StoNo" runat="server" Width="200px" DataTextField="StorageNo"
                        DataValueField="StorageNo" AutoPostBack="True" OnSelectedIndexChanged="ddl_StoNo_SelectedIndexChanged">
                    </ace:DropDownListEx>
                </td>
            </tr>
            <tr>
                <td>
                    <ace:LabelEx ID="LabelEx1" runat="server" CssClass="Label">
                                                条码：</ace:LabelEx>
                </td>
                <td style="color: #FF0000" width="225">
                    <ace:TextBoxEx ID="txt_BarCode" runat="server" Width="200px" MaxLength="100"></ace:TextBoxEx>
                    <ace:LabelEx ID="lbl_Star2" runat="server" CssClass="Label" ForeColor="#CC0000">*</ace:LabelEx>
                </td>
                <td>
                    <div style="float: left;">
                        <ace:ButtonEx ID="btn_Submit" runat="server" CssClass="ButtonFlat" Text=" 确 认" Width="100px"
                            RightSpace="2" OnClick="btn_Submit_Click" /></div>
                    <span style="color: Red; ">(*表格中红色记录代表未确认入库的产品,双击某行添加复秤数据)</span>
                    <ace:ButtonEx ID="btn_Delete" runat="server" CssClass="ButtonFlat" DialogHeight="200px"
                        DialogWidth="400px" LeftSpace="0" RightSpace="0" ShowConfirmMsg="False" ShowWaitingPanel="False"
                        onClientClick="javascript:return DeleteCheck();" Text="删 除" Width="70px" OnClick="btn_Delete_Click" />
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    
                </td>
            </tr>
        </table>
        <table width="100%" border="0">
            <tr>
                <td>
                    <ace:DataGridEx ID="dgProduct" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" PageSize="20" OnBuildDataSource="dgProduct_BuildDataSource"
                        ShowFooter="True" Width="100%" AllowExport="False" DownloadFileName="" CssClass="Grid"
                        HighLight="False" HighLightCssClass="DataGridHighLight" SQLString="" PageCountEx="1"
                        CurrentPageIndexEx="0" MAXRowCount="500" OnItemDataBound="dgProduct_ItemDataBound">
                        <Columns>
                            <ace:CheckBoxColumn DataField="Product_ID">
                                <HeaderStyle Width="8px" />
                                <ItemStyle Width="8px" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                    Font-Strikeout="False" Font-Underline="False" />
                            </ace:CheckBoxColumn>
                            <ace:MultiQueryStringColumn WinType="Normal" DataTextField="Product_Name" HeaderText="品名"
                                SortExpression="Product_Name" DataNavigateUrlField="Product_ID" DataNavigateUrlFormatString="javascript:Product_OpenNormal('../Product_Profile.aspx?PROID={0}&flag=Edit','Product');"
                                PopupWin="False" WinHeight="700px" CharCount="0" NavigateUrl="" Text="">
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
                            <asp:BoundColumn DataField="Gold_NetWeight" HeaderText="净金重">
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
                            <asp:BoundColumn DataField="Factory_Name" HeaderText="供货商">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="StorageNo" HeaderText="入库单号">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ComfirmWeight" HeaderText="复秤">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Descriptions" HeaderText="描述">
                                <ItemStyle HorizontalAlign="Left" Width="25%" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ProductStatus" HeaderText="状态" Visible="false"></asp:BoundColumn>
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
