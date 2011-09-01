<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Theme="DefaultTheme" 
CodeFile="Product_List.aspx.cs" Inherits="ProductList" %>

<%@ Register Assembly="ACE.Common.Web.UI" Namespace="ACE.Common.Web.UI" TagPrefix="ace" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
    //����ַ���ǰ��Ŀ��ִ�
    String.prototype.trim = function(){
	    return this.replace(/^[\s]+|[\s]+$/, "");
    };
    var local = "ctl00_ContentPlaceHolder1_";
    function CheckSearch(){
        if(document.getElementById(local+"ddl_OrderName").value.trim() == ""  && document.getElementById(local+"txt_Barcode").value.trim() == ""){
            alert("Please input either Order name or Barcode as searching criteria.");
            return false;
        }
        else{
            return true;
        }
    }

    function DoSearch() {
        if(window.event.keyCode==13)
        {
            document.getElementById(local+"btn_Search").click();
        }
    }
    function  document.onkeydown()      
    {  
       if(window.event.keyCode==13)
        {
          //window.event.returnValue= false;
          document.getElementById(local+"btn_Search").click();
        }
    } 
    function HaveSelect()
    {
        var o=document.getElementsByTagName("input");
        for(i=0;i<o.length;i++)
        {
            if(o[i].name.indexOf('dgProduct_cbSelect')>-1)
            {
                if(o[i].checked)
                {
                    return true;
                }
            }
        }
        return false;
    }
    function DeleteConfirm() {
        var re = window.confirm("ȷ��Ҫɾ������Ʒ�� ?");
        if (re) {
            return true;
        }
        else {
            return false;
        }
    }
    function DeleteCheck()
    {
        if(HaveSelect())
        {
            DeleteConfirm();
        }
        else
        {
            alert("You do not select any record!");
            return false;
        }
    }
    function ResetSearch() {
        debugger;
        document.getElementById(local + "ddl_Type0").value = "";
       document.getElementById(local+"ddl_Type").value="";
       document.getElementById(local + "ddl_OrderName").value = "";
       document.getElementById(local+"txt_ProductName").value="";
       document.getElementById(local+"txt_Barcode").value="";
      return false;
    }
    function Product_OpenNormal(strUrl, windowName) {
        var vTmd=Math.random();
        //��ô��ڵĴ�ֱλ��
        var iTop = (window.screen.availHeight - 30 - 600) / 2;
        //��ô��ڵ�ˮƽλ��
        var iLeft = (window.screen.availWidth - 10 - 830) / 2;
        window.open(strUrl, windowName, 'height=600px,width=830px,status=no,toolbar=no,menubar=no,top=' + iTop + ',left=' + iLeft + ',location=no,scrollbars=yes,resizable=no');
        
        //return window.showModalDialog(strUrl,windowName,'dialogWidth=830px;dialogHeight=600px;center:1;help:0;status:0;resizable:0');
    }
    function Open_AddWindow() {
        //��ô��ڵĴ�ֱλ��
        var iTop = (window.screen.availHeight - 30 - 600) / 2;
        //��ô��ڵ�ˮƽλ��
        var iLeft = (window.screen.availWidth - 10 - 830) / 2;
        window.open('Product_Profile.aspx?PROID=0&flag=Add', 'Product', 'height=600px,width=830px,status=no,toolbar=no,menubar=no,top=' + iTop + ',left=' + iLeft + ',location=no,scrollbars=yes,resizable=no');
        return false;
        
        //return window.showModalDialog('Product_Profile.aspx?PROID=0&flag=Add','Product','dialogWidth=830px;dialogHeight=600px;center:1;help:0;status:0;resizable:0');
    }
    function DoBlur(){
        if (window.event.keyCode==13) window.event.keyCode=9;
    }
    function ClearSubtype()
    {
        document.getElementById(local+"txt_SubTypeName").value="";
        document.getElementById(local+"hiddenforsmtypeid").value="";
        return false;
    }
    function WebForm_FireDefaultButton(event, target) {
        if (event.keyCode == 13 && !(event.srcElement && (event.srcElement.tagName.toLowerCase() == "textarea"))) {
            var defaultButton = document.getElementById(target);
            if (defaultButton && typeof (defaultButton.click) != "undefined") {
                defaultButton.click();
                event.cancelBubble = true;
                if (event.stopPropagation) event.stopPropagation();
                return false;
            }
        }
        return true;
    }

    </script>
    <script language="JavaScript" type="text/javascript" src="Js/calendar.js"></script>
    <script language="javascript" type="text/javascript" src="Js/common.js"></script>
    <script language="JavaScript" type="text/javascript" src="Js/calendar-en.js"></script>
    <script language="JavaScript" type="text/javascript" src="Js/calendar-setup.js"></script>
    <script language="javascript" type="text/javascript" src="Controls/cal/popcalendar_en.js">function hiddenButton_onclick() {

}

function hiddenButton_onclick() {

}

</script>

    <table width="100%" border="0" onkeydown="DoSearch()">
         <tr>
                            <td align="left">
                                <b><font size="4" color="gray">
                                    <asp:Label ID="lbl_BuildingProfile" runat="server"
                                        Text="��Ʒ����" Font-Size="Large"></asp:Label></font></b>
                            </td>
                        </tr>
        <tr>
            <td>
                <%--</ajax:AjaxPanel>--%>
                <table border="0" cellpadding="0" cellspacing="1" class="bgColorBorder1" style="width: 100%">
        <tr>
            <br />
        </tr>
        <tr>
            <td style="height: 23px; width:12%" align="right">
                <ace:LabelEx ID="LabelEx1" runat="server" CssClass="Label">������:</ace:LabelEx>
            </td>
            <td style="height: 23px; width:15%">
                <ace:DropDownListEx ID="ddl_OrderName" runat="server" Width="180px">
                    <asp:ListItem>---</asp:ListItem>
                    <asp:ListItem>������</asp:ListItem>
                    <asp:ListItem>�ܴ���</asp:ListItem>
                </ace:DropDownListEx>
            </td>
            <%--</ajax:AjaxPanel>--%>
            <td style="height: 23px; width:10%" align="right">
                <ace:LabelEx ID="LabelEx3" runat="server" CssClass="Label">��Ʒ���:</ace:LabelEx>
            </td>
            <td style="height: 23px; width:15%">
                <ace:DropDownListEx ID="ddl_Type" runat="server" Width="132px">
                    <asp:ListItem>---</asp:ListItem>
                    <asp:ListItem>���</asp:ListItem>
                    <asp:ListItem>����</asp:ListItem>
                    <asp:ListItem>����</asp:ListItem>
                    <asp:ListItem>����</asp:ListItem>
                </ace:DropDownListEx>
            </td>
            <td style="height: 23px; width:12%" align="right">
                <ace:LabelEx ID="LabelEx5" runat="server" CssClass="Label">�������:</ace:LabelEx>
            </td>
            <td style="height: 23px; ">
                
                <ace:DropDownListEx ID="ddl_Type0" runat="server" Width="132px">
                    <asp:ListItem>---</asp:ListItem>
                    <asp:ListItem>�ƽ�</asp:ListItem>
                    <asp:ListItem>����</asp:ListItem>
                    <asp:ListItem>�ٽ�</asp:ListItem>
                    <asp:ListItem>����</asp:ListItem>
                </ace:DropDownListEx>
            </td>
            <%--<input type="button" id="hiddenButton" runat="server" style="width: 83px" onclick="hiddenButton_Click"/>--%>
            <td style="height: 23px; ">
                
                &nbsp;</td>
           
        </tr>
        <tr>
            <td align="right">
                <ace:LabelEx ID="LabelEx2" runat="server" CssClass="Label">��Ʒ����:</ace:LabelEx>
            </td>
            <td>
                <ace:TextBoxEx ID="txt_ProductName" runat="server" Width="175px"></ace:TextBoxEx>
            </td>
            <td align="right">
                <ace:LabelEx ID="LabelEx4" runat="server" CssClass="Label">����:</ace:LabelEx>
            </td>
            <td>
                <ace:TextBoxEx ID="txt_Barcode" runat="server"></ace:TextBoxEx>
            </td>
            <td align="right">
                <ace:LabelEx ID="LabelEx6" runat="server" CssClass="Label">�����ŵ�:</ace:LabelEx>
            </td>
            <td>
                
                <ace:DropDownListEx ID="ddl_Type1" runat="server" Width="132px">
                    <asp:ListItem>---</asp:ListItem>
                    <asp:ListItem>��һ�ŵ�</asp:ListItem>
                    <asp:ListItem>�ڶ��ŵ�</asp:ListItem>
                    <asp:ListItem>�����ŵ�</asp:ListItem>
                    <asp:ListItem>�����ŵ�</asp:ListItem>
                    <asp:ListItem>�����ŵ�</asp:ListItem>
                    <asp:ListItem>�����ŵ�</asp:ListItem>
                    <asp:ListItem>�����ŵ�</asp:ListItem>
                    <asp:ListItem>�ڰ��ŵ�</asp:ListItem>
                </ace:DropDownListEx>
            </td>
            <td style="height: 23px; ">
                <asp:CheckBox ID="chk_IsSaled" runat="server" Text="���۳�" />
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
                            <ace:ButtonEx ID="btn_Search" runat="server" Text="��ѯ"
                                Width="70px" OnClick="btn_Search_Click" CssClass="ButtonFlat" 
                                DialogHeight="400px" onClientClick="javascript:return CheckSearch();"
                                DialogWidth="600px" LeftSpace="0" RightSpace="0"
                                ShowConfirmMsg="False" ShowWaitingPanel="False" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <ace:ButtonEx ID="btn_Add" runat="server" Text="���" Width="70px" onClientClick="javascript:return Open_AddWindow();"
                                CssClass="ButtonFlat" DialogHeight="400px" DialogWidth="400px" LeftSpace="0"
                                 RightSpace="0" ShowConfirmMsg="False" ShowWaitingPanel="False" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <ace:ButtonEx ID="btn_Delete" runat="server" Text="ɾ��" Width="70px" onClientClick="javascript:return DeleteCheck();"
                                CssClass="ButtonFlat" DialogHeight="400px" DialogWidth="400px" LeftSpace="0"
                                 RightSpace="0" ShowConfirmMsg="False" ShowWaitingPanel="False" 
                                onclick="btn_Delete_Click" />
                            </td>
                        <td align="left" style="width: 100%;display:none;">
                            <asp:Button ID="hiddenButton" runat="server" onclick="hiddenButton_Click" />
                            <ace:ButtonEx ID="btn_Reset" runat="server" onClientClick="javascript:return ResetSearch();"
                                Text="����" Width="70px" Visible="False" />
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
                                ShowFooter="True" OnSortCommand="dgProduct_SortCommand" Width="100%" AllowExport="False"
                                DownloadFileName="" CssClass="Grid" HighLight="False" HighLightCssClass="DataGridHighLight"
                                SQLString="" OnItemDataBound="dgProduct_ItemDataBound"
                                PageCountEx="1" CurrentPageIndexEx="0" MAXRowCount="500">
                                <Columns>
                                    <ace:CheckBoxColumn DataField="Product_ID">
                                        <HeaderStyle Width="8px" />
                                        <ItemStyle Width="8px" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                            Font-Strikeout="False" Font-Underline="False" />
                                    </ace:CheckBoxColumn>
                                    <ace:MultiQueryStringColumn WinType="Normal" DataTextField="Product_Name" HeaderText="Ʒ��"
                                        SortExpression="Product_Name" DataNavigateUrlField="Product_ID"
                                        DataNavigateUrlFormatString="javascript:Product_OpenNormal('Product_Profile.aspx?PROID={0}&flag=Edit','Product');"
                                        PopupWin="False" WinHeight="700px" WinWidth="1050px" CharCount="0" NavigateUrl=""
                                        Text="">
                                        <ItemStyle HorizontalAlign="Left" Width="17%" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </ace:MultiQueryStringColumn>
                                    <asp:boundcolumn DataField="Barcode" HeaderText="����" SortExpression="Barcode">
                                        <itemstyle horizontalalign="Left" width="12%" />
                                        <headerstyle horizontalalign="Left" />
                                    </asp:boundcolumn>
                                    <asp:boundcolumn DataField="Factory_Weight" HeaderText="��������" SortExpression="Factory_Weight">
                                        <itemstyle horizontalalign="Left" width="8%" />
                                        <headerstyle horizontalalign="Left" />
                                    </asp:boundcolumn>
                                    <asp:boundcolumn DataField="Gold_NetWeight" HeaderText="������" SortExpression="Gold_NetWeight">
                                        <itemstyle horizontalalign="Left" width="6%" />
                                        <headerstyle horizontalalign="Left" />
                                    </asp:boundcolumn>
                                    <asp:boundcolumn DataField="ShouCun" HeaderText="�ִ�" SortExpression="ShouCun">
                                        <itemstyle horizontalalign="Left" width="5%" />
                                        <headerstyle horizontalalign="Left" />
                                    </asp:boundcolumn>
                                    <asp:boundcolumn DataField="Price" HeaderText="���ۼ�" SortExpression="Price">
                                        <itemstyle horizontalalign="Left" width="6%" />
                                        <headerstyle horizontalalign="Left" />
                                    </asp:boundcolumn>
                                    <asp:boundcolumn DataField="Style" HeaderText="���" SortExpression="ProducStylet_Size">
                                        <itemstyle horizontalalign="Left" width="8%" />
                                        <headerstyle horizontalalign="Left" />
                                    </asp:boundcolumn>
                                    <asp:boundcolumn DataField="Old_NO" HeaderText="ԭ���" SortExpression="Old_NO">
                                        <itemstyle horizontalalign="Right" width="8%" />
                                        <headerstyle horizontalalign="Right" />
                                    </asp:boundcolumn>
                                    <asp:boundcolumn DataField="Real_Number" HeaderText="����" SortExpression="Real_Number">
                                        <itemstyle horizontalalign="Right" width="5%" />
                                        <headerstyle horizontalalign="Right" />
                                    </asp:boundcolumn>
                                    <asp:boundcolumn DataField="SuJinFeiYong" HeaderText="�ؽ𹤷�" SortExpression="SuJinFeiYong">
                                        <itemstyle horizontalalign="Right" width="8%" />
                                        <headerstyle horizontalalign="Right" />
                                    </asp:boundcolumn>
                                    <asp:boundcolumn DataField="GongFei" HeaderText="����" SortExpression="GongFei">
                                        <itemstyle horizontalalign="Right" width="5%" />
                                        <headerstyle horizontalalign="Right" />
                                    </asp:boundcolumn>
                                    <asp:boundcolumn DataField="Factory_Name" HeaderText="������" SortExpression="Factory_Name">
                                        <itemstyle horizontalalign="Right" width="9%" />
                                        <headerstyle horizontalalign="Right" />
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
    <asp:HiddenField ID="hiddenforsmtypeid" runat="server" />
    
    <%--<input type="button" id="hiddenButton" runat="server" style="width: 83px" onclick="hiddenButton_Click"/>--%>
</asp:Content>
