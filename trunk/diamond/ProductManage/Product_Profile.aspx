<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="Product_Profile.aspx.cs" Inherits="Product_Profile" Theme="DefaultTheme" %>

<%@ Register Assembly="ACE.Common.Web.UI" Namespace="ACE.Common.Web.UI" TagPrefix="ace" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Product Profile</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Expires" content="0"/>     
    <meta http-equiv="Cache-Control" content="no-cache"/>     
    <meta http-equiv="Pragma" content="no-cache"/> 
    <link href="Controls/cal/popcalendar.css" type="text/css" rel="stylesheet" />
    <script language="JavaScript" type="text/javascript">
      function ResetDate()
      {
        var o=document.getElementsByTagName("input");
   
        for(i=0;i<o.length;i++)
        {
            if(o[i].name.indexOf('txtLeaseExpDate')>-1) o[i].value='';
        }
        return false;
    }

    function ConfirmCancel() {
        var re = window.confirm("确定要关闭当前页面吗 ?");
        if (re) {
            window.opener = null; window.close();
        }
        else {
            return false;
        }
    }

    function DeleteConfirm() {
        var re = window.confirm("Are you sure to delete this record ?");
        if (re) {
            return true;
        }
        else {
            return false;
        }
    }

    function CheckProductData() {
        //alert(document.getElementById("ddl_SmallType").value);
        if (document.getElementById("ddl_OrderName").value == "") {
            alert("Please select order name!");
            return false;
        }
        if (document.getElementById("txt_ProductName").value == "") {
            alert("Please input product name!");
            return false;
        }
        document.getElementById("hiddenforstype").value = document.getElementById("ddl_SmallType").value;
//        if (document.getElementById("txt_OrderNumber").value == "") {
//            alert("Please input order number!");
//            return false;
//        }
    }

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
    
    function selectchange(o){
    //debugger;
        //alert("123");
    document.getElementById("ddl_SmallType").options.length = 0;      //清空选项
	var opts = document.getElementById("selectvalue").value.split(',');
	for (var i = 0 ; i < opts.length ; i++ ) //循环添加选项值
	  {	  
	        if(i==0)
	        {
	            var optemp = new Option();
	            optemp.text = "";    //取TEXT值
		        optemp.value = "";    //取VALUE值
		        document.getElementById("ddl_SmallType").add(optemp);       //添加选项
	        }
		   var opt = new Option();     //新建选项
		   var optContent = opts[i].split('%'); //获取选项内容
		   if(optContent[0]==o.value)
		   {
		       opt.text = optContent[1];    //取TEXT值
		       opt.value = optContent[2];    //取VALUE值
		       document.getElementById("ddl_SmallType").add(opt);       //添加选项
		   }
	}
	if (document.getElementById("btn_Submit").value == "Add") {
	    document.getElementById("txt_Sort_Value").value = "";
	}
}

function clearsortvalue() {
    if (document.getElementById("btn_Submit").value == "Add") {
        document.getElementById("txt_Sort_Value").value = "";
    }
}


function KeyPress(objTR) {//只允许录入数据字符 0-9 和小数点
    //var objTR = element.document.activeElement;  
    var txtval = objTR.value;
    var l = objTR.value.length;
    var key = event.keyCode;
    if ((key < 48 || key > 57) && key != 46) {
        event.keyCode = 0;
    }
    else {
        if (key == 46) {
            if (txtval.indexOf(".") != -1 || txtval.length == 0) {
                event.keyCode = 0;
            }
        }
    }
    if (txtval.indexOf(".") != -1) {
        var decimalPart = txtval.substring(txtval.indexOf(".") + 1, l);
        if (decimalPart.length >= 2) {
            event.keyCode = 0;
        }
    }
}
    </script>
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
        .style2
        {
            height: 19px;
        }
    </style>
</head>
<body onload="self.focus()">
    <form runat="server">
    <%--<ajax:AjaxPanel ID="panel1" Width="100%" runat="server">--%>
        <table  border="0" cellpadding="0" cellspacing="0" class="NCLabelSmall">
            <tr>
                <td>
                    <table  border="0">
                        <tr>
                            <td align="left">
                                <b><font size="4" color="gray">
                                    <asp:Label ID="lbl_BuildingProfile" runat="server"
                                        Text="商品详情"></asp:Label></font></b>
                            </td>
                        </tr>
                        <tr>
                            <td class="NCLabelSmall" align="left">
                                <ace:ButtonEx ID="btn_Submit" runat="server" CssClass="ButtonFlat" 
                                    Text="保存并打印条码" Width="100px" onclick="btn_Submit_Click" RightSpace="2"/>
                                <ace:ButtonEx ID="btn_Cancel" runat="server" Text="关闭" Width="70px" OnClientClick="ConfirmCancel()"
                                    CssClass="ButtonFlat" />
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
                                                <img id="ImageEx1" onload="javascript:limitImage(this);" alt=""  src="Images/NoImage2.jpg" />
                                                <%--<asp:Image ID="ImageEx1" runat="server" ImageUrl="Images/DTZ_logo.jpg" OnLoad="javascript:limitImage(this);" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ace:LabelEx ID="LabelEx1" runat="server" CssClass="Label">
                                                品名：</ace:LabelEx>
                                        </td>
                                        <td style="color: #FF0000" width="225">
                                            <ace:TextBoxEx ID="txt_ProductName" runat="server" Width="200px" onfocus="clearsortvalue();" 
                                                MaxLength="100"></ace:TextBoxEx>
                                            <ace:LabelEx ID="lbl_Star2" runat="server" CssClass="Label" ForeColor="#CC0000" >*</ace:LabelEx>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ace:LabelEx ID="LabelEx10" runat="server" CssClass="Label">
                                                款号：</ace:LabelEx>
                                        </td>
                                        <td style="color: #FF0000" width="225">
                                            <ace:TextBoxEx ID="txt_StyleID" runat="server" Width="200px" MaxLength="100" onfocus="clearsortvalue();"></ace:TextBoxEx>
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
                                            </ace:DropDownListEx></td>
                                    </tr>
                                    
                                    <tr>
                                        <td>
                                            <ace:LabelEx ID="LabelEx14" runat="server" CssClass="Label">
                                                工厂货重：</ace:LabelEx>
                                        </td>
                                        <td width="225">
                                            <ace:TextBoxEx ID="txt_FactoryWeight" runat="server" Width="200px" 
                                                MaxLength="100"></ace:TextBoxEx>
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
                                        <td>
                                            <ace:LabelEx ID="LabelEx16" runat="server" CssClass="Label">
                                                原编号：</ace:LabelEx>
                                        </td>
                                        <td width="225">
                                            <ace:TextBoxEx ID="txt_OldNO" runat="server" Width="200px" MaxLength="10" ></ace:TextBoxEx>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td>
                                            <ace:LabelEx ID="LabelEx4" runat="server" CssClass="Label">
                                                手寸：</ace:LabelEx>
                                        </td>
                                        <td width="225">
                                            <ace:TextBoxEx ID="txt_Size" runat="server" Width="200px" MaxLength="10"></ace:TextBoxEx>
                                        </td>
                                    </tr>
                                    <%--</ajax:AjaxPanel>--%>
                                    <tr>
                                        <td>
                                            <ace:LabelEx ID="LabelEx17" runat="server" CssClass="Label">
                                                零售价：</ace:LabelEx>
                                        </td>
                                        <td width="225">
                                            <ace:TextBoxEx ID="txt_Price" runat="server" Width="200px" MaxLength="10" ></ace:TextBoxEx>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ace:LabelEx ID="LabelEx6" runat="server" CssClass="Label">
                                                素金工费：</ace:LabelEx>
                                        </td>
                                        <td style="color: #FF0000" width="225">
                                            <ace:TextBoxEx ID="txt_SuJinGongFei" runat="server" onlynumber="True" 
                                                style="margin-bottom: 0px" Width="200px" MaxLength="5"></ace:TextBoxEx>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ace:LabelEx ID="LabelEx7" runat="server" CssClass="Label">
                                                件数：</ace:LabelEx>
                                        </td>
                                        <td style="color: #FF0000" width="225">
                                            <ace:TextBoxEx ID="txt_Count" runat="server" onlynumber="True" 
                                                style="margin-bottom: 0px" Width="200px" MaxLength="5"></ace:TextBoxEx>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <ace:LabelEx ID="LabelEx18" runat="server" CssClass="Label">
                                                工费：</ace:LabelEx>
                                        </td>
                                        <td width="225" class="style2">
                                            <ace:TextBoxEx ID="txt_GongFei" runat="server" onlynumber="True" 
                                                style="margin-bottom: 0px" Width="200px" MaxLength="5"></ace:TextBoxEx>
                                        </td>
                                        <td align="left" valign="middle" class="style2">
                                            <ace:LabelEx ID="LabelEx12" runat="server" CssClass="Label" Width="55px" 
                                                Height="16px">
                                                 图片：</ace:LabelEx>
                                            </td>
                                        <td align="right" valign="middle" class="style2">
                                            <asp:FileUpload ID="FileUpload1" runat="server" Width="330px" />
                                        </td>
                                        <td align="right" valign="middle" class="style2">
                                            <asp:Button ID="btn_DeletePicture" runat="server" 
                                                onclick="btn_DeletePicture_Click" Text="删除图片" Visible="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height:45px">
                                            <ace:LabelEx ID="LabelEx5" runat="server" CssClass="Label">
                                                条码：</ace:LabelEx>
                                        </td>
                                        <td width="225">
                                            <ace:TextBoxEx ID="txt_Barcode" runat="server" ReadOnly="True" Width="200px">
                                            </ace:TextBoxEx>
                                        </td>
                                        <td align="right" colspan="3">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td valign="top" height="50">
                                            <ace:LabelEx ID="LabelEx11" runat="server" CssClass="Label">
                                               备注：
                                            </ace:LabelEx>
                                        </td>
                                        <td colspan="4">
                                            <textarea ID="txt_Description" runat="server" name="S1" rows="3" 
                                                style="width:666px"></textarea></td>
                                    </tr>
                                </table>
                            </td>
            </tr>
    <%--</ajax:AjaxPanel>--%>
                               
                        <%--<tr>
                         <td>
                                <table width="100%" cellpadding="2" cellspacing="0" border="0">
                                    <tr>
                                        <td>
                                            <ace:LabelEx ID="lblCreatedBy" runat="server" CssClass="LastUpdateLabel" Text="Created By"></ace:LabelEx>
                                            <ace:LabelEx ID="lblCreateByValue" runat="server" CssClass="LastUpdateLabel"></ace:LabelEx></td>
                                        <td>
                                            <ace:LabelEx ID="lblCreatedOn" runat="server" CssClass="LastUpdateLabel" Text="Created On"></ace:LabelEx>
                                            <ace:LabelEx ID="lblCreatedOnValue" runat="server" CssClass="LastUpdateLabel"></ace:LabelEx></td>
                                        <td>
                                            <ace:LabelEx ID="lblLastEditBy" runat="server" CssClass="LastUpdateLabel" Text="Last Edit By"></ace:LabelEx>
                                            <ace:LabelEx ID="lblLastEditByValue" runat="server" CssClass="LastUpdateLabel"></ace:LabelEx></td>
                                        <td>
                                            <ace:LabelEx ID="lblLastModifiedOn" runat="server" CssClass="LastUpdateLabel" Text="Last Modified On"></ace:LabelEx>
                                            <ace:LabelEx ID="lblLastModifiedOnValue" runat="server" CssClass="LastUpdateLabel"></ace:LabelEx>
                                        </td>
                                    </tr>
                                </table>
                                </td>
                                </tr>--%>
                    </table>
                    <asp:HiddenField ID="hiddenforimage" runat="server" />
                    <asp:HiddenField ID="hiddenforstype" runat="server" />
                    <asp:HiddenField ID="hiddenforsubtypename" runat="server" />
                    <asp:HiddenField ID="hiddenforsubtypeid" runat="server" />
                    <input type="hidden" id = "selectvalue" runat="server"/>
                    <asp:HiddenField ID="hiddenforupload" runat="server" />
    </form>
</body>
</html>
<script language="javascript">
    //alert(document.getElementById("hiddenforimage").value);
    if (document.getElementById("hiddenforimage").value != "") {
        document.getElementById("ImageEx1").src = document.getElementById("hiddenforimage").value;
    }
</script>
