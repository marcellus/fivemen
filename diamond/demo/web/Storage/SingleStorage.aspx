<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Theme="DefaultTheme"
    CodeFile="SingleStorage.aspx.cs" Inherits="Storage_SingleStorage" %>

<%@ Register Assembly="ACE.Common.Web.UI" Namespace="ACE.Common.Web.UI" TagPrefix="ace" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" class="NCLabelSmall">
        <tr>
            <td>
                <table border="0">
                    <tr>
                        <td align="left">
                            <b><font size="4" color="gray">
                                <asp:Label ID="lbl_BuildingProfile" runat="server" Text="单件入库"></asp:Label></font></b>
                        </td>
                    </tr>
                    <tr>
                        <td class="NCLabelSmall" align="left">
                            <ace:ButtonEx ID="btn_Submit" runat="server" CssClass="ButtonFlat" Text="入库" Width="100px"
                                OnClick="btn_Submit_Click" RightSpace="2" />
                            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" cellpadding="2" cellspacing="0">
                <tr>
                        <td>
                            <ace:LabelEx ID="LabelEx3" runat="server" CssClass="Label">
                                               入库单：</ace:LabelEx>
                        </td>
                        <td style="color: #FF0000" width="225">
                             <ace:DropDownListEx ID="ddl_StoNo" runat="server" Width="200px" DataTextField="StorageNo" 
                    DataValueField="StorageNo" >
                </ace:DropDownListEx>
                        </td>
                    </tr>
                
                    <tr>
                        <td style="width: 120px" align="left">
                            <ace:LabelEx ID="LabelEx9" runat="server" CssClass="Label" Width="100px">
                                            供货商：</ace:LabelEx>
                        </td>
                        <td style="color: #FF0000" width="225">
                            <ace:DropDownListEx ID="ddl_OrderName" runat="server" Width="205px" Height="20px">
                                <asp:ListItem>---</asp:ListItem>
                                <asp:ListItem>金至尊</asp:ListItem>
                                <asp:ListItem>周大生</asp:ListItem>
                            </ace:DropDownListEx>
                            <ace:LabelEx ID="lbl_Star1" runat="server" CssClass="Label" ForeColor="#CC0000">*</ace:LabelEx>
                        </td>
                        <td align="center" class="style3" rowspan="12" height="365" colspan="3">
                            <%--<ace:ImageEx ID="ImageEx1" onload="changsize();" runat="server" 
                                                ImageUrl="~/Images/DTZ_logo.jpg" />--%>
                            <img id="ImageEx1" onload="javascript:limitImage(this);" alt="" src="Images/NoImage2.jpg" />
                            <%--<asp:Image ID="ImageEx1" runat="server" ImageUrl="Images/DTZ_logo.jpg" OnLoad="javascript:limitImage(this);" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ace:LabelEx ID="LabelEx1" runat="server" CssClass="Label">
                                                品名：</ace:LabelEx>
                        </td>
                        <td style="color: #FF0000" width="225">
                            <ace:TextBoxEx ID="txt_ProductName" runat="server" Width="200px" 
                                MaxLength="100"></ace:TextBoxEx>
                            <ace:LabelEx ID="lbl_Star2" runat="server" CssClass="Label" ForeColor="#CC0000">*</ace:LabelEx>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ace:LabelEx ID="LabelEx10" runat="server" CssClass="Label">
                                                款号：</ace:LabelEx>
                        </td>
                        <td style="color: #FF0000" width="225">
                            <ace:TextBoxEx ID="txt_StyleID" runat="server" Width="200px" MaxLength="100"></ace:TextBoxEx>
                        </td>
                    </tr>
                    <%--<ajax:AjaxPanel ID="panel1" runat="server">--%>
                    <tr>
                        <td class="style1">
                            <ace:LabelEx ID="LabelEx2" runat="server" CssClass="Label">
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
                            <ace:LabelEx ID="LabelEx13" runat="server" CssClass="Label">
                                                材质：</ace:LabelEx>
                        </td>
                        <td width="225">
                            <ace:DropDownListEx ID="ddl_SmallType" runat="server" Height="20px" Width="205px">
                                <asp:ListItem>---</asp:ListItem>
                                <asp:ListItem>黄金</asp:ListItem>
                                <asp:ListItem>铂金</asp:ListItem>
                                <asp:ListItem>钯金</asp:ListItem>
                                <asp:ListItem>白银</asp:ListItem>
                            </ace:DropDownListEx>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ace:LabelEx ID="LabelEx14" runat="server" CssClass="Label">
                                                工厂货重：</ace:LabelEx>
                        </td>
                        <td width="225">
                            <ace:TextBoxEx ID="txt_FactoryWeight" runat="server" Width="200px" MaxLength="100"></ace:TextBoxEx>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ace:LabelEx ID="LabelEx15" runat="server" CssClass="Label">
                                                净金重：</ace:LabelEx>
                        </td>
                        <td width="225">
                            <ace:TextBoxEx ID="txt_NetGoldWeight" runat="server" Width="200px" MaxLength="10"></ace:TextBoxEx>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <ace:LabelEx ID="LabelEx18" runat="server" CssClass="Label">
                                                手寸：</ace:LabelEx>
                        </td>
                        <td width="225" class="style2">
                            <ace:TextBoxEx ID="txt_Size" runat="server" OnlyNumber="True" Style="margin-bottom: 0px"
                                Width="200px" MaxLength="5"></ace:TextBoxEx>
                        </td>
                        <td align="left" valign="middle" class="style2">
                            <ace:LabelEx ID="LabelEx12" runat="server" CssClass="Label" Width="55px" Height="16px">
                                                 图片：</ace:LabelEx>
                        </td>
                        <td align="right" valign="middle" class="style2">
                            <asp:FileUpload ID="FileUpload1" runat="server" Width="330px" />
                        </td>
                        <td align="right" valign="middle" class="style2">
                          
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" height="50">
                            <ace:LabelEx ID="LabelEx11" runat="server" CssClass="Label">
                                               描述：
                            </ace:LabelEx>
                        </td>
                        <td colspan="4">
                            <textarea id="txt_Description" runat="server" name="S1" rows="3" cols="0" style="width: 666px"></textarea>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%--</ajax:AjaxPanel>--%>
    </table>
   
<script type="text/javascript">
    function clearControl() {
        var Input = document.getElementsByTagName("input");
        var Inputarea = document.getElementsByTagName("textarea");
        var Inputselect = document.getElementsByTagName("select");
        for (var i = 0; i < Input.length; i++) {
            if (Input[i].type == "text") {
                Input[i].value = ""; //清除text的值
            }
        }
        for (var j = 0; j < Inputarea.length; j++) {
            Inputarea[j].value = ""; //清除textarea的值
        }
        for (var k = 0; k < Inputselect.length; k++) {
            Inputselect[k].options[0].selected = true; //把select的值选项设置为第一个
        }
    } 


</script>
    <asp:HiddenField ID="hiddenforimage" runat="server" />
                    <asp:HiddenField ID="hiddenforstype" runat="server" />
                    <asp:HiddenField ID="hiddenforsubtypename" runat="server" />
                    <asp:HiddenField ID="hiddenforsubtypeid" runat="server" />
                    <input type="hidden" id = "selectvalue" runat="server"/>
                    <asp:HiddenField ID="hiddenforupload" runat="server" />
</asp:Content>
