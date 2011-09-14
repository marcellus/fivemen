<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StoreSalesReport.aspx.cs" Inherits="report_StoreSalesReport"  Theme="DefaultTheme"  %>
<%@ Register Assembly="ACE.Common.Web.UI" Namespace="ACE.Common.Web.UI" TagPrefix="ace" %>
<%@ Register Src="../Controls/DateSelectorEX.ascx" TagName="DateSelectorEX" TagPrefix="uc" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" Runat="Server">
<script language="javascript" type="text/javascript">
    function OpenSubtypeSelector() {
            var height = 400;
            var width = 660;
            var vTmd = Math.random();
            var typeid = document.getElementById("ctl00_ContentPlaceHolder1_ddl_Type").value;
            var sReturn = window.showModalDialog('SubTypeSelector.aspx?typeid=' + typeid + '&tmd=' + vTmd, 'dialog', "dialogwidth:" + width + "px;dialogheight:" + height + "px;center:1;help:0;status:0;");
            if (typeof (sReturn) != "undefined" && sReturn != "") {
                var arrTmp = sReturn.replace(/[%]/g, '"').split('|');
                document.getElementById("ctl00_ContentPlaceHolder1_hiddenforsmtypeid").value = arrTmp[1];
                document.getElementById("ctl00_ContentPlaceHolder1_txt_SubTypeName").value = arrTmp[0];
                return false;
            }
            return false;
        }
    //清除字符串前后的空字串
    String.prototype.trim = function(){
	    return this.replace(/^[\s]+|[\s]+$/, "");
    };
    var local = "ctl00_ContentPlaceHolder1_";
   </script>
    <script language="JavaScript" type="text/javascript" src="../Js/calendar.js"></script>
    <script language="javascript" type="text/javascript" src="../Js/common.js"></script>
    <script language="JavaScript" type="text/javascript" src="../Js/calendar-en.js"></script>
    <script language="JavaScript" type="text/javascript" src="../Js/calendar-setup.js"></script>
    <script language="javascript" type="text/javascript" src="../Controls/cal/popcalendar_en.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%-- <ajax:AjaxPanel ID="ajaxPan1" runat="server" Width="100%" >--%>
<table width="100%" border="0" onkeydown="DoSearch()">
         <tr>
                            <td align="left">
                                <b><font size="4" color="gray">
                                    <asp:Label ID="lbl_BuildingProfile" runat="server"
                                        Text="门店销售记录查询" Font-Size="Large"></asp:Label></font></b>
                            </td>
                        </tr>
        <tr>
            <td>
                <%--</ajax:AjaxPanel>--%>
                <table border="0" cellpadding="0" cellspacing="1" class="bgColorBorder1" style="width: 100%">
        <tr>
            <caption>
                <br />
            </caption>
        </tr>
        <tr>
            <td align="right" style="height: 23px; width:12%">
                 <ace:LabelEx ID="LabelEx1" runat="server" CssClass="Label">门店:</ace:LabelEx>
             </td>
             <td style="height: 23px; width:15%">
                    <ace:DropDownListEx ID="ddl_Shop" runat="server" Width="180px" 
                        DataTextField="Name" AutoPostBack="true"
                    DataValueField="id" 
                        onselectedindexchanged="ddl_Shop_SelectedIndexChanged">
                </ace:DropDownListEx>
             </td>
             <%--</ajax:AjaxPanel>--%>
             <td align="right" style="height: 23px; width:10%">
                 <ace:LabelEx ID="LabelEx3" runat="server" CssClass="Label">起始时间:</ace:LabelEx>
             </td>
             <td style="height: 23px; width:15%;margin-top:5px;">
                <uc:DateSelectorEX ID="txt_startDate" runat="server"  />
             </td>
             <td align="right" style="height: 23px; width:12%">
                 <ace:LabelEx ID="LabelEx5" runat="server" CssClass="Label">截止时间:</ace:LabelEx>
             </td>
             <td style="height: 23px; margin-top:5px;">
              <uc:DateSelectorEX ID="txt_endDate" runat="server" />
             </td>
             <%--<input type="button" id="hiddenButton" runat="server" style="width: 83px" onclick="hiddenButton_Click"/>--%>
            
                 <td>
                 <ace:ButtonEx ID="ButtonEx1" runat="server" CssClass="ButtonFlat" 
                             DialogHeight="400px" DialogWidth="600px" LeftSpace="0" 
                              RightSpace="0" ShowConfirmMsg="False" 
                             ShowWaitingPanel="False" Text="查询" Width="70px" 
                         onclick="ButtonEx1_Click" />
                         &nbsp;&nbsp;
                         <ace:ButtonEx ID="btn_Export" runat="server" Text="导出"
                                Width="70px" CssClass="ButtonFlat" 
                                DialogHeight="400px" 
                                DialogWidth="600px" LeftSpace="0" RightSpace="0"
                                ShowConfirmMsg="False" ShowWaitingPanel="False" 
                                onclick="btn_Export_Click" />
                 
                 </td>
           
        </tr>
    </table>
    <%--</ajax:AjaxPanel>--%>
            </td>
        </tr>
        <tr>
            <td class="NCLabelSmall">
                <table width="100%" border="0" cellspacing="0" cellpadding="1">
                    <tr>
                        <td style="white-space: nowrap">
                            
                            &nbsp;&nbsp;&nbsp;&nbsp;
                          
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <ace:DataGridEx ID="dgProduct" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" PageSize="20" OnBuildDataSource="dgProduct_BuildDataSource"
                                ShowFooter="True"  Width="100%" AllowExport="False"
                                DownloadFileName="" CssClass="Grid" HighLight="False" HighLightCssClass="DataGridHighLight"
                                SQLString="" OnItemDataBound="dgProduct_ItemDataBound"
                                PageCountEx="1" CurrentPageIndexEx="0" MAXRowCount="500">
                                <Columns>
                                   
                                    <ace:MultiQueryStringColumn WinType="Normal" DataTextField="Product_Name" HeaderText="品名"
                                        SortExpression="Product_Name" DataNavigateUrlField="Product_ID"
                                        DataNavigateUrlFormatString="javascript:Product_OpenNormal('Product_Profile.aspx?PROID={0}&flag=Edit','Product');"
                                        PopupWin="False" WinHeight="700px" WinWidth="1050px" CharCount="0" NavigateUrl=""
                                        Text="">
                                        <ItemStyle HorizontalAlign="Left" Width="13%" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </ace:MultiQueryStringColumn>
                                    <asp:boundcolumn DataField="Barcode" HeaderText="条码" SortExpression="Barcode">
                                        <itemstyle horizontalalign="Left" width="12%" />
                                        <headerstyle horizontalalign="Center" />
                                    </asp:boundcolumn>
                                    <asp:boundcolumn DataField="SalePrice" HeaderText="售价" SortExpression="SalePrice">
                                        <itemstyle horizontalalign="Right" width="8%" />
                                        <headerstyle horizontalalign="Center" />
                                    </asp:boundcolumn>
                                    <asp:boundcolumn DataField="Discount" HeaderText="折扣" SortExpression="Discount">
                                        <itemstyle horizontalalign="Right" width="8%" />
                                        <headerstyle horizontalalign="Center" />
                                    </asp:boundcolumn>
                                    <asp:boundcolumn DataField="SaleLsh" HeaderText="销售流水号" SortExpression="SaleLsh">
                                        <itemstyle horizontalalign="Center" width="15%" />
                                        <headerstyle horizontalalign="Center" />
                                    </asp:boundcolumn>
                                    <asp:boundcolumn DataField="Sales" HeaderText="售货员" SortExpression="Sales">
                                        <itemstyle horizontalalign="Left" width="6%" />
                                        <headerstyle horizontalalign="Center" />
                                    </asp:boundcolumn>
                                    <asp:boundcolumn DataField="CustomerName" HeaderText="顾客" SortExpression="CustomerName">
                                        <itemstyle horizontalalign="Left" width="8%" />
                                        <headerstyle horizontalalign="Center" />
                                    </asp:boundcolumn>
                                    <asp:boundcolumn DataField="CustomerPhone" HeaderText="顾客电话" SortExpression="CustomerPhone">
                                        <itemstyle horizontalalign="Right" width="8%" />
                                        <headerstyle horizontalalign="Center" />
                                    </asp:boundcolumn>
                                    <asp:boundcolumn DataField="TrueMoney" HeaderText="实际支付金额" SortExpression="TrueMoney">
                                        <itemstyle horizontalalign="Right" width="13%" />
                                        <headerstyle horizontalalign="Center" />
                                    </asp:boundcolumn>
                                    <asp:boundcolumn DataField="SaleTime" HeaderText="销售时间" SortExpression="SaleTime">
                                        <itemstyle horizontalalign="Right" width="18%" />
                                        <headerstyle horizontalalign="Center" />
                                    </asp:boundcolumn>
                                   
                                </Columns>
                                <ItemStyle CssClass="ItemStyle" />
                                <AlternatingItemStyle CssClass="AlternatingItemStyle" />
                                <FooterStyle CssClass="GridFoot" />
                            </ace:DataGridEx></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
<%-- </ajax:AjaxPanel>--%>
</asp:Content>

