<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SaleRecordAdd.aspx.cs" Inherits="Sales_SaleRecordAdd" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table border="0px" cellpadding="0" cellspacing="0">

<tr><td style=" vertical-align:top;width:1000px">
<table>
<tr><td colspan="4">请填写以下销售详情单</td></tr>
<tr>
<td>销售员</td>
<td>
    <asp:Label ID="lbSale" Width="160px"  runat="server" Text="贾名"></asp:Label></td>
 <td>销售时间</td>
 <td><asp:Label ID="lbSaleTime" Width="160px"  runat="server" Text="lbSaleTime"></asp:Label></td>
</tr>

<tr>
<td>销售价格</td>
<td>
    <asp:TextBox ID="txtSalePrice" Width="160px" runat="server"></asp:TextBox></td>
 <td>折   扣</td>
 <td>
     <asp:TextBox ID="txtDiscount" Width="160px"  runat="server"></asp:TextBox></td>
</tr>

<tr>
<td>优惠劵编号</td>
<td>
    <asp:TextBox ID="txtCouponsNo" Width="160px"  runat="server"></asp:TextBox></td>
 <td>优惠劵金额</td>
 <td>
     <asp:TextBox ID="txtCouponsMoney" Width="160px"  runat="server"></asp:TextBox></td>
</tr>

<tr>
<td>现金</td>
<td>
    <asp:TextBox ID="txtCashMoney" Width="160px" runat="server"></asp:TextBox></td>
 <td>银行卡</td>
 <td>
     <asp:TextBox ID="txtVisaCardMoney" Width="160px"  runat="server"></asp:TextBox></td>
</tr>

<td>储蓄卡</td>
<td>
    <asp:TextBox ID="txtUserCardMoney" Width="160px" runat="server"></asp:TextBox></td>
 <td>实收金额</td>
 <td>
     <asp:TextBox ID="txtTrueMoney" Width="160px"  runat="server"></asp:TextBox></td>
</tr>

<td>客户姓名</td>
<td>
    <asp:TextBox ID="CustomerName" Width="160px"  runat="server"></asp:TextBox></td>
 <td>联系电话</td>
 <td>
     <asp:TextBox ID="txtCustomerPhone" Width="160px"  runat="server"></asp:TextBox></td>
</tr>


<td>发票编号</td>
<td> <asp:TextBox ID="txtInvoiceNo" Width="160px"  runat="server"></asp:TextBox>
    </td>
 <td>备注</td>
 <td><asp:TextBox ID="txtBz" Width="160px"  runat="server"></asp:TextBox></td>
</tr>
<tr><td colspan="4">
<asp:Button ID="btnSave" runat="server" Width="300px" CssClass="ButtonFlat" Text="保存并打印销售单" />
    <OBJECT ID="printobj" style="display:none"
	CLASSID="CLSID:A561A382-7330-4A09-923E-85F74F60B851">
</OBJECT> 
    <div style="display:none"><script type="text/javascript">
function printSaleDetail(){
//alert("beginprint");
var obj=document.getElementById("printobj");
//alert(obj);
	obj.posX="20"
	obj.posY="30"
	var cs
	cs="";
	var xj=2000;
	var len=6;
	var zl=10.5;
	var customer="";
	//cs=cs+"Text,Text15,1.587502,101.0709,宋体,9,False,tsxx5,-2147483640|";
	//cs=cs+"Text,Text14,1.587502,94.72092,宋体,9,False,tsxx4,-2147483640|";
	//cs=cs+"Text,Text13,1.587502,88.37092,宋体,9,False,tsxx3,-2147483640|";
	
	//cs=cs+"Text,lsh,27.51669,17.46252,CIA Code 39 Medium Text,14.25,False,*1110908435584*,-2147483640|";
	//cs=cs+"Text,lsh,2.116669,17.46252,CIA Code 39 Medium Text,14.25,False,*1110908435584*,-2147483640|";
	//cs=cs+"Text,Text3,2.116669,23.81252,宋体,10.5,False,业务流水号：,-2147483640|";
	
	cs=cs+"Text,Text1,15.34585,0,宋体,14.25,False,第一门店销售明细单,-2147483640|";
	
	cs=cs+"Text,lsh,2.116669,12.46252,CIA Code 39 Medium Text,14.25,False,*1110908435584*,-2147483640|";
	//cs=cs+"Text,Text2,2.116669,7.937508,宋体,10.5,False,销售流水号：贾名,-2147483640|";
	var height=20;
	height=height+len;
	cs=cs+"Text,Text2,2.116669,"+height+",宋体,10.5,False,销售员：贾名,-2147483640|";
	height=height+len;
	cs=cs+"Text,Text3,2.116669,"+height+",宋体,10.5,False,销售时间："+new Date().toLocaleString()+",-2147483640|";
	height=height+len;
	cs=cs+"Text,Text4,2.116669,"+height+",宋体,10.5,False,现金："+xj+"  找零："+zl+",-2147483640|";
	//cs=cs+"Text,Text5,15.34585,31.75003,宋体,10.5,False,找零："+zl+",-2147483640|";
	height=height+len;
	cs=cs+"Text,Text5,2.116669,"+height+",宋体,10.5,False,品  名        条  码,-2147483640|";
	//alert("beginlist");
	
	//height=height+len;
	for(var i=6;i<16;i++)
	{
	    height=height+len;
	    cs=cs+"Text,Text"+i+",2.116669,"+height+",宋体,10.5,False,翡翠手环        001,-2147483640|";
	}
	
	
	//alert("list");
	height=height+len;
	cs=cs+"Text,Text16,2.116669,"+height+",宋体,10.5,False,顾客签名：____________,-2147483640|";
	height=height+len;
	cs=cs+"Text,Text17,2.116669,"+height+",宋体,10.5,False,售后电话：0755-67303932,-2147483640|";
	height=height+len;
	cs=cs+"Text,Text18,2.116669,"+height+",宋体,10.5,False, ,-2147483640	";
		//alert("sendprintdata");
	obj.printData(cs);
	
}	


</script>
</div>
    <input id="Button1" onclick="printSaleDetail();" class="ButtonFlat" type="button" value="测试打印销售单" />
</td></tr>

</table>
     
</td>


<td>
<table style="width: 300px;">
    <tr>
        <td>
            条&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 码
        </td>
        <td colspan="3">
            <input type="text" name="txtBarCode" id="txtBarCode"  style="width: 220px"
              />  
        </td>
        
      
    </tr>
    <tr>
        <td>
            供&nbsp; 货&nbsp; 商
        </td>
        <td class="style1">
            <input name="txtGhs" type="text" id="txtGhs" />
        </td>
        <td>
            品&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 名
        </td>
        <td>
            <input name="txtPm" type="text" id="txtPm" />
        </td>
    </tr>
    <tr>
        <td>
            款&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 号
        </td>
        <td class="style1">
            <input name="txtKh" type="text" id="txtKh" />
        </td>
        <td>
            产品类别
        </td>
        <td>
            <input name="txtCplb" type="text" id="txtCplb" />
        </td>
    </tr>
    <tr>
        <td>
            材&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 质
        </td>
        <td class="style1">
            <input name="txtCz" type="text" id="txtCz" />
        </td>
        <td>
            工厂货重
        </td>
        <td>
            <input name="txtGchz" type="text" id="txtGchz" />
        </td>
    </tr>
    <tr>
        <td>
            净&nbsp; 金&nbsp; 重
        </td>
        <td class="style1">
            <input name="txtJjz" type="text" id="txtJjz" />
        </td>
        <td>
            复&nbsp; 秤&nbsp; 重
        </td>
        <td>
            <input name="txtFcz" type="text" id="txtFcz" />
        </td>
    </tr>
    <tr>
        <td>
            原&nbsp; 编&nbsp; 号
        </td>
        <td class="style1">
            <input name="txtYbh" type="text" id="txtYbh" />
        </td>
        <td>
            手&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 寸
        </td>
        <td>
            <input name="txtSc" type="text" id="txtSc" />
        </td>
    </tr>
    <tr>
        <td>
            零&nbsp; 售&nbsp; 价
        </td>
        <td class="style1">
            <input name="txtLsj" type="text" id="txtLsj" />
        </td>
        <td>
            素金工费
        </td>
        <td>
            <input name="txtSjgf" type="text" id="txtSjgf" />
        </td>
    </tr>
    <tr>
        <td>
            件&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 数
        </td>
        <td class="style1">
            <input name="txtJs" type="text" id="txtJs" />
        </td>
        <td>
            工&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 费
        </td>
        <td>
            <input name="txtGf" type="text" id="txtGf" />
        </td>
    </tr>
    <tr>
        <td>
            备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 注
        </td>
        <td colspan="3">
            <input name="txtBz" type="text" id="txtBz" style="width:230px" />
        </td>
    </tr>
    <tr>
        <td style="vertical-align:top">
            图&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 片
        </td>
        <td colspan="3">
            <img id="imgPic" src="" style="height:223px;width:230px;border-width:1px;" />
        </td>
    </tr>
</table>
<script type="text/javascript" language="javascript">
function Self_TestMethod()
{
alert("123");
}
function ShowProductDetail()
{
 //alert("begin");
  $.ajax({              
        type: "POST",             
        url: "../Services/ProductDetailShow.aspx",              
        data: "{}",              
        contentType: "application/json; charset=utf-8",              
        dataType: "json",               
        success: function(msg) {               
        //instantiate a template with data 
           // alert("success");              
              //  alert(msg.Ghs);
              $("#txtGhs").val(msg.Ghs);
               $("#txtPm").val(msg.Pm);
               
               $("#txtCplb").val(msg.Cplb);
                $("#txtCz").val(msg.Cz);
                 $("#txtKh").val(msg.Kh);
               
                $("#txtJs").val(msg.Js);
               $("#txtLsj").val(msg.Lsj);
               
                $("#txtSjgf").val(msg.Sjgf);
               $("#txtSc").val(msg.Sc);
               
               
                $("#txtYbh").val(msg.Ybh);
               $("#txtJjz").val(msg.Jjz);
                $("#txtFcz").val(msg.Fcz);
                 $("#txtGchz").val(msg.Gchz);
               
                $("#txtGf").val(msg.Gf);
               $("#txtBz").val(msg.Bz);
               
                $("#txtGf").val(msg.Gf);
               $("#txtBz").val(msg.Bz);
               alert(msg.ImgPath);
               $("#imgPic").attr("src",msg.ImgPath);
                    if(AfterScanProcess)
                    {
                        AfterScanProcess(msg);
                    }
                },
       error:function(msg)
       { 
       //alert("error");
       //alert(msg.Ghs);
         //alert("error");
       }
                
                }); 
  //alert("end");

}

//alert("123");
$(document).ready(function() {
//alert("beginonready");
$("#txtBarCode").keydown(function(event){

if(event.keyCode==13){  
   //doSth  
   ShowProductDetail();
   }  

 
  
});        
});


</script>

</td></tr>

</table>
</asp:Content>

