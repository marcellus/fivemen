<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="产品销售" AutoEventWireup="true" CodeFile="SaleRecordAdd.aspx.cs" Inherits="Sales_SaleRecordAdd"  %>

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
    <asp:TextBox ID="txtCustomerName" Width="160px"  runat="server"></asp:TextBox></td>
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
<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Width="300px" CssClass="ButtonFlat" Text="保存并打印销售单" />
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
	cs=cs+"Text,Text5,2.116669,"+height+",宋体,10.5,False,品  名   工厂货重  零售价,-2147483640|";
	//alert("beginlist");
	
	//height=height+len;
	var table=$('#ctl00_ContentPlaceHolder1_gridview');
	//alert(table);
	var count=6;
	var l=table.find("tr").length+6;
	//alert( $("#ctl00_ContentPlaceHolder1_gridview").find("tr")[1]);
    $("#ctl00_ContentPlaceHolder1_gridview tr").each(function () {
            //alert("findtd");
            var obj=$(this).find("td");
            if(obj.length>0)
            {
               //alert("data"+obj.length);
               //alert($(obj[0]).text());
               // alert($(obj[0]).val());
               // alert($(obj[0]).html());
               var out=$(obj[1]).text()+" "+$(obj[6]).text()+" "+$(obj[8]).text();
               height=height+len;
               
	           cs=cs+"Text,Text"+count+",2.116669,"+height+",宋体,10.5,False,"+out+",-2147483640|";
	           count=count+1;
            }
            
      });

/*
	for(var i=6;i<16;i++)
	{
	    height=height+len;
	    cs=cs+"Text,Text"+i+",2.116669,"+height+",宋体,10.5,False,翡翠手环        001,-2147483640|";
	}
*/	
	
	//alert("list");
	height=height+len;
	cs=cs+"Text,Text"+count+",2.116669,"+height+",宋体,10.5,False,顾客签名：____________,-2147483640|";
	height=height+len;
	count=count+1;
	cs=cs+"Text,Text"+count+",2.116669,"+height+",宋体,10.5,False,售后电话：0755-67303932,-2147483640|";
	height=height+len;
	count=count+1;
	cs=cs+"Text,Text"+count+",2.116669,"+height+",宋体,10.5,False, ,-2147483640	";
		//alert("sendprintdata");
		//alert(cs);
	obj.printData(cs);
	
}	


</script>
</div>

    <input style="display:none" id="Button1" onclick="printSaleDetail();" class="ButtonFlat" type="button" value="测试打印销售单" />
    <div>
    <br />
    <ft:GridViewEx CssClass="gvStyle" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" runat="server" AutoUpdateAfterCallBack="true"
                                    Width="100%" ID="gridview" 
            AutoGenerateColumns="False" AllowPaging="false" AllowSorting="false"
            GridLines="Horizontal"  >
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                    <Columns>
                                       
                                       
                                        <asp:TemplateField HeaderText="序号" HeaderStyle-Width="60px"  ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                            <%#String.Format("{0}", (((GridViewRow)Container).RowIndex + 1) )%>
                                            </ItemTemplate>

<HeaderStyle Width="60px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                       </asp:TemplateField>
                                        <asp:BoundField HeaderText="品名" DataField="Product_Name" 
                                            ReadOnly="true"  HeaderStyle-Width="120px" ItemStyle-Width="120px" >
<HeaderStyle Width="120px"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
                                        </asp:BoundField>
                                        
                                        <asp:BoundField HeaderText="条码" DataField="Barcode"
                                            ReadOnly="true"  HeaderStyle-Width="120px" ItemStyle-Width="120px" >
<HeaderStyle Width="120px"></HeaderStyle>

<ItemStyle Width="120px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="款号" DataField="Style"
                                            ReadOnly="true" HeaderStyle-Width="160px" ItemStyle-Width="160px" >
<HeaderStyle Width="160px"></HeaderStyle>

<ItemStyle Width="160px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="材质" DataField="Cailiao" 
                                             ReadOnly="true"
                                            HeaderStyle-Width="80px" ItemStyle-Width="80px" >
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                         <asp:BoundField HeaderText="供货商" DataField="Factory_Name" 
                                            ReadOnly="true" HeaderStyle-Width="80px" ItemStyle-Width="80px" >
                                  
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                        
                                         <asp:BoundField HeaderText="工厂货重" DataField="Factory_Weight" 
                                            ReadOnly="true" HeaderStyle-Width="80px" ItemStyle-Width="80px" >
                                  
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                        
                                         <asp:BoundField HeaderText="净金重" DataField="Gold_NetWeight" 
                                            ReadOnly="true" HeaderStyle-Width="80px" ItemStyle-Width="80px" >
                                  
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>

                                        </asp:BoundField>
                                         <asp:BoundField HeaderText="零售价" DataField="Price" 
                                            ReadOnly="true" HeaderStyle-Width="80px" ItemStyle-Width="80px" >
                                  
<HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle Width="80px"></ItemStyle>
                                        </asp:BoundField>
                                         
                                  
                                    </Columns>
                                    
    </ft:GridViewEx>
    
    </div>
</td></tr>

</table>
     
</td>


<td>
<uc:Product ID="product1" runat="server" OnScanChanged="scanChange_Click" />

</td></tr>

</table>
</asp:Content>

