<%@ Page Language="C#" MasterPageFile="~/Layout/YuanTuoSearch.master" AutoEventWireup="true"
    CodeFile="ProductDetail.aspx.cs" Inherits="YuanTuo_ProductDetail" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        *
        {
            margin: 0;
            padding: 0;
        }
        ul
        {
            list-style: none outside none;
        }
        .box
        {
            width: 280px;
            border: 0px solid orange;
           
            vertical-align:top;
        }
        .box1
        {
            height: 280px;
            background: orange;
             vertical-align:top;
        }
        .box2
        {
            width: 280px;
            height: 280px;
            overflow: hidden;
            position: relative;
             vertical-align:top;
        }
        .box2 li
        {
            float: left;
            width: 280px;
            height: 280px;
            background: red;
        }
        .box2 .list
        {
            height: 280px;
            position: absolute;
            top: 0;
            left: 0;
            width: 40000%;
        }
.numdiv
{
	padding:5 5 5 5;
	margin:5 5 5 5;
}
.numdiv a
{
	display:inline;
	width:60px;
	margin-left:40px;
	height:40px;
	line-height:40px;
	background-color:Gray;
    color:Black;
    text-decoration:none;
    float:left;
    padding:0 10 0 0;
    text-align:center;
    
}
.numdiv a:hover
{
	background-color:Aqua;
    color:White;
    text-decoration:none;

}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  

    <table border="0">
        <tr>
            <td style="width: 100px">
                &nbsp; &nbsp; &nbsp; &nbsp;
            </td>
            <td style="padding-top:20px">
           
                <asp:Repeater runat="server" ID="repeater1" OnItemCommand="repeater1_ItemCommand">
                    <HeaderTemplate>
                        <table width="100%" border="0" align="center">
                            <tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <td style="vertical-align:top">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 1000px; table-layout: fixed">
                                <tr>
                                    <td style="vertical-align:top;width: 280px; height: 280px;">
                                    
                                        <div class="box" style="vertical-align:top; background-color:blue">
                                            <div class="box2" id="box2" style="vertical-align:top; background-color:blue">
                                                <ul class="list" style="vertical-align:top; background-color:blue">
                                                    <% foreach (string i in CycleImages) {%>
                                                       <% if(i.Length>0) {%>
                                                    <li style="background-color:blue">
                                                        <img alt="3" src="ProductPic/<%=i%>" width="280" height="280" /></li>
                                                    <%}%>
                                                    <%}%>
                                                </ul>
                                            </div>
                                        </div>
                                    </td>
                                    <td>
                                        <div>
<div style="display:none">
    <input id="hidId" runat="server" type="hidden" />
                                           
</div>
                                            
                                        </div>
                                        
                                        <div style="height: 140px; padding-top:0px; padding-left:35px;font-family:黑体; font-size:13pt;
                                             word-wrap: break-word; word-break: normal;">
                                             <div style="height:40px;width:100%; overflow-y:auto;color:red; font-size:16pt"><%=SendInfo%></div>
                                         <div style="height:20px">产品名称：<%#Eval("name") %></div>
                             
                                        <div style="height:20px">品&nbsp;&nbsp;&nbsp;牌：<%#Eval("pinpai") %></div>
                                        
                                        <div style="height:20px">规&nbsp;&nbsp;&nbsp;格：<%#Eval("guige") %></div>
                                        
                                        <div style="height:20px">产&nbsp;&nbsp;&nbsp;地：<%#Eval("chandi") %></div>
                                        
                                       <div>浏览次数：<%#(((int)Eval("seetimes"))+1) %>次</div>
                                        </div>
                                        <div>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                        <td style="vertical-align:top">
                                        <div 
                                            style="vertical-align:top;font-size: 16pt; width: 240px; height: 71px; display: block; background-image: url(images/buyback.png)">
                                                <div onclick="showKeyboard(this);" style="vertical-align:top">
                                                        <br />
                                                    <div style="text-align:right; margin-right:2px;">￥<span onclick="showKeyboard(this.parent);"  style=" color:red" id="spanprice"><%#Eval("disacountprice", "{0:f2}")%></span><asp:Label
                                                        ID="lbBuyAndPrint2" runat="server" Text='购买商品' ></asp:Label></div>
                                                         <div style="font-size: 11pt; text-align: right" onclick="showKeyboard(this.parent);">
                                                    打印凭条&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                                </div>
                                               
                                            </div>
                                            <div onclick="javascript:document.getElementById('ctl00_ContentPlaceHolder1_repeater1_ctl01_lbAddToStore').click();"
                                            style="font-size: 16pt; width: 240px; height: 71px; display: block; background-image: url(images/tostoreback.png)">
                                            <br />
                                            &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lbAddToStore2" runat="server" Text="加入购物车" ForeColor="Gray"></asp:Label>&nbsp;&nbsp;</div>
                                        <div style="display: none">
                                            <asp:Button CommandName="buyAndPrint" ID="lbBuyAndPrint" runat="server" Text="购买商品" />
                                            <asp:Button ID="lbAddToStore" CommandName="addToStore" runat="server" Text="加入购物车" /></div>
                                        <div>
                                            <asp:Label ID="lbMsg" ForeColor="Red" runat="server" Text=""></asp:Label></div>
                                        </td>
                                        <td style="">
                                        
                                         <div  id="numberkeyboard" style="margin-left:30px;background-color:Olive;width:250px;display:none; position:absolute">
<table border="0" style="font-family:Arial;font-size:18pt"> 
<tr> 
<td colspan="3" align="left">
购买数量：
<br />
<div style="color:#db4701">
<input type="text"  name="txtOrderNum" id="txtOrderNum" value="" style=" background-color:Olive;font-size:20pt; border:0px; border-bottom:solid 1px black;width:240px;text-align:left; color:Red " readonly /></td> 
</div>
</tr> 
<tr > 
<td align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'" name="btn" value=" 7 " onclick="funKey('7');"></TD> 
<td align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'"  name="btn" value=" 8 " onclick="funKey('8');"></TD> 
<td align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'"  name="btn" value=" 9 " onclick="funKey('9');"></TD> 
</tr> 
<tr> 
<td align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'"  name="btn" value=" 4 " onclick="funKey('4');"></TD> 
<td align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'"  name="btn" value=" 5 " onclick="funKey('5');"></TD> 
<td align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'" name="btn" value=" 6 " onclick="funKey('6');"></TD> 

</tr> 
<tr> 
<td align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'" name="btn" value=" 1 " onclick="funKey('1');"></TD> 
<td align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'" name="btn" value=" 2 " onclick="funKey('2');"></TD> 
<td align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'" name="btn" value=" 3 " onclick="funKey('3');"></TD> 

</tr> 
<tr> 
<td align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'" name="btn" value=" 0 " onclick="funKey('0');"></TD> 
<td align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'" name="btn" value="确定" onclick="orderNum();"></TD> 
<td align="center"><input type="button" style="width:80px;height:50px; color:black;font-size:20pt" onmouseover="javascript:this.style.color='blue';" onmouseout="javascript:this.style.color='black'" name="btn" value="取消" onclick="cancelKey();"></TD> 
 
</tr> 
</TABLE> 
</div>
<SCRIPT  type="text/javascript"> 
<!-- 
var showFlag = false; 

function funKey(cmd){ 
var obj = document.getElementById("txtOrderNum"); 
obj.value = obj.value + cmd; 
} 

function showKeyboard(obj)
{
var left = obj.offsetLeft;
            var top = obj.offsetTop;
            var width = obj.offsetWidth ;
            var height = obj.offsetHeight ;
           //alert(width);
          // alert(height)
            while(obj = obj.offsetParent){
                left += obj.offsetLeft;
                top += obj.offsetTop;
            }
             left += width-10;
             top += height-70;
           // alert(left);
           // alert(top);
var keyboard=document.getElementById("numberkeyboard");
keyboard.style.display="";
keyboard.style.left = left;
    keyboard.style.top = top;
    keyboard.style.zIndex = 1000;
document.getElementById("txtOrderNum").value="";

}
function orderNum()
{
//alert("ordernumbegin");
//alert(document.getElementById("spanprice").innerHTML);
var url="SendSmsToUser.aspx?ordernum="+document.getElementById("txtOrderNum").value+"&price="+document.getElementById("spanprice").innerHTML;
//alert("tourl:"+url);
window.location.href=url;
//alert("ordernum"+document.getElementById("txtOrderNum").value);
}
function cancelKey()
{
var keyboard=document.getElementById("numberkeyboard");
//alert(keyboard);
keyboard.style.display="none";

}

//--> 
</SCRIPT> 
                                        
                                        </td>
                                        </tr>
                                        </table>
                                        
                                            
                                        </div>
                                        
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    <br />
                                        <!-- #b0e2f9-->
                                       <div style="border-bottom:solid 1px  #b0e2f9; vertical-align:bottom; background-image:url('images/ProductDesHeader.png'); height:25px; background-repeat:no-repeat">
                                       
                                       </div>
                                       <div style="margin-top:15px">
                                        <table border="0" cellpadding="0" cellspacing="0" style="padding:0; margin:0; vertical-align:top">
                                        <tr>
                                        <td style="vertical-align:top"><img  alt="" width="166" height="130" src='ProductPic/<%=ImgMain %>' /></Td>
                                        <td style="vertical-align:top; margin-left:20px; padding-left:20px">
                                        <div style="overflow-y:auto; height:148px;  width:810px; font-family:Arial">
                                        <%=Description %>
                                        </div>
                                        </td>
                                        </tr>
                                        </table>
                                       </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tr></table>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
        </tr>
    </table>
   

    <script type="text/javascript">
function show()
{
   alert("真棒");
}     
      //  setInterval("nextAd()",2000);
//nextAd();

 window.onload=function(){
 var box2=document.getElementById('box2');
             // alert(box2);

        var oUl=box2.getElementsByTagName('ul')[0];
       // alert(oUl);

        var aLi=oUl.getElementsByTagName('li');
      //  alert(aLi);

        var lenAd=aLi.length;
//alert(lenAd);
//alert(aLi[0]);
var wAd=280;
if(aLi[0])
        wAd=aLi[0].offsetWidth;
//alert(wAd);
        var indexAd=0;

        var bAd=true;

        var timerAd=null;
         function nextAd(){

//alert("next");
            bAd?indexAd++:indexAd--;

            (indexAd==0 || indexAd==lenAd-1) && (bAd=!bAd);

            startMove(-indexAd*wAd);

        }
        
         function doMove(iTarget){

//alert("domove");
            var iSpeed=(iTarget-oUl.offsetLeft)/14;

            iSpeed = iSpeed > 0 ? Math.ceil(iSpeed) : Math.floor(iSpeed);        

            oUl.offsetLeft == iTarget ? clearInterval(timer) : oUl.style.left = oUl.offsetLeft + iSpeed + "px";

        };

        function startMove(iTarget){//alert(1);
//alert("startMove");
            clearInterval(timerAd);

            timerAd=setInterval(function(){

                doMove(iTarget);

            },30)

        };
 // alert("afterLoad");     
  setInterval(nextAd,5000);
  //alert("afterLoad2");
    };

    </script>

</asp:Content>
