<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Product_Send.aspx.cs"  Theme="DefaultTheme"  Inherits="Product_Send" %>

<%@ Register Assembly="ACE.Common.Web.UI" Namespace="ACE.Common.Web.UI" TagPrefix="ace" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <link href="Controls/cal/popcalendar.css" type="text/css" rel="stylesheet" />
<script language="JavaScript" type="text/javascript" src="Js/calendar.js"></script>
    <script language="javascript" type="text/javascript" src="Js/common.js"></script>
    <script language="JavaScript" type="text/javascript" src="Js/calendar-en.js"></script>
    <script language="JavaScript" type="text/javascript" src="Js/calendar-setup.js"></script>
    <script language="javascript" type="text/javascript" src="Controls/cal/popcalendar_en.js"></script>
    <script type="text/javascript">
    </script>
    <script type="text/javascript">
        var flag = false;
        function limitImage(ImgD) {
            //debugger;
            var areaWidth = 350;  //你放置图片区域的宽度。   
            var areaHeight = 390; //你放置图片区域的高度。   
            var image = new Image();
            image.src = ImgD.src;
            var tempWidth = image.width;
            var tempHeight = image.height;
            var altWidth = image.width;
            var altHeight = image.height;
            ImgD.alt = altWidth + "×" + altHeight;
            if (image.width > 0 && image.height > 0) {
                flag = true;
                if (tempWidth > areaWidth) {
                    tempWidth = areaWidth;
                    tempHeight = (image.height * areaWidth) / image.width;
                }
                if (tempHeight > areaHeight) {
                    tempWidth = (tempWidth * areaHeight) / tempHeight;
                    tempHeight = areaHeight;
                }
                ImgD.width = tempWidth;
                ImgD.height = tempHeight;
            }
        }

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
<table  border="0" cellpadding="0" cellspacing="0" style="width:100%" class="NCLabelSmall">
            <tr>
                <td>
                    <table  border="0">
                        <tr>
                            <td align="left">
                                <b><font size="4" color="gray">
                                    <asp:Label ID="lbl_BuildingProfile" runat="server"
                                        Text="产品分配" Font-Size="Large"></asp:Label></font></b>
                            </td>
                        </tr>
                        <tr>
                            <td class="NCLabelSmall" align="left">
                                &nbsp;<asp:Button ID="btn_Submit" runat="server" TabIndex="1" onclick="btn_OK_Click" Text="" Width="1px"/>
                                            
                                        &nbsp;<ace:ButtonEx ID="btn_Cancel" runat="server" Text="关闭" Width="70px" OnClientClick="ConfirmCancel()"
                                    CssClass="ButtonFlat" TabIndex="3" />
                            &nbsp;&nbsp;
                            </td>
                        </tr>
                        </table>
                        </td>
                        </tr>
                        <tr>
                            <td>
                                <table border="0"  cellpadding="2" cellspacing="0">
                                    <tr>
                                        <td style="width:120px" align="left">
                                            <ace:LabelEx ID="LabelEx19" runat="server" CssClass="Label" Width="100px" Font-Size="Small">
                                            门店名称：</ace:LabelEx>
                                        </td>
                                        <td style="color: #FF0000" width="225">
                                            <ace:DropDownListEx ID="ddl_OrderName0" runat="server" Width="205px"  ReadOnly="True" 
                                                Height="20px" >
                                            <asp:ListItem>---</asp:ListItem>
                                            <asp:ListItem>第一门店</asp:ListItem>
                                            <asp:ListItem>第二门店</asp:ListItem>
                                            <asp:ListItem>第三门店</asp:ListItem>
                                            <asp:ListItem>第四门店</asp:ListItem>
                                            <asp:ListItem>第五门店</asp:ListItem>
                                            <asp:ListItem>第六门店</asp:ListItem>
                                            <asp:ListItem>第七门店</asp:ListItem>
                                            <asp:ListItem>第八门店</asp:ListItem>
                                            </ace:DropDownListEx>
                                            <ace:LabelEx ID="lbl_Star2" runat="server" CssClass="Label" ForeColor="#CC0000" >*</ace:LabelEx>
                                        </td>
                                        <td align="center" class="style3" rowspan="14" height="365" colspan="3">
                                            <%--<ajax:AjaxPanel ID="panel1" runat="server">--%>
                                                <img id="ImageEx1" onload="javascript:limitImage(this);" alt=""  src="Images/NoImage2.jpg" />
                                                <%--</ajax:AjaxPanel>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:120px" align="left">
                                            <ace:LabelEx ID="LabelEx5" runat="server" CssClass="Label" Font-Size="Small">
                                                条码：</ace:LabelEx>
                                        </td>
                                        <td style="color: #FF0000" width="225">
                                            <ace:TextBoxEx ID="txt_Barcode" runat="server" Width="200px" ></ace:TextBoxEx>
                                            <ace:LabelEx ID="lbl_Star3" runat="server" CssClass="Label" 
                                                ForeColor="#CC0000" >*</ace:LabelEx>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:120px" align="left">
                                            <ace:LabelEx ID="LabelEx9" runat="server" CssClass="Label" Width="100px" Font-Size="Small">
                                            供货商：</ace:LabelEx>
                                        </td>
                                        <td style="color: #FF0000" width="225">
                                            <ace:DropDownListEx ID="ddl_OrderName" runat="server" Width="205px"  ReadOnly="True" 
                                                Height="20px" >
                                            <asp:ListItem>---</asp:ListItem>
                                            <asp:ListItem>金至尊</asp:ListItem>
                                            <asp:ListItem>周大生</asp:ListItem>
                                            </ace:DropDownListEx>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ace:LabelEx ID="LabelEx1" runat="server" CssClass="Label" Font-Size="Small">
                                                 品名：</ace:LabelEx>
                                        </td>
                                        <td style="color: #FF0000" width="225">
                                            <ace:TextBoxEx ID="txt_ProductName" runat="server" Width="200px" onfocus="clearsortvalue();" 
                                                MaxLength="100" ReadOnly="True"></ace:TextBoxEx>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ace:LabelEx ID="LabelEx10" runat="server" CssClass="Label" Font-Size="Small">
                                                 款号：</ace:LabelEx>
                                        </td>
                                        <td style="color: #FF0000" width="225">
                                            <ace:TextBoxEx ID="txt_StyleID" runat="server" Width="200px" MaxLength="100" onfocus="clearsortvalue();"></ace:TextBoxEx>
                                        </td>
                                    </tr>
                                    <%--<ajax:AjaxPanel ID="panel1" runat="server">--%>
                                    <tr>
                                        <td class="style1">
                                            <ace:LabelEx ID="LabelEx2" runat="server" CssClass="Label" Font-Size="Small">
                                                 产品类别：</ace:LabelEx>
                                        </td>
                                        <td width="225" class="style1">
                                            
                                            <ace:DropDownListEx ID="ddl_LeiBie" runat="server" Width="205px" Height="20px">
                                           <asp:ListItem>---</asp:ListItem>
                                            <asp:ListItem>钻戒</asp:ListItem>
                                            <asp:ListItem>项链</asp:ListItem>
                                            <asp:ListItem>耳环</asp:ListItem>
                                            <asp:ListItem>手镯</asp:ListItem>
                                            </ace:DropDownListEx>
                                            
                                                </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ace:LabelEx ID="LabelEx13" runat="server" CssClass="Label" Font-Size="Small">
                                                材质：</ace:LabelEx>
                                        </td>
                                        <td width="225">
                                            <ace:DropDownListEx ID="ddl_SmallType" runat="server" Height="20px" Width="205px">
                                            <asp:ListItem>---</asp:ListItem>
                                            <asp:ListItem>黄金</asp:ListItem>
                                            <asp:ListItem>铂金</asp:ListItem>
                                            <asp:ListItem>钯金</asp:ListItem>
                                            <asp:ListItem>白银</asp:ListItem>
                                            </ace:DropDownListEx></td>
                                    </tr>
                                    
                                    <tr>
                                        <td>
                                            <ace:LabelEx ID="LabelEx14" runat="server" CssClass="Label" Font-Size="Small">
                                                 工厂货重：</ace:LabelEx>
                                        </td>
                                        <td width="225">
                                            <ace:TextBoxEx ID="txt_FactoryWeight" runat="server" Width="200px" 
                                                MaxLength="100" ReadOnly="True"></ace:TextBoxEx>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td>
                                            <ace:LabelEx ID="LabelEx15" runat="server" CssClass="Label" Font-Size="Small">
                                                 净金重：</ace:LabelEx>
                                        </td>
                                        <td width="225">
                                            <ace:TextBoxEx ID="txt_NetGoldWeight" runat="server" Width="200px" 
                                                MaxLength="10" ReadOnly="True"></ace:TextBoxEx>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td>
                                            <ace:LabelEx ID="LabelEx16" runat="server" CssClass="Label" Font-Size="Small">
                                                原编号：</ace:LabelEx>
                                        </td>
                                        <td width="225">
                                            <ace:TextBoxEx ID="txt_OldNO" runat="server" Width="200px" MaxLength="10" 
                                                ReadOnly="True" ></ace:TextBoxEx>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td>
                                            <ace:LabelEx ID="LabelEx4" runat="server" CssClass="Label" Font-Size="Small">
                                                 手寸：</ace:LabelEx>
                                        </td>
                                        <td width="225">
                                            <ace:TextBoxEx ID="txt_Size" runat="server" Width="200px" MaxLength="10" 
                                                ReadOnly="True"></ace:TextBoxEx>
                                        </td>
                                    </tr>
                                    <%--</ajax:AjaxPanel>--%>
                                    <tr>
                                        <td>
                                            <ace:LabelEx ID="LabelEx17" runat="server" CssClass="Label" Font-Size="Small">
                                                 零售价：</ace:LabelEx>
                                        </td>
                                        <td width="225">
                                            <ace:TextBoxEx ID="txt_Price" runat="server" Width="200px" MaxLength="10" 
                                                ReadOnly="True" ></ace:TextBoxEx>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ace:LabelEx ID="LabelEx6" runat="server" CssClass="Label" Font-Size="Small">
                                                素金工费：</ace:LabelEx>
                                        </td>
                                        <td style="color: #FF0000" width="225">
                                            <ace:TextBoxEx ID="txt_SuJinGongFei" runat="server" onlynumber="True" 
                                                style="margin-bottom: 0px" Width="200px" MaxLength="5" ReadOnly="True"></ace:TextBoxEx>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ace:LabelEx ID="LabelEx7" runat="server" CssClass="Label" Font-Size="Small">
                                                件数：</ace:LabelEx>
                                        </td>
                                        <td style="color: #FF0000" width="225">
                                            <ace:TextBoxEx ID="txt_Count" runat="server" onlynumber="True" 
                                                style="margin-bottom: 0px" Width="200px" MaxLength="5" ReadOnly="True"></ace:TextBoxEx>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <ace:LabelEx ID="LabelEx18" runat="server" CssClass="Label" Font-Size="Small">
                                                工费：</ace:LabelEx>
                                        </td>
                                        <td width="225" class="style2">
                                            <ace:TextBoxEx ID="txt_GongFei" runat="server" onlynumber="True" 
                                                style="margin-bottom: 0px" Width="200px" MaxLength="5" ReadOnly="True"></ace:TextBoxEx>
                                        </td>
                                        <td align="left" valign="middle" class="style2">
                                            &nbsp;</td>
                                        <td align="right" valign="middle" class="style2">
                                            &nbsp;</td>
                                        <td align="right" valign="middle" class="style2">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td valign="top" height="50">
                                            <ace:LabelEx ID="LabelEx11" runat="server" CssClass="Label" Font-Size="Small">
                                               备注：
                                            </ace:LabelEx>
                                        </td>
                                        <td colspan="4">
                                            <textarea ID="txt_Description" runat="server" name="S1" rows="3" 
                                                style="width:666px" readonly="readonly"></textarea></td>
                                    </tr>
                                </table>
                            </td>
            </tr>
                    </table>
                    <asp:HiddenField ID="hiddenforimage" runat="server" />
                    <asp:HiddenField ID="hiddenforstype" runat="server" />
                    <asp:HiddenField ID="hiddenforsubtypename" runat="server" />
                    <asp:HiddenField ID="hiddenforsubtypeid" runat="server" />
                    <input type="hidden" id = "selectvalue" runat="server"/>
                    <asp:HiddenField ID="hiddenforupload" runat="server" />
                    <script language="javascript" type="text/javascript">
                        if (document.getElementById("ContentPlaceHolder1_hiddenforimage").value != "") {
                            document.getElementById("ImageEx1").src = document.getElementById("ContentPlaceHolder1_hiddenforimage").value;
                        }
</script>
</asp:Content>
